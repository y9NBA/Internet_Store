using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
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

            if(Role_On.SelectedItem == null) Role_On.SelectedIndex = 0;

            if(Password.Password != PasswordCheck.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User user = new User();
            Person person = new Person();

            user.Login = Login.Text;
            user.Password = Password.Password;

            person.Last_name = Last_Name.Text;
            person.First_name = First_Name.Text;
            person.Middle_name = Middle_Name.Text;

            user.Person.Add(person);

            Singleton.DB.User.Add(user);
            Singleton.DB.Person.Add(person);

            Singleton.DB.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрировались!", "Итог регистрации", MessageBoxButton.OK, MessageBoxImage.Information);

            WindowRegisterUser windowRegisterUser = new WindowRegisterUser();
            this.Close();
            windowRegisterUser.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Login_SelectionChanged(object sender, RoutedEventArgs e)
        {
            foreach (User userCheck in Singleton.DB.User.ToList())
            {
                if (userCheck.Login == Login.Text)
                {
                    if (MessageBox.Show("Логин занят! Хотите поиенять?", "Проблема", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        Login.Cursor = Login.Cursor;
                        return;
                    }
                    else
                    {
                        Login.Text = "";
                        return;
                    }
                }
            }
        }

        private void Person_Check()
        {
            foreach (Person personCheck in Singleton.DB.Person.ToList())
            {
                if (personCheck.Last_name == Last_Name.Text && personCheck.First_name == First_Name.Text
                    && personCheck.Middle_name == Middle_Name.Text && personCheck.User.Count != 0)
                {
                    if (MessageBox.Show("Человек с такими данными уже занесён! Всё равно хотите добавить?", "Проблема", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        Login.Text += personCheck.User.Count.ToString();
                    }
                    else
                    {
                        Last_Name.Text = "";
                        First_Name.Text = "";
                        Middle_Name.Text = "";
                        Login.Text = "";
                        return;
                    }
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
