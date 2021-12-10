using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public class StudentDao : Dao
  {
    public StudentDao(MyDatabase db) : base(db) { }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
      string sql = "SELECT SCLASS, SNO, SNAME, SSEX, SAGE, SDEPT FROM S;";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      using DbDataReader reader = await cmd.ExecuteReaderAsync();

      LinkedList<Student> result = new LinkedList<Student>();
      while (await reader.ReadAsync())
      {
        result.AddLast(new Student
        (
          reader.GetInt32(0),
          reader.GetInt32(1),
          reader.GetString(2),
          reader.GetString(3),
          reader.GetInt32(4),
          reader.GetString(5)
        ));
      }
      return result;
    }

    public async Task<IEnumerable<Student>> GetByNumber(int number)
    {
      string sql = "SELECT SCLASS, SNO, SNAME, SSEX, SAGE, SDEPT FROM S WHERE SNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      cmd.Parameters.AddWithValue("number", number);
      using DbDataReader reader = await cmd.ExecuteReaderAsync();

      LinkedList<Student> result = new LinkedList<Student>();
      while (await reader.ReadAsync())
      {
        result.AddLast(new Student
        (
          reader.GetInt32(0),
          reader.GetInt32(1),
          reader.GetString(2),
          reader.GetString(3),
          reader.GetInt32(4),
          reader.GetString(5)
        ));
      }
      return result;
    }
  }
}
