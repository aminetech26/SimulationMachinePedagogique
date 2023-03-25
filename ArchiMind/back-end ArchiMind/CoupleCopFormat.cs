using System;
using System.Numerics;
using System.Collections;

namespace ArchiMind
{    
     
     internal class CoupleCopFormat
    {  
        public ArrayList listInstruction = new ArrayList (); 
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
        public ArrayList getListInstruction(){
            return listInstruction ; 
        }
              
    }

}