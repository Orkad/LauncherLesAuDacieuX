using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LauncherLesAuDacieuX.Properties;

namespace LauncherLesAuDacieuX
{
    [Serializable]
    public class Mod:IDisposable
    {
        /// <summary>
        ///     Nom du Mod
        /// </summary>
        public string Name;
        /// <summary>
        ///     Version du mod (peut ne pas correspondre a la version exacte du mod)
        /// </summary>
        public int Version;
        /// <summary>
        ///     Adresse vers la distribution du fichier zip
        /// </summary>
        public string ZipUrl;
        /// <summary>
        ///     Code d'extraction (A3 pour Arma3 ou TS3 pour TeamSpeak Client 3)
        /// </summary>
        public string Extract_code;
        /// <summary>
        ///     Chemin du fichier temporaire (nom 
        /// </summary>
        private readonly string _tmpFile = Path.GetTempPath() + Path.GetRandomFileName();

        public void DownloadMod(DownloadProgressChangedEventHandler handler = null)
        {
            Core.DownloadFile(ZipUrl, _tmpFile, handler);
        }

        public void DeployMod(Action<float> percentageAction = null)
        {
            using (var stream = File.Open(_tmpFile, FileMode.Open))
            {
                if (Extract_code == "A3")
                    ExtractOverride(new ZipArchive(stream), Core.GetArma3Path(), percentageAction);
                else if (Extract_code == "TS3")
                    ExtractOverride(new ZipArchive(stream), Core.GetTeamSpeakPath(), percentageAction);
            }
            if (File.Exists(_tmpFile))
                File.Delete(_tmpFile);
        }

        internal static void ExtractOverride(ZipArchive archive, string destinationDirectoryName, Action<float> percentageAction = null)
        {
            for (int i=0;i< archive.Entries.Count; i++)
            {
                var file = archive.Entries[i];
                string completeFileName = destinationDirectoryName + file.FullName;
                if (file.Name == "")
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }
                file.ExtractToFile(completeFileName, true);
                float progress = (float)decimal.Divide(i,archive.Entries.Count)*100;
                percentageAction?.Invoke(progress);
            }
        }

        public void Dispose()
        {
            if (File.Exists(_tmpFile))
                File.Delete(_tmpFile);
        }
    }
}
