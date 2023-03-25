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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace projet.Pages
{
    /// <summary>
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        { 
            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/CEI.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 800)
            {
                StackPanel1.Height = 100;
                StackPanel1.Height = 150 ;
                Text1.FontSize = 32 ;
                Instruction.Width = 150 ;
                Instruction.Height = 70 ;
                Format.Width = 150 ;
                Format.Height = 70 ;
                Reg.Width = 150;
                Reg.Height = 70;
                Dep.Width = 150;
                Dep.Height = 70;
                Destinataire.Width = 150;
                Destinataire.Height = 70;
                Source.Width = 150;
                Source.Height = 70;
                TextBox1.Width = 150;
                TextBox2.Width = 150;
                TextBox3.Width = 150;
                Inst_En_Hexa.Width = 275 ;
                Inst_En_Hexa.Height= 60 ;
                Inst_En_Hexa.FontSize = 25;
                Button_simuler.Height = 90;
                Button_simuler.Width = 350;
            }
            else
            {
                StackPanel1.Height = 75;
                StackPanel1.Height = 125;
                Text1.FontSize = 27 ;
                Instruction.Width = 100;
                Instruction.Height = 70;
                Format.Width = 100;
                Format.Height = 70;
                Reg.Width = 100;
                Reg.Height = 70;
                Dep.Width = 100;
                Dep.Height = 70;
                Destinataire.Width = 100;
                Destinataire.Height = 70;
                Source.Width = 100;
                Source.Height = 70;
                TextBox1.Width = 100;
                TextBox2.Width = 100;
                TextBox3.Width = 100;
                Inst_En_Hexa.Width= 200;
                Inst_En_Hexa.Height = 50;
                Inst_En_Hexa.FontSize= 22 ;
                Button_simuler.Height = 75 ;
                Button_simuler.Width = 300 ; 
            }
        }

        private void RemoveHintText(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "XXXX")
            {
                TextBox1.Text = "";
                TextBox1.Foreground = Brushes.Black;
            }
        }

        private void AddHintText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                TextBox1.Text = "XXXX";
                TextBox1.Foreground = Brushes.Gray;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null)
            {
                // Convert the new text to upper case
                string newText = textBox.Text + e.Text.ToUpper();

                // Set the Handled property to true to indicate that we've handled the input
                e.Handled = true;

                // Set the text of the TextBox to the upper case text
                textBox.Text = newText;

                // Move the caret to the end of the TextBox
                textBox.CaretIndex = textBox.Text.Length;
            }
        }

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox2.Text == "XXXX")
            {
                TextBox2.Text = "";
                TextBox2.Foreground = Brushes.Black;
            }
        }

        private void TextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                TextBox2.Text = "XXXX";
                TextBox2.Foreground = Brushes.Gray;
            }
        }
    }
}
