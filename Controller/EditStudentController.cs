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

    public Task SaveAsync(Student stu)
    {
      if (mode == NewOrEdit.New)
      {
        return MyDatabase.Instance.StudentDao.InsertOneAsync(stu);
      }
      else
      {
        return MyDatabase.Instance.StudentDao.UpdateOneAsync(stu);
      }
    }
  }
}
