using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LauncherLesAuDacieuX.Properties;
using System.IO.Compression;

namespace LauncherLesAuDacieuX
{
    public class Mod:IDisposable
    {
        public string Name;
        public string Version;
        public string ZipUrl;
        public string Extract_code;
        private readonly string _tmpFileName = Path.GetTempPath() + Path.GetRandomFileName();

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Version) && !string.IsNullOrEmpty(ZipUrl) &&
                   !string.IsNullOrEmpty(Extract_code);
        }

        public void DownloadMod(DownloadProgressChangedEventHandler handler = null)
        {
            Core.Download(ZipUrl, _tmpFileName, handler);
        }

        public void DeployMod(Action<float> percentageAction = null)
        {
            using (var stream = File.Open(_tmpFileName, FileMode.Open))
            {
                if (Extract_code == "A3")
                    ExtractOverride(new ZipArchive(stream), Core.GetArma3Path(), percentageAction);
                else if (Extract_code == "TS3")
                    ExtractOverride(new ZipArchive(stream), Core.GetTeamSpeakPath(), percentageAction);
            }
        }

        public void DeleteTmpFile()
        {
            if (File.Exists(_tmpFileName))
                File.Delete(_tmpFileName);
        }

        public static void ExtractOverride(ZipArchive archive, string destinationDirectoryName, Action<float> percentageAction = null)
        {
            for(int i=0;i< archive.Entries.Count; i++)
            {
                var file = archive.Entries[i];
                string completeFileName = Path.Combine(destinationDirectoryName, file.FullName);
                if (file.Name == "")
                {// Assuming Empty for Directory
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
            DeleteTmpFile();
        }
    }

    public class Config
    {
        public List<Mod> Mods { get; set; } = new List<Mod>();
        const string MOD_NAME = "name";
        const string MOD_VERSION = "version";
        const string MOD_ZIPURL = "zip_url";
        const string MOD_EXTRACT = "extract";

        public Config(string uri)
        {
            var tmp = Core.GetRandomTempFilePath();
            Core.Download(uri, tmp);
            using(var reader = new StreamReader(File.OpenRead(tmp)))
                Read(reader);
            File.Delete(tmp);
        }

        public void Read(TextReader reader)
        {
            string currentLine;
            Mod currentMod = null;
            string currentGroup = null;
            while ((currentLine = reader.ReadLine()?.Trim()) != null)
            {
                if(currentLine.StartsWith("//"))
                    continue;
                if (currentGroup == "[mod]")
                {
                    TryExtractVar(MOD_NAME, currentLine, ref currentMod.Name);
                    TryExtractVar(MOD_VERSION, currentLine, ref currentMod.Version);
                    TryExtractVar(MOD_ZIPURL, currentLine, ref currentMod.ZipUrl);
                    TryExtractVar(MOD_EXTRACT, currentLine, ref currentMod.Extract_code);
                }
                if (currentLine == "[mod]")
                {
                    currentGroup = "[mod]";
                    if (currentMod != null && currentMod.IsValid())
                        Mods.Add(currentMod);
                    currentMod = new Mod();
                }
            }
            if (currentMod != null && currentMod.IsValid())
                Mods.Add(currentMod);
            reader.Dispose();
        }

        private static void TryExtractVar(string varName, string line, ref string value, char affectationChar = '=')
        {
            if (line.StartsWith(varName + affectationChar))
                value = line?.Substring(varName.Length + 1);
        }
    }
}
