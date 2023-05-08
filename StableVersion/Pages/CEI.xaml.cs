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
using System.Windows.Media.Effects;
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
                
                Column_button.Width = new GridLength(100);
                Button.Margin = new Thickness(30, 20, 0, 0);
                Button1.Margin = new Thickness(30);
                Button2.Margin = new Thickness(30);
                Button3.Margin = new Thickness(30);
                Button4.Margin = new Thickness(30);
                Button5.Margin = new Thickness(30);
                Button6.Margin = new Thickness(30);
                
                Column1.Width = new GridLength(300);
                Column2.Width = new GridLength(300);
                Column3.Width = new GridLength(300);

                Row1.Height = new GridLength(300);
                Row2.Height = new GridLength(300);

            }
            else
            {

                Column_button.Width = new GridLength(75) ;
                Button.Margin = new Thickness(25,20,0,0);
                Button1.Margin = new Thickness(15);
                Button2.Margin = new Thickness(15);
                Button3.Margin = new Thickness(15);
                Button4.Margin = new Thickness(15);
                Button5.Margin = new Thickness(15);
                Button6.Margin = new Thickness(15);

                Column1.Width = new GridLength(225);
                Column2.Width = new GridLength(225);
                Column3.Width = new GridLength(225);

                Row1.Height = new GridLength(225);
                Row2.Height = new GridLength(225);

            }

        }


        private void GoToArith(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToPage3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageSimulateur.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToEntreeSortie(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page_EntreeSortie.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToDecalage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page_Decalage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToTransfert(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Transfert.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GoToBranchement(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Branchement.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
