using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IMainView : IView
  {
    void UpdateStudentData(IEnumerable<Student> data);
    void ShowEditStudentView(NewOrEdit mode, Student stu);
    void ShowStudentCourseView(Student stu);
    void UpdateCourseData(IEnumerable<Course> data);
    void ShowCourseStudentView(Course course);
    void ShowEditCourseView(NewOrEdit mode, Course course);
  }
}
