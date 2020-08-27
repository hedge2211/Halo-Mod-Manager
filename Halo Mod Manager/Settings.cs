using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halo_Mod_Manager
{
    public class Settings
    {
        public string GamePath { get; set; }
        public static string SettingsPath { get
            {
                if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HaloModManager")))
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HaloModManager"));
                }
                string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HaloModManager"), "settings.json");
                return path;
            } }
        public void Save()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            using(FileStream f = new FileStream(Settings.SettingsPath,FileMode.OpenOrCreate))
            {
                var bytes = Encoding.UTF8.GetBytes(json);
                f.Write(bytes, 0, bytes.Length);
            }
        }
        public static Settings Load()
        {
            try
            {
                var json = File.ReadAllText(Settings.SettingsPath);
                Settings set = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(json);
                return set;
            }catch(Exception ex)
            {
                return new Settings();
            }
        }
        
    }
}
