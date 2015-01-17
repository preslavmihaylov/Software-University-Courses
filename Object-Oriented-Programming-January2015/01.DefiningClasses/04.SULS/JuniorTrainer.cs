using System;

    class JuniorTrainer : Trainer
    {
        private string rank = "Junior";

        public string Rank
        {
            get
            {
                return this.rank;    
            }
        }


        public JuniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public override string ToString()
        {
            return base.ToString() + "Rank: " + this.Rank + Environment.NewLine;
        }
    }
