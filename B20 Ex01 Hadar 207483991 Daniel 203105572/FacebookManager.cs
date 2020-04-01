using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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
            AppSettings.LoadFromFile();
        }

        public bool Login(bool rememeberMe)
        {
            LoginResult = FacebookService.Login(
                ConfigurationManager.AppSettings["FacebookAppID"].ToString(),
               "public_profile",
               "email",
               "user_birthday",
               "user_age_range",
               "user_gender",
               "user_link",
               "manage_pages",
               "publish_pages",
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

            AppSettings.RememberUser = rememeberMe;

            if (!LoginResult.FacebookOAuthResult.IsSuccess)
            {
                return false;
            }

            LoggedInUser = LoginResult.LoggedInUser;

            return true;
        }

        public void Connect()
        {
            LoginResult = FacebookService.Connect(AppSettings.AccessToken);
            LoggedInUser = LoginResult.LoggedInUser;
        }
        public void Logout()
        {

            FacebookService.Logout(null);
            LoggedInUser = null;
            LoginResult = null;
            AppSettings.RememberUser = false;
            AppSettings.SaveToFile();


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

        public int BestTimeToGetMostLikes()
        {

            FacebookObjectCollection<Post> userPosts = FetchPosts();
            FacebookObjectCollection<Checkin> userCheckins = FetchCheckins();
            FacebookObjectCollection<Album> userAlbums = FetchAlbums();

            Dictionary<int, List<int>> likesPerHour = new Dictionary<int, List<int>>();

            for (int i = 0; i < 24; i++)
            {
                NewMethod<Post>(userPosts, likesPerHour);
                NewMethod<Checkin>(userCheckins, likesPerHour);
                NewMethod<Album>(userAlbums, likesPerHour);
            }

            // likesPerHour[0].Sum() / likesPerHour[0].Count
            int mostLikedHour = likesPerHour
                .OrderByDescending(kv => kv.Value.Sum() / kv.Value.Count)
                .First().Key;

            return mostLikedHour;

        }

        private static void NewMethod<T>(FacebookObjectCollection<T> userPosts, Dictionary<int, List<int>> likesPerHour) where T : PostedItem
        {
            foreach (T post in userPosts)
            {
                DateTime? timeCeated = post.CreatedTime;
                int? numberOfLikes = post.LikedBy?.Count;
                if (timeCeated.HasValue)
                {
                    if (!likesPerHour.ContainsKey(timeCeated.Value.Hour))
                    {
                        likesPerHour.Add(timeCeated.Value.Hour, new List<int>());
                    }
                    if (numberOfLikes.HasValue)
                    {
                        likesPerHour[timeCeated.Value.Hour].Add(numberOfLikes.Value);
                    }
                }
            }
        }
    }
}