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

        private SoundPackList list;
        private SoundEndine engine = null;

        private event EventHandler IsMuteChanged;
        private bool is_mute = false;

        private bool IsMute
        {
            get { return is_mute; }
            set
            {
                if (IsMute != value)
                {
                    is_mute = value;

                    if (IsMuteChanged != null)
                        IsMuteChanged(this, EventArgs.Empty);
                }
            }
        }

        private const int BaloonTimeout = 3000;

        public MainForm()
        {
            InitializeComponent();

            Load += new EventHandler(MainForm_Load);
            FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            IsMuteChanged += (_sender, _e) =>
            {
                menuItemIsMute.Checked = IsMute;

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format(
                        "ミュートを {0} にしました",
                        IsMute? "有効" : "無効"),
                    ToolTipIcon.Info
                );
            };
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            // 01. NotifyIcon Initialization

            notifyIcon.Text = Application.ProductName;

            menuItemSettings.Click += (_sender, _e) =>
            {
                Show();
            };

            menuItemIsMute.Click += (_sender, _e) =>
            {
                IsMute = !IsMute;
            };

            menuItemExit.Click += (_sender, _e) =>
            {
                CanClose = true; Close();
            };

            // 02. Prepare Event for Combobox & Reload Button

            comboBoxSoundPacks.SelectedIndexChanged += (_sebder, _e) =>
            {
                list.SelectedIndex = comboBoxSoundPacks.SelectedIndex;
            };

            buttonReloadSoundPacks.Click += (_sebder, _e) =>
            {
                list.Load();
            };

            // 03. Load SoundPack List & SoundEngine

            list = new SoundPackList(
                Path.Combine(Application.StartupPath, "Sounds")
            );

            list.Loaded += (_sender, _e) =>
            {
                comboBoxSoundPacks.DataSource = list.Select(_ => _.Name).ToList();

                menuItemChangeSoundPacks.DropDown = new ToolStripDropDown();

                foreach (var pack in list)
                {
                    var item = menuItemChangeSoundPacks.DropDown.Items.Add(pack.Name);

                    item.Click += (_1, _2) =>
                    {
                        list.SelectedName = item.Text;
                    };
                }
            };

            list.SelectIndexChanged += (_sender, _e) =>
            {
                if (engine != null) engine.Dispose();

                engine = SoundEndine.FromSoundPack(list.SelectedItem);

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format("サウンドパック {0} をロードしました", engine.Name),
                    ToolTipIcon.Info
                );

                comboBoxSoundPacks.SelectedIndex = list.SelectedIndex;
            };

            list.Load();
            list.SelectedIndex = 0; /* for load sound engine */

            // 04. Keyboard Listener Initialization

            keyboard_listener = new KeyboardHookListener(new GlobalHooker())
            {
                Enabled = true,
            };

            keyboard_listener.KeyDown += (_sender, _e) =>
            {
                labelKeyData.Text = _e.KeyData.ToString();

                if (!IsMute) engine.Play(_e.KeyData);

                if (_e.KeyData == Keys.M &&
                    Keys.Shift == (Control.ModifierKeys & Keys.Shift) &&
                    Keys.Control == (Control.ModifierKeys & Keys.Control))
                    IsMute = !IsMute;
            };

            keyboard_listener.KeyUp += (_sender, _e) =>
            {
                /* On Modifier Key */
                if (SoundEndine.IsModifierKey(_e.KeyData))
                    engine.ObsoluteKeys.Remove(_e.KeyData);
            };
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CanClose)
            {
                e.Cancel = false; /* only called from menu */
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
