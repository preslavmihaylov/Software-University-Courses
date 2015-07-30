
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;

class StudentSystemMain
{
    static void Main()
    {
        Database.SetInitializer(
            new MigrateDatabaseToLatestVersion<SQLServerContext, Configuration>());

        var context = new SQLServerContext();

        // SeedDatabase(context); - Initial Seed

        // 1.	Lists all students and their homework submissions. 
        // Select only their names and for each homework - content and content-type.

        var students = context.Students.Select(s => new
        {
            Name = s.Name,
            Homeworks = s.Homeworks.Select(h => new
            {
                Content = h.Content,
                ContentType = h.ContentType
            })
        });

        foreach (var student in students)
        {
            Console.WriteLine("--- " + student.Name);
            foreach (var homework in student.Homeworks)
            {
                Console.WriteLine(" - " + homework.Content + " - " + homework.ContentType);
            }
        }

        // 2.	List all courses with their corresponding resources. 
        // Select the course name and description and everything for each resource.
        // Order the courses by start date (ascending), then by end date (descending).

        var courses = context.Courses
            .OrderBy(c => c.StartDate)
            .ThenByDescending(c => c.EndDate)
            .Select(c => new
        {
            Name = c.Name,
            Description = c.Description,
            Resources = c.Resources
        });

        Console.WriteLine();
        foreach (var course in courses)
        {
            Console.WriteLine(" --- " + course.Name + " -- " + course.Description);
            foreach (var resource in course.Resources)
            {
                Console.WriteLine(" - " + resource.Name + " - " + resource.URL + " - " + resource.ResourceType);
            }
        }

        // 3.	List all courses with more than 5 resources. 
        // Order them by resources count (descending), then by start date (descending).
        // Select only the course name and the resource count.

        var coursesWithMoreThan5Resources = context.Courses
            .Where(c => c.Resources.Count > 5)
            .OrderByDescending(c => c.Resources.Count)
            .ThenByDescending(c => c.StartDate)
            .Select(c => new
            {
                Name = c.Name,
                ResourcesCount = c.Resources.Count
            });

        Console.WriteLine();
        foreach (var course in coursesWithMoreThan5Resources)
        {
            Console.WriteLine(" --- " + course.Name + " - " + course.ResourcesCount);
        }

        // 4.	List all courses which were active on a given date, 
        // and for each course count the number of students enrolled. 
        // Select the course name, start and end date, course duration 
        // and number of students enrolled. 
        // Order the results by the number of students enrolled (in descending order),
        // then by duration (descending).

        DateTime activeDate = new DateTime(2015, 07, 20);
        var activeCourses = context.Courses
            .Where(c => c.StartDate < activeDate && c.EndDate > activeDate)
            .OrderByDescending(c => c.Students.Count)
            .ThenByDescending(c => EntityFunctions.DiffDays(c.StartDate, c.EndDate))
            .Select(c => new
            {
                Name = c.Name,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Duration = EntityFunctions.DiffDays(c.StartDate, c.EndDate),
                StudentsEnrolledCount = c.Students.Count
            });

        Console.WriteLine();
        foreach (var activeCourse in activeCourses)
        {
            Console.WriteLine(" --- {0} - {1} - {2} - Duration: {3} ---",
                activeCourse.Name,
                activeCourse.StartDate.ToString("dd/MM/yyyy"),
                activeCourse.EndDate.ToString("dd/MM/yyyy"),
                activeCourse.Duration);
        }

        // 5.	For each student, calculate the number of courses she’s enrolled in, 
        // the total price of these courses and the average price per course 
        // for the student. Select the student name, number of courses, 
        // total price and average price. 
        // Order the results by total price (descending), 
        // then by number of courses (descending) 
        // and then by the student’s name (ascending).

        var studentStatistics = context.Students
            .Select(s => new
            {
                Name = s.Name,
                CoursesCount = s.Courses.Count,
                CoursesTotalPrice = s.Courses.Sum(c => c.Price),
                CoursesAveragePrice = s.Courses.Average(c => c.Price)
            })
            .OrderByDescending(s => s.CoursesTotalPrice)
            .ThenByDescending(s => s.CoursesCount)
            .ThenBy(s => s.Name);

        Console.WriteLine();
        foreach (var studentStatistic in studentStatistics)
        {
            Console.WriteLine(" --- {0} - Courses Count: {1}",
                studentStatistic.Name,
                studentStatistic.CoursesCount);
            Console.WriteLine("   -- Total Price: {0} - Average Price: {1}",
                studentStatistic.CoursesTotalPrice,
                studentStatistic.CoursesAveragePrice);
        }
    }

    private static void SeedDatabase(SQLServerContext context)
    {
        var pesho = new Student
        {
            Birthday = new DateTime(1994, 06, 5),
            PhoneNumber = "0892244992",
            RegistrationDate = new DateTime(2014, 06, 11),
            Name = "Pesho"
        };

        var gosho = new Student
        {
            Birthday = new DateTime(1992, 07, 1),
            PhoneNumber = "0892244993",
            RegistrationDate = new DateTime(2013, 06, 11),
            Name = "Gosho"
        };

        var minka = new Student
        {
            Birthday = new DateTime(1984, 06, 5),
            PhoneNumber = "0882244992",
            RegistrationDate = new DateTime(2015, 06, 11),
            Name = "Minka"
        };

        var penka = new Student
        {
            Birthday = new DateTime(1993, 06, 5),
            PhoneNumber = "0893244992",
            RegistrationDate = new DateTime(2013, 06, 11),
            Name = "Minka"
        };

        var menka = new Student
        {
            Birthday = new DateTime(1991, 06, 5),
            PhoneNumber = "0892245992",
            RegistrationDate = new DateTime(2012, 06, 11),
            Name = "Menka"
        };

        var databases = new Course()
        {
            Description = "really cool",
            EndDate = new DateTime(2015, 07, 30),
            Name = "Databases",
            Price = 50.55m,
            StartDate = new DateTime(2015, 06, 15)
        };

        var databaseApps = new Course()
        {
            Description = "really cool course",
            EndDate = new DateTime(2015, 08, 30),
            Name = "Database Apps",
            Price = 100.55m,
            StartDate = new DateTime(2015, 07, 15)
        };

        var systemAdministration = new Course()
        {
            Description = "really hard course",
            EndDate = new DateTime(2014, 08, 30),
            Name = "System Administration",
            Price = 200.55m,
            StartDate = new DateTime(2015, 07, 15)
        };

        databases.Students.Add(pesho);
        databases.Students.Add(gosho);
        databases.Students.Add(minka);

        databaseApps.Students.Add(menka);
        databaseApps.Students.Add(penka);
        databaseApps.Students.Add(minka);

        systemAdministration.Students.Add(pesho);
        systemAdministration.Students.Add(penka);
        systemAdministration.Students.Add(gosho);
        systemAdministration.Students.Add(menka);

        var peshoHomework = new Homework()
        {
            Content = "no homework y'all",
            ContentType = ContentType.Other,
            Course = systemAdministration,
            Student = pesho,
            SubmissionDate = new DateTime(2015, 02, 20)
        };

        var goshoHomework = new Homework()
        {
            Content = "I did it",
            ContentType = ContentType.PDF,
            Course = databases,
            Student = gosho,
            SubmissionDate = new DateTime(2015, 07, 20)
        };

        var minkaHomework = new Homework()
        {
            Content = "Ain't nobody got time fo' this",
            ContentType = ContentType.ZIP,
            Course = databaseApps,
            Student = minka,
            SubmissionDate = new DateTime(2015, 08, 20)
        };

        var menkaHomework = new Homework()
        {
            Content = "Ain't nobody got time fo' this yeah",
            ContentType = ContentType.ZIP,
            Course = systemAdministration,
            Student = menka,
            SubmissionDate = new DateTime(2015, 07, 25)
        };

        var penkaHomework = new Homework()
        {
            Content = "Ain't nobody got time fo' this yeah",
            ContentType = ContentType.ZIP,
            Course = databaseApps,
            Student = penka,
            SubmissionDate = new DateTime(2015, 07, 25)
        };

        var databasesPresentation = new Resource()
        {
            Course = databases,
            Name = "Presentation Databases",
            URL = "http://example.com",
            ResourceType = ResourceType.Presentation
        };

        var databasesHomework = new Resource()
        {
            Course = databases,
            Name = "Homework Databases",
            URL = "http://example.com",
            ResourceType = ResourceType.Document
        };

        var databaseAppsPresentation = new Resource()
        {
            Course = databaseApps,
            Name = "Presentation Database Apps",
            URL = "http://example.com",
            ResourceType = ResourceType.Presentation
        };

        var databaseAppsHomework = new Resource()
        {
            Course = databaseApps,
            Name = "Homework Database Apps",
            URL = "http://example.com",
            ResourceType = ResourceType.Document
        };

        var systemAdministrationPresentation = new Resource()
        {
            Course = systemAdministration,
            Name = "Presentation System Administration",
            URL = "http://example.com",
            ResourceType = ResourceType.Presentation
        };

        var systemAdministrationHomework = new Resource()
        {
            Course = systemAdministration,
            Name = "Homework System Administration",
            URL = "http://example.com",
            ResourceType = ResourceType.Document
        };

        context.Students
            .AddOrUpdate(pesho, gosho, minka, penka, menka);

        context.Courses
            .AddOrUpdate(databases, databaseApps, systemAdministration);

        context.Homeworks
            .AddOrUpdate(
                peshoHomework,
                goshoHomework,
                minkaHomework,
                menkaHomework,
                penkaHomework);

        context.Resources.AddOrUpdate(
            databasesPresentation,
            databasesHomework,
            databaseAppsPresentation,
            databaseAppsHomework,
            systemAdministrationPresentation,
            systemAdministrationHomework
            );
    }
}