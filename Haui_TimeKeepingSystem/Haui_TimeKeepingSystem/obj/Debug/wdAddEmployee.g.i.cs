﻿#pragma checksum "..\..\wdAddEmployee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BB558AC67C9E5E39497C398D13900F1D4DC882737E229B19614C7DB81AFBA811"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Haui_TimeKeepingSystem;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Haui_TimeKeepingSystem {
    
    
    /// <summary>
    /// wdAddEmployee
    /// </summary>
    public partial class wdAddEmployee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmployeeName;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmployeeCode;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDepartMent;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJob;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPicturePath;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon btnOpenFile;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFingerID;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\wdAddEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Haui_TimeKeepingSystem;component/wdaddemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\wdAddEmployee.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 15 "..\..\wdAddEmployee.xaml"
            ((Haui_TimeKeepingSystem.wdAddEmployee)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtEmployeeName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtEmployeeCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtDepartMent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtJob = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtPicturePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnOpenFile = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            
            #line 78 "..\..\wdAddEmployee.xaml"
            this.btnOpenFile.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnOpenFile_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtFingerID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\wdAddEmployee.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\wdAddEmployee.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

