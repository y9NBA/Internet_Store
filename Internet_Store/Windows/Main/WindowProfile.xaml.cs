using Infrastructure;
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
    /// Логика взаимодействия для WindowProfile.xaml
    /// </summary>
    public partial class WindowProfile : Window
    {
        private UserRepository users;
        private PersonRepository persons;
        public WindowProfile()
        {
            InitializeComponent();
            users = new UserRepository();
            persons = new PersonRepository();
            Gender.ItemsSource = new List<string>() { "мужской", "женский" };
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            UserModel user = users.GetById(CurrentUser.User.ID);
            PersonModel person = user.Person;

            try
            {
                user.Login = Login.Text != user.Login 
                                ? users.GetByName(Login.Text) == null && Login.Text != string.Empty
                                ? Regex.IsMatch(Login.Text, @"^[a-zA-Z](.[a-zA-Z0-9_-]*)$") == true
                                ? Login.Text
                                : throw new Exception("LoginInCorrect")
                                : throw new Exception("Login")
                                : user.Login;
                person.Last_name = Last_Name.Text;
                person.First_name = First_Name.Text;
                person.Middle_name = Middle_Name.Text;
                person.Number_phone = Number_Phone.Text;
                person.Email = Email.Text;
                person.Birthday = Birthday.Text;
                user.Person.Gender = Gender.SelectedItem.ToString();

                if (Password.Password != null)
                {
                    user.Password = Password.Password != string.Empty
                                   ? Password.Password != user.Password
                                   ? Password.Password == PasswordCheck.Password
                                   ? Regex.IsMatch(Password.Password, "(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*")
                                   ? Password.Password
                                   : throw new Exception("Password")
                                   : throw new Exception("PasswordInCorrect")
                                   : throw new Exception("AlsoPassword")
                                   : user.Password;
                }

                users.Update(user);
                MessageBox.Show("Данные профиля обновлены", "Store", MessageBoxButton.OK, MessageBoxImage.Information);
                Update();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show($"Дата рождения введена некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
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
                    case "AlsoPassword":
                        MessageBox.Show("Ваш пароль должен отличаться от предыдущего", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Number_Phone":
                        MessageBox.Show("Номер телефона заполнен некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Gender":
                        MessageBox.Show("Поле Пол не заполнено", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Email":
                        MessageBox.Show("Почта введена некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
                        break;
                    case "Birthday":
                        MessageBox.Show("Дата рождения введена некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Stop);
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

        private void Canc_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            users.GetList();
            Update();
        }

        private void Update()
        {
            UserModel user = users.GetById(CurrentUser.User.ID);
            PersonModel person = persons.GetById(CurrentUser.User.ID);

            Role_txt.Text = user.Role.Name_Role;
            Login.Text = user.Login;
            Last_Name.Text = person.Last_name;
            First_Name.Text = person.First_name;
            Middle_Name.Text = person.Middle_name;
            Number_Phone.Text = person.Number_phone;
            Email.Text = person.Email;
            Birthday.Text = person.Birthday;
            Gender.SelectedItem = user.Person.Gender;
        }
    }
}
