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
    /// Логика взаимодействия для WindowAddPersonUser.xaml
    /// </summary>
    public partial class WindowAddPersonUser : Window
    {
        private UserRepository _userRepository;
        private PersonRepository _personRepository;
        public WindowAddPersonUser()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            _personRepository = new PersonRepository();
            Gender.ItemsSource = new List<string>() { "мужской", "женский" };
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonModel personM = new PersonModel()
                {
                    Last_name = Last_Name.Text != string.Empty ? Last_Name.Text : throw new Exception("Name"),
                    First_name = First_Name.Text != string.Empty ? First_Name.Text : throw new Exception("Name"),
                    Middle_name = Middle_Name.Text != string.Empty ? Middle_Name.Text : throw new Exception("Name"),
                    Number_phone = Number_Phone.Text,
                    Email = "",
                    Birthday = "",
                    Gender = Gender.Text != string.Empty ? Gender.Text : throw new Exception("Gender"),
                    User = new User()
                    {
                        Login = _userRepository.GetByName(Login.Text) == null && Login.Text != string.Empty ? Login.Text : throw new Exception("Login"),
                        Password = Password.Password == PasswordCheck.Password && Password.Password != string.Empty ? Password.Password : throw new Exception("Password"),
                        RoleID = 1
                    },
                    DiscountID = 0
                };
                _personRepository.Add(personM);
                if (MessageBox.Show("Добавление прошло успешно", "База данных", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Name")
                {
                    MessageBox.Show("Поле ФИО заполнено некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (ex.Message == "Login")
                {
                    MessageBox.Show("Такой логин уже занят", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (ex.Message == "Password")
                {
                    MessageBox.Show("Введённые пароли не совпадают", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (ex.Message == "Number_Phone")
                {
                    MessageBox.Show("Номер телефона заполнен некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else if (ex.Message == "Gender")
                {
                    MessageBox.Show("Поле Пол не заполнено", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else
                {
                    MessageBox.Show("Проверьте корректность введённых данных", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            WindowEditingListPersonsUsers windowEditingListPersonsUsers = new WindowEditingListPersonsUsers();
            this.Close();
            windowEditingListPersonsUsers.ShowDialog();
        }
    }
}
