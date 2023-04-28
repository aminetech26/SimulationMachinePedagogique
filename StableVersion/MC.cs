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
       private static List<Case> mc = new List<Case>();
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
      /* public static void addCase(Case cas){
          MC.mc.Add(Convert.ToInt32(cas.getAdr, 16),cas);
       } */
       public static Case recherche_mc(string adr){
         Case case_adr = mc.Find(c => adr.Equals(c.getAdr()));
         return case_adr;
       } 
         public static void AjouterCase(int index, Case nouvelleCase)
        {
          mc.Insert(index, nouvelleCase);
        }
    }
}
