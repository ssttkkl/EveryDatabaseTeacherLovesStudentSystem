using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Model
{
  public class StudentCourse
  {
    public int StudentCls { get; }
    public int StudentNumber { get; }
    public int CourseNumber { get; }
    public int Grade { get; }
    public string StudentName { get; }
    public string CourseName { get; }
    public int? Credit { get; }

    public StudentCourse(int studentCls, int studentNumber, int courseNumber, int grade, string studentName = null, string courseName = null, int? credit = null)
    {
      StudentCls = studentCls;
      StudentNumber = studentNumber;
      CourseNumber = courseNumber;
      Grade = grade;
      StudentName = studentName;
      CourseName = courseName;
      Credit = credit;
    }
  }
}
