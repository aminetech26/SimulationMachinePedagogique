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
    /// Logique d'interaction pour ExerciceTypeMenu.xaml
    /// </summary>
    public partial class ExerciceTypeMenu : Page
    {
        public ExerciceTypeMenu()
        {
            InitializeComponent();
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType1.xaml", UriKind.RelativeOrAbsolute));
            menu.Cursor = Cursors.Hand;
            //btn1.MouseEnter += MonBouton_MouseEnter;
            //btn2.MouseEnter += MonBouton_MouseEnter;
            //btn3.MouseEnter += MonBouton_MouseEnter;
            //btn4.MouseEnter += MonBouton_MouseEnter;
            //btn5.MouseEnter += MonBouton_MouseEnter;
            //btn6.MouseEnter += MonBouton_MouseEnter;

        }

        private void menu_Uncheked(object sender, RoutedEventArgs e)
        {
            _PageContent.IsHitTestVisible = true;
            _PageContent.Effect = null;

            scrll.Visibility=Visibility.Collapsed;
            btn1.Visibility= Visibility.Collapsed;
            btn2.Visibility = Visibility.Collapsed;
            btn3.Visibility = Visibility.Collapsed;
            btn4.Visibility = Visibility.Collapsed;
            btn6.Visibility = Visibility.Collapsed;
            btn5.Visibility = Visibility.Collapsed;


            menu.Visibility = Visibility.Visible;
            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "MENU_ICON");
            menu.Margin = new Thickness(12, 20, 0, 0);
            menu.HorizontalAlignment = HorizontalAlignment.Center;

        }

        private void menu_Cheked(object sender, RoutedEventArgs e)
        {
            scrll.Visibility = Visibility.Visible;
            btn1.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;
            btn3.Visibility = Visibility.Visible;
            btn4.Visibility = Visibility.Visible;
            btn6.Visibility = Visibility.Visible;
            btn5.Visibility = Visibility.Visible;

            _PageContent.IsHitTestVisible = false;
            _PageContent.Effect = new BlurEffect() { Radius = 30, KernelType = KernelType.Gaussian };

            menu2.Visibility = Visibility.Visible;
            menuIcon.SetResourceReference(System.Windows.Shapes.Path.DataProperty, "MENU_ICON");
            menu.Margin = new Thickness(12, 20, 0, 0);

        }

        private void Exit_Quiz(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Quiz.xaml", UriKind.RelativeOrAbsolute));
        }



        private void MonBouton_Click(object sender, RoutedEventArgs e)
        {
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType1.xaml", UriKind.RelativeOrAbsolute));
            txt1.Foreground = Brushes.Black;
            img1.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/pencil1.png", UriKind.RelativeOrAbsolute));
            txt2.Foreground = Brushes.White;
            img2.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt3.Foreground = Brushes.White;
            img3.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt4.Foreground = Brushes.White;
            img4.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt5.Foreground = Brushes.White;
            img5.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt6.Foreground = Brushes.White;
            img6.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
        }

        private void MonBouton2_Click(object sender, RoutedEventArgs e)
        {
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType2.xaml", UriKind.RelativeOrAbsolute));
            txt1.Foreground = Brushes.White;
            img1.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt2.Foreground = Brushes.Black;
            img2.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/pencil1.png", UriKind.RelativeOrAbsolute));
            txt3.Foreground = Brushes.White;
            img3.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt4.Foreground = Brushes.White;
            img4.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt5.Foreground = Brushes.White;
            img5.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt6.Foreground = Brushes.White;
            img6.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
        }

        private void MonBouton3_Click(object sender, RoutedEventArgs e)
        {
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType3.xaml", UriKind.RelativeOrAbsolute));
            txt1.Foreground = Brushes.White;
            img1.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt2.Foreground = Brushes.White;
            img2.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt3.Foreground = Brushes.Black;
            img3.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/pencil1.png", UriKind.RelativeOrAbsolute));
            txt4.Foreground = Brushes.White;
            img4.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt5.Foreground = Brushes.White;
            img5.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt6.Foreground = Brushes.White;
            img6.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
        }

        private void MonBouton4_Click(object sender, RoutedEventArgs e)
        {
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType4.xaml", UriKind.RelativeOrAbsolute));
            txt1.Foreground = Brushes.White;
            img1.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt2.Foreground = Brushes.White;
            img2.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt3.Foreground = Brushes.White;
            img3.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt4.Foreground = Brushes.Black;
            img4.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/pencil1.png", UriKind.RelativeOrAbsolute));
            txt5.Foreground = Brushes.White;
            img5.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt6.Foreground = Brushes.White;
            img6.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
        }

        private void MonBouton5_Click(object sender, RoutedEventArgs e)
        {
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType5.xaml", UriKind.RelativeOrAbsolute));
            txt1.Foreground = Brushes.White;
            img1.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt2.Foreground = Brushes.White;
            img2.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt3.Foreground = Brushes.White;
            img3.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt4.Foreground = Brushes.White;
            img4.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt5.Foreground = Brushes.Black;
            img5.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/pencil1.png", UriKind.RelativeOrAbsolute));
            txt6.Foreground = Brushes.White;
            img6.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
        }

        private void MonBouton6_Click(object sender, RoutedEventArgs e)
        {
            _PageContent.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/ExerciceType6.xaml", UriKind.RelativeOrAbsolute));
            txt1.Foreground = Brushes.White;
            img1.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt2.Foreground = Brushes.White;
            img2.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt3.Foreground = Brushes.White;
            img3.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt4.Foreground = Brushes.White;
            img4.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt5.Foreground = Brushes.White;
            img5.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/qst.png", UriKind.RelativeOrAbsolute));
            txt6.Foreground = Brushes.Black;
            img6.Source = new BitmapImage(new Uri("pack://application:,,,/Pages/images/pencil1.png", UriKind.RelativeOrAbsolute));
        }
    }
}
