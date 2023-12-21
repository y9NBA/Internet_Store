using Infrastructure;
using Internet_Store.Windows.WindowsSeller;
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
    /// Логика взаимодействия для WindowEditingGood.xaml
    /// </summary>
    public partial class WindowEditingGood : Window
    {
        private GoodRepository goods;
        private UserRepository users;
        public WindowEditingGood()
        {
            InitializeComponent();
            goods = new GoodRepository();
            users = new UserRepository();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            WindowAddGood windowAddGood = new WindowAddGood();
            this.Close();
            windowAddGood.ShowDialog();
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            GoodModel good = ViewList.SelectedItem as GoodModel;

            if(good == null)
            {
                return;
            }

            goods.Delete(good.ID);
            MessageBox.Show("Товар удалён", "Store", MessageBoxButton.OK, MessageBoxImage.Information);
            Update();
        }


        private void Updating_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            goods.GetList();
            users.GetList();

            Update();
        }

        private void Update()
        {
            if (CurrentUser.Role == "Продавец")
            {
                ViewList.ItemsSource = goods.GetList().Where(i => i.SellerID == CurrentUser.User.ID);
            }
            else if (CurrentUser.Role == "Админ")
            {
                ViewList.ItemsSource = goods.GetList();
            }
        }

        private void Button_Click_Description(object sender, RoutedEventArgs e)
        {
            GoodModel good = ViewList.SelectedItem as GoodModel;

            if (good == null)
            {
                MessageBox.Show("Вы не выбрали товар", "Store", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            else
            {
                CurrentGood.Good = GoodMapper.Map(good);
                CurrentGood.isEditing = true;

                WindowGoodView windowGoodView = new WindowGoodView();
                this.Close();
                windowGoodView.ShowDialog();
            }
        }

        private void ViewList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GoodModel good = ViewList.SelectedItem as GoodModel;

            if(good == null)
            {
                return;
            }

            CurrentGood.Good = GoodMapper.Map(good);
            CurrentGood.isEditing = true;

            WindowAddGood windowAddGood = new WindowAddGood();
            this.Close();
            windowAddGood.ShowDialog();
        }
    }
}
