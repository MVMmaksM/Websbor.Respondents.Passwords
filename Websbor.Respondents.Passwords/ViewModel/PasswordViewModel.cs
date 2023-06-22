using DbLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Respondents.Passwords.ViewModel
{
    public class PasswordViewModel : INotifyPropertyChanged
    {
        private WebsborGSRepositories _websborGSRepositories = new WebsborGSRepositories();
        private object _selectedPassword;
        private BindingList<DbLibrary.Model.Passwords> _passwords = new BindingList<DbLibrary.Model.Passwords>();
        public BindingList<DbLibrary.Model.Passwords> Password
        {
            get { return _passwords; }
            set
            {
                _passwords = value;
                OnPropertyChanged("Password");
            }
        }

        public object SelectedPassword
        {
            get { return _selectedPassword; }
            set
            {
                _selectedPassword = _websborGSRepositories.GetByOkpo(((DbLibrary.Model.Passwords)value).Okpo); ;
                OnPropertyChanged("SelectedPassword");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
