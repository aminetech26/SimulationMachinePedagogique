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
        private void GoToCreerProgramme(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Creerprogramme.xaml", UriKind.RelativeOrAbsolute));
        }






        private void Fermer(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1200)
            {
                Text1.FontSize = 32;
                Button1.Height = 64;
                Button1.Width = 650;
                Button2.Height = 64;
                Button2.Width = 650;
                Button3.Height = 64;
                Button3.Width = 650;
                Button4.Height = 64;
                Button4.Width = 650;
                Button5.Height = 64;
                Button5.Width = 650;
            }
            else
            {
                Text1.FontSize = 22;
                Button1.Height = 54;
                Button1.Width = 520;
                Button2.Height = 54;
                Button2.Width = 520;
                Button3.Height = 54;
                Button3.Width = 520;
                Button4.Height = 54;
                Button4.Width = 520;
                Button5.Height = 54;
                Button5.Width = 520;

            }

        }

        private void BackCEI(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/CEI.xaml", UriKind.RelativeOrAbsolute));

        }

        private void BackHomeFromExo(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page1.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
