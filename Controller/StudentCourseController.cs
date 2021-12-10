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

    public void AddStudentCourse()
    {
      view.ShowEditStudentCourseView(db, Constraint.Utils.NewOrEdit.New, null, stu);
    }

    public void EditStudentCourse(StudentCourse stuCourse)
    {
      view.ShowEditStudentCourseView(db, Constraint.Utils.NewOrEdit.Edit, stuCourse, stu);
    }

    public void RemoveStudentCourse(StudentCourse stuCourse)
    {
      Task task = db.StudentCourseDao.DeleteOne(stuCourse);
      task.Wait();
    }
  }
}
