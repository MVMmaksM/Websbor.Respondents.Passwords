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

namespace Websbor.Respondents.Passwords.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
      
        public AddEditWindow(DbLibrary.Model.Passwords passwords)
        {
            InitializeComponent();
        
            
            TxtBxName.Text = passwords.Name;
            TxtBxOkpo.Text = passwords.Okpo;
            TxtBxPassword.Text = passwords.Password;
            TxtBxDateCreate.Text = passwords.DateCreate;
            TxtBxComment.Text = passwords.Comment;
        }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
