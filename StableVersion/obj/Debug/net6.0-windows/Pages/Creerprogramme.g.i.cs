﻿#pragma checksum "..\..\..\..\Pages\Creerprogramme.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CA8B7A3B5668D8A9A0C15886FB3E1E1965E48F38"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using projet.Utilities;


namespace projet.Pages {
    
    
    /// <summary>
    /// Creerprogramme
    /// </summary>
    public partial class Creerprogramme : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 117 "..\..\..\..\Pages\Creerprogramme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Pages\Creerprogramme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Text1;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\Pages\Creerprogramme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button1;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\Pages\Creerprogramme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button2;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\..\Pages\Creerprogramme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button3;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\..\Pages\Creerprogramme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BorderHexadecimal;
        
        #line default
        #line hidden
        
        
        #line 425 "..\..\..\..\Pages\Creerprogramme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BorderMnemonique;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/projet;V1.0.0.0;component/pages/creerprogramme.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Creerprogramme.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Button = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\..\Pages\Creerprogramme.xaml"
            this.Button.Click += new System.Windows.RoutedEventHandler(this.GoBackHome);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Text1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 135 "..\..\..\..\Pages\Creerprogramme.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoToProgramme3);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button1 = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\..\Pages\Creerprogramme.xaml"
            this.Button1.Click += new System.Windows.RoutedEventHandler(this.Hexadecimal);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button2 = ((System.Windows.Controls.Button)(target));
            
            #line 173 "..\..\..\..\Pages\Creerprogramme.xaml"
            this.Button2.Click += new System.Windows.RoutedEventHandler(this.Mnemonique);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Button3 = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.BorderHexadecimal = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.BorderMnemonique = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
