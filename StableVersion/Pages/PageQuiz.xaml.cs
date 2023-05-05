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
    /// Interaction logic for PageQuiz.xaml
    /// </summary>
    public partial class PageQuiz : Page
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

        public PageQuiz()
        {
            InitializeComponent();
            Text4.Visibility = Visibility.Collapsed;
            Text5.Visibility = Visibility.Collapsed;
            Image1.Visibility = Visibility.Collapsed;
            Image2.Visibility = Visibility.Collapsed;
            myGridExpl.Visibility = Visibility.Collapsed;
        }

        private void GoListQuiz(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Quiz.xaml", UriKind.RelativeOrAbsolute));

            nchlhtmchi();
            Frame frame = (Frame)contextofwindow.FindName("window");
            frame.NavigationService.Navigate(new Uri("/Pages/Page1.xaml", UriKind.Relative));

        }


        private void Suivant(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz2.xaml", UriKind.RelativeOrAbsolute));
        }


        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1200)
            {
                Text1.FontSize = 45;
                Text2.FontSize = 32;
                Text3.FontSize = 35;
                Combo.Height = 40;
                Combo.Width = 500;
                Button1.Height = 55;
                Button1.Width = 140;
                Button3.Height = 68;
                Button3.Width = 168;

            }
            else
            {
                Text1.FontSize = 32;
                Text2.FontSize = 22;
                Text3.FontSize = 23;
                Combo.Height = 40;
                Combo.Width = 400;
                Button1.Height = 43;
                Button1.Width = 125;
                Button3.Height = 55;
                Button3.Width = 155;

            }

        }

        private void Reponse1(object sender, RoutedEventArgs e)
        {
            ComboBoxItem? selectedItem = Combo.SelectedItem as ComboBoxItem;
            Uri imageUri = new Uri("pack://application:,,,/Pages/images/false.png");
            BitmapImage bitmap = new BitmapImage(imageUri);
           
            if (selectedItem != null)
            {
                myGridExpl.Visibility = Visibility.Visible;
                Text5.Visibility = Visibility.Visible;
                Image2.Visibility = Visibility.Visible;
                if (selectedItem.Content.ToString() == "Les deux premieres reponses")
                {
                    Text4.Visibility = Visibility.Visible;
                    Image1.Visibility = Visibility.Visible;
                }
                else
                {
                    Image1.Source = bitmap ;
                    Image1.Width = 30;
                    Image1.Height= 30;
                    Text4.Text = "";
                    Text4.Inlines.Add(new Run("Vous êtes proche de la bonne réponse, mais ce n'est pas tout à fait ça."));
                    Text4.Inlines.Add(new LineBreak());
                    Text4.Inlines.Add(new Run("Essayez encore !"));
                    Text4.Foreground = new BrushConverter().ConvertFromString("#FFB347") as Brush;
                    Text4.Visibility = Visibility.Visible;
                    Image1.Visibility = Visibility.Visible;
                    
                }

            }
            Combo.IsEnabled = false;
        }
    }
}
