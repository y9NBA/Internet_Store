using Infrastructure;
using Internet_Store.Windows.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для WindowGoodView.xaml
    /// </summary>
    public partial class WindowGoodView : Window
    {
        private GoodRepository goods;
        private UserRepository users;
        private CustomRepository customs;
        public WindowGoodView()
        {
            InitializeComponent();
            goods = new GoodRepository();
            users = new UserRepository();
            customs = new CustomRepository();

            if(CurrentGood.isOrder == true || Quest.IsAuth == true || CurrentGood.isEditing == true)
            {
                Total_Amount.Visibility = Visibility.Collapsed;
                Button_Buy_Good.Visibility = Visibility.Collapsed;
                Button_Incr.Visibility = Visibility.Collapsed;
                Button_Decr.Visibility = Visibility.Collapsed;
                Amount_Label.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            goods.GetList();
            users.GetList();

            Name_Good.Text = CurrentGood.Good.Name;
            Type.Text = CurrentGood.Good.Type.Name_Type;
            Description.Text = CurrentGood.Good.Description;
            Amount.Text = CurrentGood.Good.Amount.ToString();
            Price.Text = CurrentGood.Good.Price.ToString();
            Total_Amount.Text = "1";
        }

        private void Total_Amount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(Total_Amount.Text, out long total_amount) == false)
            {
                MessageBox.Show("Можно вводить только цифры", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                Total_Amount.Text = Regex.Replace(Total_Amount.Text, "[^0-9.]", ""); ;
            }
            else
            {
                if (total_amount > CurrentGood.Good.Amount)
                {
                    MessageBox.Show("Невозможно приобрести такое количество данного товара", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    Total_Amount.Text = CurrentGood.Good.Amount.ToString();
                }
                else if (total_amount == 0)
                {
                    Total_Amount.Text = "1";
                }
            }

            Button_Buy_Good.Content = $"Купить за {int.Parse(Total_Amount.Text) * CurrentGood.Good.Price}";
        }

        private void Add_1_Total_Amount(object sender, RoutedEventArgs e)
        {
            Total_Amount.Text = $"{int.Parse(Total_Amount.Text) + 1}";
        }

        private void Remove_1_Total_Amount(object sender, RoutedEventArgs e)
        {
            Total_Amount.Text = $"{int.Parse(Total_Amount.Text) - 1}";
        }

        private void Button_Buy_Good_Click(object sender, RoutedEventArgs e)
        {
            Custom custom = new Custom()
            {
                Date_Order = DateTime.Now,
                Total_Amount = int.Parse(Total_Amount.Text),
                Total_Price = decimal.Parse(Total_Amount.Text) * CurrentGood.Good.Price,
                StatusID = 1,
                GoodID = CurrentGood.Good.ID,
                CustomerID = CurrentUser.User.ID
            };

            customs.Add(custom);

            users.Update(CurrentUser.User);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentGood.isOrder == true)
            {
                CurrentGood.isOrder = false;

                WindowEditingOrder windowEditingOrder = new WindowEditingOrder();
                this.Close();
                windowEditingOrder.ShowDialog();
            }
            else if (CurrentGood.isEditing == true)
            {
                CurrentGood.isEditing = false;

                WindowEditingGood windowEditingGood = new WindowEditingGood();
                this.Close();
                windowEditingGood.ShowDialog();
            }
            else
            {
                WindowGoods windowGoods = new WindowGoods();
                this.Close();
                windowGoods.ShowDialog();
            }
            
        }
    }
}
