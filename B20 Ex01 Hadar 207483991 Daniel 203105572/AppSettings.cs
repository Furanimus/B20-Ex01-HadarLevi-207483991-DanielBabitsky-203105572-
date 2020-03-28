using System;
using System.IO;
using System.Xml.Serialization;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public class AppSettings
    {
        public bool RememberUser { get; set; }

        public string AccessToken { get; set; }

        public AppSettings()
        {
            RememberUser = false;
            AccessToken = null;
        }

        // move all properties with reflection
        public void LoadFromFile()
        {
            try
            {
                using (Stream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "AppSettings.xml"), FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    AppSettings obj = serializer.Deserialize(stream) as AppSettings;
                    this.AccessToken = obj.AccessToken;
                    this.RememberUser = obj.RememberUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SaveToFile()
        {
            using (Stream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "AppSettings.xml"), FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}
