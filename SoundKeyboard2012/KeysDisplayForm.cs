using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Security.Permissions;

namespace SoundKeyboard2012
{
    public partial class KeysDisplayForm : Form
    {
        public KeysDisplayForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_ENDSESSION = 0x16;

            switch (message.Msg)
            {
                case WM_ENDSESSION:
                    Close();
                    break;
            }

            base.WndProc(ref message);
        }

        #region property DisplayKeys

        public Keys DisplayKeys
        {
            get
            {
                return mKeys;
            }
            set
            {
                if (mKeys != value)
                {
                    mKeys = value;
                    labelKeys.Text = mKeys.ToString();
                }
            }
        }
        private Keys mKeys;

        #endregion
    }
}
