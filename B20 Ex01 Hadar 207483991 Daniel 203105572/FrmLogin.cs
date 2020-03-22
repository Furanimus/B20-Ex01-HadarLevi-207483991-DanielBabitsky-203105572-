using System;
using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public partial class frmLogin : Form
    {
        public static FacebookManager m_FacebookManager;

        public frmLogin()
        {
            m_FacebookManager = new FacebookManager();
            InitializeComponent();
        }

        private void loginLogoutBtn_Click(object sender, EventArgs e)
        {
            var loginSuccessfully = m_FacebookManager.Login();

            if (loginSuccessfully)
            { 
                this.OpenMainWindow();
            }
            else
            {
                MessageBox.Show($"There was an error login: {m_FacebookManager.LoginResult.ErrorMessage}");
            }
        }

        public void OpenMainWindow()
        {
            Hide();

            frmMain form = new frmMain();
            form.Show();

        }

        private void FacebookForm_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
