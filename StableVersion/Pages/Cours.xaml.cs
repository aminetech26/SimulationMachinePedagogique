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
using static System.Net.Mime.MediaTypeNames;

namespace projet.Pages
{
    /// <summary>
    /// Interaction logic for Cours.xaml
    /// </summary>
    public partial class Cours : Page
    {
        public Cours()
        {
            InitializeComponent();
        }

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


        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1000)
            {
                Text1.FontSize = 25;
                Button.Width = 30 ;
                Button.Margin = new Thickness(-100, 0, 100, 0);
                exemples.Margin = new Thickness(0, 50, 0, 0);
                Button1.Height = 60;
                Button1.Width = 620;
                Button2.Height = 60;
                Button2.Width = 620;
                Exemple1.Height = 60;
                Exemple1.Width = 620;
                Exemple2.Height = 60;
                Exemple2.Width = 620;
                Exemple3.Height = 60;
                Exemple3.Width = 620;
            }
            else
            {
                Text1.FontSize = 20;
                Button.Width = 27 ;
                Button.Margin = new Thickness(30, 0, 20, 0);
                exemples.Margin = new Thickness(0, 10, 0, 0);
                Button1.Height = 50;
                Button1.Width = 520;
                Button2.Height = 50;
                Button2.Width = 520;
                Exemple1.Height = 50;
                Exemple1.Width = 520;
                Exemple2.Height = 50;
                Exemple2.Width = 520;
                Exemple3.Height = 50;
                Exemple3.Width = 520;

            }

        }


            private void GoBackHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Exemple1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Exemple1"; // Default file name
            dlg.DefaultExt = ".archimind"; // Default file extension
            dlg.Filter = "Archimind files (.archimind)|*.archimind"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;//return the full path not only the name as it seems.
                ProgrammePage firstPage = new ProgrammePage(filePath);
                nchlhtmchi();
                Frame frame = (Frame)contextofwindow.FindName("window");
                frame.NavigationService.Navigate(firstPage);
                //this.NavigationService.Navigate(firstPage);
            }

        }

        private void Exemple2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Exemple2"; // Default file name
            dlg.DefaultExt = ".archimind"; // Default file extension
            dlg.Filter = "Archimind files (.archimind)|*.archimind"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;//return the full path not only the name as it seems.
                ProgrammePage firstPage = new ProgrammePage(filePath);
                nchlhtmchi();
                Frame frame = (Frame)contextofwindow.FindName("window");
                frame.NavigationService.Navigate(firstPage);
                //this.NavigationService.Navigate(firstPage);
            }

        }

        private void Exemple3_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Exemple3"; // Default file name
            dlg.DefaultExt = ".archimind"; // Default file extension
            dlg.Filter = "Archimind files (.archimind)|*.archimind"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;//return the full path not only the name as it seems.
                ProgrammePage firstPage = new ProgrammePage(filePath);
                nchlhtmchi();
                Frame frame = (Frame)contextofwindow.FindName("window");
                frame.NavigationService.Navigate(firstPage);
                //this.NavigationService.Navigate(firstPage);
            }

        }
    }
}
