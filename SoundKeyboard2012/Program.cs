using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Threading;

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
            Application.Run(new MainForm());
        }
    }
}
