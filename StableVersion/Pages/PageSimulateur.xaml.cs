using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 800)
            {
                text.FontSize = 25;
                txt1.FontSize = 18;
                txt2.FontSize = 18;
                img1.Width = 200;
                img1.Height = 140;
                img2.Width = 200;
                img2.Height = 140;
            }
            else
            {
                text.FontSize = 20;
                txt1.FontSize = 15;
                txt2.FontSize = 15;
                img1.Width = 150;
                img1.Height = 120;
                img2.Width = 150;
                img2.Height = 120;

            }
        }

    }
}
