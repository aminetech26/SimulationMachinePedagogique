using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiMind
{
    internal class Ri
    {     
            private static string cop;
            private static char d;
            private static char w;
            private static string mod;
            private static string reg;
            private static string reg_m;
            private static String ri; 

            // implemntation des getter et setter 

            public static string getCop()
            {
                return cop;
            }
            public static void setCop(string cop)
            {
                Ri.cop = cop;
            }
            public static char getD()
            {
                return d;
            }
            public static void setD(char d)
            {
                Ri.d = d;
            }
            public static char getW()
            {
                return w;
            }
            public static void setW(char w)
            {
                Ri.w = w;
            }
            public static string getMod()
            {
                return mod;
            }
            public static void setMod(string mod)
            {
                Ri.mod = mod;
            }
            public static string getReg()
            {
                return reg;
            }
            public static void setReg(string reg)
            {
                Ri.reg = reg;
            }
            public static string getReg_m()
            {
                return reg_m;
            }
            public static void setReg_m(string reg_m)
            {
                Ri.reg_m = reg_m;
            }
            public static string getRi()
            {
                return ri;
            }
            public static void setRi(string ri)
            {
                Ri.ri = ri;
            }
        
        // fin de l'imlementation des getter et setter 

        public static void decodageRi(string Rim)
        {   
            // convertion de hexa decimal au binaire 
            int decimalValue =  Convert.ToInt32(Rim,16);
            string BinaireValueOfRim = Convert.ToString(decimalValue,2);
             // ToDO : implementation d'une methode testTaile pour verifier si la taille est en 16 bits 
    
             // correction des 0 a gauche 
            while( BinaireValueOfRim.Length < 16 ) {
                BinaireValueOfRim = BinaireValueOfRim.Insert(0,'0'.ToString()); 
            }
            // fin de convertion  
                Ri.setCop(BinaireValueOfRim.Substring(0,6));
                Ri.setD(BinaireValueOfRim[6]);
                Ri.setW(BinaireValueOfRim[7]); 
                Ri.setMod(BinaireValueOfRim.Substring(8,2));
                Ri.setReg(BinaireValueOfRim.Substring(10,3));
                Ri.setReg_m(BinaireValueOfRim.Substring(13));
                Ri.setRi(Rim); 

        }

        
    }
}
