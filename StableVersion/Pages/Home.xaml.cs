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
using System.Windows.Threading;

namespace projet.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home
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

        public Home()
        {
            InitializeComponent();
            Grid_Language.Visibility = Visibility.Hidden;

        }


        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1000)
            {
                Text1.FontSize = 65;
                Text2.FontSize = 30;
                Text2.Width = 600;
                Button1.Width = 375;
                Button2.Width = 375;
                Button3.Width = 375;
                Button1.Height = 65;
                Button2.Height = 65;
                Button3.Height = 65;
                text00.FontSize = 22;
                text01.FontSize = 22;
                text02.FontSize = 22;
                ADD.Width = 25;
                FOLDER.Width = 25;
                CPU.Width = 28;
                STP1.Width = 330;
                STP2.Width = 330;
                STP3.Width = 330;
            }
            else
            {
                Text1.FontSize = 56;
                Text2.Width = 500;
                Text2.FontSize = 24;
                Button1.Width = 300;
                Button2.Width = 300;
                Button3.Width = 300;
                Button1.Height = 50;
                Button2.Height = 50;
                Button3.Height = 50;
                text00.FontSize = 19;
                text01.FontSize = 19;
                text02.FontSize = 19;
                ADD.Width= 22;
                FOLDER.Width= 22;
                CPU.Width= 25;
                STP1.Width = 300;
                STP2.Width = 300;
                STP3.Width = 300;
            }


        }


        private void Exmpl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Cours.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToProgrammePage(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/ProgrammePage.xaml", UriKind.Relative));

            nchlhtmchi();
            Frame frame = (Frame)contextofwindow.FindName("window");
            frame.NavigationService.Navigate(new Uri("/ProgrammePage.xaml", UriKind.Relative));

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
