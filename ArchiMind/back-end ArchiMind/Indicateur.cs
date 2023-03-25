using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiMind
{
    internal class Indicateur
    {          private static char zero;  //
               private static char signe;  // 
               private static char overflow;
               private static char retenu;
               private static char demi_retenue;
               private static char parité; //
               private static char trace;
               private static char auto_incr_dec;
        
        // Getter et Setter
             public static char getZero()
                    {
                        return zero;
                    }
             public static char getSigne()
                    {
                        return signe;
                    }
             public static char getOverflow()
                    {
                        return overflow;
                    }
             public static char getRetenu()
                    {
                        return retenu;
                    }
             public static char getDemiRetenue()
                    {
                        return demi_retenue;
                    }
             public static char getParite()
                    {
                        return parité;
                    }
             public static char getTrace()
                    {
                        return trace;
                    }
             public static char getAutoIncrDec()
                    {
                        return auto_incr_dec;
                    }
             public static void setZero(char zero)
                    {
                        Indicateur.zero = zero;
                    }
             public static void setSigne(char signe)
                    {
                        Indicateur.signe = signe;
                    }
             public static void setOverflow(char overflow)
                    {
                        Indicateur.overflow = overflow;
                    }
             public static void setRetenu(char retenu)
                    {
                        Indicateur.retenu = retenu;
                    }
             public static void setDemiRetenue(char demi_retenue)
                    {
                        Indicateur.demi_retenue = demi_retenue;
                    }
             public static void setParite(char parite)
                    {
                        Indicateur.parité = parite;
                    }
             public static void setTrace(char trace)
                    {
                        Indicateur.trace = trace;
                    }
             public static void setAutoIncrDec(char auto_incr_dec)
                    {
                        Indicateur.auto_incr_dec = auto_incr_dec;
                    }
          //    
          public static void Zero()
        {
            if (Convert.ToInt32(Registre.getAx(),16) == 0 )
            {
                setZero('1');
            } else
            {
                setZero('0');
            }
        }
          public static void Signe()
        {
            int decimalValue = Convert.ToInt32(Registre.getAx(), 16); 
            string binaryValue = Convert.ToString(decimalValue,2);
            binaryValue = Erreur.correctionFormat(binaryValue); 
            if (binaryValue[0] == '1')
            {
                setSigne('1');
            }else
            {
                setSigne('0');
            }
        }  
        // TODO: cette methode est incomplete
         public static void Parité()
        {
            // la parité c'est le nombre de 1 
            string value = "    " ; 
            int  nb_parité = value.Count(c => c == '1');
            if (nb_parité % 2 == 0 )
            {
               Indicateur.setParite('1');
            } else
            {
               Indicateur.setParite('0');
            }
        }
    }
}