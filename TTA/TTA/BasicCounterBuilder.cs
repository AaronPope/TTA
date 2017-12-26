using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TTA
{
    class BasicCounterBuilder : StackLayout
    {
        // Page-level font size default value
        const int FONT_SIZE = 32;
        TapGestureRecognizer labelTgr = new TapGestureRecognizer();
        TapGestureRecognizer nameGesture = new TapGestureRecognizer();
        PanGestureRecognizer pgr = new PanGestureRecognizer();

        Color BUTTON_COLOR = Color.DarkOrange;
        int BUTTON_WIDTH = 75;
        int pendingScoreChange = 0;
        Player player;
        Button decrementButton, incrementButton;
        Label scoreLabel;
        Entry playerName;

        public BasicCounterBuilder() : this(new Player()) { } 

        public BasicCounterBuilder(Player p)
        {
            player = p;

            this.Orientation = StackOrientation.Horizontal;
            this.Margin = new Thickness(8, 8, 8, 0);

            /* Will still consider this, but much later; 
             * It takes up too much space right now 
             */

            playerName = new Entry
            {
                Text = player.Name,
                IsVisible = true,
                Opacity = 0.75,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.WhiteSmoke,
                //BackgroundColor = Color.FromRgb(255, 128, 128),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Entry)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 100,
            };

            decrementButton = new Button
            {
                Text = "-",
                IsVisible = true,
                Opacity = 0.75,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                //TextColor = Color.Blue,
                BackgroundColor = BUTTON_COLOR,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                WidthRequest = BUTTON_WIDTH,
            };

            scoreLabel = new Label
            {
                Text = player.Score.ToString(),
                IsVisible = true,
                Opacity = 0.75,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.WhiteSmoke,
                //BackgroundColor = Color.FromRgb(255, 128, 128),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            incrementButton = new Button
            {
                Text = "+",
                IsVisible = true,
                Opacity = 0.75,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                //TextColor = Color.Blue,
                BackgroundColor = BUTTON_COLOR,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = BUTTON_WIDTH,
            };

            // Handle clicking/tapping on buttons
            decrementButton.Clicked += DecrementButton_Clicked;
            incrementButton.Clicked += IncrementButton_Clicked;

            // Tap event recognition added to label
            labelTgr.Tapped += LabelTgr_Tapped;
            scoreLabel.GestureRecognizers.Add(labelTgr);

            playerName.Unfocused += PlayerName_Unfocused;

            /* May add this back in later
             * 
             *   //nameGesture.Tapped += NameGesture_Tapped;
             *   //playerName.GestureRecognizers.Add(nameGesture);
             *
               */

            // Add the elements to the view 
            this.Children.Add(playerName);
            this.Children.Add(decrementButton);
            this.Children.Add(scoreLabel);
            this.Children.Add(incrementButton);
        } // End constructor

        private void PlayerName_Unfocused(object sender, FocusEventArgs e)
        {
            if (playerName.Text == "")
            {
                this.IsVisible = false;
            }
        }


        private void UpdateScore()
        {
            // Update the Player object with the pending score
            player.ChangeScore(pendingScoreChange);
            // Zero out the pending change
            pendingScoreChange = 0;
            // Update the score text
            scoreLabel.Text = player.Score.ToString();
        }

        private void UpdatePendingScore()
        {
            if (pendingScoreChange != 0)
                scoreLabel.Text = String.Format("{0} ({1})", player.Score, pendingScoreChange);
            else
                scoreLabel.Text = player.Score.ToString();
        }


        /* EVENT HANDLERS */
        private void UpdateScore_Tapped(object sender, EventArgs e)
        {
            UpdateScore();
        }

        private void IncrementButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(e);
            //player.changeScore(1);
            ++pendingScoreChange;
            UpdatePendingScore();
        }

        private void DecrementButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(e);
            //player.ChangeScore(-1);
            --pendingScoreChange;
            UpdatePendingScore();
        }

        private void LabelTgr_Tapped(object sender, EventArgs e)
        {
            UpdateScore();
        }
    }
}
