using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Controller
{
  public class EditStudentCourseController : IEditStudentCourseController
  {
    private IEditStudentCourseView view;
    private NewOrEdit mode;
    private StudentCourse stuCourse;

    public EditStudentCourseController(IEditStudentCourseView view, NewOrEdit mode, StudentCourse stuCourse)
    {
      this.view = view;
      this.mode = mode;
      this.stuCourse = stuCourse;

      Task<IEnumerable<Course>> task = MyDatabase.Instance.CourseDao.GetAllAsync();
      task.Wait();
      view.UpdateCourseItems(task.Result);
    }

    public void OnStuClsAndStuNumChanged(int stuCls, int stuNum)
    {
      Task<Student> task = MyDatabase.Instance.StudentDao.GetOneByClsAndNumberAsync(stuCls, stuNum);
      task.Wait();
      Student stu = task.Result;
      if (stu != null)
      {
        view.UpdateStudentName(stu.Name);
      }
    }

    public void Save(StudentCourse stuCourse)
    {
      Task task;
      if (mode == NewOrEdit.New)
      {
        task = MyDatabase.Instance.StudentCourseDao.InsertOneAsync(stuCourse);
      }
      else
      {
        task = MyDatabase.Instance.StudentCourseDao.UpdateOneAsync(stuCourse);
      }
      task.Wait();
    }
  }
}
