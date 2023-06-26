using DbLibrary.Configurations;
using DbLibrary.Model;
using DbLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Websbor.Respondents.Passwords.Configurations;
using Websbor.Respondents.Passwords.Services;
using Websbor.Respondents.Passwords.View;
using Websbor.Respondents.Passwords.ViewModel;

namespace Websbor.Respondents.Passwords
{
    public class Facade
    {
        private readonly string PATH_FILE_SETTING = Path.Combine(Environment.CurrentDirectory, "appSetting.json");
        private FileServices _fileServices;
        private AppSettings _appSettings;
        private PasswordsRepositories _passwordsRepositories;
        private WebsborGSRepositories _websborRepositories;
        public PasswordViewModel PasswordViewModel { get; }
        public WebsborGSViewModel WebsborGSViewModel { get; }
        public Facade()
        {
            _fileServices = new FileServices(new WorkFile(), new WorkExcelFile());
            _passwordsRepositories = new PasswordsRepositories();
            _websborRepositories = new WebsborGSRepositories();
            PasswordViewModel = new PasswordViewModel();
            WebsborGSViewModel = new WebsborGSViewModel();
        }

        public AppSettings Initialize()
        {
            _appSettings = _fileServices.GetSettingsFromFile(PATH_FILE_SETTING);
            DbSettings.ConnectionString = _appSettings.GetconnectionString();
            return _appSettings;
        }

        public void GetAllPasswords()
        {
            Task.Run(() => PasswordViewModel.Password = new ObservableCollection<DbLibrary.Model.Passwords>(_passwordsRepositories.GetAll()));
        }
        public void GetAllWebsborGS()
        {
            Task.Run(() => WebsborGSViewModel.WebsborGS = new ObservableCollection<WebsborGS>(_websborRepositories.GetAll()));
        }

        public int AddPassword(DbLibrary.Model.Passwords dataPassword)
        {
            var result = _passwordsRepositories.AddAsync(dataPassword);
            return result.Result;
        }

        public void LoadPassword()
        {
            try
            {
                var pathFile = FileDialog.ShowOpenFileDialog();

                if (!string.IsNullOrWhiteSpace(pathFile))
                {
                    var extFile = Path.GetExtension(pathFile);
                    if (extFile == ".xlsx")
                    {
                        var dataLoad = _fileServices.LoadPasswordExcel(pathFile);
                        _passwordsRepositories.AddFromList(dataLoad);
                    }
                    else if (extFile == ".txt")
                    {
                        //загрузка из текстового файла
                    }
                    else
                    {
                        throw new Exception("Неподдерживаемое расширение файла");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void LoadWebsborGS()
        {
            var pathFile = FileDialog.ShowOpenFileDialog();

            if (!string.IsNullOrWhiteSpace(pathFile))
            {
                var extFile = Path.GetExtension(pathFile);
                if (extFile == ".xlsx")
                {
                    var dataLoad = _fileServices.LoadWebsborGSExcel(pathFile);
                    _websborRepositories.AddFromList(dataLoad);
                }
                else if (extFile == ".txt")
                {
                    //загрузка из текстового файла
                }
                else
                {
                    throw new Exception("Неподдерживаемое расширение файла");
                }
            }


        }
        public void DeletePasswordTable()
        {
            _passwordsRepositories.DeleteTable();
        }

        public void CreateAddPasswordWindow(MainWindow mainWindow) 
        {
            var addWindow = new AddWindow();
            addWindow.Owner = mainWindow;
            addWindow.Show();
        }

        public void CreateEditPasswordWindow(MainWindow mainWindow) 
        {
            var addWindow = new EditPasswordWindow(PasswordViewModel);
            addWindow.Owner = mainWindow;
            addWindow.Show();
        }
    }
}
