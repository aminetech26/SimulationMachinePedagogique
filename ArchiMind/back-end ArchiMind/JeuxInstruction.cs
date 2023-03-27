using System;
using System.Numerics;
using System.Collections;


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

             //---------------------------------- Arithemethique instructions ---------------------------------------------------------------------------

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

       //------------------- transfere instructions ------------------------------------------------------------------
        
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
        //--------------------------------------------------------------------------------------------------- 
        } 
       public CoupleCopFormat getMycouple(){
             return mycouple; 
        }    
        // les methodes de remplissage de code operation

        private int recherche_index_mnemonique(Mnemoniques inst){ 
            return (int) inst; 
        }
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
        public string recherche_mem_depl(string reg_mem){
             int valendecimale = 0;
             string binaire_val;
             foreach(string r_m in list_mem_dep){
              if(reg_mem.Equals(r_m)){
                 valendecimale= Array.IndexOf(list_mem_dep,r_m);
                 break;   
              }
             }
             if(valendecimale > 3){
              binaire_val=Convert.ToString(valendecimale,2);
             }else{
              binaire_val="0"+Convert.ToString(valendecimale,2);
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
             if(valendecimale > 3){
              binaire_val=Convert.ToString(valendecimale,2);
             }else{
              binaire_val="0"+Convert.ToString(valendecimale,2);
             }
             return binaire_val;
        }
        public string recherche_reg(string reg){
          string reg_binaire="";
          int regvalue_decimal=0;
          Registers_enum regist=(Registers_enum)Enum.Parse(typeof (Registers_enum),reg);
          regvalue_decimal=(int) regist;
          if(regvalue_decimal > 3){
            reg_binaire=Convert.ToString(regvalue_decimal,2);
          }else{
             reg_binaire="0"+Convert.ToString(regvalue_decimal,2);
          }
          return reg_binaire;
        }
        public void remplir_01(Mnemoniques inst ,string Reg_mem,bool ifdepl,string deplval,string imm16_val){   // INST Reg16/mem16,imm16
            string instruction_binaire;
            string mod_binaire;
            string r_m_binaire="";           
            int index_of_mnemonique =recherche_index_mnemonique(inst); // this will return the index of where i can have access to all the format and cop of "inst"
            Instruction myinstruction= new Instruction();
            myinstruction = recherche_instruction((CoupleCopFormat)detailInstruction[index_of_mnemonique],"Reg16/mem16,imm16");
            instruction_binaire=myinstruction.getCop();
            if(Reg_mem[0].Equals("[")){
               if(ifdepl){
                      mod_binaire="00";
                      r_m_binaire=recherche_mem_depl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
                      instruction_binaire=instruction_binaire+" "+deplval;
               }else{
                      mod_binaire="10";
                      r_m_binaire=recherche_mem_sansdepl(Reg_mem);
                      instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
                      instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
               }
            }else{
              mod_binaire="11";
              r_m_binaire=recherche_reg(Reg_mem);
              Console.WriteLine("im here");
              instruction_binaire=instruction_binaire.Replace("xxx",r_m_binaire);
              instruction_binaire=instruction_binaire.Replace("xx",mod_binaire);
            }
          instruction_binaire=instruction_binaire+" "+imm16_val;
           Console.WriteLine("the instruction "+instruction_binaire);
        }      
    }

}