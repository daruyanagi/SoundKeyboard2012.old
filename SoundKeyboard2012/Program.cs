using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Threading;
using System.Deployment.Application;

namespace SoundKeyboard2012
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var application_id = "SoundKeyboard 2012";

            bool createdNew;
            Mutex mutex = new Mutex(true, application_id, out createdNew);

            if (createdNew == false)
            {
                MessageBox.Show(
                    "二重起動しようとしました。このアプリケーションは終了します。",
                    application_id,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotifyIcon = new System.Windows.Forms.NotifyIcon();
            NotifyIcon.Icon = new System.Drawing.Icon("SoundKeyboard.ico");
            NotifyIcon.Visible = true;

            MainForm = new MainForm();
            MainForm.WindowState = FormWindowState.Minimized;
            MainForm.Show(); /* for initialize, once show. */
            MainForm.Hide();
            
            Application.Run();

            mutex.ReleaseMutex();
        }

        public static MainForm MainForm { get; set; }
        public static NotifyIcon NotifyIcon { get; set; }

        public static string GetVersion()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return "ポータブルバージョン";
            
            Version v = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            return string.Format("ネットワークインストールバージョン：{0}.{1}.{2}.{3}",
                v.Major, v.Minor, v.Build, v.Revision);
        }
    }
}
