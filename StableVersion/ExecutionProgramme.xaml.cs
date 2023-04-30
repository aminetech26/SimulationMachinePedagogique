using ArchiMind;
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

namespace projet
{
    /// <summary>
    /// Logique d'interaction pour ExecutionProgramme.xaml
    /// </summary>
    public partial class ExecutionProgramme : Page
    {
        public ExecutionProgramme()
        {
            InitializeComponent();
            AX.Text = Registre.getAx() ;
            BX.Text = Registre.getBx() ;
            CX.Text = Registre.getCx() ;
            DX.Text = Registre.getDx() ;
            SI.Text = Registre.getSi() ;
            DI.Text = Registre.getDi() ;
            SP.Text = Registre.getSp() ;
            BP.Text = Registre.getBp() ;

            List<Case> _animals;

            _animals = new List<Case>();
            _animals.Add(new Case { ADR = "", Donnee = "" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8197h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "102h", Donnee = "8197h" });
            _animals.Add(new Case { ADR = "103h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "104h", Donnee = "8165h" });
            _animals.Add(new Case { ADR = "105h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "106h", Donnee = "9765h" });
            _animals.Add(new Case { ADR = "107h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "108h", Donnee = "9765h" });
            _animals.Add(new Case { ADR = "109h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "110h", Donnee = "8765h" });
            _animals.Add(new Case { ADR = "111h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "112h", Donnee = "8765h" });
            _animals.Add(new Case { ADR = "113h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8165h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8195h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8195h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            dataGrid1.ItemsSource = _animals;

        }

        private void Button_Go_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
            {
                // Get the selected row object
                Case? selectedPerson = dataGrid1.SelectedItem as Case;

                // Display the selected person's name in a TextBox
                //txADR.Text = selectedPerson.ADR;
                RIM.Text = selectedPerson.Donnee;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                if (e.NewSize.Width >= 1000)
                {
                    //dataGrid1.Width = 350 ;
                }
                else
                {
                    //dataGrid1.Width = 250;

                }

        }
    }
}
