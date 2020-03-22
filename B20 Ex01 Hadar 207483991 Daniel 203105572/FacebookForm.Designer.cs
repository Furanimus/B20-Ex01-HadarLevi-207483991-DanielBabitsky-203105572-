namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    partial class FacebookForm
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
            this.SuspendLayout();
            // 
            // m_LoginLogoutBtn
            // 
            this.m_LoginLogoutBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_LoginLogoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_LoginLogoutBtn.Location = new System.Drawing.Point(161, 85);
            this.m_LoginLogoutBtn.Name = "m_LoginLogoutBtn";
            this.m_LoginLogoutBtn.Size = new System.Drawing.Size(203, 45);
            this.m_LoginLogoutBtn.TabIndex = 2;
            this.m_LoginLogoutBtn.Text = "Login";
            this.m_LoginLogoutBtn.UseVisualStyleBackColor = false;
            this.m_LoginLogoutBtn.Click += new System.EventHandler(this.m_LoginLogoutBtn_Click);
            // 
            // FacebookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_LoginLogoutBtn);
            this.Name = "FacebookForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_LoginLogoutBtn;
    }
}

