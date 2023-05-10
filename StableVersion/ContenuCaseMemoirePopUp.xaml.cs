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
using System.Windows.Shapes;

namespace projet
{
    /// <summary>
    /// Interaction logic for ContenuCaseMemoirePopUp.xaml
    /// </summary>
    public partial class ContenuCaseMemoirePopUp : Window
    {
        public ContenuCaseMemoirePopUp()
        {
            InitializeComponent();
        }
        public void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
