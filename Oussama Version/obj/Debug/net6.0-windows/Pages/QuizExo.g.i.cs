﻿#pragma checksum "..\..\..\..\Pages\QuizExo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C435EF056A9B7920FDE98457A8087C1A79EEC5CB"
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
    /// QuizExo
    /// </summary>
    public partial class QuizExo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Pages\QuizExo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid slider;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\QuizExo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton menu;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\QuizExo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.Storyboard HideStackPanel;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\QuizExo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.Storyboard ShowStackPanel;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Pages\QuizExo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path menuIcon;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\QuizExo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel navBar;
        
        #line default
        #line hidden
        
        
        #line 341 "..\..\..\..\Pages\QuizExo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame _PageContent;
        
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
            System.Uri resourceLocater = new System.Uri("/projet;component/pages/quizexo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\QuizExo.xaml"
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
            this.slider = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.menu = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 38 "..\..\..\..\Pages\QuizExo.xaml"
            this.menu.Checked += new System.Windows.RoutedEventHandler(this.menu_Cheked);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\Pages\QuizExo.xaml"
            this.menu.Unchecked += new System.Windows.RoutedEventHandler(this.menu_Uncheked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.HideStackPanel = ((System.Windows.Media.Animation.Storyboard)(target));
            return;
            case 4:
            this.ShowStackPanel = ((System.Windows.Media.Animation.Storyboard)(target));
            return;
            case 5:
            this.menuIcon = ((System.Windows.Shapes.Path)(target));
            return;
            case 6:
            this.navBar = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            
            #line 106 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz1);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 122 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz2);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 132 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz3);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 142 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz4);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 152 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz5);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 162 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz6);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 172 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz7);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 182 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz8);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 192 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz9);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 202 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz10);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 212 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz11);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 222 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz12);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 232 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz13);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 242 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz14);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 252 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz15);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 262 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz16);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 272 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz17);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 282 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz18);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 292 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz19);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 302 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz20);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 312 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz21);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 322 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz22);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 332 "..\..\..\..\Pages\QuizExo.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.toQuiz23);
            
            #line default
            #line hidden
            return;
            case 30:
            this._PageContent = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

