using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Atanas", "Petrov", 18, 100014, "+3592-650", "destroyer@abv.bg", new List<int>() { 2, 2, 4, 5, 6}, 1),
            new Student("Angel", "Anastasov", 15, 100116, "+3592-650", "acho@abv.bg", new List<int>() { 3, 3, 6, 4, 2, 2}, 1),
            new Student("Ivan", "Ivanov", 14, 100255, "2-650", "ivo@abv.bg", new List<int>() { 2, 6, 6, 5}, 2),
            new Student("Georgi", "Georgiev", 20, 100322, "555-555", "gosho@abv.bg", new List<int>() { 3, 3, 3, 3}, 2),
            new Student("Boris", "Hristov", 19, 100414, "02-567", "borko@gmail.com", new List<int>() { 6, 6, 6, 6}, 1),
            new Student("Boris", "Borisov", 14, 100556, "321-222", "boris@gmail.com", new List<int>() { 4, 5, 5, 6}, 3),
            new Student("Penka", "Petrova", 22, 100611, "02-555", "penka@yahoo.com", new List<int>() { 2, 4, 5, 5}, 3)
        };

        Console.WriteLine("04. Grouped by GroupID 2:");
        printList(students.Where(c => c.GroupID == 2));
        Console.WriteLine();

        Console.WriteLine("05. Students where the first name is before the last name: ");
        printList(students.Where(c => c.FirstName.CompareTo(c.LastName) == -1));
        Console.WriteLine();

        Console.WriteLine("06.Students's first and last name whose ages are between 18 and 24: ");
        var studentsFilteredByAge = students
            .Where(c => c.Age >= 18 && c.Age <= 24)
            .Select(c => new { c.FirstName, c.LastName } );

        printList(studentsFilteredByAge);
        Console.WriteLine();

        Console.WriteLine("07. Students ordered by first and last names descending: ");
        printList(students.OrderByDescending(c => c.FirstName).ThenByDescending(c => c.LastName));
        Console.WriteLine();

        Console.WriteLine("08. Students filtered by email '@abv.bg': ");
        printList(students.Where(c => c.Email.EndsWith("@abv.bg")));
        Console.WriteLine();

        Console.WriteLine("09. Students filtered by phone starting with 02/+3592/+359 2: ");
        var studentsFilteredByPhone = students
            .Where(c => c.Phone.StartsWith("02") || 
                    c.Phone.StartsWith("+359 2") || 
                    c.Phone.StartsWith("+3592"));
        printList(studentsFilteredByPhone);
        Console.WriteLine();

        Console.WriteLine("10. Excellent Students: ");
        var excellentStudents = students
            .Where(c => c.Marks.Contains(6))
            .Select(delegate(Student c)
            {
                string marks = Student.ConcatMarks(c.Marks);
                return new
                {
                    FullName = c.FirstName + " " + c.LastName,
                    Marks = marks
                };
            });

        printList(excellentStudents);
        Console.WriteLine();

        Console.WriteLine("11. Weak Students: ");
        var weakStudents = students.Where(delegate(Student c)
        {
            int count = 0;
            foreach (var mark in c.Marks)
            {
                if (mark == 2)
                {
                    count++;
                }
            }
            return count == 2;
        });

        printList(weakStudents);
        Console.WriteLine();

        Console.WriteLine("12. Students enrolled in 2014: ");
        var enrolledStudents = students.Where(delegate(Student c) 
        {
            return c.FacultyNumber[4].ToString() == "1" && c.FacultyNumber[5].ToString() == "4";
        });

        printList(enrolledStudents);
        Console.WriteLine();

        Console.WriteLine("13. Grouped students: ");
        var groupedStudents = 
            from s in students
              group s by s.GroupID into groups
              select new { gr = groups.Key, st = groups.ToList() };
        foreach (var group in groupedStudents)
        {
            Console.WriteLine("Group " + group.gr + ": ");
            foreach (var student in group.st)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }
        Console.WriteLine();

        Console.WriteLine("14. Students joined to specialities: ");
        List<StudentSpeciality> specialities = new List<StudentSpeciality>()
        {
            new StudentSpeciality("Web developer", 100322),
            new StudentSpeciality("Java developer", 100014),
            new StudentSpeciality("Web developer", 100322),
            new StudentSpeciality("Web developer", 100116),
            new StudentSpeciality("Java Developer", 100556),
            new StudentSpeciality(".NET Developer", 100414),
            new StudentSpeciality(".NET Developer", 100255)
        };

        var joinedList = from st in students
		    join spec in specialities on st.FacultyNumber equals spec.FacultyNumber
		    select new { st.FirstName, st.LastName, st.FacultyNumber, spec.Speciality };

        foreach (var student in joinedList)
        {
            Console.WriteLine("Name: " + student.FirstName + " " + student.LastName + Environment.NewLine +
                "Faculty number: " + student.FacultyNumber + Environment.NewLine + 
                "Speciality: " + student.Speciality);
            Console.WriteLine();
        }
    }

    private static void printList<T>(IEnumerable<T> students)
    {
        foreach (var item in students)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
