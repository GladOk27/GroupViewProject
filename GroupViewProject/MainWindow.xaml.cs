﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupViewProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdListView();
        }

        void UpdListView()
        {
            Main main = new Main();

            lvViewGroup.ItemsSource = main.ReadGroup();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNameGroup.Text) && !String.IsNullOrWhiteSpace(tbNumberGroup.Text) && !String.IsNullOrWhiteSpace(tbCurator.Text))
                {
                    Group group = new Group()
                    {
                        NameGroup = tbNameGroup.Text,
                        NumberGroup = tbNumberGroup.Text,
                        CuratorGroup = tbCurator.Text
                    };

                    Main main = new Main();

                    main.AddGroup(group);
                    UpdListView();
                }
                else
                {
                    MessageBox.Show("Поле пустое");
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNumberGroup.Text))
                {
                    Group group = new Group()
                    {
                        idGroup = Convert.ToInt32(tbNumberGroup.Text)
                    };
                    Main main = new Main();
                    main.DelGroup(group);
                    UpdListView();
                    tbNameGroup.Clear();
                    tbCurator.Clear();
                    tbNumberGroup.Clear();
                    tbNumberGroup.Text = "";
                }
                else
                {
                    MessageBox.Show("Поле пустое");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNameGroup.Text) && !String.IsNullOrWhiteSpace(tbNumberGroup.Text) && !String.IsNullOrWhiteSpace(tbCurator.Text) && !String.IsNullOrWhiteSpace(tbNumberGroup.Text))
                {
                    Group group = new Group()
                    {
                        idGroup = Convert.ToInt32(tbNumberGroup.Text),
                        NameGroup = tbNameGroup.Text,
                        NumberGroup = tbNumberGroup.Text,
                        CuratorGroup = tbCurator.Text
                    };
                    Main main = new Main();
                    main.UpdGroup(group);
                    UpdListView();
                }
                else
                {
                    MessageBox.Show("Поля пустые");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dbViewGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Group group = new Group();
            group = lvViewGroup.SelectedItem as Group;
            if (group != null)
            {

              
                tbNameGroup.Text = group.NameGroup;
                tbNumberGroup.Text = group.NumberGroup;
                tbCurator.Text = group.CuratorGroup;
            }
        }
    }
}
