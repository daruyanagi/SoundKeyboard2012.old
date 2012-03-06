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

        public string SoundPackName = string.Empty;

        public string SoundPackPath = string.Empty;

        public string[] SoundPackList = null;

        public Dictionary<string, SoundPlayer> Sounds = new Dictionary<string, SoundPlayer>();

        public void BuildSounds(string name)
        {
            SoundPackName = name;

            SoundPackPath = Path.Combine(Application.StartupPath, "Sounds", SoundPackName);

            Sounds = new DirectoryInfo(SoundPackPath)
                .EnumerateFiles()
                .Where(_ => _.Extension == ".wav")
                .Select(_ => new SoundPlayer(_.FullName))
                .ToDictionary(_ => Path.GetFileNameWithoutExtension(_.SoundLocation));
        }

        public void BuildSoundsList()
        {
            SoundPackList = new DirectoryInfo(Path.Combine(Application.StartupPath, "Sounds"))
                .GetDirectories()
                .Select(_ => _.Name)
                .ToArray();
        }

        public MainForm()
        {
            InitializeComponent();

            BuildSoundsList();
            BuildSounds("alpha");

            comboBox1.DataSource = SoundPackList;

            comboBox1.SelectedIndexChanged += (_1, _2) =>
            {
                BuildSounds(comboBox1.SelectedItem.ToString());
            };

            buttonReload.Click += (_1, _2) =>
            {
                BuildSoundsList();
            };

            Load += new EventHandler(MainForm_Load);
            FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            keyboard_listener = new KeyboardHookListener(new GlobalHooker())
            {
                Enabled = true,
            };

            keyboard_listener.KeyDown += (_sender, _e) =>
            {
                var key = _e.KeyData.ToString();

                labelKeyData.Text = key;

                if (Sounds.Keys.Contains(key)) Sounds[key].Play();
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
