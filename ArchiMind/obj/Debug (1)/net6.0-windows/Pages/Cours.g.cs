﻿#pragma checksum "..\..\..\..\Pages\Cours.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90F79C38C309CA2D1349E5A917BA4177B18A6DAB"
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
    /// Cours
    /// </summary>
    public partial class Cours : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/projet;component/pages/cours.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Cours.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 61 "..\..\..\..\Pages\Cours.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BackHomeFromExo);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 127 "..\..\..\..\Pages\Cours.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BackQuiz);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 177 "..\..\..\..\Pages\Cours.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Fermer);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 215 "..\..\..\..\Pages\Cours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoBackQuiz);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

