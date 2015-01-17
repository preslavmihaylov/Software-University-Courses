using System;

    class SeniorTrainer : Trainer
    {
        private string rank = "Senior";

        public string Rank
        {
            get
            {
                return this.rank;    
            }
        }

        public SeniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public void deleteCourse(string courseName)
        {
            Console.WriteLine("The trainer " + this.FirstName + " " + this.LastName + " has deleted the course " + courseName);
        }

        public override string ToString() 
        {
 	        return base.ToString() + "Rank: " + this.Rank + Environment.NewLine;
        }
    }
