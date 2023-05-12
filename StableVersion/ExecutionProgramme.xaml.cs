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
        //******************************************************************************************************//

        List<string> conseils = new List<string>()
        {
            "Utiliser des commentaires pour documenter le code.",
            "Utiliser des étiquettes pour référencer des adresses.",
            "Utiliser des macros pour simplifier le code.",
            "Utiliser des sous-programmes pour réutiliser le code.",
            "Optimiser le code pour améliorer les performances.",
            "Éviter les instructions longues.",
            "Utiliser des opérateurs bit à bit pour manipuler les données binaires.",
            "Éviter les instructions de saut inconditionnel pour améliorer la lisibilité du code.",
            "Utiliser les instructions les plus rapides pour les tâches les plus courantes.",
            "Éviter les opérations arithmétiques inutiles en utilisant les opérations de décalage pour les multiplications et les divisions par 2.",
            "Utiliser les directives d'assemblage pour spécifier la taille et l'alignement des données.",
            "Utiliser les instructions de comparaison pour éviter les erreurs d'arithmétique.",
            "Utiliser les instructions de déplacement de données pour optimiser les transferts de données.",
            "Éviter les instructions de chargement de données redondantes.",
            "Éviter l'utilisation de registres de trop grande taille pour économiser de la mémoire.",
            "Utiliser des structures de contrôle pour rendre le code plus lisible et compréhensible.",
        };

        //******************************************************************************************************//

        public static ExecutionProgramme instance;
        public static List<Instruction> programInst;
        public ExecutionProgramme(List<Instruction> programInstructions)
        {

            InitializeComponent();
            instance = this;
            JeuxInstruction.setContextProgram(instance); 
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
            Co.setco("0100");
            MC.setRam("0100");
            
            
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
        }//
        private static async void format_reg_regOUmem(string mnemonique, string format, bool mem_b, string distinataire, bool ifdepl, string valdepl, string contenueCaseMemoire, string source, string val1, string val2, string val3  )
        {


            // le contenue de distinataire est toujour dans ual1
            string adresse = "";
            string result = "";
            if (mem_b)
            { //reg16,mem16
                if (ifdepl)
                {
                    switch (source)
                    {
                        case "[BX+SI+depl]":
                            Registre.setContenuRegistre("BX", val2);
                            Registre.setContenuRegistre("SI", val3);
                            break;
                        case "[BX+DI+depl]":
                            Registre.setContenuRegistre("BX", val2);
                            Registre.setContenuRegistre("DI", val3);
                            break;
                        case "[BP+SI+depl]":
                            Registre.setContenuRegistre("BP", val2);
                            Registre.setContenuRegistre("SI", val3);
                            break;
                        case "[BP+DI+depl]":
                            Registre.setContenuRegistre("BP", val2);
                            Registre.setContenuRegistre("DI", val3);
                            break;
                        case "[SI+depl]":
                            Registre.setContenuRegistre("SI", val2);
                            break;
                        case "[DI+depl]":
                            Registre.setContenuRegistre("DI", val2);
                            break;
                        case "[BP+depl]":
                            Registre.setContenuRegistre("BP", val2);
                            break;
                        case "[BX+depl]":
                            Registre.setContenuRegistre("BX", val2);
                            break;
                        default:
                            System.Console.WriteLine("Error ! no such mem_depl");
                            break;
                    }
                }
                else
                {
                    switch (source)
                    {
                        case "[BX+SI]":
                            Registre.setContenuRegistre("BX", val2);
                            Registre.setContenuRegistre("SI", val3);
                            break;
                        case "[BX+DI]":
                            Registre.setContenuRegistre("BX", val2);
                            Registre.setContenuRegistre("DI", val3);
                            break;
                        case "[BP+SI]":
                            Registre.setContenuRegistre("BP", val2);
                            Registre.setContenuRegistre("SI", val3);
                            break;
                        case "[BP+DI]":
                            Registre.setContenuRegistre("BP", val2);
                            Registre.setContenuRegistre("DI", val3);
                            break;
                        case "[SI]":
                            Registre.setContenuRegistre("SI", val2);
                            break;
                        case "[DI]":
                            Registre.setContenuRegistre("DI", val2);
                            break;
                        case "[BP]":
                            Registre.setContenuRegistre("BP", val2);
                            break;
                        case "[BX]":
                            Registre.setContenuRegistre("BX", val2);
                            break;
                        default:
                            System.Console.WriteLine("Error ! no such mem_depl");
                            break;
                    }
                }
                adresse = UAL.calculAdresse(source, ifdepl, valdepl);
                // animation(ual,ram,adresse) ; 
                MC.setRim(contenueCaseMemoire);
                UAL.setUal2(MC.getRim());
                Registre.setContenuRegistre(distinataire, val1);
                UAL.setUal1(Registre.getContenuRegistre(distinataire));
                string resultf;
                switch (mnemonique)
                {
                    //add , sub ,mov, xchg ,and , or ,xor ,cmp
                    case "ADD":
                        //  result = ccm + contenue de registre ; 
                        result = (Convert.ToInt32(UAL.getUal1(), 16) + Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        JeuxInstruction.SetInt(result);
                        resultf = JeuxInstruction.GetInt();
                        // positionner les flags 
                        break;
                    case "SUB":
                        result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        JeuxInstruction.SetInt(result);
                        resultf = JeuxInstruction.GetInt();
                        break;
                    case "MOV": // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                        result = UAL.getUal2();
                        JeuxInstruction.SetInt(result);
                        resultf = JeuxInstruction.GetInt();
                        break;
                    case "XCHG": // ANIMATION PARTICULIER  
                        JeuxInstruction.SetInt(result);
                        resultf = JeuxInstruction.GetInt();
                        break;
                    case "AND":
                        result = (Convert.ToInt32(UAL.getUal1(), 16) & Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        JeuxInstruction.SetInt(result);
                        resultf = JeuxInstruction.GetInt();
                        break;
                    case "OR":
                        result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        JeuxInstruction.SetInt(result);
                        resultf = JeuxInstruction.GetInt();
                        break;
                    case "XOR":
                        result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        JeuxInstruction.SetInt(result);
                        resultf = JeuxInstruction.GetInt();
                        break;
                }
                UAL.positionnerIndicateurs(mnemonique, result, UAL.getUal1(), UAL.getUal2());
                string r = JeuxInstruction.GetInt();
                MC.setRim(result);
                // vu que xchng a une animation particulier on va la traiter dans le switch
                if (mnemonique == "XCHG") { }
            }
            else
            {

                Registre.setContenuRegistre(distinataire, val1);
                Registre.setContenuRegistre(source, val2);
                UAL.setUal2(Registre.getContenuRegistre(source));
                UAL.setUal1(Registre.getContenuRegistre(distinataire));
                // animation(reg,ual1,donne);
                //Registre to ual1  
                int r; int r1;
                r = Convert.ToInt32(UAL.getUal1(), 16);
                r1 = Convert.ToInt32(UAL.getUal2(), 16);
                switch (mnemonique)
                {
                    //add , sub ,mov, xchg ,and , or ,xor ,cmp
                    case "ADD":
                        //  result = ccm + contenue de registre ; 
                        result = (r + r1).ToString("X4");
                        JeuxInstruction.SetInt(result);
                        // positionner les flags 
                        break;
                    case "SUB":
                        result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        break;
                    case "MOV": // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                        result = UAL.getUal2();
                        break;
                    case "XCHG": // ANIMATION PARTICULIER  
                        break;
                    case "AND":
                        result = (r & r1).ToString("X4");
                        JeuxInstruction.SetInt(result);
                        break;
                    case "OR":
                        result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        break;
                    case "XOR":
                        result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                        break;
                }
                // sortie to registr
                UAL.positionnerIndicateurs(mnemonique, result, UAL.getUal1(), UAL.getUal2());
                Registre.setContenuRegistre(distinataire, result);
                JeuxInstruction.SetInt(result);
                 }
               }
        private static async void format_ax_reg(string mnenmonique, string source, string valAx, string valsource, string format, bool RegM)
        {
            Registre.setAx(valAx);
            Registre.setContenuRegistre(source, valsource);
            UAL.setUal1(Registre.getAx());
            UAL.setUal2(Registre.getContenuRegistre(source));
            Registre.setAx(UAL.getUal2());
            Registre.setContenuRegistre(source, UAL.getUal1());
            JeuxInstruction.SetInt(Registre.getContenuRegistre(source));
            switch (mnenmonique)
            {
                //xchg , 
                case "XCHG":
                    // animation (ual , registre , donne )
                    UAL.positionnerIndicateurs(mnenmonique);
                    // animation (ual,registre , donne ); 
                    break;
                default:
                    Console.WriteLine("il ya un erreur");
                    break;
            }
        }
        private static async void format_ax_imm16(string mnemonique, string valAx, string valImmediate16, string format, bool RegM)
        {
            // ici je vais faire un petite bloc du code pour intialisé la 2eme case de la memoire par la valeur immidiate
            Case case_memoire = new Case();
            // case_memoire = MC.recherche_mc("0101");
            //case_memoire.setContenu(valImmediate16);
            case_memoire.setAdr("0101");
            // MC.AjouterCase(Convert.ToInt32("0101",16),case_memoire); 
            // fin de l'intialisation 
            Registre.setAx(valAx);
            Co.incCo();
            MC.setRam(Co.getco());
            //  case_memoire = MC.recherche_mc(Co.getco());
            // MC.setRim(case_memoire.getContenu());
            UAL.setUal1(Registre.getAx());
            UAL.setUal2(MC.getRim());
            string result = "";
            string r = UAL.getUal1();
            string r1 = UAL.getUal2();
            switch (mnemonique)
            {

                //ADD , SUB , OR , XOR 
                case "ADD":
                    //  result = ccm + contenue de registre ; 
                    result = (Convert.ToInt32(UAL.getUal1(), 16) + Convert.ToInt32(valImmediate16, 16)).ToString("X4");
                    Registre.setAx(result);
                    // positionner les flags 
                    break;
                case "SUB":
                    result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                    Registre.setAx(result);
                    break;
                case "OR":
                    result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");

                    Registre.setAx(result);
                    break;
                case "XOR":
                    result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                    Registre.setAx(result);
                    break;
            }
            // animation (UAL,registre,donne );
            UAL.positionnerIndicateurs(mnemonique, result, r, r1);
         }
        private static async void format_reg16(string mnemonique, string reg, string valReg,string format, bool RegM)
        {
            //inc , dec 

            Registre.setContenuRegistre(reg, valReg);
            string result = "";
            UAL.setUal1(Registre.getContenuRegistre(reg));
            int hexInt;
            switch (mnemonique)
            {
                case "INC":
                    hexInt = Convert.ToInt32(UAL.getUal1(), 16);
                    hexInt++;
                    result = hexInt.ToString("X4").ToUpper();
                    JeuxInstruction.SetInt(result);

                    break;
                case "DEC":
                    hexInt = Convert.ToInt32(UAL.getUal1(), 16);
                    hexInt--;
                    result = hexInt.ToString("X4").ToUpper();
                    JeuxInstruction.SetInt(result);
                    break;
                default:
                    Console.WriteLine("erreur");
                    break;
            }
            // positionner les indicateurs 
            UAL.positionnerIndicateurs(mnemonique, result);
            // animation (ual,registre,donne); 
            // ual to registr
            Registre.setContenuRegistre(reg, result);
        }
        private static async void format_reg16_imm16(string mnemonique, string reg, string valReg, string valImm16, string format, bool RegM)
        {
            // ici je vais faire un petite bloc du code pour intialisé la 2eme case de la memoire par la valeur immidiate
            Case case_memoire = new Case();
            // case_memoire = MC.recherche_mc("0101");
            // case_memoire.setContenu(valImm16);
            case_memoire.setAdr("0101");
            //MC.AjouterCase(Convert.ToInt32("0101", 16), case_memoire);
            // ----------------------------------//
            Registre.setContenuRegistre(reg, valReg);
            // animation(registre,UAL1,donne); 
            UAL.setUal1(Registre.getContenuRegistre(reg));
            Co.incCo();
            MC.setRam(Co.getco());
            // case_memoire = MC.recherche_mc(Co.getco());
            //MC.setRim(case_memoire.getContenu());
            UAL.setUal2(MC.getRim());
            string result = "";
            string r = UAL.getUal1();
            string r1 = UAL.getUal2();
            switch (mnemonique)
            {
                case "MOV":
                    result = UAL.getUal2();
                    JeuxInstruction.SetInt(result);
                    break;
                default:
                    Console.WriteLine("Erreur");
                    break;
            }
            // positionner les indicateurs 
            UAL.positionnerIndicateurs(mnemonique, result);

        }
        private static async void format_dx_mem16(string mnemonique, string ccm, string mem, bool ifdepl, string valDepl, string valdx, string valmem1, string valmem2)
        {
            string adresse = "";
            string result = "";
            Registre.setDx(valdx);
            if (ifdepl)
            {
                switch (mem)
                {
                    case "[BX+SI+depl]":
                        Registre.setContenuRegistre("BX", valmem1);
                        Registre.setContenuRegistre("SI", valmem2);
                        break;
                    case "[BX+DI+depl]":
                        Registre.setContenuRegistre("BX", valmem1);
                        Registre.setContenuRegistre("DI", valmem2);
                        break;
                    case "[BP+SI+depl]":
                        Registre.setContenuRegistre("BP", valmem1);
                        Registre.setContenuRegistre("SI", valmem2);
                        break;
                    case "[BP+DI+depl]":
                        Registre.setContenuRegistre("BP", valmem1);
                        Registre.setContenuRegistre("DI", valmem2);
                        break;
                    case "[SI+depl]":
                        Registre.setContenuRegistre("SI", valmem1);
                        break;
                    case "[DI+depl]":
                        Registre.setContenuRegistre("DI", valmem1);
                        break;
                    case "[BP+depl]":
                        Registre.setContenuRegistre("BP", valmem1);
                        break;
                    case "[BX+depl]":
                        Registre.setContenuRegistre("BX", valmem1);
                        break;
                    default:
                        System.Console.WriteLine("Error ! no such mem_depl");
                        break;
                }
            }
            else
            {
                switch (mem)
                {
                    case "[BX+SI]":
                        Registre.setContenuRegistre("BX", valmem1);
                        Registre.setContenuRegistre("SI", valmem2);
                        break;
                    case "[BX+DI]":
                        Registre.setContenuRegistre("BX", valmem1);
                        Registre.setContenuRegistre("DI", valmem2);
                        break;
                    case "[BP+SI]":
                        Registre.setContenuRegistre("BP", valmem1);
                        Registre.setContenuRegistre("SI", valmem2);
                        break;
                    case "[BP+DI]":
                        Registre.setContenuRegistre("BP", valmem1);
                        Registre.setContenuRegistre("DI", valmem2);
                        break;
                    case "[SI]":
                        Registre.setContenuRegistre("SI", valmem1);
                        break;
                    case "[DI]":
                        Registre.setContenuRegistre("DI", valmem1);
                        break;
                    case "[BP]":
                        Registre.setContenuRegistre("BP", valmem1);
                        break;
                    case "[BX]":
                        Registre.setContenuRegistre("BX", valmem1);
                        break;
                    default:
                        System.Console.WriteLine("Error ! no such mem_depl");
                        break;
                }
            }
            adresse = UAL.calculAdresse(mem, ifdepl, valDepl);
            MC.setRam(adresse);
            // ajouter la case memoire  dans l'adresse pointé 
            Case case_memoire = new Case();
            case_memoire.setAdr(adresse);
            case_memoire.setContenu(ccm);
            //MC.AjouterCase(Convert.ToInt32(adresse, 16), case_memoire);
            //  
            MC.setRim(ccm);
            // animation (rim,ual2,donne) 
            UAL.setUal2(MC.getRim());
            // animation ( registre , ual1, donne) ;
            UAL.setUal1(Registre.getDx());
            switch (mnemonique)
            {
                // outsw 
                case "OUTSW":
                    // ici ON A RIEN A FAIRE COMME ANIMATION 
                    UAL.positionnerIndicateurs(mnemonique);
                    break;
                default:
                    Console.WriteLine("erreur ");
                    break;
            }
        }
        //-----------------------------------------------------------------------------------
        public async static void execution_programme(string mnemonique, string format, string destination, string source, bool mem = true, bool ifdepl = true, string valdep = "", string val_imm16 = "")
        {
            //pop up pour recuperer contenu case memoire || cas format avec memoire
            ContenuCaseMemoirePopUp cont = new ContenuCaseMemoirePopUp();
            // les registres
            TextBox AX = (TextBox)instance.FindName("AX");
            TextBox BX = (TextBox)instance.FindName("BX");
            TextBox CX = (TextBox)instance.FindName("CX");
            TextBox DX = (TextBox)instance.FindName("DX");
            TextBox SI = (TextBox)instance.FindName("SI");
            TextBox DI = (TextBox)instance.FindName("DI");
            TextBox BP = (TextBox)instance.FindName("BP");
            TextBox SP = (TextBox)instance.FindName("SP");
            Case case_memoire = new Case();
            string result = "";
            //page phase2;
            switch (format)
            {
                /*
                case "Reg16/Mem16,Reg16":
                    if (mem_b)
                    { //mem16,reg16
                        if (ifdepl)
                        {
                            switch (mem)
                            {
                                case "[BX+SI+depl]":
                                    Registre.setContenuRegistre("BX", val1);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BX+DI+depl]":
                                    Registre.setContenuRegistre("BX", val1);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[BP+SI+depl]":
                                    Registre.setContenuRegistre("BP", val1);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BP+DI+depl]":
                                    Registre.setContenuRegistre("BP", val1);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[SI+depl]":
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[DI+depl]":
                                    Registre.setContenuRegistre("DI", val1);
                                    break;
                                case "[BP+depl]":
                                    Registre.setContenuRegistre("BP", val1);
                                    break;
                                case "[BX+depl]":
                                    Registre.setContenuRegistre("BX", val1);
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        else
                        {
                            switch (mem)
                            {
                                case "[BX+SI]":
                                    Registre.setContenuRegistre("BX", val3);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BX+DI]":
                                    Registre.setContenuRegistre("BX", val3);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[BP+SI]":
                                    Registre.setContenuRegistre("BP", val3);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BP+DI]":
                                    Registre.setContenuRegistre("BP", val3);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[SI]":
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[DI]":
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[BP]":
                                    Registre.setContenuRegistre("BP", val2);
                                    break;
                                case "[BX]":
                                    Registre.setContenuRegistre("BX", val2);
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        Registre.setContenuRegistre(source, val1);
                        string adresse = UAL.calculAdresse(mem, ifdepl, valdepl);
                        MC.setRam(adresse);
                        //case_memoire = MC.recherche_mc(adresse);
                        //case_memoire.setContenu(ccm);
                        MC.setRim(ccm);
                        UAL.setUal1(ccm);
                        switch (mnemonique)
                        {
                            //add , sub ,mov, xchg ,and , or ,xor ,cmp
                            case "ADD":
                                //  result = ccm + contenue de registre ; 
                                result = (Convert.ToInt32(ccm, 16) + Convert.ToInt32(val1, 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                // positionner les flags 
                                break;
                            case "SUB":
                                result = (Convert.ToInt32(ccm, 16) - Convert.ToInt32(val1, 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                break;
                            case "MOV": // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                                result = val1;
                                JeuxInstruction.SetInt(result);
                                break;
                            case "XCHG": // ANIMATION PARTICULIER  
                                result = val1; 
                                break;
                            case "AND":
                                result = (Convert.ToInt32(ccm, 16) & Convert.ToInt32(val1, 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                break;
                            case "OR":
                                result = (Convert.ToInt32(ccm, 16) | Convert.ToInt32(val1, 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                break;
                            case "XOR":
                                result = (Convert.ToInt32(ccm, 16) ^ Convert.ToInt32(val1, 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                break;
                        }
                        UAL.positionnerIndicateurs(mnemonique, result, ccm, val1);
                        MC.setRim(result);
                        // vu que xchng a une animation particulier on va la traiter dans le switch
                    }
                    else
                    { // la on est dans ke cas de reg,reg 
                        Registre.setContenuRegistre(mem, val1);
                        Registre.setContenuRegistre(source, val2);
                        UAL.setUal1(Registre.getContenuRegistre(mem));
                        UAL.setUal2(Registre.getContenuRegistre(source));
                        switch (mnemonique)
                        {
                            //add , sub ,mov, xchg ,and , or ,xor ,cmp
                            case "ADD":
                                //  result = ccm + contenue de registre ; 
                                result = (Convert.ToInt32(UAL.getUal1(), 16) + Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                // positionner les flags 
                                break;
                            case "SUB":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                JeuxInstruction.SetInt(result);
                                break;
                            case "MOV": // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                                result = UAL.getUal2();
                                JeuxInstruction.SetInt(result);
                                break;
                            case "XCHG": // ANIMATION PARTICULIER  

                                break;
                            case "AND":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) & Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                break;
                            case "OR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                break;
                            case "XOR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X4");
                                JeuxInstruction.SetInt(result);
                                break;
                        }
                        JeuxInstruction.SetInt(result);
                    }
                    break;
                case "Reg16,Reg16/Mem16":
                   format_reg_regOUmem(mnemonique, format, mem_b, mem, ifdepl, valdepl, ccm, source, val1, val2, val3);
                    break;
                case "AX,Reg16":
                    format_ax_reg(mnemonique, source, val1, val2, format, mem_b);
                    break;
                case "AX,imm16":
                    format_ax_imm16(mnemonique, val1, val2,format, mem_b);
                    break;
                case "Reg16":
                    format_reg16(mnemonique, source, val1 , format, mem_b);
                    break;
                case "Reg16,imm16":
                    format_reg16_imm16(mnemonique, source, val1, val3, format, mem_b);
                    break;
                // mem16
                */
                case "Mem16":
                    //decodage -- delay
                    if (ifdepl)
                    {
                        switch (destination) 
                        {
                            case "[BX+SI+DEP]":
                                Registre.setContenuRegistre("BX", Registre.getBx());
                                Registre.setContenuRegistre("SI", Registre.getSi());
                                break;
                            case "[BX+DI+DEP]":
                                Registre.setContenuRegistre("BX", Registre.getBx());
                                Registre.setContenuRegistre("DI", Registre.getDi());
                                break;
                            case "[BP+SI+DEP]":
                                Registre.setContenuRegistre("BP", Registre.getBp());
                                Registre.setContenuRegistre("SI", Registre.getSi());
                                break;
                            case "[BP+DI+DEP]":
                                Registre.setContenuRegistre("BP", Registre.getBp());
                                Registre.setContenuRegistre("DI", Registre.getDi());
                                break;
                            case "[SI+DEP]":
                                Registre.setContenuRegistre("SI", Registre.getSi());
                                break;
                            case "[DI+DEP]":
                                Registre.setContenuRegistre("DI", Registre.getDi());
                                break;
                            case "[BP+DEP]":
                                Registre.setContenuRegistre("BP", Registre.getBp());
                                break;
                            case "[BX+DEP]":
                                Registre.setContenuRegistre("BX", Registre.getBx());
                                break;
                            default:
                                System.Console.WriteLine("Error ! no such mem_depl");
                                break;
                        }
                    }
                    else
                    {
                        switch (destination)
                        {
                            case "[BX+SI]":
                                Registre.setContenuRegistre("BX", Registre.getBx());
                                Registre.setContenuRegistre("SI", Registre.getSi());
                                break;
                            case "[BX+DI]":
                                Registre.setContenuRegistre("BX", Registre.getBx());
                                Registre.setContenuRegistre("DI", Registre.getDi());
                                break;
                            case "[BP+SI]":
                                Registre.setContenuRegistre("BP", Registre.getBp());
                                Registre.setContenuRegistre("SI", Registre.getSi());
                                break;
                            case "[BP+DI]":
                                Registre.setContenuRegistre("BP", Registre.getBp());
                                Registre.setContenuRegistre("DI", Registre.getDi());
                                break;
                            case "[SI]":
                                Registre.setContenuRegistre("SI", Registre.getSi());
                                break;
                            case "[DI]":
                                Registre.setContenuRegistre("DI", Registre.getDi());
                                break;
                            case "[BP]":
                                Registre.setContenuRegistre("BP", Registre.getBp());
                                break;
                            case "[BX]":
                                Registre.setContenuRegistre("BX", Registre.getBx());
                                break;
                            default:
                                System.Console.WriteLine("Error ! no such mem_depl");
                                break;
                        }
                    }
                    Registre.setCx(Registre.getCx());// f loop user must set CX content ... 
                    switch (mnemonique)
                    {
                            case "JMP":
                            cont.adresse.Text = UAL.calculAdresse(destination, ifdepl, valdep);
                            cont.ShowDialog();
                            string contenu =  cont.userInputTextBox.Text;
                            Co.setco(contenu);
                            MC.setRam(Co.getco());
                            MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                            UAL.positionnerIndicateurs("JMP");
                            break;
                            case "LOOP":
                            cont.adresse.Text = UAL.calculAdresse(destination, ifdepl, valdep);
                            cont.ShowDialog();
                            contenu = cont.userInputTextBox.Text;
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                Registre.setCx(Convert.ToString((int.Parse(Registre.getCx()) - 1)));
                                UAL.positionnerIndicateurs("LOOP");
                                execution_programme("INC", "Reg16", "SP", "", false,false,"","");
                                Co.setco(contenu);
                                MC.setRam(Co.getco());
                              //  MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                                //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                                //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                            }
                            //apres loop 
                            //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                            break;
                        case "LOOPZ":
                            cont.adresse.Text = UAL.calculAdresse(destination, ifdepl, valdep);
                            cont.ShowDialog();
                            contenu = cont.userInputTextBox.Text;
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() != '1')
                                {
                                    UAL.positionnerIndicateurs("LOOPZ");
                                    Co.setco(contenu);
                                    MC.setRam(Co.getco());
                                    MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                                    //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                                    //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                                    //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            //apres loop 
                            //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                            break;
                        case "LOOPE": //loope est identique a loopz
                            cont.adresse.Text = UAL.calculAdresse(destination, ifdepl, valdep);
                            cont.ShowDialog();
                            contenu = cont.userInputTextBox.Text;
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() == '1')
                                {
                                    UAL.positionnerIndicateurs("LOOPE");
                                    Co.setco(contenu);
                                    MC.setRam(Co.getco());
                                    MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                                    //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                                    //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                                    //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            //apres loop 
                            //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                            break;
                        case "LOOPNZ":
                            cont.adresse.Text = UAL.calculAdresse(destination, ifdepl, valdep);
                            cont.ShowDialog();
                            contenu = cont.userInputTextBox.Text;
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() != '0')
                                {
                                    UAL.positionnerIndicateurs("LOOPNZ");
                                    Co.setco(contenu);
                                    MC.setRam(Co.getco());
                                    MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                                    //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                                    //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                                    //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            //apres loop 
                            //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                            break;
                        case "LOOPNE":
                            cont.adresse.Text = UAL.calculAdresse(destination, ifdepl, valdep);
                            cont.ShowDialog();
                            contenu = cont.userInputTextBox.Text;
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() != '0')
                                {
                                    UAL.positionnerIndicateurs("LOOPNE");
                                    Co.setco(contenu);
                                    MC.setRam(Co.getco());
                                    MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                                    //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                                    //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                                    //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            //apres loop 
                            //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                            break;
                        default:
                            System.Console.WriteLine("Error ! mnenmonique not defined");
                            break;
                    }

                    break;
                    case "Reg16/Mem16":
                    if (mem)
                    {
                        if (ifdepl)
                        {
                            switch (destination)
                            {
                                case "[BX+SI+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BX+DI+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+SI+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BP+DI+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[SI+DEP]":
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[DI+DEP]":
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    break;
                                case "[BX+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        else
                        {
                            switch (destination)
                            {
                                case "[BX+SI]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BX+DI]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+SI]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BP+DI]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[SI]":
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[DI]":
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    break;
                                case "[BX]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        
                        string adresse = UAL.calculAdresse(destination, ifdepl, valdep);
                        cont.adresse.Text = adresse;
                        cont.ShowDialog();
                        string contenu = cont.userInputTextBox.Text;
                        MC.setRam(adresse);
                        //MC.setRim(MC.recherche_mc(adresse).getContenu())
                        //case_memoire.setAdr(Co.getco());
                        case_memoire.setContenu(contenu);
                        MC.setRim(case_memoire.getContenu());
                        UAL.setUal2(MC.getRim());
                        switch (mnemonique)
                        {
                            case "INC":
                                UAL.setUal1("1");
                                int hexInt = Convert.ToInt32(UAL.getUal2(), 16);
                                hexInt++;
                                result = hexInt.ToString("X4").ToUpper();
                                JeuxInstruction.SetInt(result);
                                UAL.positionnerIndicateurs("INC", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRim(result);
                                //      MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "DEC":
                                UAL.setUal1("FFFF");//-1
                                hexInt = Convert.ToInt32(UAL.getUal2(), 16);
                                hexInt--;
                                result = hexInt.ToString("X4").ToUpper();
                                JeuxInstruction.SetInt(result);
                                UAL.positionnerIndicateurs("DEC", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "MUL":
                                //in this instruction user must specify content of BX
                                Registre.setBx(Registre.getBx());
                                BigInteger bi1 = BigInteger.Parse(UAL.getUal2(), NumberStyles.HexNumber);
                                BigInteger bi2 = BigInteger.Parse(Registre.getBx(), NumberStyles.HexNumber);
                                BigInteger result_mul = bi1 * bi2;
                                string hexResult = result_mul.ToString("X8");//32 bits representation
                                UAL.positionnerIndicateurs("MUL", hexResult, UAL.getUal1(), UAL.getUal2());
                                string poids_fort = hexResult.Substring(0, 4);
                                string poids_faible = hexResult.Substring(4, 4);
                                Registre.setAx(poids_faible);
                                Registre.setDx(poids_fort);
                                break;
                            case "NOT":
                                ushort operand = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber);
                                ushort result_not = (ushort)~operand;
                                hexResult = result_not.ToString("X4");
                                JeuxInstruction.SetInt(hexResult);
                                UAL.positionnerIndicateurs("NOT", hexResult, UAL.getUal1(), UAL.getUal2());
                                MC.setRim(hexResult);
                                //MC.recherche_mc(adresse).setContenu(hexResult);
                                break;
                            default:
                                Console.WriteLine("error in mnemonique");
                                break;
                        }
                    }
                    else // cas reg
                    {
                        UAL.setUal2(Registre.getContenuRegistre(destination));

                        switch (mnemonique)
                        {
                            case "INC":
                                UAL.setUal1("1");
                                int hexInt = Convert.ToInt32(UAL.getUal2(), 16);
                                hexInt++;
                                result = hexInt.ToString("X4").ToUpper();
                                JeuxInstruction.SetInt(result);
                                UAL.positionnerIndicateurs("INC", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRim(result);
                                //      MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "DEC":
                                UAL.setUal1("FFFF");//-1
                                hexInt = Convert.ToInt32(UAL.getUal2(), 16);
                                hexInt--;
                                result = hexInt.ToString("X4").ToUpper();
                                JeuxInstruction.SetInt(result);
                                UAL.positionnerIndicateurs("DEC", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "MUL":
                                //in this instruction user must specify content of BX
                                Registre.setBx(Registre.getBx());
                                BigInteger bi1 = BigInteger.Parse(UAL.getUal2(), NumberStyles.HexNumber);
                                BigInteger bi2 = BigInteger.Parse(Registre.getBx(), NumberStyles.HexNumber);
                                BigInteger result_mul = bi1 * bi2;
                                string hexResult = result_mul.ToString("X8");//32 bits representation
                                UAL.positionnerIndicateurs("MUL", hexResult, UAL.getUal1(), UAL.getUal2());
                                string poids_fort = hexResult.Substring(0, 4);
                                string poids_faible = hexResult.Substring(4, 4);
                                Registre.setAx(poids_faible);
                                Registre.setDx(poids_fort);
                                break;
                            case "NOT":
                                ushort operand = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber);
                                ushort result_not = (ushort)~operand;
                                hexResult = result_not.ToString("X4");
                                JeuxInstruction.SetInt(hexResult);
                                UAL.positionnerIndicateurs("NOT", hexResult, UAL.getUal1(), UAL.getUal2());
                                MC.setRim(hexResult);
                                //MC.recherche_mc(adresse).setContenu(hexResult);
                                break;
                            default:
                                Console.WriteLine("error in mnemonique");
                                break;
                        }
                    }
                    break;
                case "Reg16/Mem16,imm16":
                    if (mem)
                    {
                        if (ifdepl)
                        {
                            switch (destination)
                            {
                                case "[BX+SI+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BX+DI+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+SI+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BP+DI+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[SI+DEP]":
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[DI+DEP]":
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    break;
                                case "[BX+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        else
                        {
                            switch (destination)
                            {
                                case "[BX+SI]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BX+DI]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+SI]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BP+DI]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[SI]":
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[DI]":
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    break;
                                case "[BX]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        string adresse = UAL.calculAdresse(destination, ifdepl, valdep);
                        cont.adresse.Text = adresse;
                        cont.ShowDialog();
                        string contenu = cont.userInputTextBox.Text;
                        MC.setRam(adresse);
                        // MC.setRim(MC.recherche_mc(adresse).getContenu());
                        UAL.setUal1(val_imm16);
                        //on lit le deuxieme mot memoire pour avoir l'operande immediat
                        Co.incCo();
                        MC.setRam(Co.getco());
                        // MC.setRim(MC.recherche_mc("0101").getContenu());
                        UAL.setUal2(contenu);
                        switch (mnemonique)
                        {

                            case "ADD":
                                int r = Convert.ToInt32(UAL.getUal1(), 16);
                                int r1 = Convert.ToInt32(UAL.getUal2(), 16);
                                result = (Convert.ToInt32(UAL.getUal1(), 16) + Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                JeuxInstruction.SetInt(result);
                                //animation Indicateurs
                                UAL.positionnerIndicateurs("ADD", result, UAL.getUal1(), UAL.getUal2());
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "SUB":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("SUB", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRam(adresse);
                                MC.setRim(result);
                                JeuxInstruction.SetInt(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "MOV":
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("MOV", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRam(adresse);
                                JeuxInstruction.SetInt(UAL.getUal2());
                                MC.setRim(UAL.getUal2());
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "AND":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) & Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("AND", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRam(adresse);
                                JeuxInstruction.SetInt(result);
                                MC.setRim(result);
                                // MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "OR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("OR", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRam(adresse);
                                JeuxInstruction.SetInt(result);
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "XOR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("XOR", result, UAL.getUal1(), UAL.getUal2());
                                MC.setRam(adresse);
                                JeuxInstruction.SetInt(result);
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "SHL":
                                //ushort pour 16-bit representation
                                ushort dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                ushort count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                           // Shift the destination left by the count value
                                string str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                string str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // UAL.positionnerIndicateurs("SHL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("SHL", str_res, val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                         // Shift the dest left by the count value
                                str_op2 = dest.ToString("X4");
                                dest = (ushort)(dest >> count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SHR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x0001) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("SHR", str_res, val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                         // Check the value of the MSB before the shift
                                bool signBit = (dest & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                dest = (ushort)(dest << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (dest & 0x8000) != 0;
                                str_op2 = dest.ToString("X4");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SAL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("SAL", str_res, val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAR":
                                dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                         // Check the value of the MSB before the shift
                                signBit = (dest & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                dest = (ushort)(dest >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = dest.ToString("X4");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SAR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("SAR", str_res, val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "ROR":
                                dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (dest << (16 - count)));
                                bool carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X4");
                                string str_op1 = count.ToString("X4");
                                dest = (ushort)(dest << count);
                                JeuxInstruction.SetInt(dest.ToString("X4"));
                                // UAL.positionnerIndicateurs("ROR", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("ROR", dest.ToString("X4"), val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "ROL":
                                dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                // Perform the rotation
                                dest = (ushort)((dest << count) | (dest >> (16 - count)));
                                carryFlag = (dest & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X4");
                                str_op1 = count.ToString("X4");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // UAL.positionnerIndicateurs("ROL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("ROL", dest.ToString("X4"), val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X4");
                                str_op1 = count.ToString("X4");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // UAL.positionnerIndicateurs("RCR", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("RCR", dest.ToString("X4"), val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "RCL":
                                dest = ushort.Parse(contenu, NumberStyles.HexNumber);
                                count = ushort.Parse(val_imm16, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value b
                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (dest & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    dest = (ushort)((dest << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = dest.ToString("X4");
                                str_op1 = count.ToString("X4");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("RCL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (dest & 0x8000) != 0;
                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                UAL.positionnerIndicateurs("RCL", dest.ToString("X4"), val_imm16, contenu);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "CMP":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                UAL.positionnerIndicateurs("CMP", result);
                                break;
                            default:
                                System.Console.WriteLine("error ! no such mnemonique");
                                break;
                        }
                    }
                    //-------------------------------------------------------------------------------
                    else
                    {//reg,imm16
                        Registre.setContenuRegistre(destination, Registre.getContenuRegistre(destination));//val3 valeur te3 registre // une autre fois je travaille avec source alors que c'est destinataire -- juste notation
                        UAL.setUal1(Registre.getContenuRegistre(destination));
                        //on lit le deuxieme mot memoire pour avoir l'operande immediat
                        Co.incCo();//premier mot adresse 100 deuxieme adresse 101
                                         //animation(CO,RAM,adresse);
                        MC.setRam(Co.getco());
                        // MC.setRim(MC.recherche_mc("0101").getContenu());
                        UAL.setUal2(val_imm16);
                        string r = UAL.getUal1();
                        string r1 = UAL.getUal2();
                        switch (mnemonique)
                        {
                            case "SHL":
                                //ushort pour 16-bit representation
                                ushort dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                ushort count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                                    // Shift the dest left by the count value
                                string str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                string str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // UAL.positionnerIndicateurs("SHL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                             // Shift the dest left by the count value
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest >> count);
                                str_res = dest.ToString("X");
                                // UAL.positionnerIndicateurs("SHR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x0001) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                bool signBit = (dest & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                dest = (ushort)(dest << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (dest & 0x8000) != 0;
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X");
                                //UAL.positionnerIndicateurs("SAL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "SAR":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                signBit = (dest & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                dest = (ushort)(dest >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X");
                                // UAL.positionnerIndicateurs("SAR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "ROR":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (dest << (16 - count)));
                                bool carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                string str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X");
                                //  UAL.positionnerIndicateurs("ROR", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                Registre.setContenuRegistre(destination, dest.ToString("X"));

                                break;
                            case "ROL":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest << count) | (dest >> (16 - count)));
                                carryFlag = (dest & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X");
                                //UAL.positionnerIndicateurs("ROL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the MSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X");
                                //UAL.positionnerIndicateurs("RCR", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                Registre.setContenuRegistre(destination, dest.ToString("X"));

                                break;
                            case "RCL":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (dest & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    dest = (ushort)((dest << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X");
                                //UAL.positionnerIndicateurs("RCL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (dest & 0x8000) != 0;
                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(dest.ToString("X"));
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "CMP":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                UAL.positionnerIndicateurs("CMP", result);
                                break;
                            case "ADD":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) + Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(destination, result);
                                //fin
                                break;
                            case "SUB":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(destination, result);
                                //fin
                                break;
                            case "MOV":
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(destination, result);
                                break;
                            case "AND":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) & Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(destination, result);
                                //fin
                                break;
                            case "OR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(destination, result);
                                //fin
                                break;
                            case "XOR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(destination, result);
                                //fin
                                break;
                            default:
                                System.Console.WriteLine("error ! no such mnemonique");
                                break;
                        }
                       }
                    break;
                case "AX,DX":
                    switch (mnemonique)
                    {
                        case "IN":
                            //animation registre(ax,dx)
                            //afficher fenetre (contient numero periph ex : clavier) Registre.getDX();
                            cont.text_popup.Text = "Entrer une valeur a mettre dans le periph d'entree : ";
                            cont.adresse.Text = Registre.getDx();
                            cont.ShowDialog();
                            string value1 = cont.userInputTextBox.Text;
                            UAL.setUal2(value1);
                            UAL.setUal1(Registre.getAx());
                            Registre.setAx(value1);
                            JeuxInstruction.SetInt(value1);
                            break;
                        default:
                            System.Console.WriteLine("no such mnemonique");
                            break;
                    }
                    break;
                case "Mem16,DX":
                    switch (mnemonique)
                    {
                        case "INSW":
                            //animation registre(dx)
                            //afficher fenetre (contient numero periph ex : clavier) Registre.getDX();
                            cont.text_popup.Text = "Entrer une valeur a mettre dans le periph d'entree : ";
                            cont.adresse.Text = Registre.getDx();
                            cont.ShowDialog();
                            string value = cont.userInputTextBox.Text;
                            cont.text_popup.Text = "Entrer le contenu de la case mémoire: ";
                            string adresse = UAL.calculAdresse(destination, ifdepl, valdep);
                            cont.adresse.Text = adresse;
                            cont.ShowDialog();
                            Co.setco(adresse);
                            MC.setRam(adresse);
                            MC.setRim(value);
                            //MC.recherche_mc(adresse).setContenu(value);
                            //UAL.positionnerIndicateurs("IN", value);
                            JeuxInstruction.SetInt(value);
                            break;
                        default:
                            System.Console.WriteLine("no such mnemonique");
                            break;
                    }
                    break;

                case "DX,Mem16":
                   // format_dx_mem16(mnemonique, ccm, mem, ifdepl, valdepl, val1, val2, val3);
                    break;

                case "Reg16/Mem16,CX":
                    if (mem)
                    {
                        if (ifdepl)
                        {
                            switch (destination)
                            {
                                case "[BX+SI+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BX+DI+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+SI+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BP+DI+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[SI+DEP]":
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[DI+DEP]":
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+DEP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    break;
                                case "[BX+DEP]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        else
                        {
                            switch (destination)
                            {
                                case "[BX+SI]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BX+DI]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP+SI]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[BP+DI]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[SI]":
                                    Registre.setContenuRegistre("SI", Registre.getSi());
                                    break;
                                case "[DI]":
                                    Registre.setContenuRegistre("DI", Registre.getDi());
                                    break;
                                case "[BP]":
                                    Registre.setContenuRegistre("BP", Registre.getBp());
                                    break;
                                case "[BX]":
                                    Registre.setContenuRegistre("BX", Registre.getBx());
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        string adresse = UAL.calculAdresse(destination, ifdepl, valdep);
                        cont.adresse.Text = adresse;
                        cont.ShowDialog();
                        string ccm = cont.userInputTextBox.Text;
                        MC.setRam(adresse);
                        //MC.setRim(MC.recherche_mc(adresse).getContenu());
                        UAL.setUal1(ccm);
                        //on met le contenu de cx dans ual2
                        UAL.setUal2(Registre.getCx());
                        switch (mnemonique)
                        {
                            case "SHL":
                                //ushort pour 16-bit representation
                                ushort dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                ushort count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                                       // Shift the dest left by the count value
                                string str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                string str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                UAL.positionnerIndicateurs("SHL", str_res, operand2hex: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                MC.setRim(dest.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                                // Shift the dest left by the count value
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest >> count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                UAL.positionnerIndicateurs("SHR", str_res, operand2hex: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x0001) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                               // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                                // Check the value of the MSB before the shift
                                bool signBit = (dest & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                dest = (ushort)(dest << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (dest & 0x8000) != 0;
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);

                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                               // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAR":
                                dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                                // Check the value of the MSB before the shift
                                signBit = (dest & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                dest = (ushort)(dest >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                UAL.positionnerIndicateurs("SAR", str_res, operand2hex: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                             //   MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "ROR":
                                dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (dest << (16 - count)));
                                bool carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                string str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("ROR", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                              //  MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "ROL":
                                dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest << count) | (dest >> (16 - count)));
                                carryFlag = (dest & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("ROL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the MSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                UAL.positionnerIndicateurs("RCR", str_res, operand2hex: str_op2, operand1Hex: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                             //   MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "RCL":
                                dest = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (dest & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    dest = (ushort)((dest << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                UAL.positionnerIndicateurs("RCL", str_res, operand2hex: str_op2, operand1Hex: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (dest & 0x8000) != 0;
                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                Co.setco(adresse);
                                MC.setRam(adresse);
                                MC.setRim(dest.ToString("X"));
                             //   MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            default:
                                System.Console.WriteLine("error ! no such mnemonique");
                                break;
                        }
                        UAL.positionnerIndicateurs(mnemonique, JeuxInstruction.GetInt(), Registre.getCx(), ccm);
                    }
                    //-------------------------------------------------------------------------------
                    else
                    {//reg,cx
                        Registre.setContenuRegistre(destination, Registre.getContenuRegistre(destination));//val3 valeur te3 registre // une autre fois je travaille avec source alors que c'est destinataire -- juste notation
                        UAL.setUal1(Registre.getContenuRegistre(destination));
                        //on met cx dans ual2
                        string val1 = Registre.getContenuRegistre(destination);
                        UAL.setUal2(Registre.getCx());
                        switch (mnemonique)
                        {
                            case "SHL":
                                //ushort pour 16-bit representation
                                ushort dest = ushort.Parse(val1, NumberStyles.HexNumber);
                                ushort count = ushort.Parse(Registre.getCx(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                                       // Shift the dest left by the count value
                                string str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                string str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                             // Shift the dest left by the count value
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest >> count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x0001) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                bool signBit = (dest & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                dest = (ushort)(dest << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (dest & 0x8000) != 0;
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "SAR":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                signBit = (dest & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                dest = (ushort)(dest >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    dest |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = dest.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((dest & 0x8000) != 0);
                                // Set the new value of the CF flag
                                if (newCarryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "ROR":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (dest << (16 - count)));
                                bool carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                string str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the LSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));

                                break;
                            case "ROL":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest << count) | (dest >> (16 - count)));
                                carryFlag = (dest & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                dest = (ushort)((dest >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (dest & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the LSB to determine the new value of the CF flag

                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the LSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the LSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));

                                break;
                            case "RCL":
                                dest = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (dest & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    dest = (ushort)((dest << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = dest.ToString("X");
                                str_op1 = count.ToString("X");
                                dest = (ushort)(dest << count);
                                str_res = dest.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (dest & 0x8000) != 0;
                                // Set the new value of the CF flag
                                if (carryFlag)
                                {
                                    // If the MSB is set, set the CF flag to 1
                                    Indicateur.setretenuAuxiliaire('1');
                                }
                                else
                                {
                                    // If the MSB is not set, set the CF flag to 0
                                    Indicateur.setretenuAuxiliaire('0');
                                }
                                //ecriture des resultats
                                //animation(UAL,registre)
                                Registre.setContenuRegistre(destination, dest.ToString("X"));
                                break;
                            default:
                                System.Console.WriteLine("error ! no such mnemonique");
                                break;
                        }
                        UAL.positionnerIndicateurs(mnemonique, JeuxInstruction.GetInt(), Registre.getContenuRegistre(destination), Registre.getCx());
                    }
                    break;
                default:

                    break;
            }

        }
        private void DelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int delay = (int)e.NewValue;
            DelayTextBlock.Text = $"Delay: {delay} ms";
        }



        private void ButtonExecuter_Click(object sender, RoutedEventArgs e)
        {
            int i = 1;
                foreach (Instruction ins in programInst)
                {
                    execution_programme(ins.getMnemonique(), ins.getFormat(), ins.getDestination(), ins.getSource(), ins.getmem(), ins.getifdepl(), ins.getValDepl(), ins.getval_imm16());
                   // MessageBox.Show("verify result");
                    int delay = (int)DelaySlider.Value; // Get the value of the slider control
                    System.Threading.Thread.Sleep(delay); // Delay the execution for the value of the slider
                    Co.incCo();
                    dataGrid1.SelectedIndex = i;
                    i++;
                }
          
        }






        //---------------------------------------------- Conseil du jour ----------------------------------------------//


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = true;
            mainGrid.Effect = new System.Windows.Media.Effects.BlurEffect { Radius = 7 };

            // Generate a random number
            Random random = new Random();
            int randomNumber = random.Next(conseils.Count);

            // Display the randomly selected name
            string randomName = conseils[randomNumber];

            Conseil.Text = randomName;
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = false;
            mainGrid.Effect = null;
        }

        //---------------------------------------------- Conseil du jour ----------------------------------------------//



    }
}
