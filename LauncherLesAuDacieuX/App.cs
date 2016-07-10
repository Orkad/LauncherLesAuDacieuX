using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherLesAuDacieuX
{
    public partial class App : Form
    {
        #region EXTERNAL

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void StartDragWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        #region THREAD SAFED

        internal void ThreadSafe(Action action)
        {
            BeginInvoke((MethodInvoker) delegate { action?.Invoke(); });
        }

        internal void Log(string shortMessage, Color color)
        {
            ThreadSafe(() =>
            {
                labelLog.ForeColor = color;
                if (shortMessage != null)
                    labelLog.Text = shortMessage;
                Task.Delay(1000);
            });
        }

        internal void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ThreadSafe(() =>
            {
                progressBarEx1.Value = e.ProgressPercentage;
                labelDownloadSpeed.Text = Core.FormatBytes(e.BytesReceived) + "/" +
                                          Core.FormatBytes(e.TotalBytesToReceive);
            });
        }

        private void ExtractProgress(float percent)
        {
            ThreadSafe(() =>
            {
                progressBarEx1.Value = (int)percent;
            });
        }

        private void ClearProgress()
        {
            ThreadSafe(() =>
            {
                progressBarEx1.Value = 0;
                labelDownloadSpeed.Text = "";
            });
        }

        private void Ok()
        {
            ThreadSafe(() =>
            {
                progressBarEx1.Value = progressBarEx1.Maximum;
                progressBarEx1.ProgressColor = Color.Green;
                buttonGo.Visible = true;
                labelLog.Text = @"Verrification terminée";
            });
        }

        private void Fail()
        {
            ThreadSafe(() =>
            {
                progressBarEx1.Value = progressBarEx1.Maximum;
                progressBarEx1.ProgressColor = Color.DarkRed;
                buttonGo.Visible = true;
                buttonGo.Text = @"Réesayer";
                buttonGo.Click += (sender, args) => CheckForUpdate();
                labelLog.Text = @"Echec de la mise à jour veuillez réesayer";
            });
        }

        #endregion

        #region EVENT

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.ActiveControl = null;
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.ActiveControl = null;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            Core.LaunchArma3();
        }

        #endregion

        public App()
        {
            InitializeComponent();
            labelDownloadSpeed.Text = "";
            labelLog.Text = "";
            buttonGo.Visible = false;
            CheckForUpdate();
        }

        public void CheckForUpdate()
        {
            new Thread(() =>
            {
                LocalVerification();
                Task.Delay(1000).Wait();
                RemoteVerification();
                Task.Delay(1000).Wait();
                UpdateVerification();
                Ok();
            }).Start();
        }

        public void Log(string shortMessage)
        {
            Log(shortMessage, Color.Orange);
        }

        public void LogError(string shortMessage)
        {
            Log(shortMessage, Color.OrangeRed);
        }


        private bool LocalVerification()
        {
            if (Core.GetArma3Path() == null) {      LogError("Arma 3 est introuvable");                      return false; }
            if (Core.GetTeamSpeakPath() == null) {  LogError("TeamSpeak 3 Client est introuvable");          return false; }
            Log("Installation ok");
            return true;
        }

        private bool RemoteVerification()
        {
            if (!Core.CheckInternetConnection()) {   LogError("pas de connexion internet");                   return false; }
            if (!Core.CheckServerOnline()) {         LogError("le serveur est hors ligne pour l'instant");    return false; }
            Log("Serveur en ligne");
            return true;
        }

        private bool UpdateVerification()
        {
            var localConfig = Config.LoadLocal();
            Mod TFS_A3 = new Mod() { Extract_code = "A3", Name = "TFR (Arma 3)", Version = 2, ZipUrl = "https://www.dropbox.com/s/28fwjg15pcef7ap/TFR_A3.zip?dl=1" };
            //var remoteConfigMOK = new Config() { Mods = new List<Mod> { TFS_A3 }, ServerIp = "85.131.221.137", ServerPort = 2302, ServerName = "Les AuDacieuX" };
            var remoteConfigMOK = Config.LoadRemote("https://raw.githubusercontent.com/Orkad/Launcher/master/config?raw=true");
            var newMods = Config.ModsDifferencies(localConfig, remoteConfigMOK);
            bool errors = false;
            newMods.ForEach(mod =>
            {
                Log("Téléchargement de " + mod.Name);
                try{mod.DownloadMod(DownloadProgress);}
                catch{LogError("Echec du téléchargement de " + mod.Name); errors = true;}
                ClearProgress();
            });
            newMods.ForEach(mod =>
            {
                Log("Déploiment de " + mod.Name);
                try { mod.DeployMod(ExtractProgress); }
                catch { LogError("Echec du déploiment de " + mod.Name); errors = true;}
                ClearProgress();
            });
            if (!errors)
            {
                Ok();
                remoteConfigMOK.Save();
                return true;
            }
            Fail();
            return false;
        }
    }
}
