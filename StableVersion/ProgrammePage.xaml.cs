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
using System.Diagnostics;
using projet.Pages;
using TextBox = System.Windows.Controls.TextBox;

namespace projet
{
    /// <summary>
    /// Interaction logic for ProgrammePage.xaml
    /// </summary>
    public sealed partial class ProgrammePage : Page
    {
        //static int Load_is_clicked = 0;

        static int currentLineNumber = 1;
        List<Instruction> programInstructions = new List<Instruction>();
        public ProgrammePage()
        {
            InitializeComponent();
            Loaded += ProgrammePage_Loaded;
        }
        public ProgrammePage(string filePath = "")
        {
            InitializeComponent();
            Loaded += ProgrammePage_Loaded;
            if(filePath != "") {
                LoadProgramFromFile(filePath);
            }
        }
        private void ProgrammePage_Loaded(object sender, RoutedEventArgs e)
        {
            programInstructions = new List<Instruction>();//bech a chaque nreinitialiser
        }
        //private void Go_Back(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}





        private Instruction SetInstruction(string mnemonique, string format, string destination, string source, bool mem, bool ifdepl, string valdep,string val_imm16)
        {
            Instruction new_instruction = new Instruction(mnemonique, format, destination, source, mem, ifdepl, valdep,val_imm16);
            return new_instruction;
        }

        private static int number_inst;

        public static void Set_number_inst(int valeur)
        {
            number_inst = valeur;
        }

        public static int Get_number_inst()
        {
            return number_inst;
        }
        

        private void AddInstruction_Click(object sender, RoutedEventArgs e)
        {
            currentLineNumber = 0 ;
            Instruction_Ligne currentInstruction = (Instruction_Ligne)Grid_Inst.Children[Grid_Inst.Children.Count - 1];
            string? mnemonique = (currentInstruction.ComboBox2.SelectedItem != null) ? currentInstruction.ComboBox2.SelectedItem.ToString() : "";
            string? format = (currentInstruction.ComboBox3.SelectedItem != null) ? currentInstruction.ComboBox3.SelectedItem.ToString() : "";
            string? reg_m = (currentInstruction.ComboBox4.IsEnabled && currentInstruction.ComboBox4.SelectedItem != null) ? currentInstruction.ComboBox4.SelectedItem.ToString() : "";
            string? depl = (currentInstruction.ComboBox5.IsEnabled && currentInstruction.ComboBox5.SelectedItem != null) ? currentInstruction.ComboBox5.SelectedItem.ToString() : "";
            string? destinataire = (currentInstruction.ComboBox6.IsEnabled && currentInstruction.ComboBox6.SelectedItem != null) ? currentInstruction.ComboBox6.SelectedItem.ToString() : "";
            string? source = (currentInstruction.ComboBox7.IsEnabled && (currentInstruction.ComboBox7.Visibility == Visibility.Visible) && currentInstruction.ComboBox7.SelectedItem != null) ? currentInstruction.ComboBox7.SelectedItem.ToString() : "";
            string? val_dep = currentInstruction.Val1 is TextBox textBox1 ? textBox1.Text : "";
            string? val_imm16 = currentInstruction.Val0 is TextBox textBox ? textBox.Text : "";
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

            foreach (UIElement element in Grid_Inst.Children)
            {
                currentLineNumber++;
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
                    if (ins.Val1.IsVisible && ins.Val1.Text.Length == 0)
                    {
                        allChecked = false;
                        break;
                    }
                    if (ins.Val0.IsVisible && ins.Val0.Text.Length == 0)
                    {
                        allChecked = false;
                        break;
                    }
                }
            }
            if (!allChecked)
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner un élément dans toutes les listes déroulantes activées.");
                if (currentLineNumber > 1)
                {
                    currentLineNumber--;
                }
            }
            else
            {

                Instruction instruction = new Instruction();
                instruction = SetInstruction(mnemonique, format, destinataire, source,  mem, deplacement, val_dep,val_imm16);
                programInstructions.Add(instruction);
                currentLineNumber++;
                var instructionLigne = new Instruction_Ligne();
                Grid_Inst.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                Grid_Inst.Children.Add(instructionLigne);
                Grid.SetRow(instructionLigne, currentLineNumber - 1);
                Grid.SetColumn(instructionLigne, 1);
                //currentLineNumber++;
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
            
            Creerprogramme secondPage = new Creerprogramme(programInstructions);
            this.NavigationService.Navigate(secondPage);

            Set_number_inst(currentLineNumber);

        }





        private void GoBack_To_Home(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Page1.xaml", UriKind.Relative));
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
                    if (i <= 2)
                    {
                        if (userControl.FindName($"Val{i-1}") is TextBox textBox)
                        {
                            instructionData.Add($"Val{i-1}", textBox.Text.ToString() ?? "");
                        }
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
                return ;
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
                    if (j <= 2)
                    {
                        if (programData[i].TryGetValue($"Val{j-1}", out string textBoxValue))
                        {
                            TextBox? textBox = newInstruction.FindName($"Val{j-1}") as TextBox;
                            if (textBox != null)
                            {
                                textBox.Loaded += (sender, e) =>
                                {
                                    textBox.Text = textBoxValue ?? "";
                                };
                            }
                            //test  System.Windows.MessageBox.Show(comboBoxValue);
                        }
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
                programData[i].TryGetValue($"Val{1}", out string Val1);
                programData[i].TryGetValue($"Val{0}", out string Val0);
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
                instruction = SetInstruction(mnemonique, format, destinataire, source, deplacement, mem,Val1,Val0);
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