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

namespace Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            MessageBox.Show(" Retour ");
        }

        private void Button_Etape_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Etape par etape");
        }
        
        private void Button_commencer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Commencer");
        }
        
        private void Button_recommencer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recommencer");
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
    }
}
