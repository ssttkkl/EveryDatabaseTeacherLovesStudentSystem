using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  interface ICourseStudentView
  {
    void UpdateStudentCourseData(IEnumerable<StudentCourse> data);
  }
}
