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
    private Student stu;
    private Course course;

    public EditStudentCourseController(IEditStudentCourseView view, NewOrEdit mode, StudentCourse stuCourse, Student stu, Course course)
    {
      this.view = view;
      this.mode = mode;
      this.stuCourse = stuCourse;

      Task.Run(async () =>
      {
        var courses = await MyDatabase.Instance.CourseDao.GetAllAsync();
        if (mode == NewOrEdit.Edit)
        {
          view.Dispatcher.Invoke(() => view.UpdateCourseItems(courses, courses.First(c => c.Number == stuCourse.CourseNumber)));
        }
        else
        {
          if (course != null)
          {
            view.Dispatcher.Invoke(() => view.UpdateCourseItems(courses, courses.First(c => c.Number == course.Number)));
          }
          else
          {
            view.Dispatcher.Invoke(() => view.UpdateCourseItems(courses, null));
          }
        }
      });
    }

    public async Task OnStuClsAndStuNumChangedAsync(int stuCls, int stuNum)
    {
      var stu = await MyDatabase.Instance.StudentDao.GetOneByClsAndNumberAsync(stuCls, stuNum);
      if (stu != null)
      {
        view.UpdateStudentName(stu.Name);
      }
    }

    public Task SaveAsync(StudentCourse stuCourse)
    {
      if (mode == NewOrEdit.New)
      {
        return MyDatabase.Instance.StudentCourseDao.InsertOneAsync(stuCourse);
      }
      else
      {
        return MyDatabase.Instance.StudentCourseDao.UpdateOneAsync(stuCourse);
      }
    }
  }
}
