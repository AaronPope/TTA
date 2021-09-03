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
    class Player
    {
        public int Score { get; private set; }
        public int PendingScoreChange { get; private set; }
        public string Name { get; set; }

        /// <summary>
        /// Creates a new player with a random name and score of 0
        /// </summary>
        public Player()
            : this(0) { }

        /// <summary>
        ///  Creates a new player with a random name and a specified score
        /// </summary>
        /// <param name="score">Desired starting score</param>
        public Player(int score)
        {
            this.Score = score;
            GenerateRandomName();
        }

        /// <summary>
        /// Creates a new player with a specified name and a specified score
        /// </summary>
        /// <param name="score">Desired starting score</param>
        /// <param name="name">Desired starting name</param>
        public Player(int score, string name)
        {
            this.Score = score;
            this.Name = name;
        }

        public int ChangeScore(int value)
        {
            this.Score += value;
            return this.Score;
        }

        public int CommitScoreChange(int value)
        {
            this.Score += this.PendingScoreChange;
            return this.Score;
        }

        private void GenerateRandomName()
        {
            this.Name = RandomNameGenerator.getRandomName();
        }
    }
}