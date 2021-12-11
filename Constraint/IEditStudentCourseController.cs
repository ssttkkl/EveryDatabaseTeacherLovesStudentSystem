using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  interface IEditStudentCourseController
  {
    Task SaveAsync(StudentCourse stuCourse);
    Task OnStuClsAndStuNumChangedAsync(int stuCls, int stuNum);
  }
}
