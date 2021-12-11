using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace EveryDatabaseTeacherLovesStudentSystem.Constraint
{
  public interface IView
  {
    Dispatcher Dispatcher { get; }
  }
}
