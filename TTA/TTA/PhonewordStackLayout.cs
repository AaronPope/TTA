using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

using Phoneword.Core;

namespace Phoneword
{
    class PhonewordStackLayout : StackLayout
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;
        Label prompt;

        private string translatedNumber;

        public PhonewordStackLayout()
        {
            Spacing = 15;

            phoneNumberText = new Entry {
                Text = "1-855-XAMARIN"
            };

            translateButton = new Button {
                Text = "Translate"
            };

            translateButton.Clicked += (sender, eventArgs) => {
                translatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);
                callButton.IsEnabled = string.IsNullOrEmpty(translatedNumber) == false;
                callButton.Text = $"Call {translatedNumber ?? ""}";
            };

            callButton = new Button {
                Text = "Call",
                IsEnabled = false
            };

            callButton.Clicked += async (sender, eventArgs) => {
                //if (Parent.GetType() == typeof(ContentPage)) {
                //    if (await (ContentPage) Parent.DisplayAlert(
                //        "Dial a number",
                //        "Would you like to call someone?",
                //        "Yes",
                //        "No")) {
                //        // TODO
                //    }
                //}


                try {
                    PhoneDialer.Open(translatedNumber);
                }
                catch (ArgumentNullException e) {
                    
                }
                catch (FeatureNotSupportedException e) {
                    Console.WriteLine("FEATURE NOT SUPPORTED");
                    Console.WriteLine(e);
                }
                catch(Exception e) {
                    
                }
            };

            prompt = new Label {
                Text = "Enter a Phoneword:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            this.Children.Add(prompt);
            this.Children.Add(phoneNumberText);
            this.Children.Add(translateButton);
            this.Children.Add(callButton);
        }

        public void Call()
        {

        }
    }
}
