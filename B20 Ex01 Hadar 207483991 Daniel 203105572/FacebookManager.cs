using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public class FacebookManager
    {
        public const string AppID = "970453233350486";
        public User LoggedInUser { get; set; }

        public LoginResult LoginResult { get; set; }

        public FacebookManager()
        {
        }
        public void Login()
        {
            LoginResult = FacebookService.Login(
               AppID,
               "public_profile",
               "email",
               "publish_to_groups",
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
            LoggedInUser = LoginResult.LoggedInUser;
        }
    }
}
