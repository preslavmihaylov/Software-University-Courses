using System;
using System.Collections;
using System.Linq;
using _00.Employees_Exercise;

class EmployeesExample
{
    static void Main()
    {
        var context = new SoftUniEntities();

        // Problem 3.	Employee Queries
        // Step 1 - Employees with Salary Over 50 000

        var firstQuery = context.Employees
            .Where(e => e.Salary > 50000)
            .Select(e => e.FirstName);

        Console.WriteLine("Employees with salaries higher than 50000:");
        foreach (var employeeFirstName in firstQuery)
        {
            Console.WriteLine(employeeFirstName);
        }
        Console.WriteLine();

        // Step 2 - Employees from Reserch and Development

        var secondQuery = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            });

        Console.WriteLine("Employees from Reserch and Development");
        foreach (var employee in secondQuery)
        {
            Console.WriteLine("{0} {1} from {2} - ${3:F2}",
                employee.FirstName,
                employee.LastName, 
                employee.DepartmentName,
                employee.Salary);
        }

        // Problem 4.	Adding a New Address and Updating Employee

        var address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownID = 4
        };

        // context.Addresses.Add(address);

        var nakovEmployee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        // nakovEmployee.Address = address;

        context.SaveChanges();

        Console.WriteLine();
        Console.WriteLine("Nakov address:");
        Console.WriteLine(nakovEmployee.Address.AddressText);

        // Problem 5.	Deleting Project by Id

        var project = context.Projects.Find(2);


        var employeesWithGivenProject = project.Employees;

        foreach (var employee in employeesWithGivenProject)
        {
            employee.Projects.Remove(project);
        }

        context.Projects.Remove(project);

        // context.SaveChanges();
    }
}