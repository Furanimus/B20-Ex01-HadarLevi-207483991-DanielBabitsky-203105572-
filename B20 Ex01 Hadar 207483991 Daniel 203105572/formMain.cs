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
     public partial class formMain : Form
     {
          private readonly FacebookManager r_FacebookManager;

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

          private void formMain_Load(object i_Sender, EventArgs i_Args)
          {
          }

          protected override void OnClosing(CancelEventArgs i_Args)
          {
               r_FacebookManager.Logout();

               base.OnClosing(i_Args);
          }

          protected override void OnClosed(EventArgs i_Args)
          {
               Form form = MdiParent;
               form.Close();

               base.OnClosed(i_Args);
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
               fetchFriends();
          }

          private void buttonOpenFBBrowser_Click(object i_Sender, EventArgs i_Args)
          {
               FormFBBrowser fBBrowser = new FormFBBrowser();
               fBBrowser.Show();
          }

          private void buttonFetchCheckins_Click(object i_Sender, EventArgs i_Args)
          {
               fetchCheckins();
          }

          private void buttonFetchGroups_Click(object i_Sender, EventArgs i_Args)
          {
               fetchGroups();
          }

          private void fetchFriends()
          {
               foreach (User friend in LoggedInUser.Friends)
               {
                    listBoxFriends.Items.Add(friend);
               }
          }

          private void fetchCheckins()
          {
               foreach (Checkin chekin in LoggedInUser.Checkins)
               {
                    listBoxCheckins.Items.Add(chekin);
               }
          }

          private void fetchGroups()
          {
               foreach (Group group in LoggedInUser.Groups)
               {
                    listBoxGroups.Items.Add(group);
               }
          }

          private void formMain_FormClosing(object sender, FormClosingEventArgs e)
          {
          }

          private void buttonFindFriend_Click(object i_Sender, EventArgs i_Args)
          {
               listBoxFriends.Items.Clear();

               foreach (User friend in LoggedInUser.Friends)
               {
                    if (friend.ToString().Contains(textBoxFriendSearch.Text))
                    {
                         listBoxFriends.Items.Add(friend);
                    }
               }
          }
     }
}