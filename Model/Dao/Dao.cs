using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public abstract class Dao
  {
    protected MySqlConnection conn;
    protected abstract string CreateTableSql { get; }

    public Dao(MySqlConnection conn)
    {
      this.conn = conn;
    }

    internal async Task InitializeAsync()
    {
      try
      {
        MySqlCommand cmd = new MySqlCommand(CreateTableSql, conn);
        await cmd.ExecuteNonQueryAsync();
      }
      catch (MySqlException)
      {
        // pass
      }
    }
  }
}
