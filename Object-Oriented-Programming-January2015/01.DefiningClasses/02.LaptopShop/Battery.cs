using System;
    class Battery
    {
        private string type;
        private int life;

        public string Type 
        {
            get
            {
                return this.type;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.type = value;
            } 
        }

        public int Life
        {
            get
            {
                return this.life;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.life = value;
            }
        }

        public Battery(string type, int life)
        {
            this.Type = type;
            this.Life = life;
        }

        public override string ToString()
        {
            string output = "";
            output += "Battery Type: " + this.Type + Environment.NewLine;
            output += "Battery Life: " + this.Life + Environment.NewLine;
            return output;
        }
    }
