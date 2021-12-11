using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IMainController
  {
    Task LoadAllStudentsAsync();
    Task SearchStudentByNumberAsync(int number);
    void AddStudent();
    void EditStudent(Student stu);
    Task RemoveStudentAsync(Student stu);
    void ViewStudentDetail(Student stu);
    Task LoadAllCoursesAsync();
    Task SearchCourseByNumberAsync(int number);
    void AddCourse();
    void EditCourse(Course course);
    Task RemoveCourseAsync(Course course);
    void ViewCourseDetail(Course course);
    void Import(string fileName);
    void Export(string fileName);
  }
}
