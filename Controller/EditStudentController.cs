using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Controller
{
  public class EditStudentController : IEditStudentController
  {
    private IEditStudentView view;
    private NewOrEdit mode;
    private Student stu;

    public EditStudentController(IEditStudentView view, NewOrEdit mode, Student stu)
    {
      this.view = view;
      this.mode = mode;
      this.stu = stu;
    }

    public void Save(Student stu)
    {
      Task task;
      if (mode == NewOrEdit.New)
      {
        task = MyDatabase.Instance.StudentDao.InsertOneAsync(stu);
      }
      else
      {
        task = MyDatabase.Instance.StudentDao.UpdateOneAsync(stu);
      }
      task.Wait();
    }
  }
}
