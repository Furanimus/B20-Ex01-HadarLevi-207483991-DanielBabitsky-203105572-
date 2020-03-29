using System;
using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public partial class formLogin : Form
    {
        public static FacebookManager s_FacebookManager;

        public formLogin()
        {
            s_FacebookManager = new FacebookManager();
            InitializeComponent();

            if (s_FacebookManager.AppSettings.RememberUser)
            {
                m_RemberMeCheckbox.Checked = s_FacebookManager.AppSettings.RememberUser;
            }
        }


        public void OpenMainWindow()
        {
            Hide();
            formMain form = new formMain();
            form.Show();
        }

        private void FacebookForm_Load(object i_Sender, EventArgs i_Args)
        {
        }

        private void pictureBox1_Click(object i_Sender, EventArgs i_Args)
        {
        }

        private void m_LoginBtn_Click(object sender, EventArgs e)
        {
            bool loginSuccessfully = s_FacebookManager.Login(m_RemberMeCheckbox.Checked);

            if (loginSuccessfully)
            {
                this.OpenMainWindow();
            }
            else
            {
                MessageBox.Show($"There was an error login: {s_FacebookManager.LoginResult.ErrorMessage}");
            }
        }

        private void formLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}