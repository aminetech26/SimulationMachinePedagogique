using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiMind
{
    internal class Case
    {  
      private string? adr ; 
      private string? contenue ; 
      public void setAdr(string adr){
        this.adr = adr ; 
      } 
      public string getAdr(){ 
        return this.adr; 
      }
      public string getContenu(){
        return this.contenue ; 
      } 
      public void setContenu(string contenue){
        this.contenue = contenue ; 
      }
    }
}