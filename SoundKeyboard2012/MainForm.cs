using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Media;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace SoundKeyboard2012
{
    public partial class MainForm : Form
    {
        private KeyboardHookListener keyboard_listener;
        private bool CanClose = false;

        private readonly string SoundPackPath;
        private SoundEndine engine = null;

        private const int BaloonTimeout = 3000;

        public MainForm()
        {
            InitializeComponent();

            SoundPackPath = Path.Combine(Application.StartupPath, "Sounds");

            Load += new EventHandler(MainForm_Load);
            FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            // 01. NotifyIcon Initialization

            notifyIcon.Text = Application.ProductName;

            menuItemSettings.Click += (_sender, _e) =>
            {
                Show();
            };

            menuItemExit.Click += (_sender, _e) =>
            {
                CanClose = true; Close();
            };

            // 02. Prepare Event for Combobox & Reload Button

            comboBoxSoundPacks.SelectedIndexChanged += (_sebder, _e) =>
            {
                var path = Path.Combine(
                    SoundPackPath,
                    comboBoxSoundPacks.SelectedItem.ToString());

                if (engine != null) engine.Dispose();

                engine = new SoundEndine(path);

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format("サウンドパック {0} をロードしました", engine.Name),
                    ToolTipIcon.Info
                );
            };

            buttonReloadSoundPacks.Click += (_sebder, _e) =>
            {
                comboBoxSoundPacks.DataSource = new DirectoryInfo(SoundPackPath)
                    .GetDirectories()
                    .Select(_ => _.Name)
                    .ToArray();
            };

            // 03. Load SoundPack List & SoundEngine (must be after 02.)
            
            /* load soundpack list */
            buttonReloadSoundPacks.PerformClick();

            /* load a soundengine  */
            if (comboBoxSoundPacks.Items.Count > 0)
                comboBoxSoundPacks.SelectedIndex = 0;
            else
                throw new Exception("サウンドパックが見つかりません");

            // 04. Keyboard Listener Initialization

            keyboard_listener = new KeyboardHookListener(new GlobalHooker())
            {
                Enabled = true,
            };

            keyboard_listener.KeyDown += (_sender, _e) =>
            {
                labelKeyData.Text = _e.KeyData.ToString();

                engine.Play(_e.KeyData);
            };

            keyboard_listener.KeyUp += (_sender, _e) =>
            {
                // labelKeyData.Text = string.Empty;
            };
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CanClose)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                Hide();

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    "最小化しました。" + "\r\n" +
                    "終了するにはタスクトレイアイコンのコンテクストメニューを利用します",
                    ToolTipIcon.Info
                );
            }
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            keyboard_listener.Dispose();
        }
    }
}
