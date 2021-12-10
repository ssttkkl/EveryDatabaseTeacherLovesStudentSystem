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

    public void LoadAllStudentCourses()
    {
      Task<IEnumerable<StudentCourse>> task = MyDatabase.Instance.StudentCourseDao.GetByStudent(stu);
      task.Wait();
      view.UpdateStudentCourseData(task.Result);
    }

    public void AddStudentCourse()
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.New, null, stu);
    }

    public void EditStudentCourse(StudentCourse stuCourse)
    {
      view.ShowEditStudentCourseView(Constraint.Utils.NewOrEdit.Edit, stuCourse, stu);
    }

    public void RemoveStudentCourse(StudentCourse stuCourse)
    {
      Task task = MyDatabase.Instance.StudentCourseDao.DeleteOne(stuCourse);
      task.Wait();
    }
  }
}
