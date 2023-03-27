using System;
using System.Numerics;

namespace ArchiMind
{
     internal class Instruction
    {
        private string format;
        private string cop;
        private string champ_notused;
        public void setFormat (string format) { this.format = format; }
        public void setCop (string cop) { this.cop= cop; }
        public string getFormat () { return this.format; }
        public string getCop() { return this.cop; }
         public Instruction ()
        {
        }  
        public Instruction (string format , string cop )
        {
            this.format = format;
            this.cop = cop;
        }  
        public Instruction (string format , string cop ,string champ_notused)
        {
            this.format = format;
            this.cop = cop;
            this.champ_notused=champ_notused;
        }  
        public void afficheInstruction()
        {
            Console.Write(getFormat()+" ");
            Console.WriteLine(getCop());
            
        }
    }

}