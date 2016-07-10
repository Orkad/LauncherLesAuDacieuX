using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using LauncherLesAuDacieuX.Properties;
using Microsoft.Win32;
using System.IO.Compression;

namespace LauncherLesAuDacieuX
{
    public class Core
    {
        /// <summary>
        ///     Récupère le chemin complet vers le dossier "Arma 3" 
        /// </summary>
        /// <returns>chemin complet vers dossier Arma 3 | null si non trouvé</returns>
        public static string GetArma3Path()
        {
            if (Directory.Exists(Settings.Default.ARMA3_PATH))
                return Settings.Default.ARMA3_PATH;
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.OpenSubKey(@"Software\Valve\Steam");
            var steamPath = regKey?.GetValue("SteamPath").ToString();
            string arma3Path = steamPath + "/steamapps/common/Arma 3";
            return !Directory.Exists(arma3Path) ? null : arma3Path;
        }

        /// <summary>
        ///     Récupère le chemin complet vers le dossier "TeamSpeak"
        /// </summary>
        /// <returns>chemin complet vers le dossier "TeamSpeak 3 Client" | null si non trouvé</returns>
        public static string GetTeamSpeakPath()
        {
            if (Directory.Exists(Settings.Default.TS3_PATH))
                return Settings.Default.TS3_PATH;
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\TeamSpeak 3 Client");
            return key?.GetValue(null) as string;
        }

        /// <summary>
        ///     Verification de la connection internet
        /// </summary>
        /// <returns></returns>
        public static bool CheckInternetConnection()
        {
            try{Dns.GetHostEntry("www.google.com");return true;}
            catch{return false;}
        }

        /// <summary>
        ///     Verification de la disponibilité du serveur de jeu
        /// </summary>
        /// <returns></returns>
        public static bool CheckServerOnline()
        {
            try{return new Ping().Send(IPAddress.Parse(Settings.Default.SERVER_IP)).Status == IPStatus.Success;}
            catch{return false;}
        }

        /// <summary>
        ///     Lancement de l'application Arma 3 
        /// </summary>
        /// <param name="parameters"></param>
        public static void LaunchArma3(params string[] parameters)
        {
            string paramString = parameters.Aggregate("-mod=" + Settings.Default.ADDON_LIST + " -nopause -connect=" + Settings.Default.SERVER_IP + ":" + Settings.Default.SERVER_PORT,
                (current, additionnalParameters) => current + additionnalParameters);
            Process.Start(GetArma3Path() + "/arma3battleye.exe", paramString);
        }

        /// <summary>
        ///     Vérifie si il y a des mise a jour a effectuer
        /// </summary>
        /// <returns></returns>
        public static bool CheckForUpdate()
        {
            return true;
        }

        /// <summary>
        ///     Applique la/les mises a jour
        /// </summary>
        public static async Task<string> Download(string uri, Action<DownloadProgressChangedEventArgs> traceProgress = null)
        {
            WebClient client = new WebClient();
            string tempPath = Path.GetTempPath() + Settings.Default.TEMP_FILE_NAME;
            if(traceProgress != null)
                client.DownloadProgressChanged += (sender, args) => traceProgress?.Invoke(args);
            await client.DownloadFileTaskAsync(new Uri(uri), tempPath);
            return tempPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="fileFullPath"></param>
        /// <param name="handler"></param>
        public static void DownloadFile(string uri, string fileFullPath, DownloadProgressChangedEventHandler handler = null)
        {
            WebClient client = new WebClient();
            if (handler != null)
                client.DownloadProgressChanged += handler;
            client.DownloadFileTaskAsync(new Uri(uri), fileFullPath).Wait();
        }

        public static void ExtractZip(string zipPath, string extractPath)
        {
            new ZipArchive(File.Open(zipPath, FileMode.Open)).ExtractToDirectory(extractPath);
        }

        public static string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    //return string.Format("{0:00.00} {1}", decimal.Divide(bytes, max), order);
                return decimal.Divide(bytes,max).ToString("F") + " " + order;

                max /= scale;
            }
            return "0 Bytes";
        }

        public static string GetRandomTempFilePath() => Path.GetTempPath() + Path.GetRandomFileName();
    }
}
