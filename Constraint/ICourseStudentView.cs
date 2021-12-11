using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  interface ICourseStudentView : IView
  {
    void UpdateStudentCourseData(IEnumerable<StudentCourse> data);
    void ShowEditStudentCourseView(NewOrEdit mode, StudentCourse stuCourse, Course course);
  }
}
