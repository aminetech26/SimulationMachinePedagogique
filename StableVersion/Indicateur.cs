using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using projet;


namespace ArchiMind
{
    internal class Indicateur
    {          private static char zero;  //
               private static char signe;  // 
               private static char overflow;
               private static char retenu;
               private static char retenuAuxiliaire;
               private static char parité; //
               private static char trace;
               private static char auto_incr_dec;


            public static void setZero(char zero, Grid IND_Z)
            {
                if (zero == '1')
                {
                    IND_Z.Background = Brushes.Blue;
                }
                else
                {
                    IND_Z.Background = Brushes.White;
                }
                Indicateur.zero = zero;
            }


            public static void setSigne(char signe, Grid IND_S)
            {
                if (zero == '1')
                {
                    IND_S.Background = Brushes.Blue;
                }
                else
                {
                    IND_S.Background = Brushes.White;
                }
                Indicateur.signe = signe;
            }
            public static void setOverflow(char overflow, Grid IND_O)
            {
                if (zero == '1')
                {
                    IND_O.Background = Brushes.Blue;
                }
                else
                {
                    IND_O.Background = Brushes.White;
                }
                Indicateur.overflow = overflow;
            }
            public static void setRetenu(char retenu, Grid IND_R)
            {
                if (zero == '1')
                {
                    IND_R.Background = Brushes.Blue;
                }
                else
                {
                    IND_R.Background = Brushes.White;
                }
                Indicateur.retenu = retenu;
            }
            public static void setretenuAuxiliaire(char demi_retenue, Grid IND_RA)
            {
                if (zero == '1')
                {
                    IND_RA.Background = Brushes.Blue;
                }
                else
                {
                    IND_RA.Background = Brushes.White;
                }
                Indicateur.retenuAuxiliaire = retenuAuxiliaire;
            }
            public static void setParite(char parite, Grid IND_P)
            {
                if (zero == '1')
                {
                    IND_P.Background = Brushes.Blue;
                }
                else
                {
                    IND_P.Background = Brushes.White;
                }
                Indicateur.parité = parité;
            }
            public static void setTrace(char trace, Grid IND_T)
            {
                if (zero == '1')
                {
                    IND_T.Background = Brushes.Blue;
                }
                else
                {
                    IND_T.Background = Brushes.White;
                }
                Indicateur.trace = trace;
            }

            public static void setAutoIncrDec(char auto_incr_dec, Grid IND_AIC)
            {
                if (zero == '1')
                {
                    IND_AIC.Background = Brushes.Blue;
                }
                else
                {
                    IND_AIC.Background = Brushes.White;
                }
                Indicateur.auto_incr_dec = auto_incr_dec;
            }
        

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
             public static char getretenuAuxiliaire()
                    {
                        return retenuAuxiliaire;
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
             public static void setretenuAuxiliaire(char demi_retenue)
                    {
                        Indicateur.retenuAuxiliaire = retenuAuxiliaire;
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
            public static void afficherIndicateur(){//pour le test
                    Console.WriteLine("Carry Flag : ",Indicateur.getRetenu());
                    Console.WriteLine("Overflow Flag : ",Indicateur.getOverflow());
                    Console.WriteLine("Auxiliary Carry Flag : ",Indicateur.getretenuAuxiliaire());
                    Console.WriteLine("Parity Flag : ",Indicateur.getParite());
                    Console.WriteLine("Zero Flag : ",Indicateur.getZero());
                    Console.WriteLine("Sign Flag : ",Indicateur.getSigne());
                    Console.WriteLine("Trace Flag : ",Indicateur.getTrace());
                    Console.WriteLine("Auto inc dec Flag : ",Indicateur.getAutoIncrDec());
            }  
    }
}