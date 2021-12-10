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
  }
}
