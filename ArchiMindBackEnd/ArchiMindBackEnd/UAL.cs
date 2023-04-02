using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiMind
{
    internal class UAL
    { 
     private  static string ual1; 
     private static string ual2 ; 
     private static string result ; 

      public static void setUal1(String ual1){
        UAL.ual1 = ual1 ; 
      }
      public static string getUal1(){
        return UAL.ual1 ; 
        }
        public static void setUal2(String ual2){
        UAL.ual2 = ual2 ; 
      }
      public static string getUal2(){
        return UAL.ual2 ; 
        }
        public static string  calculAdresse(String mem , bool ifdepl , string valdepl ){
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
        static int CountOccurrences(string str, char c) // for parity check
        {
        int count = 0;

        foreach (char ch in str)
        {
        if (ch == c)
        {
            count++;
        }
        }

        return count;
        }

        public static void positionnerIndicateurs(string mnemoniques,string result,string operand1 = "default",string operand2="default"){
            int nb_bits = 16;
            switch (mnemoniques) {
            case "ADD":
        //carry/overflow check
        if ((int.Parse(result) & (1 << nb_bits)) != 0) { // keyen carry + debordement
        Indicateur.setRetenu('1');
        Indicateur.setOverflow('1');
        } else { // mekench
        Indicateur.setRetenu('0');
        Indicateur.setOverflow('0');
        }
        //parity check
        if (CountOccurrences(result,'1')%2==0){
            Indicateur.setParite('1');
        }else{
            Indicateur.setParite('0');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        if ((((int.Parse(operand1) & 0x0F) + (1 & 0x0F)) & 0x10) != 0){
            Indicateur.setretenuAuxiliaire('1');
        }else{
            Indicateur.setretenuAuxiliaire('0');
        }
        //setting other flags .. non positionne pat l'operation as undefined // x
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    case "SUB":
        //carry/overflow check
        if ((int.Parse(result) & (1 << nb_bits)) != 0) { // keyen carry + debordement
        Indicateur.setRetenu('1');
        Indicateur.setOverflow('1');
        } else { // mekench
        Indicateur.setRetenu('0');
        Indicateur.setOverflow('0');
        }
        //parity check
        if (CountOccurrences(result,'1')%2==0){
            Indicateur.setParite('1');
        }else{
            Indicateur.setParite('0');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        if ((((int.Parse(operand1) & 0x0F) + (1 & 0x0F)) & 0x10) != 0){
            Indicateur.setretenuAuxiliaire('1');
        }else{
            Indicateur.setretenuAuxiliaire('0');
        }
        //setting other flags .. non positionne pat l'operation a zero
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    case "INC":
        //overflow check
        if ((int.Parse(result) & (1 << nb_bits)) != 0) { // keyen debordement
        Indicateur.setOverflow('1');
        } else { // mekench
        Indicateur.setOverflow('0');
        }
        //parity check
        if (CountOccurrences(result,'1')%2==0){
            Indicateur.setParite('1');
        }else{
            Indicateur.setParite('0');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        //retenuAuxiliaire check
        if ((((int.Parse(operand1) & 0x0F) + (1 & 0x0F)) & 0x10) != 0){
            Indicateur.setretenuAuxiliaire('1');
        }else{
            Indicateur.setretenuAuxiliaire('0');
        }
        //setting other flags .. non positionne pat l'operation a zero
        Indicateur.setRetenu('x');
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    case "DEC":
        //overflow check
        if ((int.Parse(result) & (1 << nb_bits)) != 0) { // keyen debordement
        Indicateur.setOverflow('1');
        } else { // mekench
        Indicateur.setOverflow('0');
        }
        //parity check
        if (CountOccurrences(result,'1')%2==0){
            Indicateur.setParite('1');
        }else{
            Indicateur.setParite('0');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        //retenuAuxiliaire check
        if ((((int.Parse(operand1) & 0x0F) + (-1 & 0x0F)) & 0x10) != 0){
            Indicateur.setretenuAuxiliaire('1');
        }else{
            Indicateur.setretenuAuxiliaire('0');
        }
        //setting other flags .. non positionne pat l'operation a zero
        Indicateur.setRetenu('x');
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    case "MUL":
        // carry / overflow check
        if (result[0] == '0'){
            Indicateur.setRetenu('0');
            Indicateur.setOverflow('0');
        }else{
           Indicateur.setRetenu('1');
            Indicateur.setOverflow('1'); 
        }
        //undefined after mul instruction
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        break;
    case "MOV":
        //MOV does not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "XCHG":
        //XCHG does not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "NOT":
        //NOT does not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "AND":
        Indicateur.setRetenu('0');
        Indicateur.setOverflow('0');
        Indicateur.setretenuAuxiliaire('x');
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        Indicateur.setParite('x'); // has meaning only for 8-bit operand tsema nkhliwh undefined khir
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    case "OR":
        //like and operation
        Indicateur.setRetenu('0');
        Indicateur.setOverflow('0');
        Indicateur.setretenuAuxiliaire('x');
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        Indicateur.setParite('x'); // has meaning only for 8-bit operand tsema nkhliwh undefined khir
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    case "XOR":
        // same as -and- and or
        Indicateur.setRetenu('0');
        Indicateur.setOverflow('0');
        Indicateur.setretenuAuxiliaire('x');
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        Indicateur.setParite('x'); // has meaning only for 8-bit operand tsema nkhliwh undefined khir
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    case "SHL"://needs operand 1 and 2
        //Indicateur.setRetenu('Most recently shifted bit from MSB'); // depend de l'instruction -- traitement special
        //Overflow check 
        if (operand2[0] == '1'){
        if (Indicateur.getRetenu() != result[0]){
            Indicateur.setOverflow('1');
        }else{
            Indicateur.setOverflow('0');    
        }}else{
            Indicateur.setOverflow('x');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        Indicateur.setParite('x'); // has meaning only for 8-bit operand tsema nkhliwh undefined khir [a revoir]
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        break;
    case "SHR":
        //needs operand 1 and 2
        //Indicateur.setRetenu('Most recently shifted bit from LSB'); // depend de l'instruction -- traitement special
        //Overflow check 
        if (operand2[0] == '1'){
        if ((result[0]!='0')|(result[1]!='0')){
            Indicateur.setOverflow('1');
        }else{
            Indicateur.setOverflow('0');    
        }}else{
            Indicateur.setOverflow('x');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        Indicateur.setParite('x'); // has meaning only for 8-bit operand tsema nkhliwh undefined khir [a revoir]
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        break;
    case "SAL":
        //same as SHL
        //needs operand 1 and 2
        //Indicateur.setRetenu('Most recently shifted bit from MSB'); // depend de l'instruction -- traitement special
        //Overflow check 
        if (operand2[0] == '1'){
        if (Indicateur.getRetenu() != result[0]){
            Indicateur.setOverflow('1');
        }else{
            Indicateur.setOverflow('0');    
        }}else{
            Indicateur.setOverflow('x');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        Indicateur.setParite('x'); // has meaning only for 8-bit operand tsema nkhliwh undefined khir [a revoir]
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        break;
    case "SAR":
                //needs operand 1 and 2
        //Indicateur.setRetenu('Most recently shifted bit from LSB'); // depend de l'instruction -- traitement special
        //Overflow check 
        if (operand2[0] == '1'){
        if (result[0]!=result[1]){
            Indicateur.setOverflow('1');
        }else{
            Indicateur.setOverflow('0');    
        }}else{
            Indicateur.setOverflow('0');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        Indicateur.setParite('x'); // has meaning only for 8-bit operand tsema nkhliwh undefined khir [a revoir]
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        break;
    case "ROR":
        //affects only cf and of
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu(result[0]);
        Indicateur.setOverflow('x');
        if (operand2[0] == '1'){
        if(operand1[0] != result[0]){
          Indicateur.setOverflow('1');  
        }else{
          Indicateur.setOverflow('0');
        }}
        break;
    case "ROL":
        //affects only cf and of
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu(result[0]);
        Indicateur.setOverflow('x');
        if (operand2[0] == '1'){
        if(operand1[0] != result[0]){
          Indicateur.setOverflow('1');  
        }else{
          Indicateur.setOverflow('0');
        }}
        break;
    case "RCR":
        //affects only cf and of
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu(result[15]);
        Indicateur.setOverflow('x');
        if (operand2[0] == '1'){
        if(operand1[0] != result[0]){
          Indicateur.setOverflow('1');  
        }else{
          Indicateur.setOverflow('0');
        }}
        break;
    case "RCL":
        //affects only cf and of
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu(result[15]);
        Indicateur.setOverflow('x');
        if (operand2[0] == '1'){
        if(operand1[0] != result[0]){
          Indicateur.setOverflow('1');  
        }else{
          Indicateur.setOverflow('0');
        }}
        break;
    case "IN":
        //does not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "OUT":
        // does not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "INSW":
        // doest not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "OUTSW":
        // does not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "JMP":
        // does not affect any flag
        Indicateur.setAutoIncrDec('x');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "LOOP":
        Indicateur.setAutoIncrDec('1');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "LOOPZ":
        Indicateur.setAutoIncrDec('1');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "LOOPE":
        Indicateur.setAutoIncrDec('1');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "LOOPNZ":
        Indicateur.setAutoIncrDec('1');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "LOOPNE":
        Indicateur.setAutoIncrDec('1');
        Indicateur.setretenuAuxiliaire('x');
        Indicateur.setTrace('x');
        Indicateur.setZero('x');
        Indicateur.setSigne('x');
        Indicateur.setParite('x');
        Indicateur.setRetenu('x');
        Indicateur.setOverflow('x');
        break;
    case "CMP":
        //carry/overflow check
        if ((int.Parse(result) & (1 << nb_bits)) != 0) { // keyen carry + debordement
        Indicateur.setRetenu('1');
        Indicateur.setOverflow('1');
        } else { // mekench
        Indicateur.setRetenu('0');
        Indicateur.setOverflow('0');
        }
        //parity check
        if (CountOccurrences(result,'1')%2==0){
            Indicateur.setParite('1');
        }else{
            Indicateur.setParite('0');
        }
        //sign check
        if (result[0]=='1'){
            Indicateur.setSigne('1');
        }else{
            Indicateur.setSigne('0');
        }
        //zero check
        if(int.Parse(result) == 0){
            Indicateur.setZero('1');
        }else{
            Indicateur.setZero('0');
        }
        if ((((int.Parse(operand1) & 0x0F) + (1 & 0x0F)) & 0x10) != 0){
            Indicateur.setretenuAuxiliaire('1');
        }else{
            Indicateur.setretenuAuxiliaire('0');
        }
        //setting other flags .. non positionne pat l'operation as undefined // x
        Indicateur.setTrace('x');
        Indicateur.setAutoIncrDec('x');
        break;
    default:
        Console.Beep();
        Console.WriteLine("Error in instruction !");
        break;
}

        }
    }
    
}