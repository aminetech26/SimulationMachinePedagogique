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

        

    }
}
