using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiMind
{
    internal class Ual
    { 
     private  static string ual1; 
     private static string ual2 ; 
     private static string result ; 

      public static void setUal1(String ual1){
        Ual.ual1 = ual1 ; 
      }
      public static string getUal2(){
        return Ual.ual1 ; 
        }
        public static void setUal2(String ual2){
        Ual.ual2 = ual2 ; 
      }
      public static string getUal2(){
        return Ual.ual2 ; 
        }
        public static string  calculeAdresse(String mem , bool ifdepl , string valdepl ){
             string result_hex ; 
             int result_decimal ; 
            if (ifdepl){
                 switch (mem){
                    case "[BX+SI+XXXX]" : 
                        result_decimal = Convert.ToInt32(Registre.getBx(),16) + Convert.ToInt32(Registre.getSi(),16) + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ; 
                    case "[BX+DI+XXXX]" :
                        result_decimal = Convert.ToInt32(Registre.getBx(),16) + Convert.ToInt32(Registre.getDi(),16) + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ; 
                    case "[BP+SI+XXXX]" :
                        result_decimal = Convert.ToInt32(Registre.getBp(),16) + Convert.ToInt32(Registre.getSi(),16) + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                    case "[BP+DI+XXXX]" :
                        result_decimal = Convert.ToInt32(Registre.getBp(),16) + Convert.ToInt32(Registre.getDi(),16) + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                    case "[SI+XXXX]"  : 
                        result_decimal = Convert.ToInt32(Registre.getSi(),16)  + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                    case "[DI+XXXX]"  :
                        result_decimal = Convert.ToInt32(Registre.getDi(),16)  + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                    case "[BP+XXXX]" :
                        result_decimal = Convert.ToInt32(Registre.getBp(),16)  + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ; 
                    case  "[BX+XXXX]" :  
                        result_decimal = Convert.ToInt32(Registre.getBx(),16)  + Convert.ToInt32(valdepl,16) ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                 }
            }else{  // "[BX+SI]","[BX+DI]","[BP+SI]"//,"[BP+DI]","[SI]","[DI]","[XXXX]","[BX]"
                switch(mem) {
                    case "[BX+SI]" : 
                        result_decimal = Convert.ToInt32(Registre.getBx(),16) + Convert.ToInt32(Registre.getSi(),16)  ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ; 
                    case "[BX+DI]" : 
                        result_decimal = Convert.ToInt32(Registre.getBx(),16) + Convert.ToInt32(Registre.getDi(),16)  ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                    case "[BP+SI]" : 
                        result_decimal = Convert.ToInt32(Registre.getBp(),16) + Convert.ToInt32(Registre.getSi(),16)  ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                    case "[BP+DI]" : 
                     result_decimal = Convert.ToInt32(Registre.getBp(),16) + Convert.ToInt32(Registre.getDi(),16)  ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;
                    case "[SI]" :
                        result_decimal =  Convert.ToInt32(Registre.getSi(),16)  ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ; 
                    case "[DI]" :
                        result_decimal =  Convert.ToInt32(Registre.getDi(),16)  ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;  
                    case  "[XXXX]" :
                    break ;
                    case  "[BX]":   
                        result_decimal =  Convert.ToInt32(Registre.getBx(),16)  ;
                        result_hex = result_decimal.ToHexString("X");  
                        break ;       
                }
            }
        }
    }
    
}