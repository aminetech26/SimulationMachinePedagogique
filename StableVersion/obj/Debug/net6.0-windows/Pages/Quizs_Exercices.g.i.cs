﻿#pragma checksum "..\..\..\..\Pages\Quizs_Exercices.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0940D5DF1AA97C75119EAD50FD4E6A83D9D2DA4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using projet.Pages;


namespace projet.Pages {
    
    
    /// <summary>
    /// Quizs_Exercices
    /// </summary>
    public partial class Quizs_Exercices : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Pages\Quizs_Exercices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image1;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Quizs_Exercices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Text1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Pages\Quizs_Exercices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Stack;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\Quizs_Exercices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DisplayDataTextBlock;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Pages\Quizs_Exercices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DisplayData1TextBlock1;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Pages\Quizs_Exercices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button1;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Pages\Quizs_Exercices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/projet;component/pages/quizs_exercices.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Quizs_Exercices.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\Pages\Quizs_Exercices.xaml"
            ((System.Windows.Controls.Grid)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Grid_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Text1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Stack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.DisplayDataTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.DisplayData1TextBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Button1 = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Pages\Quizs_Exercices.xaml"
            this.Button1.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.GoToExerciceTypeMenu);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Button2 = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\Pages\Quizs_Exercices.xaml"
            this.Button2.Click += new System.Windows.RoutedEventHandler(this.GoToQuiz);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

