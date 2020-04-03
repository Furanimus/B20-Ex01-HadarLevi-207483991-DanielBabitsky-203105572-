using System.IO;
using System.Xml.Serialization;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public sealed class AppSettings
    {
        private static AppSettings m_AppSettings = null;

        private static object m_lock = new object();
        
        public bool RememberUser { get; set; }          
        
        public string LastAccessToken { get; set; }

        private AppSettings()
        {
            RememberUser = false;
            LastAccessToken = null;
        }

        public static AppSettings Instance
        {
            get
            {
                if (m_AppSettings == null)
                {
                    lock (m_lock)
                    {
                        if (m_AppSettings == null)
                        {
                            m_AppSettings = LoadFromFile();
                        }
                    }
                }

                return m_AppSettings;
            }
        }

        private static AppSettings LoadFromFile()
        {
            AppSettings m_AppSettings = new AppSettings();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "AppSettings.xml");

            if (File.Exists(filePath))
            {
                using (Stream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "AppSettings.xml"), FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    m_AppSettings = serializer.Deserialize(stream) as AppSettings;
                }
            }
            return m_AppSettings;
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
