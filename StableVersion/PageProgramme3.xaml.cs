using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Page = System.Windows.Controls.Page;
using TextBox = System.Windows.Controls.TextBox;
using ArchiMind;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace projet
{
    /// <summary>
    /// Interaction logic for PageProgramme3.xaml
    /// </summary>
    public partial class PageProgramme3
    {
        private List<Instruction> programInst;

        public PageProgramme3(List<Instruction> programInstructions)
        {
            InitializeComponent();
            suivant.IsEnabled= false;
            AX.Focus();
            programInst = new List<Instruction>(programInstructions);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var tb in FindVisualChildren<TextBox>(this))
            {
                tb.TextChanged += TextBox_TextChanged;
            }
        }

        private IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            foreach (var control in Reg_Grid.Children)
            {
                if (control is System.Windows.Controls.TextBox textBox && textBox != sender)
                {
                    textBox.IsEnabled = false;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach (var control in Reg_Grid.Children)
            {
                if (control is TextBox textBox && textBox != sender)
                {
                    textBox.IsEnabled = true;
                }
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool allValid = true;

            foreach (var tb in FindVisualChildren<TextBox>(this))
            {
                string input = tb.Text.Trim();
                TextBox? textBox = sender as TextBox;
                textBox.CaretIndex = textBox.Text.Length;
                if (!Regex.IsMatch(input, @"^[0-9A-Fa-f]{4}$"))
                {
                    tb.ToolTip = "Entrer 4 caracteres en hexa";
                    tb.Background = Brushes.Red;
                    allValid = false;
                }
                else
                {
                    tb.ToolTip = null;
                    tb.Background = Brushes.White;
                }
            }

            suivant.IsEnabled = allValid;
        }

        private void suivant_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello i'm clicked");
            Registre.setAx(AX.Text);
            Registre.setBx(BX.Text);
            Registre.setCx(CX.Text);
            Registre.setDx(DX.Text);
            Registre.setDi(DI.Text);
            Registre.setSi(SI.Text);
            Registre.setSp(SP.Text);
            Registre.setBp(BP.Text);
            //test
            MessageBox.Show("AX:"+Registre.getAx()+"BP:"+Registre.getBp());
            //navigate to execution page.
            ExecutionProgramme thirdPage = new ExecutionProgramme(programInst);
            this.NavigationService.Navigate(thirdPage);
         //   NavigationService.Navigate(new Uri("/ExecutionProgramme.xaml", UriKind.Relative));
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void containerGridElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 1200)
            {
                text.FontSize = 27;
                Border_AX.Width = 250;
                Border_AX.Height = 50;
                Border_AX.Margin = new Thickness(0,25,0,25);
                Border_BX.Width = 250;
                Border_BX.Height = 50;
                Border_BX.Margin = new Thickness(0,25,0,25);
                Border_CX.Width = 250;
                Border_CX.Height = 50;
                Border_CX.Margin = new Thickness(0,25,0,25);
                Border_DX.Width = 250;
                Border_DX.Height = 50;
                Border_DX.Margin = new Thickness(0,25,0,25);
                Border_SI.Width = 250;
                Border_SI.Height = 50;
                Border_SI.Margin = new Thickness(0,25,0,25);
                Border_DI.Width = 250;
                Border_DI.Height = 50;
                Border_DI.Margin = new Thickness(0,25,0,25);
                Border_BP.Width = 250;
                Border_BP.Height = 50;
                Border_BP.Margin = new Thickness(0,25,0,25);
                Border_SP.Width = 250;
                Border_SP.Height = 50;
                Border_SP.Margin = new Thickness(0,25,0,25);
                suivant.Width = 250;
                suivant.Height = 65;
            }
            else
            {
                text.FontSize= 23 ;
                Border_AX.Width = 200 ;
                Border_AX.Height = 45 ;
                Border_AX.Margin = new Thickness(0 ,12 ,0 ,12);
                Border_BX.Width = 200 ;
                Border_BX.Height = 45 ;
                Border_BX.Margin = new Thickness(0 ,12 ,0 ,12);
                Border_CX.Width = 200 ;
                Border_CX.Height = 45 ;
                Border_CX.Margin = new Thickness(0 ,12 ,0 ,12);
                Border_DX.Width = 200 ;
                Border_DX.Height = 45 ;
                Border_DX.Margin = new Thickness(0 ,12 ,0 ,12);
                Border_SI.Width = 200 ;
                Border_SI.Height = 45 ;
                Border_SI.Margin = new Thickness(0 ,12 ,0 ,12);
                Border_DI.Width = 200 ;
                Border_DI.Height = 45 ;
                Border_DI.Margin = new Thickness(0 ,12 ,0 ,12);
                Border_BP.Width = 200 ;
                Border_BP.Height = 45 ;
                Border_BP.Margin = new Thickness(0 ,12 ,0 ,12);
                Border_SP.Width = 200 ;
                Border_SP.Height = 45 ;
                Border_SP.Margin = new Thickness(0 ,12 ,0 ,12);
                suivant.Width = 215 ;
                suivant.Height = 50 ;
            }

        }
    }
}
