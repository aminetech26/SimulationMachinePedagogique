using System.Collections;
using System.Globalization;
using System.Numerics;
using System.Text;
using System;
using ArchiMind;
using System.Collections.Generic;
using System.Windows.Controls;
using projet;
using System.Threading.Tasks;
using projet.Pages;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls.Ribbon;
using System.Security.Cryptography;
using System.Windows;
using static System.Windows.Forms.DataFormats;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArchiMind
{

    internal class JeuxInstruction
    {

        public  static Animation _jeuxInstruction;
        public static ExecutionProgramme contextProgram;
        public static void AnimatIndicateurProgram()
        {
            Grid Z = (Grid)contextProgram.FindName("IND_Z");
            Grid A = (Grid)contextProgram.FindName("IND_A");
            Grid S = (Grid)contextProgram.FindName("IND_S");
            Grid D = (Grid)contextProgram.FindName("IND_D");
            Grid R = (Grid)contextProgram.FindName("IND_R");
            Grid P = (Grid)contextProgram.FindName("IND_P");
            Grid T = (Grid)contextProgram.FindName("IND_T");
            Grid I = (Grid)contextProgram.FindName("IND_I");
            switch (Indicateur.getZero())
            {
                case '1':
                    Z.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    Z.Background = new SolidColorBrush(Colors.Blue);
                    break;
                    // default: Z.Fill = new SolidColorBrush(Colors.Black); break;
            }
            switch (Indicateur.getSigne())
            {
                case '1':
                    S.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    S.Background = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getOverflow())
            {
                case '1':
                    D.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    D.Background = new SolidColorBrush(Colors.Blue);
                    break;
            }

            switch (Indicateur.getRetenu())
            {
                case '1':
                    R.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    R.Background = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getretenuAuxiliaire())
            {
                case '1':
                    A.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    A.Background = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getParite())
            {
                case '1':
                    P.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    P.Background = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getTrace())
            {
                case '1':
                    T.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    T.Background = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getAutoIncrDec())
            {
                case '1':
                    I.Background = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    I.Background = new SolidColorBrush(Colors.Blue);
                    break;
            }
        }

        public static void setContextProgram(ExecutionProgramme cntProgram)
        {
            contextProgram = cntProgram;
        }

        public static void setJeux(Animation page)
        { _jeuxInstruction = page; }  




        public static void Phase1()
        {
            TextBlock text = (TextBlock)_jeuxInstruction.FindName("phase1");
            text.Visibility = Visibility.Visible;

            text.Text = "Phase1  ( rechercher l’instruction à traiter )" + Environment.NewLine +
                "Mettre le contenu du CO dans le registre RAM  : " + Environment.NewLine +
                "RAM = (CO) " + Environment.NewLine +
                "Commande de lecture à partir de la mémoire : Lect " + Environment.NewLine +
                "RI = (RIM) " + Environment.NewLine +
                "Analyse et décodage";



        }




        public static void Phase2(string mnemoni, string format, bool RegM)
        {

            TextBlock text = (TextBlock)_jeuxInstruction.FindName("phase1");
            text.Visibility = Visibility.Collapsed;


            TextBlock ual = (TextBlock)_jeuxInstruction.FindName("UAL");
            ual.Text = mnemoni;

            TextBlock text1 = (TextBlock)_jeuxInstruction.FindName("phase2");
            text1.Visibility = Visibility.Visible;

            if ((format == "AX,imd16") || ((format == "Reg16/Mem16,imm16") && (RegM == false)) || (format == "Reg16,imm16"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                        "UAL1 = Valeur de Registre  " + Environment.NewLine +
                        "CO = CO + 1                            " + Environment.NewLine +
                        "RAM = CO                               " + Environment.NewLine +
                        "Lecture  et le met dans RIM            " + Environment.NewLine +
                        "UAL2 = RIM                             ";

            }
            if ((format == "Reg16/Mem16,imm16") && (RegM == true))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                        " On fait un Calcule Adresse        " + Environment.NewLine +
                        " la valeur on le met dans le RAM   " + Environment.NewLine +
                        " Lecture  et le met dans RIM       " + Environment.NewLine +
                        " UAL1 = RIM                        " + Environment.NewLine +
                        " CO = CO + 1                       " + Environment.NewLine +
                        " RAM = CO                          " + Environment.NewLine +
                        " Lecture  et le met dans RIM       " + Environment.NewLine +
                        " UAL2 = RIM                        ";
            }
            if (((format == "Reg16,Reg16/mem16") && (RegM == true)) || ((format == "Reg16/mem16,Reg16") && (RegM == true)))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                       " On fait un Calcule Adresse        " + Environment.NewLine +
                       " la valeur on le met dans le RAM   " + Environment.NewLine +
                       " Lecture  et le met dans RIM       " + Environment.NewLine +
                       " UAL1 = RIM                        " + Environment.NewLine +
                       " UAL2 = Valeur de Registre  "
              ;
            }
            if ((format == "Reg16/mem16") && (RegM == true) && (mnemoni == "INC"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                      " On fait un Calcule Adresse        " + Environment.NewLine +
                      " la valeur on le met dans le RAM   " + Environment.NewLine +
                      " Lecture  et le met dans RIM       " + Environment.NewLine +
                      " UAL1 = RIM                        " + Environment.NewLine +
                      " UAL2 = 0001  "
             ;
            }
            if ((format == "Reg16/mem16") && (RegM == true) && (mnemoni == "DEC"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                      " On fait un Calcule Adresse        " + Environment.NewLine +
                      " la valeur on le met dans le RAM   " + Environment.NewLine +
                      " Lecture  et le met dans RIM       " + Environment.NewLine +
                      " UAL1 = RIM                        " + Environment.NewLine +
                      " UAL2 = FFFF  "
             ;
            }
            if ((format == "Reg16/mem16") && (RegM == true) && (mnemoni == "MUL"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                      " On fait un Calcule Adresse        " + Environment.NewLine +
                      " la valeur on le met dans le RAM   " + Environment.NewLine +
                      " Lecture  et le met dans RIM       " + Environment.NewLine +
                      " UAL1 = RIM                        " + Environment.NewLine +
                      " UAL2 = Valeur de AX  "
             ;
            }
            if ((format == "Reg16/mem16") && (RegM == true) && (mnemoni == "NOT"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                      " On fait un Calcule Adresse        " + Environment.NewLine +
                      " la valeur on le met dans le RAM   " + Environment.NewLine +
                      " Lecture  et le met dans RIM       " + Environment.NewLine +
                      " UAL1 = RIM                        "

             ;
            }
            if (((format == "Reg16,Reg16/mem16") && (RegM == false)) || ((format == "Reg16/mem16,Reg16") && (RegM == false)) || (format == "AX,Reg16"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                       "UAL1 = Valeur de Registre 1 " + Environment.NewLine +
                       "UAL2 = Valeur de Registre 2 "
                     ;

            }
            if ((format == "Reg16/Mem16,CX") && (RegM == false))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                       "UAL1 = Valeur de Registre 1 " + Environment.NewLine +
                       "UAL2 = Valeur de CX "
                     ;
            }
            if ((format == "Reg16/Mem16,CX") && (RegM == true))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                      " On fait un Calcule Adresse        " + Environment.NewLine +
                      " la valeur on le met dans le RAM   " + Environment.NewLine +
                      " Lecture  et le met dans RIM       " + Environment.NewLine +
                      " UAL1 = RIM                        " + Environment.NewLine +
                      " UAL2 = Valeur de CX  "
             ;
            }
            if ((format == "Reg16") && (RegM == false) && (mnemoni == "INC"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                      " UAL1 = Destinataire                        " + Environment.NewLine +
                      " UAL2 = 0001                               "
             ;
            }
            if ((format == "Reg16") && (RegM == false) && (mnemoni == "DEC"))
            {
                text1.Text = "phase 2 :    " + Environment.NewLine +
                      " UAL1 = Destinataire                        " + Environment.NewLine +
                      " UAL2 = FFFF                              "
             ;
            }
        }





        public static void Phase3(string mnemoni, string format, bool RegM)
        {

            TextBlock text = (TextBlock)_jeuxInstruction.FindName("phase2");
            text.Visibility = Visibility.Collapsed;

            TextBlock text1 = (TextBlock)_jeuxInstruction.FindName("phase3");
            text1.Visibility = Visibility.Visible;

            if ((format == "AX,imd16") || (format == "Reg16,imm16") || ((format == "Reg16/Mem16,CX") && (RegM == false)) || (format == "AX,Reg16") || ((format == "Reg16/Mem16,imm16") && (RegM == false)) || ((format == "Reg16,Reg16/mem16") && (RegM == true)) || ((format == "Reg16,Reg16/mem16") && (RegM == false)) || ((format == "Reg16/mem16,Reg16") && (RegM == false)) || ((format == "Reg16") && (RegM == false)))
            {
                text1.Text = "phase 3 :                             " + Environment.NewLine +
                       " Fair Operatin dans UAL               " + Environment.NewLine +
                       " Destinatair = Sortie UAL             ";

            }
            if ((format == "Reg16/Mem16,imm16") && (RegM == true) || ((format == "Reg16/Mem16,CX") && (RegM == true)) || ((format == "Reg16/mem16,Reg16") && (RegM == true)) || ((format == "Reg16/mem16") && (RegM == true) && (mnemoni != "MUL")))
            {
                text1.Text = "phase 3 :                           " + Environment.NewLine +
                        " Fair Operatin dans UAL            " + Environment.NewLine +
                        " On fait un Calcule Adresse        " + Environment.NewLine +
                        " la valeur on le met dans la RAM    " + Environment.NewLine +
                        " sortie UAL dans RIM                " + Environment.NewLine +
                        " on fait une Ecriture               ";
            }
            if ((format == "Reg16/mem16") && (RegM == true) && (mnemoni == "MUL"))
            {
                text1.Text = "phase 3 :                             " + Environment.NewLine +
                       " Fair Operatin dans UAL               " + Environment.NewLine +
                       " AX = 4 bits de poid faible             " + Environment.NewLine +
                       " DX = 4 bits de poid fort             ";
            }
        }

        public static void setRiInFront(string contenueRi)
        {

            var ri = (TextBox)_jeuxInstruction.FindName("RI");

            ri.Text = contenueRi;
        }

        public static void AnimatIndicateur()
        {
            Rectangle Z = (Rectangle)_jeuxInstruction.FindName("Z");
            Rectangle A = (Rectangle)_jeuxInstruction.FindName("A");
            Rectangle S = (Rectangle)_jeuxInstruction.FindName("S");
            Rectangle D = (Rectangle)_jeuxInstruction.FindName("D");
            Rectangle R = (Rectangle)_jeuxInstruction.FindName("R");
            Rectangle P = (Rectangle)_jeuxInstruction.FindName("P");
            Rectangle T = (Rectangle)_jeuxInstruction.FindName("T");
            Rectangle I = (Rectangle)_jeuxInstruction.FindName("I");
            switch (Indicateur.getZero())
            {
                case '1':
                    Z.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    Z.Fill = new SolidColorBrush(Colors.Blue);
                    break;
                    // default: Z.Fill = new SolidColorBrush(Colors.Black); break;
            }
            switch (Indicateur.getSigne())
            {
                case '1':
                    S.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    S.Fill = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getOverflow())
            {
                case '1':
                    D.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    D.Fill = new SolidColorBrush(Colors.Blue);
                    break;
            }

            switch (Indicateur.getRetenu())
            {
                case '1':
                    R.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    R.Fill = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getretenuAuxiliaire())
            {
                case '1':
                    A.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    A.Fill = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getParite())
            {
                case '1':
                    P.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    P.Fill = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getTrace())
            {
                case '1':
                    T.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    T.Fill = new SolidColorBrush(Colors.Blue);
                    break;
            }
            switch (Indicateur.getAutoIncrDec())
            {
                case '1':
                    I.Fill = new SolidColorBrush(Colors.Red);
                    break;
                case '0':
                    I.Fill = new SolidColorBrush(Colors.Blue);
                    break;
            }
        }


        private static string myInt;

        // Méthode statique pour stocker un entier
        public static void SetInt(string value)
        {
            myInt = value;
        }

        // Méthode statique pour récupérer l'entier stocké
        public static string GetInt()
        {
            return myInt;
        }

        static private string[] list_mem_dep = { "[BX+SI+XXXX]", "[BX+DI+XXXX]", "[BP+SI+XXXX]", "[BP+DI+XXXX]", "[SI+XXXX]", "[DI+XXXX]", "[BP+XXXX]", "[BX+XXXX]" };
        static private string[] list_mem_sansdep = { "[BX+SI]", "[BX+DI]", "[BP+SI]", "[BP+DI]", "[SI]", "[DI]", "[XXXX]", "[BX]" };
        private CoupleCopFormat mycouple = new CoupleCopFormat();
        // private ArrayList  detailInstruction = new ArrayList (); 
        // i think it should be a static attribute because it will never change again ...............                                                          
        static private List<CoupleCopFormat> detailInstruction = new List<CoupleCopFormat>();

        // ------------------------hexadecimale to binary form------------------------------------------------------
        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
                { '0', "0000" },
                { '1', "0001" },
                { '2', "0010" },
                { '3', "0011" },
                { '4', "0100" },
                { '5', "0101" },
                { '6', "0110" },
                { '7', "0111" },
                { '8', "1000" },
                { '9', "1001" },
                { 'a', "1010" },
                { 'b', "1011" },
                { 'c', "1100" },
                { 'd', "1101" },
                { 'e', "1110" },
                { 'f', "1111" }
                 };

        static public string HexStringToBinary(string hex)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                // This will crash for non-hex characters. You might want to handle that differently.
                result.Append(hexCharacterToBinary[char.ToLower(c)]);
            }
            return result.ToString();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void intialize()
        {
            // la methode qui intialise 

            //------------------- Arithmethique instructions ------------------------------------------------------------------

            // l'intialisation des format de l'istruction ADD // index = 0 
            Instruction instruction = new Instruction("AX,imm16", "00000101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,imm16", "10000001xx000xxx", "000");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "00000001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16", "00000011xxxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // l'intialisation des format de l'istruction SUB // index = 1
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("AX,imm16", "00101101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,imm16", "10000001xx101xxx", "101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "00101001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16", "00101011xxxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // l'intialisation des format de l'istruction INC // index = 2
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16", "1000 0xxx", "0"); // we have a bit which can distung between INC and DEC (the forth bit) if 0 :INC else DEC  
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16", "11111111xx000xxx", "000");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // l'intialisation des format de l'istruction DEC // index = 3
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16", "1000 1xxx", "1"); // we have a bit which can distung between INC and DEC (the forth bit) if 0 :INC else DEC  
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16", "11111111xx001xxx", "001");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // l'intialisation des format de l'istruction MUL // index = 4
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16", "11110111xx100xxx", "100");  // the result will be saved in AX if it's in 16bit ... 
            mycouple.addInstruction(instruction);                                 // if it's in 32 bit it'll be saved in DX:AX 
            detailInstruction.Add(mycouple);

            //------------------- transfere instructions ------------------------------------------------------------------
            // l'intialisation des format de l'istruction MOV // index = 5 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16,Reg16/Mem16", "10001011xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "10001001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,imm16", "10100111xx000xxx", "000"); //A7 1100 0000
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,imm16", "10101xxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // l'intialisation des format de l'istruction XCHG // index = 6
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("AX,Reg16", "10010xxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "10000111xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16", "10001001xxxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            //------------------- logic instructions ---------------------------------------------------------------------------------

            // l'intialisation des format de l'istruction NOT // index = 7
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16", "11110111xx010xxx", "010");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // l'intialisation des format de l'istruction AND // index = 8 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "10000001xx100xxx", "100");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "00100001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16", "00100011xxxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // l'intialisation des format de l'istruction OR // index = 9 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("AX,imm16", "00001101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,imm16", "10000001xx001xxx", "001");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "00001001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16", "00001011xxxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // l'intialisation des format de l'istruction XOR // index = 11 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("AX,imm16", "00110101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,imm16", "10000001xx110xxx", "110");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "00110001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16", "00110011xxxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // l'intialisation des instructions de decalages 
            //instruction SHL 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx100xxx", "100");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010011xx100xxx", "100");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction SHR 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx101xxx", "101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010011xx101xxx", "101");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction SAL  -- meme cop que SHL 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx100xxx", "100");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010001xx100xxx", "100");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction SAR 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx111xxx", "111");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010011xx111xxx", "111");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction ROR 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx001xxx", "001");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010011xx001xxx", "001");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction ROL 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx000xxx", "000");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010011xx000xxx", "000");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction RCR 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx011xxx", "011");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010011xx011xxx", "011");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction RCL 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "11000001xx010xxx", "010");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,CX", "11010011xx010xxx", "010");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);

            // instructions d'entree-sorties
            //instruction in
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("AX,DX", "11101101");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction out
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("DX,AX", "11101111");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction insw
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Mem16,DX", "01101101");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            //instruction outsw
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("DX,Mem16", "01101111");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // Initialisation des instructions de branchement 
            // instruction jmp 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Mem16", "1111111100101xxx");      // nouvelle format
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // instruction LOOP 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Mem16", "111000100xxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // instruction LOOPZ
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Mem16", "111000010xxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // instruction LOOPE
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Mem16", "111000011xxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // instruction LOOPNZ
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Mem16", "111000000xxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // instruction LOOPNE 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Mem16", "111000001xxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
            // instruction CMP 
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("Reg16/Mem16,imm16", "10000011xx111xxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16", "00111001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16", "00111011xxxxxxxx");
            mycouple.addInstruction(instruction);


            //--------------------------------------------------------------------------------------------------- 

            //--------------------------------------------------------------------------------------------------- 
        }
        public CoupleCopFormat getMycouple()
        {
            return mycouple;
        }
        // les methodes de remplissage de code operation

        /* private int recherche_index_mnemonique(Mnemoniques inst){ 
             return (int) inst; 
         }*/
        private int recherche_index_mnemonique(string mnemonique)
        {
            Mnemoniques mymnemonique = (Mnemoniques)Enum.Parse(typeof(Mnemoniques), mnemonique);   /// FORMAT COP CHAMPNOTUSED   reg/mem,imm  
            return (int)mymnemonique;
        }
        // instruction = format + cop 
        public Instruction recherche_instruction(CoupleCopFormat mycouple, string format)
        {
            Instruction inst = new Instruction();
            foreach (Instruction instruction in mycouple.getListInstruction())
            {
                if (format.Equals(instruction.getFormat()))
                {
                    inst = instruction;
                    break;
                }
            }
            return inst;
        }
        public string recherche_mem_depl(string reg_mem)
        { //[BX+SI+2345]  = [BX+SI+XXXX]   REPLACE("2345","XXXX");  000 111
            int valendecimale = 0;
            string binaire_val;
            foreach (string r_m in list_mem_dep)
            {
                if (reg_mem.Equals(r_m))
                {
                    valendecimale = Array.IndexOf(list_mem_dep, r_m);
                    break;
                }
            }
            // l'idial est d'utiliser la methode correctionformat dans la class erreur  
            if (valendecimale > 3)
            {
                binaire_val = Convert.ToString(valendecimale, 2);
            }
            else if (valendecimale > 1)
            {
                binaire_val = "0" + Convert.ToString(valendecimale, 2);
            }
            else
            {
                binaire_val = "00" + Convert.ToString(valendecimale, 2);
            }
            return binaire_val;
        }

        public string recherche_mem_sansdepl(string reg_mem)
        {
            int valendecimale = 0;
            string binaire_val;
            foreach (string r_m in list_mem_sansdep)
            {
                if (reg_mem.Equals(r_m))
                {
                    valendecimale = Array.IndexOf(list_mem_sansdep, r_m);
                    break;
                }
            }
            // correction format 
            if (valendecimale > 3)
            {
                binaire_val = Convert.ToString(valendecimale, 2);
            }
            else if (valendecimale > 1)
            {
                binaire_val = "0" + Convert.ToString(valendecimale, 2);
            }
            else
            {
                binaire_val = "00" + Convert.ToString(valendecimale, 2);
            }
            return binaire_val;
        }


        public string recherche_reg(string reg)
        {
            string reg_binaire = "";
            int regvalue_decimal = 0;
            Registers_enum myreg = (Registers_enum)Enum.Parse(typeof(Registers_enum), reg);
            regvalue_decimal = (int)myreg;
            // correction format 
            if (regvalue_decimal > 3)
            {
                reg_binaire = Convert.ToString(regvalue_decimal, 2);
            }
            else if (regvalue_decimal > 1)
            {
                reg_binaire = "0" + Convert.ToString(regvalue_decimal, 2);
            }
            else
            {
                reg_binaire = "00" + Convert.ToString(regvalue_decimal, 2);
            }
            return reg_binaire;
        }
        //cbn:remplir 01 fiha qlq details lzm ytbdlou -- meshi void string .. + deplval et tt rj3hum en binaire -- voir exemple lt7t.
        public string remplir_Reg_mem_imm16(string inst, string Reg_mem, bool ifdepl, string deplval, string imm16_val)
        {   // INST Reg16/mem16,imm16
            string instruction_binaire = "";
            string mod_binaire;
            string r_m_binaire = "";
            int index_of_mnemonique = recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction = new Instruction();
            Console.WriteLine(index_of_mnemonique);
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Reg16/Mem16,imm16");
            instruction_binaire = myinstruction.getCop();
            Console.WriteLine(instruction_binaire);
            string instruction_hexa;
            if (Reg_mem[0] == '[')
            {
                if (ifdepl)
                {
                    mod_binaire = "10";
                    r_m_binaire = recherche_mem_depl(Reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    // j pas compris pourquoi tu traite l'instruction seul 
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire)  + deplval;
                }
                else
                {
                    mod_binaire = "00";
                    r_m_binaire = recherche_mem_sansdepl(Reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
                }
            }
            else
            {
                mod_binaire = "11";
                r_m_binaire = recherche_reg(Reg_mem);
                instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
            }
            instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire) + imm16_val;
            Console.WriteLine("the instruction " + instruction_binaire);
            return instruction_hexa;
        }
        // methode dekhlelha les entrees te3 la pages hedik li 9bal simulation trj3lk instruction en binaire kima t7atha f la MC.
        public string remplir_AX_imm16(string inst, string imm16_val)
        {   // INST AX,imm16 -- 
            // comment distingue le AX des autres registres ?
            // ca sera utile de verifier la valeur si elle est en 16bits + en hexa
            string instruction_binaire;
            int index_of_mnemonique = recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction = new Instruction();
            // il faut traiter le cas ou le format ne figure pas dans l'instruction 
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "AX,imm16");
            instruction_binaire = myinstruction.getCop();
            string instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire) + imm16_val;
            Console.WriteLine("the instruction : " + instruction_binaire);
            return instruction_hexa;
        }
        //public static string remplir_reg16_mem16(string inst ,string Reg_mem,bool ifdepl,string deplval){   // INST reg16/mem16 -- 
        //    string instruction_binaire;  
        //    string r_m_binaire;        
        //    string mod_binaire;
        //    int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
        //    Instruction myinstruction= new Instruction();
        //    myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16/Mem16");
        //    instruction_binaire=myinstruction.getCop();
        //    if(Reg_mem[0].Equals("[")){
        //       if(ifdepl){
        //              mod_binaire="00";
        //              r_m_binaire=recherche_mem_depl(Reg_mem);
        //              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
        //              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
        //              instruction_binaire=instruction_binaire+" "+HexStringToBinary(deplval);//hna dert padleft 7eta l 12 bits brk pasq deplacement max 3 f l'hexa - memoire sghira
        //       }else{
        //              mod_binaire="10";
        //              r_m_binaire=recherche_mem_sansdepl(Reg_mem);
        //              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
        //              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
        //       }
        //    }else{
        //      mod_binaire="11";
        //      r_m_binaire=recherche_reg(Reg_mem);
        //      //Console.WriteLine("im here");
        //      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
        //      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
        //    }
        //    System.Console.WriteLine("instruction en binaire :"+instruction_binaire);
        //    return instruction_binaire;
        //} 
        public string remplir_reg16(string inst, string Reg16)
        {   // INST reg16 -- 
            string instruction_binaire;
            string r_m_binaire;
            int index_of_mnemonique = recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction = new Instruction();
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Reg16");
            instruction_binaire = myinstruction.getCop();
            r_m_binaire = recherche_reg(Reg16);
            instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
            System.Console.WriteLine("instruction en binaire :" + instruction_binaire);
            return JeuxInstruction.BinaryStringToHexString(instruction_binaire);
        }
        //-----------------------------------------------------------------------------------------------------------
        public string remplir_reg_mem_reg(string inst, string reg_mem, string reg, bool ifdepl, string deplval)
        {  // INST REG/MEM,REG
            string instruction_binaire = "";
            string mod_binaire;
            string r_m_binaire;
            string reg_binaire;
            int index_of_mnemonique = recherche_index_mnemonique(inst);
            Instruction myinstruction = new Instruction(); 
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Reg16/Mem16,Reg16");
            instruction_binaire = myinstruction.getCop();
            reg_binaire = recherche_reg(reg);
            /*result = original.Substring(0,start) + replacement + original.Substring(start + length);Console.WriteLine(result);*/
            //  instruction_binaire=instruction_binaire.Substring(0,10)+reg_binaire+instruction_binaire.Substring(13);
            Console.WriteLine(instruction_binaire);
            string instruction_hexa;
            if (reg_mem[0] == '[')
            {
                if (ifdepl)
                {
                    mod_binaire = "10";
                    r_m_binaire = recherche_mem_depl(reg_mem);
                    // instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    //instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_binaire = instruction_binaire.Substring(0, 10) + r_m_binaire + instruction_binaire.Substring(13);
                    instruction_binaire = instruction_binaire.Substring(0, 8) + mod_binaire + instruction_binaire.Substring(10);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire) + deplval;
                }
                else
                {
                    mod_binaire = "00";
                    r_m_binaire = recherche_mem_sansdepl(reg_mem);
                    //instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    //instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_binaire = instruction_binaire.Substring(0, 10) + r_m_binaire + instruction_binaire.Substring(13);
                    instruction_binaire = instruction_binaire.Substring(0, 8) + mod_binaire + instruction_binaire.Substring(10);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
                }
            }
            else
            {
                mod_binaire = "11";
                r_m_binaire = recherche_reg(reg_mem);
                // instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                //instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                instruction_binaire = instruction_binaire.Substring(0, 10) + r_m_binaire + instruction_binaire.Substring(13);
                instruction_binaire = instruction_binaire.Substring(0, 8) + mod_binaire + instruction_binaire.Substring(10);
            }
            instruction_binaire = instruction_binaire.Replace("xxx", reg_binaire);
            instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
            Console.WriteLine("the instruction " + instruction_binaire);
            return instruction_hexa;
        }
        // this is INST Reg16 , Reg16/mem16 c
        public string remplir_reg_reg_mem(string inst, string reg_mem, string reg, bool ifdepl, string deplval)
        {
            string instruction_binaire = "";
            string mod_binaire;
            string r_m_binaire;
            string reg_binaire;
            int index_of_mnemonique = recherche_index_mnemonique(inst);
            Instruction myinstruction = new Instruction();
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Reg16,Reg16/Mem16");

            instruction_binaire = myinstruction.getCop();
            //instruction_binaire= "00110011xxxxxxxx";
            reg_binaire = recherche_reg(reg);
            /*result = original.Substring(0,start) + replacement + original.Substring(start + length);Console.WriteLine(result);*/
            instruction_binaire = instruction_binaire.Substring(0, 10) + reg_binaire + instruction_binaire.Substring(13);
            Console.WriteLine(instruction_binaire);
            string instruction_hexa;
            if (reg_mem[0] == '[')
            {
                if (ifdepl)
                {
                    mod_binaire = "10";
                    r_m_binaire = recherche_mem_depl(reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire) + deplval;
                }
                else
                {
                    mod_binaire = "00";
                    r_m_binaire = recherche_mem_sansdepl(reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
                }
            }
            else
            {
                mod_binaire = "11";
                r_m_binaire = recherche_reg(reg_mem);
                instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
            }

            Console.WriteLine("the instruction " + instruction_binaire);
            return instruction_hexa;
        }
        //---------------------------------------------------------------------------------------------------------- 
        //------------------- 
        public string remplir_reg_mem_cx(string inst, string Reg_mem, bool ifdepl, string deplval)
        {   // INST Reg16/mem16,CX
            string instruction_binaire = "";
            string mod_binaire;
            string r_m_binaire = "";
            int index_of_mnemonique = recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction = new Instruction();
            //Console.WriteLine(index_of_mnemonique);              
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Reg16/mem16,CX");
            instruction_binaire = myinstruction.getCop();
            Console.WriteLine(instruction_binaire);
            string instruction_hexa;
            if (Reg_mem[0] == '[')
            {
                if (ifdepl)
                {
                    mod_binaire = "10";
                    r_m_binaire = recherche_mem_depl(Reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire) + deplval;
                }
                else
                {
                    mod_binaire = "00";
                    r_m_binaire = recherche_mem_sansdepl(Reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
                }
            }
            else
            {
                mod_binaire = "11";
                r_m_binaire = recherche_reg(Reg_mem);
                instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
            }
            Console.WriteLine("the instruction " + instruction_binaire);
            return instruction_hexa;
        }
        public string remplir_mem16(string inst, string mem16, bool ifdepl, string deplval)
        {
            string instruction_binaire = "";
            string mem_binaire = "";
            int index_of_mnemonique = recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction = new Instruction();
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Mem16");
            instruction_binaire = myinstruction.getCop();
            string instruction_hexa;
            // l'instruction jmp est un cas particulier  
            if (instruction_binaire.IndexOf('x') == 13)
            {
                mem_binaire = recherche_mem_sansdepl(mem16);
                instruction_binaire = instruction_binaire.Replace("xxx", mem_binaire);
                instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
            }
            else
            {
                if (ifdepl)
                {
                    // on doit verifie que le deplacement va etre seulement sur 16 bit ;;
                    mem_binaire = recherche_mem_depl(mem16);
                    instruction_binaire = instruction_binaire.Replace("xxxx", HexStringToBinary(deplval));
                    instruction_binaire = instruction_binaire.Replace("xxx", mem_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
                }
                else
                {
                    mem_binaire = recherche_mem_sansdepl(mem16);
                    instruction_binaire = instruction_binaire.Replace("xxxx", "0000");
                    instruction_binaire = instruction_binaire.Replace("xxx", mem_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
                }
            }
            return instruction_hexa ;
        }
        //added remplir methods 
        public string remplir_AX_DX() {

            return JeuxInstruction.BinaryStringToHexString("11101101");
           // return "11101101"; // this instruction doesn't need a decoudage // IN AX,DX
        }

        public string remplir_DX_AX()
        {
            return JeuxInstruction.BinaryStringToHexString("11101111");
           // return "11101111";  // this instruction doesn't need a decoudage // IN DX,AX
        }

        public string remplir_mem16_DX()
        {
            return JeuxInstruction.BinaryStringToHexString("01101101");
          //  return "01101101";  //"mem16,DX","01101101" insw
        }

        public string remplir_DX_mem16()
        {
            return JeuxInstruction.BinaryStringToHexString("01101111");

           // return "01101111";  //"DX,mem16","01101111" outsw
        }

        public string remplir_AX_Reg16(string inst, string Reg16)
        {   // INST AX,reg16 
            string instruction_binaire;
            string r_m_binaire;
            int index_of_mnemonique = recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction = new Instruction();
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "AX,imm16");
            instruction_binaire = myinstruction.getCop();
            r_m_binaire = recherche_reg(Reg16);
            instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
            System.Console.WriteLine("instruction en binaire :" + instruction_binaire);
            return JeuxInstruction.BinaryStringToHexString(instruction_binaire);
        }

        public string remplir_Reg16_imm16(string inst, string Reg16, string imm_val)
        {   // INST reg16,imm16 
            string instruction_binaire;
            string r_m_binaire;
            int index_of_mnemonique = recherche_index_mnemonique(inst);
            Instruction myinstruction = new Instruction();
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Reg16,imm16");
            instruction_binaire = myinstruction.getCop();
            r_m_binaire = recherche_reg(Reg16);
            instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
            System.Console.WriteLine("instruction en binaire :" + instruction_binaire);
            return JeuxInstruction.BinaryStringToHexString(instruction_binaire)+ imm_val;
        }

        public string remplir_reg16_mem16(string inst, string Reg_mem, bool ifdepl, string deplval)
        {   // INST reg16/mem16 -- 
            string instruction_binaire;
            string r_m_binaire;
            string mod_binaire;
            int index_of_mnemonique = recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction = new Instruction();
            myinstruction = recherche_instruction(detailInstruction.ElementAt(index_of_mnemonique), "Reg16/Mem16");
            instruction_binaire = myinstruction.getCop();
            string instruction_hexa;
            if (Reg_mem[0] == '[')
            {
                if (ifdepl)
                {
                    mod_binaire = "10";
                    r_m_binaire = recherche_mem_depl(Reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire) + deplval;//hna dert padleft 7eta l 12 bits brk pasq deplacement max 3 f l'hexa - memoire sghira
               
                }
                else
                {
                    mod_binaire = "00";
                    r_m_binaire = recherche_mem_sansdepl(Reg_mem);
                    instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                    instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                    instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
                }
            }
            else
            {
                mod_binaire = "11";
                r_m_binaire = recherche_reg(Reg_mem);
                //Console.WriteLine("im here");
                instruction_binaire = instruction_binaire.Replace("xxx", r_m_binaire);
                instruction_binaire = instruction_binaire.Replace("xx", mod_binaire);
                instruction_hexa = JeuxInstruction.BinaryStringToHexString(instruction_binaire);
            }
            System.Console.WriteLine("instruction en binaire :" + instruction_binaire);
            return instruction_hexa;
        }



        //------------------------------------------------------ partie execution ---------------------------------------------------
        // methode correction instruction .. 
        // remplir mc -- ecrire_mc (instruction,taille,adresse debut);

        /*
        methode qui manque
          Memoire Centrale -- Case:rech_mc(adresse); // case manque --oussama
          calcul_adresse(); //tous les cas possibles; //UAL --oussama
          positionner_indicateur(); //UAL; --amine.
          set/getContenuReg()                                                --generale //akhrib;

        */









        /*
        ecriture par defaut a l'adresse 0100
        positionnement co
        positionnemt ram / lect rim -> ri
        ex : ADD BX,CX 03D9 lecture we7da
        */
        //---------------------
        /*if(mem){
          string adresse = calculadresse();
          case = recherche_mc(adresse);
          case.setContenu(contenu_user);
        }*/
        //CO.setCo("0100");
        //page phase1;
        //animation(source : "co",destinataire : "ram","adresse");
        //MC.setRam(CO.getCo());
        //Case case = new Case();
        //case = rech_mc("0100");
        //MC.setRim(case.contenu);
        //animation("rim","ri","donnee");
        //setRI(MC.getRim());
        //bouton;
        //page phase2;
        //
        // string format;
        //switch (format){
        // case "Reg16,mem16/Reg16":
        //      if (r_m){ //reg,reg
        //decodage -- delay
        //setContenuRegistre(reg1,val1);
        //setContenuRegistre(reg2,val2);
        //hover (nombreregistre,reg1,reg2);
        //animation(reg_destinataire,ual2,donnee);
        //setUAL2(getContenuReg(reg_dest));
        //animation(reg_source,ual1,donnee);
        //setUAL2(getContenuReg(reg_source));
        /*switch(mnemonique){
          case add: var result = UAL.getUAL1 + UAL.getUAL2(operation en hexa); 
        }*/
        //positionner indicateur(mnemonique,result);
        //animation(UAL,registres,donnee);
        //setContenuRegistre(reg_dest,result);

        //     }else{//reg,mem ADD AX,[SI+DI+5Dh]
        //decodage -- delay
        //setContenuRegistre(reg1,val1);
        //switch(source){
        // case "[SI+DI+depl]" : //setContenuRegistre(SI,val2); //setContenuRegistre(DI,val3);
        //}
        //hover (nombreregistre,reg1,reg2);
        //animation(UAL,RAM,adresse);
        //MC.setRAM(calaculadresse());
        //MC.setRIM(rech_mc(adresse).getContenu());
        //animation(RIM,UAL1) -- destinataire f ual2 / source ual1
        //UAL.setUAL1(MC.getRIM());
        //animation(reg,UAL2);
        //UAL.setUAL2(getContenuReg(reg_dest));
        //animation(reg_destinataire,ual2,donnee);
        //setUAL2(getContenuReg(reg_dest));
        //animation(reg_source,ual1,donnee);
        //setUAL2(getContenuReg(reg_dest));

        /*switch(mnemonique){
          case add: var result = UAL.getUAL1 + UAL.getUAL2(operation en hexa); 
        }*/
        //positionner indicateur(mnemonique,result);
        //animation(UAL,registres,donnee);
        //setContenuRegistre(reg_dest,result);
        //    }
        //    break;
        //   case "":
        // code to be executed if expression equals value2
        //     break;

        ///   default:
        // code to be executed if none of the above cases are true
        //  break;
        //   }  

        //------------------------------------------------------------------------------------------


        public static async void format_reg_regOUmem(string mnemonique, string format, bool mem_b, string distinataire, bool ifdepl, string valdepl, string contenueCaseMemoire, string source, string val1, string val2, string val3, List<System.Windows.Controls.Image> Images)
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
                if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                Animation.AnimateImage3(Images[79], Images[81], Images[84], -1165, -30, -550, -365, 300, 1);
                Animation.AnimateImage3(Images[78], Images[82], Images[85], -1165, -30, -550, -365, 300, 1);
                Animation.AnimateImage3(Images[80], Images[83], Images[86], -1165, -30, -550, -365, 300, 1);
                await Task.Delay(TimeSpan.FromSeconds(4));
                MC.setRim(contenueCaseMemoire);
                // animation (rim,ual2,donnee) ; 
                Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
                Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
                Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
                UAL.setUal2(MC.getRim());
                await Task.Delay(TimeSpan.FromSeconds(2));
                Registre.setContenuRegistre(distinataire, val1);
                // animation (registre,ual1,donnee);
                Animation.AnimateImage(Images[21], Images[9], -1020, 8, -70, 1);
                Animation.AnimateImage(Images[22], Images[10], -1020, 8, -70, 1);
                Animation.AnimateImage(Images[23], Images[11], -1020, 8, -70, 1);
                await Task.Delay(TimeSpan.FromSeconds(2));
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
                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                Animation.AnimateImage2(Images[70], Images[73], -1165, -30, -1210, -465, 1);
                Animation.AnimateImage2(Images[71], Images[74], -1165, -30, -1210, -465, 1);
                Animation.AnimateImage2(Images[69], Images[72], -1165, -30, -1210, -465, 1);

                MC.setRim(result);
                await Task.Delay(TimeSpan.FromSeconds(2));
                // vu que xchng a une animation particulier on va la traiter dans le switch
                if (mnemonique == "XCHG")
                {
                    Animation.AnimateImage2(Images[57], Images[54], -1165, -30, -1210, -465, 1);
                    Animation.AnimateImage2(Images[58], Images[55], -1165, -30, -1210, -465, 1);
                    Animation.AnimateImage2(Images[59], Images[56], -1165, -30, -1210, -465, 1);

                }
            }
            else
            {

                Registre.setContenuRegistre(distinataire, val1);
                Registre.setContenuRegistre(source, val2);
                UAL.setUal2(Registre.getContenuRegistre(source));
                UAL.setUal1(Registre.getContenuRegistre(distinataire));
                // animation(reg,ual1,donne);
                //Registre to ual1  
                if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                Animation.AnimateImage(Images[21], Images[6], -900, 8, -70, 1);
                Animation.AnimateImage(Images[22], Images[7], -900, 8, -70, 1);
                Animation.AnimateImage(Images[23], Images[8], -900, 8, -70, 1);

                //animation (reg,ual2,donne); 
                await Task.Delay(TimeSpan.FromSeconds(2));
                Animation.AnimateImage(Images[24], Images[9], -1020, 8, -70, 1);
                Animation.AnimateImage(Images[25], Images[10], -1020, 8, -70, 1);
                Animation.AnimateImage(Images[26], Images[11], -1020, 8, -70, 1);

                await Task.Delay(TimeSpan.FromSeconds(2));
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


                // animation(ual, registre, donne);
                // sortie to registr
                UAL.positionnerIndicateurs(mnemonique, result, UAL.getUal1(), UAL.getUal2());
                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                Animation.AnimateImage2(Images[57], Images[54], -1165, -30, -1210, -465, 1);
                Animation.AnimateImage2(Images[58], Images[55], -1165, -30, -1210, -465, 1);
                Animation.AnimateImage2(Images[59], Images[56], -1165, -30, -1210, -465, 1);
                Registre.setContenuRegistre(distinataire, result);
                JeuxInstruction.SetInt(result);



            }


        }
        public static async void format_ax_reg(string mnenmonique, string source, string valAx, string valsource, List<System.Windows.Controls.Image> Images, string format, bool RegM)
        {
            Registre.setAx(valAx);
            Registre.setContenuRegistre(source, valsource);
            if (Animation.btnclick == true) { Phase2(mnenmonique, format, RegM); await Task.Delay(20000); }
            // animation (registre , ual1 , donne ); 
            Animation.AnimateImage(Images[21], Images[6], -900, 8, -70, 1);
            Animation.AnimateImage(Images[22], Images[7], -900, 8, -70, 1);
            Animation.AnimateImage(Images[23], Images[8], -900, 8, -70, 1);
            await Task.Delay(TimeSpan.FromSeconds(2));
            UAL.setUal1(Registre.getAx());

            // animation (registre ,ual2, donne ) ; 
            Animation.AnimateImage(Images[24], Images[9], -1020, 8, -70, 1);
            Animation.AnimateImage(Images[25], Images[10], -1020, 8, -70, 1);
            Animation.AnimateImage(Images[26], Images[11], -1020, 8, -70, 1);
            await Task.Delay(TimeSpan.FromSeconds(2));
            UAL.setUal2(Registre.getContenuRegistre(source));
            Registre.setAx(UAL.getUal2());
            Registre.setContenuRegistre(source, UAL.getUal1());
            JeuxInstruction.SetInt(Registre.getContenuRegistre(source));
            switch (mnenmonique)
            {
                //xchg , 
                case "XCHG":
                    // animation (ual , registre , donne )
                    if (Animation.btnclick == true) { Phase3(mnenmonique, format, RegM); await Task.Delay(20000); }
                    Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
                    Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
                    Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);
                    UAL.positionnerIndicateurs(mnenmonique);
                    // animation (ual,registre , donne ); 


                    // positionner les indicateur ; 
                    break;
                default:
                    Console.WriteLine("il ya un erreur");
                    break;
            }
        }
        public static async void format_ax_imm16(string mnemonique, string valAx, string valImmediate16, List<System.Windows.Controls.Image> Images, string format, bool RegM)
        {
            // ici je vais faire un petite bloc du code pour intialisé la 2eme case de la memoire par la valeur immidiate
            Case case_memoire = new Case();
            // case_memoire = MC.recherche_mc("0101");
            //case_memoire.setContenu(valImmediate16);
            case_memoire.setAdr("0101");
            // MC.AjouterCase(Convert.ToInt32("0101",16),case_memoire); 
            // fin de l'intialisation 
            Registre.setAx(valAx);
            if (Animation.btnclick == true) { Phase2(mnemonique, format, RegM); await Task.Delay(20000); }

            // animation(registre,ual1,donne); 
            Animation.AnimateImage(Images[21], Images[9], -1020, 8, -70, 1);
            Animation.AnimateImage(Images[22], Images[10], -1020, 8, -70, 1);
            Animation.AnimateImage(Images[23], Images[11], -1020, 8, -70, 1);
            await Task.Delay(2000);
            Co.incCo();
            // animation(co,ram,adresse); 
            Animation.AnimateImage1(Images[48], 300, 190, 1);
            Animation.AnimateImage1(Images[49], 300, 190, 1);
            Animation.AnimateImage1(Images[50], 300, 190, 1);
            await Task.Delay(2000);
            MC.setRam(Co.getco());
            //  case_memoire = MC.recherche_mc(Co.getco());
            // MC.setRim(case_memoire.getContenu());
            // animation (rim,ual2,donne) ; 
            Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
            Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
            Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
            await Task.Delay(2000);
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
            if (Animation.btnclick == true) { Phase3(mnemonique, format, RegM); await Task.Delay(10000); }
            Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
            Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
            Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);

        }

        public static void format_dx_ax(string mnenmonique, string valDx, string valAx)
        {
            // out 
        }

        public static async void format_reg16(string mnemonique, string reg, string valReg, List<System.Windows.Controls.Image> Images, string format, bool RegM)
        {
            //inc , dec 

            Registre.setContenuRegistre(reg, valReg);
            string result = "";
            // animation (registre, UAL1, donne ); 
            //Registre to ual1  
            if (Animation.btnclick == true) { Phase2(mnemonique, format, RegM); await Task.Delay(20000); }
            Animation.AnimateImage(Images[21], Images[6], -900, 8, -70, 1);
            Animation.AnimateImage(Images[22], Images[7], -900, 8, -70, 1);
            Animation.AnimateImage(Images[23], Images[8], -900, 8, -70, 1);
            await Task.Delay(TimeSpan.FromSeconds(2));
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
            if (Animation.btnclick == true) { Phase3(mnemonique, format, RegM); await Task.Delay(20000); }
            Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
            Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
            Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);
            await Task.Delay(TimeSpan.FromSeconds(2));
            Registre.setContenuRegistre(reg, result);

        }

        public static async void format_reg16_imm16(string mnemonique, string reg, string valReg, string valImm16, List<System.Windows.Controls.Image> Images, string format, bool RegM)
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
            //Registre to ual1  
            if (Animation.btnclick == true) { Phase2(mnemonique, format, RegM); await Task.Delay(20000); }
            Animation.AnimateImage(Images[21], Images[9], -1020, 8, -70, 1);
            Animation.AnimateImage(Images[22], Images[10], -1020, 8, -70, 1);
            Animation.AnimateImage(Images[23], Images[11], -1020, 8, -70, 1);
            await Task.Delay(2000);
            UAL.setUal1(Registre.getContenuRegistre(reg));
            Co.incCo();
            // animation(co , ram , adresse ) ; 
            Animation.AnimateImage1(Images[48], 300, 190, 1);
            Animation.AnimateImage1(Images[49], 300, 190, 1);
            Animation.AnimateImage1(Images[50], 300, 190, 1);
            await Task.Delay(2000);
            MC.setRam(Co.getco());
            // case_memoire = MC.recherche_mc(Co.getco());
            //MC.setRim(case_memoire.getContenu());
            // animation (rim,ual2,donne) ;
            // // // Rim to Ual2 
            Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
            Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
            Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
            await Task.Delay(2000);
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
            //animation(ual , registre , donne  )  ;
            // // ual to registr
            if (Animation.btnclick == true) { Phase3(mnemonique, format, RegM); await Task.Delay(20000); }
            Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
            Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
            Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);

        }

        public static async void format_dx_mem16(string mnemonique, string ccm, string mem, bool ifdepl, string valDepl, string valdx, string valmem1, string valmem2, List<System.Windows.Controls.Image> Images)
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
            // animation ( UAL ,RAM ,adresse ) 
            Animation.AnimateImage3(Images[19], Images[16], Images[34], -1165, -30, -550, -365, 300, 1);
            Animation.AnimateImage3(Images[18], Images[15], Images[33], -1165, -30, -550, -365, 300, 1);
            Animation.AnimateImage3(Images[20], Images[17], Images[35], -1165, -30, -550, -365, 300, 1);
            await Task.Delay(TimeSpan.FromSeconds(4));
            MC.setRam(adresse);
            // ajouter la case memoire  dans l'adresse pointé 
            Case case_memoire = new Case();
            case_memoire.setAdr(adresse);
            case_memoire.setContenu(ccm);
            //MC.AjouterCase(Convert.ToInt32(adresse, 16), case_memoire);
            //  
            MC.setRim(ccm);
            // animation (rim,ual2,donne) 
            // // // Rim to Ual2 
            projet.Animation.AnimateImage(Images[0], Images[9], -1010, 10, -70, 7);
            projet.Animation.AnimateImage(Images[4], Images[10], -1010, 8, -70, 7);
            projet.Animation.AnimateImage(Images[2], Images[11], -1010, 6, -70, 7);
            await Task.Delay(TimeSpan.FromSeconds(2));
            UAL.setUal2(MC.getRim());
            // animation ( registre , ual1, donne) ;
            // //Registre to ual1  
            projet.Animation.AnimateImage(Images[21], Images[6], -900, 8, -70, 1);
            projet.Animation.AnimateImage(Images[22], Images[7], -900, 8, -70, 1);
            projet.Animation.AnimateImage(Images[23], Images[8], -900, 8, -70, 1);
            await Task.Delay(TimeSpan.FromSeconds(2));
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
        public async static void executer_simulation_phase_a_phase(string mnemonique, string format, bool mem_b, String mem, bool ifdepl, string valdepl, string ccm, string source, string val1, string val2, string val3, List<System.Windows.Controls.Image> Images, string CoForLoop = "default")
        {

            Case case_memoire = new Case();
            string result = "";
            //    if (mem_b)
            //      {//mem_b memoire booleen variable qui dit si c'est memoire ou pas
            //******* cette methode ne fonction pas dans ce cas car le contenue de registre n'est pas encore postionné
            string adressee = UAL.calculAdresse(mem, ifdepl, valdepl);
            //    case_memoire = MC.recherche_mc(adressee);
            case_memoire.setContenu(ccm);
            int delay = 0;
            Co.setco("0100");
            if (Animation.btnclick == true) { Phase1(); await Task.Delay(20000); }

            //page phase1;
            //animation(source : "co",destinataire : "ram",type : "adresse");
            Animation.AnimateImage1(Images[75], 300, 190, 1);
            Animation.AnimateImage1(Images[76], 300, 190, 1);
            Animation.AnimateImage1(Images[77], 300, 190, 1);
            await Task.Delay(TimeSpan.FromSeconds(2));
            MC.setRam(Co.getco());

            // case_memoire = MC.recherche_mc("0100");
            case_memoire.setAdr(Co.getco());
            case_memoire.setContenu(ccm);
            MC.setRim(case_memoire.getContenu());
            //animation("rim","ri","donnee");
            Animation.AnimateImage(Images[0], Images[3], -710, 10, -40, 1);
            Animation.AnimateImage(Images[1], Images[4], -710, 8, -40, 1);
            Animation.AnimateImage(Images[2], Images[5], -710, 6, -40, 1);
            Ri.setRi(MC.getRim());

            //bool skip = false;
            //if (format == "AX,imm16")
            //{

            //    setRiInFront(getInstructionInBinaire(mnemonique, format, mem_b, mem, source, ifdepl, valdepl, val2));
            //    skip = true;
            //}
            //if (format == "Reg16/Mem16,imm16" && (mem_b == true))
            //{
            //    setRiInFront(getInstructionInBinaire(mnemonique, format, mem_b, mem, source, ifdepl, valdepl, val3));
            //    skip = true;
            //}
            //if (format == "Reg16/Mem16,imm16" && (mem_b == false))
            //{
            //    setRiInFront(getInstructionInBinaire(mnemonique, format, mem_b, mem, source, ifdepl, valdepl, val2));
            //    skip = true;
            //}
            //if (!skip)
            //{
            //    setRiInFront(getInstructionInBinaire(mnemonique, format, mem_b, mem, source, ifdepl, valdepl, "0000"));
            //}

            //bouton ou bien delay;

            await Task.Delay(TimeSpan.FromSeconds(2));
            //page phase2;
            switch (format)
            {
                case "Reg16/mem16,Reg16":
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
                        if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                        // animation(UAL,RAM,adresse); 
                        Animation.AnimateImage3(Images[79], Images[81], Images[84], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[78], Images[82], Images[85], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[80], Images[83], Images[86], -1165, -30, -550, -365, 300, 1);
                        await Task.Delay(TimeSpan.FromSeconds(4));
                        MC.setRam(adresse);
                        //case_memoire = MC.recherche_mc(adresse);
                        //case_memoire.setContenu(ccm);
                        MC.setRim(ccm);
                        // animation(RIM,UAL1,DONNE); 
                        Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
                        Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
                        Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
                        UAL.setUal1(ccm);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        // animation(registre, UAL2 ,DONNE); 
                        Animation.AnimateImage(Images[21], Images[9], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[22], Images[10], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[23], Images[11], -1020, 8, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));

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
                        if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                        UAL.positionnerIndicateurs(mnemonique, result, ccm, val1);
                        Animation.AnimateImage2(Images[43], Images[37], -1165, -30, -170, -100, 1);
                        Animation.AnimateImage2(Images[42], Images[36], -1165, -30, -170, -100, 1);
                        Animation.AnimateImage2(Images[44], Images[38], -1165, -30, -170, -100, 1);
                        // animation(ual,rim,donne)
                        MC.setRim(result);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        // vu que xchng a une animation particulier on va la traiter dans le switch
                        if (mnemonique == "XCHG")
                        {
                            Animation.AnimateImage2(Images[57], Images[54], -1165, -30, -1210, -465, 1);
                            Animation.AnimateImage2(Images[58], Images[55], -1165, -30, -1210, -465, 1);
                            Animation.AnimateImage2(Images[59], Images[56], -1165, -30, -1210, -465, 1);

                        }

                    }
                    else
                    { // la on est dans ke cas de reg,reg 
                        Registre.setContenuRegistre(mem, val1);
                        Registre.setContenuRegistre(source, val2);
                        // animation(registre,ual1,donne) ; 
                        if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                        //Registre to ual1  
                        Animation.AnimateImage(Images[21], Images[6], -900, 8, -70, 1);
                        Animation.AnimateImage(Images[22], Images[7], -900, 8, -70, 1);
                        Animation.AnimateImage(Images[23], Images[8], -900, 8, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        UAL.setUal1(Registre.getContenuRegistre(mem));

                        //animation (reg,ual2,donne); 
                        Animation.AnimateImage(Images[24], Images[9], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[25], Images[10], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[26], Images[11], -1020, 8, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));

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
                                result = ccm;
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
                        if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                        UAL.positionnerIndicateurs(mnemonique, result, UAL.getUal1(), UAL.getUal2());
                        Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
                        Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
                        Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);

                        JeuxInstruction.SetInt(result);


                    }
                    break;
                case "Reg16,Reg16/mem16":
                    format_reg_regOUmem(mnemonique, format, mem_b, mem, ifdepl, valdepl, ccm, source, val1, val2, val3, Images);
                    break;
                case "AX,Reg16":
                    format_ax_reg(mnemonique, source, val1, val2, Images, format, mem_b);
                    break;
                case "AX,imd16":
                    format_ax_imm16(mnemonique, val1, val2, Images, format, mem_b);
                    break;
                case "Reg16":
                    format_reg16(mnemonique, source, val1, Images, format, mem_b);
                    break;
                case "Reg16,imm16":
                    format_reg16_imm16(mnemonique, source, val1, val3, Images, format, mem_b);
                    break;
                // mem16
                case "mem16":
                    //decodage -- delay
                    if (ifdepl)
                    {
                        switch (source)
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
                        switch (source)
                        {
                            case "[BX+SI]":
                                Registre.setContenuRegistre("BX", val1);
                                Registre.setContenuRegistre("SI", val2);
                                break;
                            case "[BX+DI]":
                                Registre.setContenuRegistre("BX", val1);
                                Registre.setContenuRegistre("DI", val2);
                                break;
                            case "[BP+SI]":
                                Registre.setContenuRegistre("BP", val1);
                                Registre.setContenuRegistre("SI", val2);
                                break;
                            case "[BP+DI]":
                                Registre.setContenuRegistre("BP", val1);
                                Registre.setContenuRegistre("DI", val2);
                                break;
                            case "[SI]":
                                Registre.setContenuRegistre("SI", val1);
                                break;
                            case "[DI]":
                                Registre.setContenuRegistre("DI", val1);
                                break;
                            case "[BP]":
                                Registre.setContenuRegistre("BP", val1);
                                break;
                            case "[BX]":
                                Registre.setContenuRegistre("BX", val1);
                                break;
                            default:
                                System.Console.WriteLine("Error ! no such mem_depl");
                                break;
                        }
                    }
                    //hover (nombreregistre,reg1,reg2);
                    //animation(Registre,CO,adresse);
                    Registre.setCx(val1);// f loop user must set CX content ... 
                    switch (mnemonique)
                    {

                        case "JMP":
                            Co.setco(UAL.calculAdresse(mem, ifdepl, valdepl));
                            MC.setRam(Co.getco());
                            MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                            UAL.positionnerIndicateurs("JMP");
                            //normalement c'est ca mnkmlush l'execution de la suite --
                            break;
                        case "LOOP":

                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                Registre.setCx(Convert.ToString((int.Parse(Registre.getCx()) - 1)));
                                UAL.positionnerIndicateurs("LOOP");
                                executer_simulation_phase_a_phase("INC", "Reg16", false, "SP", false, "0000", "0000", "0000", Registre.getSp(), "0000", "0000", Images, Co.getco());
                                Co.setco(UAL.calculAdresse(mem, ifdepl, valdepl));
                                MC.setRam(Co.getco());
                                MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                                //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                                //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                            }
                            //apres loop 
                            //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                            break;
                        case "LOOPZ":
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() != '1')
                                {
                                    UAL.positionnerIndicateurs("LOOPZ");
                                    Co.setco(UAL.calculAdresse(mem, ifdepl, valdepl));
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
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() == '1')
                                {
                                    UAL.positionnerIndicateurs("LOOPE");
                                    Co.setco(UAL.calculAdresse(mem, ifdepl, valdepl));
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
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() != '0')
                                {
                                    UAL.positionnerIndicateurs("LOOPNZ");
                                    Co.setco(UAL.calculAdresse(mem, ifdepl, valdepl));
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
                            for (int i = 0; i < int.Parse(Registre.getCx()) - 1; i++)
                            {
                                if (Indicateur.getZero() != '0')
                                {
                                    UAL.positionnerIndicateurs("LOOPNE");
                                    Co.setco(UAL.calculAdresse(mem, ifdepl, valdepl));
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
                case "Reg16/mem16":
                    if (mem_b)
                    {
                        if (ifdepl)
                        {
                            switch (mem)
                            {
                                case "[BX+SI+depl]":
                                    Registre.setContenuRegistre("BX", val3);
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[BX+DI+depl]":
                                    Registre.setContenuRegistre("BX", val3);
                                    Registre.setContenuRegistre("DI", val1);
                                    break;
                                case "[BP+SI+depl]":
                                    Registre.setContenuRegistre("BP", val3);
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[BP+DI+depl]":
                                    Registre.setContenuRegistre("BP", val3);
                                    Registre.setContenuRegistre("DI", val1);
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
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[BX+DI]":
                                    Registre.setContenuRegistre("BX", val3);
                                    Registre.setContenuRegistre("DI", val1);
                                    break;
                                case "[BP+SI]":
                                    Registre.setContenuRegistre("BP", val3);
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[BP+DI]":
                                    Registre.setContenuRegistre("BP", val3);
                                    Registre.setContenuRegistre("DI", val1);
                                    break;
                                case "[SI]":
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[DI]":
                                    Registre.setContenuRegistre("DI", val1);
                                    break;
                                case "[BP]":
                                    Registre.setContenuRegistre("BP", val1);
                                    break;
                                case "[BX]":
                                    Registre.setContenuRegistre("BX", val1);
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        //hover (nombreregistre,reg1,reg2);

                        //animation (Registres,RAM,adresse)
                        if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                        Animation.AnimateImage3(Images[79], Images[81], Images[84], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[78], Images[82], Images[85], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[80], Images[83], Images[86], -1165, -30, -550, -365, 300, 1);
                        await Task.Delay(TimeSpan.FromSeconds(4));
                        string adresse = UAL.calculAdresse(mem, ifdepl, valdepl);
                        MC.setRam(adresse);
                        //    MC.setRim(MC.recherche_mc(adresse).getContenu());

                        //case_memoire.setAdr(Co.getco());
                        case_memoire.setContenu(ccm);
                        MC.setRim(case_memoire.getContenu());

                        //animation(Rim,UAL2,donee)
                        Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
                        Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
                        Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
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
                                //animation (UAL,rim);
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                Animation.AnimateImage2(Images[43], Images[37], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[42], Images[36], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[44], Images[38], -1165, -30, -170, -100, 1);

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
                                //animation (UAL,rim);
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                Animation.AnimateImage2(Images[43], Images[37], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[42], Images[36], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[44], Images[38], -1165, -30, -170, -100, 1);
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "MUL":
                                //in this instruction user must specify content of BX
                                Registre.setBx(val2);
                                //hover registre
                                //animation (registre,UAL1);

                                Animation.AnimateImage(Images[24], Images[9], -1020, 8, -70, 1);
                                Animation.AnimateImage(Images[25], Images[10], -1020, 8, -70, 1);
                                Animation.AnimateImage(Images[26], Images[11], -1020, 8, -70, 1);
                                await Task.Delay(TimeSpan.FromSeconds(2));

                                BigInteger bi1 = BigInteger.Parse(UAL.getUal2(), NumberStyles.HexNumber);
                                BigInteger bi2 = BigInteger.Parse(Registre.getBx(), NumberStyles.HexNumber);
                                BigInteger result_mul = bi1 * bi2;
                                string hexResult = result_mul.ToString("X8");//32 bits representation
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("MUL", hexResult, UAL.getUal1(), UAL.getUal2());
                                //animation(UAL,registre,donnee);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);
                                await Task.Delay(TimeSpan.FromSeconds(2));

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
                                //animation (UAL,rim);
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                Animation.AnimateImage2(Images[43], Images[37], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[42], Images[36], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[44], Images[38], -1165, -30, -170, -100, 1);
                                MC.setRim(hexResult);
                                //  MC.recherche_mc(adresse).setContenu(hexResult);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {

                    }
                    break;
                case "Reg16/Mem16,imm16":
                    if (mem_b)
                    {
                        if (ifdepl)
                        {
                            switch (mem)
                            { //khdmt b source mais f hed le cas c'est destinataire -- nom a revoir
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
                                    Registre.setContenuRegistre("BX", val1);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BX+DI]":
                                    Registre.setContenuRegistre("BX", val1);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[BP+SI]":
                                    Registre.setContenuRegistre("BP", val1);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BP+DI]":
                                    Registre.setContenuRegistre("BP", val1);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[SI]":
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[DI]":
                                    Registre.setContenuRegistre("DI", val1);
                                    break;
                                case "[BP]":
                                    Registre.setContenuRegistre("BP", val1);
                                    break;
                                case "[BX]":
                                    Registre.setContenuRegistre("BX", val1);
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        //hover (nombreregistre,reg1,reg2);

                        //animation (Registres,RAM,adresse)
                        if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                        Animation.AnimateImage3(Images[79], Images[81], Images[84], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[78], Images[82], Images[85], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[80], Images[83], Images[86], -1165, -30, -550, -365, 300, 1);
                        await Task.Delay(TimeSpan.FromSeconds(4));
                        string adresse = UAL.calculAdresse(mem, ifdepl, valdepl);
                        MC.setRam(adresse);
                        // MC.setRim(MC.recherche_mc(adresse).getContenu());
                        //animation(Rim,UAL1,donnee)
                        Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
                        Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
                        Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        UAL.setUal1(val2);
                        //on lit le deuxieme mot memoire pour avoir l'operande immediat
                        Co.setco("0101");//premier mot adresse 100 deuxieme adresse 101
                        //animation(CO,RAM,adresse);
                        Animation.AnimateImage1(Images[60], 300, 190, 1);
                        Animation.AnimateImage1(Images[61], 300, 190, 1);
                        Animation.AnimateImage1(Images[62], 300, 190, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        MC.setRam("0101");
                        // MC.setRim(MC.recherche_mc("0101").getContenu());
                        //animation(Rim,UAL2,donee)
                        Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
                        Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
                        Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
                        UAL.setUal2(ccm);
                        if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(10000); }
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
                                //animation(CO,ram,adresse)
                                //Animation.AnimateImage1(Images[48], 300, 190, 1);
                                //Animation.AnimateImage1(Images[49], 300, 190, 1);
                                //Animation.AnimateImage1(Images[50], 300, 190, 1);
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                MC.setRim(result);

                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "SUB":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                // UAL.positionnerIndicateurs("SUB", result);
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("SUB", result, UAL.getUal1(), UAL.getUal2());
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                MC.setRim(result);
                                JeuxInstruction.SetInt(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "MOV":
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("MOV", result);
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("MOV", result, UAL.getUal1(), UAL.getUal2());
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                JeuxInstruction.SetInt(UAL.getUal2());
                                MC.setRim(UAL.getUal2());
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "AND":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) & Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("AND", result);
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("AND", result, UAL.getUal1(), UAL.getUal2());
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                JeuxInstruction.SetInt(result);
                                MC.setRim(result);
                                // MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "OR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                UAL.positionnerIndicateurs("OR", result);
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("OR", result, UAL.getUal1(), UAL.getUal2());
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                JeuxInstruction.SetInt(result);
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "XOR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("XOR", result);
                                //ecriture des resultats
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("XOR", result, UAL.getUal1(), UAL.getUal2());
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                JeuxInstruction.SetInt(result);
                                MC.setRim(result);
                                //MC.recherche_mc(adresse).setContenu(result);
                                //fin
                                break;
                            case "SHL":
                                //ushort pour 16-bit representation
                                ushort destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                ushort count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                           // Shift the destination left by the count value
                                string str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                string str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // UAL.positionnerIndicateurs("SHL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((destination & 0x8000) != 0);
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
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("SHL", str_res, val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);

                                MC.setRim(destination.ToString("X"));
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                    // Shift the destination left by the count value
                                str_op2 = destination.ToString("X4");
                                destination = (ushort)(destination >> count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SHR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x0001) != 0);
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
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("SHR", str_res, val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);

                                MC.setRim(destination.ToString("X"));
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                    // Check the value of the MSB before the shift
                                bool signBit = (destination & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                destination = (ushort)(destination << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (destination & 0x8000) != 0;
                                str_op2 = destination.ToString("X4");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SAL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("SAL", str_res, val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);

                                MC.setRim(destination.ToString("X"));
                                // MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAR":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                    // Check the value of the MSB before the shift
                                signBit = (destination & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                destination = (ushort)(destination >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = destination.ToString("X4");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SAR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("SAR", str_res, val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                MC.setRim(destination.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "ROR":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (destination << (16 - count)));
                                bool carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X4");
                                string str_op1 = count.ToString("X4");
                                destination = (ushort)(destination << count);
                                JeuxInstruction.SetInt(destination.ToString("X4"));
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
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("ROR", destination.ToString("X4"), val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                MC.setRim(destination.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());

                                break;
                            case "ROL":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination << count) | (destination >> (16 - count)));
                                carryFlag = (destination & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X4");
                                str_op1 = count.ToString("X4");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("ROL", destination.ToString("X4"), val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X4");
                                str_op1 = count.ToString("X4");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("RCR", destination.ToString("X4"), val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                MC.setRim(destination.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());

                                break;
                            case "RCL":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (destination & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    destination = (ushort)((destination << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = destination.ToString("X4");
                                str_op1 = count.ToString("X4");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("RCL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (destination & 0x8000) != 0;
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
                                //animation(CO,ram,adresse)
                                if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                                UAL.positionnerIndicateurs("RCL", destination.ToString("X4"), val2, ccm);
                                Animation.AnimateImage(Images[51], Images[9], -910, 10, -70, 1);
                                Animation.AnimateImage(Images[52], Images[10], -910, 8, -70, 1);
                                Animation.AnimateImage(Images[53], Images[11], -910, 6, -70, 1);
                                await Task.Delay(2000);
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)

                                Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -170, -100, 1);
                                Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -170, -100, 1);
                                MC.setRim(destination.ToString("X"));
                                //MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "CMP":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
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
                     //animation registre to ual1
                        if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                        Animation.AnimateImage(Images[21], Images[9], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[22], Images[10], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[23], Images[11], -1020, 8, -70, 1);
                        await Task.Delay(2000);
                        Registre.setContenuRegistre(mem, val1);//val3 valeur te3 registre // une autre fois je travaille avec source alors que c'est destinataire -- juste notation
                        UAL.setUal1(val1);
                        //on lit le deuxieme mot memoire pour avoir l'operande immediat
                        Co.setco("0101");//premier mot adresse 100 deuxieme adresse 101
                                         //animation(CO,RAM,adresse);
                        Animation.AnimateImage1(Images[60], 300, 190, 1);
                        Animation.AnimateImage1(Images[61], 300, 190, 1);
                        Animation.AnimateImage1(Images[62], 300, 190, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        MC.setRam("0101");
                        // MC.setRim(MC.recherche_mc("0101").getContenu());
                        Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
                        Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
                        Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
                        await Task.Delay(2000);
                        UAL.setUal2(val2);

                        string r = UAL.getUal1();
                        string r1 = UAL.getUal2();

                        switch (mnemonique)
                        {
                            case "SHL":
                                //ushort pour 16-bit representation
                                ushort destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                ushort count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                                    // Shift the destination left by the count value
                                string str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                string str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // UAL.positionnerIndicateurs("SHL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((destination & 0x8000) != 0);
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

                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                             // Shift the destination left by the count value
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination >> count);
                                str_res = destination.ToString("X");
                                // UAL.positionnerIndicateurs("SHR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x0001) != 0);
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
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                bool signBit = (destination & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                destination = (ushort)(destination << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (destination & 0x8000) != 0;
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X");
                                //UAL.positionnerIndicateurs("SAL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "SAR":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                signBit = (destination & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                destination = (ushort)(destination >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X");
                                // UAL.positionnerIndicateurs("SAR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "ROR":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (destination << (16 - count)));
                                bool carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                string str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X");
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
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                Registre.setContenuRegistre(source, destination.ToString("X"));

                                break;
                            case "ROL":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination << count) | (destination >> (16 - count)));
                                carryFlag = (destination & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X");
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
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X");
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
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                Registre.setContenuRegistre(source, destination.ToString("X"));

                                break;
                            case "RCL":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (destination & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    destination = (ushort)((destination << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X");
                                //UAL.positionnerIndicateurs("RCL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (destination & 0x8000) != 0;
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
                                JeuxInstruction.SetInt(destination.ToString("X"));
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "CMP":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                UAL.positionnerIndicateurs("CMP", result);
                                break;
                            case "ADD":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) + Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                // UAL.positionnerIndicateurs("ADD", result);
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(source, result);
                                //fin
                                break;
                            case "SUB":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) - Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("SUB", result);
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(source, result);
                                //fin
                                break;
                            case "MOV":
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("MOV", result);
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(source, result);
                                break;
                            case "AND":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) & Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("AND", result);
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(source, result);
                                //fin
                                break;
                            case "OR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) | Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("OR", result);
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(source, result);
                                //fin
                                break;
                            case "XOR":
                                result = (Convert.ToInt32(UAL.getUal1(), 16) ^ Convert.ToInt32(UAL.getUal2(), 16)).ToString("X");
                                //animation Indicateurs
                                //UAL.positionnerIndicateurs("XOR", result);
                                //ecriture des resultats
                                //animation(UAL,registre)
                                JeuxInstruction.SetInt(result);
                                Registre.setContenuRegistre(source, result);
                                //fin
                                break;
                            default:
                                System.Console.WriteLine("error ! no such mnemonique");
                                break;
                        }
                        if (mnemonique != "CMP")
                        {
                            if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                            UAL.positionnerIndicateurs(mnemonique, JeuxInstruction.GetInt(), val2, ccm);
                            Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
                            Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
                            Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);
                        }
                    }
                    break;
                case "AX,DX":
                    switch (mnemonique)
                    {
                        case "IN":
                            //animation registre(ax,dx)
                            //afficher fenetre (contient numero periph ex : clavier) Registre.getDX();
                            string value1 = Console.ReadLine();
                            await Task.Delay(TimeSpan.FromSeconds(4));
                            UAL.setUal2(value1);
                            //animation registre ual2 (AX,UAL2,donne);
                            Animation.AnimateImage(Images[24], Images[9], -1020, 8, -70, 2);
                            Animation.AnimateImage(Images[25], Images[10], -1020, 8, -70, 2);
                            Animation.AnimateImage(Images[26], Images[11], -1020, 8, -70, 2);
                            await Task.Delay(TimeSpan.FromSeconds(6));
                            UAL.setUal1(Registre.getAx());
                            //animation Indicateurs
                            // UAL.positionnerIndicateurs("IN", value1);
                            //animation UAL registre
                            Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 2);
                            Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 2);
                            Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 2);
                            Registre.setAx(value1);
                            JeuxInstruction.SetInt(value1);
                            break;
                        default:
                            System.Console.WriteLine("no such mnemonique");
                            break;
                    }
                    break;
                case "mem16,DX":
                    switch (mnemonique)
                    {
                        case "INSW":
                            //animation registre(dx)
                            //afficher fenetre (contient numero periph ex : clavier) Registre.getDX();
                            string value = Console.ReadLine();
                            string adresse = UAL.calculAdresse(mem, ifdepl, valdepl);
                            Co.setco(adresse);
                            //Co to Ram
                            Animation.AnimateImage1(Images[12], 300, 190, 1);
                            Animation.AnimateImage1(Images[13], 300, 190, 1);
                            Animation.AnimateImage1(Images[14], 300, 190, 1);
                            await Task.Delay(TimeSpan.FromSeconds(2));
                            MC.setRam(adresse);
                            MC.setRim(value);
                            //MC.recherche_mc(adresse).setContenu(value);
                            //UAL.positionnerIndicateurs("IN", value);
                            //animation UAL registre
                            Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
                            Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
                            Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);
                            JeuxInstruction.SetInt(value);
                            break;
                        default:
                            System.Console.WriteLine("no such mnemonique");
                            break;
                    }
                    break;

                case "DX,Mem16":
                    format_dx_mem16(mnemonique, ccm, mem, ifdepl, valdepl, val1, val2, val3, Images);
                    break;

                case "Reg16/Mem16,CX":
                    if (mem_b)
                    {
                        if (ifdepl)
                        {
                            switch (mem)
                            { //khdmt b source mais f hed le cas c'est destinataire -- nom a revoir
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
                                    Registre.setContenuRegistre("BX", val1);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BX+DI]":
                                    Registre.setContenuRegistre("BX", val1);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[BP+SI]":
                                    Registre.setContenuRegistre("BP", val1);
                                    Registre.setContenuRegistre("SI", val2);
                                    break;
                                case "[BP+DI]":
                                    Registre.setContenuRegistre("BP", val1);
                                    Registre.setContenuRegistre("DI", val2);
                                    break;
                                case "[SI]":
                                    Registre.setContenuRegistre("SI", val1);
                                    break;
                                case "[DI]":
                                    Registre.setContenuRegistre("DI", val1);
                                    break;
                                case "[BP]":
                                    Registre.setContenuRegistre("BP", val1);
                                    break;
                                case "[BX]":
                                    Registre.setContenuRegistre("BX", val1);
                                    break;
                                default:
                                    System.Console.WriteLine("Error ! no such mem_depl");
                                    break;
                            }
                        }
                        //hover (nombreregistre,reg1,reg2);
                        //animation (Registres,RAM,adresse)// ual ram 
                        if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                        Animation.AnimateImage3(Images[79], Images[81], Images[84], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[78], Images[82], Images[85], -1165, -30, -550, -365, 300, 1);
                        Animation.AnimateImage3(Images[80], Images[83], Images[86], -1165, -30, -550, -365, 300, 1);
                        await Task.Delay(TimeSpan.FromSeconds(4));
                        string adresse = UAL.calculAdresse(mem, ifdepl, valdepl);
                        MC.setRam(adresse);
                        //MC.setRim(MC.recherche_mc(adresse).getContenu());
                        // animation(RIM,UAL1,DONNE); 
                        Animation.AnimateImage(Images[30], Images[6], -910, 10, -70, 1);
                        Animation.AnimateImage(Images[31], Images[7], -910, 8, -70, 1);
                        Animation.AnimateImage(Images[32], Images[8], -910, 6, -70, 1);
                        UAL.setUal1(MC.getRim());
                        //on met le contenu de cx dans ual2
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        // animation(registre, UAL2 ,DONNE); 
                        Animation.AnimateImage(Images[21], Images[9], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[22], Images[10], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[23], Images[11], -1020, 8, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        UAL.setUal2(Registre.getCx());
                        switch (mnemonique)
                        {
                            case "SHL":
                                //ushort pour 16-bit representation

                                ushort destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                ushort count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                           // Shift the destination left by the count value
                                string str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                string str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);

                                // UAL.positionnerIndicateurs("SHL", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((destination & 0x8000) != 0);
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
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                    // Shift the destination left by the count value
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination >> count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SHR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x0001) != 0);
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
                                //animation(CO,ram,adresse)
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                    // Check the value of the MSB before the shift
                                bool signBit = (destination & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                destination = (ushort)(destination << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (destination & 0x8000) != 0;
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);

                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                //animation(CO,ram,adresse)
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "SAR":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                    // Check the value of the MSB before the shift
                                signBit = (destination & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                destination = (ushort)(destination >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                //UAL.positionnerIndicateurs("SAR", str_res, operand2: str_op2);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                //animation(CO,ram,adresse)
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "ROR":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (destination << (16 - count)));
                                bool carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                string str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());

                                break;
                            case "ROL":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination << count) | (destination >> (16 - count)));
                                carryFlag = (destination & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                //animation(Registre,co,adresse)
                                Co.setco(adresse);
                                //animation(CO,ram,adresse)
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());

                                break;
                            case "RCL":
                                destination = ushort.Parse(ccm, NumberStyles.HexNumber);
                                count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (destination & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    destination = (ushort)((destination << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // UAL.positionnerIndicateurs("RCL", str_res, operand2: str_op2, operand1: str_op1);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (destination & 0x8000) != 0;
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
                                //animation(CO,ram,adresse)
                                MC.setRam(adresse);
                                //animation (UAL,rim,donnee)
                                MC.setRim(destination.ToString("X"));
                                MC.recherche_mc(adresse).setContenu(MC.getRim());
                                break;
                            default:
                                System.Console.WriteLine("error ! no such mnemonique");
                                break;
                        }
                        if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                        UAL.positionnerIndicateurs(mnemonique, JeuxInstruction.GetInt(), val2, ccm);
                        Animation.AnimateImage2(Images[43], Images[37], -1165, -30, -170, -100, 1);
                        Animation.AnimateImage2(Images[42], Images[36], -1165, -30, -170, -100, 1);
                        Animation.AnimateImage2(Images[44], Images[38], -1165, -30, -170, -100, 1);
                    }
                    //-------------------------------------------------------------------------------
                    else
                    {//reg,cx
                     //animation registre to ual1
                        if (Animation.btnclick == true) { Phase2(mnemonique, format, mem_b); await Task.Delay(20000); }
                        Animation.AnimateImage(Images[21], Images[6], -900, 8, -70, 1);
                        Animation.AnimateImage(Images[22], Images[7], -900, 8, -70, 1);
                        Animation.AnimateImage(Images[23], Images[8], -900, 8, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        Registre.setContenuRegistre(source, val3);//val3 valeur te3 registre // une autre fois je travaille avec source alors que c'est destinataire -- juste notation
                        UAL.setUal1(Registre.getContenuRegistre(source));
                        //on met cx dans ual2
                        //animation (reg,ual2,donne); 
                        Animation.AnimateImage(Images[24], Images[9], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[25], Images[10], -1020, 8, -70, 1);
                        Animation.AnimateImage(Images[26], Images[11], -1020, 8, -70, 1);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        UAL.setUal2(Registre.getCx());
                        switch (mnemonique)
                        {
                            case "SHL":
                                //ushort pour 16-bit representation
                                ushort destination = ushort.Parse(val1, NumberStyles.HexNumber);
                                ushort count = ushort.Parse(val2, NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                           // Shift the destination left by the count value
                                string str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                string str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                bool newCarryFlag = ((destination & 0x8000) != 0);
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "SHR":
                                //ushort pour 16-bit representation
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by
                                                                                             // Shift the destination left by the count value
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination >> count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x0001) != 0);
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "SAL": // same brk on conserve le bit de signe -- nombre signe
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                bool signBit = (destination & 0x8000) != 0;
                                // Shift the value left by the count value, preserving the sign bit
                                destination = (ushort)(destination << count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= 0x8000;
                                }
                                // Check the value of the MSB after the shift
                                bool newSignBit = (destination & 0x8000) != 0;
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "SAR":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by
                                                                                             // Check the value of the MSB before the shift
                                signBit = (destination & 0x8000) != 0;
                                // Shift the value right by the count value, preserving the sign bit
                                destination = (ushort)(destination >> count);
                                if (signBit)
                                {
                                    // The MSB was set before the shift, so set it again
                                    destination |= (ushort)(0xFFFF << (16 - count));
                                }
                                // Check the value of the MSB after the shift
                                str_op2 = destination.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the MSB to determine the new value of the CF flag
                                newCarryFlag = ((destination & 0x8000) != 0);
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "ROR":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (destination << (16 - count)));
                                bool carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                string str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));

                                break;
                            case "ROL":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination << count) | (destination >> (16 - count)));
                                carryFlag = (destination & 0x8000) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            case "RCR"://the user must set the value of CF indicateur !!! -- a signaler 
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                destination = (ushort)((destination >> count) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? (0xFFFF << (16 - count)) : 0));
                                carryFlag = (destination & 0x0001) != 0;
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));

                                break;
                            case "RCL":
                                destination = ushort.Parse(UAL.getUal1(), NumberStyles.HexNumber);
                                count = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber); // number of bits to shift the operand by // number of bits to shift the value by

                                // Perform the rotation
                                while (count > 0)
                                {
                                    // Get the value of the most significant bit before the rotation
                                    bool msb = (destination & 0x8000) != 0;

                                    // Shift the value left by one bit and OR it with the carry flag
                                    destination = (ushort)((destination << 1) | (Convert.ToBoolean(Indicateur.getretenuAuxiliaire()) ? 1 : 0));

                                    // Update the carry flag with the original value of the most significant bit
                                    carryFlag = msb;

                                    count--;
                                }
                                //---------------------------------------------
                                str_op2 = destination.ToString("X");
                                str_op1 = count.ToString("X");
                                destination = (ushort)(destination << count);
                                str_res = destination.ToString("X4");
                                JeuxInstruction.SetInt(str_res);
                                // Check the new value of the LSB to determine the new value of the CF flag
                                carryFlag = (destination & 0x8000) != 0;
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
                                Registre.setContenuRegistre(source, destination.ToString("X"));
                                break;
                            default:
                                System.Console.WriteLine("error ! no such mnemonique");
                                break;
                        }
                        if (Animation.btnclick == true) { Phase3(mnemonique, format, mem_b); await Task.Delay(20000); }
                        UAL.positionnerIndicateurs("ROR", JeuxInstruction.GetInt(), val3, Registre.getCx());
                        Animation.AnimateImage2(Images[18], Images[15], -1165, -30, -1210, -465, 1);
                        Animation.AnimateImage2(Images[19], Images[16], -1165, -30, -1210, -465, 1);
                        Animation.AnimateImage2(Images[20], Images[17], -1165, -30, -1210, -465, 1);
                    }
                    break;
                default:

                    break;
            }

        }


        //------------------------------------------------------------------------------------------




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
                    my_second_part = "," + instruction.getval_imm16();//here
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

        public string inst_to_hexaforme(Instruction inst)
        {
            string hexaforme;

            switch (inst.getFormat())
            {
                case "AX,imm16":
                    hexaforme = remplir_AX_imm16(inst.getMnemonique(),inst.getval_imm16());
                    break;
                case "Reg16/Mem16,imm16":
                    hexaforme = remplir_Reg_mem_imm16(inst.getMnemonique(), inst.getDestination(), inst.getifdepl(), inst.getValDepl(),inst.getval_imm16());
                    break;
                case "Reg16/Mem16,Reg16":
                    hexaforme = remplir_reg_mem_reg(inst.getMnemonique(), inst.getDestination(), inst.getSource(), inst.getifdepl(),inst.getValDepl());
                    break;
                case "Reg16,Reg16/Mem16":
                    hexaforme = remplir_reg_reg_mem(inst.getMnemonique(), inst.getSource(), inst.getDestination(), inst.getifdepl(), inst.getValDepl());
                    break;
                case "Reg16":
                    hexaforme = remplir_reg16(inst.getMnemonique(), inst.getDestination());
                    break;
                case "Reg16/Mem16":
                    hexaforme = remplir_reg16_mem16(inst.getMnemonique(), inst.getDestination(), inst.getifdepl(), inst.getValDepl());
                    break;
                case "Reg16,imm16":
                    hexaforme = remplir_Reg16_imm16(inst.getMnemonique(), inst.getDestination(), inst.getValDepl());
                    break;
                case "AX,Reg16":
                    hexaforme = remplir_AX_Reg16(inst.getMnemonique(), inst.getDestination());
                    break;
                case "Reg16/Mem16,CX":
                    hexaforme = remplir_reg_mem_cx(inst.getMnemonique(), inst.getDestination(), inst.getifdepl(), inst.getValDepl());
                    break;
                case "AX,DX":
                    hexaforme = remplir_AX_DX();
                    break;
                case "DX,AX":
                    hexaforme = remplir_DX_AX();
                    break;
                case "Mem16,DX":
                    hexaforme = remplir_mem16_DX();
                    break;
                case "DX,Mem16":
                    hexaforme = remplir_mem16_DX();
                    break;
                case "Mem16":
                    hexaforme = remplir_mem16(inst.getMnemonique(), inst.getDestination(), inst.getifdepl(), inst.getValDepl());
                    break;
                default:
                    hexaforme = "";
                    break;
            }
            return hexaforme;
           
        }
        //---------------------------------------------------------------------------------------------------------
        public static bool IsValidBinary(string binaryString)
        {
            foreach (char c in binaryString)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }

            return true;
        }
        public static string BinaryStringToHexString(string binaryString)
        {
            if (string.IsNullOrEmpty(binaryString))
            {
                return "fargh";
            }
            if (!IsValidBinary(binaryString))
            {
                return "not binaire";
            }

            // Pad the binary string with zeroes to ensure its length is a multiple of 4
            string paddedBinaryString = binaryString.PadLeft((binaryString.Length + 3) / 4 * 4, '0');

            // Convert the padded binary string to a byte array
            byte[] binaryBytes = new byte[paddedBinaryString.Length / 8];
            for (int i = 0; i < paddedBinaryString.Length; i += 8)
            {
                binaryBytes[i / 8] = Convert.ToByte(paddedBinaryString.Substring(i, 8), 2);
            }

            // Convert the byte array to a hexadecimal string
            string hexString = BitConverter.ToString(binaryBytes).Replace("-", "");

            return hexString;
        }

    }
}