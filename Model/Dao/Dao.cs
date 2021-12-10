using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public abstract class Dao
  {
    protected MyDatabase db;

    public Dao(MyDatabase db)
    {
      this.db = db;
    }
  }
}
