using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
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

        public Page1()
        {
            InitializeComponent();
            Main.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
            Grid_Language.Visibility = Visibility.Hidden;
        }


        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Adjust the size of the frame to match the size of the window
            Main.Width = e.NewSize.Width - 228;
            Main.Height = e.NewSize.Height;
          
        }

        private void toQuizPage(object sender, MouseButtonEventArgs e)
        {
            //NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Quiz.xaml", UriKind.RelativeOrAbsolute));

            nchlhtmchi();
            Frame frame = (Frame)contextofwindow.FindName("window");
            frame.NavigationService.Navigate(new Uri("/Pages/Quiz.xaml", UriKind.Relative));
        }

        private void toHomePage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page1.xaml", UriKind.RelativeOrAbsolute));
        }
        
        private void toSimulateurPage(object sender, MouseButtonEventArgs e)
        {
            Main.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageSimulateur.xaml", UriKind.RelativeOrAbsolute));
        }
        
        private void toPremierpasPage(object sender, MouseButtonEventArgs e)
        {
            Main.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Premierpas.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Fermer(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /*************************************************************************************/

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

        private void Exmpl(object sender, RoutedEventArgs e)
        {

        }

        private void GoToProgrammePage(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Fr_En_Click(object sender, RoutedEventArgs e)
        {
            Grid_Language.Visibility = Visibility.Visible;
        }

        private void Button_Fr_En_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid_Language.Visibility = Visibility.Hidden;
        }


    }
}
