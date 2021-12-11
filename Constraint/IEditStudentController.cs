using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IEditStudentController
  {
    Task SaveAsync(Student stu);
  }
}
