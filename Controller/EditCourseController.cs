using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Controller
{
  public class EditCourseController : IEditCourseController
  {
    private IEditCourseView view;
    private NewOrEdit mode;
    private Course course;

    public EditCourseController(IEditCourseView view, NewOrEdit mode, Course course)
    {
      this.view = view;
      this.mode = mode;
      this.course = course;

      Task.Run(async () =>
      {
        var courses = (await MyDatabase.Instance.CourseDao.GetAllAsync());
        if (mode == NewOrEdit.Edit)
        {
          courses = courses.Where(c => c.Number != course.Number);
          if (course.PrevCourseNumber != null)
            view.Dispatcher.Invoke(() => view.UpdatePrevCourseItems(courses, courses.First(c => c.Number == course.PrevCourseNumber)));
          else
          {
            view.Dispatcher.Invoke(() => view.UpdatePrevCourseItems(courses, null));
          }
        }
        else
        {
          view.Dispatcher.Invoke(() => view.UpdatePrevCourseItems(courses, null));
        }
      });
    }

    public Task SaveAsync(Course course)
    {
      if (mode == NewOrEdit.New)
      {
        return MyDatabase.Instance.CourseDao.InsertOneAsync(course);
      }
      else
      {
        return MyDatabase.Instance.CourseDao.UpdateOneAsync(course);
      }
    }
  }
}
