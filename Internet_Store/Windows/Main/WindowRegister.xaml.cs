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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Internet_Store
{
    /// <summary>
    /// Логика взаимодействия для WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        private UserRepository users;
        private PersonRepository persons;
        private RoleRepository roles;
        public WindowRegister()
        {
            InitializeComponent();
            users = new UserRepository();
            persons = new PersonRepository();
            Gender.ItemsSource = new List<string>() { "мужской", "женский" };
            Role.ItemsSource = roles.GetList().Where(i => i.ID < 3).ToList();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserModel userM = new UserModel()
                {
                    Person = new PersonModel()
                    {
                        Last_name = Last_Name.Text != string.Empty ? Last_Name.Text : throw new Exception("Name"),
                        First_name = First_Name.Text != string.Empty ? First_Name.Text : throw new Exception("Name"),
                        Middle_name = Middle_Name.Text != string.Empty ? Middle_Name.Text : throw new Exception("Name"),
                        Number_phone = Number_Phone.Text,
                        Email = "",
                        Birthday = "",
                        Gender = Gender.Text != string.Empty ? Gender.Text : throw new Exception("Gender"),
                        DiscountID = 0
                    },

                    Login = users.GetByName(Login.Text) == null && Login.Text != string.Empty
                            ? Regex.IsMatch(Login.Text, @"^[a-zA-Z](.[a-zA-Z0-9_-]*)$") == true
                            ? Login.Text
                            : throw new Exception("LoginInCorrect")
                            : throw new Exception("Login"),
                    Password = Password.Password == PasswordCheck.Password && Password.Password != string.Empty ? Password.Password : throw new Exception("Password"),
                    RoleID = Role.Text != string.Empty
                            ? roles.GetByName(Role.Text).ID
                            : throw new Exception("Role")
                };
                users.Add(userM);

                MessageBox.Show("Регистрация прошла успешно! Вы будете перенесены на вход", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                WindowAuth windowAuth = new WindowAuth();
                this.Close();
                windowAuth.ShowDialog();
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Role":
                        MessageBox.Show("Поле Роль не заполнено", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Name":
                        MessageBox.Show("Поле ФИО заполнено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Login":
                        MessageBox.Show("Такой логин уже занят", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Password":
                        MessageBox.Show("Введённые пароли не совпадают", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Number_Phone":
                        MessageBox.Show("Номер телефона заполнен некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Gender":
                        MessageBox.Show("Поле Пол не заполнено", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "LoginInCorrect":
                        MessageBox.Show("Логин может содержать только латинские буквы, цифры, тире и символ нижнего подчёркивания", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    default:
                        MessageBox.Show("Проверьте корректность введённых данных", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            WindowAuth windowAuth = new WindowAuth();
            this.Close();
            windowAuth.ShowDialog();
        }
    }
}
