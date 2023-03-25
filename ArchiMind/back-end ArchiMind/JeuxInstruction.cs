using System;
using System.Numerics;
using System.Collections;


namespace ArchiMind
{
      internal class JeuxInstruction
    {
        private CoupleCopFormat Mycouple = new CoupleCopFormat() ; 
        private ArrayList  detailInstruction = new ArrayList ();
        
        public void intialize()
        {   
            // la methode qui intialise 
           Instruction instruction = new Instruction("AX,imm16", "00000101");
           Mycouple.addInstruction(instruction);  
           instruction = new Instruction("Reg16/Mem16,imm16","10000001xx000xxx","000") ; 
           Mycouple.addInstruction(instruction); 
           instruction = new Instruction("Reg16/Mem16,Reg16","00000001xxxxxxxx") ;   
           Mycouple.addInstruction(instruction) ; 
           instruction = new Instruction("Reg16,Reg16/Mem16","00000011xxxxxxxx") ;   
           Mycouple.addInstruction(instruction) ;
        } 
        public CoupleCopFormat getMycouple(){
             return Mycouple; 
        }           
    }

}