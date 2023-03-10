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
    /// Interaction logic for PageQuiz2.xaml
    /// </summary>
    public partial class PageQuiz2 : Page
    {
        public PageQuiz2()
        {
            InitializeComponent();
        }

        private void Precedent(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageQuiz.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
