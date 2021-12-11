using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IEditCourseView : IView
  {
    void UpdatePrevCourseItems(IEnumerable<Course> courses, Course selectedCourse);
  }
}
