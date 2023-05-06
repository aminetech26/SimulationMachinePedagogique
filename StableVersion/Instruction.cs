using System;
using System.Numerics;

namespace ArchiMind
{
     public class Instruction
    {
        private string format;
        private string cop;
        private string champ_notused;
        private string mnemonique;
        private bool mem; //mem ou reg
        private string destination;
        private string source;
        private bool ifdepl;
        private string valdep;
        private string val_imm16;

        public void setFormat (string format) { this.format = format; }
        public void setCop (string cop) { this.cop= cop; }
        public string getFormat () { return this.format; }
        public string getCop() { return this.cop; }
        public string getMnemonique()
        {
               return this.mnemonique;
        }
        public bool getmem()
        {
            return this.mem; 
        }
        public string getSource()
        {
            return this.source;
        }
        public string getDestination()
        {
            return this.destination;
        }
        public bool getifdepl()
        {
            return this.ifdepl;
        }
        public string getValDepl()
        {
            return this.valdep;
        }
        public string getval_imm16()
        {
            return this.val_imm16;
        }
        public void setval_imm16(string val_imm16)
        {
            this.valdep = val_imm16;
        }
        public void setIfDepl(bool ifdepl)
        {
            this.ifdepl = ifdepl;
        }
        public void setMem(bool mem)
        {
            this.mem = mem;
        } 
        public Instruction()
        {

        }
        public Instruction (string format , string cop ){
            this.format = format;
            this.cop = cop;
        }  
        
        public Instruction (string format , string cop ,string champ_notused){
            this.format = format;
            this.cop = cop;
            this.champ_notused=champ_notused;
        }  
        public Instruction(string mnemonique, string format, string destination, string source, bool mem=true, bool ifdepl=true, string valdep=""){
            this.format=format;
            this.mnemonique = mnemonique;
            this.mem = mem;
            this.destination = destination;
            this.source = source;
            this.ifdepl = ifdepl;
            this.valdep = valdep;
        }


        public void afficheInstruction()
        {
            Console.Write(getMnemonique()+" ");
            Console.Write(getFormat() + " ");
            Console.Write(getDestination() + " ");
            Console.Write(getSource() + " ");
            Console.Write(getValDepl() + " ");
        }




    }

}