using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Respondents.Passwords.Configurations;

namespace Websbor.Respondents.Passwords.Services
{
    public class FileServices
    {
        private IWorkFile _workFile;
        public FileServices(IWorkFile workFile)
        {
            _workFile = workFile;
        }

        public AppSettings GetSettingsFromFile(string pathFileSetting)
        {
            if (File.Exists(pathFileSetting))
            {
                var settingString = _workFile.ReadFile(pathFileSetting);
                return JsonConvert.DeserializeObject<AppSettings>(settingString);
            }

            var appSettings = new AppSettings();
            SaveFileSetting(appSettings, pathFileSetting);
            return appSettings; 
        }

        public void SaveFileSetting(AppSettings appSettings, string pathFileSetting) 
        {
            var settingString = JsonConvert.SerializeObject(appSettings);
            var bytesFile = Encoding.UTF8.GetBytes(pathFileSetting);
            _workFile.SaveFile(pathFileSetting, bytesFile);
        }
    }
}
