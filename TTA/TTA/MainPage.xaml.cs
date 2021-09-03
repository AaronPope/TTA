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
    public partial class MainPage : ContentPage
    {

        List<Player> players = new List<Player> {
            new Player(50, "Player 1"),
            new Player(50, "Player 2"),
        };

        public MainPage()
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();

            tgr.Tapped += Tgr_Tapped;
            outerStackLayout.GestureRecognizers.Add(tgr);

            AddNewPlayers(players);

            addPlayerButton.Clicked += AddNewPlayer;
        }

        private void Tgr_Tapped(object sender, EventArgs e)
        {
            addPlayerButton.IsVisible = !addPlayerButton.IsVisible;
        }

        private void AddNewRandomPlayers(int numberOfPlayersToAdd)
        {
            if (numberOfPlayersToAdd > 0)
                for (int i = 0; i < numberOfPlayersToAdd; ++i)
                {
                    AddNewPlayer(new Player());
                }
        }

        private void AddNewPlayers(List<Player> listOfPlayers)
        {
            foreach (Player p in players)
            {
                AddNewPlayer(p);
            }
        }

        private void AddNewPlayer(Player player)
        {
            outerStackLayout.Children.Insert(outerStackLayout.Children.Count - 1, new BasicCounterBuilder(player));
        }

        private void AddNewPlayer(object sender, EventArgs e)
        {
            AddNewRandomPlayers(1);
        }
    }
}
