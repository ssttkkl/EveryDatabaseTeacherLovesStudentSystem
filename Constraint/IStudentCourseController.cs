using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IStudentCourseController
  {
    void LoadAllStudentCourses();
    void AddStudentCourse();
    void EditStudentCourse(StudentCourse stuCourse);
    void RemoveStudentCourse(StudentCourse stuCourse);
  }
}
