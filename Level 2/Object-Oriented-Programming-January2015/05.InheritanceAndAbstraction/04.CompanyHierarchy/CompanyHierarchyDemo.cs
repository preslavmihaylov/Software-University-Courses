using System;

class CompanyHierarchyDemo
{
    static void Main()
    {
        Employee[] employees = new Employee[3];

        SalesEmployee stilian = new SalesEmployee("Stilian", "Stoikov", 1000, "Sales");
        stilian.Sales.Add(new Sales("Chocolate", 20));
        stilian.Sales.Add(new Sales("Bananas", 10));
        employees[0] = stilian;

        Developer georgi = new Developer("Georgi", "Georgiev", 1500, "Production");
        georgi.Projects.Add(new Project("Tetris game", new DateTime(2014,12,15), "open"));
        georgi.Projects.Add(new Project("Diablo 3", new DateTime(2013, 11, 10), "closed"));
        employees[1] = georgi;

        Manager theBoss = new Manager("Mihail", "Svetoslavov", 5000, "Marketing");
        theBoss.Subordinates.Add(georgi);
        theBoss.Subordinates.Add(stilian);
        employees[2] = theBoss;

        foreach (var employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }
}
