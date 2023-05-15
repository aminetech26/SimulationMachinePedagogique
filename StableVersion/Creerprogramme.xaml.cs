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

            BorderMnemonique.Visibility = Visibility.Visible;

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

        static int q = 1;
        private void Hexadecimal(object sender, RoutedEventArgs e)
        {

            BorderHexadecimal.Visibility = Visibility.Visible;
            BorderMnemonique.Visibility = Visibility.Collapsed;
            if (q==1)
            {
                int i = ProgrammePage.Get_number_inst();

                for (int f = 0; f < i; f++)
                {
                    RowDefinition row = new RowDefinition();
                    Grid_Hexa.RowDefinitions.Add(row);
                }

                for (int o = 0; o < 2; o++)
                {
                    ColumnDefinition col = new ColumnDefinition();
                    Grid_Hexa.ColumnDefinitions.Add(col);
                }

                // add some elements to the grid
                JeuxInstruction j = new JeuxInstruction();
                j.intialize();
                string text = "";
                int k = 1;
                TextBlock line = new TextBlock();
                TextBlock nb = new TextBlock();
                foreach (Instruction ins in programInst)
                {

                    text = j.inst_to_hexaforme(ins) + "  \n";
                    line = new TextBlock();
                    line.Text = text;

                    line.FontSize = 22;
                    line.FontWeight = FontWeights.DemiBold;
                    line.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7A7A7A"));
                    line.FontFamily = new FontFamily("Montserrat");
                    line.TextAlignment = TextAlignment.Center;
                    line.Margin = new Thickness(0, 10, 0, 10);
                    line.Height = Double.NaN;
                    line.Width = 250;


                    Grid.SetRow(line, k);
                    Grid.SetColumn(line, 3);
                    Grid_Hexa.Children.Add(line);
                    nb = new TextBlock();
                    nb.Text = k.ToString();

                    nb.FontSize = 22;
                    nb.FontWeight = FontWeights.Bold;
                    nb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4E719D"));
                    nb.FontFamily = new FontFamily("Montserrat");
                    nb.TextAlignment = TextAlignment.Center;
                    nb.Margin = new Thickness(20, 10, 20, 10);
                    nb.Height = Double.NaN;
                    nb.Width = Double.NaN;

                    Grid.SetRow(nb, k);
                    Grid.SetColumn(nb, 0);
                    Grid_Hexa.Children.Add(nb);
                    k++;

                }
            }


        }

        static int j = 1;
        private void Mnemonique(object sender, RoutedEventArgs e)
        {
            
            BorderHexadecimal.Visibility = Visibility.Collapsed;
            BorderMnemonique.Visibility = Visibility.Visible;
            if (j == 1)
            {
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
                j.intialize();
                string text = "";
                int k = 1;
                TextBlock line = new TextBlock();
                TextBlock nb = new TextBlock();
                foreach (Instruction ins in programInst)
                {
                    text = j.convertir_instruction_Lmnemonique(ins) + "  \n";
                    

                    line = new TextBlock();
                    line.Text = text;

                    line.FontSize = 22;
                    line.FontWeight = FontWeights.DemiBold;
                    line.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7A7A7A"));
                    line.FontFamily = new FontFamily("Montserrat");
                    line.TextAlignment = TextAlignment.Center;
                    line.Margin = new Thickness(0, 10, 0, 10);
                    line.Height = Double.NaN;
                    line.Width = 250;


                    Grid.SetRow(line, k);
                    Grid.SetColumn(line, 3);
                    Grid_Mnem.Children.Add(line);
                    nb = new TextBlock();
                    nb.Text = k.ToString();

                    nb.FontSize = 22;
                    nb.FontWeight = FontWeights.Bold;
                    nb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4E719D"));
                    nb.FontFamily = new FontFamily("Montserrat");
                    nb.TextAlignment = TextAlignment.Center;
                    nb.Margin = new Thickness(20, 10, 20, 10);
                    nb.Height = Double.NaN;
                    nb.Width = Double.NaN;

                    Grid.SetRow(nb, k);
                    Grid.SetColumn(nb, 0);
                    Grid_Mnem.Children.Add(nb);
                    k++;

                }
                

            }
            

        }


    }
}
