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

        public static SoundEndine FromSoundPack(SoundPack pack)
        {
            return new SoundEndine(pack.Location);
        }

        public string Name
        {
            get
            {
                return Path.GetFileNameWithoutExtension(Location);
            }
        }

        public string Location { get; private set; }

        public List<Keys> ObsoluteKeys = new List<Keys>();

        public static bool IsModifierKey(Keys key)
        {
            return (key & Keys.LShiftKey) == Keys.LShiftKey
                || (key & Keys.RShiftKey) == Keys.RShiftKey
                || (key & Keys.RControlKey) == Keys.RControlKey
                || (key & Keys.LControlKey) == Keys.LControlKey
                || (key & Keys.RMenu) == Keys.RShiftKey
                || (key & Keys.LMenu) == Keys.LShiftKey
                || (key & Keys.RWin) == Keys.RWin
                || (key & Keys.LWin) == Keys.LWin
                || (key & Keys.Space) == Keys.Space
                || (key & Keys.Enter) == Keys.Enter
                || (key & Keys.Return) == Keys.Return
                || (key & Keys.Back) == Keys.Back
                || (key & Keys.Delete) == Keys.Delete;
        }

        public void Play(Keys keys)
        {
            var k = keys.ToString();

            if (Sounds.Keys.Contains(k) && !ObsoluteKeys.Contains(keys))
            {
                Sounds[k].Play();

                if (IsModifierKey(keys)) ObsoluteKeys.Add(keys);
            }
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
