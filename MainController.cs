using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  class MainController : IMainController
  {
    private IMainView view;
    private MyDatabase db = new MyDatabase("localhost", 3306, "root", "hwl1098042114", "for_study");

    public MainController(IMainView view)
    {
      this.view = view;
      db.Open();
    }

    public void LoadAllCourses()
    {
      Task<IEnumerable<Course>> task = db.CourseDao.GetAllAsync();
      task.Wait();
      view.UpdateCourseData(task.Result);
    }

    public void LoadAllStudents()
    {
      Task<IEnumerable<Student>> task = db.StudentDao.GetAllAsync();
      task.Wait();
      view.UpdateStudentData(task.Result);
    }

    public void SearchCourseByNumber(int number)
    {
      Task<IEnumerable<Course>> task = db.CourseDao.GetByNumber(number);
      task.Wait();
      view.UpdateCourseData(task.Result);
    }

    public void SearchStudentByNumber(int number)
    {
      Task<IEnumerable<Student>> task = db.StudentDao.GetByNumber(number);
      task.Wait();
      view.UpdateStudentData(task.Result);
    }

    public void ViewStudentDetail(Student stu)
    {
      view.ShowStudentCourseView(db, stu);
    }

    public void ViewCourseDetail(Course course)
    {
      view.ShowCourseStudentView(db, course);
    }
  }
}
