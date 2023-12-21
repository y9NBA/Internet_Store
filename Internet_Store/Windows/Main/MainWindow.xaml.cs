using Infrastructure;
using Internet_Store.Windows.Main;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            switch (CurrentUser.Role)
            {
                case "Покупатель":
                    Button_Seller.Visibility = Visibility.Collapsed;
                    Button_Admin.Visibility = Visibility.Collapsed;
                    break;
                case "Продавец":
                    Button_Customer.Visibility = Visibility.Collapsed;
                    Button_Admin.Visibility = Visibility.Collapsed;
                    break;
                case "Админ": 
                    Button_Customer.Visibility = Visibility.Collapsed;
                    Button_Seller.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            switch (Quest.IsAuth)
            {
                case true:
                    Quest.IsAuth = false;
                    WindowAuth windowAuth = new WindowAuth();
                    this.Close();
                    windowAuth.ShowDialog();
                    break;
                case false:
                    if (MessageBox.Show("Хотите выйти из аккаунта?", "Store", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        CurrentUser.User = null;
                        CurrentUser.Role = "Покупатель";

                        WindowAuth windowAuth0 = new WindowAuth();
                        this.Close();
                        windowAuth0.ShowDialog();
                    }
                    break;
            }
        }

        private void Editing_Users_Click(object sender, RoutedEventArgs e)
        {
            WindowEditingListPersonsUsers windowEditingListPersonsUsers = new WindowEditingListPersonsUsers();
            this.Close();
            windowEditingListPersonsUsers.ShowDialog();
        }

        private void Goods_Click(object sender, RoutedEventArgs e)
        {
            WindowGoods windowGoods = new WindowGoods();
            this.Close();
            windowGoods.ShowDialog();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            switch (Quest.IsAuth)
            {
                case true:
                    MessageBox.Show("Недоступно, надо авторизоваться", "Store", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case false:
                    WindowEditingOrder windowEditingOrder = new WindowEditingOrder();
                    this.Close();
                    windowEditingOrder.ShowDialog();
                    break;
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            switch (Quest.IsAuth)
            {
                case true:
                    MessageBox.Show("Недоступно, надо авторизоваться", "Store", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case false:
                    WindowProfile windowProfile = new WindowProfile();
                    this.Close();
                    windowProfile.ShowDialog();
                    break;
            }
        }

        private void Editing_Goods_Click(object sender, RoutedEventArgs e)
        {
            WindowEditingGood windowEditingGood = new WindowEditingGood();
            this.Close();
            windowEditingGood.ShowDialog();
        }
    }
}
