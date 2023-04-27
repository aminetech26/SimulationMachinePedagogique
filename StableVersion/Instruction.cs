using System;
using System.Numerics;

namespace ArchiMind
{
     internal class Instruction
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

        public void setFormat (string format) { this.format = format; }
        public void setCop (string cop) { this.cop= cop; }
        public string getFormat () { return this.format; }
        public string getCop() { return this.cop; }
        public string getMnemonique()
        {
               return this.mnemonique;
        }
        public bool getRegM()
        {
            return mem; 
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
        public void setIfDepl(bool ifdepl)
        {
            this.ifdepl = ifdepl;
        }
        public void setMem(bool mem)
        {
            this.mem = mem;
        }

        public Instruction (){
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
        public Instruction(string format, string cop, string champ_notused, string mnemonique, bool mem, string destination, string source, bool ifdepl, string valdep) : this(format, cop, champ_notused){
            this.mnemonique = mnemonique;
            this.mem = mem;
            this.destination = destination;
            this.source = source;
            this.ifdepl = ifdepl;
            this.valdep = valdep;
        }


        public void afficheInstruction()
        {
            Console.Write(getFormat()+" ");
            Console.WriteLine(getCop());
            
        }
    }

}