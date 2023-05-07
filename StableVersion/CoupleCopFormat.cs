using System;
using System.Numerics;
using System.Collections;
using System.Windows.Documents;
using System.Collections.Generic;

namespace ArchiMind
{    
     
     internal class CoupleCopFormat
    {  
        public List<Instruction> listInstruction = new List<Instruction>();
        public void addInstruction (Instruction s ) {
            listInstruction.Add(s); 
        }  
         public void afficheFormatCop()
        {
            foreach (Instruction element in listInstruction)
            {
                element.afficheInstruction();
            }
        }   
        public List<Instruction> getListInstruction(){
            return listInstruction ; 
        }
              
    }

}