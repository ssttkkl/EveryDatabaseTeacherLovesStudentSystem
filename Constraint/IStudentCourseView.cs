using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  interface IStudentCourseView
  {
    void UpdateStudentCourseData(IEnumerable<StudentCourse> data);
    void ShowEditStudentCourseView(MyDatabase db, NewOrEdit mode, StudentCourse stuCourse, Student student);
  }
}
