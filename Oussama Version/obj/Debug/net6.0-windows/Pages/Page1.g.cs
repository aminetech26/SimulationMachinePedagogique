﻿#pragma checksum "..\..\..\..\Pages\Page1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A05555FC6E4CE2282D84E4D1B64988425BA5B1C8"
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
using projet.Utilities;


namespace projet.Pages {
    
    
    /// <summary>
    /// Page1
    /// </summary>
    public partial class Page1 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 140 "..\..\..\..\Pages\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Main;
        
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
            System.Uri resourceLocater = new System.Uri("/projet;component/pages/page1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Page1.xaml"
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
            
            #line 9 "..\..\..\..\Pages\Page1.xaml"
            ((projet.Pages.Page1)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.MainWindow_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 64 "..\..\..\..\Pages\Page1.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toHomePage);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 92 "..\..\..\..\Pages\Page1.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toCEIPage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 102 "..\..\..\..\Pages\Page1.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuizPage);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 129 "..\..\..\..\Pages\Page1.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Fermer);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Main = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

