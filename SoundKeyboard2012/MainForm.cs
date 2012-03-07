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

        private readonly string SoundPackPath;
        private string[] SoundPackList = null;

        private SoundEndine engine = null;

        public void BuildSounds(string name)
        {
            var path = Path.Combine(SoundPackPath, name);

            if (engine != null) engine.Dispose();

            engine = new SoundEndine(path);
        }

        public void BuildSoundsList()
        {
            SoundPackList = new DirectoryInfo(SoundPackPath)
                .GetDirectories()
                .Select(_ => _.Name)
                .ToArray();
        }

        public MainForm()
        {
            InitializeComponent();

            SoundPackPath = Path.Combine(Application.StartupPath, "Sounds");

            Load += new EventHandler(MainForm_Load);
            FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            BuildSoundsList();
            BuildSounds("alpha");

            comboBox1.DataSource = SoundPackList;

            comboBox1.SelectedIndexChanged += (_sebder, _e) =>
            {
                BuildSounds(comboBox1.SelectedItem.ToString());
            };

            buttonReload.Click += (_sebder, _e) =>
            {
                BuildSoundsList();
            };

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

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            keyboard_listener.Dispose();
        }
    }
}
