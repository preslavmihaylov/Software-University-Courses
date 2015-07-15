using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using _01_06.DB_Model;

static class EmployeeDAO
{
    public static SoftUniEntities Context = new SoftUniEntities();

    public static ObjectResult<usp_projects_by_employee_Result> GetProjectsByEmployee(Employee employee)
    {
        return Context.usp_projects_by_employee(employee.EmployeeID);
    }

    public static void Add(Employee employee)
    {
        Context.Employees.Add(employee);
        Context.SaveChanges();
    }

    public static Employee FindByKey(object key)
    {
        return Context.Employees.Find(key);
    }

    public static void Modify(Employee employee)
    {
        Context.SaveChanges();
    }

    public static void Delete(Employee employee)
    {
        var projects = employee.Projects;
        var departments = employee.Departments;
        var managedEmployees = employee.Employees1;

        var managedDepartments = Context.Departments
            .Where(d => d.ManagerID == employee.ManagerID);

        foreach (var managedDepartment in managedDepartments)
        {
            managedDepartment.ManagerID = null;
        }

        foreach (var managedEmployee in managedEmployees)
        {
            managedEmployee.ManagerID = null;
        }

        foreach (var project in projects)
        {
            project.Employees.Remove(employee);
        }

        foreach (var department in departments)
        {
            department.Employees.Remove(employee);
        }

        Context.Employees.Remove(employee);
        Context.SaveChanges();
    }
}