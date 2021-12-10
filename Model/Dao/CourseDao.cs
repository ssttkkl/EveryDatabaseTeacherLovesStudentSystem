using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public class CourseDao : Dao
  {
    public CourseDao(MySqlConnection conn) : base(conn)
    {
      try
      {
        string sql = "CREATE TABLE C(CNO INT PRIMARY KEY, CNAME VARCHAR(20), CPNO INT, CCREDIT INT);";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
      }
      catch (MySqlException)
      {
        // pass
      }
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
      string sql = "SELECT C.CNO, C.CNAME, C.CPNO, C.CCREDIT, C2.CNAME FROM C " +
        "LEFT JOIN C C2 ON C.CPNO = C2.CNO;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
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
      MySqlCommand cmd = new MySqlCommand(sql, conn);
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

    public async Task InsertOne(Course course)
    {
      string sql = "INSERT INTO C(CNO, CNAME, CPNO, CCREDIT) VALUES (@number, @name, @prevCourseNumber, @credit);";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("number", course.Number);
      cmd.Parameters.AddWithValue("name", course.Name);
      cmd.Parameters.AddWithValue("prevCourseNumber", course.PrevCourseNumber);
      cmd.Parameters.AddWithValue("credit", course.Credit);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task UpdateOne(Course course)
    {
      string sql = "UPDATE C SET CNAME = @name, CPNO = @prevCourseNumber, CCREDIT = @credit WHERE CNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("number", course.Number);
      cmd.Parameters.AddWithValue("name", course.Name);
      cmd.Parameters.AddWithValue("prevCourseNumber", course.PrevCourseNumber);
      cmd.Parameters.AddWithValue("credit", course.Credit);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task DeleteOne(Course course)
    {
      string sql = "DELETE FROM C WHERE C.CNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("number", course.Number);

      await cmd.ExecuteNonQueryAsync();
    }
  }
}
