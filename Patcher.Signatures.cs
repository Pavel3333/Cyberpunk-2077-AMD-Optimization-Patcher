using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;

namespace Cyberpunk_2077_AMD_Optimization_Patcher
{
    public class PatcherSignature
    {
        public PatcherSignature(string newHash, string newSignature, string newReplacement)
        {
            Hash = newHash;
            Signature = newSignature;
            Replacement = newReplacement;
        }

        public string Hash { get; set; }
        public string Signature { get; set; }
        public string Replacement { get; set; }
    }
    partial class Patcher
    {
        private PatcherError updateSignatures()
        {
            string signaturesFileContents;

            try
            {
                using (WebClient client = new WebClient())
                {
                    signaturesFileContents = client.DownloadString(PATCH_SIGNATURES_URL);
                }
            }
            catch (WebException e)
            {
                extraData = e.Message;
                return PatcherError.SignatureFileGettingError;
            }

            try
            {
                signatures = JsonConvert.DeserializeObject<List<PatcherSignature>>(signaturesFileContents);
            }
            catch (JsonReaderException e)
            {
                extraData = e.Message;
                return PatcherError.JSONReaderError;
            }

            return PatcherError.Ok;
        }

        private static readonly string PATCH_SIGNATURES_URL = "https://raw.githubusercontent.com/Pavel3333/Cyberpunk-2077-AMD-Optimization-Patcher/main/data/signatures.json";
        private static readonly List<PatcherSignature> SIGNATURES = new List<PatcherSignature>
        {
            new PatcherSignature(
                "E34EF581899F3A719001E1F85A0FD8C112B21471329DBAA9F25880E7678557A8",
                "75 30 33 C9 B8 01 00 00 00 0F A2 8B C8 C1 F9 08",
                "EB"
            )
        };

        private static List<PatcherSignature> signatures = SIGNATURES;
    }
}
