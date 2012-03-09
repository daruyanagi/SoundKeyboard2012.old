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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeSoundPacks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemIsMute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxSoundPacks = new System.Windows.Forms.ComboBox();
            this.buttonReloadSoundPacks = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonAddSoundPack = new System.Windows.Forms.Button();
            this.checkBoxMute = new System.Windows.Forms.CheckBox();
            this.checkBoxShowKeyInput = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableDefaultSound = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeleteSoundPack = new System.Windows.Forms.Button();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSettings,
            this.menuItemChangeSoundPacks,
            this.toolStripSeparator1,
            this.menuItemIsMute,
            this.toolStripSeparator2,
            this.menuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(233, 104);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(232, 22);
            this.menuItemSettings.Text = "設定画面を表示(&S)";
            // 
            // menuItemChangeSoundPacks
            // 
            this.menuItemChangeSoundPacks.Name = "menuItemChangeSoundPacks";
            this.menuItemChangeSoundPacks.Size = new System.Drawing.Size(232, 22);
            this.menuItemChangeSoundPacks.Text = "サウンドエンジンの切り替え";
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
            this.tabPage1.Controls.Add(this.label1);
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
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(348, 403);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(180, 36);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "アプリケーションを終了(&X)";
            this.buttonExit.UseVisualStyleBackColor = true;
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
            // 
            // checkBoxMute
            // 
            this.checkBoxMute.AutoSize = true;
            this.checkBoxMute.Location = new System.Drawing.Point(23, 20);
            this.checkBoxMute.Name = "checkBoxMute";
            this.checkBoxMute.Size = new System.Drawing.Size(75, 22);
            this.checkBoxMute.TabIndex = 0;
            this.checkBoxMute.Text = "ミュート";
            this.checkBoxMute.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowKeyInput
            // 
            this.checkBoxShowKeyInput.AutoSize = true;
            this.checkBoxShowKeyInput.Location = new System.Drawing.Point(23, 61);
            this.checkBoxShowKeyInput.Name = "checkBoxShowKeyInput";
            this.checkBoxShowKeyInput.Size = new System.Drawing.Size(135, 22);
            this.checkBoxShowKeyInput.TabIndex = 1;
            this.checkBoxShowKeyInput.Text = "入力キーを表示する";
            this.checkBoxShowKeyInput.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableDefaultSound
            // 
            this.checkBoxEnableDefaultSound.AutoSize = true;
            this.checkBoxEnableDefaultSound.Location = new System.Drawing.Point(23, 100);
            this.checkBoxEnableDefaultSound.Name = "checkBoxEnableDefaultSound";
            this.checkBoxEnableDefaultSound.Size = new System.Drawing.Size(389, 22);
            this.checkBoxEnableDefaultSound.TabIndex = 3;
            this.checkBoxEnableDefaultSound.Text = "キーにサウンドが設定されていない場合、Default.wav を再生する";
            this.checkBoxEnableDefaultSound.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "labelSoundPackName";
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
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(39, 34);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(42, 18);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "label2";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(39, 76);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(42, 18);
            this.labelCopyright.TabIndex = 1;
            this.labelCopyright.Text = "label2";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(39, 118);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 18);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "label2";
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
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxEnableDefaultSound;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelProductName;
    }
}

