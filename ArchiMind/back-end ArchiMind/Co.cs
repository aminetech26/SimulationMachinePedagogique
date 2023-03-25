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
            int DecimalValue  = Convert.ToInt32(Co.co,16);
            DecimalValue++; 
            setco(DecimalValue.ToString("X"));
        }
    }
}
