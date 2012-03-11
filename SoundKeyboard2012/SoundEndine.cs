using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Media;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace SoundKeyboard2012
{
    public class SoundEndine : IDisposable
    {
        private readonly Dictionary<string, SoundPlayer> mSounds;

        private GlobalHooker mGlobalHooker = new GlobalHooker();
        private KeyboardHookListener mKeyboardListener = null;
        private Timer mTimer = null;

        public List<Keys> SilentKeys = new List<Keys>();

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        private SoundEndine()
        {

        }

        public SoundEndine(SoundPack sound_pack)
        {
            Location = sound_pack.Location;

            mSounds = new System.IO.DirectoryInfo(Location)
                .EnumerateFiles()
                .Where(_ => _.Extension == ".wav")
                .Select(_ => new SoundPlayer(_.FullName))
                .ToDictionary(_ => Path.GetFileNameWithoutExtension(_.SoundLocation));

            mTimer = new Timer();

            mTimer.Tick += (_sender, _e) =>
            {
                if (mKeyboardListener == null ||
                    mKeyboardListener.Enabled == false)
                {
                    InitializaKeyboardListner();
                    System.Diagnostics.Debug.WriteLine(
                        "(Re)start keyboard listner: {0}", DateTime.Now);
                }
            };

            mTimer.Interval = 60 * 1000;
            mTimer.Start();
        }

        private void InitializaKeyboardListner()
        {
            mKeyboardListener = new KeyboardHookListener(mGlobalHooker)
            {
                Enabled = true,
            };

            mKeyboardListener.KeyDown += (_sender, _e) =>
            {
                if (KeyDown != null) KeyDown(_sender, _e);

                Play(_e.KeyData);

                /* [Control] + [Alt] + [M] -> Mute ON/OFF */
                if (_e.KeyData == Keys.M &&
                    Keys.Shift == (Control.ModifierKeys & Keys.Shift) &&
                    Keys.Control == (Control.ModifierKeys & Keys.Control))
                    MuteEnabled = !MuteEnabled;
            };

            mKeyboardListener.KeyUp += (_sender, _e) =>
            {
                /* Re-Allow sound in Key up */
                if (IsModifierKey(_e.KeyData))
                    SilentKeys.Remove(_e.KeyData);

                if (KeyUp != null) KeyUp(_sender, _e);
            };
        }

        #region property Name
        public string Name
        {
            get
            {
                return Path.GetFileNameWithoutExtension(Location);
            }
        }
        #endregion

        #region property DefaultSoundEnabled
        public bool DefaultSoundEnabled
        {
            get { return mDefaultSoundEnabled; }
            set
            {
                if (mDefaultSoundEnabled != value)
                {
                    mDefaultSoundEnabled = value;

                    if (DefaultSoundEnabledChanged != null)
                        DefaultSoundEnabledChanged(this, EventArgs.Empty);
                }
            }
        }
        private bool mDefaultSoundEnabled;
        public event EventHandler DefaultSoundEnabledChanged;
        #endregion

        #region property MuteEnabled
        public bool MuteEnabled
        {
            get { return mMuteEnabled; }
            set
            {
                if (mMuteEnabled != value)
                {
                    mMuteEnabled = value;

                    if (MuteEnabledChanged != null)
                        MuteEnabledChanged(this, EventArgs.Empty);
                }
            }
        }
        private bool mMuteEnabled;
        public event EventHandler MuteEnabledChanged;
        #endregion

        public string Location { get; private set; }

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
            if (MuteEnabled) return;

            var k = keys.ToString();

            if (mSounds.Keys.Contains(k))
            {
                if (!SilentKeys.Contains(keys))
                {
                    mSounds[k].Play();

                    if (IsModifierKey(keys)) SilentKeys.Add(keys);
                }
            }
            else
            {
                if (DefaultSoundEnabled)
                    mSounds["default"].Play();
            }
        }

        public void Dispose()
        {
            foreach (var sound in mSounds.Values)
            {
                sound.Dispose();
            }

            if (mKeyboardListener != null)
                mKeyboardListener.Dispose();
        }
    }
}
