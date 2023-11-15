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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Infrastructure;


namespace Internet_Store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(Singleton.DB.User.ToList());
        }

        private void Btn_Click_Login(object sender, RoutedEventArgs e)
        {
            List<User> users = Singleton.DB.User.Where(user => user.Login == Login.Text && user.Password == Password.Password).ToList();
            if (users.Count == 1)
            {
                User user = users[0];
                List<string> roles = new List<string>();
                string separator = ", ";
                if (user.Role.Count == 0)
                {
                    user.Role.Add(Singleton.DB.Role.Where(role => role.Id == 1).Single());
                    Singleton.DB.SaveChanges();
                }
                foreach (Role role in user.Role)
                {
                    roles.Add(role.Name);
                }
                MessageBox.Show(string.Join(separator, roles), "Вы вошли как:");
                if (roles.Contains("Покупатель"))
                {
                    WindowCustomer windowCustomer = new WindowCustomer();
                    Hide();
                    windowCustomer.ShowDialog();
                    Show();
                }
            }
        }

        private void Btn_Click_Register(object sender, RoutedEventArgs e)
        {
            WindowRegisterUser windowRegisterUser = new WindowRegisterUser();
            this.Close();
            windowRegisterUser.ShowDialog();
        }

        private void Btn_Click_Login_As_Guest(object sender, RoutedEventArgs e)
        {

        }
    }
}
