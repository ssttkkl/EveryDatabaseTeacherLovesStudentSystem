using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  class StudentCourseController : IStudentCourseController
  {
    private IStudentCourseView view;
    public Student stu { get; private set; }

    public StudentCourseController(IStudentCourseView view, Student stu)
    {
      this.view = view;
      this.stu = stu;
    }

    public async Task LoadAllStudentCoursesAsync()
    {
      var result = await MyDatabase.Instance.StudentCourseDao.GetByStudentAsync(stu);
      view.UpdateStudentCourseData(result);
    }

    public void AddStudentCourse()
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.New, null, stu);
    }

    public void EditStudentCourse(StudentCourse stuCourse)
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.Edit, stuCourse, stu);
    }

    public Task RemoveStudentCourseAsync(StudentCourse stuCourse)
    {
      return MyDatabase.Instance.StudentCourseDao.DeleteOneAsync(stuCourse);
    }
  }
}
