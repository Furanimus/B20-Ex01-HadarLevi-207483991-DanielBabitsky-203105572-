using FacebookWrapper.ObjectModel;
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
    public partial class frmMain : Form
    {
        private readonly FacebookManager m_FacebookManager;


        public User LoggedInUser
        {
            get
            {
                return this.m_FacebookManager.LoggedInUser;
            }
        }

        public frmMain()
        {
            m_FacebookManager = frmLogin.m_FacebookManager;

            InitializeComponent();

            SetDataInForm();
        }

        private void SetDataInForm()
        {
            lblName.Text = this.LoggedInUser.FirstName;


        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void lblHello_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
