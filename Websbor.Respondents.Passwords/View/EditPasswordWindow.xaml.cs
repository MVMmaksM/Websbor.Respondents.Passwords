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
    public partial class EditPasswordWindow : Window
    {
        private PasswordsRepositories _passwordsRepository;
        private PasswordViewModel _editPassword;
        public EditPasswordWindow(PasswordViewModel passwordViewModel )
        {
            InitializeComponent();
            _editPassword = passwordViewModel;
            this.DataContext = _editPassword;
            _passwordsRepository = new PasswordsRepositories();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _passwordsRepository.Update(_editPassword.SelectedPasswordEdit);
        }      
    }
}
