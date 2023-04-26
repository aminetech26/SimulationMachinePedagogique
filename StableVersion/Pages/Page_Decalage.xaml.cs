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
    public partial class Page_Decalage : Page
    {
        public Page_Decalage()
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
                Inst.Width = 275;
                Inst.Height = 60;
                Inst.FontSize = 25;
                Inst_En_Hexa.Width = 275;
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
                Inst.Width = 150;
                Inst.Height = 50;
                Inst.FontSize = 22;
                Inst_En_Hexa.Width = 150;
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
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 4)
            {
                textBox.Text = textBox.Text.Substring(0, 4);
                textBox.CaretIndex = 4;
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

        public void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string hexString = TextBox1.Text;
            string moule = "^[0-9A-Fa-f]+$";
            Regex regex = new Regex(moule);

            if (!regex.IsMatch(hexString))
            {
                MessageBox.Show("Le texte saisi n'est pas en hexadécimal.");
                return;
            }

            //int decimalValue = Convert.ToInt32(hexString, 16);
            //MessageBox.Show("La valeur décimale correspondante est : " + decimalValue.ToString());
            string Registr;
            string deplace;
            string destinatair;
            string source;
            string Forma;
            ComboBoxItem? selectedItem = Instruction.SelectedItem as ComboBoxItem;
            string letter = Format.SelectedItem.ToString();
            ComboBoxItem? selectedItem2 = Reg.SelectedItem as ComboBoxItem; if (selectedItem2 == null) { Registr = "0000"; } else { Registr = selectedItem2.ToString(); }
            ComboBoxItem? selectedItem3 = Dep.SelectedItem as ComboBoxItem; if (selectedItem3 == null) { deplace = "0000"; } else { deplace = selectedItem3.ToString(); }
            ComboBoxItem? selectedItem4 = Destinataire.SelectedItem as ComboBoxItem; if (selectedItem4 == null) { destinatair = "0000"; } else { destinatair = selectedItem4.ToString(); }
            ComboBoxItem? selectedItem5 = Source.SelectedItem as ComboBoxItem; if (selectedItem5 == null) { source = "0000"; } else { source = selectedItem5.ToString(); }

            MainWindow wind = new MainWindow(sender, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox4.Text, selectedItem.Content.ToString(), letter, Registr, deplace, destinatair, source);

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
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");

                }
                else if (selectedItem.Content.ToString() == "SHR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");

                }
                else if (selectedItem.Content.ToString() == "SAL")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");
                }
                else if (selectedItem.Content.ToString() == "SAR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");
                }
                else if (selectedItem.Content.ToString() == "ROR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");
                }
                else if (selectedItem.Content.ToString() == "ROL")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");
                }
                else if (selectedItem.Content.ToString() == "RCR")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");
                }
                else if (selectedItem.Content.ToString() == "RCX")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg/M , Imd16");
                    Format.Items.Add("Reg/M , CX");
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

                if (string.Compare(letter, "Reg/M , Imd16") == 0)
                {
                    int columnIndex = Grid.GetColumn(stkDes);
                    if (columnIndex >= 0)
                    {
                        StackPanel1.Children.Remove(stkDes);
                    }

                    int columnIndex5 = Grid.GetColumn(grid_ccm);
                    if (columnIndex5 >= 0)
                    {
                        Grid5.Children.Remove(grid_ccm);
                    }

                    champ3.Text = "Imd16(n decalage) :";

                }


                if (string.Compare(letter, "Reg/M , CX") == 0)
                {
                    int columnIndex = Grid.GetColumn(stkDes);
                    if (columnIndex >= 0)
                    {
                        StackPanel1.Children.Remove(stkDes);
                    }

                    int columnIndex5 = Grid.GetColumn(grid_ccm);
                    if (columnIndex5 >= 0)
                    {
                        Grid5.Children.Remove(grid_ccm);
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
            
            Reg.IsEnabled= false ;   

        }


        private void componentDes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void componentSrc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string letter1 = Format.SelectedItem.ToString();
            string letter2 = Reg.SelectedItem.ToString();
            string letter4 = Source.SelectedItem.ToString();
            string letter5 = Dep.SelectedItem.ToString();
            


            if (letter4 != null)
            {
                    if (string.Compare(letter2, " Memoire ") == 0)
                    {

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

            Dep.IsEnabled= false ;
            Source.IsEnabled= false ;


        }



        private void Actualiser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page_Decalage.xaml", UriKind.RelativeOrAbsolute));
        }


    }
}
