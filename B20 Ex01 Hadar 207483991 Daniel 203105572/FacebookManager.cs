using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Configuration;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public class FacebookManager
    {
        public LoginResult LoginResult { get; set; }

        public User LoggedInUser { get; set; }

        public AppSettings AppSettings { get; set; }

        public FacebookManager()
        {
            AppSettings = new AppSettings();

            if (AppSettings.RememberUser)
            {
                AppSettings.LoadFromFile();
            }
        }

        public bool Login()
        {

            LoginResult = FacebookService.Login(
                ConfigurationManager.AppSettings["FacebookAppID"].ToString(),
               "public_profile",
               "email",
               "user_birthday",
               "user_age_range",
               "user_gender",
               "user_link",
               "user_tagged_places",
               "user_videos",
               "publish_to_groups",
               "groups_access_member_info",
               "user_friends",
               "user_events",
               "user_likes",
               "user_location",
               "user_photos",
               "user_posts",
               "user_hometown");

            if (!LoginResult.FacebookOAuthResult.IsSuccess)
            {
                return false;
            }

            LoggedInUser = LoginResult.LoggedInUser;
            AppSettings.SaveToFile();

            return true;
        }

        public void Logout()
        {
            if (AppSettings.RememberUser == false)
            {
                FacebookService.Logout(null);
                LoggedInUser = null;
                LoginResult = null;
            }
        }

        public FacebookObjectCollection<User> FetchFriends()
        {
            FacebookObjectCollection<User> userFriends = LoggedInUser.Friends;

            return userFriends;
        }

        public FacebookObjectCollection<Checkin> FetchCheckins()
        {
            FacebookObjectCollection<Checkin> userCheckins = LoggedInUser.Checkins;

            return userCheckins;
        }

        public FacebookObjectCollection<Group> FetchGroups()
        {
            FacebookObjectCollection<Group> userGroups = LoggedInUser.Groups;

            return userGroups;
        }
    }
}