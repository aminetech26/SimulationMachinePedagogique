using ArchiMind;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Page_EntreeSortie.xaml
    /// </summary>
    public partial class Page_EntreeSortie : Page
    {
        private Page_EntreeSortie mainpage;
        public Page_EntreeSortie()
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
            ComboBoxItem selectedItem = Instruction.SelectedItem as ComboBoxItem;

            string Forma; string deplace; bool ifdepl;
            string letter = Format.SelectedItem.ToString();
            string destinatair = "";
            if ((letter != "AX,imd16") && (letter != "Reg16")&&(letter!="AX,DX")) { destinatair = Destinataire.SelectedItem.ToString(); }
            string source = "XXXX";
            if (Source.SelectedItem != null) { source = Source.SelectedItem.ToString(); }
            string Registr = "";
            if ((letter != "AX,imd16") && (letter != "Reg16") && (letter != "AX,DX")) { Registr = Reg.SelectedItem.ToString(); }
            if ((Registr == " Registre ") || (letter == "AX,imd16") || (letter == "Reg16")|| (letter == "AX,DX")) { deplace = "0000"; }
            else { deplace = Dep.SelectedItem.ToString(); }
            if (deplace == "Avec deplacement") { ifdepl = true; }
            else { ifdepl = false; }
            JeuxInstruction instruction = new JeuxInstruction();


            MainWindow wind = new MainWindow(sender, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox4.Text, selectedItem.Content.ToString(), letter, Registr, "0000", destinatair, source, champ1.Text, champ2.Text, champ3.Text);

        }
        string i;
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
                if (selectedItem.Content.ToString() == "IN")
                {
                    Format.Items.Clear();
                    Format.Items.Add("AX,DX");

                }
                else if (selectedItem.Content.ToString() == "OUT")
                {
                    Format.Items.Clear();
                    Format.Items.Add("DX,Mem16");

                }
                else if (selectedItem.Content.ToString() == "INSW")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Mem , Reg");
                }
                else if (selectedItem.Content.ToString() == "OUTSW")
                {
                    Format.Items.Clear();
                    Format.Items.Add("Reg , Mem");
                }
            }
        }


        private void componentFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string letter = Format.SelectedItem.ToString();

            // Show the components for the selected option
            if (letter != null)
            {

                if (string.Compare(letter, "AX,DX") == 0)
                {
                    int columnIndex2 = Grid.GetColumn(stkDep);

                    // Check if the column index is greater than or equal to zero
                    if (columnIndex2 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(2);
                        StackPanel1.Children.Remove(stkDep);
                    }

                    int columnIndex3 = Grid.GetColumn(stkReg);
                    if (columnIndex3 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(3);
                        StackPanel1.Children.Remove(stkReg);
                    }
                    int columnIndex6 = Grid.GetColumn(stkDes);
                    if (columnIndex6 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(3);
                        StackPanel1.Children.Remove(stkDes);
                    }

                    int columnIndex4 = Grid.GetColumn(grid_dep);
                    if (columnIndex4 >= 0)
                    {
                        Grid5.Children.Remove(grid_dep);
                    }

                    int columnIndex5 = Grid.GetColumn(grid_ccm);
                    if (columnIndex5 >= 0)
                    {
                        Grid5.Children.Remove(grid_ccm);
                    }

                    int columnIndex7 = Grid.GetColumn(stc_3);
                    if (columnIndex7 >= 0)
                    {
                        StackPanel2.Children.Remove(stc_3);
                    }
                    int columnIndex8 = Grid.GetColumn(stc_2);
                    if (columnIndex8 >= 0)
                    {
                        StackPanel2.Children.Remove(stc_2);
                    }

                    champ1.Text = "Valeur Entrer :";
              

            
                    Source.Items.Clear();
                    Source.Items.Add("DX");

                } 
                if (string.Compare(letter, "DX, AX") == 0)
                {
                        int columnIndex2 = Grid.GetColumn(stkDep);

                        // Check if the column index is greater than or equal to zero
                        if (columnIndex2 >= 0)
                        {
                            // StackPanel1.ColumnDefinitions.RemoveAt(2);
                            StackPanel1.Children.Remove(stkDep);
                        }

                        int columnIndex3 = Grid.GetColumn(stkReg);
                        if (columnIndex3 >= 0)
                        {
                            // StackPanel1.ColumnDefinitions.RemoveAt(3);
                            StackPanel1.Children.Remove(stkReg);
                        }

                        int columnIndex4 = Grid.GetColumn(grid_dep);
                        if (columnIndex4 >= 0)
                        {
                            Grid5.Children.Remove(grid_dep);
                        }

                        int columnIndex5 = Grid.GetColumn(grid_ccm);
                        if (columnIndex5 >= 0)
                        {
                            Grid5.Children.Remove(grid_ccm);
                        }

                        int columnIndex6 = Grid.GetColumn(stc_3);
                        if (columnIndex5 >= 0)
                        {
                            StackPanel2.Children.Remove(stc_3);
                        }

                        champ1.Text = "AX :";
                        champ2.Text = "DX :";

                        Destinataire.Items.Clear();
                        Destinataire.Items.Add("DX");
                        Source.Items.Clear();
                        Source.Items.Add("AX");

                }
                

                if (string.Compare(letter, "Mem , Reg") == 0)
                {
                    int columnIndex2 = Grid.GetColumn(stkDep);

                    // Check if the column index is greater than or equal to zero
                    if (columnIndex2 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(2);
                        StackPanel1.Children.Remove(stkDep);
                    }

                    int columnIndex3 = Grid.GetColumn(stkReg);
                    if (columnIndex3 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(3);
                        StackPanel1.Children.Remove(stkReg);
                    }

                    int columnIndex4 = Grid.GetColumn(grid_dep);
                    if (columnIndex4 >= 0)
                    {
                        Grid5.Children.Remove(grid_dep);
                    }

                    int columnIndex5 = Grid.GetColumn(grid_ccm);
                    if (columnIndex5 >= 0)
                    {
                        Grid5.Children.Remove(grid_ccm);
                    }

                    int columnIndex6 = Grid.GetColumn(stc_3);
                    if (columnIndex5 >= 0)
                    {
                        StackPanel2.Children.Remove(stc_3);
                    }

                    champ1.Text = "DI :";
                    champ2.Text = "DX :";

                    Destinataire.Items.Clear();
                    Destinataire.Items.Add("DI");
                    Source.Items.Clear();
                    Source.Items.Add("DX");

                }

                if (string.Compare(letter, "Reg , Mem") == 0)
                {

                    int columnIndex2 = Grid.GetColumn(stkDep);

                    // Check if the column index is greater than or equal to zero
                    if (columnIndex2 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(2);
                        StackPanel1.Children.Remove(stkDep);
                    }

                    int columnIndex3 = Grid.GetColumn(stkReg);
                    if (columnIndex3 >= 0)
                    {
                        // StackPanel1.ColumnDefinitions.RemoveAt(3);
                        StackPanel1.Children.Remove(stkReg);
                    }

                    int columnIndex4 = Grid.GetColumn(grid_dep);
                    if (columnIndex4 >= 0)
                    {
                        Grid5.Children.Remove(grid_dep);
                    }

                    int columnIndex5 = Grid.GetColumn(grid_ccm);
                    if (columnIndex5 >= 0)
                    {
                        Grid5.Children.Remove(grid_ccm);
                    }

                    int columnIndex6 = Grid.GetColumn(stc_3);
                    if (columnIndex5 >= 0)
                    {
                        StackPanel2.Children.Remove(stc_3);
                    }

                    champ1.Text = "DX :";
                    champ2.Text = "SI :";

                    Destinataire.Items.Clear();
                    Destinataire.Items.Add("DX");
                    Source.Items.Clear();
                    Source.Items.Add("SI");

                }


            }

            Instruction.IsEnabled = false;
            Reg.Items.Clear();
            Dep.Items.Clear();

        }


        private void componentReg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void componentDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void componentDes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }


        private void componentSrc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Actualiser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/PageEntree_Sortie1.xaml", UriKind.RelativeOrAbsolute));
        }

       
    }
}
