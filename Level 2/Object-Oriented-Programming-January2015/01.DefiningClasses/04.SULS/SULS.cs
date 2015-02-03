using System;
using System.Collections.Generic;
using System.Linq;
class SULS
{
    enum firstNames { Gosho, Pesho, Penko, Asen, Cvetan, Vasil, Chochko, Pesho2, Rambo };
    enum lastNames { Georgiev, Pesholiev, Penkaliev, Asenov, Cvetanov, Vasilev, Chochkov, Pesho2ev, Rambonev };
    enum types { JuniorTrainer, SeniorTrainer, GraduateStudent, OnsiteStudent, OnlineStudent, DropoutStudent };
    enum courses { JavaBasics, WebFundamentals, JavascriptBasics, PHPBasics, OOP };
    static void Main()
    {
        Random randGenerator = new Random();
        Console.Write("Input the number of people. ");
        int peopleCount = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Person[] people = new Person[peopleCount];
        List<CurrentStudent> students = new List<CurrentStudent>();

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("People");
        Console.WriteLine(new string('-', 40));

        int studentID = 0;
        for (int index = 0; index < peopleCount; index++)
        {
            string firstName = ((firstNames)randGenerator.Next(9)).ToString();
            string lastName = ((lastNames)randGenerator.Next(9)).ToString();
            string type = ((types)randGenerator.Next(6)).ToString();
            int age = randGenerator.Next(80);
            double averageGrade = (randGenerator.NextDouble() * 4) + 2;
            string course = ((courses)randGenerator.Next(5)).ToString();

            switch (type)
            {
                case "JuniorTrainer":
                    people[index] = new JuniorTrainer(firstName, lastName, age);
                    break;
                case "SeniorTrainer":
                    people[index] = new SeniorTrainer(firstName, lastName, age);
                    break;
                case "GraduateStudent":
                    people[index] = new GraduateStudent(firstName, lastName, age, studentID, averageGrade);
                    studentID++;
                    break;
                case "DropoutStudent":
                    people[index] = new DropoutStudent(firstName, lastName, age, studentID, averageGrade, "Being lazy...");
                    studentID++;
                    break;
                case "OnlineStudent":
                    people[index] = new OnlineStudent(firstName, lastName, age, studentID, averageGrade, course);
                    students.Add(new OnlineStudent(firstName, lastName, age, studentID, averageGrade, course));
                    studentID++;
                    break;
                default:
                    int numberOfVisits = randGenerator.Next(125);
                    people[index] = new OnsiteStudent(firstName, lastName, age, studentID, averageGrade, course, numberOfVisits);
                    students.Add(new OnsiteStudent(firstName, lastName, age, studentID, averageGrade, course, numberOfVisits));
                    studentID++;
                    break;
            }

            Console.WriteLine(people[index].ToString());
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Current Students Ranking");
        Console.WriteLine(new string('-', 40));

        students = students.OrderBy(s => s.AverageGrade).ToList();
        foreach (CurrentStudent student in students)
        {
            Console.WriteLine(student.ToString());
            Console.WriteLine();
        }
        
    }
}
