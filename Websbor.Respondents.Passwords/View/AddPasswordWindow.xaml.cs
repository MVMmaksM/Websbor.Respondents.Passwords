using DbLibrary.Repositories;
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
using System.Windows.Shapes;
using Websbor.Respondents.Passwords.ViewModel;

namespace Websbor.Respondents.Passwords.View
{  
    public partial class AddWindow : Window
    {      
        private AddPassordViewModel _addPassordViewModel;
        private PasswordsRepositories _repositoryPassword;
        public AddWindow()
        {
            InitializeComponent();
            _addPassordViewModel = new AddPassordViewModel();
            _addPassordViewModel.Password.DateCreate = DateTime.Now.ToShortDateString();
            _repositoryPassword = new PasswordsRepositories();
            this.DataContext = _addPassordViewModel;            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _repositoryPassword.AddAsync(_addPassordViewModel.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        private void TxtBxOkpo_LostFocus(object sender, RoutedEventArgs e)
        {
            _addPassordViewModel.GetWebsborGS();
        }
    }
}
