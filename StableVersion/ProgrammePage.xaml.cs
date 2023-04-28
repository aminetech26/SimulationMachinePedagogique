using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
using System.IO;
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
        // --------------------------------------------------------------------------------
        public string convertir_instruction_Lmnemonique(Instruction instruction)
        {
             return instruction.getmnemonique()+" "+convertir_First_part(instruction)+convertir_Second_part(instruction);
        }
        // ---------------------------------------------------------------------------------
        public string convertir_First_part(Instruction instruction)   // we consider INST First_part,Second_part
        {
            string my_first_part="";
          switch(instruction.getFormat()){
                case "AX,DX" :
                case "AX,imm16":
                case "AX,Reg16":
                    my_first_part = "AX";
                break;
                case "DX,AX":
                case "DX,mem16":
                    my_first_part ="DX" ;
                break;
                case "Reg16/Mem16,imm16":
                case "Reg16/mem16":
                case "Reg16/mem16,imm8":
                case "Reg16/mem16,CX":
                    my_first_part = case_reg_mem(instruction);
                break;
                case "Reg16,Reg16/mem16":
                case "Reg16,imm16":
                case "Reg16":
                    my_first_part = case_reg(instruction);
                    break;
                case "mem16,DX":
                case "mem16":
                    my_first_part=case_mem(instruction);
                    break;
                default:
                    my_first_part= "error";
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
        public string case_mem(Instruction instruction) { // Inst mem, ....
            if (instruction.getifdepl())
            {
                return instruction.getDestination().Replace("XXXX",instruction.getValDepl());
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
                case "mem16,DX":
                    my_second_part =",DX";
                    break;
                case "DX,AX":
                    my_second_part = ",AX";
                    break;
                case "Reg16/mem16,CX":
                    my_second_part = ",CX";
                    break;
                case "Reg16,Reg16/mem16":
                    my_second_part =","+src_case_reg_mem(instruction);
                    break;
                case "DX,mem16":
                    my_second_part = "," + src_case_mem(instruction);
                    break;
                case "Reg16/mem16":
                case "Reg16":
                case "mem16":
                    my_second_part = "";
                    break;
                case "AX,imm16":
                case "Reg16/Mem16,imm16":
                case "Reg16/mem16,imm8":
                case "Reg16,imm16":
                    my_second_part = "," + BinaryStringToHexString(instruction.getval_imm16());
                  break;
                case "AX,Reg16":
                    my_second_part = "," + src_case_reg(instruction);
                    break;
                default:
                    my_second_part = "error";
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
                return instruction.getSource().Replace("XXXX", instruction.getValDepl());
            }
            else
            {
                return instruction.getSource();
            }
        }
    // la fonction principale qui convertir tout les instruction et les sauvgarder dans un fichier text ... chaque line avec une instruction
      public void convertir_list_inst_fochier_txt(List<Instruction> programInstructions){
         string file_path="./myfile.txt";
         using StreamWriter write=new StreamWriter(file_path,true);
         foreach(Instruction inst in programInstructions){
             write.WriteLine(convertir_instruction_Lmnemonique(inst));
         }
      }
      //-------------------------------------------------------------------------------------------------------------------
       // convertir la list des instruction a la forme en hexa decimale
       public void convertir_list_inst_hexaforme(){

       }
       // convertion de chaque instruction ........
       public string inst_to_hexaforme(Instruction inst){
        string hexaforme;
        string binaryforme;
        JeuxInstruction jeux_inst=new JeuxInstruction();
        switch(inst.getFormat()){
            case "AX,imm16":
             binaryforme=jeux_inst.remplir_AX_imm16(inst.getmnemonique(),inst.getval_imm16());
            break;
            case "Reg16/Mem16,imm16":
            binaryforme=jeux_inst.remplir_Reg_mem_imm16(inst.getmnemonique(),inst.getDestination(),inst.getifdepl(),inst.getValDepl(),inst.getval_imm16());
            break;
            case "Reg16/Mem16,Reg16":
             binaryforme=jeux_inst.remplir_reg_mem_reg(inst.getmnemonique(),inst.getDestination(),inst.getSource(),inst.getifdepl(),inst.getValDepl());
            break;
            case "Reg16,Reg16/Mem16":
            binaryforme=jeux_inst.remplir_reg_reg_mem(inst.getmnemonique(),inst.getDestination(),inst.getSource(),inst.getifdepl(),inst.getValDepl());
            break;
            case "Reg16":
            binaryforme=jeux_inst.remplir_reg16(inst.getmnemonique(),inst.getDestination());
            break;
            case "Reg16/mem16":
            binaryforme=jeux_inst.remplir_reg16_mem16(inst.getmnemonique(),inst.getDestination(),inst.getifdepl(),inst.getValDepl());
            break;
            case "Reg16,imm16":
            binaryforme=jeux_inst.remplir_Reg16_imm16(inst.getmnemonique(),inst.getDestination(),inst.getval_imm16());
            break;
            case "AX,Reg16":
            binaryforme=jeux_inst.remplir_AX_Reg16(inst.getmnemonique(),inst.getDestination());
            break;
            case "Reg16/mem16,CX":
            binaryforme=jeux_inst.remplir_reg_mem_cx(inst.getmnemonique(),inst.getDestination(),inst.getifdepl(),inst.getValDepl());
            break;
            case "AX,DX":
             binaryforme=jeux_inst.remplir_AX_DX();
            break;
            case "DX,AX":
            binaryforme=jeux_inst.remplir_DX_AX();
            break;
            case "mem16,DX":
            binaryforme=jeux_inst.remplir_mem16_DX();
            break;
            case "DX,mem16":
            binaryforme=jeux_inst.remplir_mem16_DX();
            break;
            default:
            binaryforme="error";
            break;
        }
        hexaforme=BinaryStringToHexString(binaryforme);
        return hexaforme;
       }
       //---------------------------------------------------------------------------------------------------------
       public static string BinaryStringToHexString(string binary)
{
    if (string.IsNullOrEmpty(binary))
        return binary;

    StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

    // TODO: check all 1's or 0's... throw otherwise

    int mod4Len = binary.Length % 8;
    if (mod4Len != 0)
    {
        // pad to length multiple of 8
        binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
    }

    for (int i = 0; i < binary.Length; i += 8)
    {
        string eightBits = binary.Substring(i, 8);
        result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
    }

    return result.ToString();
}
    }
}
