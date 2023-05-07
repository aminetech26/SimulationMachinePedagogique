using ArchiMind;
using System;
using System.Collections.Generic;
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

namespace projet.Pages
{
    /// <summary>
    /// Interaction logic for Branchement.xaml
    /// </summary>
    public partial class Branchement : Page
    {
        private Branchement mainpage;
        public Branchement()
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
            bool allValid = true;
            foreach (var tb in FindVisualChildren<TextBox>(this))
            {
                string input = tb.Text.Trim();
                TextBox? textBox = sender as TextBox;
                textBox.CaretIndex = textBox.Text.Length;
                if (!Regex.IsMatch(input, @"^[0-9A-Fa-f]{4}$"))
                {
                    tb.ToolTip = "Entrer 4 caracteres en hexa";
                    tb.Background = Brushes.Red;
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

            //int decimalValue = Convert.ToInt32(hexString, 16);
            //MessageBox.Show("La valeur décimale correspondante est : " + decimalValue.ToString());
            ComboBoxItem selectedItem = Instruction.SelectedItem as ComboBoxItem;
            if (selectedItem == null) { MessageBox.Show("ERREUR!!!, CHOISER UNE INSTRUCTION "); return; }
            string Forma; string deplace; bool ifdepl;
            string letter = "";

            if (Format.SelectedItem.ToString() == "") { MessageBox.Show("ERREUR!!!, CHOISER UNE FORMAT "); return; }
            else { letter = Format.SelectedItem.ToString(); }
            string destinatair = "";
            if ((letter != "AX,imd16") && (letter != "Reg16")) { destinatair = Destinataire.SelectedItem.ToString(); }
            string source = "XXXX";
            if (Source.SelectedItem != null) { source = Source.SelectedItem.ToString(); }
            string Registr = "";
            if ((letter != "AX,imd16") && (letter != "Reg16")&& (letter !="Mem16" ) ){ Registr = Reg.SelectedItem.ToString(); }
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
        // cette methode pour changer format 
        {
            // Get the selected combo box item
            ComboBoxItem selectedItem = Instruction.SelectedItem as ComboBoxItem;


            // Show the components for the selected option
            if (selectedItem != null)
            {
                // Format.Items.Clear();
                if (selectedItem.Content.ToString() == "LOOP")
                {
                    Format.Items.Clear();
                    Format.Items.Add("mem16");
                    //if (Format.SelectedIndex == 1) { Format.SelectedItem = "AX , Imd"; }

                }
                else if (selectedItem.Content.ToString() == "LOOPE")
                {
                    Format.Items.Clear();
                    Format.Items.Add("mem16");

                }
                else if (selectedItem.Content.ToString() == "LOOPNE")
                {
                    Format.Items.Clear();
                    Format.Items.Add("mem16");
                }
                else if (selectedItem.Content.ToString() == "LOOPZ")
                {
                    Format.Items.Clear();
                    Format.Items.Add("mem16");
                }
                else if (selectedItem.Content.ToString() == "LOOPNZ")
                {
                    Format.Items.Clear();
                    Format.Items.Add("mem16");
                }
                else if (selectedItem.Content.ToString() == "JMP")
                {
                    Format.Items.Clear();
                    Format.Items.Add("mem16");
                }
                else if (selectedItem.Content.ToString() == "CMP")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg16,Reg16/mem16");
                    Format.Items.Add("Reg16/mem16,Reg16");
                    Format.Items.Add("Reg16/mem16,imm16");

                }
            }


        }
        private void componentFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string letter = Format.SelectedItem.ToString();

            // Show the components for the selected option
            if (letter != null)
            {


                if (string.Compare(letter, "mem16") == 0)
                {
                    //int columnIndex = Grid.GetColumn(stkDes);
                    //if (columnIndex >= 0)
                    //{
                    //    StackPanel1.Children.Remove(stkDes);
                    //}


                    int columnIndex1 = Grid.GetColumn(stkSrc);
                    if (columnIndex1 >= 0)
                    {
                        //StackPanel1.ColumnDefinitions.RemoveAt(0);
                        StackPanel1.Children.Remove(stkSrc);
                    }
                    //int columnIndex2 = Grid.GetColumn(stkDep);

                    //// Check if the column index is greater than or equal to zero
                    //if (columnIndex2 >= 0)
                    //{
                    //    // StackPanel1.ColumnDefinitions.RemoveAt(2);
                    //    StackPanel1.Children.Remove(stkDep);
                    //}
                    int columnIndex3 = Grid.GetColumn(stkReg);
                    if (columnIndex3 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(3);
                        StackPanel1.Children.Remove(stkReg);
                    }
                    //int columnIndex4 = Grid.GetColumn(grid_dep);
                    //if (columnIndex4 >= 0)
                    //{
                    //    Grid5.Children.Remove(grid_dep);
                    //}
                    int columnIndex5 = Grid.GetColumn(grid_ccm);
                    if (columnIndex5 >= 0)
                    {
                        Grid5.Children.Remove(grid_ccm);
                    }
                    int columnIndex6 = Grid.GetColumn(stc_2);
                    if (columnIndex6 >= 0)
                    {
                        stc_2.Children.Remove(champ2);
                        stc_2.Children.Remove(TextBox2);
                    }

                    champ1.Text = "AX:";
                    champ3.Text = "imm16:";


                }
                else if ((string.Compare(letter, "Reg16,Reg16/mem16") == 0) || (string.Compare(letter, "Reg16/mem16,Reg16") == 0))
                {
                    if (!StackPanel1.Children.Contains(stkDes))
                    {
                        StackPanel1.ColumnDefinitions.Add(new ColumnDefinition());
                        Grid.SetColumn(stkDes, 4);
                        StackPanel1.Children.Add(stkDes);
                    }
                    if (!StackPanel1.Children.Contains(stkDep))
                    {
                        StackPanel1.ColumnDefinitions.Add(new ColumnDefinition());
                        Grid.SetColumn(stkDep, 3);
                        StackPanel1.Children.Add(stkDep);
                    }
                    if (!StackPanel1.Children.Contains(stkReg))
                    {
                        StackPanel1.ColumnDefinitions.Add(new ColumnDefinition());
                        Grid.SetColumn(stkReg, 2);
                        StackPanel1.Children.Add(stkReg);
                    }
                    if (!StackPanel1.Children.Contains(stkSrc))
                    {
                        StackPanel1.ColumnDefinitions.Add(new ColumnDefinition());
                        Grid.SetColumn(stkSrc, 5);
                        StackPanel1.Children.Add(stkSrc);
                    }


                }
                else if (string.Compare(letter, "Reg16/mem16,imm16") == 0)
                {

                    if (!StackPanel1.Children.Contains(stkDep))
                    {
                        StackPanel1.ColumnDefinitions.Add(new ColumnDefinition());
                        Grid.SetColumn(stkDep, 3);
                        StackPanel1.Children.Add(stkDep);
                    }
                    if (!StackPanel1.Children.Contains(stkReg))
                    {
                        StackPanel1.ColumnDefinitions.Add(new ColumnDefinition());
                        Grid.SetColumn(stkReg, 2);
                        StackPanel1.Children.Add(stkReg);
                    }
                    int columnIndex1 = Grid.GetColumn(stkSrc);
                    if (columnIndex1 >= 0)
                    {
                        StackPanel1.Children.Remove(stkSrc);
                    }

                }
                else if (letter == "Reg16/mem16")
                {
                    int columnIndex = Grid.GetColumn(stkSrc);
                    if (columnIndex >= 0)
                    {
                        StackPanel1.Children.Remove(stkSrc);
                    }
                    txtDes.Text = "Source";
                }
                //else if (letter == "Reg16")
                //{
                //    int columnIndex = Grid.GetColumn(stkDes);
                //    if (columnIndex >= 0)
                //    {
                //        StackPanel1.Children.Remove(stkDes);
                //    }
                //    int columnIndex2 = Grid.GetColumn(stkDep);

                //    // Check if the column index is greater than or equal to zero
                //    if (columnIndex2 >= 0)
                //    {
                //        // StackPanel1.ColumnDefinitions.RemoveAt(2);
                //        StackPanel1.Children.Remove(stkDep);
                //    }
                //    int columnIndex3 = Grid.GetColumn(stkReg);
                //    if (columnIndex3 >= 0)
                //    {
                //        // StackPanel1.ColumnDefinitions.RemoveAt(3);
                //        StackPanel1.Children.Remove(stkReg);
                //    }
                //    int columnIndex4 = Grid.GetColumn(grid_dep);
                //    if (columnIndex4 >= 0)
                //    {
                //        Grid5.Children.Remove(grid_dep);
                //    }
                //    int columnIndex5 = Grid.GetColumn(grid_ccm);
                //    if (columnIndex5 >= 0)
                //    {
                //        Grid5.Children.Remove(grid_ccm);
                //    }
                //    int columnIndex6 = Grid.GetColumn(stc_2);
                //    if (columnIndex6 >= 0)
                //    {
                //        stc_2.Children.Remove(champ2);
                //        stc_2.Children.Remove(TextBox2);
                //    }
                //    int columnIndex7 = Grid.GetColumn(stc_3);
                //    if (columnIndex7 >= 0)
                //    {
                //        stc_2.Children.Remove(champ3);
                //        stc_2.Children.Remove(TextBox3);
                //    }
                //    Source.Items.Clear();
                //    Source.Items.Add(" AX ");
                //    Source.Items.Add(" CX ");
                //    Source.Items.Add(" DX ");
                //    Source.Items.Add(" BX ");
                //    Source.Items.Add(" SP ");
                //    Source.Items.Add(" BP ");
                //    Source.Items.Add(" SI ");
                //    Source.Items.Add(" DI ");
                //}
            }
            //Instruction.IsEnabled = false;
            Reg.Items.Clear();
            Reg.Items.Add(" Registre ");
            Reg.Items.Add(" Memoire ");
            Dep.Items.Clear();
            Dep.Items.Add("Avec deplacement");
            Dep.Items.Add("Sans deplacement");

        }
        private void componentReg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? selectedItem = Reg.SelectedItem as ComboBoxItem;

            string letter = Reg.SelectedItem.ToString();
            string letter2 = Format.SelectedItem.ToString();


            if (letter != null)
            {
                if (string.Compare(letter, " Registre ") == 0)
                {
                    int columnIndex2 = Grid.GetColumn(stkDep);
                    if (columnIndex2 >= 0)
                    {
                        StackPanel1.Children.Remove(stkDep);
                    }
                    Destinataire.Items.Clear();
                    Destinataire.Items.Add("AX");
                    Destinataire.Items.Add("CX");
                    Destinataire.Items.Add("DX");
                    Destinataire.Items.Add("BX");
                    Destinataire.Items.Add("SP");
                    Destinataire.Items.Add("BP");
                    Destinataire.Items.Add("SI");
                    Destinataire.Items.Add("DI");
                }
                if (string.Compare(letter, " Memoire ") == 0)
                {
                    //if (!StackPanel1.Children.Contains(stkDep))
                    //
                    //    StackPanel1.ColumnDefinitions.Add(new ColumnDefinition());
                    //    Grid.SetColumn(stkDep, 3);
                    //    StackPanel1.Children.Add(stkDep);
                    //}

                    if (letter2 == "Reg16/mem16,Reg16")
                    {
                        Source.Items.Clear();
                        Source.Items.Add("AX");
                        Source.Items.Add("BX");
                        Source.Items.Add("CX");
                        Source.Items.Add("DX");
                        Source.Items.Add("SI");
                        Source.Items.Add("DI");
                        Source.Items.Add("SP");
                        Source.Items.Add("BP");
                    }
                    if (letter2 == "Reg16,Reg16/mem16")
                    {
                        Destinataire.Items.Clear();
                        Destinataire.Items.Add("AX");
                        Destinataire.Items.Add("CX");
                        Destinataire.Items.Add("DX");
                        Destinataire.Items.Add("BX");
                        Destinataire.Items.Add("SP");
                        Destinataire.Items.Add("BP");
                        Destinataire.Items.Add("SI");
                        Destinataire.Items.Add("DI");
                    }

                }


            }
            Format.IsEnabled = false;

        }
        private void componentDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = Dep.SelectedItem as ComboBoxItem;

            string letter = Dep.SelectedItem.ToString();
            string letter1 = Format.SelectedItem.ToString();
            //string letter2 = Reg.SelectedItem.ToString();

            if ((letter != null) && ((letter1 == "Reg16/mem16,Reg16") || (letter1 == "Reg16/mem16,imm16") || (letter1 == "Reg16/mem16") || (letter1 == "mem16")))
            {
                if (string.Compare(letter, "Avec deplacement") == 0)
                {
                    Destinataire.Items.Clear();
                    Destinataire.Items.Add("[BX+SI+DEP]");
                    Destinataire.Items.Add("[BX+DI+DEP]");
                    Destinataire.Items.Add("[BP+SI+DEP]");
                    Destinataire.Items.Add("[BP+DI+DEP]");
                    Destinataire.Items.Add("[SI+DEP]");
                    Destinataire.Items.Add("[DI+DEP]");
                    Destinataire.Items.Add("[BP+DEP]");
                    Destinataire.Items.Add("[BX+DEP]");
                }
                if (string.Compare(letter, "Sans deplacement") == 0)
                {
                    Destinataire.Items.Clear();
                    Destinataire.Items.Add("[BX+SI]");
                    Destinataire.Items.Add("[BX+DI]");
                    Destinataire.Items.Add("[BP+SI]");
                    Destinataire.Items.Add("[BP+DI]");
                    Destinataire.Items.Add("[SI]");
                    Destinataire.Items.Add("[DI]");
                    Destinataire.Items.Add("[Dep16]");
                    Destinataire.Items.Add("[BX]");
                }


            }
            else if ((letter != null) && (letter1 == "Reg16,Reg16/mem16"))
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
            else if ((letter != null) && (letter1 == "mem16"))
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

            Dep.IsEnabled = false;
            Reg.IsEnabled = false;

        }
        private void componentDes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string letter1 = Destinataire.SelectedItem.ToString();
            string letter2 = Format.SelectedItem.ToString();
            string letter3;
            string letter5;



            if ((letter1 != null) && ((letter2 == "Reg16/mem16,Reg16") || (letter2 == "Reg16/mem16,imm16") || (letter2 == "Reg16/mem16")))
            {
                letter3 = Reg.SelectedItem.ToString();
                Reg.IsEnabled = false;
                if ((string.Compare(letter1, "AX") == 0) && (letter3 == " Registre "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("BX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");

                }
                if ((string.Compare(letter1, "BX") == 0) && (letter3 == " Registre "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if ((string.Compare(letter1, "CX") == 0) && (letter3 == " Registre "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("BX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if ((string.Compare(letter1, "DX") == 0) && (letter3 == " Registre "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("BX");
                    Source.Items.Add("CX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if ((string.Compare(letter1, "SI") == 0) && (letter3 == " Registre "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("BX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if ((string.Compare(letter1, "DI") == 0) && (letter3 == " Registre "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("BX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if ((string.Compare(letter1, "SP") == 0) && (letter3 == " Registre "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("BX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("BP");
                }
                if ((string.Compare(letter1, "BP") == 0) && (letter3 == " Registre "))
                {

                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("BX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                }
                if ((string.Compare(letter1, "DI") == 0) && (letter3 == " Memoire "))
                {
                    string letter4 = Dep.SelectedItem.ToString();
                    if (string.Compare(letter4, "Avec deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BX+SI+DEP]");
                        Source.Items.Add("[BP+SI+DEP]");
                        Source.Items.Add("[SI+DEP]");
                        Source.Items.Add("[BP+DEP]");
                        Source.Items.Add("[BX+DEP]");
                    }
                    else if (string.Compare(letter4, "Sans deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BX+SI]");
                        Source.Items.Add("[BP+SI]");
                        Source.Items.Add("[SI]");
                        Source.Items.Add("[Dep16]");
                        Source.Items.Add("[BX]");
                    }
                }
                if ((string.Compare(letter1, "SI") == 0) && (letter3 == " Memoire "))
                {
                    string letter4 = Dep.SelectedItem.ToString();
                    if (string.Compare(letter4, "Avec deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BX+DI+DEP]");
                        Source.Items.Add("[BP+DI+DEP]");
                        Source.Items.Add("[DI+DEP]");
                        Source.Items.Add("[BP+DEP]");
                        Source.Items.Add("[BX+DEP]");
                    }
                    else if (string.Compare(letter4, "Sans deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BX+DI]");
                        Source.Items.Add("[BP+DI]");
                        Source.Items.Add("[DI]");
                        Source.Items.Add("[Dep16]");
                        Source.Items.Add("[BX]");
                    }
                }
                if ((string.Compare(letter1, "BX") == 0) && (letter3 == " Memoire "))
                {
                    string letter4 = Dep.SelectedItem.ToString();
                    if (string.Compare(letter4, "Avec deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BP+SI+DEP]");
                        Source.Items.Add("[BP+DI+DEP]");
                        Source.Items.Add("[SI+DEP]");
                        Source.Items.Add("[DI+DEP]");
                        Source.Items.Add("[BP+DEP]");
                    }
                    else if (string.Compare(letter4, "Sans deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BP+SI]");
                        Source.Items.Add("[BP+DI]");
                        Source.Items.Add("[SI]");
                        Source.Items.Add("[DI]");
                        Source.Items.Add("[Dep16]");
                    }
                }
                if ((string.Compare(letter1, "BX") == 0) && (letter3 == " Memoire "))
                {
                    string letter4 = Dep.SelectedItem.ToString();
                    if (string.Compare(letter4, "Avec deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BP+SI+DEP]");
                        Source.Items.Add("[BP+DI+DEP]");
                        Source.Items.Add("[SI+DEP]");
                        Source.Items.Add("[DI+DEP]");
                        Source.Items.Add("[BP+DEP]");
                    }
                    else if (string.Compare(letter4, "Sans deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BP+SI]");
                        Source.Items.Add("[BP+DI]");
                        Source.Items.Add("[SI]");
                        Source.Items.Add("[DI]");
                        Source.Items.Add("[Dep16]");
                    }
                }
                if ((string.Compare(letter1, "BP") == 0) && (letter3 == " Memoire "))
                {
                    string letter4 = Dep.SelectedItem.ToString();
                    if (string.Compare(letter4, "Avec deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BX+SI+DEP]");
                        Source.Items.Add("[BX+DI+DEP]");
                        Source.Items.Add("[SI+DEP]");
                        Source.Items.Add("[DI+DEP]");
                        Source.Items.Add("[BX+DEP]");
                    }
                    else if (string.Compare(letter4, "Sans deplacement") == 0)
                    {
                        Source.Items.Clear();
                        Source.Items.Add("[BX+SI]");
                        Source.Items.Add("[BX+DI]");
                        Source.Items.Add("[SI]");
                        Source.Items.Add("[DI]");
                        Source.Items.Add("[Dep16]");
                        Source.Items.Add("[BX]");
                    }
                }
                if (((string.Compare(letter1, "[BX+SI+DEP]") == 0) || (letter1 == "[BX+SI]")) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if (((string.Compare(letter1, "[BX+DI+DEP]") == 0) || (letter1 == "[BX+DI]")) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if (((string.Compare(letter1, "[BP+DI+DEP]") == 0) || (letter1 == "[BP+DI]")) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BX");
                }
                if (((string.Compare(letter1, "[BP+SI+DEP]") == 0) || (letter1 == "[BP+SI]")) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BX");
                }
                if (((string.Compare(letter1, "[BX+DEP]") == 0) || (letter1 == "[BX]")) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if (((string.Compare(letter1, "[SI+DEP]") == 0) || (letter1 == "[SI]")) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("BX");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if (((string.Compare(letter1, "[DI+DEP]") == 0) || (letter1 == "[DI]")) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("BX");
                    Source.Items.Add("SI");
                    Source.Items.Add("SP");
                    Source.Items.Add("BP");
                }
                if ((string.Compare(letter1, "[BP+DEP]") == 0) && (letter3 == " Memoire "))
                {
                    Source.Items.Clear();
                    Source.Items.Add("AX");
                    Source.Items.Add("CX");
                    Source.Items.Add("DX");
                    Source.Items.Add("BX");
                    Source.Items.Add("SI");
                    Source.Items.Add("DI");
                    Source.Items.Add("SP");
                }

                if ((letter2 == "Reg16/mem16,imm16") || (letter2 == "Reg16/mem16"))
                {
                    if (letter3 == " Memoire ")
                    {
                        letter5 = Dep.SelectedItem.ToString();
                        if (letter5 == "Sans deplacement")
                        {
                            int columnIndex = Grid.GetColumn(grid_dep);
                            if (columnIndex >= 0)
                            {
                                Grid5.Children.Remove(grid_dep);
                            }
                            if (letter1 == "[DI]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "DI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[SI]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "SI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BX]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "BX :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[Dep16]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "Dep16 :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BX+SI]")
                            {
                                champ2.Text = "BX :";
                                champ1.Text = "SI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BX+DI]")
                            {
                                champ2.Text = "BX :";
                                champ1.Text = "DI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BP+SI]")
                            {
                                champ2.Text = "BP :";
                                champ1.Text = "SI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BP+DI]")
                            {
                                champ2.Text = "BP :";
                                champ1.Text = "DI :";
                                champ3.Text = "imm16 :";
                            }

                        }
                        if (letter5 == "Avec deplacement")
                        {
                            if (letter1 == "[DI+DEP]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "DI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[SI+DEP]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "SI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BX+DEP]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "BX :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BP+DEP]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ1.Text = "BP :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BX+SI+DEP]")
                            {
                                champ2.Text = "BX :";
                                champ1.Text = "SI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BX+DI+DEP]")
                            {
                                champ2.Text = "BX :";
                                champ1.Text = "DI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BP+SI+DEP]")
                            {
                                champ2.Text = "BP :";
                                champ1.Text = "SI :";
                                champ3.Text = "imm16 :";
                            }
                            if (letter1 == "[BP+DI+DEP]")
                            {
                                champ2.Text = "BP :";
                                champ1.Text = "DI :";
                                champ3.Text = "imm16 :";
                            }

                        }
                    }
                    if (letter3 == " Registre ")
                    {
                        int columnIndex = Grid.GetColumn(grid_dep);
                        if (columnIndex >= 0)
                        {
                            Grid5.Children.Remove(grid_dep);
                        }
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

                        champ3.Text = "imm16 :";
                        champ1.Text = Destinataire.SelectedItem.ToString();
                    }


                }
            }
            else if (letter2 == "mem16")
            {
                string letter6 = Instruction.SelectedItem.ToString();
                letter5 = Dep.SelectedItem.ToString();
                if (letter6 == "JMP")
                {
                    if (letter5 == "Sans deplacement")
                    {
                        int columnIndex = Grid.GetColumn(grid_dep);
                        if (columnIndex >= 0)
                        {
                            Grid5.Children.Remove(grid_dep);
                        }
                        if (letter1 == "[DI]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "DI :";

                        }
                        if (letter1 == "[SI]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "SI :";

                        }
                        if (letter1 == "[BX]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "BX :";

                        }
                        if (letter1 == "[Dep16]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "Dep16 :";

                        }
                        if (letter1 == "[BX+SI]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BX :";
                            champ1.Text = "SI :";

                        }
                        if (letter1 == "[BX+DI]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BX :";
                            champ1.Text = "DI :";

                        }
                        if (letter1 == "[BP+SI]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BP :";
                            champ1.Text = "SI :";

                        }
                        if (letter1 == "[BP+DI]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BP :";
                            champ1.Text = "DI :";
                        }

                    }
                    else if (letter5 == "Avec deplacement")
                    {
                        if (letter1 == "[DI+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "DI :";

                        }
                        if (letter1 == "[SI+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "SI :";

                        }
                        if (letter1 == "[BX+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "BX :";

                        }
                        if (letter1 == "[BP+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if ((columnIndex1 >= 0) && (columnIndex2 >= 0))
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);
                            }
                            champ1.Text = "BP :";

                        }
                        if (letter1 == "[BX+SI+DEP]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BX :";
                            champ1.Text = "SI :";

                        }
                        if (letter1 == "[BX+DI+DEP]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BX :";
                            champ1.Text = "DI :";

                        }
                        if (letter1 == "[BP+SI+DEP]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BP :";
                            champ1.Text = "SI :";

                        }
                        if (letter1 == "[BP+DI+DEP]")
                        {
                            int columnIndex2 = Grid.GetColumn(stc_3);
                            if (columnIndex2 >= 0)
                            {
                                stc_3.Children.Remove(TextBox3);
                                stc_3.Children.Remove(champ3);

                            }
                            champ2.Text = "BP :";
                            champ1.Text = "DI :";

                        }






                    }
                }
                else if (letter6 != "JMP")
                {
                    if (letter5 == "Sans deplacement")
                    {
                        int columnIndex = Grid.GetColumn(grid_dep);
                        if (columnIndex >= 0)
                        {
                            Grid5.Children.Remove(grid_dep);
                        }
                        if (letter1 == "[DI]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "DI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[SI]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "SI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BX]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "BX :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[Dep16]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "Dep16 :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BX+SI]")
                        {

                            champ2.Text = "BX :";
                            champ1.Text = "SI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BX+DI]")
                        {
                            champ2.Text = "BX :";
                            champ1.Text = "DI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BP+SI]")
                        {

                            champ2.Text = "BP :";
                            champ1.Text = "SI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BP+DI]")
                        {

                            champ2.Text = "BP :";
                            champ1.Text = "DI :";
                            champ3.Text = "CX :";
                        }

                    }


                    else if (letter5 == "Avec deplacement")
                    {
                        if (letter1 == "[DI+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "DI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[SI+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "SI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BX+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "BX :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BP+DEP]")
                        {
                            int columnIndex1 = Grid.GetColumn(stc_2);
                            if (columnIndex1 >= 0)
                            {
                                stc_2.Children.Remove(champ2);
                                stc_2.Children.Remove(TextBox2);

                            }
                            champ1.Text = "BP :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BX+SI+DEP]")
                        {

                            champ2.Text = "BX :";
                            champ1.Text = "SI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BX+DI+DEP]")
                        {
                            champ2.Text = "BX :";
                            champ1.Text = "DI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BP+SI+DEP]")
                        {

                            champ2.Text = "BP :";
                            champ1.Text = "SI :";
                            champ3.Text = "CX :";

                        }
                        if (letter1 == "[BP+DI+DEP]")
                        {

                            champ2.Text = "BP :";
                            champ1.Text = "DI :";
                            champ3.Text = "CX :";

                        }
                    }

                }



                //if (letter2 == "Reg16/mem16")
                //{
                //    int columnIndex = Grid.GetColumn(grid_dep);
                //    if (columnIndex >= 0)
                //    {
                //        Grid5.Children.Remove(grid_dep);
                //    }
                //    int columnIndex1 = Grid.GetColumn(grid_ccm);
                //    if (columnIndex1 >= 0)
                //    {
                //        Grid5.Children.Remove(grid_ccm);
                //    }
                //    int columnIndex2 = Grid.GetColumn(stc_3);
                //    if (columnIndex2 >= 0)
                //    {
                //        stc_3.Children.Remove(champ3);
                //        stc_3.Children.Remove(TextBox3);
                //    }
                //}
            }
            //else if ((letter2 == "mem16")&& ((letter6 == "LOOP")|| (letter6 == "LOOPE") || (letter6 == "LOOPNE") || (letter6 == "LOOPZ")|| (letter6 == "LOOPNZ")))
            //{

            //    letter5 = Dep.SelectedItem.ToString();
            //    if (letter5 == "Sans deplacement")
            //    {
            //        int columnIndex = Grid.GetColumn(grid_dep);
            //        if (columnIndex >= 0)
            //        {
            //            Grid5.Children.Remove(grid_dep);
            //        }
            //        if (letter1 == "[DI]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0) 
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "DI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[SI]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0)
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "SI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BX]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0)
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "BX :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[Dep16]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0)
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "Dep16 :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BX+SI]")
            //        {

            //            champ2.Text = "BX :";
            //            champ1.Text = "SI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BX+DI]")
            //        {
            //            champ2.Text = "BX :";
            //            champ1.Text = "DI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BP+SI]")
            //        {

            //            champ2.Text = "BP :";
            //            champ1.Text = "SI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BP+DI]")
            //        {

            //            champ2.Text = "BP :";
            //            champ1.Text = "DI :";
            //            champ3.Text = "CX :";
            //        }

            //    }
            //    if (letter5 == "Avec deplacement")
            //    {
            //        if (letter1 == "[DI+DEP]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0)
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "DI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[SI+DEP]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0)
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "SI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BX+DEP]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0)
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "BX :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BP+DEP]")
            //        {
            //            int columnIndex1 = Grid.GetColumn(stc_2);
            //            if (columnIndex1 >= 0)
            //            {
            //                stc_2.Children.Remove(champ2);
            //                stc_2.Children.Remove(TextBox2);

            //            }
            //            champ1.Text = "BP :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BX+SI+DEP]")
            //        {

            //            champ2.Text = "BX :";
            //            champ1.Text = "SI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BX+DI+DEP]")
            //        {
            //            champ2.Text = "BX :";
            //            champ1.Text = "DI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BP+SI+DEP]")
            //        {

            //            champ2.Text = "BP :";
            //            champ1.Text = "SI :";
            //            champ3.Text = "CX :";

            //        }
            //        if (letter1 == "[BP+DI+DEP]")
            //        {

            //            champ2.Text = "BP :";
            //            champ1.Text = "DI :";
            //            champ3.Text = "CX :";

            //        }
            //    }



            //}
            Destinataire.IsEnabled = false;
        }





        private void componentSrc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string letter3;
            string letter1 = Format.SelectedItem.ToString();
            string letter2;
            string letter4; string letter5;



            if (Source.SelectedItem.ToString() != null)
            {
                if ((letter1 == "Reg16,Reg16/mem16") || (letter1 == "Reg16/mem16,Reg16"))
                {
                    letter2 = Reg.SelectedItem.ToString(); ;
                    if (letter1 == "Reg16/mem16,Reg16") { letter4 = Destinataire.SelectedItem.ToString(); letter3 = Source.SelectedItem.ToString(); }
                    else { letter3 = Destinataire.SelectedItem.ToString(); letter4 = Source.SelectedItem.ToString(); }
                    if (letter2 == " Memoire ")
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
                                champ3.Text = "DI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[SI]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ3.Text = "SI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BX]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ3.Text = "BX :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[Dep16]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ3.Text = "Dep16 :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BX+SI]")
                            {
                                champ2.Text = "BX :";
                                champ3.Text = "SI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BX+DI]")
                            {
                                champ2.Text = "BX :";
                                champ3.Text = "DI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BP+SI]")
                            {
                                champ2.Text = "BP :";
                                champ3.Text = "SI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BP+DI]")
                            {
                                champ2.Text = "BP :";
                                champ3.Text = "DI :";
                                champ1.Text = letter3 + " :";
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
                                champ3.Text = "DI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[SI+DEP]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ3.Text = "SI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BX+DEP]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ3.Text = "BX :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BP+DEP]")
                            {
                                int columnIndex1 = Grid.GetColumn(stc_2);
                                if (columnIndex1 >= 0)
                                {
                                    stc_2.Children.Remove(champ2);
                                    stc_2.Children.Remove(TextBox2);
                                }
                                champ3.Text = "BP :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BX+SI+DEP]")
                            {
                                champ2.Text = "BX :";
                                champ3.Text = "SI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BX+DI+DEP]")
                            {
                                champ2.Text = "BX :";
                                champ3.Text = "DI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BP+SI+DEP]")
                            {
                                champ2.Text = "BP :";
                                champ3.Text = "SI :";
                                champ1.Text = letter3 + " :";
                            }
                            if (letter4 == "[BP+DI+DEP]")
                            {
                                champ2.Text = "BP :";
                                champ3.Text = "DI :";
                                champ1.Text = letter3 + " :";
                            }

                        }
                    }
                    if (letter2 == " Registre ")
                    {
                        int columnIndex = Grid.GetColumn(grid_dep);
                        if (columnIndex >= 0)
                        {
                            Grid5.Children.Remove(grid_dep);
                        }
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

                        champ3.Text = Source.SelectedItem.ToString();
                        champ1.Text = Destinataire.SelectedItem.ToString();
                    }
                }
                //if (letter1 == " Reg ")
                //{
                //    int columnIndex2 = Grid.GetColumn(stc_3);
                //    if (columnIndex2 >= 0)
                //    {
                //        stc_3.Children.Remove(champ3);
                //        stc_3.Children.Remove(TextBox3);
                //    }
                //    champ1.Text = Source.SelectedItem.ToString();
                //}
            }




        }

        private void Actualiser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page2.xaml", UriKind.RelativeOrAbsolute));
        }


    }
}
