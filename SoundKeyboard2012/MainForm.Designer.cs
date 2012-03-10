namespace SoundKeyboard2012
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeSoundPacks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemIsMute = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDefaultSoundEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisplayKeyEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDeleteSoundPack = new System.Windows.Forms.Button();
            this.labelSoundPackName = new System.Windows.Forms.Label();
            this.buttonAddSoundPack = new System.Windows.Forms.Button();
            this.buttonReloadSoundPacks = new System.Windows.Forms.Button();
            this.comboBoxSoundPacks = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxEnableDefaultSound = new System.Windows.Forms.CheckBox();
            this.checkBoxShowKeyInput = new System.Windows.Forms.CheckBox();
            this.checkBoxMute = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSettings,
            this.menuItemChangeSoundPacks,
            this.toolStripSeparator1,
            this.menuItemIsMute,
            this.menuItemDefaultSoundEnabled,
            this.menuItemDisplayKeyEnabled,
            this.toolStripSeparator2,
            this.menuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(233, 148);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(232, 22);
            this.menuItemSettings.Text = "設定画面を表示(&S)";
            this.menuItemSettings.Click += new System.EventHandler(this.ToggleSettingsWindowVisible);
            // 
            // menuItemChangeSoundPacks
            // 
            this.menuItemChangeSoundPacks.Name = "menuItemChangeSoundPacks";
            this.menuItemChangeSoundPacks.Size = new System.Drawing.Size(232, 22);
            this.menuItemChangeSoundPacks.Text = "サウンドエンジンの切り替え";
            this.menuItemChangeSoundPacks.DropDownOpening += new System.EventHandler(this.menuItemChangeSoundPacks_DropDownOpening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // menuItemIsMute
            // 
            this.menuItemIsMute.Name = "menuItemIsMute";
            this.menuItemIsMute.Size = new System.Drawing.Size(232, 22);
            this.menuItemIsMute.Text = "ミュート(&M)";
            this.menuItemIsMute.Click += new System.EventHandler(this.ToggleMuteEnabled);
            // 
            // menuItemDefaultSoundEnabled
            // 
            this.menuItemDefaultSoundEnabled.Name = "menuItemDefaultSoundEnabled";
            this.menuItemDefaultSoundEnabled.Size = new System.Drawing.Size(232, 22);
            this.menuItemDefaultSoundEnabled.Text = "デフォルトサウンドの再生";
            this.menuItemDefaultSoundEnabled.Click += new System.EventHandler(this.ToggleDefaultSoundEnabled);
            // 
            // menuItemDisplayKeyEnabled
            // 
            this.menuItemDisplayKeyEnabled.Name = "menuItemDisplayKeyEnabled";
            this.menuItemDisplayKeyEnabled.Size = new System.Drawing.Size(232, 22);
            this.menuItemDisplayKeyEnabled.Text = "キー入力の表示";
            this.menuItemDisplayKeyEnabled.Click += new System.EventHandler(this.ToggleKeyDisplayEnabled);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(232, 22);
            this.menuItemExit.Text = "終了(&X)";
            this.menuItemExit.Click += new System.EventHandler(this.ForceExit);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 375);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDeleteSoundPack);
            this.tabPage1.Controls.Add(this.labelSoundPackName);
            this.tabPage1.Controls.Add(this.buttonAddSoundPack);
            this.tabPage1.Controls.Add(this.buttonReloadSoundPacks);
            this.tabPage1.Controls.Add(this.comboBoxSoundPacks);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "サウンドパック";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteSoundPack
            // 
            this.buttonDeleteSoundPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteSoundPack.Location = new System.Drawing.Point(372, 43);
            this.buttonDeleteSoundPack.Name = "buttonDeleteSoundPack";
            this.buttonDeleteSoundPack.Size = new System.Drawing.Size(124, 31);
            this.buttonDeleteSoundPack.TabIndex = 6;
            this.buttonDeleteSoundPack.Text = "削除(&D)";
            this.buttonDeleteSoundPack.UseVisualStyleBackColor = true;
            this.buttonDeleteSoundPack.Click += new System.EventHandler(this.buttonDeleteSoundPack_Click);
            // 
            // labelSoundPackName
            // 
            this.labelSoundPackName.AutoSize = true;
            this.labelSoundPackName.Location = new System.Drawing.Point(6, 12);
            this.labelSoundPackName.Name = "labelSoundPackName";
            this.labelSoundPackName.Size = new System.Drawing.Size(133, 18);
            this.labelSoundPackName.TabIndex = 5;
            this.labelSoundPackName.Text = "labelSoundPackName";
            // 
            // buttonAddSoundPack
            // 
            this.buttonAddSoundPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddSoundPack.Location = new System.Drawing.Point(372, 6);
            this.buttonAddSoundPack.Name = "buttonAddSoundPack";
            this.buttonAddSoundPack.Size = new System.Drawing.Size(124, 31);
            this.buttonAddSoundPack.TabIndex = 4;
            this.buttonAddSoundPack.Text = "追加(&A)";
            this.buttonAddSoundPack.UseVisualStyleBackColor = true;
            this.buttonAddSoundPack.Click += new System.EventHandler(this.buttonAddSoundPack_Click);
            // 
            // buttonReloadSoundPacks
            // 
            this.buttonReloadSoundPacks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReloadSoundPacks.Location = new System.Drawing.Point(372, 307);
            this.buttonReloadSoundPacks.Name = "buttonReloadSoundPacks";
            this.buttonReloadSoundPacks.Size = new System.Drawing.Size(124, 31);
            this.buttonReloadSoundPacks.TabIndex = 3;
            this.buttonReloadSoundPacks.Text = "設定のリロード";
            this.buttonReloadSoundPacks.UseVisualStyleBackColor = true;
            // 
            // comboBoxSoundPacks
            // 
            this.comboBoxSoundPacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSoundPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxSoundPacks.FormattingEnabled = true;
            this.comboBoxSoundPacks.Location = new System.Drawing.Point(3, 46);
            this.comboBoxSoundPacks.Name = "comboBoxSoundPacks";
            this.comboBoxSoundPacks.Size = new System.Drawing.Size(363, 280);
            this.comboBoxSoundPacks.TabIndex = 2;
            this.comboBoxSoundPacks.SelectedIndexChanged += new System.EventHandler(this.SoundPackList_SelectIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxEnableDefaultSound);
            this.tabPage2.Controls.Add(this.checkBoxShowKeyInput);
            this.tabPage2.Controls.Add(this.checkBoxMute);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(502, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "その他の設定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableDefaultSound
            // 
            this.checkBoxEnableDefaultSound.AutoSize = true;
            this.checkBoxEnableDefaultSound.Location = new System.Drawing.Point(23, 100);
            this.checkBoxEnableDefaultSound.Name = "checkBoxEnableDefaultSound";
            this.checkBoxEnableDefaultSound.Size = new System.Drawing.Size(329, 16);
            this.checkBoxEnableDefaultSound.TabIndex = 3;
            this.checkBoxEnableDefaultSound.Text = "キーにサウンドが設定されていない場合、Default.wav を再生する";
            this.checkBoxEnableDefaultSound.UseVisualStyleBackColor = true;
            this.checkBoxEnableDefaultSound.Click += new System.EventHandler(this.ToggleDefaultSoundEnabled);
            // 
            // checkBoxShowKeyInput
            // 
            this.checkBoxShowKeyInput.AutoSize = true;
            this.checkBoxShowKeyInput.Location = new System.Drawing.Point(23, 61);
            this.checkBoxShowKeyInput.Name = "checkBoxShowKeyInput";
            this.checkBoxShowKeyInput.Size = new System.Drawing.Size(120, 16);
            this.checkBoxShowKeyInput.TabIndex = 1;
            this.checkBoxShowKeyInput.Text = "入力キーを表示する";
            this.checkBoxShowKeyInput.UseVisualStyleBackColor = true;
            this.checkBoxShowKeyInput.Click += new System.EventHandler(this.ToggleKeyDisplayEnabled);
            // 
            // checkBoxMute
            // 
            this.checkBoxMute.AutoSize = true;
            this.checkBoxMute.Location = new System.Drawing.Point(23, 20);
            this.checkBoxMute.Name = "checkBoxMute";
            this.checkBoxMute.Size = new System.Drawing.Size(57, 16);
            this.checkBoxMute.TabIndex = 0;
            this.checkBoxMute.Text = "ミュート";
            this.checkBoxMute.UseVisualStyleBackColor = true;
            this.checkBoxMute.Click += new System.EventHandler(this.ToggleMuteEnabled);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.labelVersion);
            this.tabPage3.Controls.Add(this.labelCopyright);
            this.tabPage3.Controls.Add(this.labelProductName);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(502, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SoundKeyboard 2012 について";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(170, 75);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 18);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "label2";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(170, 108);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(42, 18);
            this.labelCopyright.TabIndex = 1;
            this.labelCopyright.Text = "label2";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelProductName.Location = new System.Drawing.Point(170, 24);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(85, 36);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "label2";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(348, 403);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(180, 36);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "アプリケーションを終了(&X)";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ForceExit);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.Location = new System.Drawing.Point(166, 403);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(176, 36);
            this.buttonMinimize.TabIndex = 5;
            this.buttonMinimize.Text = "タスクトレイへ最小化(&M)";
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.Minimize);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(170, 141);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(140, 18);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://daruyanagi.net/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(24, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(534, 452);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "SoundKeyboard 2012";
            this.TopMost = true;
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeSoundPacks;
        private System.Windows.Forms.ToolStripMenuItem menuItemIsMute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonReloadSoundPacks;
        private System.Windows.Forms.ComboBox comboBoxSoundPacks;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonAddSoundPack;
        private System.Windows.Forms.CheckBox checkBoxShowKeyInput;
        private System.Windows.Forms.CheckBox checkBoxMute;
        private System.Windows.Forms.Button buttonDeleteSoundPack;
        private System.Windows.Forms.Label labelSoundPackName;
        private System.Windows.Forms.CheckBox checkBoxEnableDefaultSound;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.ToolStripMenuItem menuItemDefaultSoundEnabled;
        private System.Windows.Forms.ToolStripMenuItem menuItemDisplayKeyEnabled;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

