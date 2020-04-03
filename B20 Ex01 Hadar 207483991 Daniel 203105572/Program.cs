using System;
using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    static class Program
    {
        public static FacebookManager FacebookManager = new FacebookManager(AppSettings.Instance);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitForm();
        }

        private static void InitForm()
        {
            Form startingForm;

            if (FacebookManager.AppSettingsInstance.RememberUser &&
                !string.IsNullOrEmpty(FacebookManager.AppSettingsInstance.LastAccessToken))
            {

                FacebookManager.Connect();
                startingForm = new formMain(FacebookManager);

            }
            else
            {
                startingForm = new formLogin(FacebookManager);
            }

            Application.Run(startingForm);
        }
    }
}
