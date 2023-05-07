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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projet.Pages
{
    /// <summary>
    /// Logique d'interaction pour Quizs_Exercices.xaml
    /// </summary>
    public partial class Quizs_Exercices : Page
    {
        private static MainWindow contextofwindow;

        public static void setcontex(MainWindow contex)
        {
            contextofwindow = contex;
        }

        public static void nchlhtmchi()
        {
            Frame frame = (Frame)contextofwindow.FindName("window");
            frame.Content = null;
        }

        public Quizs_Exercices()
        {
            InitializeComponent();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 3);
            String[] tab1 = {
                                " ''Le test ultime de la connaissance est l'expérience ''" ,
                                "''La meilleure facon d'apprendre et de tester ''",
                                "''L'apprentissage ne se termine jamais''",
                               };

            String[] tab2 = { " - John Dewey -", "- Thomas Edison -", "- Nancy Duarte -" };

            DisplayDataTextBlock.Text = tab1[randomNumber];
            DisplayData1TextBlock1.Text = tab2[randomNumber];

        }
        private void GoToExerciceTypeMenu(object sender, RoutedEventArgs e)
        {
            nchlhtmchi();
            Frame frame = (Frame)contextofwindow.FindName("window");
            frame.NavigationService.Navigate(new Uri("/Pages/ExerciceTypeMenu.xaml", UriKind.Relative));

            //NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceTypeMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toExoPage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Exercices.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToQuiz(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("pack://application:,,,/Pages/QuizExo.xaml", UriKind.RelativeOrAbsolute));   

            nchlhtmchi();
            Frame frame = (Frame)contextofwindow.FindName("window");
            frame.NavigationService.Navigate(new Uri("/Pages/QuizExo.xaml", UriKind.Relative));
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1000)
            {
                Text1.FontSize = 100;
                Image1.Width = 150;
                Image1.Height = 160;
                DisplayData1TextBlock1.FontSize = 30;
                DisplayDataTextBlock.FontSize = 30;

                Button1.Width = 230;
                Button1.Height = 240;
                Button2.Height = 240;
                Button2.Width = 230;
            }
            else
            {
                Text1.FontSize = 80;
                Image1.Width = 120;
                Image1.Height = 143;
                DisplayDataTextBlock.FontSize = 20;
                DisplayData1TextBlock1.FontSize = 20;
                Button1.Width = 207;
                Button1.Height = 220;
                Button2.Height = 207;
                Button2.Width = 220;

            }

        }


    }
}
