using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    partial class formLogin:Form
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
            this.m_LoginBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_RemberMeCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_LoginBtn
            // 
            this.m_LoginBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_LoginBtn.Location = new System.Drawing.Point(30, 450);
            this.m_LoginBtn.Name = "m_LoginBtn";
            this.m_LoginBtn.Size = new System.Drawing.Size(400, 75);
            this.m_LoginBtn.TabIndex = 2;
            this.m_LoginBtn.Text = "Login";
            this.m_LoginBtn.UseVisualStyleBackColor = false;
            this.m_LoginBtn.Click += new System.EventHandler(this.m_LoginBtn_Click);
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
            // 
            // m_RemberMeCheckbox
            // 
            this.m_RemberMeCheckbox.AutoSize = true;
            this.m_RemberMeCheckbox.Location = new System.Drawing.Point(30, 532);
            this.m_RemberMeCheckbox.Name = "m_RemberMeCheckbox";
            this.m_RemberMeCheckbox.Size = new System.Drawing.Size(95, 17);
            this.m_RemberMeCheckbox.TabIndex = 6;
            this.m_RemberMeCheckbox.Text = "Remember Me";
            this.m_RemberMeCheckbox.UseVisualStyleBackColor = true;
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(456, 561);
            this.Controls.Add(this.m_RemberMeCheckbox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_LoginBtn);
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formLogin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_LoginBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CheckBox m_RemberMeCheckbox;
    }
}

