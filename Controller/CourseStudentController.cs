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

    public void LoadAllStudentCourses()
    {
      Task<IEnumerable<StudentCourse>> task = MyDatabase.Instance.StudentCourseDao.GetByCourseAsync(course);
      task.Wait();
      view.UpdateStudentCourseData(task.Result);
    }
    public void AddStudentCourse()
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.New, null, course);
    }

    public void EditStudentCourse(StudentCourse stuCourse)
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.Edit, stuCourse, course);
    }

    public void RemoveStudentCourse(StudentCourse stuCourse)
    {
      Task task = MyDatabase.Instance.StudentCourseDao.DeleteOneAsync(stuCourse);
      task.Wait();
    }
  }
}
