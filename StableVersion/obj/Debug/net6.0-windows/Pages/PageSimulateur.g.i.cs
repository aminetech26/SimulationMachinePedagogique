﻿#pragma checksum "..\..\..\..\Pages\PageSimulateur.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "408F6474B663DE756EEC0821F3134E0B1F77ED1E"
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
    /// PageSimulateur
    /// </summary>
    public partial class PageSimulateur : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img1;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button1;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt1;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img2;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button2;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Pages\PageSimulateur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt2;
        
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
            System.Uri resourceLocater = new System.Uri("/projet;V1.0.0.0;component/pages/pagesimulateur.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\PageSimulateur.xaml"
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
            
            #line 11 "..\..\..\..\Pages\PageSimulateur.xaml"
            ((System.Windows.Controls.Grid)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Grid_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Border = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.img1 = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.Button1 = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.txt1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.img2 = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.Button2 = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Pages\PageSimulateur.xaml"
            this.Button2.Click += new System.Windows.RoutedEventHandler(this.toCEIPage);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txt2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

