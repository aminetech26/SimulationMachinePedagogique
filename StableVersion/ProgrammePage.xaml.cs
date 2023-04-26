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
    /// Interaction logic for ProgrammePage.xaml
    /// </summary>
    public partial class ProgrammePage : Page
    {
        public ProgrammePage()
        {
            InitializeComponent();
        }
        private void AddInstruction_Click(object sender, RoutedEventArgs e)
        {
            Instruction_Ligne newInstruction = new Instruction_Ligne();
            // Set the position of the new control relative to the previous control
            double previousControlBottom = Canvas.GetTop(containerElement.Children[containerElement.Children.Count - 2]) + containerElement.Children[containerElement.Children.Count - 2].RenderSize.Height;
            Canvas.SetBottom(newInstruction, previousControlBottom + 20);

            // Add the new control to the container
            containerElement.Children.Add(newInstruction);
           // instructionList.Add(newInstruction);
        }
    }
}
