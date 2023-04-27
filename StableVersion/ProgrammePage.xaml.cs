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

        private Instruction SetInstruction(string mnemonique, string format, string destination, string source, bool mem = true, bool ifdepl = true, string valdep = "")
        {
            Instruction new_instruction = new Instruction(mnemonique, format, destination, source, mem = true, ifdepl = true, valdep = "");
            return new_instruction;
        }
            
        private void AddInstruction_Click(object sender, RoutedEventArgs e)
        {

            Instruction_Ligne previousInstruction = (Instruction_Ligne)containerElement.Children[containerElement.Children.Count - 2];
            string mnemonique = previousInstruction.ComboBox1.SelectedItem.ToString();
            string format = previousInstruction.ComboBox2.SelectedItem.ToString();
            string reg_m = (previousInstruction.ComboBox3.IsEnabled) ? previousInstruction.ComboBox3.SelectedItem.ToString() : "";
            string depl = (previousInstruction.ComboBox4.IsEnabled) ? previousInstruction.ComboBox4.SelectedItem.ToString() : "";
            string destinataire = (previousInstruction.ComboBox5.IsEnabled) ? previousInstruction.ComboBox3.SelectedItem.ToString() : "";
            string source = (previousInstruction.ComboBox6.IsEnabled) ? previousInstruction.ComboBox6.SelectedItem.ToString() : "";
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
            //reste a traiter les cas particulier (immediat + valeur deplacement)
            Instruction instruction;
            instruction = SetInstruction(mnemonique,format,destinataire,source,deplacement,mem);
            programInstructions.Add(instruction);
            Instruction_Ligne newInstruction = new Instruction_Ligne();

            // Set the position of the new control relative to the previous control
            double previousControlBottom = Canvas.GetTop(containerElement.Children[containerElement.Children.Count - 2]) + containerElement.Children[containerElement.Children.Count - 2].RenderSize.Height;
            Canvas.SetBottom(newInstruction, previousControlBottom + 20);

            // Add the new control to the container
            containerElement.Children.Add(newInstruction);
           // instructionList.Add(newInstruction);
        }
    }
}
