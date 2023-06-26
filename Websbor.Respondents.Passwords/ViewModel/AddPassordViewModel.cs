using DbLibrary.Model;
using DbLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Websbor.Respondents.Passwords.ViewModel
{
    public class AddPassordViewModel : INotifyPropertyChanged
    {
        private WebsborGSRepositories _websborGSRepositories = new WebsborGSRepositories();
        private DbLibrary.Model.Passwords _passord = new DbLibrary.Model.Passwords();
        private WebsborGS _websborGS = new WebsborGS();
        public DbLibrary.Model.Passwords Password
        {
            get { return _passord; }
            set
            {
                _passord = value;              
                OnPropertyChanged("Password");
            }
        }  
        public WebsborGS WebsborGS
        {
            get { return _websborGS; }
            set 
            {
                _websborGS = value;
                OnPropertyChanged("WebsborGS");
            }
        }

        public void GetWebsborGS() 
        {
            WebsborGS = _websborGSRepositories.GetByOkpo(Password.Okpo);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
