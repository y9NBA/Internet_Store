﻿using Infrastructure;
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

namespace Internet_Store.Windows.Main
{
    /// <summary>
    /// Логика взаимодействия для WindowGoods.xaml
    /// </summary>
    public partial class WindowGoods : Window
    {
        private GoodRepository goods;
        private TypeRepository types;
        public WindowGoods()
        {
            InitializeComponent();

            goods = new GoodRepository();
            types = new TypeRepository();

            Goods.ItemsSource = goods.GetList(); 
            Types.ItemsSource = types.GetList();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            GoodModel good = Goods.SelectedItem as GoodModel;

            if(good == null)
            {
                MessageBox.Show("Вы не выбрали товар", "Store", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            else
            {
                CurrentGood.Good = GoodMapper.Map(good);

                WindowGoodView windowGoodView = new WindowGoodView();
                this.Close();
                windowGoodView.ShowDialog();
            }
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Types.SelectedIndex = -1;
        }

        private void Types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Infrastructure.Type type = Types.SelectedItem as Infrastructure.Type;

            if (type == null)
            {
                Goods.ItemsSource = goods.GetList();
                return;
            }

            Goods.ItemsSource = goods.GetList().Where(i => i.TypeID == type.ID);
        }
    }
}
