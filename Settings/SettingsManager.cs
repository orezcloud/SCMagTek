using System;
using System.IO;
using System.Configuration;
using System.Xml.Serialization;

namespace SCMagTek.Settings
{
    public class SettingsManager
    {
        private static readonly string SettingsFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SCMagTek",
            "settings.xml");

        private static readonly SettingsManager _instance = new SettingsManager();
        public static SettingsManager Instance => _instance;

        private UserSettings _settings;

        private SettingsManager()
        {
            LoadSettings();
        }

        public string LastComPort
        {
            get => _settings.LastComPort;
            set
            {
                _settings.LastComPort = value;
                SaveSettings();
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    using (var stream = new FileStream(SettingsFilePath, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(UserSettings));
                        _settings = (UserSettings)serializer.Deserialize(stream);
                    }
                }
                else
                {
                    _settings = new UserSettings();
                    CreateSettingsDirectory();
                    SaveSettings();
                }
            }
            catch (Exception)
            {
                _settings = new UserSettings();
            }
        }

        private void CreateSettingsDirectory()
        {
            string directory = Path.GetDirectoryName(SettingsFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void SaveSettings()
        {
            try
            {
                CreateSettingsDirectory();
                using (var stream = new FileStream(SettingsFilePath, FileMode.Create))
                {
                    var serializer = new XmlSerializer(typeof(UserSettings));
                    serializer.Serialize(stream, _settings);
                }
            }
            catch (Exception)
            {
                // Handle exception (log or notify user)
            }
        }
    }

    [Serializable]
    public class UserSettings
    {
        public string LastComPort { get; set; } = string.Empty;
    }
}
