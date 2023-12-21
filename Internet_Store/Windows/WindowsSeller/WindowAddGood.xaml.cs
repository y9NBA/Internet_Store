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
using System.Text.RegularExpressions;
using System.Security.Authentication;
using System.CodeDom;

namespace Internet_Store.Windows.WindowsSeller
{
    /// <summary>
    /// Логика взаимодействия для WindowAddGood.xaml
    /// </summary>
    public partial class WindowAddGood : Window
    {
        private GoodRepository goods;
        private TypeRepository types;
        private UserRepository users;
        public WindowAddGood()
        {
            InitializeComponent();
            goods = new GoodRepository();
            types = new TypeRepository();
            users = new UserRepository();

            var sellers = users.GetList().Where(i => i.Role.Name_Role == "Продавец").ToList();

            if (CurrentUser.Role == "Продавец")
            {
                Seller.Visibility = Visibility.Collapsed;
                Author.Visibility = Visibility.Collapsed;
                Seller.ItemsSource = sellers.Where(i => CurrentUser.User.ID == i.ID);
                Seller.SelectedIndex = 0;
            }
            if(CurrentUser.Role == "Админ")
            {
                Seller.ItemsSource = sellers;
                Seller.SelectedIndex = sellers.FindIndex(i => i.ID == CurrentGood.Good.SellerID);
            }
            if(CurrentGood.isEditing == true)
            {
                Register.Visibility = Visibility.Collapsed;
                
                GoodModel good = GoodMapper.Map(CurrentGood.Good);

                Name_Good.Text = good.Name;
                Description.Text = good.Description;
                Amount.Text = good.Amount.ToString();
                Price.Text = good.Price.ToString().Replace('.', ',');
                Type.SelectedIndex = int.Parse(good.TypeID.ToString()) - 1;
            }
            if(CurrentGood.isEditing == false)
            {
                Rechange.Visibility = Visibility.Collapsed;

                Amount.Text = "1";
                Price.Text = "1,0";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            goods.GetList();

            Type.ItemsSource = types.GetList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GoodModel good = new GoodModel()
                {
                    Name = Name_Good.Text != string.Empty ? Name_Good.Text : throw new Exception("NameGood"),
                    Description = Description.Text != string.Empty ? Description.Text : throw new Exception("Description"),
                    Amount = Amount.Text != string.Empty && Int32.TryParse(Amount.Text, out int amount) == true
                             ? amount : throw new Exception("Amount"),
                    Price = Price.Text != string.Empty && Decimal.TryParse(Price.Text, out decimal price) == true
                            ? price : throw new Exception("Price"),
                    TypeID = Type.Text != string.Empty ? types.GetByName(Type.Text).ID : throw new Exception("Type"),
                    SellerID = Seller.Text != string.Empty 
                               ? users.GetById((Seller.SelectedItem as UserModel).ID).ID
                               : throw new Exception("Seller")
                };

                goods.Add(good);

                Clear_Field();
            }
            catch (Exception ex)
            {
                switch(ex.Message)
                {
                    case "NameGood":
                        MessageBox.Show("Название товара введено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Description":
                        MessageBox.Show("Описание товара введено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Amount":
                        MessageBox.Show("Количество товара введено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Price":
                        MessageBox.Show("Цена товара введена некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Type":
                        MessageBox.Show("Категория товара введена некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Seller":
                        MessageBox.Show("Производитель товара введён некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CurrentGood.Good = null;
            CurrentGood.isEditing = false;

            WindowEditingGood windowEditingGood = new WindowEditingGood();
            this.Close();
            windowEditingGood.ShowDialog();
        }
        
        private void Clear_Field()
        {
            switch (CurrentGood.isEditing)
            {
                case true:
                    if (MessageBox.Show("Товар успешно обновлён\nВернуться к списку товаров?", "Store", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        CurrentGood.isEditing = false;
                        CurrentGood.Good = null;

                        WindowEditingGood windowEditingGood = new WindowEditingGood();
                        this.Close();
                        windowEditingGood.ShowDialog();
                    }
                    break;
                case false:
                    if (MessageBox.Show("Товар успешно добавлен\nОчистить поля ввода?", "Store", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        Name_Good.Text = string.Empty;
                        Description.Text = string.Empty;
                        Amount.Text = "1";
                        Price.Text = "1,0";
                        Type.SelectedIndex = -1;
                    }
                    break;
            }
            
        }
        private void Rechange_Click(object sender, RoutedEventArgs e)
        {
            GoodModel good = GoodMapper.Map(CurrentGood.Good);

            try
            {
                good.Name = Name_Good.Text != string.Empty ? Name_Good.Text : throw new Exception("NameGood");
                good.Description = Description.Text != string.Empty ? Description.Text : throw new Exception("Description");
                good.Amount = Amount.Text != string.Empty && Int32.TryParse(Amount.Text, out int amount) == true
                             ? amount : throw new Exception("Amount");
                good.Price = Price.Text != string.Empty && Decimal.TryParse(Price.Text, out decimal price) == true
                            ? price : throw new Exception("Price");
                good.TypeID = Type.Text != string.Empty ? types.GetByName(Type.Text).ID : throw new Exception("Type");

                goods.Update(good);

                Clear_Field();
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "NameGood":
                        MessageBox.Show("Название товара введено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Description":
                        MessageBox.Show("Описание товара введено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Amount":
                        MessageBox.Show("Количество товара введено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Price":
                        MessageBox.Show("Цена товара введена некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case "Type":
                        MessageBox.Show("Категория товара введена некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
        }
    }
}
