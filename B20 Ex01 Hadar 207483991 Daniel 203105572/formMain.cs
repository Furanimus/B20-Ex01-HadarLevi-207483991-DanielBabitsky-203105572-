using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{


    public partial class formMain : Form
    {
        private const int k_PictureBoxSize = 64;

        private FacebookManager r_FacebookManager;

        public User LoggedInUser
        {
            get
            {
                return r_FacebookManager.LoggedInUser;
            }
        }

        public formMain()
        {
            r_FacebookManager = formLogin.s_FacebookManager;

            InitializeComponent();

            SetDataInForm();
        }

        private void SetDataInForm()
        {
            lblName.Text = LoggedInUser.FirstName;

            pictureBoxProfilePicture.Load(LoggedInUser.PictureNormalURL);
        }

        private Image LoadImage(string i_Url)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(i_Url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();

            Bitmap bitmap = new Bitmap(responseStream);

            responseStream.Dispose();

            return bitmap;
        }

        private void formMain_Load(object i_Sender, EventArgs i_Args)
        {
            //FacebookObjectCollection<User> userFriends = r_FacebookManager.FetchFriends();
            //int i = 0;

            //foreach (User friend in userFriends)
            //{
            //    //listBoxFriends.Items.Add(friend.Name);
            //    CreateUserFriend(i, friend.Name, friend.PictureNormalURL);
            //    i++;
            //}
        }

        private void CreateUserFriend(Control panel, int i_Index, string i_Name, string i_Url)
        {
            var label = new Label() { Text = i_Name };
            label.Top = k_PictureBoxSize * i_Index + i_Index * 10 + 30;
            label.Left = 74;
            label.Width = 180;
            label.Font = new Font("Arial", 12);
            panel.Controls.Add(label);

            Bitmap bitmap = new Bitmap(LoadImage(i_Url), new Size(k_PictureBoxSize, k_PictureBoxSize));
            PictureBox pictureBox = new PictureBox() { Image = bitmap };
            pictureBox.Top = k_PictureBoxSize * i_Index + i_Index * 10;
            pictureBox.Left = 0;
            pictureBox.Width = k_PictureBoxSize;
            pictureBox.Height = k_PictureBoxSize;

            panel.Controls.Add(pictureBox);
        }

        private void lblHello_Click(object i_Sender, EventArgs i_Args)
        {
        }

        private void lblName_Click(object i_Sender, EventArgs i_Args)
        {
        }

        private void menuStrip1_ItemClicked(object i_Sender, ToolStripItemClickedEventArgs i_Args)
        {
        }

        private void testToolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
        {
        }

        private void toolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
        {
        }

        private void webBrowserFacebook_DocumentCompleted(object i_Sender, WebBrowserDocumentCompletedEventArgs i_Args)
        {
        }

        private void buttonFetchFriends_Click(object i_Sender, EventArgs i_Args)
        {
            //listBoxFriends.Items.Clear();
            //formMain_Load();
            //displayFriends();
        }

        private void buttonOpenFBBrowser_Click(object i_Sender, EventArgs i_Args)
        {
            FormFBBrowser fBBrowser = new FormFBBrowser();
            fBBrowser.Show();
        }

        private void buttonFetchCheckins_Click(object i_Sender, EventArgs i_Args)
        {

            displayCheckins();
        }

        private void displayFriends()
        {
            FacebookObjectCollection<User> userFriends = r_FacebookManager.FetchFriends();
            panelFriends.Controls.Clear();
            int i = 0;

            foreach (User friend in userFriends)
            {
                CreateUserFriend(panelFriends, i, friend.Name, friend.PictureNormalURL);
                i++;
            }
        }

        private void displayCheckins()
        {
            FacebookObjectCollection<Checkin> userCheckins = r_FacebookManager.FetchCheckins();
            int i = 0;
            panelChekins.Controls.Clear();

            foreach (Checkin friend in userCheckins)
            {
                CreateUserFriend(panelChekins, i, friend.Name, friend.PictureURL);
                i++;
            }
        }

        private void displayGroups()
        {
            listBoxGroups.Items.Clear();
            FacebookObjectCollection<Group> userGroups = r_FacebookManager.FetchGroups();

            foreach (Group group in userGroups)
            {
                listBoxGroups.Items.Add(group.Name);
            }
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonFetchGroups_Click(object sender, EventArgs e)
        {
            displayGroups();
        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r_FacebookManager.Logout();

        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstFriends_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void buttonFindFriend_Click(object i_Sender, EventArgs i_Args)
        {
            panelFriends.Controls.Clear();
            FacebookObjectCollection<User> userFriends = r_FacebookManager.FetchFriends();

            foreach (User friend in userFriends)
            {
                if (friend.Name.ToLower().Contains(textBoxFriendSearch.Text.ToLower()))
                {
                    CreateUserFriend(panelFriends, 0, friend.Name, friend.PictureNormalURL);
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonFetchFriends_Click_1(object sender, EventArgs e)
        {
            displayFriends();
        }

        private void listBoxCheckins_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {
            //FacebookObjectCollection<Checkin> userCheckins = r_FacebookManager.FetchCheckins();
            //int i = 0;

            //foreach (Checkin checkin in userCheckins)
            //{
            //    CreateUserFriend(panelChekins,i, checkin.Name, checkin.PictureURL);
            //    i++;
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblHello_Click_1(object sender, EventArgs e)
        {

        }
    }
}
