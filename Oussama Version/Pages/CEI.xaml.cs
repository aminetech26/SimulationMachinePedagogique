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
    /// Interaction logic for CEI.xaml
    /// </summary>
    public partial class CEI : Page
    {
        public CEI()
        {
            InitializeComponent();
            
            
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1000)
            {
                Button1.Margin = new Thickness(25);
                Button2.Margin = new Thickness(25);
                Button3.Margin = new Thickness(25);
                Button4.Margin = new Thickness(25);
                Button5.Margin = new Thickness(25);
                Button6.Margin = new Thickness(25);

                Column1.Width = new GridLength(300);
                Column2.Width = new GridLength(300);
                Column3.Width = new GridLength(300);

                Row1.Height = new GridLength(300);
                Row2.Height = new GridLength(300);

            }
            else
            {
                Button1.Margin = new Thickness(5);
                Button2.Margin = new Thickness(5);
                Button3.Margin = new Thickness(5);
                Button4.Margin = new Thickness(5);
                Button5.Margin = new Thickness(5);
                Button6.Margin = new Thickness(5);

                Column1.Width = new GridLength(225);
                Column2.Width = new GridLength(225);
                Column3.Width = new GridLength(225);

                Row1.Height = new GridLength(225);
                Row2.Height = new GridLength(225);

            }
           

        }


        private void GoToArith(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/InsArith.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
