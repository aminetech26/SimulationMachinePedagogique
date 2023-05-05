using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;

namespace projet.Pages
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Page
    {
        public Quiz()
        {
            InitializeComponent();
            Main2.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Quizs_Exercices.xaml", UriKind.RelativeOrAbsolute));
        }


        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Adjust the size of the frame to match the size of the window
            Main2.Width = e.NewSize.Width - 228;
            Main2.Height = e.NewSize.Height;

        }


        /****************************** MENU *******************************/

        private void toQuizPage(object sender, MouseButtonEventArgs e)
        {
            Main2.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Quizs_Exercices.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toHomePage(object sender, MouseButtonEventArgs e)
        {
            Main2.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toSimulateurPage(object sender, MouseButtonEventArgs e)
        {
            Main2.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageSimulateur.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toPremierpasPage(object sender, MouseButtonEventArgs e)
        {
            Main2.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Premierpas.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Fermer(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
