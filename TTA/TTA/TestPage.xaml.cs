using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TTA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();

            // A text swap to check that the code-behind has been properly linked to the view
            testPageLabel.Text = "Oopsies... it's been swapped on class initialization!";
        }
    }
}