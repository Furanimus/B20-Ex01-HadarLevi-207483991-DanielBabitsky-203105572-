using FacebookWrapper.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            if (string.IsNullOrEmpty(i_Url))
            {
                return null;
            }
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

        private void fillPanelTextAndPicture(Control panel, int i_Index, string i_Name, string i_Url)
        {

            var label = new Label() { Text = i_Name };
            label.Top = k_PictureBoxSize * i_Index + i_Index * 10 + 30;
            label.Left = 74;
            label.Width = 180;
            label.Font = new Font("Arial", 12);
            panel.Controls.Add(label);

            Image image = LoadImage(i_Url);
            if (image != null)
            {
                Bitmap bitmap = new Bitmap(image, new Size(k_PictureBoxSize, k_PictureBoxSize));
                PictureBox pictureBox = new PictureBox() { Image = bitmap };
                pictureBox.Top = k_PictureBoxSize * i_Index + i_Index * 10;
                pictureBox.Left = 0;
                pictureBox.Width = k_PictureBoxSize;
                pictureBox.Height = k_PictureBoxSize;

                panel.Controls.Add(pictureBox);
            }

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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                this.fetchUserInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fetchUserInfo()
        {
            try
            {
                displayCheckins();
                displayFriends();
                displayPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void buttonFetchCheckins_Click(object i_Sender, EventArgs i_Args)
        {

            displayCheckins();
        }

        private void displayFriends(string searchText = null)
        {
            panelFriends.Controls.Clear();

            List<User> userFriends = r_FacebookManager.FetchFriends().ToList();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                userFriends = userFriends.Where(friend => friend.Name.ToLower().Contains(searchText.ToLower())).ToList();
            }

            int i = 0;
            foreach (User friend in userFriends)
            {
                fillPanelTextAndPicture(panelFriends, i, friend.Name, friend.PictureNormalURL);
                i++;
            }
        }

        private void displayCheckins(string searchText = null)
        {
            panelChekins.Controls.Clear();

            List<Checkin> userCheckins = r_FacebookManager.FetchCheckins().ToList();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                userCheckins = userCheckins
                    .Where(checkins => !string.IsNullOrWhiteSpace(checkins.Place.Location.City + checkins.Place.Location.Country))
                    .Where(checkins => checkins.Place.Location.City.ToLower().Contains(searchText.ToLower()) ||
                    checkins.Place.Location.Country.ToLower().Contains(searchText.ToLower())).ToList();
            }

            int i = 0;
            foreach (Checkin checkins in userCheckins)
            {
                Location location = checkins.Place.Location;
                fillPanelTextAndPicture(panelChekins, i, $"{location.City}, {location.Country}", checkins.PictureURL);
                i++;
            }
        }

        private void displayPosts(string searchText = null)
        {
            panelPosts.Controls.Clear();
            List<Post> userPosts = r_FacebookManager.FetchPosts().ToList();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                userPosts = userPosts
                    .Where(post => !string.IsNullOrWhiteSpace(post.Message))
                    .Where(post => post.Message.ToLower().Contains(searchText.ToLower()))
                    .ToList();
            }

            int i = 0;
            foreach (Post post in userPosts)
            {
                fillPanelTextAndPicture(panelPosts, i, post.Message, post.PictureURL);
                i++;
            }
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonFetchPosts_Click(object sender, EventArgs e)
        {
            displayPosts();
        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r_FacebookManager.Logout();
            OpenLoginWindow();
        }
        public void OpenLoginWindow()
        {
            Hide();
            formLogin form = new formLogin();
            form.Show();
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lstFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonFindFriend_Click(object i_Sender, EventArgs i_Args)
        {
            displayFriends(textBoxFriendSearch.Text);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (r_FacebookManager.LoginResult != null)
            {
                if (!string.IsNullOrEmpty(r_FacebookManager.LoginResult.AccessToken))
                {
                    r_FacebookManager.AppSettings.AccessToken = r_FacebookManager.LoginResult.AccessToken;
                }
            }

            r_FacebookManager.AppSettings.SaveToFile();
        }

        private void buttonFindCheckin_Click(object sender, EventArgs e)
        {
            displayCheckins(textBoxCheckinsSearch.Text);
        }

        private void buttonFindPosts_Click(object sender, EventArgs e)
        {
            displayPosts(textBoxPostsSearch.Text);

        }

        private void textBoxFriendSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void m_PostBtn_Click(object sender, EventArgs e)
        {
            FormTextFill newPost = new FormTextFill();
            newPost.StartPosition = FormStartPosition.CenterParent;
            newPost.ShowDialog();
            
            if (!string.IsNullOrEmpty(newPost.UserInput) && !newPost.IsCanceled)
            {
                try
                {
                    r_FacebookManager.PostStatus(newPost.UserInput);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nothing happened");
            }
        }

        private void m_BestPhotoBtn_Click(object i_Sender, EventArgs i_Args)
        {
            try
            {
                int bestHour = r_FacebookManager.BestTimeToGetMostLikes();
                lblBestTimeToGetLikes.Text = $"The best time of day to get the most likes is: {bestHour}!";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGetMostActiveFriends_Click(object i_Sender, EventArgs i_Args)
        {
            //Call Activating Method

            List<List<PostedItem>> userPosts = new List<List<PostedItem>>();
            userPosts.Add(r_FacebookManager.FetchAlbums().ToList()) as PostedItem);
            userPosts.Add(r_FacebookManager.FetchPosts().ToList() as PostedItem);
            userPosts.Add(r_FacebookManager.FetchPosts().ToList() as PostedItem);
            FacebookObjectCollection<Checkin> userCheckin = r_FacebookManager.FetchCheckins();

           
             //Tested Chart with

             //this.chartMostActive.Series["Posts"].Points.AddXY("Dan", 13);
             //this.chartMostActive.Series["Photos"].Points.AddXY("Dan", 33);
             //this.chartMostActive.Series["Posts"].Points.AddXY("Her", 30);
             //this.chartMostActive.Series["Likes"].Points.AddXY("Her", 20);
        }

        private void buttonColumnChart_Click(object i_Sender, EventArgs i_Args)
        {
             changeChartsView(SeriesChartType.Column);
        }

        private void buttonLineChart_Click(object i_Sender, EventArgs i_Args)
        {
             changeChartsView(SeriesChartType.Line);
        }

        private void changeChartsView (SeriesChartType i_ChartType)
        {
             foreach (Series series in chartMostActive.Series)
             {
                  series.ChartType = i_ChartType;
             }
        }
    }
}