// Updated by XamlIntelliSenseFileGenerator 06.12.2023 9:37:03
#pragma checksum "..\..\..\..\Windows\Main\WindowRegister.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0B2844F94D2E03FD383802FF0C89BD3F4BF8CE5F17D2F54D624373E9AA1E2647"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Internet_Store;
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


namespace Internet_Store
{


    /// <summary>
    /// WindowRegister
    /// </summary>
    public partial class WindowRegister : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 45 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Last_Name;

#line default
#line hidden


#line 49 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox First_Name;

#line default
#line hidden


#line 53 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Middle_Name;

#line default
#line hidden


#line 57 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Number_Phone;

#line default
#line hidden


#line 61 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Gender;

#line default
#line hidden


#line 65 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login;

#line default
#line hidden


#line 69 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;

#line default
#line hidden


#line 75 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordCheck;

#line default
#line hidden


#line 78 "..\..\..\..\Windows\Main\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Register;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Internet_Store;component/windows/main/windowregister.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Windows\Main\WindowRegister.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Last_Name = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.First_Name = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.Middle_Name = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.Number_Phone = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.Gender = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 6:
                    this.Login = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.Password = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 8:
                    this.PasswordCheck = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 9:
                    this.Register = ((System.Windows.Controls.Button)(target));

#line 84 "..\..\..\..\Windows\Main\WindowRegister.xaml"
                    this.Register.Click += new System.Windows.RoutedEventHandler(this.Register_Click);

#line default
#line hidden
                    return;
                case 10:

#line 91 "..\..\..\..\Windows\Main\WindowRegister.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ComboBox Role;
    }
}

