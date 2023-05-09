using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;
using System.Data;
using System.Windows.Threading;
using ArchiMind;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;
using System.Diagnostics.Metrics;
using projet.Pages;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Reflection;
using System.Configuration;

namespace projet
{
    /// <summary>
    /// Interaction logic for Animation.xaml
    /// </summary>
    public partial class Animation : Window
    {

        private static Animation animatpage;
        private static Page_EntreeSortie _entreeSortie;
        private static Page2 Arith;
        private static Page5 Arith1;
        private static Transfert transfert;
        private static Page _p;

        public static void setcontext(Page p)
        {
            _p = p;
        }


        public static Page getcontext()
        {
            return _p;
        }
        //public static void setcontext(Page_EntreeSortie page)
        //{ _entreeSortie = page; }

        //private static Page _page; 
        //public static Page getcontext()
        //{
        //    return _page ;
        //}
       
        //public static void setcontext(Page2 page)
        //{ Arith = page; }

        //public static void setcontext(Page5 page)
        //{ Arith1 = page; }

        //public static void setcontext(Transfert page)
        //{ transfert = page; }

        List<Case> _animals;
        public Animation()
        {
            InitializeComponent();
            animatpage = this;
            JeuxInstruction.setJeux(animatpage);
            MC.mc = new List<Case>();
            MC.mc.Add(new Case { ADR = "", Donnee = "" });
            MC.mc.Add(new Case { ADR = "104", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "105", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "106", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "107", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "108", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "109", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "10A", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "10B", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "10C", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "10D", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "10E", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "10F", Donnee = "0000" });
            MC.mc.Add(new Case { ADR = "110", Donnee = "0000" });
            dataGrid1.ItemsSource = MC.mc;
            // dataGrid1.SelectedIndex = 1;
            textBox1.Text = "1";
            //this.dataGrid1.SelectAll(); 
            this.Loaded += MainWindow_Loaded;

        }





        public  Animation(string Reg1, string Reg2, string Reg3, string ccm, string Valdep, string memonique, string Format, string RegM, string dep, string destinaitr, string source, string NomReg1, string NomReg2, string NomReg3)
        {
            InitializeComponent();
            animatpage = this;
            JeuxInstruction.setJeux(animatpage);
            // pour manupiler les parametre de la fonction executer_simulation_phase_a_phase
            List<Image> listeImages = new List<Image>();
            listeImages.Add(myImage);   // 0
            listeImages.Add(myImage1);  // 1
            listeImages.Add(myImage2);  // 2 
            listeImages.Add(myImag0e);  // 3
            listeImages.Add(myImag1e);  // 4
            listeImages.Add(myImag2e);  // 5
            listeImages.Add(myImag3e);  // 6
            listeImages.Add(myImag4e);  // 7
            listeImages.Add(myImag5e);  // 8
            listeImages.Add(myImag6e);  // 9
            listeImages.Add(myImag7e);  // 10
            listeImages.Add(myImag8e);  // 11
            listeImages.Add(myImag9e);  // 12
            listeImages.Add(myImag10e); // 13
            listeImages.Add(myImag11e); // 14
            listeImages.Add(myImag12e); // 15
            listeImages.Add(myImag13e); // 16
            listeImages.Add(myImag14e); // 17
            listeImages.Add(myImag15e); // 18
            listeImages.Add(myImag16e); // 19
            listeImages.Add(myImag17e); // 20
            listeImages.Add(myImag18e); // 21
            listeImages.Add(myImag19e); // 22
            listeImages.Add(myImag20e); // 23
            listeImages.Add(myImag21e); // 24
            listeImages.Add(myImag22e); // 25
            listeImages.Add(myImag23e); // 26
            listeImages.Add(myImag24e); // 27
            listeImages.Add(myImag25e); // 28
            listeImages.Add(myImag26e); // 29
            listeImages.Add(myImag30e); // 30
            listeImages.Add(myImag31e); // 31
            listeImages.Add(myImag32e); // 32 
            listeImages.Add(myImag33e); // 33 
            listeImages.Add(myImag34e); // 34 
            listeImages.Add(myImag35e); // 35 
            listeImages.Add(myImag36e); // 36 
            listeImages.Add(myImag37e); // 37 
            listeImages.Add(myImag38e); // 38 
            listeImages.Add(myImag39e); // 39 
            listeImages.Add(myImag40e); // 40 
            listeImages.Add(myImag41e); // 41 
            listeImages.Add(myImag42e); // 42 
            listeImages.Add(myImag43e); // 43 
            listeImages.Add(myImag44e); // 44 
            listeImages.Add(myImag45e); // 45 
            listeImages.Add(myImag46e); // 46 
            listeImages.Add(myImag47e); // 47 
            listeImages.Add(myImag48e); // 48 
            listeImages.Add(myImag49e); // 49 
            listeImages.Add(myImag50e); // 50 
            listeImages.Add(myImag51e); // 51 
            listeImages.Add(myImag52e); // 52 
            listeImages.Add(myImag53e); // 53 
            listeImages.Add(myImag54e); // 54 
            listeImages.Add(myImag55e); // 55 
            listeImages.Add(myImag56e); // 56 
            listeImages.Add(myImag57e); // 57 
            listeImages.Add(myImag58e); // 58 
            listeImages.Add(myImag59e); // 59
            listeImages.Add(myImag60e); // 60
            listeImages.Add(myImag61e); // 61
            listeImages.Add(myImag62e); // 62
            listeImages.Add(myImag63e); // 63  
            listeImages.Add(myImag64e); // 64  
            listeImages.Add(myImag65e); // 65  
            listeImages.Add(myImag66e); // 66  
            listeImages.Add(myImag67e); // 67  
            listeImages.Add(myImag68e); // 68
             listeImages.Add(myImag70e); // 69  
            listeImages.Add(myImag71e); // 70  
            listeImages.Add(myImag72e); // 71  
            listeImages.Add(myImag73e); // 72  
            listeImages.Add(myImag74e); // 73  
            listeImages.Add(myImag75e); // 74 
            listeImages.Add(AdrCo);    //75
            listeImages.Add(AdrCo1);    //76
            listeImages.Add(AdrCo2);    //77
            listeImages.Add(AdrUal);    //78
            listeImages.Add(AdrUal1);   //79
            listeImages.Add(AdrUal2);   //80
            listeImages.Add(AdrUal3);   //81
            listeImages.Add(AdrUal4);   //82
            listeImages.Add(AdrUal5);   //83
            listeImages.Add(AdrUal6);   //84
            listeImages.Add(AdrUal7);   //85
            listeImages.Add(AdrUal8);   //86
            Boolean mem_b;
            Boolean ifdep;

            if (RegM == " Memoire ") mem_b = true;
            else mem_b = false;
            if (Valdep == "XXXX") ifdep = false;
            else ifdep = true;
            string i;
            MC.mc = new List<Case>();
            MC.mc.Add(new Case { ADR = "", Donnee = "" });

            if ((Format == "AX,imd16")||((Format=="Reg16/Mem16,imm16")&& (RegM == " Registre "))|| (Format == "Reg16,imm16")|| (Format=="AX,Reg16")|| ((Format == "Reg16/mem16,Reg16") && (RegM == " Registre "))|| ((Format == "Reg16,Reg16/mem16") && (RegM == " Registre ")) || ((Format == "Reg16/Mem16,CX") && (RegM == " Registre ")))
            {

                MC.mc.Add(new Case { ADR = "100", Donnee = "0005" });
                MC.mc.Add(new Case { ADR = "101", Donnee = Reg3 });
                MC.mc.Add(new Case { ADR = "102", Donnee = "0000" });
                MC.mc.Add(new Case { ADR = "103", Donnee = "0000" });
            }

            if ((Format == "Reg16")||((Format == "Reg16/mem16") && (RegM == " Registre "))||(Format== "AX,DX"))
            {
                MC.mc.Add(new Case { ADR = "100", Donnee = "0005" });
                MC.mc.Add(new Case { ADR = "101", Donnee = "0000" });
                MC.mc.Add(new Case { ADR = "102", Donnee = "0000" });
            }

            if (((Format == "Reg16/mem16,Reg16") && (RegM == " Memoire ")))
            {
                
                MC.mc.Add(new Case { ADR = "100", Donnee = "0005" });
                MC.mc.Add(new Case { ADR = "101", Donnee = Reg3 });
                MC.mc.Add(new Case { ADR = "102", Donnee = "0000" });
                MC.mc.Add(new Case { ADR = "103", Donnee = "0000" });
                i = "104"; string  r2 =Reg2;
                if (Reg2 == "XXXX") { r2 = "0000"; } 
                if (Valdep=="XXXX") { Valdep = "0000"; }

                int adr = Convert.ToInt32(Reg3, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32(i, 16); 
               for (int j = 0;j < adr; j++) 
                {
                    MC.mc.Add(new Case { ADR = i, Donnee = "0000" });
                    int entier = Convert.ToInt32(i, 16) + 1;
                    i = entier.ToString("X3");
                }
                MC.mc.Add(new Case { ADR = i, Donnee = ccm });

            }

            if ( ((Format == "Reg16/mem16") && (RegM == " Memoire ")) && (memonique == "MUL"))
            {

                MC.mc.Add(new Case { ADR = "100", Donnee = "0005" });
                MC.mc.Add(new Case { ADR = "101", Donnee = Reg1 });
                MC.mc.Add(new Case { ADR = "102", Donnee = "0000" });
                MC.mc.Add(new Case { ADR = "103", Donnee = "0000" });
                i = "104"; string r2 = Reg2;
                if (Reg2 == "XXXX") { r2 = "0000"; }
                if (Valdep == "XXXX") { Valdep = "0000"; }

                int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32(i, 16);
                for (int j = 0; j < adr; j++)
                {
                    MC.mc.Add(new Case { ADR = i, Donnee = "0000" });
                    int entier = Convert.ToInt32(i, 16) + 1;
                    i = entier.ToString("X3");
                }
                MC.mc.Add(new Case { ADR = i, Donnee = ccm });

            }


            if (((Format == "Reg16/mem16") && (RegM == " Memoire ")) && (memonique != "MUL") || ((Format== "Reg16/Mem16,CX") && (RegM == " Memoire ")))
            {

                MC.mc.Add(new Case { ADR = "100", Donnee = "0005" });
                MC.mc.Add(new Case { ADR = "101", Donnee = Reg1 });
                MC.mc.Add(new Case { ADR = "102", Donnee = "0000" });
                MC.mc.Add(new Case { ADR = "103", Donnee = "0000" });
                i = "104"; string r2=Reg2;
                if (Reg2 == "XXXX") { r2 = "0000"; }
                if (Valdep == "XXXX") { Valdep = "0000"; }

                int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32(i, 16);
                for (int j = 0; j < adr; j++)
                {
                    MC.mc.Add(new Case { ADR = i, Donnee = "0000" });
                    int entier = Convert.ToInt32(i, 16) + 1;
                    i = entier.ToString("X3");
                }
                MC.mc.Add(new Case { ADR = i, Donnee = ccm });

            }

            if ((Format == "Reg16,Reg16/mem16") && (RegM == " Memoire "))
            {
                MC.mc.Add(new Case { ADR = "100", Donnee = "0005" });
                MC.mc.Add(new Case { ADR = "101", Donnee = Reg3 });
                MC.mc.Add(new Case { ADR = "102", Donnee = "0000" });
                MC.mc.Add(new Case { ADR = "103", Donnee = "0000" });
                i = "104"; string r2 = Reg2;
                if (Reg2 == "XXXX") { r2 = "0000"; }
                if (Valdep == "XXXX") { Valdep = "0000"; }

                int adr = Convert.ToInt32(Reg3, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32(i, 16);
                for (int j = 0; j < adr; j++)
                {
                    MC.mc.Add(new Case { ADR = i, Donnee = "0000" });
                    int entier = Convert.ToInt32(i, 16) + 1;
                    i = entier.ToString("X3");
                }
                MC.mc.Add(new Case { ADR = i, Donnee = ccm });

            }

            if ((Format == "Reg16/Mem16,imm16") && (RegM == " Memoire "))
            {
                MC.mc.Add(new Case { ADR = "100", Donnee = "0005" });
                MC.mc.Add(new Case { ADR = "101", Donnee = Reg3 });
                MC.mc.Add(new Case { ADR = "102", Donnee = "0000" });
                MC.mc.Add(new Case { ADR = "103", Donnee = "0000" });
                i = "104";
                string r2 = Reg2;
                if (Reg2 == "XXXX") { r2 = "0000"; }
                if (Valdep == "XXXX") { Valdep = "0000"; }
                int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32(i, 16);
                for (int j = 0; j < adr; j++)
                {
                    MC.mc.Add(new Case { ADR = i, Donnee = "0000" });
                    int entier = Convert.ToInt32(i, 16) + 1;
                    i = entier.ToString("X3");
                }
                MC.mc.Add(new Case { ADR = i, Donnee = ccm });
            }


            CO.Text = "100";
            

            dataGrid1.ItemsSource = MC.mc;
            // dataGrid1.SelectedIndex = 1;
            textBox1.Text = "1";
            //this.dataGrid1.SelectAll(); 
            this.Loaded += MainWindow_Loaded;



            int delay = 0;
            JeuxInstruction.executer_simulation_phase_a_phase(memonique, Format, mem_b, destinaitr, ifdep, Valdep, ccm, source, Reg1, Reg3, Reg2, listeImages);
            if (btnclick == true) { delay = 10000; }

            // Créer un thread pour afficher le deuxième texte après 15 secondes
            Thread thread2 = new Thread(() =>
            {
                Thread.Sleep(2*delay+1000);
                Dispatcher.Invoke(() =>
                {
                    REG1.Text = Reg1;
                    Box1Name.Text = NomReg1.Substring(0, 2);
                    REG2.Text = Reg2;
                    Box2Name.Text = NomReg2.Substring(0, 2);
                    if (Reg1 == "XXXX")
                    {
                        REG1.Visibility = Visibility.Collapsed;
                        Box1Name.Visibility = Visibility.Collapsed;
                        Rec1.Visibility = Visibility.Collapsed;
                    }
                    if (Reg2 == "XXXX")
                    {
                        REG2.Visibility = Visibility.Collapsed;
                        Box2Name.Visibility = Visibility.Collapsed;
                        Rec2.Visibility = Visibility.Collapsed;
                    }
                    if (Reg3 == "XXXX")
                    {
                        REG3.Visibility = Visibility.Collapsed;
                        Box3Name.Visibility = Visibility.Collapsed;
                        Rec3.Visibility = Visibility.Collapsed;
                    }
                    REG3.Text = Reg3;
                    Box3Name.Text = NomReg3.Substring(0, 2);

                    CO.Text = "100h";

                });
            });
            thread2.Start();


            if (Format == "AX,DX")
            {
                Thread thread1 = new Thread(() =>
                {

                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread1.Start();

                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(TimeSpan.FromSeconds(11));
                    Dispatcher.Invoke(() =>
                    {
                        UAL1.Text = Reg1;
                        UAL2.Text = "";
                    });

                });
                thread3.Start();
                Thread thread4 = new Thread(() =>
                {
                    Thread.Sleep(TimeSpan.FromSeconds(19));
                    Dispatcher.Invoke(() =>
                    {
                        Box2Name.Text = "AX";
                        REG2.Text = Reg1;
                        Box2Name.Visibility = Visibility.Visible;
                        REG2.Visibility = Visibility.Visible;

                    });

                });
                thread4.Start();
            }

            if ((Format == "Reg16/Mem16,imm16") && (RegM == " Memoire "))
            {
                Thread thread1 = new Thread(() =>
                {

                    Thread.Sleep(TimeSpan.FromSeconds(2*delay+2000));
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread1.Start();
                Thread thread7 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay + 4000);
                    Dispatcher.Invoke(() =>
                    {
                        RI.Text = RIM.Text;

                    });

                });
                thread7.Start();

                Thread thread6 = new Thread(() =>
                {
                    int resl;
                    Thread.Sleep(4*delay+8000);
                    Dispatcher.Invoke(() =>
                    {

                        if (Reg2 == "XXXX") { resl = Convert.ToInt32(Reg1, 16); }
                        else { resl = Convert.ToInt32(Reg2, 16) + Convert.ToInt32(Reg1, 16); }
                        if (ifdep == false) { RAM.Text = resl.ToString("X3"); }
                        else { RAM.Text = (resl + Convert.ToInt32(Valdep, 16)).ToString("X3"); }
                        string r2 = Reg2;
                        if (Reg2 == "XXXX") { r2 = "0000"; }
                        if (Valdep == "XXXX") { Valdep = "0000"; }
                        int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;

                        SelectRowByIndexes(dataGrid1, adr, adr);

                    });

                });
                thread6.Start();
                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4*delay+10000);
                    Dispatcher.Invoke(() =>
                    {
                        if (RegM == " Memoire ") { UAL2.Text = ccm; }
                        else { UAL2.Text = Reg3; }
                        CO.Text = "101";
                    });

                });
                thread3.Start();

               
                Thread thread4 = new Thread(() =>
                {
                    Thread.Sleep(4 * delay + 12000);
                    Dispatcher.Invoke(() =>
                    {
                        RAM.Text = CO.Text;
                        textBox1.Text = "2";
                        int num = int.Parse(textBox1.Text);
                        SelectRowByIndexes(dataGrid1, num, num);

                    });

                });
                thread4.Start();
                Thread thread8 = new Thread(() =>
                {
                   
                    Thread.Sleep(5 * delay + 14000);
                    Dispatcher.Invoke(() =>
                    {
                        int resl;
                        UAL1.Text = RIM.Text;
                        if (Reg2 == "XXXX") { resl = Convert.ToInt32(Reg3, 16); }
                        else { resl = Convert.ToInt32(Reg2, 16) + Convert.ToInt32(Reg3, 16); }
                        if (ifdep == false) { RAM.Text = resl.ToString("X3"); }
                        else { RAM.Text = (resl + Convert.ToInt32(Valdep, 16)).ToString("X3"); }
                        string r2 = Reg2;
                        if (Reg2 == "XXXX") { r2 = "0000"; }
                        if (Valdep == "XXXX") { Valdep = "0000"; }
                        int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;

                        SelectRowByIndexes(dataGrid1, adr, adr);
                    });

                });
                thread8.Start();
                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(5 * delay + 17000);
                    Dispatcher.Invoke(() =>
                    {
                        Case data = (Case)dataGrid1.SelectedItem;
                        // Modifier l'objet de données
                        data.Donnee = JeuxInstruction.GetInt(); ;
                        if (memonique=="MOV") { data.Donnee = REG3.Text; }
                        dataGrid1.ItemsSource = MC.mc;
                        dataGrid1.Items.Refresh();
                        string r2 = Reg2;
                        if (Reg2 == "XXXX") { r2 = "0000"; }
                        if (Valdep == "XXXX") { Valdep = "0000"; }
                        int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;
                        SelectRowByIndexes(dataGrid1, adr, adr);

                    });

                });
                thread5.Start();
                btnclick = false;
            }


            if ((Format == "AX,imd16") || (Format == "Reg16,imm16") || ((Format == "Reg16/Mem16,imm16") && (RegM == " Registre ")))
            {
                Thread thread1 = new Thread(() =>
                {

                    Thread.Sleep(2*delay+2000);
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread1.Start();

                Thread thread4 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay +4000);
                    Dispatcher.Invoke(() =>
                    {

                        RI.Text = RIM.Text;
                    
                         
                       
                    });

                });
                thread4.Start();
                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4*delay+6000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL1.Text = REG1.Text;
                        CO.Text = "101";
                        textBox1.Text = "2";
                       
                    });

                });
                thread3.Start();
                Thread thread7 = new Thread(() =>
                {
                    Thread.Sleep(4*delay+8000);
                    Dispatcher.Invoke(() =>
                    {
                        //CO.Text=Co.getco();
                        int num = int.Parse(textBox1.Text);
                        SelectRowByIndexes(dataGrid1, num, num);
                        Co.setco(CO.Text);
                        RAM.Text = CO.Text;
                        MC.setRim(RIM.Text);
                    });

                });
                thread7.Start();
                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(4*delay+10000);
                    Dispatcher.Invoke(() =>
                    {

                        UAL2.Text = RIM.Text;
                    });

                });
                thread5.Start();
                Thread thread6 = new Thread(() =>
                {
                    Thread.Sleep(5*delay+14000);
                    Dispatcher.Invoke(() =>
                    {
                        if ((Format == "Reg16/Mem16,imm16"))
                        { source = destinaitr; }
                        string r = JeuxInstruction.GetInt();
                        if (source == Box3Name.Text) { REG3.Text = r; }
                        if (source == Box2Name.Text) { REG2.Text = r; }
                        if (source == Box1Name.Text) { REG1.Text = r; }
                        if (Format == "AX,imd16") { REG1.Text = Registre.getAx(); }
                        if (memonique == "MOV") { REG1.Text = REG3.Text; }
                        
                    });

                });
                thread6.Start();
            
            }

            if ((Format == "Reg16,Reg16/mem16") && (RegM == " Memoire ") || (Format == "Reg16/mem16,Reg16") && (RegM == " Memoire "))
            {
                Thread thread11 = new Thread(() =>
                {

                    Thread.Sleep(2*delay+2000);
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread11.Start();

                Thread thread12 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay + 4000);
                    Dispatcher.Invoke(() =>
                    {

                        RI.Text = RIM.Text;



                    });

                });
                thread12.Start();
                Thread thread1 = new Thread(() =>
                {
                    int resl;
                    Thread.Sleep(4*delay+8000);
                    Dispatcher.Invoke(() =>
                    {

                        if (Reg2 == "XXXX") { resl = Convert.ToInt32(Reg3, 16); }
                        else { resl = Convert.ToInt32(Reg2, 16) + Convert.ToInt32(Reg3, 16); }
                        if (ifdep == false) { RAM.Text = resl.ToString("X3"); }
                        else { RAM.Text = (resl + Convert.ToInt32(Valdep, 16)).ToString("X3"); }
                        string r2 = Reg1;
                        if (Reg2 == "XXXX") { r2 = "0000"; }
                        if (Valdep == "XXXX") { Valdep = "0000"; }
                        //if (memonique == "XCHG") { Reg3 = Reg2; }
                        int adr = Convert.ToInt32(Reg3, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;

                        SelectRowByIndexes(dataGrid1, adr, adr);

                    });

                });
                thread1.Start();
                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4*delay+10000);
                    Dispatcher.Invoke(() =>
                    {
                        if (RegM == " Memoire ") { UAL2.Text = ccm; }
                        else { UAL2.Text = Reg3; }

                    });

                });
                thread3.Start();
                Thread thread4 = new Thread(() =>
                {
                    Thread.Sleep(4 * delay + 12000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL1.Text = Reg1;


                    });

                });
                thread4.Start();
                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(4 * delay + 15000);
                    Dispatcher.Invoke(() =>
                    {
                        string r = JeuxInstruction.GetInt();
                        if (Format == "Reg16/mem16,Reg16")
                        {

                            if (memonique == "XCHG") { r = UAL1.Text; }
                            else { RIM.Text = r; }
                            Case data = (Case)dataGrid1.SelectedItem;
                            // Modifier l'objet de données
                            data.Donnee = r;
                            dataGrid1.ItemsSource = MC.mc;
                            dataGrid1.Items.Refresh();
                            string r2 = Reg2;
                            if (Reg2 == "XXXX") { r2 = "0000"; }
                            if (Valdep == "XXXX") { Valdep = "0000"; }
                            if (memonique == "XCHG") { REG1.Text = UAL2.Text; }
                            int adr = Convert.ToInt32(Reg3, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;
                            SelectRowByIndexes(dataGrid1, adr, adr);
                        }
                        else
                        {
                            if (memonique == "XCHG")
                            {
                                r = UAL1.Text;
                                Case data = (Case)dataGrid1.SelectedItem;
                                // Modifier l'objet de données
                                data.Donnee = r;
                                dataGrid1.ItemsSource = MC.mc;
                                dataGrid1.Items.Refresh();
                                string r2 = Reg2;
                                if (Reg2 == "XXXX") { r2 = "0000"; }
                                if (Valdep == "XXXX") { Valdep = "0000"; }
                                REG1.Text = UAL2.Text;
                                int adr = Convert.ToInt32(Reg3, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;
                                SelectRowByIndexes(dataGrid1, adr, adr);
                            }
                            else
                            {
                                if (destinaitr == Box3Name.Text) { REG3.Text = r; }
                                if (destinaitr == Box2Name.Text) { REG2.Text = r; }
                                if (destinaitr == Box1Name.Text) { REG1.Text = r; }
                            }

                        }


                    });

                });
                thread5.Start();

            }


            if ((Format == "Reg16/Mem16,CX") && (RegM == " Memoire "))
            {
                Thread thread11 = new Thread(() =>
                {

                    Thread.Sleep(2*delay+2000);
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread11.Start();
                Thread thread12 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay + 4000);
                    Dispatcher.Invoke(() =>
                    {

                        RI.Text = RIM.Text;



                    });

                });
                thread12.Start();
                Thread thread1 = new Thread(() =>
                {
                    int resl;
                    Thread.Sleep(4*delay+8000);
                    Dispatcher.Invoke(() =>
                    {

                        if (Reg2 == "XXXX") { resl = Convert.ToInt32(Reg1, 16); }
                        else { resl = Convert.ToInt32(Reg2, 16) + Convert.ToInt32(Reg1, 16); }
                        if (ifdep == false) { RAM.Text = resl.ToString("X3"); }
                        else { RAM.Text = (resl + Convert.ToInt32(Valdep, 16)).ToString("X3"); }
                        string r2 = Reg1;
                        if (Reg2 == "XXXX") { r2 = "0000"; }
                        if (Valdep == "XXXX") { Valdep = "0000"; }
                        //if (memonique == "XCHG") { Reg3 = Reg2; }
                        int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;

                        SelectRowByIndexes(dataGrid1, adr, adr);

                    });

                });
                thread1.Start();
                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4*delay+10000);
                    Dispatcher.Invoke(() =>
                    {
                        if (RegM == " Memoire ") { UAL2.Text = ccm; }
                        else { UAL2.Text = Reg3; }

                    });

                });
                thread3.Start();
                Thread thread4 = new Thread(() =>
                {
                    Thread.Sleep(4*delay+12000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL1.Text = Reg3;


                    });

                });
                thread4.Start();
                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(5*delay+15000);
                    Dispatcher.Invoke(() =>
                    {
                        string r = JeuxInstruction.GetInt();
                        if (Format == "Reg16/Mem16,CX")
                        {

                            if (memonique == "XCHG") { r = UAL1.Text; }
                            else { RIM.Text = r; }
                            Case data = (Case)dataGrid1.SelectedItem;
                            // Modifier l'objet de données
                            data.Donnee = r;
                            dataGrid1.ItemsSource = MC.mc;
                            dataGrid1.Items.Refresh();
                            string r2 = Reg2;
                            if (Reg2 == "XXXX") { r2 = "0000"; }
                            if (Valdep == "XXXX") { Valdep = "0000"; }
                            if (memonique == "XCHG") { REG1.Text = UAL2.Text; }
                            int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;
                            SelectRowByIndexes(dataGrid1, adr, adr);
                        }


                    });

                });
                thread5.Start();
            }



            if ((Format == "Reg16,Reg16/mem16") && (RegM == " Registre ") || ((Format == "Reg16/mem16,Reg16") && (RegM == " Registre ")) || (Format == "AX,Reg16") || ((Format == "Reg16/Mem16,CX") && (RegM == " Registre ")) || (Format == "AX,DX"))
            {

                Thread thread1 = new Thread(() =>
                {

                    Thread.Sleep(2*delay+2000);
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread1.Start();

                Thread thread12 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay + 4000);
                    Dispatcher.Invoke(() =>
                    {

                        RI.Text = RIM.Text;



                    });

                });
                thread12.Start();

                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4*delay+6000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL2.Text = Reg3;

                    });

                });
                thread3.Start();
                Thread thread4 = new Thread(() =>
                {
                    Thread.Sleep(4 * delay + 8000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL1.Text = Reg1;


                    });

                });
                thread4.Start();
                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(5 * delay + 10000);
                    Dispatcher.Invoke(() =>
                    {
                        if ((memonique == "XCHG") && (RegM == " Registre "))
                        {
                            REG1.Text = UAL2.Text;
                            REG3.Text = UAL1.Text;
                        }

                        else
                        {
                            string r = JeuxInstruction.GetInt();
                            if (destinaitr == Box3Name.Text) { REG3.Text = r; }
                            if (destinaitr == Box2Name.Text) { REG2.Text = r; }
                            if (destinaitr == Box1Name.Text) { REG1.Text = r; }
                            if (Format == "AX,Reg16")
                            {
                                if (source == Box3Name.Text) { REG3.Text = r; }
                                if (source == Box2Name.Text) { REG2.Text = r; }
                                if (source == Box1Name.Text) { REG1.Text = r; }
                                REG1.Text = Registre.getAx();
                            }
                        }



                    });

                });
                thread5.Start();
            }

            if ((Format == "Reg16") || ((Format == "Reg16/mem16") && (RegM == " Registre ")))
            {
                Thread thread11 = new Thread(() =>
                {

                    Thread.Sleep(2*delay+2000);
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread11.Start();
                Thread thread12 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay + 4000);
                    Dispatcher.Invoke(() =>
                    {

                        RI.Text = RIM.Text;



                    });

                });
                thread12.Start();
                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4*delay+6000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL2.Text = Reg1;
                        if (memonique == "INC") UAL1.Text = "0001";
                        if (memonique == "DEC") UAL1.Text = "FFFF";
                    });

                });
                thread3.Start();


                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(5*delay+10000);
                    Dispatcher.Invoke(() =>
                    {
                        string r = JeuxInstruction.GetInt();
                        REG1.Text = r;

                    });

                });
                thread5.Start();
            }


            if ((Format == "Reg16/mem16") && (RegM == " Memoire ") && (memonique != "MUL"))
            {
                Thread thread11 = new Thread(() =>
                {

                    Thread.Sleep(2*delay+2000);
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread11.Start();
                Thread thread12 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay + 4000);
                    Dispatcher.Invoke(() =>
                    {

                        RI.Text = RIM.Text;
                    });

                });
                thread12.Start();
               
                Thread thread1 = new Thread(() =>
                {
                    int resl;
                    Thread.Sleep(4*delay+8000);
                    Dispatcher.Invoke(() =>
                    {

                        if (Reg2 == "XXXX") { resl = Convert.ToInt32(Reg1, 16); }
                        else { resl = Convert.ToInt32(Reg2, 16) + Convert.ToInt32(Reg1, 16); }
                        if (ifdep == false) { RAM.Text = resl.ToString("X3"); }
                        else { RAM.Text = (resl + Convert.ToInt32(Valdep, 16)).ToString("X3"); }
                        i = "104"; string r2 = Reg2;
                        if (Reg2 == "XXXX") { r2 = "0000"; }
                        if (Valdep == "XXXX") { Valdep = "0000"; }

                        int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;
                        SelectRowByIndexes(dataGrid1, adr, adr);

                    });

                });
                thread1.Start();
                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4*delay+10000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL2.Text = ccm;

                    });

                });
                thread3.Start();
                Thread thread4 = new Thread(() =>
                {
                    Thread.Sleep(4*delay+12000);
                    Dispatcher.Invoke(() =>
                    {
                        if (memonique == "INC") UAL1.Text = "0001";
                        if (memonique == "DEC") UAL1.Text = "FFFF";
                        if (memonique == "MUL") UAL1.Text = Registre.getBx();

                    });

                });
                thread4.Start();
                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(5*delay+17000);
                    Dispatcher.Invoke(() =>
                    {
                        if (memonique == "MUL")
                        {
                            Box1Name.Text = "AX"; REG1.Text = Registre.getAx();
                            Box2Name.Text = "DX"; REG2.Text = Registre.getDx();

                        }
                        else
                        {
                            Case data = (Case)dataGrid1.SelectedItem;
                            // Modifier l'objet de données
                            data.Donnee = JeuxInstruction.GetInt(); ;
                            dataGrid1.ItemsSource = MC.mc;
                            dataGrid1.Items.Refresh();
                            i = "104"; string r2 = Reg2;
                            if (Reg2 == "XXXX") { r2 = "0000"; }
                            if (Valdep == "XXXX") { Valdep = "0000"; }

                            int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;
                            SelectRowByIndexes(dataGrid1, adr, adr);

                        }

                    });

                });
                thread5.Start();
            }



            if ((Format == "Reg16/mem16") && (RegM == " Memoire ") && (memonique == "MUL"))
            {
                Thread thread11 = new Thread(() =>
                {

                    Thread.Sleep(2*delay+2000);
                    Dispatcher.Invoke(() =>
                    {

                        RAM.Text = CO.Text;

                    });

                });
                thread11.Start();
                Thread thread12 = new Thread(() =>
                {

                    Thread.Sleep(2 * delay + 4000);
                    Dispatcher.Invoke(() =>
                    {

                        RI.Text = RIM.Text;
                    });

                });
                thread12.Start();
                Thread thread1 = new Thread(() =>
                {
                    int resl;
                    Thread.Sleep(4 * delay +8000);
                    Dispatcher.Invoke(() =>
                    {

                        if (Reg2 == "XXXX") { resl = Convert.ToInt32(Reg1, 16); }
                        else { resl = Convert.ToInt32(Reg2, 16) + Convert.ToInt32(Reg1, 16); }
                        if (ifdep == false) { RAM.Text = resl.ToString("X3"); }
                        else { RAM.Text = (resl + Convert.ToInt32(Valdep, 16)).ToString("X3"); }
                        string r2 = Reg2;
                        if (Reg2 == "XXXX") { r2 = "0000"; }
                        if (Valdep == "XXXX") { Valdep = "0000"; }

                        int adr = Convert.ToInt32(Reg1, 16) + Convert.ToInt32(Valdep, 16) + Convert.ToInt32(r2, 16) - Convert.ToInt32("100", 16) + 1;
                        SelectRowByIndexes(dataGrid1, adr, adr);

                    });

                });
                thread1.Start();
                Thread thread3 = new Thread(() =>
                {

                    Thread.Sleep(4 * delay +10000);
                    Dispatcher.Invoke(() =>
                    {
                        UAL2.Text = ccm;

                    });

                });
                thread3.Start();
                Thread thread4 = new Thread(() =>
                {
                    Thread.Sleep(4 * delay +12000);
                    Dispatcher.Invoke(() =>
                    {
                        if (memonique == "INC") UAL1.Text = "0001";
                        if (memonique == "DEC") UAL1.Text = "FFFF";
                        if (memonique == "MUL") UAL1.Text = Registre.getBx();

                    });

                });
                thread4.Start();
                Thread thread5 = new Thread(() =>
                {
                    Thread.Sleep(5 * delay +17000);
                    Dispatcher.Invoke(() =>
                    {
                        if (memonique == "MUL")
                        {
                            Box1Name.Text = "AX"; REG1.Text = Registre.getAx();
                            Box2Name.Text = "DX"; REG2.Text = Registre.getDx();
                            Box2Name.Visibility = Visibility.Visible;
                            REG2.Visibility = Visibility.Visible;
                            Rec2.Visibility = Visibility.Visible;
                            REG3.Visibility = Visibility.Collapsed;
                            Box3Name.Visibility = Visibility.Collapsed;
                            Rec3.Visibility = Visibility.Collapsed;
                        }

                    });

                });
                thread5.Start();
            }

        }


       


        public static async void AnimateImage3(Image image, Image image1, Image image2, double finalX, double finalY, double finalX1, double finalY1, double finalX2, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            yAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            // Start the storyboard
            DoubleAnimation xAnimation1 = new DoubleAnimation(Canvas.GetLeft(image1), finalX1, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image1), finalY1, TimeSpan.FromSeconds(durationInSeconds));
            Storyboard.SetTargetProperty(xAnimation1, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTarget(xAnimation1, image1);
            Storyboard.SetTarget(yAnimation1, image1);

            storyboard.Children.Add(xAnimation1);
            storyboard.Children.Add(yAnimation1);

            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation x1Animation = new DoubleAnimation(Canvas.GetLeft(image2), finalX2, TimeSpan.FromSeconds(durationInSeconds / 2));
            Storyboard.SetTargetProperty(x1Animation, new PropertyPath(Canvas.LeftProperty));


            // Set the target object for the animations
            Storyboard.SetTarget(x1Animation, image2);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(x1Animation);
            xAnimation1.BeginTime = TimeSpan.FromSeconds(2 * durationInSeconds);
            yAnimation1.BeginTime = TimeSpan.FromSeconds(3 * durationInSeconds);

            x1Animation.BeginTime = TimeSpan.FromSeconds(4 * durationInSeconds);

            storyboard.Begin();

            await Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds));
            image.Visibility = Visibility.Collapsed;
            image1.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(4 * durationInSeconds));
            image1.Visibility = Visibility.Collapsed;
            image2.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(4.1 * durationInSeconds));
            image2.Visibility = Visibility.Collapsed;

        }

        public static async void AnimateImage(Image image, Image image1, double finalX, double finalY, double finalY1, double finalX2, double finalY2, double finalY3, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;

            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image1), finalY1, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation xAnimation2 = new DoubleAnimation(Canvas.GetLeft(image), finalX2, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation2 = new DoubleAnimation(Canvas.GetTop(image), finalY2, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation3 = new DoubleAnimation(Canvas.GetTop(image1), finalY3, TimeSpan.FromSeconds(durationInSeconds));
            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTargetProperty(xAnimation2, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation2, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTargetProperty(yAnimation3, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);
            Storyboard.SetTarget(yAnimation1, image1);
            Storyboard.SetTarget(xAnimation2, image);
            Storyboard.SetTarget(yAnimation2, image);
            Storyboard.SetTarget(yAnimation3, image1);
            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);
            storyboard.Children.Add(xAnimation2);
            storyboard.Children.Add(yAnimation1);
            storyboard.Children.Add(yAnimation2);
            storyboard.Children.Add(yAnimation3);

            // Create a new storyboard and add the animations to it
            xAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            yAnimation1.BeginTime = TimeSpan.FromSeconds(2 * durationInSeconds);
            yAnimation3.BeginTime = TimeSpan.FromSeconds(3 * durationInSeconds);
            xAnimation2.BeginTime = TimeSpan.FromSeconds(4 * durationInSeconds);
            yAnimation2.BeginTime = TimeSpan.FromSeconds(5 * durationInSeconds);

            storyboard.Begin();

            await Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds));
            image.Visibility = Visibility.Collapsed;
            image1.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(3 * durationInSeconds));
            image1.Visibility = Visibility.Collapsed;

        }

        public static async void AnimateImage4(Image image, Image image1, double finalX, double finalY, double finalX1, double finalY1, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            xAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            // Start the storyboard
            DoubleAnimation xAnimation1 = new DoubleAnimation(Canvas.GetLeft(image1), finalX1, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image1), finalY1, TimeSpan.FromSeconds(durationInSeconds));
            Storyboard.SetTargetProperty(xAnimation1, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTarget(xAnimation1, image1);
            Storyboard.SetTarget(yAnimation1, image1);

            storyboard.Children.Add(xAnimation1);
            storyboard.Children.Add(yAnimation1);

            yAnimation1.BeginTime = TimeSpan.FromSeconds(2 * durationInSeconds);
            xAnimation1.BeginTime = TimeSpan.FromSeconds(3 * durationInSeconds);

            storyboard.Begin();

            await Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds));
            image.Visibility = Visibility.Collapsed;
            image1.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(4 * durationInSeconds));
            image1.Visibility = Visibility.Collapsed;
        }


        public static async void AnimateImage(Image image, Image image1, double finalX, double finalY, double finalY1, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds ));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            xAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds );
            // Start the storyboard

            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image1), finalY1, TimeSpan.FromSeconds(durationInSeconds));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTarget(yAnimation1, image1);


            storyboard.Children.Add(yAnimation1);

            yAnimation1.BeginTime = TimeSpan.FromSeconds(2 * durationInSeconds);
            storyboard.Begin();

            await Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds));
            image.Visibility = Visibility.Collapsed;
            image1.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(2* durationInSeconds));
            image1.Visibility = Visibility.Collapsed;

        }

        public static async void AnimateImage2(Image image, Image image1, double finalX, double finalY, double finalX1, double finalY1, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            yAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            // Start the storyboard
            DoubleAnimation xAnimation1 = new DoubleAnimation(Canvas.GetLeft(image1), finalX1, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image1), finalY1, TimeSpan.FromSeconds(durationInSeconds));
            Storyboard.SetTargetProperty(xAnimation1, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTarget(xAnimation1, image1);
            Storyboard.SetTarget(yAnimation1, image1);

            storyboard.Children.Add(xAnimation1);
            storyboard.Children.Add(yAnimation1);

            xAnimation1.BeginTime = TimeSpan.FromSeconds(2 * durationInSeconds);
            yAnimation1.BeginTime = TimeSpan.FromSeconds(3 * durationInSeconds);
            storyboard.Begin();

            await Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds));
            image.Visibility = Visibility.Collapsed;
            image1.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(4 * durationInSeconds));
            image1.Visibility = Visibility.Collapsed;
        }

        public static async void AnimateImage1(Image image, double finalX, double finalY, double finalX1, double finalY1, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            xAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            // Start the storyboard


            await Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds));
            //image.Visibility = Visibility.Collapsed;
            DoubleAnimation xAnimation1 = new DoubleAnimation(Canvas.GetLeft(image), finalX1, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image), finalY1, TimeSpan.FromSeconds(durationInSeconds));
            Storyboard.SetTargetProperty(xAnimation1, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTarget(xAnimation1, image);
            Storyboard.SetTarget(yAnimation1, image);
            storyboard.Children.Add(xAnimation1);
            storyboard.Children.Add(yAnimation1);
            xAnimation1.BeginTime = TimeSpan.FromSeconds(3 * durationInSeconds);
            yAnimation1.BeginTime = TimeSpan.FromSeconds(4 * durationInSeconds);
            // Start the storyboard

            storyboard.Begin();
        }

        public static async void AnimateImage1(Image image, double finalX, double finalY, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            xAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            // Start the storyboard

            storyboard.Begin();
            await Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds));
            image.Visibility = Visibility.Collapsed;



        }

       

        private void AnimateButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Vector3DAnimation and set its properties
            Vector3DAnimation animation = new Vector3DAnimation();
            animation.From = new Vector3D(0, 0, 0);
            animation.To = new Vector3D(100, 100, 0);
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.RepeatBehavior = RepeatBehavior.Forever;

        }

        private void Button_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static bool btnclick = false;

        private void Button_Etape_Click(object sender, RoutedEventArgs e)
        {
            btnclick= true;
            Page p = Animation.getcontext();
            Button btn = (Button)p.FindName("Button_simuler");
            ButtonAutomationPeer peer = new ButtonAutomationPeer(btn);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
            this.Close();
        }
                
        private void Button_commencer_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Commencer");
            btnclick = false;
            Page p = Animation.getcontext();
            Button btn = (Button)p.FindName("Button_simuler");
            ButtonAutomationPeer peer = new ButtonAutomationPeer(btn);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
            this.Close();

        }

      
        
        
        
        
        
        
        
        
        private void Button_recommencer_Click(object sender, RoutedEventArgs e)
        {
            btnclick = false;
            Page p = Animation.getcontext();
            Button btn = (Button)p.FindName("Button_simuler");
            ButtonAutomationPeer peer = new ButtonAutomationPeer(btn);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
            this.Close();
        }

        private void RowDefinition_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            // Get the new DPI value
            double newDpi = e.NewDpi.DpiScaleX;

            // Get the row definition that raised the event
            RowDefinition rowDef = (RowDefinition)sender;

            // Set the height of the row to a new value based on the DPI
            rowDef.Height = new GridLength(50 * newDpi, GridUnitType.Pixel);
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(textBox1.Text);
            SelectRowByIndexes(dataGrid1, num, num);

        }


        // =================================================================


        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T tChild)
                {
                    return tChild;
                }
                else
                {
                    T foundChild = FindVisualChild<T>(child);
                    if (foundChild != null)
                    {
                        return foundChild;
                    }
                }
            }
            return null;
        }

        public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }








        public static void SelectRowByIndexes(DataGrid dataGrid, params int[] rowIndexes)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

            if (!dataGrid.SelectionMode.Equals(DataGridSelectionMode.Extended))
                throw new ArgumentException("The SelectionMode of the DataGrid must be set to Extended.");

            if (rowIndexes.Length.Equals(0) || rowIndexes.Length > dataGrid.Items.Count)
                throw new ArgumentException("Invalid number of indexes.");

            dataGrid.SelectedItems.Clear();
            foreach (int rowIndex in rowIndexes)
            {
                if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

                object item = dataGrid.Items[rowIndex]; //=Product X
                dataGrid.SelectedItems.Add(item);

                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                if (row == null)
                {
                    dataGrid.ScrollIntoView(item);
                    row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                }
                if (row != null)
                {
                    DataGridCell cell = GetCell(dataGrid, row, 0);
                    if (cell != null)
                        cell.Focus();
                }
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
            {
                // Get the selected row object
                Case selectedPerson = dataGrid1.SelectedItem as Case;

                // Display the selected person's name in a TextBox
                txADR.Text = selectedPerson.ADR;
                RIM.Text = selectedPerson.Donnee;
            }
        }




        public async void CO_RAM()
        {
            AnimateImage1(myImag9e, 300, 190, 150, 100, 1);
            AnimateImage1(myImag10e, 300, 190, 150, 100, 1);
            AnimateImage1(myImag11e, 300, 190, 150, 100, 1);
            await Task.Delay(4000);
            myImag10e.Visibility = Visibility.Collapsed;
            myImag11e.Visibility = Visibility.Collapsed;
            myImag9e.Visibility = Visibility.Collapsed;
        }
        public async void RIM_RI()
        {
            // Rim to Ri
            AnimateImage(myImage, myImag0e, -710, 10, -40, -155, -100, 10, 1);
            AnimateImage(myImage1, myImag1e, -710, 10, -40, -155, -100, 10, 1);
            AnimateImage(myImage2, myImag2e, -710, 10, -40, -155, -100, 10, 1);
            await Task.Delay(3000);
            myImag0e.Visibility = Visibility.Collapsed;
            myImag1e.Visibility = Visibility.Collapsed;
            myImag2e.Visibility = Visibility.Collapsed;
            myImage.Visibility = Visibility.Collapsed;
            myImage1.Visibility = Visibility.Collapsed;
            myImage2.Visibility = Visibility.Collapsed;
        }

        public async void REG_UAL1()
        {
            AnimateImage(myImag18e, myImag3e, -900, 8, -67, -1200, -458, 10, 1);
            AnimateImage(myImag19e, myImag4e, -900, 8, -67, -1200, -458, 10, 1);
            AnimateImage(myImag20e, myImag5e, -900, 8, -67, -1200, -458, 10, 1);
            await Task.Delay(3000);
            myImag3e.Visibility = Visibility.Collapsed;
            myImag4e.Visibility = Visibility.Collapsed;
            myImag5e.Visibility = Visibility.Collapsed;
            myImag18e.Visibility = Visibility.Collapsed;
            myImag19e.Visibility = Visibility.Collapsed;
            myImag20e.Visibility = Visibility.Collapsed;
        }


        public async void UAL_REG()
        {
            AnimateImage2(myImag16e, myImag13e, -1165, -30, -1210, -465, 1);
            AnimateImage2(myImag15e, myImag12e, -1165, -30, -1210, -465, 1);
            AnimateImage2(myImag17e, myImag14e, -1165, -30, -1210, -465, 1);
            await Task.Delay(6000);
            AnimateImage1(myImag12e, -1150, 1, 1);
            AnimateImage1(myImag13e, -1150, 1, 1);
            AnimateImage1(myImag14e, -1150, 1, 1);
            AnimateImage1(myImag15e, -980, -300, 1);
            AnimateImage1(myImag16e, -980, -300, 1);
            AnimateImage1(myImag17e, -980, -300, 1);
        }

        public async void Loop_INC()   // hd la methode li tkhdm biha loop t3awd inc plusieur fois madabic matbdlch delay ou zid 3amr les registr dbr rssk
        {
            for (int i = 0; i < 4; i++)
            {
                CO_RAM();
                await Task.Delay(6000);
                RIM_RI();
                await Task.Delay(6000);
                REG_UAL1();
                await Task.Delay(8000);
                UAL_REG();
                await Task.Delay(9000);
            }
        }


    }
   
}
