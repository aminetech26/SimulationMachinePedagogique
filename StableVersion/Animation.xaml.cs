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
using System.Windows.Threading;
using ArchiMind;
using System.Text.RegularExpressions;
using System.Threading;

namespace projet
{
    /// <summary>
    /// Interaction logic for Animation.xaml
    /// </summary>
    public partial class Animation : Window
    {
        List<Case> _animals;
        public Animation()
        {
            InitializeComponent();

            _animals = new List<Case>();
            _animals.Add(new Case { ADR = "", Donnee = "" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8197h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "102h", Donnee = "8197h" });
            _animals.Add(new Case { ADR = "103h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "104h", Donnee = "8165h" });
            _animals.Add(new Case { ADR = "105h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "106h", Donnee = "9765h" });
            _animals.Add(new Case { ADR = "107h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "108h", Donnee = "9765h" });
            _animals.Add(new Case { ADR = "109h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "110h", Donnee = "8765h" });
            _animals.Add(new Case { ADR = "111h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "112h", Donnee = "8765h" });
            _animals.Add(new Case { ADR = "113h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8165h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8195h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8195h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            dataGrid1.ItemsSource = _animals;
            // dataGrid1.SelectedIndex = 1;

            //this.dataGrid1.SelectAll(); 
            this.Loaded += MainWindow_Loaded;

            // Rim to Ri
            //AnimateImage(myImage, myImag0e, -710, 10, -40, 7);
            //AnimateImage(myImage1, myImag1e, -710, 8, -40, 7);
            //AnimateImage(myImage2, myImag2e, -710, 6, -40, 7);

            // Rim to Ual1 
            //AnimateImage(myImage, myImag3e, -910, 10, -70, 7);
            //AnimateImage(myImage1, myImag4e, -910, 8, -70, 7);
            //AnimateImage(myImage2, myImag5e, -910, 6, -70, 7);

            // Rim to Ual2 
            //AnimateImage(myImage, myImag6e, -1010, 10, -70, 7);
            //AnimateImage(myImage1, myImag7e, -1010, 8, -70, 7);
            //AnimateImage(myImage2, myImag8e, -1010, 6, -70, 7);

            //Co to Ram
            //AnimateImage1(myImag9e, 300, 190, 7);
            //AnimateImage1(myImag10e, 300, 190, 7);
            //AnimateImage1(myImag11e, 300, 190, 7);

            // Sortie to ual2
            //AnimateImage2(myImag16e, myImag13e, -1165, -30, -905, -100, 7);
            //AnimateImage2(myImag15e, myImag12e, -1165, -30, -905, -100, 7);
            //AnimateImage2(myImag17e, myImag14e, -1165, -30, -905, -100, 7);

            // Sortie to ual1
            //AnimateImage2(myImag16e, myImag13e, -1165, -30, -1010, -100, 7);
            //AnimateImage2(myImag15e, myImag12e, -1165, -30, -1010, -100, 7);
            //AnimateImage2(myImag17e, myImag14e, -1165, -30, -1010, -100, 7);

            // registre to Ri
            //AnimateImage(myImag18e, myImag0e, -700, 8,-40, 7);
            //AnimateImage(myImag19e, myImag1e, -700, 8, -40, 7);
            //AnimateImage(myImag20e, myImag2e, -700, 8, -40, 7);

            //Registre to ual1
            //AnimateImage(myImag18e, myImag3e, -900, 8, -70, 7);
            //AnimateImage(myImag19e, myImag4e, -900, 8, -70, 7);
            //AnimateImage(myImag20e, myImag5e, -900, 8, -70, 7);

            //Registre to Ual2
            //AnimateImage(myImag18e, myImag6e, -1020, 8, -70, 7);
            //AnimateImage(myImag19e, myImag7e, -1020, 8, -70, 7);
            //AnimateImage(myImag20e, myImag8e, -1020, 8, -70, 7);

            //AnimateImage(myImag18e, myImag21e, -170, 8, -90, 7);
            //AnimateImage(myImag19e, myImag22e, -170, 8, -90, 7);
            //AnimateImage(myImag20e, myImag23e, -170, 8, -90, 7);

        }

        
        public Animation(string Reg1, string Reg2, string Reg3, string ccm, string Valdep, string memonique, string Format, string RegM, string dep, string destinaitr, string source) 
        {
            InitializeComponent();
            _animals = new List<Case>();

            _animals = new List<Case>();
            _animals.Add(new Case { ADR = "", Donnee = "" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8197h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "102h", Donnee = "8197h" });
            _animals.Add(new Case { ADR = "103h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "104h", Donnee = "8165h" });
            _animals.Add(new Case { ADR = "105h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "106h", Donnee = "9765h" });
            _animals.Add(new Case { ADR = "107h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "108h", Donnee = "9765h" });
            _animals.Add(new Case { ADR = "109h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "110h", Donnee = "8765h" });
            _animals.Add(new Case { ADR = "111h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "112h", Donnee = "8765h" });
            _animals.Add(new Case { ADR = "113h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8165h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8195h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            _animals.Add(new Case { ADR = "100h", Donnee = "8195h" });
            _animals.Add(new Case { ADR = "101h", Donnee = "0187h" });
            dataGrid1.ItemsSource = _animals;
            // dataGrid1.SelectedIndex = 1;

            //this.dataGrid1.SelectAll(); 
            this.Loaded += MainWindow_Loaded;

            Boolean mem_b;
            Boolean ifdep;
           
            if (RegM== " Memoire ") mem_b= true;
            else mem_b= false;
            if (dep == "Avec deplacement") ifdep = true;
            else ifdep= false;

         //   JeuxInstruction.executer_simulation_phase_a_phase(memonique,Format,mem_b,destinaitr,ifdep,Valdep,ccm,source,Reg1, Reg2, Reg3, myImag18e,myImag3e);

            //RI.Text =Reg1;
            //CO.Text =Reg2;
            //RAM.Text =Reg3;
            //REG1.Text =Reg1;
            // REG2.Text =Reg2;
            // REG3.Text =Reg3;

            Thread thread1 = new Thread(() =>
            {
                Thread.Sleep(5000); 
                Dispatcher.Invoke(() =>
                {
                    RAM.Text = Reg3;
                });
            });
            thread1.Start();

            // Créer un thread pour afficher le deuxième texte après 15 secondes
            Thread thread2 = new Thread(() =>
            {
                Thread.Sleep(10000); 
                Dispatcher.Invoke(() =>
                {
                    REG1.Text = Reg3;
                    REG2.Text = Reg3;
                    REG3.Text = Reg3;
                });
            });
            thread2.Start();



        }



        private void AnimateImage(Image image, Image image1, double finalX, double finalY, double finalY1, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds/2));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            xAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds / 2);
            // Start the storyboard

            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image1), finalY1, TimeSpan.FromSeconds(durationInSeconds / 2));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTarget(yAnimation1, image1);


            storyboard.Children.Add(yAnimation1);

            yAnimation1.BeginTime = TimeSpan.FromSeconds(1.5 * durationInSeconds);
            storyboard.Begin();
            Task.Delay(TimeSpan.FromSeconds(1.5 * durationInSeconds)).ContinueWith(task => ShowImage(image1));
            Task.Delay(TimeSpan.FromSeconds(1.5 * durationInSeconds)).ContinueWith(task => DeletImage(image));


        }

        private void AnimateImage2(Image image, Image image1, double finalX, double finalY, double finalX1, double finalY1, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            yAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            // Start the storyboard
            DoubleAnimation xAnimation1 = new DoubleAnimation(Canvas.GetLeft(image1), finalX1, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation1 = new DoubleAnimation(Canvas.GetTop(image1), finalY1, TimeSpan.FromSeconds(durationInSeconds));
            Storyboard.SetTargetProperty(xAnimation1, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation1, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTarget(xAnimation1, image1);
            Storyboard.SetTarget(yAnimation1, image1);

            storyboard.Children.Add(xAnimation1);
            storyboard.Children.Add(yAnimation1);

            xAnimation1.BeginTime = TimeSpan.FromSeconds(2 * durationInSeconds);
            yAnimation1.BeginTime = TimeSpan.FromSeconds(3 * durationInSeconds);
            storyboard.Begin();
            Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds)).ContinueWith(task => ShowImage(image1));
            Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds)).ContinueWith(task => DeletImage(image));


        }



        private void AnimateImage1(Image image, double finalX, double finalY, double durationInSeconds)
        {
            image.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            // Create a new DoubleAnimation for the X and Y coordinates
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(image), finalX, TimeSpan.FromSeconds(durationInSeconds));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(image), finalY, TimeSpan.FromSeconds(durationInSeconds));


            // Set the target property for the animations
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(Canvas.TopProperty));

            // Set the target object for the animations
            Storyboard.SetTarget(xAnimation, image);
            Storyboard.SetTarget(yAnimation, image);

            // Create a new storyboard and add the animations to it

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            xAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds);
            // Start the storyboard

            storyboard.Begin();
            Task.Delay(TimeSpan.FromSeconds(2 * durationInSeconds)).ContinueWith(task => DeletImage(image));


        }

        private void ShowImage(Image image)
        {
            // Show the image
            Dispatcher.Invoke(() => image.Visibility = Visibility.Visible);
        }
        private void DeletImage(Image image)
        {
            // Show the image
            Dispatcher.Invoke(() => image.Visibility = Visibility.Collapsed);
        }



        public void AnimateImage()
        {
            // Get the current position of the image
            double currentLeft = Canvas.GetLeft(myImage);

            // Create a DoubleAnimation to animate the position of the image
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = currentLeft;
            animation.To = currentLeft - 700; // Move 200 pixels to the right
            animation.Duration = TimeSpan.FromSeconds(5);

            // Set the animation to target the Canvas.Left property of the image
            Storyboard.SetTarget(animation, myImage);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

            // Create a storyboard and add the animation to it
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            // Start the animation
            storyboard.Begin();
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
