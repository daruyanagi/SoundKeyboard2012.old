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
            this.labelKeyData = new System.Windows.Forms.Label();
            this.comboBoxSoundPacks = new System.Windows.Forms.ComboBox();
            this.buttonReloadSoundPacks = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeSoundPacks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemIsMute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelKeyData
            // 
            this.labelKeyData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKeyData.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelKeyData.Location = new System.Drawing.Point(12, 103);
            this.labelKeyData.Name = "labelKeyData";
            this.labelKeyData.Size = new System.Drawing.Size(360, 48);
            this.labelKeyData.TabIndex = 0;
            this.labelKeyData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSoundPacks
            // 
            this.comboBoxSoundPacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSoundPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSoundPacks.FormattingEnabled = true;
            this.comboBoxSoundPacks.Location = new System.Drawing.Point(20, 212);
            this.comboBoxSoundPacks.Name = "comboBoxSoundPacks";
            this.comboBoxSoundPacks.Size = new System.Drawing.Size(271, 26);
            this.comboBoxSoundPacks.TabIndex = 1;
            // 
            // buttonReloadSoundPacks
            // 
            this.buttonReloadSoundPacks.Location = new System.Drawing.Point(297, 212);
            this.buttonReloadSoundPacks.Name = "buttonReloadSoundPacks";
            this.buttonReloadSoundPacks.Size = new System.Drawing.Size(75, 26);
            this.buttonReloadSoundPacks.TabIndex = 2;
            this.buttonReloadSoundPacks.Text = "更新";
            this.buttonReloadSoundPacks.UseVisualStyleBackColor = true;
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
            this.contextMenuStrip.Size = new System.Drawing.Size(233, 126);
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
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(232, 22);
            this.menuItemExit.Text = "終了(&X)";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.buttonReloadSoundPacks);
            this.Controls.Add(this.comboBoxSoundPacks);
            this.Controls.Add(this.labelKeyData);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "SoundKeyboard 2012";
            this.TopMost = true;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelKeyData;
        private System.Windows.Forms.ComboBox comboBoxSoundPacks;
        private System.Windows.Forms.Button buttonReloadSoundPacks;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeSoundPacks;
        private System.Windows.Forms.ToolStripMenuItem menuItemIsMute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

