using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            Grid_Language.Visibility = Visibility.Hidden;

        }


        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1000)
            {
                Text1.FontSize = 75;
                Text2.FontSize = 40;
                Button1.Width = 380;
                Button2.Width = 380;
                Button3.Width = 380;
                Button1.Height = 75;
                Button2.Height = 75;
                Button3.Height = 75;
            }
            else
            {
                Text1.FontSize = 64;
                Text2.FontSize = 32;
                Button1.Width = 338;
                Button2.Width = 338;
                Button3.Width = 338;
                Button1.Height = 64;
                Button2.Height = 64;
                Button3.Height = 64;

            }


        }


        private void toCEIPage(object sender, MouseButtonEventArgs e)
        {
           NavigationService.Navigate(new Uri("pack://application:,,,/Pages/CEI.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void Exmpl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Cours.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToProgrammePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ProgrammePage.xaml", UriKind.Relative));
            
        }

        private void Button_Fr_En_Click(object sender, RoutedEventArgs e)
        {
            Grid_Language.Visibility= Visibility.Visible ;
        }

        private void Button_Fr_En_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid_Language.Visibility = Visibility.Hidden;
        }
    }
}
