using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
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

      Task<IEnumerable<Course>> task = MyDatabase.Instance.CourseDao.GetAllAsync();
      task.Wait();
      var courses = task.Result;
      if (mode == NewOrEdit.Edit)
      {
        courses = courses.Where(c => c.Number != course.Number);
      }
      view.UpdatePrevCourseItems(courses);
    }

    public void Save(Course course)
    {
      Task task;
      if (mode == NewOrEdit.New)
      {
        task = MyDatabase.Instance.CourseDao.InsertOne(course);
      }
      else
      {
        task = MyDatabase.Instance.CourseDao.UpdateOne(course);
      }
      task.Wait();
    }
  }
}
