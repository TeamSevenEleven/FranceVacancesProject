﻿#pragma checksum "C:\Users\Andy\Source\Reposs\FranceVacancesProject\FranceVacances\Views\Book.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "86A1ED4622B43BA4F6B2C25F0D99E786"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FranceVacances.Views
{
    partial class Book : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Calendar = (global::Windows.UI.Xaml.Controls.CalendarView)(target);
                    #line 12 "..\..\..\Views\Book.xaml"
                    ((global::Windows.UI.Xaml.Controls.CalendarView)this.Calendar).CalendarViewDayItemChanging += this.Calendar_CalendarViewDayItemChanging;
                    #line 14 "..\..\..\Views\Book.xaml"
                    ((global::Windows.UI.Xaml.Controls.CalendarView)this.Calendar).SelectedDatesChanged += this.Calendar_SelectedDatesChanged;
                    #line default
                }
                break;
            case 2:
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.checkout = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 26 "..\..\..\Views\Book.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.checkout).Click += this.checkout_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.price = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.total = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.cearbutton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 67 "..\..\..\Views\Book.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.cearbutton).Click += this.cearbutton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

