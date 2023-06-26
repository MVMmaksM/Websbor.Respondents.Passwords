﻿using System;
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
using Websbor.Respondents.Passwords.View;
using Websbor.Respondents.Passwords.ViewModel;

namespace Websbor.Respondents.Passwords
{
    public partial class MainWindow : Window
    {
        private Facade _facade;
        private AppSettings _appSettings;      
        public MainWindow()
        {
            InitializeComponent();
            _facade = new Facade();
            DataContext = _facade.ViewModel;
        }

        private void ButtonShowAllData_Click(object sender, RoutedEventArgs e)
        {
            //s.Password = _facade.GetAllPasswords();
            _facade.GetAllPasswords();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var viewModelAdd = new AddPassordViewModel();         
            var addWindow = new AddWindow(viewModelAdd);
            addWindow.Owner = this;           
            addWindow.Show();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemLoadWebSbor_Click(object sender, RoutedEventArgs e)
        {
            _facade.LoadWebsborGS();
        }

        private void MenuItemSaveCurrentRows_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemShemaEcxel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgDataPasswords_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void TxtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_facade.ViewModel.SelectedPassword.ToString());
        }

        private void MenuItemLoadPasswords_Click(object sender, RoutedEventArgs e)
        {
            _facade.LoadPassword();
        }

        private void MenuItemDeletePassword_Click(object sender, RoutedEventArgs e)
        {
            _facade.DeletePasswordTable();
        }      
    }
}
