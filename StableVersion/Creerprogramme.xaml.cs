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

            int i = ProgrammePage.Get_number_inst();

            for (int f = 0; f < i; f++)
            {
                RowDefinition row = new RowDefinition();
                Grid_Mnem.RowDefinitions.Add(row);
            }

            for (int o = 0; o < 2; o++)
            {
                ColumnDefinition col = new ColumnDefinition();
                Grid_Mnem.ColumnDefinitions.Add(col);
            }

            // add some elements to the grid
            JeuxInstruction j = new JeuxInstruction();
            string text = "";
            int k = 0;
            foreach (Instruction ins in programInst)
            {
                text = j.convertir_instruction_Lmnemonique(ins) + "  \n";
            
                TextBlock line = new TextBlock();
                line.Text = text;
                Grid.SetRow(line, k);
                Grid.SetColumn(line, 2);
                Grid_Mnem.Children.Add(line);
                TextBlock nb = new TextBlock();
                nb.Text = k.ToString();
                Grid.SetRow(nb, k);
                Grid.SetColumn(nb, 0);
                Grid_Mnem.Children.Add(nb);
                k++;
            }
           

        }


    }
}
