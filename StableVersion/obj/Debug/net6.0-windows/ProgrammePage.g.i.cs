﻿#pragma checksum "..\..\..\ProgrammePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "074ECF6CD170DE47CF87C8CA73BE3F54E253D101"
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
using projet;


namespace projet {
    
    
    /// <summary>
    /// ProgrammePage
    /// </summary>
    public partial class ProgrammePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 97 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GlobalGrid;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextPage;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Grid_InstructionsScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_Instructions;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_Inst;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel leftColumnGrid;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAdd;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\ProgrammePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SavePage;
        
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
            System.Uri resourceLocater = new System.Uri("/projet;V1.0.0.0;component/programmepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ProgrammePage.xaml"
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
            this.GlobalGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Button = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\ProgrammePage.xaml"
            this.Button.Click += new System.Windows.RoutedEventHandler(this.GoBack_To_Home);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NextPage = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\ProgrammePage.xaml"
            this.NextPage.Click += new System.Windows.RoutedEventHandler(this.NextPage_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Grid_InstructionsScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.Grid_Instructions = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.Grid_Inst = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.leftColumnGrid = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.ButtonAdd = ((System.Windows.Controls.Button)(target));
            
            #line 205 "..\..\..\ProgrammePage.xaml"
            this.ButtonAdd.Click += new System.Windows.RoutedEventHandler(this.AddInstruction_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SavePage = ((System.Windows.Controls.Button)(target));
            
            #line 218 "..\..\..\ProgrammePage.xaml"
            this.SavePage.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

