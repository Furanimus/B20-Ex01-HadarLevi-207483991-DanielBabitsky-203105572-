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
            
        }

        private void loginBtn_Click(object i_Sender, EventArgs i_Args)
        {
            bool loginSuccessfully = s_FacebookManager.Login();

            if (loginSuccessfully)
            { 
                this.OpenMainWindow();
            }
            else
            {
                MessageBox.Show($"There was an error login: {s_FacebookManager.LoginResult.ErrorMessage}");
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
    }
}
