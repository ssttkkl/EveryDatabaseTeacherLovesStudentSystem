using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  interface IEditStudentCourseController
  {
    void Save(StudentCourse stuCourse);
    void OnStuClsAndStuNumChanged(int stuCls, int stuNum);
  }
}
