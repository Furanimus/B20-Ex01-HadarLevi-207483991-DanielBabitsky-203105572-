namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
     partial class FormFBBrowser
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
            this.webBrowserFacebook = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserFacebook
            // 
            this.webBrowserFacebook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserFacebook.Location = new System.Drawing.Point(0, 0);
            this.webBrowserFacebook.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserFacebook.Name = "webBrowserFacebook";
            this.webBrowserFacebook.Size = new System.Drawing.Size(800, 450);
            this.webBrowserFacebook.TabIndex = 0;
            this.webBrowserFacebook.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserFacebook_DocumentCompleted);
            // 
            // FormFBBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webBrowserFacebook);
            this.Name = "FormFBBrowser";
            this.Text = "FormFBBrowser";
            this.Load += new System.EventHandler(this.FormFBBrowser_Load);
            this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.WebBrowser webBrowserFacebook;
     }
}