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
    /// Interaction logic for Exercices.xaml
    /// </summary>
    public partial class Exercices : Page
    {
        public Exercices()
        {
            InitializeComponent();
        }

        private void BackQuiz(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void BackHomeFromExo(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
            this.NavigationService.GoBack();
        }

        private void GoToQuiz1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/QuizExo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BackQuiz(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Fermer(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

    
    }
}
