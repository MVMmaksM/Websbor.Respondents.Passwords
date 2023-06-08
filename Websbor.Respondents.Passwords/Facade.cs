using DbLibrary.Configurations;
using DbLibrary.Model;
using DbLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Respondents.Passwords.Configurations;
using Websbor.Respondents.Passwords.Services;

namespace Websbor.Respondents.Passwords
{
    public class Facade
    {
        private readonly string PATH_FILE_SETTING = Path.Combine(Environment.CurrentDirectory, "appSetting.json");
        private FileServices _fileServices;
        private AppSettings _appSettings;
        private PasswordsRepositories _passwordsRepositories;
        private WebsborGSRepositories _websborRepositories;
        public Facade()
        {
            _fileServices = new FileServices(new WorkFile());
        }

        public AppSettings Initialize()
        {
            _appSettings = _fileServices.GetSettingsFromFile(PATH_FILE_SETTING);
            DbSettings.ConnectionString = _appSettings.GetconnectionString();
            return _appSettings;
        }

        public List<DbLibrary.Model.Passwords> GetAllPasswords()
        {
            var result = _passwordsRepositories.GetAll();
            return result.Result;
        }

        public int AddPassword(DbLibrary.Model.Passwords dataPassword) 
        {
            var result = _passwordsRepositories.AddAsync(dataPassword);
            return result.Result;
        }
    }
}
