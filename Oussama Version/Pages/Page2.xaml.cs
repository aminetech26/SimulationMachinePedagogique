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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace projet.Pages
{
    /// <summary>
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        { 
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/CEI.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 800)
            {
                Text1.FontSize = 32 ;
                Instruction.Width = 150 ;
                Instruction.Height = 70 ;
                Format.Width = 150 ;
                Format.Height = 70 ;
                Reg.Width = 150;
                Reg.Height = 70;
                Dep.Width = 150;
                Dep.Height = 70;
                Destinataire.Width = 150;
                Destinataire.Height = 70;
                Source.Width = 150;
                Source.Height = 70;
            }
            else
            {
                Text1.FontSize = 27 ;
                Instruction.Width = 100;
                Instruction.Height = 70;
                Format.Width = 100;
                Format.Height = 70;
                Reg.Width = 100;
                Reg.Height = 70;
                Dep.Width = 100;
                Dep.Height = 70;
                Destinataire.Width = 100;
                Destinataire.Height = 70;
                Source.Width = 100;
                Source.Height = 70;
            }
        }
    }
}
