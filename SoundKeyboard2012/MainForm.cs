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
using System.Runtime.Serialization.Formatters.Binary;

namespace SoundKeyboard2012
{
    [Serializable]
    public partial class MainForm : Form
    {
        private KeyboardHookListener @keyboard_listener;
        private bool @can_close = false;

        private SoundPackList list;
        private SoundEndine engine = null;

        private readonly string @setting_path;
        private readonly KeysDisplayForm mKeysDisplayForm = new KeysDisplayForm();

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

        private event EventHandler EnableDefaultSoundChanged;
        private bool mEnableDefaultSound = false;

        private bool EnableDefaultSound
        {
            get { return mEnableDefaultSound; }
            set
            {
                if (mEnableDefaultSound != value)
                {
                    mEnableDefaultSound = value;

                    if (EnableDefaultSoundChanged != null)
                        EnableDefaultSoundChanged(this, EventArgs.Empty);
                }
            }
        }

        private event EventHandler ShowKeyInputChanged;
        private bool mShowKeyInput = true;

        private bool ShowKeyInput
        {
            get { return mShowKeyInput; }
            set
            {
                if (mShowKeyInput != value)
                {
                    mShowKeyInput = value;

                    if (ShowKeyInputChanged != null)
                        ShowKeyInputChanged(this, EventArgs.Empty);
                }
            }
        }

        private const int BaloonTimeout = 3000;

        public MainForm()
        {
            InitializeComponent();

            // 01. Get/Create Path for Saving Setting File

            @setting_path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Application.ProductName
            );

            if (!Directory.Exists(@setting_path))
                Directory.CreateDirectory(@setting_path);
            
            @setting_path = Path.Combine(@setting_path, "Settings.config");

            // 02. Parepare events for MainForm

            Load += new EventHandler(MainForm_Load);
            FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            IsMuteChanged += (_sender, _e) =>
            {
                menuItemIsMute.Checked = IsMute;
                checkBoxMute.Checked = IsMute;

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format(
                        "ミュートを {0} にしました",
                        IsMute ? "有効" : "無効"),
                    ToolTipIcon.Info
                );
            };

            EnableDefaultSoundChanged += (_sender, _e) =>
            {
                checkBoxEnableDefaultSound.Checked = EnableDefaultSound;
                /* engine.EnableDefaultSound = EnableDefaultSound */

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format(
                        "デフォルトサウンドの再生を {0} にしました",
                        EnableDefaultSound ? "有効" : "無効"),
                    ToolTipIcon.Info
                );
            };

            ShowKeyInputChanged += (_sender, _e) =>
            {
                checkBoxShowKeyInput.Checked = ShowKeyInput;
                mKeysDisplayForm.Visible = ShowKeyInput;

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format(
                        "入力キーの表示を {0} にしました",
                        ShowKeyInput ? "有効" : "無効"),
                    ToolTipIcon.Info
                );
            };

            AppDomain.CurrentDomain.FirstChanceException += (_sender, _e) =>
            {
                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format(
                        "初回例外。{0}：{1}\r\n" +
                        "正しく初期化されなかった可能性があります",
                        _e.Exception.Source,
                        _e.Exception.Message),
                    ToolTipIcon.Error
                );
            };
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            labelProductName.Text = Application.ProductName;
            labelCopyright.Text = Application.CompanyName;
            labelVersion.Text = Application.ProductVersion;

            // 01. NotifyIcon Initialization

            notifyIcon.Text = Application.ProductName;

            menuItemSettings.Click += (_sender, _e) =>
            {
                WindowState = FormWindowState.Normal;
                Show();
            };

            menuItemIsMute.Click += (_sender, _e) =>
            {
                IsMute = !IsMute;
            };

            checkBoxMute.Click += (_sender, _e) =>
            {
                IsMute = checkBoxMute.Checked;
            };

            checkBoxEnableDefaultSound.Click += (_sender, _e) =>
            {
                EnableDefaultSound = checkBoxEnableDefaultSound.Checked;
            };

            checkBoxShowKeyInput.Click += (_sender, _e) =>
            {
                ShowKeyInput = checkBoxShowKeyInput.Checked;
            };

            menuItemExit.Click += (_sender, _e) =>
            {
                @can_close = true; Close();
            };

            buttonMinimize.Click += (_sender, _e) =>
            {
                Close();
            };

            buttonExit.Click += (_sender, _e) =>
            {
                @can_close = true; Close();
            };

            buttonAddSoundPack.Click += (_sender, _e) =>
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        list.Add(new SoundPack(dialog.SelectedPath));
                        list.Save(setting_path);
                        list.Load(setting_path);
                    }
                }
            };

            buttonDeleteSoundPack.Click += (_sender, _e) =>
            {
                list.RemoveAt(comboBoxSoundPacks.SelectedIndex);
                list.Save(setting_path);
                list.Load(setting_path);
            };

            // 02. Prepare Event for Combobox & Reload Button

            comboBoxSoundPacks.SelectedIndexChanged += (_sebder, _e) =>
            {
                @list.SelectedIndex = comboBoxSoundPacks.SelectedIndex;
            };

            buttonReloadSoundPacks.Click += (_sebder, _e) =>
            {
                @list.Load(@setting_path);
            };

            // 03. Load SoundPack List & SoundEngine

            @list = new SoundPackList(
                Path.Combine(Application.StartupPath, "Sounds")
            );

            @list.Loaded += (_sender, _e) =>
            {
                comboBoxSoundPacks.DataSource = @list.Select(_ => _.Name).ToList();

                menuItemChangeSoundPacks.DropDown = new ToolStripDropDown();

                foreach (var pack in @list)
                {
                    var item = menuItemChangeSoundPacks.DropDown.Items.Add(pack.Name);

                    item.Click += (_1, _2) =>
                    {
                        @list.SelectedName = item.Text;
                    };
                }
            };

            @list.SelectIndexChanged += (_sender, _e) =>
            {
                if (@engine != null) @engine.Dispose();

                @engine = SoundEndine.FromSoundPack(@list.SelectedItem);

                notifyIcon.ShowBalloonTip(
                    BaloonTimeout,
                    Application.ProductName,
                    string.Format("サウンドパック {0} をロードしました", engine.Name),
                    ToolTipIcon.Info
                );

                comboBoxSoundPacks.SelectedIndex = @list.SelectedIndex;
                label1.Text = list.SelectedName;
            };

            @list.Load(@setting_path);

            // 04. Keyboard Listener Initialization

            @keyboard_listener = new KeyboardHookListener(new GlobalHooker())
            {
                Enabled = true,
            };

            mKeysDisplayForm.Show();

            @keyboard_listener.KeyDown += (_sender, _e) =>
            {
                mKeysDisplayForm.DisplayKeys = _e.KeyData;

                if (!IsMute) @engine.Play(_e.KeyData);

                if (_e.KeyData == Keys.M &&
                    Keys.Shift == (Control.ModifierKeys & Keys.Shift) &&
                    Keys.Control == (Control.ModifierKeys & Keys.Control))
                    IsMute = !IsMute;
            };

            @keyboard_listener.KeyUp += (_sender, _e) =>
            {
                /* On Modifier Key */
                if (SoundEndine.IsModifierKey(_e.KeyData))
                    @engine.ObsoluteKeys.Remove(_e.KeyData);
            };
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (@can_close)
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
            if (@keyboard_listener != null)
                @keyboard_listener.Dispose();

            list.Save(@setting_path);
        }
    }
}
