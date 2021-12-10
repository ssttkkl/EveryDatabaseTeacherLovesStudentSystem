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
    private MyDatabase db;
    public Course course { get; private set; }

    public CourseStudentController(ICourseStudentView view, MyDatabase db, Course course)
    {
      this.view = view;
      this.db = db;
      this.course = course;
    }

    public void LoadAllStudentCourses()
    {
      Task<IEnumerable<StudentCourse>> task = db.StudentCourseDao.GetByCourse(course);
      task.Wait();
      view.UpdateStudentCourseData(task.Result);
    }
    public void AddStudentCourse()
    {
      view.ShowEditStudentCourseView(db, Constraint.Utils.NewOrEdit.New, null, course);
    }

    public void EditStudentCourse(StudentCourse stuCourse)
    {
      view.ShowEditStudentCourseView(db, Constraint.Utils.NewOrEdit.Edit, stuCourse, course);
    }

    public void RemoveStudentCourse(StudentCourse stuCourse)
    {
      Task task = db.StudentCourseDao.DeleteOne(stuCourse);
      task.Wait();
    }
  }
}
