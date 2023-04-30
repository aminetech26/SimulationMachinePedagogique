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

namespace projet
{
    /// <summary>
    /// Interaction logic for Instruction_Ligne.xaml
    /// </summary>
    public partial class Instruction_Ligne : UserControl
    {
        public Instruction_Ligne()
        {
            InitializeComponent();
            // set the ItemsSource for ComboBox1
            List<string> options1 = new List<string>() { "Arithmetique", "Logique", "Decalage" , "Branchement", "Transfert", "Entree Sortie" };
            ComboBox1.Items.Clear();
            ComboBox1.ItemsSource = options1;

            // set the ItemsSource for ComboBox2
            List<string> options2 = new List<string>() ;
            ComboBox2.Items.Clear();
            ComboBox2.ItemsSource = options2;
            ComboBox2.IsEnabled = false;
            ComboBox3.IsEnabled = false;
            ComboBox4.IsEnabled = false;
            ComboBox5.IsEnabled = false;
            ComboBox6.IsEnabled = false;
            ComboBox7.IsEnabled = false;
        }


        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox1.SelectedItem as string;
            ComboBox2.IsEnabled = true;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "Arithmetique":
                    ComboBox2.ItemsSource = new List<string> { "ADD", "SUB", "MUL" , "INC", "DEC" };
                    break;
                case "Logique":
                    ComboBox2.ItemsSource = new List<string> { "NOT", "AND", "OR" , "XOR" };
                    break;
                case "Decalage":
                    ComboBox2.ItemsSource = new List<string> { "SHL", "SHR", "SAL" , "SAR", "ROR", "ROL" , "RCR", "RCL" };
                    break;
                case "Branchement":
                    ComboBox2.ItemsSource = new List<string> { "JMP", "LOOP", "LOOPZ" , "LOOPE", "LOOPNZ" , "LOOPNE", "CMP" };
                    break;
                case "Transfert":
                    ComboBox2.ItemsSource = new List<string> { "MOV", "XCHG" };
                    break;
                case "Entree Sortie":
                    ComboBox2.ItemsSource = new List<string> { "IN", "OUT", "INSW" , "OUTSW" };
                    break;
                
                default:
                    ComboBox2.ItemsSource = null;
                    break;
            }
        }


        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox2.SelectedItem as string;
            ComboBox3.IsEnabled = true;

            // Update the content of ComboBox3 based on the selected item in ComboBox2
            switch (selectedItem)
            {
                case "ADD" :
                case "SUB" :
                    ComboBox3.ItemsSource = new List<string> { "AX,imm16", "Reg16/Mem16,imm16" , "Reg16/Mem16,Reg16" , "Reg16,Reg16/Mem16" };
                    break;
                case "INC":
                case "DEC":
                    ComboBox3.ItemsSource = new List<string> { "Reg16", "Reg16/Mem16" };
                    break;
                case "MUL":
                    ComboBox3.ItemsSource = new List<string> { "Reg16" };
                    break;
                
                case "MOV":
                    ComboBox3.ItemsSource = new List<string> { "Reg16,imm16", "Reg16/Mem16,imm16", "Reg16/Mem16,Reg16", "Reg16,Reg16/Mem16" };
                    break;
                case "XCHG":
                    ComboBox3.ItemsSource = new List<string> { "AX,Reg16", "Reg16/Mem16,Reg16" , "Reg16,Reg16/Mem16" };
                    break;
                
                case "NOT":
                    ComboBox3.ItemsSource = new List<string> { "Reg16/Mem16" };
                    break;
                case "AND":
                    ComboBox3.ItemsSource = new List<string> { "Reg16/Mem16,imm16", "Reg16/Mem16,Reg16", "Reg16,Reg16/Mem16" };
                    break;
                case "OR":
                case "XOR":
                    ComboBox3.ItemsSource = new List<string> { "AX,imm16", "Reg16/Mem16,Reg16", "Reg16,Reg16/Mem16" , "Reg16,Mem16,imm16" };
                    break;

                case "SHR":
                case "SHL":
                case "SAR":
                case "SAL":
                case "ROR":
                case "ROL":
                case "RCR":
                case "RCL":
                    ComboBox3.ItemsSource = new List<string> { "Reg16/Mem16,imm16", "Reg16/Mem16,CX" };
                    break;

                case "IN":
                    ComboBox3.ItemsSource = new List<string> { "AX,DX" };
                    break;
                case "OUT":
                    ComboBox3.ItemsSource = new List<string> { "DX,AX" };
                    break;
                case "INSW":
                    ComboBox3.ItemsSource = new List<string> { "Mem16,DX" };
                    break;
                case "OUTSW":
                    ComboBox3.ItemsSource = new List<string> { "DX,Mem16" };
                    break;

                case "JMP":
                case "LOOP":
                case "LOOPZ":
                case "LOOPE":
                case "LOOPNZ":
                case "LOOPNE":
                    ComboBox3.ItemsSource = new List<string> { "Mem16" };
                    break;
                case "CMP":
                    ComboBox3.ItemsSource = new List<string> { "Reg16/Mem16,imm16", "Reg16/Mem16,Reg16", "Reg16,Reg16/Mem16" };
                    break;

                default:
                    ComboBox3.ItemsSource = null;
                    break;
            }
        }
        
        
        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox3.SelectedItem as string;
            ComboBox4.IsEnabled = true;

            // Update the content of ComboBox4 based on the selected item in ComboBox3
            switch (selectedItem)
            {
                case "Reg16/Mem16,imm16":
                case "Reg16,Reg16/Mem16":
                case "Reg16/Mem16,Reg16":
                case "Reg16/Mem16":
                case "Reg16/Mem16,CX":
                    ComboBox4.ItemsSource = new List<string> { "Registre" , "Memoire" };
                    break;

                case "Reg16":
                case "AX,Reg16":
                    ComboBox4.ItemsSource = new List<string> { "Registre" };
                    break;

                case "Mem16":
                case "Mem16,DX":
                case "DX,Mem16":
                    ComboBox4.ItemsSource = new List<string> { "Memoire" };
                    break;

                default:
                    ComboBox4.ItemsSource = null;
                    ComboBox4.IsEnabled = false;
                    break;
            }
        }
        
        
        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox4.SelectedItem as string;
            string? selectedItem_Format = ComboBox3.SelectedItem as string;

            // Update the content of ComboBox5 based on the selected item in ComboBox4
            switch (selectedItem)
            {
                case "Memoire":
                    ComboBox5.ItemsSource = new List<string> { "Avec deplacement", "Sans deplacement" };
                    ComboBox5.IsEnabled = true;
                    break;

                case "Registre":
                case null:
                    ComboBox5.ItemsSource = null;
                    ComboBox5.IsEnabled = false;
                    ComboBox6.IsEnabled = true;

                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,imm16":
                        case "Reg16/Mem16,Reg16":
                        case "Reg16,Reg16/Mem16":
                            ComboBox6.ItemsSource = new List<string> { "AX" , "BX" , "CX" , "DX" , "BP" , "SP" , "SI" , "DI" };
                            break;

                        case "Reg16/Mem16,CX":
                            ComboBox6.ItemsSource = new List<string> { "AX", "BX", "DX", "BP", "SP", "SI", "DI" };
                            ComboBox7.ItemsSource = new List<string> { "CX" };
                            break;

                        case "AX,Reg16":
                            ComboBox6.ItemsSource = new List<string> { "AX" };
                            ComboBox7.ItemsSource = new List<string> { "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            break;

                        case "AX,imm16":
                            ComboBox6.ItemsSource = new List<string> { "AX" };
                            break;

                        case "AX,DX":
                            ComboBox6.ItemsSource = new List<string> { "AX" };
                            ComboBox7.ItemsSource = new List<string> { "DX" };
                            break;

                        case "DX,AX":
                            ComboBox6.ItemsSource = new List<string> { "DX" };
                            ComboBox7.ItemsSource = new List<string> { "AX" };
                            break;

                        case "DX,Mem16":
                            ComboBox6.ItemsSource = new List<string> { "DX" };
                            break;

                        case "Reg16":
                            ComboBox6.IsEnabled = false;
                            ComboBox6.ItemsSource = null;
                            ComboBox7.IsEnabled = true;
                            ComboBox7.ItemsSource = new List<string> { "AX", "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            break;
                    }

                    break;
            }
        }


        private void ComboBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox5.SelectedItem as string;
            string? selectedItem_Format = ComboBox3.SelectedItem as string;
            ComboBox6.IsEnabled = true;

            // Update the content of ComboBox6 based on the selected item in ComboBox5
            switch (selectedItem)
            {
                case "Avec deplacement":

                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,imm16":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI+DEP]", "[BX+DI+DEP]", "[BP+SI+DEP]", "[BP+DI+DEP]", "[SI+DEP]", "[DI+DEP]", "[BX+DEP]", "[BP+DEP]" };
                            break;

                        case "Reg16/Mem16,Reg16":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI+DEP]", "[BX+DI+DEP]", "[BP+SI+DEP]" , "[BP+DI+DEP]" , "[SI+DEP]" , "[DI+DEP]" , "[BX+DEP]" , "[BP+DEP]" };
                            ComboBox7.ItemsSource = new List<string> { "AX", "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            break;

                        case "Mem16,DX":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI+DEP]", "[BX+DI+DEP]", "[BP+SI+DEP]", "[BP+DI+DEP]", "[SI+DEP]", "[DI+DEP]", "[BX+DEP]", "[BP+DEP]" };
                            ComboBox7.ItemsSource = new List<string> { "DX" };
                            break;

                        case "Reg16/Mem16,CX":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI+DEP]", "[BX+DI+DEP]", "[BP+SI+DEP]", "[BP+DI+DEP]", "[SI+DEP]", "[DI+DEP]", "[BX+DEP]", "[BP+DEP]" };
                            ComboBox7.ItemsSource = new List<string> { "CX" };
                            break;


                        case "Reg16,Reg16/Mem16":
                            ComboBox7.ItemsSource = new List<string> { "[BX+SI+DEP]", "[BX+DI+DEP]", "[BP+SI+DEP]", "[BP+DI+DEP]", "[SI+DEP]", "[DI+DEP]", "[BX+DEP]", "[BP+DEP]" };
                            ComboBox6.ItemsSource = new List<string> { "AX", "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            break;

                        case "Reg16/Mem16":
                        case "Mem16":
                            ComboBox6.ItemsSource = null;
                            ComboBox6.IsEnabled = false;
                            ComboBox7.IsEnabled = true;
                            ComboBox7.ItemsSource = new List<string> { "[BX+SI+DEP]", "[BX+DI+DEP]", "[BP+SI+DEP]", "[BP+DI+DEP]", "[SI+DEP]", "[DI+DEP]", "[BX+DEP]", "[BP+DEP]" };
                            break;

                        case "DX,Mem16":
                            ComboBox7.ItemsSource = new List<string> { "[BX+SI+DEP]", "[BX+DI+DEP]", "[BP+SI+DEP]", "[BP+DI+DEP]", "[SI+DEP]", "[DI+DEP]", "[BX+DEP]", "[BP+DEP]" };
                            break;
                    }

                    break;


                case "Sans deplacement":

                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,imm16":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[BX]", "[BP]" };
                            break;

                        case "Reg16/Mem16,Reg16":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[BX]", "[BP]" };
                            ComboBox7.ItemsSource = new List<string> { "AX", "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            break;

                        case "Mem16,DX":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[BX]", "[BP]" };
                            ComboBox7.ItemsSource = new List<string> { "DX" };
                            break;

                        case "Reg16/Mem16,CX":
                            ComboBox6.ItemsSource = new List<string> { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[BX]", "[BP]" };
                            ComboBox7.ItemsSource = new List<string> { "CX" };
                            break;


                        case "Reg16,Reg16/Mem16":
                            ComboBox7.ItemsSource = new List<string> { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[BX]", "[BP]" };
                            ComboBox6.ItemsSource = new List<string> { "AX", "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            break;

                        case "Reg16/Mem16":
                        case "Mem16":
                            ComboBox6.ItemsSource = null;
                            ComboBox6.IsEnabled = false;
                            ComboBox7.IsEnabled = true;
                            ComboBox7.ItemsSource = new List<string> { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[BX]", "[BP]" };
                            break;

                        case "DX,Mem16":
                            ComboBox7.ItemsSource = new List<string> { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[BX]", "[BP]" };
                            ComboBox6.ItemsSource = new List<string> { "DX" };
                            break;
                    }

                    break;

            }
        }


        private void ComboBox6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox6.SelectedItem as string;
            string? selectedItem_Format = ComboBox3.SelectedItem as string;
            string? selectedItem_Reg_M = ComboBox4.SelectedItem as string;
            ComboBox7.IsEnabled = true;

            // Update the content of ComboBox7 based on the selected item in ComboBox6
            switch (selectedItem)
            {
                case "AX":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            ComboBox7.IsEnabled = true;
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "BX", "CX", "DX", "BP", "SP", "SI", "DI" };
                                    break;
                            }

                            break;

                        case "Reg16/Mem16,imm16":
                        case "AX,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;                            

                            break;

                    }
                    break;

                case "BX":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BP", "SP", "SI", "DI" };
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BP", "SP", "SI", "DI" };
                                    break;
                            }
                            break;

                        case "Reg16/Mem16,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;

                            break;

                    }
                    break;

                case "CX":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "AX", "BX", "DX", "BP", "SP", "SI", "DI" };
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "AX", "BX", "DX", "BP", "SP", "SI", "DI" };
                                    break;
                            }
                            break;

                        case "Reg16/Mem16,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;

                            break;
                    }
                    break;

                case "DX":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "AX", "CX", "BX", "BP", "SP", "SI", "DI" };
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "AX", "CX", "BX", "BP", "SP", "SI", "DI" };
                                    break;
                            }
                            break;

                        case "Reg16/Mem16,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;

                            break;
                    }
                    break;

                case "BP":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BX", "SP", "SI", "DI" };
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BX", "SP", "SI", "DI" };
                                    break;
                            }

                            break;
                        case "Reg16/Mem16,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;

                            break;
                    }
                    break;

                case "SP":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BX", "BP", "SI", "DI" };
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BX", "BP", "SI", "DI" };
                                    break;
                            }

                            break;
                        case "Reg16/Mem16,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;

                            break;
                    }
                    break;

                case "DI":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BP", "SP", "SI", "BX" };
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BP", "SP", "SI", "BX" };
                                    break;
                            }

                            break;
                        case "Reg16/Mem16,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;

                            break;
                    }
                    break;

                case "SI":
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,Reg16":
                            ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BP", "SP", "BX", "DI" };
                            break;

                        case "Reg16,Reg16/Mem16":

                            switch (selectedItem_Reg_M)
                            {
                                case "Registre":
                                    ComboBox7.ItemsSource = new List<string> { "AX", "CX", "DX", "BP", "SP", "BX", "DI" };
                                    break;
                            }

                            break;
                        case "Reg16/Mem16,imm16":

                            ComboBox7.ItemsSource = null;
                            ComboBox7.IsEnabled = false;

                            break;
                    }
                    break;

                case null :
                    ComboBox7.IsEnabled = true;
                    break;

                default :
                    switch (selectedItem_Format)
                    {
                        case "Reg16/Mem16,imm16":
                            ComboBox7.IsEnabled = false;
                            ComboBox7.ItemsSource = null;
                            break;
}
                    break;
            }
        }


        private void ComboBox7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox7.SelectedItem as string;
            ComboBox7.IsEnabled = true;

            switch (selectedItem)
            { 
                case null :
                    ComboBox7.IsEnabled = false;
                    break;
                
                    default: 
                        ComboBox7.IsEnabled = true;
                    break;
            
            }


            }

    }
}
