using DbLibrary.Model;
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
    public class WebsborGSViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<WebsborGS> _websborGS = new ObservableCollection<WebsborGS>();
        public ObservableCollection<WebsborGS> WebsborGS
        {
            get { return _websborGS; }
            set 
            { 
                _websborGS = value;
                OnPropertyChanged("WebsborGS");
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
