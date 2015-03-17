using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsOlderThan(DateTime date)
        {
            bool isOlder = this.BirthDate > date;
            return isOlder;
        }
    }
}
