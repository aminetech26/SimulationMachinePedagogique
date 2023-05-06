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
                Button3.Height = 60;
                Button3.Width = 620;
                Button4.Height = 60;
                Button4.Width = 620;
                Button5.Height = 60;
                Button5.Width = 620;
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
                Button3.Height = 50;
                Button3.Width = 520;
                Button4.Height = 50;
                Button4.Width = 520;
                Button5.Height = 50;
                Button5.Width = 520;

            }

        }


            private void GoBackHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
