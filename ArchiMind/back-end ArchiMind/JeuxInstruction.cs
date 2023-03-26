using System;
using System.Numerics;
using System.Collections;


namespace ArchiMind
{
      internal class JeuxInstruction
    {
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
         mycouple.addInstruction(mycouple);

        // l'intialisation des format de l'istruction AND // index = 9 
         mycouple =new CoupleCopFormat();
         instruction =new Instruction("Reg16/mem16,imm16","10000001xx100xxx","100");
         mycouple.addInstruction(mycouple);
         instruction =new Instruction("Reg16/mem16,Reg16","00100001xxxxxxxx");
         mycouple.addInstruction(mycouple);
         instruction =new Instruction("Reg16,Reg16/mem16","00100011xxxxxxxx");
         mycouple.addInstruction(mycouple);
         detailInstruction.Add(mycouple);

        // l'intialisation des format de l'istruction OR // index = 10 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("AX,imm16","00001101");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16,mem16,imm16","10000001xx001xxx","001");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16/mem16,Reg16","00001001xxxxxxxx");
         mycouple.addInstruction(mycouple);
         instruction =new Instruction("Reg16,Reg16/mem16","00001011xxxxxxxx");
         mycouple.addInstruction(mycouple);
         detailInstruction.Add(mycouple);

        // l'intialisation des format de l'istruction XOR // index = 11 
         mycouple =new CoupleCopFormat();
         instruction=new Instruction("AX,imm16","00110101");
         mycouple.addInstruction(instruction);
         instruction=new Instruction("Reg16,mem16,imm16","10000001xx110xxx","110");
         mycouple.addInstruction(instruction);
         instruction =new Instruction("Reg16/mem16,Reg16","00110001xxxxxxxx");
         mycouple.addInstruction(mycouple);
         instruction =new Instruction("Reg16,Reg16/mem16","00110011xxxxxxxx");
         mycouple.addInstruction(mycouple);
         detailInstruction.Add(mycouple);

       //------------------- logic instructions ---------------------------------------------------------------------------------

        } 
        public CoupleCopFormat getMycouple(){
             return Mycouple; 
        }    

        // les methodes de remplissage de code operation

        public void recherche_index_mnemonique(Mnemoniques INST){
          int index_of_mnemonique=(int) INST;    
        }
        public void remplir_01(){
        }      
    }

}