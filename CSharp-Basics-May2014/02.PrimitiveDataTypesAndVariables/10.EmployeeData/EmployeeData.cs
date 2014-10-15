using System;
class EmployeeData
{
    static void Main()
    {
        Console.WriteLine("Input first name");
        string firstName=Console.ReadLine();

        Console.WriteLine("Input last name:");
        string lastName=Console.ReadLine();

        Console.WriteLine("Input age:");
        int age= int.Parse(Console.ReadLine());
        while (age>100 || age < 0)
        {
         
            Console.WriteLine("Please input valid age:");
            age = int.Parse(Console.ReadLine());
           
        }

        Console.WriteLine(@"Input gender (m/f):");
        string gender = Console.ReadLine();
        while (gender != "m" && gender != "f")
        {
            Console.WriteLine("Please input valid gender:");
            gender = Console.ReadLine();
        }

        Console.WriteLine("Input personal ID number:");
        string personalID = Console.ReadLine();
        while (personalID.Length < 10 || personalID.Length > 10)
        {
            Console.WriteLine("Input valid personal ID number:");
            personalID = Console.ReadLine();
        }

        Console.WriteLine("Input employee number:");
        long employeeNumber = long.Parse(Console.ReadLine());
        while (employeeNumber < 27560000 || employeeNumber > 27569999)
        {
            Console.WriteLine("Please input valid employee number:");
            employeeNumber = long.Parse(Console.ReadLine());
        }

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("First Name: {0}", firstName);
        Console.WriteLine("Last Name: {0}", lastName);
        Console.WriteLine("Age: {0}", age);
        Console.WriteLine("Gender: {0}", gender);
        Console.WriteLine("Personal ID: {0}", personalID);
        Console.WriteLine("Employee Number: {0}", employeeNumber);
    }
}

