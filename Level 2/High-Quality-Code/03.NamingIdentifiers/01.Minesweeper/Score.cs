namespace Minesweeper
{
    using System;

    public class Score
    {
        private string name;

        private int points;

        public string Player
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }

        public Score()
        {
        }

        public Score(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
}
