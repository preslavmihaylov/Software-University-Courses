using System;

class SchoolDemo
{
    static void Main()
    {
        School svishtovSchool = new School("State high school of economics \"Dimitar Hadzhivasilev\"");
        Class first = new Class("1es42QwE", "We are number one!");
        first.Students.Add(new Student("Petar", 16, 1, "Quite noisy this guy..."));
        first.Students.Add(new Student("Georgi", 15, 2));
        first.Students.Add(new Student("Penka", 17, 3, "A programmer girl. Can you believe it?"));

        Teacher petkov = new Teacher("Petkov", 42);
        Teacher dimitrov = new Teacher("Dimitrov", 48);

        Discipline history = new Discipline("History", 18);
        history.Students.Add(new Student("Nasko", 14, 4));

        petkov.Disciplines.Add(history);
        dimitrov.Disciplines.Add(new Discipline("Geography", 12));

        first.Teachers.Add(petkov);
        first.Teachers.Add(dimitrov);
        svishtovSchool.Classes.Add(first);

        Console.WriteLine(svishtovSchool.ToString());
    }
}
