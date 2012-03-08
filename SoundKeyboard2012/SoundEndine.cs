using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Media;
using System.Windows.Forms;

namespace SoundKeyboard2012
{
    public class SoundEndine : IDisposable
    {
        private readonly Dictionary<string, SoundPlayer> Sounds;

        private SoundEndine()
        {

        }

        public SoundEndine(string path)
        {
            Location = path;

            Sounds = new System.IO.DirectoryInfo(Location)
                .EnumerateFiles()
                .Where(_ => _.Extension == ".wav")
                .Select(_ => new SoundPlayer(_.FullName))
                .ToDictionary(_ => Path.GetFileNameWithoutExtension(_.SoundLocation));
        }

        public string Name
        {
            get
            {
                return Path.GetFileNameWithoutExtension(Location);
            }
        }

        public string Location { get; private set; }

        public void Play(Keys keys)
        {
            var k = keys.ToString();

            if (Sounds.Keys.Contains(k)) Sounds[k].Play();
        }

        public void Dispose()
        {
            foreach (var sound in Sounds.Values)
            {
                sound.Dispose();
            }
        }
    }
}
