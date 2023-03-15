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

    }
}
