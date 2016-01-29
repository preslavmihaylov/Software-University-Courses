namespace _01.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    class StudentsAndCoursesExample
    {
        private static SortedDictionary<string, SortedSet<Student>> data;

        static void Main()
        {
            InitializeComponents();
            ParseInput();
            PrintOutput();
        }

        private static void InitializeComponents()
        {
            data = new SortedDictionary<string, SortedSet<Student>>();
        }

        private static void ParseInput()
        {
            using (StreamReader reader = new StreamReader("../../students.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string currentLine = reader.ReadLine();

                    string[] lineParams = currentLine.Split('|');

                    string firstName = lineParams[0].Trim();
                    string lastName = lineParams[1].Trim();
                    string course = lineParams[2].Trim();

                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };

                    PersistData(student, course);
                }
            }
        }

        private static void PrintOutput()
        {
            foreach (var courseData in data)
            {
                Console.Write("{0}: ", courseData.Key);
                Console.WriteLine(string.Join(", ", courseData.Value));
            }
        }

        private static void PersistData(Student student, string course)
        {
            if (!data.ContainsKey(course))
            {
                data[course] = new SortedSet<Student>();
            }

            data[course].Add(student);
        }
    }
}