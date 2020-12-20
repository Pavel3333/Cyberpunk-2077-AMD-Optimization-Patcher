using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Cyberpunk_2077_AMD_Optimization_Patcher
{
    public partial class Patcher : Form
    {
        private enum PatcherError
        {
            Ok,

            #region Common exceptions
            IOError,
            AccessError,
            #endregion

            #region Patch errors
            InvalidPath,
            FileNotExists,
            BGTaskError,
            InvalidFileHash,
            SignatureNotFound,
            #endregion

            #region Signatures updating errors
            SignatureFileGettingError,
            JSONReaderError,
            #endregion

            Unknown,

            PatcherErrorsCount
        }

        private string[] PatcherErrorDesc =
        {
            "Success",

            "I/O error occured.",
            "File access error occured.",

            "Invalid path",
            "File is not exists",
            "Error while processing background task",
            "Invalid file hash",
            "Signature was not found",

            "Error while getting signatures. In the future, the patcher will use built-in (possibly outdated) signatures to work. Exception data: \n",
            "Error while parsing signatures. In the future, the patcher will use built-in (possibly outdated) signatures to work. Exception data: \n",

            "Unknown error",

            "PatcherErrorsCount"
        };

        private enum PatcherFileProcessingType
        {
            Check,
            Patch
        }

        private enum PatcherErrorHandlerType
        {
            NotifyByDialog,
            NotifyByErrorProvider
        }


        public Patcher()
        {
            InitializeComponent();
        }

        private string getErrorMessage(PatcherError error) {
            string msg;

            switch (error)
            {
                case PatcherError.Ok:
                    msg = "Successfully patched! (Backup file also was created)";
                    break;
                case PatcherError.IOError:
                case PatcherError.AccessError:
                case PatcherError.JSONReaderError:
                case PatcherError.SignatureFileGettingError:
                    msg = PatcherErrorDesc[(uint)error] + EXCEPTION_INFO_PREFIX + extraData;
                    break;
                default:
                    msg = PatcherErrorDesc[(uint)error];
                    break;
            }

            return msg;
        }


        private void handleError(PatcherError error, PatcherErrorHandlerType handlerType, bool handleSuccess=true)
        {
            if (handlerType == PatcherErrorHandlerType.NotifyByErrorProvider)
            {
                bool enabled = patchButton.Enabled = error == PatcherError.Ok;
                if (!enabled)
                    textboxErrorProvider.SetError(textBox1, getErrorMessage(error));
                else
                    textboxErrorProvider.SetError(textBox1, string.Empty);
            }
            else if (handlerType == PatcherErrorHandlerType.NotifyByDialog)
            {
                string capture;
                MessageBoxIcon icon;

                if (error == PatcherError.Ok)
                {
                    if (!handleSuccess)
                        return;

                    capture = "Success!";
                    icon = MessageBoxIcon.Information;
                }
                else
                {
                    capture = "Error";
                    icon = MessageBoxIcon.Error;
                }

                MessageBox.Show(getErrorMessage(error), capture, MessageBoxButtons.OK, icon);
            }
        }

        private static string bytesToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder hexdigest = new StringBuilder(bytes.Length * 2);

            foreach (byte b in bytes)
                hexdigest.Append(b.ToString(upperCase ? "X2" : "x2"));

            return hexdigest.ToString();
        }

        private static byte[] hexToBytes(string hex)
        {
            string[] hexBytes = hex.Split();
            uint hexBytesSize = (uint)(hexBytes.Length);

            byte[] bytes = new byte[hexBytesSize];

            for (uint i = 0; i < hexBytesSize; i++)
                bytes[i] = (Convert.ToByte(hexBytes[i], 16));

            return bytes;
        }

        private string getFileHash(FileStream fileStream)
        {
            fileStream.Position = 0;

            byte[] fileHashBytes = SHA256.Create().ComputeHash(fileStream);

            return bytesToHex(fileHashBytes, upperCase: true);
        }

        private void onOperationFinished()
        {
            patchingBGWorker.ReportProgress((int)(
                100.0 *
                (float)(++finishedOperations) /
                (float)(PATCH_OPERATIONS_COUNT)
            ));
        }

        private PatcherError patchFile(FileInfo fileInfo, PatcherSignature patcherSignature)
        {
            FileStream fileStream;

            finishedOperations = 0;
            patchingBGWorker.ReportProgress(0);

            int fileSize = (int)(fileInfo.Length);
            byte[] fileContents = new byte[fileSize];

            using (fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read))
            {
                fileStream.Position = 0;
                fileStream.Read(fileContents, 0, fileSize);
            }

            onOperationFinished();

            FileInfo backupFileInfo = new FileInfo(fileInfo.FullName + ".bak");
            using (fileStream = backupFileInfo.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Position = 0;
                fileStream.Write(fileContents, 0, fileSize);
            }

            onOperationFinished();

            string[] signature = patcherSignature.Signature.Split();
            byte[] replacement = hexToBytes(patcherSignature.Replacement);

            int signatureSize = signature.Length;
            int replacementSize = replacement.Length;

            bool signatureFound = false;

            for (int fileOffset = 0; fileOffset < fileSize; fileOffset++)
            {
                signatureFound = true;

                for (int signatureOffset = 0; signatureOffset < signatureSize; signatureOffset++)
                {
                    string signatureByte = signature[signatureOffset];
                    if (signatureByte == "??")
                        continue;

                    if (fileContents[fileOffset + signatureOffset] != Convert.ToByte(signatureByte, 16))
                    {
                        signatureFound = false;
                        break;
                    }
                }

                if (signatureFound)
                {
                    for (int replacementOffset = 0; replacementOffset < replacementSize; replacementOffset++)
                        fileContents[fileOffset + replacementOffset] = replacement[replacementOffset];

                    break;
                }
            }

            if (!signatureFound)
                return PatcherError.SignatureNotFound;

            onOperationFinished();

            isPatchingNow = true;

            using (fileStream = fileInfo.Open(FileMode.Open, FileAccess.Write))
            {
                fileStream.Position = 0;
                fileStream.Write(fileContents, 0, fileSize);
            }

            isPatchingNow = false;

            onOperationFinished();

            return PatcherError.Ok;
        }

        private PatcherError processFile(FileInfo fileInfo, PatcherFileProcessingType processingType)
        {
            FileStream fileStream;

            try
            {
                if (processingType == PatcherFileProcessingType.Check ||
                    processingType == PatcherFileProcessingType.Patch
                )
                {
                    PatcherSignature patcherSignature;

                    using (fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                    {
                        string fileHash = getFileHash(fileStream);

                        patcherSignature = signatures.Find(x => x.Hashes.Contains(fileHash));
                        if (patcherSignature == null)
                            return PatcherError.InvalidFileHash;
                    }

                    if (processingType == PatcherFileProcessingType.Patch)
                    {
                        PatcherError error = patchFile(fileInfo, patcherSignature);
                        if (error != PatcherError.Ok)
                            return error;
                    }
                }
            }
            catch (IOException e)
            {
                extraData = e.Message;
                return PatcherError.IOError;
            }
            catch (UnauthorizedAccessException e)
            {
                extraData = e.Message;
                return PatcherError.AccessError;
            }

            return PatcherError.Ok;
        }

        private PatcherError tryPatch(String path, bool onlyCheck)
        {
            if (!path.EndsWith(PATCH_FILE_NAME))
            {
                return PatcherError.InvalidPath;
            }

            FileInfo fileInfo = new FileInfo(Path.GetFullPath(path));
            if (!fileInfo.Exists)
            {
                return PatcherError.FileNotExists;
            }

            if (!patchingBGWorker.IsBusy)
            {
                PatcherFileProcessingType patchType = onlyCheck
                    ? PatcherFileProcessingType.Check
                    : PatcherFileProcessingType.Patch;

                patchingBGWorker.RunWorkerAsync((fileInfo, patchType));
            }

            return PatcherError.Ok;
        }

        // Operations while patching:
        // - Read src file into buffer
        // - Write backup
        // - Patch buffer
        // - Rewrite src file

        private static readonly int PATCH_OPERATIONS_COUNT = 4;
        private static readonly string PATCH_FILE_NAME = "Cyberpunk2077.exe";
        private static readonly string TEXTBOX_HINT_TEXT = $"Path to {PATCH_FILE_NAME}";
        private static readonly string EXCEPTION_INFO_PREFIX = " Exception data: ";

        private static bool isPatchingNow = false;
        private static uint finishedOperations = 0;
        private static string extraData;
    }
}
