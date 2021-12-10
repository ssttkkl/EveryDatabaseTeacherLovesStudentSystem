using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IEditStudentCourseView
  {
    void UpdateCourseItems(IEnumerable<Course> courses);
    void UpdateStudentName(string studentName);
  }
}
