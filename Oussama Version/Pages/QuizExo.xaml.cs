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
            navBar.Opacity = 0;
        }

        private void menu_Uncheked(object sender, RoutedEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;

            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "MENU_ICON");
            menu.Margin = new Thickness(0, 20, 0, 0);
            menu.HorizontalAlignment = HorizontalAlignment.Center;
            navBar.Opacity = 0;

        }

        private void menu_Cheked(object sender, RoutedEventArgs e)
        {

            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "EXIT_ICON");
            menu.Margin = new Thickness(0, 12, 16, 0);
            menu.HorizontalAlignment = HorizontalAlignment.Right;
            navBar.Opacity = 1;

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

    }
}
