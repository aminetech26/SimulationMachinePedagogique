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
            if (e.NewSize.Width >= 1000)
            {
                text.FontSize = 23;
                text.Margin = new Thickness(100,90,100,0);
                txt1.FontSize = 17;
                txt2.FontSize = 17;
                img1.Height = 125;
                img2.Height = 125;
                Button1.Height = 45;
                Button1.Width = 220;
                Button2.Height = 45;
                Button2.Width = 220;
                Border.Height = 250;
                Border.Width = 800;
            }
            else
            {
                text.FontSize = 20;
                text.Margin = new Thickness(75, 50, 75, 0);
                txt1.FontSize = 15;
                txt2.FontSize = 15;
                img1.Height = 100;
                img2.Height = 100;
                Button1.Height = 40;
                Button1.Width = 200;
                Button2.Height = 40;
                Button2.Width = 200;
                Border.Height = 200 ;
                Border.Width = 650 ;


            }
        }

    }
}
