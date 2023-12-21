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
    /// Логика взаимодействия для WindowAuth.xaml
    /// </summary>
    public partial class WindowAuth : Window
    {
        private UserRepository users;
        public WindowAuth()
        {
            InitializeComponent();
            users = new UserRepository();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            users.GetList();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            WindowRegister windowRegister = new WindowRegister();
            this.Close();
            windowRegister.ShowDialog();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.User = users.GetList().Where(i => i.Login == Login.Text && i.Password == Password.Password).FirstOrDefault();
            if(CurrentUser.User != null)
            {
                CurrentUser.Role = CurrentUser.User.Role.Name_Role;

                MessageBox.Show($"Вы успешно вошли под логином {CurrentUser.User.Login}\nС возвращением {CurrentUser.User.Person.First_name}!", "Store", MessageBoxButton.OK, MessageBoxImage.Information);
                
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Проверьте корректность введённых данных и повторите попытку", "Что-то пошло не так", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Вы уверены, что хотите войти как гость?", "Store", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show($"Вы вошли как гость\nВам будут недоступны некоторые функции", "Store", MessageBoxButton.YesNo, MessageBoxImage.Information);
                Quest.IsAuth = true;

                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы хотите выйти из приложения?", "Store", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Пользователь, приходите ещё)\nВаш Internet_Store", "Store", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
    }
}
