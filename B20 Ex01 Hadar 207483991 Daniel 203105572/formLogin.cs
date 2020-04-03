using System;
using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public partial class formLogin : Form
    {
        public FacebookManager m_facebookManager;

        public formLogin(FacebookManager i_facebookManager)
        {
            m_facebookManager = i_facebookManager;

            if (m_facebookManager.AppSettingsInstance.RememberUser && !string.IsNullOrEmpty(m_facebookManager.AppSettingsInstance.LastAccessToken))
            {
                OpenMainWindow();
            }
            
            InitializeComponent();
        }

        public void OpenMainWindow()
        {
            
            formMain form = new formMain(m_facebookManager);
            form.Show();

            Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            bool loginSuccessfully = m_facebookManager.Login(m_RemberMeCheckbox.Checked);

            if (loginSuccessfully)
            {
                this.OpenMainWindow();
            }
            else
            {
                MessageBox.Show($"There was an error login: {m_facebookManager.LoginResult.ErrorMessage}");
            }
        }

        private void formLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}