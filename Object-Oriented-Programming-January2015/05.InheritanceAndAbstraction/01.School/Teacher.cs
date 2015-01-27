using System;
using System.Collections.Generic;

    class Teacher : Person, IDetailable
    {
        private List<Discipline> disciplines = new List<Discipline>();

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            private set
            {
                this.disciplines = value;
            }
        }

        public Teacher(string name, int age, List<Discipline> disciplines, string details = null) : base(name, age, details)
        {
            this.Disciplines = disciplines;
        }

        public Teacher(string name, int age, string details = null)
            : base(name, age, details)
        {
            this.Disciplines = new List<Discipline>();
        }

        public override string ToString()
        {
            string output = "Disciplines: " + Environment.NewLine;
            foreach (var discipline in this.disciplines)
            {
                output += new string(' ', 5) + discipline.Name + Environment.NewLine;
            }
            return base.ToString() + output;
        }
    }
