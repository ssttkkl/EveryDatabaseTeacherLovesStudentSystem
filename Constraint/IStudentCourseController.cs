using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IStudentCourseController
  {
    Task LoadAllStudentCoursesAsync();
    void AddStudentCourse();
    void EditStudentCourse(StudentCourse stuCourse);
    Task RemoveStudentCourseAsync(StudentCourse stuCourse);
  }
}
