using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Model
{
  public class Course
  {
    public int Number { get; }
    public string Name { get; }
    public int? PrevCourseNumber { get; }
    public int Credit { get; }

    public string PrevCourseName { get; }

    public Course(int number, string name, int? prevCourseNumber, int credit, string prevCourseName)
    {
      Number = number;
      Name = name ?? throw new ArgumentNullException(nameof(name));
      PrevCourseNumber = prevCourseNumber;
      Credit = credit;
      PrevCourseName = prevCourseName;
    }
  }
}
