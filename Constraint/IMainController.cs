using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IMainController
  {
    void LoadAllStudents();
    void SearchStudentByNumber(int number);
    void ViewStudentDetail(Student stu);
    void LoadAllCourses();
    void SearchCourseByNumber(int number);
    void ViewCourseDetail(Course course);
  }
}
