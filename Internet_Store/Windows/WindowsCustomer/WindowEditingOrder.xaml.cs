using Infrastructure;
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
    /// Логика взаимодействия для WindowEditingOrder.xaml
    /// </summary>
    public partial class WindowEditingOrder : Window
    {
        private CustomRepository custom;

        public WindowEditingOrder()
        {
            InitializeComponent();

            custom = new CustomRepository();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            Custom goodCustom = Orders.SelectedItem as Custom;

            if (goodCustom == null)
            {
                MessageBox.Show("Вы не выбрали товар", "Store", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            else
            {
                CurrentGood.Good = goodCustom.Good;
                CurrentGood.isOrder = true;

                WindowGoodView windowGoodView = new WindowGoodView();
                this.Close();
                windowGoodView.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Orders.ItemsSource = custom.GetList().Where(i => i.CustomerID == CurrentUser.User.ID);
        }
    }
}
