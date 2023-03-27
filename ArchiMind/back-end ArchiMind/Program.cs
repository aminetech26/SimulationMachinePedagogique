using ArchiMind;
using System.Security.AccessControl;

internal class Program
{
    public static void Main(string[] args)
    {
       JeuxInstruction j = new JeuxInstruction();
       j.intialize();
       // j.getMycouple().afficheFormatCop();
       string reg="BX";
        j.remplir_01(Mnemoniques.ADD,reg,false,"xxxx","1234");
        
    }
}