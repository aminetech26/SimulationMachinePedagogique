using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
using static System.Net.WebRequestMethods;

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

            WebSite_Button.PreviewMouseDown += OpenWebsite;

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
            Main.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OpenWebsite(object sender, MouseButtonEventArgs e)
        {
            string websiteUrl = "https://archimind.netlify.app/";

            // Prefix the URL with "http://" or "https://" to open it in a web browser
            if (!websiteUrl.StartsWith("http://") && !websiteUrl.StartsWith("https://"))
            {
                websiteUrl = "http://" + websiteUrl;
            }

            // Open the website in the default browser
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = websiteUrl,
                UseShellExecute = true
            });
        }

        private void toSimulateurPage(object sender, MouseButtonEventArgs e)
        {
            Main.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageSimulateur.xaml", UriKind.RelativeOrAbsolute));
        }
        
        private void toPremierpasPage(object sender, MouseButtonEventArgs e)
        {
            Main.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Premierpas5.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Fermer(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /*************************************************************************************/

    }
}
