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
    private MyDatabase db;
    public Student stu { get; private set; }

    public StudentCourseController(IStudentCourseView view, MyDatabase db, Student stu)
    {
      this.view = view;
      this.db = db;
      this.stu = stu;
    }

    public void LoadAllStudentCourses()
    {
      Task<IEnumerable<StudentCourse>> task = db.StudentCourseDao.GetByStudent(stu);
      task.Wait();
      view.UpdateStudentCourseData(task.Result);
    }
  }
}
