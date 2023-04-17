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
    /// Interaction logic for QuizExo.xaml
    /// </summary>
    public partial class QuizExo : Page
    {
        public QuizExo()
        {
            InitializeComponent();
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz.xaml", UriKind.RelativeOrAbsolute));
            menu.Cursor = Cursors.Hand;
            //navBar.Opacity = 0;
        }

        private void menu_Uncheked(object sender, RoutedEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;

            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "MENU_ICON");
            menu.Margin = new Thickness(0, 20, 0, 0);
            menu.HorizontalAlignment = HorizontalAlignment.Center;
            //navBar.Opacity = 0;

        }

        private void menu_Cheked(object sender, RoutedEventArgs e)
        {

            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "EXIT_ICON");
            menu.Margin = new Thickness(0, 12, 16, 0);
            menu.HorizontalAlignment = HorizontalAlignment.Right;
            //navBar.Opacity = 1;

        }


        private void toQuiz1(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz2(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz3(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz4(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz4.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz5(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz5.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz6(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz6.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz7(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz7.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz8(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz8.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz9(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz9.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz10(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz10.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz11(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz11.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz12(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz12.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz13(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz13.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz14(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz14.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz15(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz15.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz16(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz16.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz17(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz17.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz18(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz18.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz19(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz19.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz20(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz10.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz21(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz21.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz22(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz22.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz23(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz23.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz24(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz24.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz25(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz25.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz26(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz26.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz27(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz27.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz28(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz28.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz29(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz29.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz30(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz30.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz31(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz31.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz32(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz32.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz33(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz33.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz34(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz34.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz35(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz35.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz36(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz36.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz37(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz37.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz38(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz38.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz39(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz39.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz40(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz40.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz41(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz41.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz42(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz42.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz43(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz43.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz44(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz44.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz45(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz25.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz46(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz46.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
