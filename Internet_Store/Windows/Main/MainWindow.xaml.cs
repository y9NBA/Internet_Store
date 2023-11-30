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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            switch (CurrentUser.Role)
            {
                case "Покупатель":
                    Seller.Visibility = Visibility.Collapsed;
                    Admin.Visibility = Visibility.Collapsed;
                    break;
                case "Продавец":
                    Admin.Visibility = Visibility.Collapsed;
                    Customer.Visibility = Visibility.Collapsed;
                    break;
                case "Админ": 
                    Customer.Visibility = Visibility.Collapsed;
                    Seller.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
