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

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }


        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 3);
            String[] tab1 = {   " ''Le vrai test n'est pas dans la connaissance,mais dans l'application''" ,
                                " ''Le test ultime de la connaissance est l'expérience ''" ,
                                "''La meilleure facon d'apprendre et de tester ''",
                                "''L'apprentissage ne se termine jamais''",
                                " ''Il n'est qu'un processus continu de remise en question et d'amélioration de soi''"};

            String[] tab2 = { "- Corrie ten Boom -", " - John Dewey -", "- Thomas Edison -", "- Nancy Duarte -", "- Nancy Duarte -" };
            
            DisplayDataTextBlock.Text = tab1[randomNumber];
            DisplayData1TextBlock.Text = tab2[randomNumber];

        }



        private void BackHame(object sender, MouseButtonEventArgs e)
        {
            
            this.NavigationService.GoBack();
            
        }

        private void toExoPage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Exercices.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BackCEI(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
            
        }

        private void GoToCours(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Cours.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuizPage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Quiz.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toHomePage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toCEIPage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/CEI.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Fermer(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
