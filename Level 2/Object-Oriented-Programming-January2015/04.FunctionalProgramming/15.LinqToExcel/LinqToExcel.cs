using ExcelLibrary.SpreadSheet;
using QiHe.CodeLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

class LinqToExcel
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../Resources/Students-data.txt");
        List<Student> studentsList = new List<Student>();

        Workbook workbook = new Workbook();
        Worksheet worksheet = new Worksheet("Students-Data");

        string[] firstRow = reader.ReadLine().Split('\t');

        for (int i = 0; i < firstRow.Length; i++)
        {
            worksheet.Cells[0, i] = new Cell(firstRow[i]);
            worksheet.Cells.ColumnWidth[0, (ushort)i] = 5000;
        }

        worksheet.Cells[0, 12] = new Cell("Course result");
        worksheet.Cells.ColumnWidth[0, 12] = 5000;

        while (!reader.EndOfStream)
        {
            string[] input = reader.ReadLine().Split('\t');
            int id = int.Parse(input[0]);
            string firstName = input[1];
            string lastName = input[2];
            string email = input[3];
            string gender = input[4];
            string type = input[5];
            int examResult = int.Parse(input[6]);
            int homeworksSent = int.Parse(input[7]);
            int homeworksEvaluated = int.Parse(input[8]);
            double teamworkScore = double.Parse(input[9]);
            int attendancesCound = int.Parse(input[10]);
            double bonus = double.Parse(input[11]);
         
            studentsList.Add(new Student(id, firstName, lastName, email, gender,
                                         type, examResult, homeworksSent, homeworksEvaluated,
                                         teamworkScore, attendancesCound, bonus));
        }

        var sortedOnsiteStudents = studentsList
            .Select(s => s)
            .Where(s => s.Type == "Online")
            .OrderByDescending(s => s.CalculateResult());

        int rowCount = 1;
        foreach (var student in sortedOnsiteStudents)
	    {
            worksheet.Cells[rowCount, 0] = new Cell(student.ID);
            worksheet.Cells[rowCount, 1] = new Cell(student.FirstName);
            worksheet.Cells[rowCount, 2] = new Cell(student.LastName);
            worksheet.Cells[rowCount, 3] = new Cell(student.Email);
            worksheet.Cells[rowCount, 4] = new Cell(student.Gender);
            worksheet.Cells[rowCount, 5] = new Cell(student.Type);
            worksheet.Cells[rowCount, 6] = new Cell(student.ExamResult);
            worksheet.Cells[rowCount, 7] = new Cell(student.HomeworksSent);
            worksheet.Cells[rowCount, 8] = new Cell(student.HomeworksEvaluated);
            worksheet.Cells[rowCount, 9] = new Cell(student.TeamworkScore);
            worksheet.Cells[rowCount, 10] = new Cell(student.AttendancesCount);
            worksheet.Cells[rowCount, 11] = new Cell(student.Bonus);
            worksheet.Cells[rowCount, 12] = new Cell(student.CalculateResult());

            rowCount++;
	    }

        string xlsFile = "../../Resources/students-data.xls";
        workbook.Worksheets.Add(worksheet);
        workbook.Save(xlsFile);
    }
}
