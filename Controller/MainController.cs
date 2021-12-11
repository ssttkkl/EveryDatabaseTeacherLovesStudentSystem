using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

    public async Task LoadAllCoursesAsync()
    {
      var result = await MyDatabase.Instance.CourseDao.GetAllAsync();
      view.UpdateCourseData(result);
    }

    public async Task LoadAllStudentsAsync()
    {
      var result = await MyDatabase.Instance.StudentDao.GetAllAsync();
      view.UpdateStudentData(result);
    }

    public async Task SearchCourseByNumberAsync(int number)
    {
      var result = await MyDatabase.Instance.CourseDao.GetByNumberAsync(number);
      view.UpdateCourseData(result);
    }

    public async Task SearchStudentByNumberAsync(int number)
    {
      var result = await MyDatabase.Instance.StudentDao.GetByNumberAsync(number);
      view.UpdateStudentData(result);
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

    public Task RemoveStudentAsync(Student stu)
    {
      return MyDatabase.Instance.StudentDao.DeleteOneAsync(stu);
    }

    public void AddCourse()
    {
      view.ShowEditCourseView(Constraint.Utils.NewOrEdit.New, null);
    }

    public void EditCourse(Course course)
    {
      view.ShowEditCourseView(Constraint.Utils.NewOrEdit.Edit, course);
    }

    public Task RemoveCourseAsync(Course course)
    {
      return MyDatabase.Instance.CourseDao.DeleteOneAsync(course);
    }

    public void Import(string fileName)
    {
      MyDatabase.Instance.Import(fileName);
    }

    public void Export(string fileName)
    {
      MyDatabase.Instance.Export(fileName);
    }
  }
}
