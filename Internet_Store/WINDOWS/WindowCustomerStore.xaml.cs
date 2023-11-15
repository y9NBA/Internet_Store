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
using System.Windows.Shapes;

namespace Internet_Store
{
    /// <summary>
    /// Логика взаимодействия для WindowCustomerStore.xaml
    /// </summary>
    public partial class WindowCustomerStore : Window
    {
        public WindowCustomerStore()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCustomer windowCustomer = new WindowCustomer();
            Hide();
            windowCustomer.ShowDialog();
            Show();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}