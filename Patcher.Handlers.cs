using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cyberpunk_2077_AMD_Optimization_Patcher
{
    public partial class Patcher
    {
        private void changePathButton_Click(object sender, EventArgs e)
        {
            chooseCyberpunkFileDialog.ShowDialog();
        }
        private void chooseCyberpunkFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = chooseCyberpunkFileDialog.FileName;
        }
        private void patchButton_Click(object sender, EventArgs e)
        {
            PatcherError error = tryPatch(textBox1.Text.Trim(), onlyCheck: false);
            handleError(error, PatcherErrorHandlerType.NotifyByDialog, handleSuccess: false);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (!textBoxHinted)
                return;

            textBox1.Clear();
            textBox1.ForeColor = Color.Black;

            textBoxHinted = false;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBoxHinted || !string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            textBoxHinted = true;

            textBox1.Text = TEXTBOX_HINT_TEXT;
            textBox1.ForeColor = Color.Gray;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHinted && (
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                textBox1.Text == TEXTBOX_HINT_TEXT
            ))
                return;

            PatcherError error = tryPatch(textBox1.Text.Trim(), onlyCheck: true);
            handleError(error, PatcherErrorHandlerType.NotifyByErrorProvider);

            textBox1.ForeColor = Color.Black;
            textBoxHinted = false;
        }
        private void patchingBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
                return;

            (FileInfo fileInfo, PatcherFileProcessingType patchType) = ((FileInfo, PatcherFileProcessingType))(e.Argument);


            PatcherErrorHandlerType handlerType;

            switch (patchType)
            {
                case PatcherFileProcessingType.Check:
                    handlerType = PatcherErrorHandlerType.NotifyByErrorProvider;
                    break;
                case PatcherFileProcessingType.Patch:
                    handlerType = PatcherErrorHandlerType.NotifyByDialog;
                    break;
                default:
                    return;
            }

            e.Result = (processFile(fileInfo, patchType), handlerType);
        }
        private void patchingBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void patchingBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PatcherError error;
            PatcherErrorHandlerType handlerType;

            if (e.Cancelled)
                return;

            if (e.Error != null)
            {
                error = PatcherError.BGTaskError;
                handlerType = PatcherErrorHandlerType.NotifyByDialog;
            }
            else if (e.Result != null)
                (error, handlerType) = ((PatcherError, PatcherErrorHandlerType))(e.Result);
            else
                return;

            handleError(error, handlerType);
        }
        private void Patcher_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = getFirstDraggedFile(e);
            if (fileName.EndsWith(PATCH_FILE_NAME))
                textBox1.Text = fileName;
        }
        private void Patcher_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = getFirstDraggedFile(e).EndsWith(PATCH_FILE_NAME)
                    ? DragDropEffects.Copy
                    : DragDropEffects.None;

        }
        private void Patcher_Load(object sender, System.EventArgs e)
        {
            PatcherError error = updateSignatures();
            handleError(error, PatcherErrorHandlerType.NotifyByDialog, handleSuccess:false);
        }
        private void Patcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing &&
                patchingBGWorker.IsBusy &&
                isPatchingNow
            )
                e.Cancel = true;
        }

        private static string getFirstDraggedFile(DragEventArgs e)
        {
            string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop));

            return files.Length >= 1 ? files[0] : string.Empty;
        }

        private static bool textBoxHinted = true;
    }
}
