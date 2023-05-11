using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiMind
{
    internal class Co
    {
        private static string co;
      static  public String getco() { 
                return co;
        }
      static  public void setco(String co)
        {  
           // attribut static on utilise pas "this" 
           Co.co= co; 
        } 
        static  public void incCo()
        {   // Incrementation en Hexa decimal 
            // Conversion de la chaîne hexadécimale en entier
            int coHexInt = Convert.ToInt32(Co.co, 16);

            // Incrémentation de la valeur hexadécimale
            coHexInt++;

            // Conversion de la valeur hexadécimale en chaîne hexadécimale
            string hexResult = coHexInt.ToString("X4");
            
            setco(hexResult);
        }
    }
}
