using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  class CourseStudentController : ICourseStudentController
  {
    private ICourseStudentView view;
    public Course course { get; private set; }

    public CourseStudentController(ICourseStudentView view, Course course)
    {
      this.view = view;
      this.course = course;
    }

    public async Task LoadAllStudentCoursesAsync()
    {
      var result = await MyDatabase.Instance.StudentCourseDao.GetByCourseAsync(course);
      view.UpdateStudentCourseData(result);
    }
    public void AddStudentCourse()
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.New, null, course);
    }

    public void EditStudentCourse(StudentCourse stuCourse)
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.Edit, stuCourse, course);
    }

    public Task RemoveStudentCourseAsync(StudentCourse stuCourse)
    {
      return MyDatabase.Instance.StudentCourseDao.DeleteOneAsync(stuCourse);
    }
  }
}
