using System.Collections;
using System.Globalization;
using System.Numerics;
using System.Text;
using System;
using ArchiMind;
using System.Collections.Generic;
using System.Windows.Controls;
using projet;

namespace ArchiMind
{
    internal class JeuxInstruction
    {
       static private string[] list_mem_dep={"[BX+SI+XXXX]","[BX+DI+XXXX]","[BP+SI+XXXX]","[BP+DI+XXXX]","[SI+XXXX]","[DI+XXXX]","[BP+XXXX]","[BX+XXXX]"};
       static private string[] list_mem_sansdep={"[BX+SI]","[BX+DI]","[BP+SI]","[BP+DI]","[SI]","[DI]","[XXXX]","[BX]"};
        private CoupleCopFormat mycouple = new CoupleCopFormat() ; 
        // private ArrayList  detailInstruction = new ArrayList (); 
        // i think it should be a static attribute because it will never change again ...............                                                          
        static private ArrayList  detailInstruction = new ArrayList ();

   // ------------------------hexadecimale to binary form------------------------------------------------------
        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
                { '0', "0000" },
                { '1', "0001" },
                { '2', "0010" },
                { '3', "0011" },
                { '4', "0100" },
                { '5', "0101" },
                { '6', "0110" },
                { '7', "0111" },
                { '8', "1000" },
                { '9', "1001" },
                { 'a', "1010" },
                { 'b', "1011" },
                { 'c', "1100" },
                { 'd', "1101" },
                { 'e', "1110" },
                { 'f', "1111" }
                 };

                      static public string HexStringToBinary(string hex) {
                          StringBuilder result = new StringBuilder();
                          foreach (char c in hex) {
                              // This will crash for non-hex characters. You might want to handle that differently.
                              result.Append(hexCharacterToBinary[char.ToLower(c)]);
                          }
                          return result.ToString();
                      }
  //-------------------------------------------------------------------------------------------------------------------
        public void intialize()
        {   
            // la methode qui intialise 

  //------------------- Arithmethique instructions ------------------------------------------------------------------
           
            // l'intialisation des format de l'istruction ADD // index = 0 
           Instruction instruction = new Instruction("AX,imm16", "00000101");
           mycouple.addInstruction(instruction);  
           instruction = new Instruction("Reg16/Mem16,imm16","10000001xx000xxx","000") ; 
           mycouple.addInstruction(instruction); 
           instruction = new Instruction("Reg16/Mem16,Reg16","00000001xxxxxxxx") ;   
           mycouple.addInstruction(instruction) ; 
           instruction = new Instruction("Reg16,Reg16/Mem16","00000011xxxxxxxx") ;   
           mycouple.addInstruction(instruction) ;
           detailInstruction.Add(mycouple);
            // l'intialisation des format de l'istruction SUB // index = 1
            mycouple = new CoupleCopFormat();
            instruction = new Instruction("AX,imm16","00101101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,imm16","10000001xx101xxx","101");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16/Mem16,Reg16","00101001xxxxxxxx");
            mycouple.addInstruction(instruction);
            instruction = new Instruction("Reg16,Reg16/Mem16","00101011xxxxxxxx");
            mycouple.addInstruction(instruction);
            detailInstruction.Add(mycouple);
             // l'intialisation des format de l'istruction INC // index = 2
             mycouple = new CoupleCopFormat();
             instruction=new Instruction("Reg16","1000 0xxx","0"); // we have a bit which can distung between INC and DEC (the forth bit) if 0 :INC else DEC  
             mycouple.addInstruction(instruction);
             instruction=new Instruction("Reg16/mem16","11111111xx000xxx","000"); 
             mycouple.addInstruction(instruction);
             detailInstruction.Add(mycouple);

             // l'intialisation des format de l'istruction DEC // index = 3
             mycouple = new CoupleCopFormat();
             instruction=new Instruction("Reg16","1000 1xxx","1"); // we have a bit which can distung between INC and DEC (the forth bit) if 0 :INC else DEC  
             mycouple.addInstruction(instruction);
             instruction=new Instruction("Reg16/mem16","11111111xx001xxx","001"); 
             mycouple.addInstruction(instruction);
             detailInstruction.Add(mycouple);

             // l'intialisation des format de l'istruction MUL // index = 4
             mycouple = new CoupleCopFormat();
             instruction=new Instruction("Reg16/mem16","11110111xx100xxx","100");  // the result will be saved in AX if it's in 16bit ... 
             mycouple.addInstruction(instruction);                                 // if it's in 32 bit it'll be saved in DX:AX 
             detailInstruction.Add(mycouple);
             // l'intialisation des format de l'istruction MUL // index = 5
             mycouple = new CoupleCopFormat();
             instruction=new Instruction("Reg16/mem16","11110111xx110xxx","110");  
             mycouple.addInstruction(instruction);
             detailInstruction.Add(mycouple);

        //------------------- transfere instructions ------------------------------------------------------------------
          // l'intialisation des format de l'istruction MOV // index = 6 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("Reg16,Reg16/Mem16","10001011xxxxxxxx");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16/Mem16,Reg16","10001001xxxxxxxx");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16/Mem16,imm16","10100111xx000xxx","000");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16,imm16","10101xxx");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);

        // l'intialisation des format de l'istruction XCHG // index = 7 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("AX,Reg16","10010xxx");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16/Mem16,Reg16","10000111xxxxxxxx");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16,Reg16/Mem16","10001001xxxxxxxx");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
        
      //------------------- logic instructions ---------------------------------------------------------------------------------
       
       // l'intialisation des format de l'istruction NOT // index = 8 
         mycouple =new CoupleCopFormat();
         instruction =new Instruction("Reg16/mem16","11110111xx010xxx","010");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);

        // l'intialisation des format de l'istruction AND // index = 9 
         mycouple =new CoupleCopFormat();
         instruction =new Instruction("Reg16/mem16,imm16","10000001xx100xxx","100");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16/mem16,Reg16","00100001xxxxxxxx");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16,Reg16/mem16","00100011xxxxxxxx");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);

        // l'intialisation des format de l'istruction OR // index = 10 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("AX,imm16","00001101");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16,mem16,imm16","10000001xx001xxx","001");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16/mem16,Reg16","00001001xxxxxxxx");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16,Reg16/mem16","00001011xxxxxxxx");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);

        // l'intialisation des format de l'istruction XOR // index = 11 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("AX,imm16","00110101");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16,mem16,imm16","10000001xx110xxx","110");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16/mem16,Reg16","00110001xxxxxxxx");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16,Reg16/mem16","00110011xxxxxxxx");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);

        // l'intialisation des instructions de decalages 
        //instruction SHL 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("Reg16/mem16,imm8","11000001xx100xxx","100");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16/mem16,CX","11010011xx100xxx","100");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction SHR 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("Reg16/mem16,imm8","11000001xx101xxx","101");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16/mem16,CX","11010011xx101xxx","101");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction SAL  -- meme cop que SHL 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("Reg16/mem16,imm8","11000001xx100xxx","100");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16/mem16,CX","11010001xx100xxx","100");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction SAR 
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("Reg16/mem16,imm8","11000001xx111xxx","111");
         mycouple.addInstruction(instruction);
         instruction = new Instruction("Reg16/mem16,CX","11010011xx111xxx","111");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction ROR 
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("Reg16/mem16,imm8","11000001xx001xxx","001");
         mycouple.addInstruction(instruction);
         instruction = new Instruction("Reg16/mem16,CX","11010011xx001xxx","001");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction ROL 
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("Reg16/mem16,imm8","11000001xx000xxx","000");
         mycouple.addInstruction(instruction);
         instruction = new Instruction("Reg16/mem16,CX","11010011xx000xxx","000");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction RCR 
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("Reg16/mem16,imm8","11000001xx011xxx","011");
         mycouple.addInstruction(instruction);
         instruction = new Instruction("Reg16/mem16,CX","11010011xx011xxx","011");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction RCL 
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("Reg16/mem16,imm8","11000001xx010xxx","010");
         mycouple.addInstruction(instruction);
         instruction = new Instruction("Reg16/mem16,CX","11010011xx010xxx","010");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);

         // instructions d'entree-sorties
         //instruction in
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("AX,DX","11101101");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction out
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("DX,AX","11101111");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction insw
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("mem16,DX","01101101");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         //instruction outsw
         mycouple = new CoupleCopFormat();
         instruction = new Instruction("DX,mem16","01101111");
         mycouple.addInstruction(instruction);
         detailInstruction.Add(mycouple);
         // Initialisation des instructions de branchement 
         // instruction jmp 
         mycouple = new CoupleCopFormat(); 
         instruction = new Instruction ("mem16","1111111100101xxx");      // nouvelle format
         mycouple.addInstruction(instruction); 
         detailInstruction.Add(mycouple); 
         // instruction LOOP 
         mycouple = new CoupleCopFormat(); 
         instruction = new Instruction("mem16","111000100xxxxxxx"); 
         mycouple.addInstruction(instruction); 
         detailInstruction.Add(mycouple); 
         // instruction LOOPZ
         mycouple = new CoupleCopFormat(); 
         instruction = new Instruction("mem16","111000010xxxxxxx");
         mycouple.addInstruction(instruction); 
         detailInstruction.Add(mycouple); 
         // instruction LOOPE
         mycouple = new CoupleCopFormat(); 
         instruction = new Instruction("mem16","111000011xxxxxxx");
         mycouple.addInstruction(instruction); 
         detailInstruction.Add(mycouple);
         // instruction LOOPNZ
         mycouple = new CoupleCopFormat(); 
         instruction = new Instruction("mem16","111000000xxxxxxx"); 
         mycouple.addInstruction(instruction); 
         detailInstruction.Add(mycouple); 
         // instruction LOOPNE 
         mycouple = new CoupleCopFormat(); 
         instruction = new Instruction("mem16","111000001xxxxxxx");
         mycouple.addInstruction(instruction);  
         detailInstruction.Add(mycouple);   
         // instruction CMP 
         mycouple = new CoupleCopFormat(); 
         instruction = new Instruction("Reg16/mem16,imm16","10000011xx111xxx"); 
         mycouple.addInstruction(instruction); 
         instruction = new Instruction("Reg16/mem16,Reg16","00111001xxxxxxxx"); 
         mycouple.addInstruction(instruction); 
         instruction = new Instruction("Reg16,Reg16/mem16","00111011xxxxxxxx");
         mycouple.addInstruction(instruction);  
         

        //--------------------------------------------------------------------------------------------------- 
          
        //--------------------------------------------------------------------------------------------------- 
        } 
       public CoupleCopFormat getMycouple(){
             return mycouple; 
        }    
        // les methodes de remplissage de code operation

       /* private int recherche_index_mnemonique(Mnemoniques inst){ 
            return (int) inst; 
        }*/
        private int recherche_index_mnemonique(string mnemonique){ 
             Mnemoniques mymnemonique=(Mnemoniques)Enum.Parse(typeof(Mnemoniques),mnemonique);   /// FORMAT COP CHAMPNOTUSED   reg/mem,imm  
            return (int) mymnemonique; 
        }  
         // instruction = format + cop 
        public Instruction recherche_instruction(CoupleCopFormat mycouple,string format){
               Instruction inst=new Instruction();
              foreach(Instruction instruction in mycouple.getListInstruction()){
                if(format.Equals(instruction.getFormat())){
                  inst = instruction;
                  break;
                }
              }
            return inst;
        }
         public string recherche_mem_depl(string reg_mem){ //[BX+SI+2345]  = [BX+SI+XXXX]   REPLACE("2345","XXXX");  000 111
             int valendecimale = 0;
             string binaire_val;
             foreach(string r_m in list_mem_dep){
              if(reg_mem.Equals(r_m)){
                 valendecimale= Array.IndexOf(list_mem_dep,r_m);
                 break;   
              }
             }  
             // l'idial est d'utiliser la methode correctionformat dans la class erreur  
             if(valendecimale > 3){
              binaire_val=Convert.ToString(valendecimale,2);
             }else if(valendecimale>1){
              binaire_val="0"+Convert.ToString(valendecimale,2);
             }else{
              binaire_val="00"+Convert.ToString(valendecimale,2);
             }
             return binaire_val;
        }
        
        public string recherche_mem_sansdepl(string reg_mem){
             int valendecimale = 0;
             string binaire_val;
             foreach(string r_m in list_mem_sansdep){
              if(reg_mem.Equals(r_m)){
                 valendecimale= Array.IndexOf(list_mem_sansdep,r_m);
                 break;   
              }
             } 
             // correction format 
             if(valendecimale > 3){
              binaire_val=Convert.ToString(valendecimale,2);
             }else if(valendecimale>1){
              binaire_val="0"+Convert.ToString(valendecimale,2);
             }else{
              binaire_val="00"+Convert.ToString(valendecimale,2);
             }
             return binaire_val;
        }
       

        public string recherche_reg(string reg){
          string reg_binaire="";
          int regvalue_decimal=0;
          Registers_enum myreg=(Registers_enum)Enum.Parse(typeof(Registers_enum),reg);
          regvalue_decimal = (int)myreg;
          // correction format 
          if(regvalue_decimal > 3){
            reg_binaire=Convert.ToString(regvalue_decimal,2);
          }else if(regvalue_decimal>1){
             reg_binaire="0"+Convert.ToString(regvalue_decimal,2);
          }else{
            reg_binaire="00"+Convert.ToString(regvalue_decimal,2);
          }
          return reg_binaire;
        }
        //cbn:remplir 01 fiha qlq details lzm ytbdlou -- meshi void string .. + deplval et tt rj3hum en binaire -- voir exemple lt7t.
          public string remplir_Reg_mem_imm16(string inst,string Reg_mem,bool ifdepl,string deplval,string imm16_val){   // INST Reg16/mem16,imm16
            string instruction_binaire="";
            string mod_binaire;
            string r_m_binaire="";           
            int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction= new Instruction(); 
            Console.WriteLine(index_of_mnemonique);              
            myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16/Mem16,imm16");
            instruction_binaire=myinstruction.getCop();
            Console.WriteLine(instruction_binaire);
            if(Reg_mem[0].Equals("[")){
               if(ifdepl){
                      mod_binaire="00";
                      r_m_binaire=recherche_mem_depl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
                      // j pas compris pourquoi tu traite l'instruction seul 
                      instruction_binaire=instruction_binaire+" "+HexStringToBinary(deplval);
               }else{
                      mod_binaire="10";
                      r_m_binaire=recherche_mem_sansdepl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);            
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
               }
            }else{
              mod_binaire="11";
              r_m_binaire=recherche_reg(Reg_mem);
              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
            }
          instruction_binaire=instruction_binaire+" "+HexStringToBinary(imm16_val);
           Console.WriteLine("the instruction "+instruction_binaire);
           return instruction_binaire;
        }  
        // methode dekhlelha les entrees te3 la pages hedik li 9bal simulation trj3lk instruction en binaire kima t7atha f la MC.
        public string remplir_AX_imm16(string inst,string imm16_val){   // INST AX,imm16 -- 
            // comment distingue le AX des autres registres ?
            // ca sera utile de verifier la valeur si elle est en 16bits + en hexa
            string instruction_binaire;          
            int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction= new Instruction();
            // il faut traiter le cas ou le format ne figure pas dans l'instruction 
            myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"AX,imm16");
            instruction_binaire=myinstruction.getCop();
            instruction_binaire=instruction_binaire+" "+HexStringToBinary(imm16_val);
            Console.WriteLine("the instruction : "+instruction_binaire);
            return instruction_binaire;
        }   
        public string remplir_reg16_mem16(string inst ,string Reg_mem,bool ifdepl,string deplval,string imm16_val){   // INST reg16/mem16 -- 
            string instruction_binaire;  
            string r_m_binaire;        
            string mod_binaire;
            int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction= new Instruction();
            myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16/Mem16");
            instruction_binaire=myinstruction.getCop();
            if(Reg_mem[0].Equals("[")){
               if(ifdepl){
                      mod_binaire="00";
                      r_m_binaire=recherche_mem_depl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
                      instruction_binaire=instruction_binaire+" "+HexStringToBinary(deplval);//hna dert padleft 7eta l 12 bits brk pasq deplacement max 3 f l'hexa - memoire sghira
               }else{
                      mod_binaire="10";
                      r_m_binaire=recherche_mem_sansdepl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
               }
            }else{
              mod_binaire="11";
              r_m_binaire=recherche_reg(Reg_mem);
              //Console.WriteLine("im here");
              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
            }
            System.Console.WriteLine("instruction en binaire :"+instruction_binaire);
            return instruction_binaire;
        } 
        public string remplir_reg16(string inst ,string Reg16){   // INST reg16 -- 
            string instruction_binaire;  
            string r_m_binaire;        
            int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction= new Instruction();
            myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16"); 
            instruction_binaire=myinstruction.getCop();
            r_m_binaire=recherche_reg(Reg16);
            instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
            System.Console.WriteLine("instruction en binaire :"+instruction_binaire);
            return instruction_binaire;
        }
        //-----------------------------------------------------------------------------------------------------------
         public string remplir_reg_mem_reg(string inst,string reg_mem,string reg,bool ifdepl,string deplval){  // INST REG/MEM,REG
               string instruction_binaire="";
               string mod_binaire;
               string r_m_binaire;
               string reg_binaire;
               int index_of_mnemonique=recherche_index_mnemonique(inst);
               Instruction myinstruction=new Instruction();
               myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16/Mem16,Reg16");
               instruction_binaire=myinstruction.getCop();
                reg_binaire=recherche_reg(reg);
                /*result = original.Substring(0,start) + replacement + original.Substring(start + length);Console.WriteLine(result);*/
                instruction_binaire=instruction_binaire.Substring(0,10)+reg_binaire+instruction_binaire.Substring(13);
                Console.WriteLine(instruction_binaire);
               if(reg_mem[0].Equals("[")){
               if(ifdepl){
                      mod_binaire="00";
                      r_m_binaire=recherche_mem_depl(reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
                      instruction_binaire=instruction_binaire+" "+HexStringToBinary(deplval);
               }else{
                      mod_binaire="10";
                      r_m_binaire=recherche_mem_sansdepl(reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);            
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
               }
            }else{
              mod_binaire="11";
              r_m_binaire=recherche_reg(reg_mem);
              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
            }
          Console.WriteLine("the instruction "+instruction_binaire);
           return instruction_binaire;    
        }
        // this is INST Reg16 , Reg16/mem16 c
         public string remplir_reg_reg_mem(string inst,string reg_mem,string reg,bool ifdepl,string deplval){ 
               string instruction_binaire="";
               string mod_binaire;
               string r_m_binaire;
               string reg_binaire;
               int index_of_mnemonique=recherche_index_mnemonique(inst);
               Instruction myinstruction=new Instruction();
               myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16,Reg16/Mem16");
               instruction_binaire=myinstruction.getCop();
                reg_binaire=recherche_reg(reg);
                /*result = original.Substring(0,start) + replacement + original.Substring(start + length);Console.WriteLine(result);*/
                instruction_binaire=instruction_binaire.Substring(0,10)+reg_binaire+instruction_binaire.Substring(13);
                Console.WriteLine(instruction_binaire);
               if(reg_mem[0].Equals("[")){
               if(ifdepl){
                      mod_binaire="00";
                      r_m_binaire=recherche_mem_depl(reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
                      instruction_binaire=instruction_binaire+" "+HexStringToBinary(deplval);
               }else{
                      mod_binaire="10";
                      r_m_binaire=recherche_mem_sansdepl(reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);            
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
               }
            }else{
              mod_binaire="11";
              r_m_binaire=recherche_reg(reg_mem);
              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
            }
          Console.WriteLine("the instruction "+instruction_binaire);
           return instruction_binaire;    
        }
        //---------------------------------------------------------------------------------------------------------- 
        //------------------- 
            public string remplir_reg_mem_cx(string inst,string Reg_mem,bool ifdepl,string deplval){   // INST Reg16/mem16,CX
            string instruction_binaire="";
            string mod_binaire;
            string r_m_binaire="";           
            int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction= new Instruction(); 
            //Console.WriteLine(index_of_mnemonique);              
            myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16/mem16,CX");
            instruction_binaire=myinstruction.getCop();
            Console.WriteLine(instruction_binaire);
            if(Reg_mem[0].Equals("[")){
               if(ifdepl){
                      mod_binaire="00";
                      r_m_binaire=recherche_mem_depl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
                      instruction_binaire=instruction_binaire+" "+HexStringToBinary(deplval);
               }else{
                      mod_binaire="10";
                      r_m_binaire=recherche_mem_sansdepl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);            
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
               }
            }else{
              mod_binaire="11";
              r_m_binaire=recherche_reg(Reg_mem);
              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
            }
           Console.WriteLine("the instruction "+instruction_binaire);
           return instruction_binaire;
        }   
        public string remplir_mem16(string inst,string mem16,bool ifdepl,string deplval ){
        string instruction_binaire = "" ;
        string mem_binaire=""; 
        int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
        Instruction myinstruction = new Instruction();
        myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"mem16");
        instruction_binaire = myinstruction.getCop(); 
         // l'instruction jmp est un cas particulier  
        if (instruction_binaire.IndexOf('x')==13){
          mem_binaire =recherche_mem_sansdepl(mem16); 
          instruction_binaire = instruction_binaire.Replace("xxx",mem_binaire);
            }else{
           if(ifdepl){
           // on doit verifie que le deplacement va etre seulement sur 16 bit ;;
            mem_binaire=recherche_mem_depl(mem16);
            instruction_binaire = instruction_binaire.Replace("xxxx",HexStringToBinary(deplval));
            instruction_binaire = instruction_binaire.Replace("xxx",mem_binaire);
            }else{
            mem_binaire =recherche_mem_sansdepl(mem16); 
            instruction_binaire = instruction_binaire.Replace("xxxx","0000");
            instruction_binaire = instruction_binaire.Replace("xxx",mem_binaire);
            }         
            }
       return instruction_binaire ; 
      }
        //------------------------------------------------------ partie execution ---------------------------------------------------
        // methode correction instruction .. 
        // remplir mc -- ecrire_mc (instruction,taille,adresse debut);

        /*
        methode qui manque
          Memoire Centrale -- Case:rech_mc(adresse); // case manque --oussama
          calcul_adresse(); //tous les cas possibles; //UAL --oussama
          positionner_indicateur(); //UAL; --amine.
          set/getContenuReg()                                                --generale //akhrib;
          
        */









        /*
        ecriture par defaut a l'adresse 0100
        positionnement co
        positionnemt ram / lect rim -> ri
        ex : ADD BX,CX 03D9 lecture we7da
        */
        //---------------------
        /*if(mem){
          string adresse = calculadresse();
          case = recherche_mc(adresse);
          case.setContenu(contenu_user);
        }*/
        //CO.setCo("0100");
        //page phase1;
        //animation(source : "co",destinataire : "ram","adresse");
        //MC.setRam(CO.getCo());
        //Case case = new Case();
        //case = rech_mc("0100");
        //MC.setRim(case.contenu);
        //animation("rim","ri","donnee");
        //setRI(MC.getRim());
        //bouton;
        //page phase2;
        //
       // string format;
        //switch (format){
       // case "Reg16,mem16/Reg16":
        //      if (r_m){ //reg,reg
                  //decodage -- delay
                  //setContenuRegistre(reg1,val1);
                  //setContenuRegistre(reg2,val2);
                  //hover (nombreregistre,reg1,reg2);
                  //animation(reg_destinataire,ual2,donnee);
                  //setUAL2(getContenuReg(reg_dest));
                  //animation(reg_source,ual1,donnee);
                  //setUAL2(getContenuReg(reg_source));
                  /*switch(mnemonique){
                    case add: var result = UAL.getUAL1 + UAL.getUAL2(operation en hexa); 
                  }*/
                  //positionner indicateur(mnemonique,result);
                  //animation(UAL,registres,donnee);
                  //setContenuRegistre(reg_dest,result);
                  
         //     }else{//reg,mem ADD AX,[SI+DI+5Dh]
                  //decodage -- delay
                  //setContenuRegistre(reg1,val1);
                  //switch(source){
                   // case "[SI+DI+depl]" : //setContenuRegistre(SI,val2); //setContenuRegistre(DI,val3);
                  //}
                  //hover (nombreregistre,reg1,reg2);
                  //animation(UAL,RAM,adresse);
                  //MC.setRAM(calaculadresse());
                  //MC.setRIM(rech_mc(adresse).getContenu());
                  //animation(RIM,UAL1) -- destinataire f ual2 / source ual1
                  //UAL.setUAL1(MC.getRIM());
                  //animation(reg,UAL2);
                  //UAL.setUAL2(getContenuReg(reg_dest));
                  //animation(reg_destinataire,ual2,donnee);
                  //setUAL2(getContenuReg(reg_dest));
                  //animation(reg_source,ual1,donnee);
                  //setUAL2(getContenuReg(reg_dest));
                  
                  /*switch(mnemonique){
                    case add: var result = UAL.getUAL1 + UAL.getUAL2(operation en hexa); 
                  }*/
                  //positionner indicateur(mnemonique,result);
                  //animation(UAL,registres,donnee);
                  //setContenuRegistre(reg_dest,result);
          //    }
        //    break;
     //   case "":
            // code to be executed if expression equals value2
       //     break;
        
     ///   default:
            // code to be executed if none of the above cases are true
          //  break;
     //   }
      public static void format_reg_regOUmem(string mnemonique , string format , bool mem_b , string distinataire , bool ifdepl , string valdepl ,string contenueCaseMemoire , string source , string val1 , string val2 , string val3 ,Image image, Image image1)
      {
            
            
            // le contenue de distinataire est toujour dans ual1
            string adresse ="" ; 
        string result ="" ; 
        if (mem_b){ //reg16,mem16
                if(ifdepl){
                  switch(source){
                     case "[BX+SI+depl]":
                    Registre.setContenuRegistre("BX",val2);
                    Registre.setContenuRegistre("SI",val3);
                    break;
                    case "[BX+DI+depl]":
                    Registre.setContenuRegistre("BX",val2);
                    Registre.setContenuRegistre("DI",val3);
                    break;
                    case "[BP+SI+depl]":
                    Registre.setContenuRegistre("BP",val2);
                    Registre.setContenuRegistre("SI",val3);
                    break;
                    case "[BP+DI+depl]":
                    Registre.setContenuRegistre("BP",val2);
                    Registre.setContenuRegistre("DI",val3);
                    break;
                    case "[SI+depl]":
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[DI+depl]":
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP+depl]":
                    Registre.setContenuRegistre("BP",val2);
                    break;
                    case "[BX+depl]":
                    Registre.setContenuRegistre("BX",val2);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                    }
                  }else{
                    switch(source){
                    case "[BX+SI]":
                    Registre.setContenuRegistre("BX",val2);
                    Registre.setContenuRegistre("SI",val3);
                    break;
                    case "[BX+DI]":
                    Registre.setContenuRegistre("BX",val2);
                    Registre.setContenuRegistre("DI",val3);
                    break;
                    case "[BP+SI]":
                    Registre.setContenuRegistre("BP",val2);
                    Registre.setContenuRegistre("SI",val3);
                    break;
                    case "[BP+DI]":
                    Registre.setContenuRegistre("BP",val2);
                    Registre.setContenuRegistre("DI",val3);
                    break;
                    case "[SI]":
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[DI]":
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP]":
                    Registre.setContenuRegistre("BP",val2);
                    break;
                    case "[BX]":
                    Registre.setContenuRegistre("BX",val2);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                  } 
                } 
            adresse = UAL.calculAdresse(source,ifdepl,valdepl);
            // animation(ual,ram,adresse) ; 
            MC.setRim(contenueCaseMemoire); 
            // animation (rim,ual2,donnee) ; 
            UAL.setUal2(MC.getRim()); 
            Registre.setContenuRegistre(distinataire, val1); 
            // animation (registre,ual1,donnee);
            UAL.setUal1(Registre.getContenuRegistre(distinataire));
               switch (mnemonique){
                  //add , sub ,mov, xchg ,and , or ,xor ,cmp
                  case "ADD" : 
                 //  result = ccm + contenue de registre ; 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16)+ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                   // positionner les flags 
                  break ; 
                  case "SUB" : 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16) -  Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
                  case "MOV" : // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                  result = UAL.getUal2() ; 
                  break ;
                  case "XCHG" : // ANIMATION PARTICULIER  
                  break ; 
                  case "AND" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) & Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ;
                  case "OR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) | Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ;
                  case "XOR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) ^ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
                }  
            // if ( mnemonique != xchg)
            // animation(ual,registre,donne) ; 
            Registre.setContenuRegistre(distinataire,result); 

        }else{
                
           Registre.setContenuRegistre(distinataire,val1);
           Registre.setContenuRegistre(source,val2);
                // animation(reg,ual1,donne);
                //Registre to ual1
                //MainWindow.AnimateImage(image, image1, -900, 8, -70, 7);
                //MainWindow.AnimateImage(myImag19e, myImag4e, -900, 8, -70, 7);
                //MainWindow.AnimateImage(myImag20e, myImag5e, -900, 8, -70, 7);
                UAL.setUal1(Registre.getContenuRegistre(distinataire));
           //animation (reg,ual2,donne); 
           UAL.setUal2(Registre.getContenuRegistre(source)); 
           switch(mnemonique){
            //add , sub ,mov, xchg ,and , or ,xor ,cmp
                  case "ADD" : 
                 //  result = ccm + contenue de registre ; 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16)+ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                   // positionner les flags 
                  break ; 
                  case "SUB" : 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16) -  Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
                  case "MOV" : // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                  result = UAL.getUal2() ; 
                  break ;
                  case "XCHG" : // ANIMATION PARTICULIER  
                  break ; 
                  case "AND" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) & Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ;
                  case "OR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) | Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ;
                  case "XOR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) ^ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
           } 
           // if(mnemonique != xchg){
            // animation(ual,registre,donne); 
            Registre.setContenuRegistre(distinataire,result);          
         }
        }
public static void format_ax_reg ( string mnenmonique , string source ,string  valAx ,string valsource  ) {
  Registre.setAx(valAx); 
  Registre.setContenuRegistre(source,valsource);
  // animation (registre , ual1 , donne ); 
   UAL.setUal1(Registre.getAx()); 
   // animation (registre ,ual2, donne ) ; 
   UAL.setUal2(Registre.getContenuRegistre(source)); 
   switch(mnenmonique){
    //xchg , 
    case "XCHG":
      // animation (ual , registre , donne )
      Registre.setAx(UAL.getUal2()); 
      // animation (ual,registre , donne ); 
      Registre.setContenuRegistre(source,UAL.getUal2());
      // positionner les indicateur ; 
    break ;
    default :
    Console.WriteLine("il ya un erreur"); 
    break ; 
   } 
}
  public static void format_ax_imm16(string mnemonique, string valAx , string valImmediate16){
    // ici je vais faire un petite bloc du code pour intialisé la 2eme case de la memoire par la valeur immidiate
     Case case_memoire = new Case();
     case_memoire = MC.recherche_mc("0101");
     case_memoire.setContenu(valImmediate16);
     case_memoire.setAdr("0101"); 
    // MC.AjouterCase(Convert.ToInt32("0101",16),case_memoire); 
     // fin de l'intialisation 
      Registre.setAx(valAx); 
      // animation(registre,ual1,donne); 
      Co.incCo(); 
      // animation(co,ram,adresse); 
      MC.setRam(Co.getco()); 
      case_memoire = MC.recherche_mc(Co.getco()); 
      MC.setRim(case_memoire.getContenu());
      // animation (rim,ual2,donne) ; 
      UAL.setUal2(MC.getRim()); 
      string result ="" ; 
      switch(mnemonique){
        //ADD , SUB , OR , XOR 
         case "ADD" : 
                 //  result = ccm + contenue de registre ; 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16)+ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                   // positionner les flags 
                  break ; 
         case "SUB" : 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16) -  Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
         case "OR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) | Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ;
         case "XOR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) ^ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
      }  
      // animation (UAL,registre,donne ); 
      Registre.setAx(result); 
  }
      public static void executer_simulation_phase_a_phase(string mnemonique,string format,bool mem_b,String mem,bool ifdepl ,string valdepl,string ccm,string source,string val1,string val2,string val3,Image image,Image image1){
           
            Case case_memoire = new Case();
        string result =""; 
        if(mem_b){//mem_b memoire booleen variable qui dit si c'est memoire ou pas
          //******* cette methode ne fonction pas dans ce cas car le contenue de registre n'est pas encore postionné
          string adresse = UAL.calculAdresse(mem,ifdepl,valdepl);
          case_memoire = MC.recherche_mc(adresse);
          case_memoire.setContenu(ccm);
        }
        Co.setco("0100");
        //page phase1;
        //animation(source : "co",destinataire : "ram",type : "adresse");
        MC.setRam(Co.getco());
        
       // case_memoire = MC.recherche_mc("0100");
       case_memoire.setAdr(Co.getco());
            case_memoire.setContenu(ccm);
        MC.setRim(case_memoire.getContenu());
        //animation("rim","ri","donnee");
        Ri.setRi(MC.getRim());
        //bouton ou bien delay;
        //page phase2;
        switch(format){
          case "Reg16/mem16,Reg16":
             if (mem_b){ //mem16,reg16
                if(ifdepl){
                  switch(mem){
                     case "[BX+SI+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BX+DI+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP+SI+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BP+DI+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[SI+depl]":
                    Registre.setContenuRegistre("SI",val1);
                    break;
                    case "[DI+depl]":
                    Registre.setContenuRegistre("DI",val1);
                    break;
                    case "[BP+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    break;
                    case "[BX+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                    }
                  }else{
                    switch(mem){
                    case "[BX+SI]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BX+DI]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP+SI]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BP+DI]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[SI]":
                    Registre.setContenuRegistre("SI",val1);
                    break;
                    case "[DI]":
                    Registre.setContenuRegistre("DI",val1);
                    break;
                    case "[BP]":
                    Registre.setContenuRegistre("BP",val1);
                    break;
                    case "[BX]":
                    Registre.setContenuRegistre("BX",val1);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                  } 
                } 
                Registre.setContenuRegistre(source,val3);
               string adresse = UAL.calculAdresse(mem,ifdepl,valdepl); 
                // animation(UAL,RAM,adresse); 
                MC.setRam(adresse); 
                case_memoire = MC.recherche_mc(adresse);
                case_memoire.setContenu(ccm);
                MC.setRim(ccm);
                // animation(RIM,UAL1,DONNE); 
                 UAL.setUal1(ccm); 
                // animation(registre, UAL2 ,DONNE); 
                switch (mnemonique){
                  //add , sub ,mov, xchg ,and , or ,xor ,cmp
                  case "ADD" : 
                 //  result = ccm + contenue de registre ; 
                   result  =   (Convert.ToInt32(ccm,16)+ Convert.ToInt32(val3,16)).ToString("X");
                   // positionner les flags 
                  break ; 
                  case "SUB" : 
                   result  =   (Convert.ToInt32(ccm,16) -  Convert.ToInt32(val3,16)).ToString("X");
                  break ; 
                  case "MOV" : // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                  result = val3 ; 
                  break ;
                  case "XCHG" : // ANIMATION PARTICULIER  
                  break ; 
                  case "AND" : 
                  result = ( Convert.ToInt32(ccm,16) & Convert.ToInt32(val3,16)).ToString("X");
                  break ;
                  case "OR" : 
                  result = ( Convert.ToInt32(ccm,16) | Convert.ToInt32(val3,16)).ToString("X");
                  break ;
                  case "XOR" : 
                  result = ( Convert.ToInt32(ccm,16) ^ Convert.ToInt32(val3,16)).ToString("X");
                  break ; 
                }  
                 // vu que xchng a une animation particulier on va la traiter dans le switch
                  //  if(mnemonique != xchg)
                 // animation(ual,rim,donne)
                 MC.setRim(result); 
             }else { // la on est dans ke cas de reg,reg 
               Registre.setContenuRegistre(mem,val1);
               Registre.setContenuRegistre(source,val2);
               // animation(registre,ual1,donne) ; 
               UAL.setUal1(Registre.getContenuRegistre(mem)); 
               // animation(registre,ual2,donne) ;
               UAL.setUal2(Registre.getContenuRegistre(source)); 
               switch (mnemonique){
                  //add , sub ,mov, xchg ,and , or ,xor ,cmp
                  case "ADD" : 
                 //  result = ccm + contenue de registre ; 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16)+ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                   // positionner les flags 
                  break ; 
                  case "SUB" : 
                   result  =   (Convert.ToInt32(UAL.getUal1(),16) -  Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
                  case "MOV" : // je pens que le emu ne fonction pas comme ca dans des fonctions parielle 
                  result = ccm ; 
                  break ;
                  case "XCHG" : // ANIMATION PARTICULIER  
                  break ; 
                  case "AND" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) & Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ;
                  case "OR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) | Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ;
                  case "XOR" : 
                  result = ( Convert.ToInt32(UAL.getUal1(),16) ^ Convert.ToInt32(UAL.getUal2(),16)).ToString("X");
                  break ; 
                } // animation(ual,registre,donne); 
                   Registre.setContenuRegistre(mem,result);



             }
          break; 
          case "Reg16,Reg16/mem16" : 
              format_reg_regOUmem(mnemonique,format,mem_b,mem,ifdepl,valdepl,ccm,source,val1,val2,val3,image,image1); 
           break ; 
          case "Ax,Reg16" : 
              format_ax_reg(mnemonique,source,val1,val2); 
          break ; 
          // mem16
          case "mem16":
                //decodage -- delay
                if (ifdepl){
                    switch(source){
                    case "[BX+SI+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BX+DI+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP+SI+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BP+DI+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[SI+depl]":
                    Registre.setContenuRegistre("SI",val1);
                    break;
                    case "[DI+depl]":
                    Registre.setContenuRegistre("DI",val1);
                    break;
                    case "[BP+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    break;
                    case "[BX+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                    }
                  }else{
                    switch(source){
                    case "[BX+SI]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BX+DI]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP+SI]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BP+DI]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[SI]":
                    Registre.setContenuRegistre("SI",val1);
                    break;
                    case "[DI]":
                    Registre.setContenuRegistre("DI",val1);
                    break;
                    case "[BP]":
                    Registre.setContenuRegistre("BP",val1);
                    break;
                    case "[BX]":
                    Registre.setContenuRegistre("BX",val1);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                    }
                  }
                  //hover (nombreregistre,reg1,reg2);
                  //animation(Registre,CO,adresse);
                  Registre.setCx(val1);// f loop user must set CX content ... 
                  switch(mnemonique){

                    case "JMP":
                    Co.setco(UAL.calculAdresse(mem,ifdepl,valdepl));
                    MC.setRam(Co.getco());
                    MC.setRim(MC.recherche_mc(MC.getRam()).getContenu());
                    UAL.positionnerIndicateurs("JMP");
                    //normalement c'est ca mnkmlush l'execution de la suite --
                    break;
                    case "LOOP":
                    
                    for(int i = 0;i<int.Parse(Registre.getCx())-1;i++){ 
                      Registre.setCx(Convert.ToString((int.Parse(Registre.getCx())-1)));
                      UAL.positionnerIndicateurs("LOOP");
                      Co.setco(UAL.calculAdresse(mem,ifdepl,valdepl));
                      MC.setRam(Co.getco());
                      MC.setRim(MC.recherche_mc(MC.getRam()).getContenu()); 
                      //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                      //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                    }
                    //apres loop 
                    //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                    break;
                    case "LOOPZ":
                      for(int i = 0;i<int.Parse(Registre.getCx())-1;i++){
                      if (Indicateur.getZero() != '1'){
                      UAL.positionnerIndicateurs("LOOPZ");
                      Co.setco(UAL.calculAdresse(mem,ifdepl,valdepl));
                      MC.setRam(Co.getco());
                      MC.setRim(MC.recherche_mc(MC.getRam()).getContenu()); 
                      //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                      //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                      //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                      }else{
                        break;
                      }
                      }
                      //apres loop 
                      //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                    break;
                    case "LOOPE": //loope est identique a loopz
                    for(int i = 0;i<int.Parse(Registre.getCx())-1;i++){
                      if (Indicateur.getZero() == '1'){
                      UAL.positionnerIndicateurs("LOOPE");
                      Co.setco(UAL.calculAdresse(mem,ifdepl,valdepl));
                      MC.setRam(Co.getco());
                      MC.setRim(MC.recherche_mc(MC.getRam()).getContenu()); 
                      //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                      //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                      //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                      }else{
                        break;
                      }
                      }
                      //apres loop 
                      //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                    break;
                    case "LOOPNZ":
                    for(int i = 0;i<int.Parse(Registre.getCx())-1;i++){
                      if (Indicateur.getZero() != '0'){
                      UAL.positionnerIndicateurs("LOOPNZ");
                      Co.setco(UAL.calculAdresse(mem,ifdepl,valdepl));
                      MC.setRam(Co.getco());
                      MC.setRim(MC.recherche_mc(MC.getRam()).getContenu()); 
                      //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                      //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                      //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                      }else{
                        break;
                      }
                      }
                      //apres loop 
                      //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                    break;
                    case "LOOPNE":
                    for(int i = 0;i<int.Parse(Registre.getCx())-1;i++){
                      if (Indicateur.getZero() != '0'){
                      UAL.positionnerIndicateurs("LOOPNE");
                      Co.setco(UAL.calculAdresse(mem,ifdepl,valdepl));
                      MC.setRam(Co.getco());
                      MC.setRim(MC.recherche_mc(MC.getRam()).getContenu()); 
                      //apres la on doit dechiffrer l'instruction qui se trouve a l'adresse pour pouvoir l'executer
                      //executer instruction a l'adresse x a partir du code binaire. -- recursif chghul lehna
                      //UAL.positionnerIndicateurs("mnemonique instruction a l'adresse x ");
                      }else{
                        break;
                      }
                      }
                      //apres loop 
                      //execution instruction suivante -- on la traite pas mais ca doit etre signale avec une fenetre -- front-end.
                    break;
                    default:
                    System.Console.WriteLine("Error ! mnenmonique not defined");
                    break;
                  }
                
          break;
          case "Reg/mem16":
          if(mem_b){
             if(ifdepl){
                    switch(source){
                    case "[BX+SI+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BX+DI+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP+SI+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BP+DI+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[SI+depl]":
                    Registre.setContenuRegistre("SI",val1);
                    break;
                    case "[DI+depl]":
                    Registre.setContenuRegistre("DI",val1);
                    break;
                    case "[BP+depl]":
                    Registre.setContenuRegistre("BP",val1);
                    break;
                    case "[BX+depl]":
                    Registre.setContenuRegistre("BX",val1);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                    }
                  }else{
                    switch(source){
                    case "[BX+SI]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BX+DI]":
                    Registre.setContenuRegistre("BX",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[BP+SI]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("SI",val2);
                    break;
                    case "[BP+DI]":
                    Registre.setContenuRegistre("BP",val1);
                    Registre.setContenuRegistre("DI",val2);
                    break;
                    case "[SI]":
                    Registre.setContenuRegistre("SI",val1);
                    break;
                    case "[DI]":
                    Registre.setContenuRegistre("DI",val1);
                    break;
                    case "[BP]":
                    Registre.setContenuRegistre("BP",val1);
                    break;
                    case "[BX]":
                    Registre.setContenuRegistre("BX",val1);
                    break;
                    default:
                    System.Console.WriteLine("Error ! no such mem_depl");
                    break;
                    }
                  }
                  //hover (nombreregistre,reg1,reg2);
                  //animation(Registre,CO,adresse);
                  //animation (Registres,RAM,adresse)
                  string adresse = UAL.calculAdresse(mem,ifdepl,valdepl);
                  MC.setRam(adresse);
                  MC.setRim(MC.recherche_mc(adresse).getContenu());
                  //animation(Rim,UAL2,donee)
                  UAL.setUal2(MC.getRim());
                  switch(mnemonique){
                    case "INC":
                    UAL.setUal1("1");
                    int hexInt = Convert.ToInt32(UAL.getUal2(), 16);
                    hexInt++;
                     result = Convert.ToString(hexInt, 16).ToUpper();
                    UAL.positionnerIndicateurs("INC");
                    //animation (UAL,rim);
                    MC.setRim(result);
                    MC.recherche_mc(adresse).setContenu(result);
                    //fin
                    break;
                    case "DEC":
                    UAL.setUal1("FFFF");//-1
                    hexInt = Convert.ToInt32(UAL.getUal2(), 16);
                    hexInt--;
                    result = Convert.ToString(hexInt, 16).ToUpper();
                    UAL.positionnerIndicateurs("DEC");
                    //animation (UAL,rim);
                    MC.setRim(result);
                    MC.recherche_mc(adresse).setContenu(result);
                    //fin
                    break;
                    case "MUL":
                    //in this instruction user must specify content of BX
                    Registre.setBx(val3);
                    //hover registre
                    //animation (registre,UAL1);
                    BigInteger bi1 = BigInteger.Parse(UAL.getUal2(), NumberStyles.HexNumber);
                    BigInteger bi2 = BigInteger.Parse(Registre.getBx(), NumberStyles.HexNumber);
                    BigInteger result_mul = bi1 * bi2;
                    string hexResult = result_mul.ToString("X8");//32 bits representation
                    UAL.positionnerIndicateurs("MUL");
                    //animation(UAL,registre,donnee);
                    string poids_fort = hexResult.Substring(0, 15);
                    string poids_faible = hexResult.Substring(16, 32);
                    Registre.setAx(poids_faible);
                    Registre.setDx(poids_faible);
                    break;
                    case "NOT":
                    ushort operand = ushort.Parse(UAL.getUal2(), NumberStyles.HexNumber);
                    ushort result_not = (ushort)~operand;
                    hexResult = result_not.ToString("X4");
                    UAL.positionnerIndicateurs("NOT");
                    //animation (UAL,rim);
                    MC.setRim(hexResult);
                    MC.recherche_mc(adresse).setContenu(hexResult);
                    break;
                    default:
                    break;
                  }
             }else{

             } 
          break;
          default:
          break;
        }
    }
    }

}