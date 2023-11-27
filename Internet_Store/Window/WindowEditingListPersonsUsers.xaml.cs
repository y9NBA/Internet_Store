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
using Infrastructure;

namespace Internet_Store
{
    /// <summary>
    /// Логика взаимодействия для WindowEditingListUsers.xaml
    /// </summary>
    public partial class WindowEditingListPersonsUsers : Window
    {
        private PersonRepository persons;
        private UserRepository users;
        public WindowEditingListPersonsUsers()
        {
            InitializeComponent();
            persons = new PersonRepository();
            users = new UserRepository();
            ViewPersons.ItemsSource = persons.GetList();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Button");
        }

        private void Button_Click_Upd(object sender, RoutedEventArgs e)
        {
            foreach (PersonModel person in ViewPersons.ItemsSource)
            {
                try
                {
                    if (persons.Update(person) == null)
                    {
                        MessageBox.Show($"У записи под номером {person.ID} введены данные некорректно", "Ошибка ввода");
                    }
                    else
                    {
                        MessageBox.Show("Сохранение прошло успешно", "Good");
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Дата рождения введена некорректно");
                }
                catch(Exception ex)
                {
                    if (ex.Message == "Number_Phone")
                    {
                        MessageBox.Show("Номер телефона введён некорректно");
                    }
                    else if (ex.Message == "Email")
                    {
                        MessageBox.Show("Почта введена некорректно");
                    }
                }
            }
        }
    }
}
