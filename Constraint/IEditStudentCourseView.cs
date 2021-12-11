using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IEditStudentCourseView : IView
  {
    void UpdateCourseItems(IEnumerable<Course> courses, Course selectedCourse);
    void UpdateStudentName(string studentName);
  }
}
