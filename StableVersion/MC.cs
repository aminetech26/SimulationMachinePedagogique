using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ArchiMind
{
    internal class MC
    {
        private static string ram;
        private static string rim;
        public static List<Case> mc = new List<Case>();
        public static void setRam(String ram)
        {
            MC.ram = ram;
        }
        public static List<Case> getMc()
        {
            return mc;
        }
        public static void setMc(List<Case> list_cases)
        {
            MC.mc = list_cases;
        }
        public static string getRam()
        {
            return MC.ram;
        }
        public static void setRim(String rim)
        {
            MC.rim = rim;
        }
        public static string getRim()
        {
            return MC.rim;
        }
        /* public static void addCase(Case cas){
            MC.mc.Add(Convert.ToInt32(cas.getAdr, 16),cas);
         } */
        public static Case recherche_mc(string adr)
        {
            Case case_adr = mc.Find(c => adr.Equals(c.getAdr()));
            return case_adr;
        }
        public static void AjouterCase(string adresse, Case nouvelleCase)
        {
            try
            {
                int index = Convert.ToInt32(adresse, 16);
                mc.Insert(index, nouvelleCase);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
