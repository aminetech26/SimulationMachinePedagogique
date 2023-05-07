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
    /// Logique d'interaction pour ExerciceType1.xaml
    /// </summary>
    public partial class ExerciceType1 : Page
    {
        public ExerciceType1()
        {
            InitializeComponent();
        }

        private void Suivant(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType2.xaml", UriKind.RelativeOrAbsolute));
        }
        
        private void Solut(object sender, RoutedEventArgs e)
        {
            BorderSolution.Visibility = Visibility.Visible;
            BorderEnonce.Visibility = Visibility.Collapsed;
            Enonce.Visibility = Visibility.Collapsed;
            AfficherLaSolution.Visibility = Visibility.Collapsed;
            Solution.Visibility = Visibility.Visible;
            RevenirVersEnonce.Visibility = Visibility.Visible;
        }

        private void Enon(object sender, RoutedEventArgs e)
        {
            BorderSolution.Visibility = Visibility.Collapsed;
            BorderEnonce.Visibility = Visibility.Visible;
            Enonce.Visibility = Visibility.Visible;
            AfficherLaSolution.Visibility = Visibility.Visible;
            Solution.Visibility = Visibility.Collapsed;
            RevenirVersEnonce.Visibility = Visibility.Collapsed;
        }
    }
}
