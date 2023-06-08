using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Websbor.Respondents.Passwords.Configurations;

namespace Websbor.Respondents.Passwords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Facade _facade;
        private AppSettings _appSettings;
        public MainWindow()
        {
            InitializeComponent();
            
            _facade = new Facade();
            _appSettings = _facade.Initialize();
            this.DataContext = _appSettings;
        }
    }
}
