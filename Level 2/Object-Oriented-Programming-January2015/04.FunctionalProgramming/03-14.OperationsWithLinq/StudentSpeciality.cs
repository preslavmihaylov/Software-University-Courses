using System;

class StudentSpeciality
{
    public string Speciality { get; set; }
    public string FacultyNumber { get; set; }

    public StudentSpeciality(string speciality, int facultyNumber)
    {
        this.Speciality = speciality;
        this.FacultyNumber = facultyNumber.ToString();
    }
}
