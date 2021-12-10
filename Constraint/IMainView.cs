using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IMainView
  {
    void UpdateStudentData(IEnumerable<Student> data);
    void ShowStudentCourseView(MyDatabase db, Student stu);
    void UpdateCourseData(IEnumerable<Course> data);
    void ShowCourseStudentView(MyDatabase db, Course course);
  }
}
