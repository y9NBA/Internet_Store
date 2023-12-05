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
            if(MessageBox.Show("Хотите выйти из аккаунта?", "Store", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                CurrentUser.User = null;
                CurrentUser.Role = null;

                WindowAuth windowAuth = new WindowAuth();
                this.Close();
                windowAuth.ShowDialog();
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
    }
}
