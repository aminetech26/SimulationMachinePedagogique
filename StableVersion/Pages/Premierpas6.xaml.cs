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

namespace projet.Pages
{
    /// <summary>
    /// Logique d'interaction pour Premierpas9.xaml
    /// </summary>
    public partial class Premierpas6 : Page
    {
        public Premierpas6()
        {
            InitializeComponent();
        }
        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 800)
            {
                stackpanel.Width = 950;
                stackpanel.Height = 580;
                grid.Width = 950;
                grid.Height = 580;
                text1.FontSize = 18;
                text1.Width = 400;
                text2.FontSize = 16;
                text2.Width = 600;
                grid2.Width = 620;
                image1.Width = 750;
                image1.Height = 250;
                image2.Width = 30;
                image2.Height = 40;
                image3.Width = 30;
                image3.Height = 40;
                btn1.Width = 100;

            }
            else
            {
                stackpanel.Width = 675;
                stackpanel.Height = 525;
                grid.Width = 675;
                grid.Height = 525;
                text1.FontSize = 14;
                text1.Width = 300;
                text2.FontSize = 16;
                text2.Width = 510;
                grid2.Width = 520;
                image1.Width = 375;
                image1.Height = 230;
                image2.Width = 17;
                image2.Height = 31;
                image3.Width = 17;
                image3.Height = 31;
                btn1.Width = 60;

            }
        }
        private void BackToPremierpas5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Premierpas5.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToPremierpas7(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Premierpas7.xaml", UriKind.RelativeOrAbsolute));
        }
        private void Go_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}