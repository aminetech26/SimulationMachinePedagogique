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
    public partial class ProgrammePage
    {
        public ProgrammePage()
        {
            InitializeComponent();
        }

        //private void AddInstruction_Click(object sender, RoutedEventArgs e)
        //{
        //Instruction_Ligne newInstruction = new Instruction_Ligne();
        // Set the position of the new control relative to the previous control
        //double previousControlBottom = Canvas.GetTop(containerElement.Children[containerElement.Children.Count - 2]) + containerElement.Children[containerElement.Children.Count - 2].RenderSize.Height;
        //Canvas.SetBottom(newInstruction, previousControlBottom + 20);

        // Add the new control to the container
        //containerElement.Children.Add(newInstruction);
        // instructionList.Add(newInstruction);
        //}

        private int currentLineNumber = 1;

        private void AddInstruction_Click(object sender, RoutedEventArgs e)
        {
            currentLineNumber++;
            var instructionLigne = new Instruction_Ligne();
            Grid_Inst.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            Grid_Inst.Children.Add(instructionLigne);
            Grid.SetRow(instructionLigne, currentLineNumber - 1);
            Grid.SetColumn(instructionLigne, 1);

            var lineTextBlock = new TextBlock();
            lineTextBlock.Text = currentLineNumber.ToString();
            lineTextBlock.FontSize = 25 ;
            lineTextBlock.FontWeight = FontWeights.Bold;
            lineTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4E719D"));
            lineTextBlock.FontFamily = new FontFamily("Montserrat");
            lineTextBlock.TextAlignment = TextAlignment.Center;
            lineTextBlock.Margin = new Thickness(0, 27, 0, 27);
            lineTextBlock.Height = Double.NaN;
            lineTextBlock.Width = Double.NaN;
            leftColumnGrid.Children.Add(lineTextBlock);
            lineTextBlock.SetValue(Grid.RowProperty, currentLineNumber - 1);

            // Check if currentLineNumber is greater than 5 and set the VerticalScrollBarVisibility property of the ScrollViewer to Visible
            if (currentLineNumber > 5)
            {
                Grid_InstructionsScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }

        }


        private void Go_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
