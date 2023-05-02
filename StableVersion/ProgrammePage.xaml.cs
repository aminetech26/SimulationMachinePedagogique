using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
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
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using ComboBox = System.Windows.Controls.ComboBox;
using Newtonsoft.Json.Schema;

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

        private void AddInstruction_Click(object sender, RoutedEventArgs e)
        {

            Instruction_Ligne currentInstruction = (Instruction_Ligne)Grid_Inst.Children[Grid_Inst.Children.Count - 1];
            string? mnemonique = (currentInstruction.ComboBox2.SelectedItem != null) ? currentInstruction.ComboBox2.SelectedItem.ToString() : "";
            string? format = (currentInstruction.ComboBox3.SelectedItem != null) ? currentInstruction.ComboBox3.SelectedItem.ToString() : "";
            string? reg_m = (currentInstruction.ComboBox4.IsEnabled && currentInstruction.ComboBox4.SelectedItem != null) ? currentInstruction.ComboBox4.SelectedItem.ToString() : "";
            string? depl = (currentInstruction.ComboBox5.IsEnabled && currentInstruction.ComboBox5.SelectedItem != null) ? currentInstruction.ComboBox5.SelectedItem.ToString() : "";
            string? destinataire = (currentInstruction.ComboBox6.IsEnabled && currentInstruction.ComboBox6.SelectedItem != null) ? currentInstruction.ComboBox6.SelectedItem.ToString() : "";
            string? source = (currentInstruction.ComboBox7.IsEnabled && currentInstruction.ComboBox7.SelectedItem != null) ? currentInstruction.ComboBox7.SelectedItem.ToString() : "";
            int currentLineNumber = 1;
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
                System.Windows.MessageBox.Show("Veuillez sélectionner un élément dans toutes les listes déroulantes activées.");
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
            foreach (Instruction ins in programInstructions)
            {
                text = text + j.convertir_instruction_Lmnemonique(ins) + "  \n";
            }
            System.Windows.MessageBox.Show(text);

            NavigationService.Navigate(new Uri("/PageProgramme3.xaml", UriKind.Relative));
        }

        private void GoBack_To_Home(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Home.xaml", UriKind.Relative));
        }

        public void SaveProgramToFile(string filename)
        {
            List<Dictionary<string, string>> programData = new List<Dictionary<string, string>>();

            foreach (Instruction_Ligne userControl in Grid_Inst.Children)
            {
                Dictionary<string, string> instructionData = new Dictionary<string, string>();

                for (int i = 1; i <= 7; i++)
                {
                    if (userControl.FindName($"ComboBox{i}") is ComboBox comboBox)
                    {
                        instructionData.Add($"ComboBox{i}", comboBox.SelectedValue?.ToString() ?? "");
                    }
                }


                programData.Add(instructionData);
            }
            string serializedData = JsonConvert.SerializeObject(programData, Formatting.Indented);
            File.WriteAllText(filename, serializedData);
        }

        public void LoadProgramFromFile(string filePath)
        {
            int currentLineNumber = 1;

            //    string filePathJson = @"C:\Users\Amine's PC\Music\SimulationMachinePedagogique\StableVersion\ArchimindFiles\schema.json";
            //    string filePathArchimind = @"C:\Users\Amine's PC\Music\SimulationMachinePedagogique\StableVersion\ArchimindFiles\Program.archimind";

            //Load the JSON data from the .archimind file and deserialize it
            string serializedData = File.ReadAllText(filePath);
            List<Dictionary<string, string>> programData0 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(serializedData);
            List<Dictionary<string, string>> programData;
            try
            {
                programData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(serializedData);
            }
            catch (JsonSerializationException ex)
            {
                // Handle deserialization errors
                // ...
                return;
            }

            Grid_Inst.Children.Clear();

            for (int i = 0; i < programData.Count; i++)
            {
                Instruction_Ligne newInstruction = new Instruction_Ligne();

                for (int j = 1; j <= 7; j++)
                {
                    if (programData[i].TryGetValue($"ComboBox{j}", out string comboBoxValue))
                    {
                        ComboBox? comboBox = newInstruction.FindName($"ComboBox{j}") as ComboBox;
                        if (comboBox != null)
                        {
                            comboBox.Loaded += (sender, e) =>
                            {
                                comboBox.SelectedValue = comboBoxValue ?? "";
                            };
                        }
                        //test  System.Windows.MessageBox.Show(comboBoxValue);
                    }
                    else
                    {
                        //tsema raw yrecupiri  System.Windows.MessageBox.Show("VALUE NOT RETRIEVED");
                    }
                    

                }
                programData[i].TryGetValue($"ComboBox{2}", out string mnemonique);
                programData[i].TryGetValue($"ComboBox{3}", out string format);
                programData[i].TryGetValue($"ComboBox{4}", out string reg_m);
                programData[i].TryGetValue($"ComboBox{5}", out string depl);
                programData[i].TryGetValue($"ComboBox{6}", out string destinataire);
                programData[i].TryGetValue($"ComboBox{7}", out string source);

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
                Instruction instruction = new Instruction();
                instruction = SetInstruction(mnemonique, format, destinataire, source, deplacement, mem);
                programInstructions.Add(instruction);
                //currentLineNumber++;
                Grid_Inst.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                Grid_Inst.Children.Add(newInstruction);
                Grid.SetRow(newInstruction, currentLineNumber - 1);
                Grid.SetColumn(newInstruction, 1);
                currentLineNumber++;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Show save file dialog
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Program"; // Default file name
            dlg.DefaultExt = ".archimind"; // Default file extension
            dlg.Filter = "Archimind files (.archimind)|*.archimind"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;
                SaveProgramToFile(filePath);
            }
        }
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Program"; // Default file name
            dlg.DefaultExt = ".archimind"; // Default file extension
            dlg.Filter = "Archimind files (.archimind)|*.archimind"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;//return the full path not only the name as it seems.
                LoadProgramFromFile(filePath);
            }
        }



    }
}