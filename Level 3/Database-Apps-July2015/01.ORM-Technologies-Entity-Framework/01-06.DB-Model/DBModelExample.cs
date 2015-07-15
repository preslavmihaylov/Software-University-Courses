using System;
using System.Diagnostics;
using _01_06.DB_Model;
using System.Linq;

class DBModelExample
{
    static void Main()
    {
        // Problem 1. DAO Class Test
        Employee employee = EmployeeDAO.FindByKey(2);
        Console.WriteLine(employee.LastName);
        employee.LastName = "Costner";
        
        // EmployeeDAO.Modify(employee);

        employee = new Employee();
        employee.FirstName = "Georgi";
        employee.LastName = "Georgiev";
        employee.JobTitle = "Production Technician";
        employee.DepartmentID = 7;
        employee.ManagerID = 16;
        employee.Salary = 2000;
        employee.AddressID = 166;
        employee.HireDate = DateTime.Now;

        // EmployeeDAO.Add(employee);
        employee = EmployeeDAO.FindByKey(4);
        // EmployeeDAO.Delete(employee);

        // Problem 3.	Database Search Queries

        // 1.	Find all employees who have projects started in the time period
        // 2001 - 2003 (inclusive). 
        // Select the project's name, start date, end date and manager name.

        var projects = EmployeeDAO.Context.Projects
            .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
            .Select(p => new
            {
                ProjectName = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate
                // There is no project manager in the database
            });

        Console.WriteLine();
        Console.WriteLine("Projects started between 2001 and 2003");
        Console.WriteLine();

        foreach (var project in projects)
        {
            Console.WriteLine(project.ProjectName + " "  + project.StartDate + " " + project.EndDate);
        }

        // 2.	Find all addresses, ordered by the number of employees 
        // who live there (descending), then by town name (ascending). 
        // Take only the first 10 addresses and select their address text, 
        // town name and employee count. 

        var addresses = EmployeeDAO.Context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .Select(a => new
            {
                AddressText = a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count
            }).Take(10);

        foreach (var address in addresses)
        {
            Console.WriteLine("{0} - {1} - {2} employees",
                address.AddressText, 
                address.TownName, 
                address.EmployeeCount);
        }

        // 3.	Get an employee by id (e.g. 147). 
        // Select only his/her first name, last name, 
        // job title and projects (only their names). 
        // The projects should be ordered by name (ascending).

        var employeesSelected = EmployeeDAO.Context.Employees
            .Where(e => e.EmployeeID == 147)
            .Select(e => new
            {
                JobTitle = e.JobTitle,
                Projects = e.Projects.OrderBy(p => p.Name).Select(p => p.Name)
            });

        Console.WriteLine();
        Console.WriteLine("Employee with projects");
        Console.WriteLine();
        foreach (var employeeSelected in employeesSelected)
        {
            Console.WriteLine(" --- " + employeeSelected.JobTitle);
            foreach (var projectName in employeeSelected.Projects)
            {
                Console.WriteLine(projectName);
            }
        }

        // 4.	Find all departments with more than 5 employees. 
        // Order them by employee count (ascending). 
        // Select the department name, manager name and first name, 
        // last name, hire date and job title of every employee.

        var departments = EmployeeDAO.Context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerName = EmployeeDAO.Context.Employees
                    .Where(e => e.EmployeeID == d.ManagerID)
                    .Select(e => e.LastName).FirstOrDefault(),
                Employees = d.Employees.Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    HireDate = e.HireDate,
                    JobTitle = e.JobTitle
                })
            });

        Console.WriteLine();
        Console.WriteLine("Departments with more than 5 employees with their employees");
        Console.WriteLine();
        foreach (var department in departments)
        {
            Console.WriteLine(" ------------- {0}, Manager: {1}",
                department.DepartmentName, department.ManagerName);

            foreach (var departmentEmployee in department.Employees)
            {
                Console.WriteLine(" - {0} {1} - {2} - HireDate: {3}",
                    departmentEmployee.FirstName,
                    departmentEmployee.LastName,
                    departmentEmployee.JobTitle,
                    departmentEmployee.HireDate.ToString("dd/MM/yyyy"));
            }
            Console.WriteLine();
        }

        // Problem 4.	Native SQL Query
        // Find all employees who have projects with start date in the year 2002. 
        // Select only their first name. 
        // Solve this task by using both LINQ query and native SQL query through the context. 

        Stopwatch sw = new Stopwatch();

        sw.Start();

        var linqResults = EmployeeDAO.Context.Employees
            .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
            .Select(e => e.FirstName);

        Console.WriteLine(string.Join(", ", linqResults));
        Console.WriteLine();
        Console.WriteLine("LINQ Query time: {0}", sw.Elapsed);
        Console.WriteLine();

        sw.Restart();

        var sqlQueryResults = EmployeeDAO.Context
            .Database
            .SqlQuery<string>("select e.FirstName " +
                              "from Employees e " +
                              "join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID " +
                              "join Projects p on ep.ProjectID = p.ProjectID " +
                              "where DATEPART(YEAR, p.StartDate) = 2002");

        Console.WriteLine(string.Join(", ", sqlQueryResults));
        Console.WriteLine();
        Console.WriteLine("SQL Query time: {0}", sw.Elapsed);
        Console.WriteLine();

        sw.Stop();

        // Problem 5.	Concurrent Database Changes with EF

        var ctx1 = new SoftUniEntities();
        var ctx2 = new SoftUniEntities();

        var employeeToUpdate1 = ctx1.Employees.Find(7);
        var employeeToUpdate2 = ctx2.Employees.Find(7);
        employeeToUpdate1.FirstName = "Change 1";
        employeeToUpdate2.FirstName = "Change 2";

        ctx1.SaveChanges();
        ctx2.SaveChanges();

        // Without concurrency fixed - the last change is submitted
        // in the other case - the first one is submitted
        // Problem 6.	Call a Stored Procedure

        Console.WriteLine();
        Console.WriteLine("Stored Procedure result:");
        Console.WriteLine();

        var result = EmployeeDAO.GetProjectsByEmployee(employeeToUpdate1);
        foreach (var project in result)
        {
            Console.WriteLine("{0} - {1} - {2}",
                project.Name, 
                project.StartDate.ToString("dd/MM/yyyy"),
                project.EndDate != null ? project.EndDate.ToString() : "(NULL)");
        }
    }
}