using ArchiMind;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour Page_Decalage.xaml
    /// </summary>
    public partial class Decalage1 : Page
    {
        private Decalage1 mainpage;
        public Decalage1()
        {
            InitializeComponent();
            mainpage = this;
            Animation.setcontext(mainpage);
        }


        private void Go_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/CEI.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 800)
            {
                StackPanel1.Height = 100;
                StackPanel1.Height = 150;
                Text1.FontSize = 32;
                Instruction.Width = 150;
                Instruction.Height = 70;
                Format.Width = 150;
                Format.Height = 70;
                Reg.Width = 150;
                Reg.Height = 70;
                Dep.Width = 150;
                Dep.Height = 70;
                Destinataire.Width = 150;
                Destinataire.Height = 70;
                Source.Width = 150;
                Source.Height = 70;
                TextBox1.Width = 150;
                TextBox2.Width = 150;
                TextBox3.Width = 150;
                Inst_En_Hexa.Height = 60;
                Inst_En_Hexa.FontSize = 25;
                Button_simuler.Height = 90;
                Button_simuler.Width = 350;
            }
            else
            {
                StackPanel1.Height = 75;
                StackPanel1.Height = 125;
                Text1.FontSize = 27;
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
                TextBox1.Width = 100;
                TextBox2.Width = 100;
                TextBox3.Width = 100;
                Inst_En_Hexa.Height = 50;
                Inst_En_Hexa.FontSize = 22;
                Button_simuler.Height = 75;
                Button_simuler.Width = 300;
            }
        }

        private void RemoveHintText(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "XXXX")
            {
                TextBox1.Text = "";
                TextBox1.Foreground = Brushes.Black;
            }
        }

        private void AddHintText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                TextBox1.Text = "XXXX";
                TextBox1.Foreground = Brushes.Gray;
            }
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool allValid = true;
            foreach (var tb in FindVisualChildren<TextBox>(this))
            {
                string input = tb.Text.Trim();
                TextBox? textBox = sender as TextBox;
                textBox.CaretIndex = textBox.Text.Length;
                if (!Regex.IsMatch(input, @"^[0-9A-Fa-f]{4}$"))
                {
                    tb.ToolTip = "Entrer 4 caracteres en hexa";
                    tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DAF3FF"));
                    allValid = false;
                }
                else
                {
                    tb.ToolTip = null;
                    tb.Background = Brushes.White;
                }
            }
        }

        private IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox2.Text == "XXXX")
            {
                TextBox2.Text = "";
                TextBox2.Foreground = Brushes.Black;
            }
        }

        private void TextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                TextBox2.Text = "XXXX";
                TextBox2.Foreground = Brushes.Gray;
            }
        }


        private void deplac_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                TextBox3.Text = "XXXX";
                TextBox3.Foreground = Brushes.Gray;
            }
        }

        private void deplac_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox3.Text == "XXXX")
            {
                TextBox3.Text = "";
                TextBox3.Foreground = Brushes.Black;
            }
        }

        private void TextBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox4.Text == "XXXX")
            {
                TextBox4.Text = "";
                TextBox4.Foreground = Brushes.Black;
            }
        }

        private void TextBox4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox4.Text))
            {
                TextBox4.Text = "XXXX";
                TextBox4.Foreground = Brushes.Gray;
            }
        }


        private void TextBox5_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox5.Text == "XXXX")
            {
                TextBox5.Text = "";
                TextBox5.Foreground = Brushes.Black;
            }
        }

        private void TextBox5_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox5.Text))
            {
                TextBox5.Text = "XXXX";
                TextBox5.Foreground = Brushes.Gray;
            }
        }



        public void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string hexString = TextBox1.Text;
            string hexString2 = TextBox2.Text;
            string hexString3 = TextBox3.Text;
            string hexString4 = TextBox4.Text;
            string hexString5 = TextBox5.Text;
            string moule = "^[0-9A-Fa-f]+$";
            Regex regex = new Regex(moule);




            if (!regex.IsMatch(hexString) && (hexString != "XXXX"))
            {
                MessageBox.Show("Le texte saisi n'est pas en hexadécimal.");
                return;
            }
            if (!regex.IsMatch(hexString2) && (hexString2 != "XXXX"))
            {
                MessageBox.Show("Le texte saisi n'est pas en hexadécimal.");
                return;
            }
            if (!regex.IsMatch(hexString3) && (hexString3 != "XXXX"))
            {
                MessageBox.Show("Le texte saisi n'est pas en hexadécimal.");
                return;
            }
            if (!regex.IsMatch(hexString4) && (hexString4 != "XXXX"))
            {
                MessageBox.Show("Le texte saisi n'est pas en hexadécimal.");
                return;
            }
            if (!regex.IsMatch(hexString5) && (hexString5 != "XXXX"))
            {
                MessageBox.Show("Le texte saisi n'est pas en hexadécimal.");
                return;
            }

            ComboBoxItem selectedItem = Instruction.SelectedItem as ComboBoxItem;
            if (selectedItem == null) { MessageBox.Show("ERREUR!!!, CHOISER UNE INSTRUCTION "); return; }
            string Forma; string deplace; bool ifdepl;
            string letter = "";

            if (Format.SelectedItem.ToString() == "") { MessageBox.Show("ERREUR!!!, CHOISER UNE FORMAT "); return; }
            else { letter = Format.SelectedItem.ToString(); }
            string destinatair = "";
            if ((letter != "AX,imd16") && (letter != "Reg16")) { destinatair = Source.SelectedItem.ToString(); }
            string source = "XXXX";
            if (Source.SelectedItem != null) { source = Source.SelectedItem.ToString(); }
            string Registr = "";
            if ((letter != "AX,imd16") && (letter != "Reg16")) { Registr = Reg.SelectedItem.ToString(); }
            if ((Registr == " Registre ") || (letter == "AX,imd16") || (letter == "Reg16")) { deplace = "0000"; }
            else { deplace = Dep.SelectedItem.ToString(); }
            if (deplace == "Avec deplacement") { ifdepl = true; }
            else { ifdepl = false; }
            JeuxInstruction instruction = new JeuxInstruction();
            MainWindow wind = new MainWindow(sender, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox4.Text, selectedItem.Content.ToString(), letter, Registr, "0000", destinatair, source, champ1.Text, champ2.Text, champ3.Text);

        }


        public void convertButton_Click1(object sender, RoutedEventArgs e)
        {
            Animation main = new Animation();
            main.ShowDialog();
        }


        private void componentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected combo box item
            ComboBoxItem selectedItem = Instruction.SelectedItem as ComboBoxItem;


            // Show the components for the selected option
            if (selectedItem != null)
            {
                // Format.Items.Clear();
                if (selectedItem.Content.ToString() == "SHL")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");

                }
                else if (selectedItem.Content.ToString() == "SHR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");

                }
                else if (selectedItem.Content.ToString() == "SAL")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");
                }
                else if (selectedItem.Content.ToString() == "SAR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");
                }
                else if (selectedItem.Content.ToString() == "ROR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");
                }
                else if (selectedItem.Content.ToString() == "ROL")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");
                }
                else if (selectedItem.Content.ToString() == "RCR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");
                }
                else if (selectedItem.Content.ToString() == "RCX")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16/Mem16,imm16");
                    Format.Items.Add("Reg16/Mem16,CX");
                }

            }


        }


        private void componentFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem selectedItem = Format.SelectedItem as ComboBoxItem;

            string letter = Format.SelectedItem.ToString();

            // Show the components for the selected option
            if (letter != null)
            {

                if (string.Compare(letter, "Reg16/Mem16,imm16") == 0)
                {
                    int columnIndex = Grid.GetColumn(stkDes);
                    if (columnIndex >= 0)
                    {
                        StackPanel1.Children.Remove(stkDes);
                    }


                    champ3.Text = "Imd16(n decalage) :";

                }


                if (string.Compare(letter, "Reg16/Mem16,CX") == 0)
                {
                    int columnIndex = Grid.GetColumn(stkDes);
                    if (columnIndex >= 0)
                    {
                        StackPanel1.Children.Remove(stkDes);
                    }


                    champ3.Text = "CX :";
                }

                Instruction.IsEnabled = false;
                Reg.Items.Clear();
                Reg.Items.Add(" Registre ");
                Reg.Items.Add(" Memoire ");
                Dep.Items.Clear();
                Dep.Items.Add("Avec deplacement");
                Dep.Items.Add("Sans deplacement");

            }
        }


        private void componentReg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? selectedItem = Reg.SelectedItem as ComboBoxItem;

            string letter = Reg.SelectedItem.ToString();


            if (letter != null)
            {

                if (string.Compare(letter, " Registre ") == 0)
                {
                    int columnIndex1 = Grid.GetColumn(grid_ccm);
                    if (columnIndex1 >= 0)
                    {
                        Grid5.Children.Remove(grid_ccm);
                    }

                    int columnIndex2 = Grid.GetColumn(stc_2);
                    if (columnIndex2 >= 0)
                    {
                        stc_2.Children.Remove(champ2);
                        stc_2.Children.Remove(TextBox2);
                    }

                    int columnIndex3 = Grid.GetColumn(grid_dep);
                    if (columnIndex3 >= 0)
                    {
                        Grid5.Children.Remove(grid_dep);
                    }

                    int columnIndex4 = Grid.GetColumn(stkDep);
                    if (columnIndex4 >= 0)
                    {
                        StackPanel1.Children.Remove(stkDep);
                    }

                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("DX");
                    Source.Items.Add("BX");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                }

            }

            Format.IsEnabled = false;
            Reg.IsEnabled = false;

        }


        private void componentDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string letter = Dep.SelectedItem.ToString();

            if (letter != null)
            {

                if (string.Compare(letter, "Avec deplacement") == 0)
                {
                    Source.Items.Clear();
                    Source.Items.Add("[BX+SI+DEP]");
                    Source.Items.Add("[BX+DI+DEP]");
                    Source.Items.Add("[BP+SI+DEP]");
                    Source.Items.Add("[BP+DI+DEP]");
                    Source.Items.Add("[SI+DEP]");
                    Source.Items.Add("[DI+DEP]");
                    Source.Items.Add("[BP+DEP]");
                    Source.Items.Add("[BX+DEP]");
                }

                if (string.Compare(letter, "Sans deplacement") == 0)
                {
                    Source.Items.Clear();
                    Source.Items.Add("[BX+SI]");
                    Source.Items.Add("[BX+DI]");
                    Source.Items.Add("[BP+SI]");
                    Source.Items.Add("[BP+DI]");
                    Source.Items.Add("[SI]");
                    Source.Items.Add("[DI]");
                    Source.Items.Add("[Dep16]");
                    Source.Items.Add("[BX]");
                }
            }

            Reg.IsEnabled = false;

        }


        private void componentDes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void componentSrc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string letter1 = Format.SelectedItem.ToString();
            string letter2 = Reg.SelectedItem.ToString();
            string letter4 = Source.SelectedItem.ToString();
            string letter5;



            if (letter4 != null)
            {
                if (string.Compare(letter2, " Memoire ") == 0)
                {
                    letter5 = Dep.SelectedItem.ToString();
                    if (letter5 == "Sans deplacement")
                    {
                        int columnIndex = Grid.GetColumn(grid_dep);
                        if (columnIndex >= 0)
                        {
                            Grid5.Children.Remove(grid_dep);
                        }

                        if (letter4 == "[DI]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "DI :";
                        }

                        if (letter4 == "[SI]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "SI :";
                        }

                        if (letter4 == "[BX]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "BX :";

                        }
                        if (letter4 == "[Dep16]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "Dep16 :";
                        }

                        if (letter4 == "[BX+SI]")
                        {
                            champ2.Text = "BX :";
                            champ1.Text = "SI :";

                        }

                        if (letter1 == "[BX+DI]")
                        {
                            champ2.Text = "BX :";
                            champ1.Text = "DI :";
                        }

                        if (letter4 == "[BP+SI]")
                        {
                            champ2.Text = "BP :";
                            champ1.Text = "SI :";
                        }

                        if (letter4 == "[BP+DI]")
                        {
                            champ2.Text = "BP :";
                            champ1.Text = "DI :";
                        }

                    }
                    if (letter5 == "Avec deplacement")
                    {
                        if (letter4 == "[DI+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "DI :";
                        }

                        if (letter4 == "[SI+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "SI :";
                        }

                        if (letter4 == "[BX+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "BX :";
                        }

                        if (letter4 == "[BP+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                            }
                            champ1.Text = "BP :";
                        }

                        if (letter4 == "[BX+SI+DEP]")
                        {
                            champ2.Text = "BX :";
                            champ1.Text = "SI :";
                        }

                        if (letter4 == "[BX+DI+DEP]")
                        {
                            champ2.Text = "BX :";
                            champ1.Text = "DI :";
                        }

                        if (letter4 == "[BP+SI+DEP]")
                        {
                            champ2.Text = "BP :";
                            champ1.Text = "SI :";
                        }

                        if (letter4 == "[BP+DI+DEP]")
                        {
                            champ2.Text = "BP :";
                            champ1.Text = "DI :";
                        }

                    }
                }


                if (string.Compare(letter2, " Registre ") == 0)
                {

                    if (string.Compare(letter4, "AX") == 0)
                    {
                        champ1.Text = "AX :";
                    }
                    if (letter4 == "BX")
                    {
                        champ1.Text = "BX :";
                    }
                    if (letter4 == "CX")
                    {
                        champ1.Text = "CX :";
                    }

                }

            }

            Dep.IsEnabled = false;
            Source.IsEnabled = false;


        }



        private void Actualiser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page_Decalage.xaml", UriKind.RelativeOrAbsolute));
        }


    }
}
