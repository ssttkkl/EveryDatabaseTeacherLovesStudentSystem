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
    void AddStudent();
    void EditStudent(Student stu);
    void RemoveStudent(Student stu);
    void ViewStudentDetail(Student stu);
    void LoadAllCourses();
    void SearchCourseByNumber(int number);
    void AddCourse();
    void EditCourse(Course course);
    void RemoveCourse(Course course);
    void ViewCourseDetail(Course course);
  }
}
