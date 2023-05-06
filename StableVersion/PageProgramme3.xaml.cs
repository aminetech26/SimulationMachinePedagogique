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
        public PageProgramme3()
        {
            InitializeComponent();
            suivant.IsEnabled= false;
            AX.Focus();
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
            NavigationService.Navigate(new Uri("/ExecutionProgramme.xaml", UriKind.Relative));
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    }
}
