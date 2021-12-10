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
    private MyDatabase db;
    private NewOrEdit mode;
    private Student stu;

    public EditStudentController(IEditStudentView view, MyDatabase db, NewOrEdit mode, Student stu)
    {
      this.view = view;
      this.db = db;
      this.mode = mode;
      this.stu = stu;
    }

    public void Save(Student stu)
    {
      Task task;
      if (mode == NewOrEdit.New)
      {
        task = db.StudentDao.InsertOne(stu);
      }
      else
      {
        task = db.StudentDao.UpdateOne(stu);
      }
      task.Wait();
    }
  }
}
