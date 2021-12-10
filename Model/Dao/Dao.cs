using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public abstract class Dao
  {
    protected MySqlConnection conn;

    public Dao(MySqlConnection conn)
    {
      this.conn = conn;
    }
  }
}
