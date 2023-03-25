using System;
using System.Numerics;

namespace ArchiMind
{
     internal class Instruction
    {
        private string format;
        private string cop;
        public void setFormat (string format) { this.format = format; }
        public void setCop (string cop) { this.cop= cop; }
        public string getFormat () { return this.format; }
        public string getCop() { return this.cop; }
        public Instruction (string format , string cop )
        {
            this.format = format;
            this.cop = cop;
        }  
        public void afficheInstruction()
        {
            Console.Write(getFormat()+" ");
            Console.WriteLine(getCop());
        }
    }

}