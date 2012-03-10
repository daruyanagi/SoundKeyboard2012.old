using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoundKeyboard2012
{
    public partial class KeysDisplayForm : Form
    {
        public KeysDisplayForm()
        {
            InitializeComponent();
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
