using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
     public partial class FormFBBrowser : Form
     {
          public FormFBBrowser()
          {
               InitializeComponent();

          }

          private void FormFBBrowser_Load(object i_Sender, EventArgs i_Args)
          {
               webBrowserFacebook.Navigate("https://www.facebook.com");
          }

        private void webBrowserFacebook_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
