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
        public PageQuiz()
        {
            InitializeComponent();
        }

        private void GoListQuiz(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
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
                Button2.Height = 68;
                Button2.Width = 168;
                Button3.Height = 68;
                Button3.Width = 168;
                Image1.Height = 50;
                Image1.Width= 50;
                Image2.Height = 40;
                Image2.Width = 40;
                Text4.FontSize = 28;
                Text5.FontSize = 28;
                
            }
            else
            {
                Text1.FontSize = 32;
                Text2.FontSize = 22;
                Text1.FontSize = 23;
                Combo.Height = 40;
                Combo.Width = 400;
                Button1.Height = 43;
                Button1.Width = 125;
                Button2.Height = 54;
                Button2.Width = 155;
                Button3.Height = 55;
                Button3.Width = 155;
                Image1.Height = 40;
                Image1.Width = 40;
                Image2.Height = 30;
                Image2.Width = 30;
                Text4.FontSize = 21;
                Text5.FontSize = 21;

            }

        }

    }
}
