using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public sealed class FacebookManager
    {

        private readonly string[] r_Permissions = new string[]
        {
            "public_profile", "email", "user_birthday", "user_age_range", "user_gender", "user_link", "user_tagged_places",
            "user_videos", "publish_to_groups", "groups_access_member_info", "user_friends", "user_events", "user_likes",
            "user_location","publish_pages" , "user_photos","manage_pages", "user_posts", "user_hometown"
        };

        public LoginResult LoginResult { get; set; }

        public User LoggedInUser { get; set; }

        public AppSettings AppSettingsInstance { get; set; }

        public FacebookManager(AppSettings AppSettings)
        {
            AppSettingsInstance = AppSettings;
        }

        public bool Login(bool i_RememeberMe)
        {
            LoginResult = FacebookService.Login(ConfigurationManager.AppSettings["FacebookAppID"].ToString(), r_Permissions);
            
            if (!LoginResult.FacebookOAuthResult.IsSuccess)
            {
                return false;
            }

            LoggedInUser = LoginResult.LoggedInUser;

            AppSettingsInstance.LastAccessToken = LoginResult.AccessToken;
            AppSettingsInstance.RememberUser = i_RememeberMe;

            AppSettingsInstance.SaveToFile();

            return true;
        }

        public void Connect()
        {
            LoginResult = FacebookService.Connect(AppSettingsInstance.LastAccessToken);
            LoggedInUser = LoginResult.LoggedInUser;
        }

        public void Logout()
        {
            FacebookService.Logout(null);
            LoggedInUser = null;
            LoginResult = null;
            AppSettingsInstance.RememberUser = false;
            AppSettingsInstance.SaveToFile();
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

        public FacebookObjectCollection<Post> FetchPosts()
        {
            FacebookObjectCollection<Post> userPosts = LoggedInUser.Posts;
            return userPosts;
        }

        public FacebookObjectCollection<Album> FetchAlbums()
        {
            try
            {
                FacebookObjectCollection<Album> userAlbums = LoggedInUser.Albums;
                return userAlbums;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void PostStatus(string userInput)
        {
            LoggedInUser.PostStatus(userInput);
        }

        public Dictionary<int, List<int>> BestTimeToGetMostLikes()
        {
            FacebookObjectCollection<Post> userPosts = FetchPosts();
            FacebookObjectCollection<Checkin> userCheckins = FetchCheckins();
            FacebookObjectCollection<Album> userAlbums = FetchAlbums();

            Dictionary<int, List<int>> likesPerHour = new Dictionary<int, List<int>>();

            for (int i = 0; i < 24; i++)
            {
                fillLikesCountPerHour(userPosts, likesPerHour);
                fillLikesCountPerHour(userCheckins, likesPerHour);
                fillLikesCountPerHour(userAlbums, likesPerHour);
            }

            return likesPerHour;

        }

        private void fillLikesCountPerHour<T>(FacebookObjectCollection<T> userPosts, Dictionary<int, List<int>> likesPerHour) where T : PostedItem
        {
            //try
            //{
            foreach (T post in userPosts)
            {
                DateTime? timeCreated = post.CreatedTime;
                int? numberOfLikes = post.LikedBy?.Count;
                if (timeCreated.HasValue)
                {
                    if (!likesPerHour.ContainsKey(timeCreated.Value.Hour))
                    {
                        likesPerHour.Add(timeCreated.Value.Hour, new List<int>());
                    }
                    if (numberOfLikes.HasValue)
                    {
                        likesPerHour[timeCreated.Value.Hour].Add(numberOfLikes.Value);
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //        MessageBox.Show("No items to show");
            //}
        }

    }
}