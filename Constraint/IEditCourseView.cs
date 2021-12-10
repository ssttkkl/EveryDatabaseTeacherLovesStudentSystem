using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IEditCourseView
  {
    void UpdatePrevCourseItems(IEnumerable<Course> courses);
  }
}
