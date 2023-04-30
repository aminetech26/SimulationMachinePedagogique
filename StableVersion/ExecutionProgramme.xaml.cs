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
        }

        private void Button_Go_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
