using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Drawing;
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

        public App()
        {
            InitializeComponent();
            labelDownloadSpeed.Text = "";
            labelLog.Text = "";
            buttonGo.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.ActiveControl = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.ActiveControl = null;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            Core.LaunchArma3();
        }

        public void Log(string shortMessage)
        {
            Log(shortMessage, Color.Orange);
        }

        public void LogError(string shortMessage)
        {
            Log(shortMessage, Color.OrangeRed);
        }

        private void Log(string shortMessage, Color color)
        {
            //Thread Safe
            BeginInvoke((MethodInvoker) delegate
            {
                labelLog.ForeColor = color;
                if (shortMessage != null)
                    labelLog.Text = shortMessage;
                Task.Delay(1000);
            });
        }

        public void OnDownloadSuccess()
        {
            //Thread Safe
            BeginInvoke((MethodInvoker) delegate
            {
                labelDownloadSpeed.Text = "";
            });
        }

        public void Success()
        {
            //Thread Safe
            BeginInvoke((MethodInvoker)delegate
            {
                progressBarEx1.Visible = false;
                buttonGo.Enabled = true;
            });
        }

        private bool LocalVerification()
        {
            if (Core.GetArma3Path() == null) {      LogError("Arma 3 est introuvable");                      return false; }
            if (Core.GetTeamSpeakPath() == null) {  LogError("TeamSpeak 3 Client est introuvable");          return false; }
            Log("installation ok");
            return true;
        }

        private bool RemoteVerification()
        {
            if (!Core.CheckInternetConnection()) {   LogError("pas de connexion internet");                   return false; }
            if (!Core.CheckServerOnline()) {         LogError("le serveur est hors ligne pour l'instant");    return false; }
            Log("serveur ok");
            return true;
        }

        private bool UpdateVerification()
        {
            
            if (Core.CheckForUpdate())
            {
                Config config = new Config("https://github.com/Orkad/Launcher/blob/master/launcher.cfg?raw=true");
                foreach (var mod in config.Mods)
                {
                    Log("téléchargement de " + mod.Name);
                    mod.DownloadMod(DownloadProgress);
                    OnDownloadSuccess();
                    Log("extraction de " + mod.Name);
                    try { mod.DeployMod(ExtractProgress); }
                    catch (UnauthorizedAccessException e) { LogError(mod.Name + " accès refusé"); return false; }
                    catch (IOException e) { LogError(mod.Name + " en cours d'utilisation"); return false; }
                    mod.DeleteTmpFile();
                }
                
                Log("installation réussie");
                Success();
                /*string zip;
                //TODO en construction
                try {zip = Core.Download("https://github.com/Orkad/launcher/blob/master/%40CBA_A3.zip" + "?raw=true", OnDownloadChanged).Result; }
                catch(Exception e) { LogError("erreur lors du téléchargement"); throw e; }
                Log("téléchargement ok");
                Core.ExtractZip(zip, @"C:\Users\Orkad\Desktop\TestExtract");*/
            }
            return true;
        }

        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                progressBarEx1.Value = e.ProgressPercentage;
                labelDownloadSpeed.Text = Core.FormatBytes(e.BytesReceived) + "/" +
                                          Core.FormatBytes(e.TotalBytesToReceive);
            });
        }

        private void ExtractProgress(float percent)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                progressBarEx1.Value = (int) percent;
            });
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                LocalVerification();
                Task.Delay(1000).Wait();
                RemoteVerification();
                Task.Delay(1000).Wait();
                UpdateVerification();
            }).Start();
        }
    }
}
