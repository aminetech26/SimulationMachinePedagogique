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
        public string ADR { get; set; }
        public string Donnee { get; set; }

        public void setAdr(string adr)
        {
            this.ADR = adr;
        }
        public string getAdr()
        {
            return this.ADR;
        }
        public string getContenu()
        {
            return this.Donnee;
        }
        public void setContenu(string contenue)
        {
            this.Donnee = contenue;
        }
    }
}