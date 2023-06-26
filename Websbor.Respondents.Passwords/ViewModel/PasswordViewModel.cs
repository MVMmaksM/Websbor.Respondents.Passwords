using DbLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Websbor.Respondents.Passwords.ViewModel
{
    public class PasswordViewModel : INotifyPropertyChanged
    {
        private WebsborGSRepositories _websborGSRepositories = new WebsborGSRepositories();
        private object _selectedPassword;
        private ObservableCollection<DbLibrary.Model.Passwords> _passwords = new ObservableCollection<DbLibrary.Model.Passwords>();
        private DbLibrary.Model.Passwords _selectedPasswordEdit;


        public DbLibrary.Model.Passwords SelectedPasswordEdit
        {            
            get { return _selectedPasswordEdit; }
            set
            {
                try
                {
                    _selectedPasswordEdit = value;
                    OnPropertyChanged("SelectedPasswordEdit");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        public ObservableCollection<DbLibrary.Model.Passwords> Password
        {
            get { return _passwords; }
            set
            {

                try
                {
                    _passwords = value;
                    OnPropertyChanged("Password");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        public object SelectedPassword
        {
            get { return _selectedPassword; }
            set
            {
                try
                {
                    _selectedPassword = _websborGSRepositories.GetByOkpo(((DbLibrary.Model.Passwords)value)?.Okpo);
                    SelectedPasswordEdit = (DbLibrary.Model.Passwords)value;
                    OnPropertyChanged("SelectedPassword");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
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
