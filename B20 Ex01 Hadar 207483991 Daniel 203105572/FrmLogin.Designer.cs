namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    partial class frmLogin
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
            this.m_LoginLogoutBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_LoginLogoutBtn
            // 
            this.m_LoginLogoutBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_LoginLogoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_LoginLogoutBtn.Location = new System.Drawing.Point(30, 474);
            this.m_LoginLogoutBtn.Name = "m_LoginLogoutBtn";
            this.m_LoginLogoutBtn.Size = new System.Drawing.Size(400, 75);
            this.m_LoginLogoutBtn.TabIndex = 2;
            this.m_LoginLogoutBtn.Text = "Login";
            this.m_LoginLogoutBtn.UseVisualStyleBackColor = false;
            this.m_LoginLogoutBtn.Click += new System.EventHandler(this.loginLogoutBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::B20_Ex01_Hadar_207483991_Daniel_203105572.Properties.Resources.facebook_icon;
            this.pictureBox1.Location = new System.Drawing.Point(30, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(456, 561);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_LoginLogoutBtn);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FacebookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_LoginLogoutBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

