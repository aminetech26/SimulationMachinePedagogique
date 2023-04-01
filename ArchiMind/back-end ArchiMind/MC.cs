using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiMind
{
    internal class MC
    {
       private static string ram  ;
       private static string  rim   ; 
       private static ArrayList mc = new ArrayList() ; 
       public static void setRam(String ram) {
         MC.ram = ram ; 
       }
       public static string getRam(){
        return MC.ram; 
       }
        public static void setRim(String rim) {
         MC.rim = rim ; 
       }
       public static string getRim(){
        return MC.rim; 
       }  
       public static addCase(Case cas){
          MC.mc.Add(Convert.ToInt32(cas.getAdr, 16),cas);
       } 
       public static Case  getCase(string adr ){
         return MC.mc[Convert.ToInt32(adr,16)]; 
       }

       

       
    }
}
