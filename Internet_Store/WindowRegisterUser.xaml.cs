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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WindowRegisterUser : Window
    {
        public WindowRegisterUser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.User.ToList();
            Singleton.DB.Person.ToList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (Last_Name.Text == "" || First_Name.Text == "" || Middle_Name.Text == ""
                || Login.Text == "" || (Password.Password == "" && PasswordCheck.Password == ""))
            {
                MessageBox.Show("Введены не все данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            if(Password.Password != PasswordCheck.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User user = new User();
            Person person = new Person();
            Role role = Singleton.DB.Role.Where(roleCheck => roleCheck.Name == "Покупатель").FirstOrDefault() as Role;

            user.Login = Login.Text;
            user.Password = Password.Password;

            person.Last_name = Last_Name.Text;
            person.First_name = First_Name.Text;
            person.Middle_name = Middle_Name.Text;

            person.User.Add(user);
            user.Person.Add(person);
            user.Role.Add(role);

            Singleton.DB.User.Local.Add(user);
            Singleton.DB.Person.Local.Add(person);

            Singleton.DB.SaveChanges();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Login_SelectionChanged(object sender, RoutedEventArgs e)
        {
            foreach (User userCheck in Singleton.DB.User.Local)
            {
                if (userCheck.Login == Login.Text)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Проблема", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Login.Text = "";
                    return;
                }
            }
        }

        private void Person_Check()
        {
            foreach (Person personCheck in Singleton.DB.Person.Local)
            {
                if(personCheck.Last_name == Last_Name.Text && personCheck.First_name == First_Name.Text 
                    && personCheck.Middle_name == Middle_Name.Text)
                {
                    MessageBox.Show("Человек с такими данными уже занесён!", "Проблема", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Last_Name.Text = "";
                    First_Name.Text = "";
                    Middle_Name.Text = "";
                    return;
                }
            }
        }

        private void Person2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Person_Check();
        }

        private void Person1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Person_Check();
        }

        private void Person3_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Person_Check();
        }
    }
}
