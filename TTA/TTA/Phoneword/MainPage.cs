using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        StackLayout phonewordLayout = new PhonewordStackLayout();

        public MainPage()
        {
            this.Content = phonewordLayout;
        }
    }
}
