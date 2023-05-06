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
    /// Logique d'interaction pour Creerprogramme.xaml
    /// </summary>
    public partial class Creerprogramme : Page
    {
        public Creerprogramme()
        {
            InitializeComponent();
        }
        private void GoBackHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }
        private void Hexadecimal(object sender, RoutedEventArgs e)
        {
           BorderHexadecimal.Visibility = Visibility.Visible;
            BorderMnemonique.Visibility = Visibility.Collapsed;
        }

        private void Mnemonique(object sender, RoutedEventArgs e)
        {
            BorderHexadecimal.Visibility = Visibility.Collapsed;
            BorderMnemonique.Visibility = Visibility.Visible;
        }


    }
}
