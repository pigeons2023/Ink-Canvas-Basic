﻿#pragma checksum "..\..\..\Windows\OperatingGuideWindow - 复制.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3FFA90608B7CDF7BEC327DFD3BA2327B11468D0A"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Ink_Canvas;
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
using iNKORE.UI.WPF;
using iNKORE.UI.WPF.ColorPicker;
using iNKORE.UI.WPF.Common;
using iNKORE.UI.WPF.Controls;
using iNKORE.UI.WPF.Converters;
using iNKORE.UI.WPF.DragDrop;
using iNKORE.UI.WPF.Helpers;
using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Common;
using iNKORE.UI.WPF.Modern.Common.Converters;
using iNKORE.UI.WPF.Modern.Common.IconKeys;
using iNKORE.UI.WPF.Modern.Controls;
using iNKORE.UI.WPF.Modern.Controls.Helpers;
using iNKORE.UI.WPF.Modern.Controls.Primitives;
using iNKORE.UI.WPF.Modern.Helpers;
using iNKORE.UI.WPF.Modern.Helpers.Styles;
using iNKORE.UI.WPF.Modern.Input;
using iNKORE.UI.WPF.Modern.Markup;
using iNKORE.UI.WPF.Modern.Media;
using iNKORE.UI.WPF.Modern.Media.Animation;
using iNKORE.UI.WPF.Modern.Native;
using iNKORE.UI.WPF.Modern.Themes.DesignTime;
using iNKORE.UI.WPF.TrayIcons;


namespace Ink_Canvas {
    
    
    /// <summary>
    /// OperatingGuideWindow
    /// </summary>
    public partial class OperatingGuideWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 417 "..\..\..\Windows\OperatingGuideWindow - 复制.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BtnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Ink Canvas Artistry;component/windows/operatingguidewindow%20-%20%e5%a4%8d%e5%88" +
                    "%b6.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\OperatingGuideWindow - 复制.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 39 "..\..\..\Windows\OperatingGuideWindow - 复制.xaml"
            ((System.Windows.Controls.Border)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.WindowDragMove);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 45 "..\..\..\Windows\OperatingGuideWindow - 复制.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).ManipulationBoundaryFeedback += new System.EventHandler<System.Windows.Input.ManipulationBoundaryFeedbackEventArgs>(this.SCManipulationBoundaryFeedback);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnClose = ((System.Windows.Controls.Border)(target));
            
            #line 427 "..\..\..\Windows\OperatingGuideWindow - 复制.xaml"
            this.BtnClose.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.BtnClose_MouseUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

