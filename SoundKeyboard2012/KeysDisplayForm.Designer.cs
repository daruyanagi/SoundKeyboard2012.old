namespace SoundKeyboard2012
{
    partial class KeysDisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelKeys = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelKeys
            // 
            this.labelKeys.AutoSize = true;
            this.labelKeys.Font = new System.Drawing.Font("メイリオ", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelKeys.Location = new System.Drawing.Point(0, 0);
            this.labelKeys.Margin = new System.Windows.Forms.Padding(0);
            this.labelKeys.Name = "labelKeys";
            this.labelKeys.Size = new System.Drawing.Size(0, 72);
            this.labelKeys.TabIndex = 0;
            // 
            // KeysDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(197, 36);
            this.Controls.Add(this.labelKeys);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(25, 25);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KeysDisplayForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "KeysDisplayForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.LightGray;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKeys;
    }
}