using ArchiMind;
using System.Security.AccessControl;
using System;
using ArchiMind;
namespace projet{
internal class Program
{
    static void main(string[] args){
        ProgrammePage myprog_page=new ProgrammePage();
        Instruction myinstruction=new Instruction("AX,imm16","00000101");
        myinstruction.setval_imm16("0123");
        myinstruction.setmnemonique("ADD");
        Console.WriteLine("the instruction :",myprog_page.convertir_instruction_Lmnemonique(myinstruction));
    } 
}
}