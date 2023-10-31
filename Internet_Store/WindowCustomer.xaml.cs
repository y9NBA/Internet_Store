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

namespace Internet_Store
{
    /// <summary>
    /// Логика взаимодействия для WindowCustomer.xaml
    /// </summary>
    public partial class WindowCustomer : Window
    {
        public WindowCustomer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCustomerStore windowCustomerStore = new WindowCustomerStore();
            Hide();
            windowCustomerStore.ShowDialog();
            Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
