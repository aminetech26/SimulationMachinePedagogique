using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArchiMind
{
    internal class Registre
    {
        private static string ax, bx, cx, dx, si, di, sp, bp;
        public static void setAx(string ax)
        {
            Registre.ax = ax;   
        }
             // implementation des getter et setter //
        public static string getAx()
        {
            return Registre.ax;
        }
        public static void setBx(string bx)
        {
            Registre.bx = bx;
        } 
        public static string getBx() { 
            return Registre.bx;
        }
        public static void setCx(string cx)
        {
            Registre.cx = cx;
        }
        public static string getCx()
        {
            return Registre.cx;
        }
        public static void setDx(string dx)
        {
            Registre.dx = dx;
        } 
        public static string getDx()
        {
            return Registre.dx; 
        } 
        public static  void setSi(string si)
        {
            Registre.si = si;
        }
        public static string getSi()
        {
            return Registre.si;
        }
        public static void setDi(string di) 
        {
            Registre.di = di;
        }
        public static string getDi()
        {
            return Registre.di;
        }
        public static void  setSp(string sp)
        {
            Registre.sp = sp;
        }
        public static string getSp()
        {
            return Registre.sp;
        }
        public static  void setBp(string bp)
        {
            Registre.bp = bp;
        }
        public static string getBp()
        {
            return Registre.bp;
        }   

        // fin de l'implementation des getter et setter 

        public static void regToRim()
        {
            //  on peut pas l'implementer jusqu'a faire la class MC
        } 
        public static void regToUal1()
        {
            // on peut pas l'implementer jusqu'a faire la class UAL 
        }
        public static void regToUal2()
        {
            // on peut pas l'implementer jusqu'a faire la class UAL
        }


       //------------------ les methodes setContenuRegistre / getContenuRegistre --------------------------//
       public static void setContenuRegistre(string reg,string val){
            switch (reg)
            {
                case "AX":
                setAx(val);
                break;
                case "BX":
                setBx(val);
                break;
                case "CX":
                setCx(val);
                break;
                case "DX":
                setDx(val);
                break;
                case "SI":
                setSi(val);
                break;
                case "DI":
                setDi(val);
                break;
                case "SP":
                setSp(val);
                break;
                case "BP":
                setBp(val);
                break;
                default:
                Console.WriteLine("error");
                break;
            }
       }

       public static string getContenuRegistre(string reg){
            string valreg="";
            switch (reg)
            {
                case "AX":
                valreg=getAx();
                break;
                case "BX":
                valreg = getBx();
                break;
                case "CX":
                valreg = getCx();
                break;
                case "DX":
                valreg= getDx();
                break;
                case "SI":
                valreg= getSi();
                break;
                case "DI":
                valreg=getDi();
                break;
                case "SP":
                valreg=getSp();
                break;
                case "BP":
                valreg=getBp();
                break;
                default:
                Console.WriteLine("error");
                break;
            } 
         return valreg;
       }
         
       //----------------------------------------------------------------------------------------------------

    }
     
        
      
}