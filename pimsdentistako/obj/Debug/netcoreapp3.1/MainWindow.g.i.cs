﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4E6A946D2866C3E3E325A74B38336E66E9126322"
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
using pimsdentistako;
using pimsdentistako.ViewModels;
using pimsdentistako.Views;


namespace pimsdentistako {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal pimsdentistako.MainWindow Mainscreen;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border mask;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DentistButton;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreatmentButton;
        
        #line default
        #line hidden
        
        
        #line 284 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button transactionsBtn;
        
        #line default
        #line hidden
        
        
        #line 326 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AppointmentsButton;
        
        #line default
        #line hidden
        
        
        #line 371 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PatientsButton;
        
        #line default
        #line hidden
        
        
        #line 410 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUtility;
        
        #line default
        #line hidden
        
        
        #line 446 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button userAccountBtn;
        
        #line default
        #line hidden
        
        
        #line 485 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dashboardBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/pimsdentistako;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Mainscreen = ((pimsdentistako.MainWindow)(target));
            
            #line 16 "..\..\..\MainWindow.xaml"
            this.Mainscreen.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Mainscreen_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mask = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            
            #line 158 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Master_File_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DentistButton = ((System.Windows.Controls.Button)(target));
            
            #line 196 "..\..\..\MainWindow.xaml"
            this.DentistButton.Click += new System.Windows.RoutedEventHandler(this.DentistButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TreatmentButton = ((System.Windows.Controls.Button)(target));
            
            #line 241 "..\..\..\MainWindow.xaml"
            this.TreatmentButton.Click += new System.Windows.RoutedEventHandler(this.TreatmentButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.transactionsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 285 "..\..\..\MainWindow.xaml"
            this.transactionsBtn.Click += new System.Windows.RoutedEventHandler(this.transactionsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AppointmentsButton = ((System.Windows.Controls.Button)(target));
            
            #line 326 "..\..\..\MainWindow.xaml"
            this.AppointmentsButton.Click += new System.Windows.RoutedEventHandler(this.AppointmentsButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PatientsButton = ((System.Windows.Controls.Button)(target));
            
            #line 372 "..\..\..\MainWindow.xaml"
            this.PatientsButton.Click += new System.Windows.RoutedEventHandler(this.PatientsButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnUtility = ((System.Windows.Controls.Button)(target));
            
            #line 411 "..\..\..\MainWindow.xaml"
            this.btnUtility.Click += new System.Windows.RoutedEventHandler(this.UtilityButton_CLick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.userAccountBtn = ((System.Windows.Controls.Button)(target));
            
            #line 450 "..\..\..\MainWindow.xaml"
            this.userAccountBtn.Click += new System.Windows.RoutedEventHandler(this.userAccountBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dashboardBtn = ((System.Windows.Controls.Button)(target));
            
            #line 485 "..\..\..\MainWindow.xaml"
            this.dashboardBtn.Click += new System.Windows.RoutedEventHandler(this.dashboardBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

