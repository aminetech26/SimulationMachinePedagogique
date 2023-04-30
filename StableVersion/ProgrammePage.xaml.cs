using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
using ArchiMind;

namespace projet
{
    /// <summary>
    /// Interaction logic for ProgrammePage.xaml
    /// </summary>
    public sealed partial class ProgrammePage : Page
    {
        List<Instruction> programInstructions = new List<Instruction>();
        public ProgrammePage()
        {
            InitializeComponent();
            Loaded += ProgrammePage_Loaded;
        }
        private void ProgrammePage_Loaded(object sender, RoutedEventArgs e)
        {
            programInstructions = new List<Instruction>();//bech a chaque nreinitialiser
        }
        //private void Go_Back(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        private Instruction SetInstruction(string mnemonique, string format, string destination, string source, bool mem = true, bool ifdepl = true, string valdep = "")
        {
            Instruction new_instruction = new Instruction(mnemonique, format, destination, source, mem = true, ifdepl = true, valdep = "");
            return new_instruction;
        }

        private int currentLineNumber = 1;
        private void AddInstruction_Click(object sender, RoutedEventArgs e)
        {
            Instruction_Ligne currentInstruction = (Instruction_Ligne)Grid_Inst.Children[Grid_Inst.Children.Count - 1];
            string? mnemonique = (currentInstruction.ComboBox2.SelectedItem != null) ? currentInstruction.ComboBox2.SelectedItem.ToString() : "";
            string? format = (currentInstruction.ComboBox3.SelectedItem != null) ? currentInstruction.ComboBox3.SelectedItem.ToString() : "";
            string? reg_m = (currentInstruction.ComboBox4.IsEnabled && currentInstruction.ComboBox4.SelectedItem != null) ? currentInstruction.ComboBox3.SelectedItem.ToString() : "";
            string? depl = (currentInstruction.ComboBox5.IsEnabled && currentInstruction.ComboBox5.SelectedItem != null) ? currentInstruction.ComboBox4.SelectedItem.ToString() : "";
            string? destinataire = (currentInstruction.ComboBox6.IsEnabled && currentInstruction.ComboBox6.SelectedItem != null) ? currentInstruction.ComboBox3.SelectedItem.ToString() : "";
            string? source = (currentInstruction.ComboBox7.IsEnabled && currentInstruction.ComboBox7.SelectedItem != null) ? currentInstruction.ComboBox6.SelectedItem.ToString() : "";

            bool deplacement;
            bool mem;
            if (depl == "Avec deplacement")
            {
                deplacement = true;
            }
            else
            {
                deplacement = false;
            }
            if (reg_m == "Memoire")
            {
                mem = true;
            }
            else
            {
                mem = false;
            }
            bool allChecked = true;
            foreach (UIElement element in Grid_Inst.Children)
            {
                if (element is Instruction_Ligne ins)
                {
                    // Check if all enabled ComboBoxes have a selected item
                    if (ins.ComboBox1.IsEnabled && ins.ComboBox1.SelectedItem == null)
                    {
                        allChecked = false;
                        break;
                    }
                    if (ins.ComboBox2.IsEnabled && ins.ComboBox2.SelectedItem == null)
                    {
                        allChecked = false;
                        break;
                    }
                    if (ins.ComboBox3.IsEnabled && ins.ComboBox3.SelectedItem == null)
                    {
                        allChecked = false;
                        break;
                    }
                    if (ins.ComboBox4.IsEnabled && ins.ComboBox4.SelectedItem == null)
                    {
                        allChecked = false;
                        break;
                    }
                    if (ins.ComboBox5.IsEnabled && ins.ComboBox5.SelectedItem == null)
                    {
                        allChecked = false;
                        break;
                    }
                    if (ins.ComboBox6.IsEnabled && ins.ComboBox6.SelectedItem == null)
                    {
                        allChecked = false;
                        break;
                    }
                }
            }
            if (!allChecked)
            {
                MessageBox.Show("Veuillez sélectionner un élément dans toutes les listes déroulantes activées.");
            }
            else
            {
                Instruction instruction = new Instruction();
                instruction = SetInstruction(mnemonique, format, destinataire, source, deplacement, mem);
                programInstructions.Add(instruction);
                currentLineNumber++;
                var instructionLigne = new Instruction_Ligne();
                Grid_Inst.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                Grid_Inst.Children.Add(instructionLigne);
                Grid.SetRow(instructionLigne, currentLineNumber - 1);
                Grid.SetColumn(instructionLigne, 1);

                var lineTextBlock = new TextBlock();
                lineTextBlock.Text = currentLineNumber.ToString();
                lineTextBlock.FontSize = 25;
                lineTextBlock.FontWeight = FontWeights.Bold;
                lineTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4E719D"));
                lineTextBlock.FontFamily = new FontFamily("Montserrat");
                lineTextBlock.TextAlignment = TextAlignment.Center;
                lineTextBlock.Margin = new Thickness(0, 35, 0, 35);
                lineTextBlock.Height = Double.NaN;
                lineTextBlock.Width = Double.NaN;
                leftColumnGrid.Children.Add(lineTextBlock);
                lineTextBlock.SetValue(Grid.RowProperty, currentLineNumber - 1);

                // Check if currentLineNumber is greater than 5 and set the VerticalScrollBarVisibility property of the ScrollViewer to Visible
                if (currentLineNumber > 5)
                {
                    Grid_InstructionsScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                }
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            JeuxInstruction j = new JeuxInstruction();
            string text = "";
            foreach(Instruction ins in programInstructions)
            {
                text = j.convertir_instruction_Lmnemonique(ins) + "  \n";
            }
            MessageBox.Show(text);
            
            NavigationService.Navigate(new Uri("/PageProgramme3.xaml", UriKind.Relative));
        }

        private void GoBack_To_Home(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Home.xaml", UriKind.Relative));
        }
    }
}