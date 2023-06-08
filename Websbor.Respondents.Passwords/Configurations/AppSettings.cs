using Microsoft.Data.SqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Respondents.Passwords.Configurations
{
    public class AppSettings : INotifyPropertyChanged
    {
        private SqlConnectionStringBuilder StringBuilder;  
        public string Server
        {
            get { return StringBuilder.DataSource; }
            set 
            { 
                StringBuilder.DataSource = value;
                OnPropertyChanged("Server");
            }
        } 
        public string Initialcatalog
        {
            get { return StringBuilder.InitialCatalog; }
            set 
            { 
                StringBuilder.InitialCatalog = value;
                OnPropertyChanged("NameDatabase");
            }
        }

        public string GetconnectionString() => StringBuilder.ConnectionString;
        
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
