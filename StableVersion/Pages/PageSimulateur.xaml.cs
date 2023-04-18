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
    /// Logique d'interaction pour PageSimulateur.xaml
    /// </summary>
    public partial class PageSimulateur : Page
    {
        public PageSimulateur()
        {
            InitializeComponent();
        }

        private void toCEIPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/CEI.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
