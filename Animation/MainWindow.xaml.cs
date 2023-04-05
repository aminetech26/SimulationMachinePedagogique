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
using System.Windows.Controls.Primitives;
using System.Xml.Linq;
using System.Data;

namespace Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
    
        List<Case> _animals;
        public MainWindow()
        {
            InitializeComponent();
            _animals = new List<Case>();
            _animals.Add(new Case { ADR = "", Donnee = "" });
            _animals.Add(new Case { ADR = "100h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187 0187h" });
            _animals.Add(new Case { ADR = "102h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "103h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "104h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "105h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "106h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "107h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "108h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "109h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "110h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "111h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "112h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "113h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "819765h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            dataGrid1.ItemsSource = _animals;
            // dataGrid1.SelectedIndex = 1;

            //this.dataGrid1.SelectAll(); 
            this.Loaded += MainWindow_Loaded;
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


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(textBox1.Text);
            SelectRowByIndexes(dataGrid1, num, num);

        }


        // =================================================================


        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T tChild)
                {
                    return tChild;
                }
                else
                {
                    T foundChild = FindVisualChild<T>(child);
                    if (foundChild != null)
                    {
                        return foundChild;
                    }
                }
            }
            return null;
        }

        public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }





        public static void SelectRowByIndexes(DataGrid dataGrid, params int[] rowIndexes)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

            if (!dataGrid.SelectionMode.Equals(DataGridSelectionMode.Extended))
                throw new ArgumentException("The SelectionMode of the DataGrid must be set to Extended.");

            if (rowIndexes.Length.Equals(0) || rowIndexes.Length > dataGrid.Items.Count)
                throw new ArgumentException("Invalid number of indexes.");

            dataGrid.SelectedItems.Clear();
            foreach (int rowIndex in rowIndexes)
            {
                if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

                object item = dataGrid.Items[rowIndex]; //=Product X
                dataGrid.SelectedItems.Add(item);

                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                if (row == null)
                {
                    dataGrid.ScrollIntoView(item);
                    row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                }
                if (row != null)
                {
                    DataGridCell cell = GetCell(dataGrid, row, 0);
                    if (cell != null)
                        cell.Focus();
                }
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
            {
                // Get the selected row object
                Case selectedPerson = dataGrid1.SelectedItem as Case;

                // Display the selected person's name in a TextBox
                txADR.Text = selectedPerson.ADR;
                RIM.Text = selectedPerson.Donnee;
            }
        }

       
    }
    public class Case
    {
        public string ADR { get; set; }
        public string Donnee { get; set; }
    }
}
