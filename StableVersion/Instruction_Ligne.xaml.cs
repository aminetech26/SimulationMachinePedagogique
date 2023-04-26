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
    /// Interaction logic for Instruction_Ligne.xaml
    /// </summary>
    public partial class Instruction_Ligne : UserControl
    {
        public Instruction_Ligne()
        {
            InitializeComponent();
            // set the ItemsSource for ComboBox1
            List<string> options1 = new List<string>() { "Arithmetique", "Option2", "Option3" };
            ComboBox1.Items.Clear();
            ComboBox1.ItemsSource = options1;

            // set the ItemsSource for ComboBox2
            List<string> options2 = new List<string>() { "OptionA", "OptionB", "OptionC" };
            ComboBox2.Items.Clear();
            ComboBox2.ItemsSource = options2;
            ComboBox2.IsEnabled = false;
            ComboBox3.IsEnabled = false;
            ComboBox4.IsEnabled = false;
            ComboBox5.IsEnabled = false;
            ComboBox6.IsEnabled = false;
            ComboBox7.IsEnabled = false;
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox1.SelectedItem as string;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "Arithmetique":
                    ComboBox2.IsEnabled = true;
                    ComboBox2.ItemsSource = new List<string> { "ADD", "SUB", "MUL" };
                    break;
                case "Option2":
                    ComboBox2.IsEnabled = false;
                    ComboBox2.ItemsSource = new List<string> { "Item D", "Item E", "Item F" };
                    break;
                case "Item 3":
                    ComboBox2.ItemsSource = new List<string> { "Item G", "Item H", "Item I" };
                    break;
                default:
                    ComboBox2.ItemsSource = null;
                    break;
            }
        }
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox2.SelectedItem as string;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "option1":
                    ComboBox3.ItemsSource = new List<string> { "Item A", "Item B", "Item C" };
                    break;
                case "Item 2":
                    ComboBox3.ItemsSource = new List<string> { "Item D", "Item E", "Item F" };
                    break;
                case "Item 3":
                    ComboBox3.ItemsSource = new List<string> { "Item G", "Item H", "Item I" };
                    break;
                default:
                    ComboBox3.ItemsSource = null;
                    break;
            }
        }
        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox3.SelectedItem as string;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "option1":
                    ComboBox2.ItemsSource = new List<string> { "Item A", "Item B", "Item C" };
                    break;
                case "Item 2":
                    ComboBox2.ItemsSource = new List<string> { "Item D", "Item E", "Item F" };
                    break;
                case "Item 3":
                    ComboBox2.ItemsSource = new List<string> { "Item G", "Item H", "Item I" };
                    break;
                default:
                    ComboBox2.ItemsSource = null;
                    break;
            }
        }
        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox4.SelectedItem as string;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "option1":
                    ComboBox2.ItemsSource = new List<string> { "Item A", "Item B", "Item C" };
                    break;
                case "Item 2":
                    ComboBox2.ItemsSource = new List<string> { "Item D", "Item E", "Item F" };
                    break;
                case "Item 3":
                    ComboBox2.ItemsSource = new List<string> { "Item G", "Item H", "Item I" };
                    break;
                default:
                    ComboBox2.ItemsSource = null;
                    break;
            }
        }
        private void ComboBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox5.SelectedItem as string;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "option1":
                    ComboBox2.ItemsSource = new List<string> { "Item A", "Item B", "Item C" };
                    break;
                case "Item 2":
                    ComboBox2.ItemsSource = new List<string> { "Item D", "Item E", "Item F" };
                    break;
                case "Item 3":
                    ComboBox2.ItemsSource = new List<string> { "Item G", "Item H", "Item I" };
                    break;
                default:
                    ComboBox2.ItemsSource = null;
                    break;
            }
        }
        private void ComboBox6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox6.SelectedItem as string;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "option1":
                    ComboBox2.ItemsSource = new List<string> { "Item A", "Item B", "Item C" };
                    break;
                case "Item 2":
                    ComboBox2.ItemsSource = new List<string> { "Item D", "Item E", "Item F" };
                    break;
                case "Item 3":
                    ComboBox2.ItemsSource = new List<string> { "Item G", "Item H", "Item I" };
                    break;
                default:
                    ComboBox2.ItemsSource = null;
                    break;
            }
        }
        private void ComboBox7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedItem = ComboBox7.SelectedItem as string;

            // Update the content of ComboBox2 based on the selected item in ComboBox1
            switch (selectedItem)
            {
                case "option1":
                    ComboBox2.ItemsSource = new List<string> { "Item A", "Item B", "Item C" };
                    break;
                case "Item 2":
                    ComboBox2.ItemsSource = new List<string> { "Item D", "Item E", "Item F" };
                    break;
                case "Item 3":
                    ComboBox2.ItemsSource = new List<string> { "Item G", "Item H", "Item I" };
                    break;
                default:
                    ComboBox2.ItemsSource = null;
                    break;
            }
        }

    }
}
