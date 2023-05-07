using ArchiMind;
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
    /// Logique d'interaction pour Creerprogramme.xaml
    /// </summary>
    public partial class Creerprogramme : Page
    {
        private List<Instruction> programInst;

        public Creerprogramme(List<Instruction> programInstructions)
        {
            InitializeComponent();
            programInst = new List<Instruction>(programInstructions);

        }

        private void GoBackHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ProgrammePage.xaml", UriKind.RelativeOrAbsolute));
        }
        
        private void GoToProgramme3(object sender, RoutedEventArgs e)
        {
            PageProgramme3 thirdPage = new PageProgramme3(programInst);
            this.NavigationService.Navigate(thirdPage);
            //NavigationService.Navigate(new Uri("/PageProgramme3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Hexadecimal(object sender, RoutedEventArgs e)
        {
            BorderHexadecimal.Visibility = Visibility.Visible;
            BorderMnemonique.Visibility = Visibility.Collapsed;
        }

        private void Mnemonique(object sender, RoutedEventArgs e)
        {
            BorderHexadecimal.Visibility = Visibility.Collapsed;
            BorderMnemonique.Visibility = Visibility.Visible;
        }


    }
}
