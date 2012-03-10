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
    public partial class MainForm : Form
    {
        private SoundPackList mSoundPackList = null;
        private SoundEndine mSoundEngine = null;
        private bool mCanClose = false;

        private readonly string mSoundPackListConfigPath;
        private readonly string mSoundEngineConfigPath;
        private readonly KeysDisplayForm mKeysDisplayForm;

        private const int BALOON_TIMEOUT = 3000;

        #region property ShowKeyInput

        private bool KeyDisplayEnabled
        {
            get { return mKeysDisplayForm.Visible; }
            set
            {
                if (mKeysDisplayForm.Visible != value)
                {
                    mKeysDisplayForm.Visible = value;

                    if (KeyDisplayEnabledChanged != null)
                        KeyDisplayEnabledChanged(this, EventArgs.Empty);
                }
            }
        }
        private event EventHandler KeyDisplayEnabledChanged;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            // 01. Initialize readonly members

            var config_dir = Path.Combine(
                Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData),
                Application.ProductName
            );
            if (!Directory.Exists(config_dir)) Directory.CreateDirectory(config_dir);

            mSoundPackListConfigPath = Path.Combine(config_dir, "SoundPackList.config");
            mSoundEngineConfigPath = Path.Combine(config_dir, "SoundEngine.config");
            mKeysDisplayForm = new KeysDisplayForm();

            // 02. Parepare events for MainForm

            Load += new EventHandler(MainForm_Load);
            FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            KeyDisplayEnabledChanged += new EventHandler(MainForm_KeyDisplayEnabledChanged);

            AppDomain.CurrentDomain.FirstChanceException += (_sender, _e) =>
            {
                Program.NotifyIcon.ShowBalloonTip(
                    BALOON_TIMEOUT,
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
            // 01. Initialization on loaded

            labelProductName.Text = Application.ProductName;
            labelVersion.Text = Program.GetVersion();
            labelCopyright.Text = string.Format(
                "Copyright {0} 2012", Application.CompanyName);
            pictureBox1.Image = new Icon("SoundKeyboard.ico", 128, 128).ToBitmap();

            Program.NotifyIcon.Text = Application.ProductName;
            Program.NotifyIcon.ContextMenuStrip = contextMenuStrip;

            KeyDisplayEnabled = true;

            // 02. Load SoundPack List & SoundEngine

            mSoundPackList = new SoundPackList(
                Path.Combine(Application.StartupPath, "Sounds")
            );
            mSoundPackList.Loaded += new EventHandler(SoundPackList_Loaded);
            mSoundPackList.SelectIndexChanged += new EventHandler(SoundPackList_SelectIndexChanged);
            mSoundPackList.Load(mSoundPackListConfigPath);

            Visible = false;
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mCanClose)
            {
                e.Cancel = false; /* only called from menu */
            }
            else
            {
                e.Cancel = true;
                Hide();

                Program.NotifyIcon.ShowBalloonTip(
                    BALOON_TIMEOUT,
                    Application.ProductName,
                    "最小化しました。" + "\r\n" +
                    "終了するにはタスクトレイアイコンのコンテクストメニューを利用します",
                    ToolTipIcon.Info
                );
            }
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mSoundEngine != null)
                mSoundEngine.Dispose();

            mSoundPackList.Save(mSoundPackListConfigPath);

            Application.Exit();
        }

        void MainForm_KeyDisplayEnabledChanged(object sender, EventArgs e)
        {
            checkBoxShowKeyInput.Checked = KeyDisplayEnabled;
            menuItemDisplayKeyEnabled.Checked = KeyDisplayEnabled;

            Program.NotifyIcon.ShowBalloonTip(
                BALOON_TIMEOUT,
                Application.ProductName,
                string.Format(
                    "入力キーの表示を {0} にしました",
                    KeyDisplayEnabled ? "有効" : "無効"),
                ToolTipIcon.Info
            );
        }

        void buttonAddSoundPack_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    mSoundPackList.Add(new SoundPack(dialog.SelectedPath));
                    mSoundPackList.Save(mSoundPackListConfigPath);
                    mSoundPackList.Load(mSoundPackListConfigPath);
                }
            }
        }

        void buttonDeleteSoundPack_Click(object sender, EventArgs e)
        {
            mSoundPackList.RemoveAt(comboBoxSoundPacks.SelectedIndex);
            mSoundPackList.Save(mSoundPackListConfigPath);
            mSoundPackList.Load(mSoundPackListConfigPath);
        }

        void ToggleKeyDisplayEnabled(object sender, EventArgs e)
        {
            KeyDisplayEnabled = !KeyDisplayEnabled;
        }

        void ToggleDefaultSoundEnabled(object sender, EventArgs e)
        {
            mSoundEngine.DefaultSoundEnabled = !mSoundEngine.DefaultSoundEnabled;
        }

        void ToggleMuteEnabled(object sender, EventArgs e)
        {
            mSoundEngine.MuteEnabled = !mSoundEngine.MuteEnabled;
        }

        void ToggleSettingsWindowVisible(object sender, EventArgs e)
        {
            Visible = !Visible;

            if (WindowState != FormWindowState.Normal) /* for first shown */
                WindowState = FormWindowState.Normal;
        }

        void Minimize(object sender, EventArgs e)
        {
            Close();
        }

        void ForceExit(object sender, EventArgs e)
        {
            mCanClose = true; Close();
        }

        void SoundPackList_Loaded(object sender, EventArgs e)
        {
            comboBoxSoundPacks.DataSource = mSoundPackList.Select(_ => _.Name).ToList();
        }

        void SoundPackList_SelectIndexChanged(object sender, EventArgs e)
        {
            if (mSoundEngine != null) mSoundEngine.Dispose();

            mSoundEngine = new SoundEndine(mSoundPackList.SelectedItem);
            mSoundEngine.KeyUp += new KeyEventHandler(SoundEngine_KeyUp);
            mSoundEngine.KeyDown += new KeyEventHandler(SoundEngine_KeyDown);
            mSoundEngine.MuteEnabledChanged += new EventHandler(SoundEngine_MuteEnabledChanged);
            mSoundEngine.DefaultSoundEnabledChanged += new EventHandler(SoundEngine_DefaultSoundEnabledChanged);
            /* mSoundEngine.LoadConfig() */

            Program.NotifyIcon.ShowBalloonTip(
                BALOON_TIMEOUT,
                Application.ProductName,
                string.Format("サウンドパック {0} をロードしました", mSoundEngine.Name),
                ToolTipIcon.Info
            );

            comboBoxSoundPacks.SelectedIndex = mSoundPackList.SelectedIndex;
            labelSoundPackName.Text = mSoundPackList.SelectedName;
        }

        private void SoundEngine_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void SoundEngine_KeyDown(object sender, KeyEventArgs e)
        {
            mKeysDisplayForm.DisplayKeys = e.KeyData;
        }

        private void SoundEngine_MuteEnabledChanged(object sender, EventArgs e)
        {
            checkBoxMute.Checked = mSoundEngine.MuteEnabled;
            menuItemIsMute.Checked = mSoundEngine.MuteEnabled;

            Program.NotifyIcon.ShowBalloonTip(
                BALOON_TIMEOUT,
                Application.ProductName,
                string.Format(
                    "ミュートを {0} にしました",
                    mSoundEngine.MuteEnabled ? "有効" : "無効"),
                ToolTipIcon.Info
            );
        }

        private void SoundEngine_DefaultSoundEnabledChanged(object sender, EventArgs e)
        {
            checkBoxEnableDefaultSound.Checked = mSoundEngine.DefaultSoundEnabled;
            menuItemDefaultSoundEnabled.Checked = mSoundEngine.DefaultSoundEnabled;

            Program.NotifyIcon.ShowBalloonTip(
                BALOON_TIMEOUT,
                Application.ProductName,
                string.Format(
                    "デフォルトサウンドの再生を {0} にしました",
                    mSoundEngine.DefaultSoundEnabled ? "有効" : "無効"),
                ToolTipIcon.Info
            );
        }

        private void menuItemChangeSoundPacks_DropDownOpening(object sender, EventArgs e)
        {
            menuItemChangeSoundPacks.DropDown.Items.Clear();

            foreach (var pack in mSoundPackList)
            {
                var item = new ToolStripMenuItem(pack.Name)
                {
                    Checked = pack.ActiveIn(mSoundPackList),
                };

                item.Click += (_1, _2) =>
                {
                    mSoundPackList.SelectedName = item.Text;
                };

                menuItemChangeSoundPacks.DropDown.Items.Add(item);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
