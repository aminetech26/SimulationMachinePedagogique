using ArchiMind;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logique d'interaction pour ExecutionProgramme.xaml
    /// </summary>
    public partial class ExecutionProgramme : Page
    {
        public static List<Instruction> programInst;
        public ExecutionProgramme(List<Instruction> programInstructions)
        {

            InitializeComponent();

            // Create a list of objects that represent the data for each row
            List<Inst_Mnemo> dataList = new List<Inst_Mnemo>();
            foreach(Instruction inst in programInstructions)
            {
                dataList.Add(new Inst_Mnemo { InstructionMnemonique = convertir_instruction_Lmnemonique(inst) });

            }

            
            // Set the ItemsSource property of the DataGrid to the list of objects
            dataGrid1.ItemsSource = dataList;
            dataGrid1.SelectedIndex = 0;
            // Set the first cell as the focused cell

            programInst = new List<Instruction>(programInstructions); // Initialize the programInst field

            //-------------------------
            AX.Text = Registre.getAx() ;
            BX.Text = Registre.getBx() ;
            CX.Text = Registre.getCx() ;
            DX.Text = Registre.getDx() ;
            SI.Text = Registre.getSi() ;
            DI.Text = Registre.getDi() ;
            SP.Text = Registre.getSp() ;
            BP.Text = Registre.getBp() ;
            CO.Text = "0100";
            RAM.Text = "0100";
        }
        public class Inst_Mnemo
        {
            public string InstructionMnemonique { get; set; }
        }

        private void Button_Go_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                if (e.NewSize.Width >= 1000)
                {
                    //dataGrid1.Width = 350 ;
                }
                else
                {
                    //dataGrid1.Width = 250;

                }

        }

        //---------------------------------------------------------------------------

        public string convertir_instruction_Lmnemonique(Instruction instruction)
        {
            string my_instruction = "";
            return instruction.getMnemonique() + " " + convertir_First_part(instruction) + convertir_Second_part(instruction);
        }
        // ---------------------------------------------------------------------------------
        public string convertir_First_part(Instruction instruction)   // we consider INST First_part,Second_part
        {
            string my_first_part = "";
            switch (instruction.getFormat())
            {
                case "AX,DX":
                case "AX,imm16":
                case "AX,Reg16":
                    my_first_part = "AX";
                    break;
                case "DX,AX":
                case "DX,Mem16":
                    my_first_part = "DX";
                    break;
                case "Reg16/Mem16,imm16":
                case "Reg16/Mem16":
                case "Reg16/Mem16,CX":
                case "Reg16/Mem16,Reg16":
                    my_first_part = case_reg_mem(instruction);
                    break;
                case "Reg16,Reg16/Mem16":
                case "Reg16,imm16":
                case "Reg16":
                    my_first_part = case_reg(instruction);
                    break;
                case "Mem16,DX":
                case "Mem16":
                    my_first_part = case_mem(instruction);
                    break;
                default:
                    my_first_part = "";
                    break;
            }
            return my_first_part;
        }
        // --------------------------------
        public string case_reg_mem(Instruction instruction)  // if it was reg or mem
        {
            if (instruction.getmem())
            {
                return case_mem(instruction);
            }
            else // case of register {AX,BX ...}
            {
                return case_reg(instruction);
            }
        }
        // -------------------------------------
        public string case_reg(Instruction instruction) // Inst reg, ....
        {
            return instruction.getDestination();
        }
        //--------------------------------------
        public string case_mem(Instruction instruction)
        { // Inst mem, ....
            if (instruction.getifdepl())
            {
                return instruction.getDestination().Replace("DEP", instruction.getValDepl());
            }
            else
            {
                return instruction.getDestination();
            }
        }
        //----------------------------------------------------------
        public string convertir_Second_part(Instruction instruction)
        {
            string my_second_part = "";
            switch (instruction.getFormat())
            {
                case "AX,DX":
                case "Mem16,DX":
                    my_second_part = ",DX";
                    break;
                case "DX,AX":
                    my_second_part = ",AX";
                    break;
                case "Reg16/Mem16,CX":
                    my_second_part = ",CX";
                    break;
                case "Reg16,Reg16/Mem16":
                    my_second_part = "," + src_case_reg_mem(instruction);
                    break;
                case "DX,Mem16":
                    my_second_part = "," + src_case_mem(instruction);
                    break;
                case "Reg16/Mem16":
                case "Reg16":
                case "Mem16":
                    my_second_part = "";
                    break;
                case "AX,imm16":
                case "Reg16/Mem16,imm16":
                case "Reg16,imm16":
                    my_second_part = "," + instruction.getval_imm16();
                    break;
                case "AX,Reg16":
                case "Reg16/Mem16,Reg16":
                    my_second_part = "," + src_case_reg(instruction);
                    break;
                default:
                    my_second_part = "";
                    break;
            }
            return my_second_part;
        }
        // ----------------------------------------
        public string src_case_reg_mem(Instruction instruction)
        {
            if (instruction.getmem())
            {
                return src_case_mem(instruction);
            }
            else // case of register {AX,BX ...}
            {
                return src_case_reg(instruction);
            }
        }
        // -------------------------------------
        public string src_case_reg(Instruction instruction) // Inst reg, ....
        {
            return instruction.getSource();
        }
        //--------------------------------------
        public string src_case_mem(Instruction instruction)
        { // Inst mem, ....
            if (instruction.getifdepl())
            {
                return instruction.getSource().Replace("DEP", instruction.getValDepl());
            }
            else
            {
                return instruction.getSource();
            }
        }

        //---------------------------------------------------------------------------
        public static int nbMemWordsToFill(List<Instruction> programInstructions)
        {
            int result = 0;
            foreach (Instruction inst in programInstructions)
            {
                if (inst.getmem() == true)
                {//means memoire -- que les instructions qui solicitent la memoire deplacement ou sans
                    result++;
                }
            }
            return result;
        }
        public static bool IsHexCharacter(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
        }
        
        
        internal static List<Case> casesToFill(List<Instruction> programInstructions)
        {
            List<Case> casesToFill = new List<Case>();
            List<string> adresses = new List<string>();
            Case caseToFill = new Case();
            try
            {
                string filePath = "hexaFile.txt";
                string hexContent = File.ReadAllText(filePath).Replace(" ", "");
                int count = 0;
                foreach (char c in hexContent)
                {
                    if (IsHexCharacter(c))
                    {
                        count++;
                    }
                }
                int nbMemWords = count / 4;
                ushort startAdress = 0x0100;
                ushort endAdress = startAdress;
                for (int i = 0; i < nbMemWords; i++)
                {

                    endAdress++;
                }

                for (int i = 0; i < nbMemWordsToFill(programInstructions); i++)
                {
                    string hexAddress = endAdress.ToString("X4");
                    adresses.Add(hexAddress);
                    caseToFill = new Case();
                    caseToFill.setAdr(hexAddress);
                    casesToFill.Add(caseToFill);
                    endAdress++;
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            return casesToFill;
        }
        //-------------------------------------------------------------------------------------
        internal static List<Case> construction_MC(List<Instruction> programInstruction)
        {
            List<Case> memoire_centrale = new List<Case>();
            Case motMem = new Case();
            ushort adresse = 0x0100; //adresse debut code segment
            //convert programInstruction to HexFile
            //chaque ligne represente un mot memoire
            string[] contenuMotsMemoires = File.ReadAllLines("pathtoHexFile.txt");
            foreach (string contenuMotMemoire in contenuMotsMemoires)
            {
                motMem.setAdr(adresse.ToString("X4"));
                motMem.setContenu(contenuMotMemoire);
                memoire_centrale.Add(motMem);
            }
            return memoire_centrale;
        }
        // --------------------------------------------------------------------------------
        public static void executer_programme(List<Instruction> programInstructions)
        {
            //initialisation du contexte -- registre et memoire centrale.
            ArrayList registres = new ArrayList() { "AX", "BX", "CX", "DX", "SI", "DI", "BP", "SP" };
            foreach (string registre in registres)
            {
                //Registre.setContenuRegistre(registre,GridNameWella.TextBox.Text);
            }
            //initialiser mc -- methode a creer
            MC.setMc(construction_MC(programInstructions));
            //------------------------------------------------------------------------
            foreach (Instruction inst in programInstructions)
            {
                if (inst.getmem() == true)
                {
                    string dest = inst.getDestination();
                    string src = inst.getSource();
                    if (dest[0] == '[')
                    {
                        string adresse;
                        if (inst.getifdepl() == true)
                        {
                            adresse = UAL.calculAdresse(dest, inst.getifdepl(), inst.getValDepl());
                        }
                        else
                        {
                            adresse = UAL.calculAdresse(dest, inst.getifdepl());
                        }
                    }
                    else //m3netha source li fiha lcalcul
                    {
                        string adresse;
                        if (inst.getifdepl() == true)
                        {
                            adresse = UAL.calculAdresse(src, inst.getifdepl(), inst.getValDepl());
                        }
                        else
                        {
                            adresse = UAL.calculAdresse(src, inst.getifdepl());
                        }
                    }
                }
                //executer_simulation_phase_a_phase("programme", inst.getMnemonique(), inst.getFormat(), inst.getmem(), inst.getDestination(), inst.getValDepl(), inst.getSource(), inst.getifdepl());//getValImm16
            }
        }

        //-----------------------------------------------------------------------------------

    }
}
