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
                Text1.FontSize = 30;
                Button1.Height = 64;
                Button1.Width = 650;
                Button2.Height = 64;
                Button2.Width = 650;
                Button3.Height = 64;
                Button3.Width = 650;
                Button4.Height = 64;
                Button4.Width = 650;
                Button5.Height = 64;
                Button5.Width = 650;
            }
            else
            {
                Text1.FontSize = 22;
                Button1.Height = 54;
                Button1.Width = 520;
                Button2.Height = 54;
                Button2.Width = 520;
                Button3.Height = 54;
                Button3.Width = 520;
                Button4.Height = 54;
                Button4.Width = 520;
                Button5.Height = 54;
                Button5.Width = 520;

            }

        }


            private void GoBackHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
