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
        public WindowAuth()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            WindowRegister windowRegister = new WindowRegister();
            this.Close();
            windowRegister.ShowDialog();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
