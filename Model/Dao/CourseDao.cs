using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public class CourseDao : Dao
  {
    public CourseDao(MyDatabase db) : base(db) { }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
      string sql = "SELECT C.CNO, C.CNAME, C.CPNO, C.CCREDIT, C2.CNAME FROM C " +
        "LEFT JOIN C C2 ON C.CPNO = C2.CNO;";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      using DbDataReader reader = await cmd.ExecuteReaderAsync();

      LinkedList<Course> result = new LinkedList<Course>();
      while (await reader.ReadAsync())
      {
        result.AddLast(new Course
        (
          reader.GetInt32(0),
          reader.GetString(1),
          reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
          reader.GetInt32(3),
          reader.IsDBNull(4) ? "" : reader.GetString(4)
        ));
      }
      return result;
    }

    public async Task<IEnumerable<Course>> GetByNumber(int number)
    {
      string sql = "SELECT C.CNO, C.CNAME, C.CPNO, C.CCREDIT, C2.CNAME FROM C " +
        "LEFT JOIN C C2 ON C.CPNO = C2.CNO " +
        "WHERE C.CNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      cmd.Parameters.AddWithValue("number", number);
      using DbDataReader reader = await cmd.ExecuteReaderAsync();

      LinkedList<Course> result = new LinkedList<Course>();
      while (await reader.ReadAsync())
      {
        result.AddLast(new Course
        (
          reader.GetInt32(0),
          reader.GetString(1),
          reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
          reader.GetInt32(3),
          reader.IsDBNull(4) ? "" : reader.GetString(4)
        ));
      }
      return result;
    }
  }
}
