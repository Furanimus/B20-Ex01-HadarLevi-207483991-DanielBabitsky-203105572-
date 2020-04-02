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
        private FacebookManager m_Instance = null;
        private readonly object r_CtorContext = new object();

        public FacebookManager Instance
        {
             get
             {
                  if(m_Instance == null)
                  {
                       lock(r_CtorContext)
                       {
                            if(m_Instance == null)
                            {
                                 m_Instance = new FacebookManager();
                            }
                       }
                  }

                  return m_Instance;
             }
        }

        public LoginResult LoginResult { get; set; }

        public User LoggedInUser { get; set; }

        public AppSettings AppSettings { get; set; }

        public FacebookManager()
        {
            AppSettings = new AppSettings();
            AppSettings.LoadFromFile();
        }

        public bool Login(bool i_RememeberMe)
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

            AppSettings.RememberUser = i_RememeberMe;

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