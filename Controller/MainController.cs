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

    public MainController(IMainView view)
    {
      this.view = view;
    }

    public void LoadAllCourses()
    {
      Task<IEnumerable<Course>> task = MyDatabase.Instance.CourseDao.GetAllAsync();
      task.Wait();
      view.UpdateCourseData(task.Result);
    }

    public void LoadAllStudents()
    {
      Task<IEnumerable<Student>> task = MyDatabase.Instance.StudentDao.GetAllAsync();
      task.Wait();
      view.UpdateStudentData(task.Result);
    }

    public void SearchCourseByNumber(int number)
    {
      Task<IEnumerable<Course>> task = MyDatabase.Instance.CourseDao.GetByNumber(number);
      task.Wait();
      view.UpdateCourseData(task.Result);
    }

    public void SearchStudentByNumber(int number)
    {
      Task<IEnumerable<Student>> task = MyDatabase.Instance.StudentDao.GetByNumber(number);
      task.Wait();
      view.UpdateStudentData(task.Result);
    }

    public void ViewStudentDetail(Student stu)
    {
      view.ShowStudentCourseView(stu);
    }

    public void ViewCourseDetail(Course course)
    {
      view.ShowCourseStudentView(course);
    }

    public void AddStudent()
    {
      view.ShowEditStudentView(Constraint.Utils.NewOrEdit.New, null);
    }

    public void EditStudent(Student stu)
    {
      view.ShowEditStudentView(Constraint.Utils.NewOrEdit.Edit, stu);
    }

    public void RemoveStudent(Student stu)
    {
      Task task = MyDatabase.Instance.StudentDao.DeleteOne(stu);
      task.Wait();
    }

    public void AddCourse()
    {
      view.ShowEditCourseView(Constraint.Utils.NewOrEdit.New, null);
    }

    public void EditCourse(Course course)
    {
      view.ShowEditCourseView(Constraint.Utils.NewOrEdit.Edit, course);
    }

    public void RemoveCourse(Course course)
    {
      Task task = MyDatabase.Instance.CourseDao.DeleteOne(course);
      task.Wait();
    }
  }
}
