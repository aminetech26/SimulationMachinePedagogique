﻿using System;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace projet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            window.NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Page1.xaml", UriKind.RelativeOrAbsolute));


        }
        public MainWindow(object c,string Reg1,string Reg2 ,string Reg3 ,string ccm ,string Valdep,string memonique,string Format,string RegM,string dep,string destinaitr,string source)
        {

            Animation wind = new Animation(Reg1,Reg2,Reg3,ccm,Valdep,memonique,Format,RegM,dep,destinaitr,source);
            wind.ShowDialog();
        }
         
    }
}
