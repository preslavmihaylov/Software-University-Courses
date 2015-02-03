using System;
using System.Linq;
class HumanWorkerStudentDemo
{
    static Random randGenerator = new Random();
    enum firstNames { Gosho, Pesho, Penko, Asen, Cvetan, Vasil, Chochko, Strahil, Rambo };
    enum lastNames { Georgiev, Pesholiev, Penkaliev, Asenov, Cvetanov, Vasilev, Chochkov, Strahilev, Rambonev };
    static void Main()
    {
        Student[] students = new Student[10];
        Worker[] workers = new Worker[10];

        for (int index = 0; index < 10; index++)
        {
            string studentFirstName = ((firstNames)randGenerator.Next(9)).ToString();
            string studentLastName = ((lastNames)randGenerator.Next(9)).ToString();
            string studentFacultyNumber = (randGenerator.Next(1000000000) + 1000000000).ToString();

            students[index] = new Student(studentFirstName, studentLastName, studentFacultyNumber);

            string workerFirstName = ((firstNames)randGenerator.Next(9)).ToString();
            string workerLastName = ((lastNames)randGenerator.Next(9)).ToString();
            double weekSalary = randGenerator.NextDouble() * 1000 + 1000;
            int workHours = randGenerator.Next(5) + 5;

            workers[index] = new Worker(workerFirstName, workerLastName, weekSalary, workHours);
        }

        workers = workers.OrderBy(w => w.MoneyPerHour()).ToArray();
        students = students.OrderBy(s => s.FacultyNumber).ToArray();

        Human[] humans = new Human[workers.Length + students.Length];
        int humansCounter = 0;

        Console.WriteLine("Workers sorted: ");
        for (int index = 0; index < workers.Length; index++)
        {
            humans[humansCounter] = workers[index];
            humansCounter++;
            Console.WriteLine(workers[index].FirstName + " " + workers[index].LastName + " --> " + workers[index].MoneyPerHour());
        }

        Console.WriteLine();
        Console.WriteLine("Students sorted:");
        for (int index = 0; index < students.Length; index++)
        {
            humans[humansCounter] = students[index];
            humansCounter++;
            Console.WriteLine(students[index].FirstName + " " + students[index].LastName + " --> " + students[index].FacultyNumber);
        }

        humans = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToArray();

        Console.WriteLine();
        Console.WriteLine("Humans sorted: ");
        for (int index = 0; index < humans.Length; index++)
        {
            Console.WriteLine(humans[index].FirstName + " " + humans[index].LastName);
        }
    }
}