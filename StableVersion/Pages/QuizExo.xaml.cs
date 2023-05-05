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
using System.Windows.Resources;
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

            menu2.Visibility = Visibility.Hidden;
            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "MENU_ICON");
            menu.Margin = new Thickness(10, 20, 0, 0);
            menu.HorizontalAlignment = HorizontalAlignment.Center;
            //navBar.Opacity = 0;

        }

        private void menu_Cheked(object sender, RoutedEventArgs e)
        {
            menu2.Visibility = Visibility.Visible;
            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "MENU_ICON");

            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            menu.Margin = new Thickness(10, 20, 0, 0);
            //menu.HorizontalAlignment = HorizontalAlignment.Right;
            //navBar.Opacity = 1;

        }

        private void Exit_Quiz(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Quiz.xaml", UriKind.RelativeOrAbsolute));
        }


        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Quiz_White.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White.Foreground = Brushes.Black;
        }
        private void Btn_Click2(object sender, RoutedEventArgs e)
        {
            Quiz_White2.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White2.Foreground = Brushes.Black;
        }
        private void Btn_Click3(object sender, RoutedEventArgs e)
        {
            Quiz_White3.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White3.Foreground = Brushes.Black;
        }
        private void Btn_Click4(object sender, RoutedEventArgs e)
        {
            Quiz_White4.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White4.Foreground = Brushes.Black;
        }
        private void Btn_Click5(object sender, RoutedEventArgs e)
        {
            Quiz_White5.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White5.Foreground = Brushes.Black;
        }
        private void Btn_Click6(object sender, RoutedEventArgs e)
        {
            Quiz_White6.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White6.Foreground = Brushes.Black;
        }
        private void Btn_Click7(object sender, RoutedEventArgs e)
        {
            Quiz_White7.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White7.Foreground = Brushes.Black;
        }
        private void Btn_Click8(object sender, RoutedEventArgs e)
        {
            Quiz_White8.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White8.Foreground = Brushes.Black;
        }
        private void Btn_Click9(object sender, RoutedEventArgs e)
        {
            Quiz_White9.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White9.Foreground = Brushes.Black;
        }
        private void Btn_Click10(object sender, RoutedEventArgs e)
        {
            Quiz_White10.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White10.Foreground = Brushes.Black;
        }
        private void Btn_Click11(object sender, RoutedEventArgs e)
        {
            Quiz_White11.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White11.Foreground = Brushes.Black;
        }
        private void Btn_Click12(object sender, RoutedEventArgs e)
        {
            Quiz_White12.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White12.Foreground = Brushes.Black;
        }
        private void Btn_Click13(object sender, RoutedEventArgs e)
        {
            Quiz_White13.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White13.Foreground = Brushes.Black;
        }
        private void Btn_Click14(object sender, RoutedEventArgs e)
        {
            Quiz_White14.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White14.Foreground = Brushes.Black;
        }
        private void Btn_Click15(object sender, RoutedEventArgs e)
        {
            Quiz_White15.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White15.Foreground = Brushes.Black;
        }
        private void Btn_Click16(object sender, RoutedEventArgs e)
        {
            Quiz_White16.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White16.Foreground = Brushes.Black;
        }
        private void Btn_Click17(object sender, RoutedEventArgs e)
        {
            Quiz_White17.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White17.Foreground = Brushes.Black;
        }
        private void Btn_Click18(object sender, RoutedEventArgs e)
        {
            Quiz_White18.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White18.Foreground = Brushes.Black;
        }
        private void Btn_Click19(object sender, RoutedEventArgs e)
        {
            Quiz_White19.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White19.Foreground = Brushes.Black;
        }
        private void Btn_Click20(object sender, RoutedEventArgs e)
        {
            Quiz_White20.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White20.Foreground = Brushes.Black;
        }
        private void Btn_Click21(object sender, RoutedEventArgs e)
        {
            Quiz_White21.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White21.Foreground = Brushes.Black;
        }
        private void Btn_Click22(object sender, RoutedEventArgs e)
        {
            Quiz_White22.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White22.Foreground = Brushes.Black;
        }
        private void Btn_Click23(object sender, RoutedEventArgs e)
        {
            Quiz_White23.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White23.Foreground = Brushes.Black;
        }
        private void Btn_Click24(object sender, RoutedEventArgs e)
        {
            Quiz_White24.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White24.Foreground = Brushes.Black;
        }
        private void Btn_Click25(object sender, RoutedEventArgs e)
        {
            Quiz_White25.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White25.Foreground = Brushes.Black;
        }
        private void Btn_Click26(object sender, RoutedEventArgs e)
        {
            Quiz_White26.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White26.Foreground = Brushes.Black;
        }
        private void Btn_Click27(object sender, RoutedEventArgs e)
        {
            Quiz_White27.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White27.Foreground = Brushes.Black;
        }
        private void Btn_Click28(object sender, RoutedEventArgs e)
        {
            Quiz_White28.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White28.Foreground = Brushes.Black;
        }
        private void Btn_Click29(object sender, RoutedEventArgs e)
        {
            Quiz_White29.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White29.Foreground = Brushes.Black;
        }
        private void Btn_Click30(object sender, RoutedEventArgs e)
        {
            Quiz_White30.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White30.Foreground = Brushes.Black;
        }
        private void Btn_Click31(object sender, RoutedEventArgs e)
        {
            Quiz_White31.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White31.Foreground = Brushes.Black;
        }
        private void Btn_Click32(object sender, RoutedEventArgs e)
        {
            Quiz_White32.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White32.Foreground = Brushes.Black;
        }
        private void Btn_Click33(object sender, RoutedEventArgs e)
        {
            Quiz_White33.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White33.Foreground = Brushes.Black;
        }
        private void Btn_Click34(object sender, RoutedEventArgs e)
        {
            Quiz_White34.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White34.Foreground = Brushes.Black;
        }
        private void Btn_Click35(object sender, RoutedEventArgs e)
        {
            Quiz_White35.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White35.Foreground = Brushes.Black;
        }
        private void Btn_Click36(object sender, RoutedEventArgs e)
        {
            Quiz_White36.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White36.Foreground = Brushes.Black;
        }
        private void Btn_Click37(object sender, RoutedEventArgs e)
        {
            Quiz_White37.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White37.Foreground = Brushes.Black;
        }
        private void Btn_Click38(object sender, RoutedEventArgs e)
        {
            Quiz_White38.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White38.Foreground = Brushes.Black;
        }
        private void Btn_Click39(object sender, RoutedEventArgs e)
        {
            Quiz_White39.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White39.Foreground = Brushes.Black;
        }
        private void Btn_Click40(object sender, RoutedEventArgs e)
        {
            Quiz_White40.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White40.Foreground = Brushes.Black;
        }
        private void Btn_Click41(object sender, RoutedEventArgs e)
        {
            Quiz_White41.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White41.Foreground = Brushes.Black;
        }
        private void Btn_Click42(object sender, RoutedEventArgs e)
        {
            Quiz_White42.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White42.Foreground = Brushes.Black;
        }
        private void Btn_Click43(object sender, RoutedEventArgs e)
        {
            Quiz_White43.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White43.Foreground = Brushes.Black;
        }
        private void Btn_Click44(object sender, RoutedEventArgs e)
        {
            Quiz_White44.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White44.Foreground = Brushes.Black;
        }
        private void Btn_Click45(object sender, RoutedEventArgs e)
        {
            Quiz_White45.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White45.Foreground = Brushes.Black;
        }
        private void Btn_Click46(object sender, RoutedEventArgs e)
        {
            Quiz_White46.Source = new BitmapImage(new Uri("/Pages/images/qst1.png", UriKind.Relative));
            Text_White46.Foreground = Brushes.Black;
        }



        private void toQuiz1(object sender, MouseButtonEventArgs e)
        {
            //_PageContent.IsHitTestVisible = true;
            //_PageContent.Effect = null;
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };

            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz2(object sender, MouseButtonEventArgs e)
        {
            //_PageContent.IsHitTestVisible = true;
            //_PageContent.Effect = null;
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz3(object sender, MouseButtonEventArgs e)
        {
            //_PageContent.IsHitTestVisible = true;
            //_PageContent.Effect = null;
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz4(object sender, MouseButtonEventArgs e)
        {
            //_PageContent.IsHitTestVisible = true;
            //_PageContent.Effect = null;
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz4.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz5(object sender, MouseButtonEventArgs e)
        {
            //_PageContent.IsHitTestVisible = true;
            //_PageContent.Effect = null;
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz5.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz6(object sender, MouseButtonEventArgs e)
        {
            //_PageContent.IsHitTestVisible = true;
            //_PageContent.Effect = null;
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz6.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz7(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz7.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz8(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz8.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz9(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz9.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz10(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz10.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz11(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz11.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz12(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz12.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz13(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz13.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz14(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz14.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz15(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz15.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz16(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz16.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz17(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz17.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz18(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz18.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz19(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz19.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz20(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz10.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz21(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz21.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz22(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz22.xaml", UriKind.RelativeOrAbsolute));
        }

        private void toQuiz23(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz23.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz24(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz24.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz25(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz25.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz26(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz26.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz27(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz27.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz28(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz28.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz29(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz29.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz30(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz30.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz31(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz31.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz32(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz32.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz33(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz33.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz34(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz34.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz35(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz35.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz36(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz36.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz37(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz37.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz38(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz38.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz39(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz39.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz40(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz40.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz41(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz41.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz42(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz42.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz43(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz43.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz44(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz44.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz45(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz25.xaml", UriKind.RelativeOrAbsolute));
        }
        private void toQuiz46(object sender, MouseButtonEventArgs e)
        {
            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz46.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
