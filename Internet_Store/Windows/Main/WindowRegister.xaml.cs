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
            roles = new RoleRepository();

            Gender.ItemsSource = new List<string>() { "мужской", "женский" };

            if (CurrentUser.User == null)
            {
                Add.Visibility = Visibility.Collapsed;
                Role.ItemsSource = roles.GetList().Where(i => i.Name_Role != "Админ").Select(i => i.Name_Role);
                Role_txt.Text = "Вы регистрируйтесь как:";
            }
            else if (CurrentUser.Role == "Админ")
            {
                Register.Visibility = Visibility.Collapsed;
                Role.ItemsSource = roles.GetList().Select(i => i.Name_Role);
            }
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
                    Password = Password.Password == PasswordCheck.Password && Password.Password != string.Empty 
                               ? Regex.IsMatch(Password.Password, "(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*") 
                               ? Password.Password 
                               : throw new Exception("Password") 
                               : throw new Exception("PasswordInCorrect"),
                    RoleID = Role.Text != string.Empty
                            ? roles.GetByName(Role.Text).ID
                            : throw new Exception("Role")
                };
                users.Add(userM);

                if (CurrentUser.User == null)
                {
                    MessageBox.Show("Регистрация прошла успешно! Вы будете перенесены на вход", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    WindowAuth windowAuth = new WindowAuth();
                    this.Close();
                    windowAuth.ShowDialog();
                }
                else if (CurrentUser.Role == "Админ") 
                {
                    if(MessageBox.Show("Добавление прошло успешно\nОчистить поля ввода?", "База данных", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No) == MessageBoxResult.Yes)

                    Role.Text = string.Empty;
                    Last_Name.Text = string.Empty;
                    First_Name.Text = string.Empty;
                    Middle_Name.Text = string.Empty;
                    Number_Phone.Text = string.Empty;
                    Gender.Text = string.Empty;
                    Login.Text = string.Empty;
                    Password.Password = string.Empty;
                    PasswordCheck.Password = string.Empty;
                }                
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
                    case "PasswordInCorrect":
                        MessageBox.Show("Ваш пароль должен содержать минимум 8 символов, одну цифру, одну букву верхнего и нижнего регистров", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
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
            if (CurrentUser.User == null)
            {
                WindowAuth windowAuth = new WindowAuth();
                this.Close();
                windowAuth.ShowDialog();
            }
            else if (CurrentUser.Role == "Админ") 
            {
                WindowEditingListPersonsUsers windowEditingListPersonsUsers = new WindowEditingListPersonsUsers();
                this.Close();
                windowEditingListPersonsUsers.ShowDialog();
            }
        }
    }
}
