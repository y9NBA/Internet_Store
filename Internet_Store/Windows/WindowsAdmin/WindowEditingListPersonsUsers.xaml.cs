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
        
        private void Updating()
        {
            ViewPersons.ItemsSource = persons.GetList();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            WindowAddPersonUser windowAddPersonUser = new WindowAddPersonUser();
            this.Close();
            windowAddPersonUser.ShowDialog();
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            PersonModel personM = ViewPersons.SelectedItem as PersonModel;
            if (personM == null) return;
            try
            {
                persons.Delete(personM.ID);
                MessageBox.Show($"Удаление записи под номером {personM.ID} прошло успешно", "База данных", MessageBoxButton.OK, MessageBoxImage.Error);
                Updating();
            }
            catch
            {
                MessageBox.Show("Удаление не может быть осуществлено", "База данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_Upd(object sender, RoutedEventArgs e)
        {
            List<long> success = new List<long>();
            foreach (PersonModel person in ViewPersons.ItemsSource)
            {
                try
                {
                    persons.Update(person);
                    success.Add(person.ID);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show($"Дата рождения введена некорректно у записи под номером {person.ID}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Number_Phone")
                    {
                        MessageBox.Show($"Номер телефона введён некорректно у записи под номером {person.ID}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (ex.Message == "Email")
                    {
                        MessageBox.Show($"Почта введена некорректно у записи под номером {person.ID}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (ex.Message == "Gender")
                    {
                        MessageBox.Show($"Некорректно введён пол у записи под номером {person.ID}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (ex.Message == "Name")
                    {
                        MessageBox.Show($"Некорректно введено поле ФИО у записи под номером {person.ID}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"У записи под номером {person.ID} введены данные некорректно", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            MessageBox.Show($"Сохранение прошло успешно! Сохранённые записи {string.Join(",", success)}", "База данных", MessageBoxButton.OK, MessageBoxImage.Information);
            Updating();
        }

        private void Updating_Click(object sender, RoutedEventArgs e)
        {
            Updating();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
