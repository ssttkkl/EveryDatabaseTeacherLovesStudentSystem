using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public class StudentDao : Dao
  {
    protected override string CreateTableSql =>
      "CREATE TABLE S(" +
      "SCLASS INT, " +
      "SNO INT, " +
      "SNAME VARCHAR(10), " +
      "SSEX VARCHAR(2), " +
      "SAGE INT, " +
      "SDEPT CHAR(2), " +
      "PRIMARY KEY(SCLASS, SNO)" +
      ");";

    public StudentDao(MySqlConnection conn) : base(conn) { }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
      string sql = "SELECT SCLASS, SNO, SNAME, SSEX, SAGE, SDEPT FROM S;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
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

    public async Task<IEnumerable<Student>> GetByNumberAsync(int number)
    {
      string sql = "SELECT SCLASS, SNO, SNAME, SSEX, SAGE, SDEPT FROM S WHERE SNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
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

    public async Task<Student> GetOneByClsAndNumberAsync(int cls, int number)
    {
      string sql = "SELECT SCLASS, SNO, SNAME, SSEX, SAGE, SDEPT FROM S WHERE SCLASS = @cls AND SNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("cls", cls);
      cmd.Parameters.AddWithValue("number", number);
      using DbDataReader reader = await cmd.ExecuteReaderAsync();

      if (await reader.ReadAsync())
      {
        return new Student
        (
          reader.GetInt32(0),
          reader.GetInt32(1),
          reader.GetString(2),
          reader.GetString(3),
          reader.GetInt32(4),
          reader.GetString(5)
        );
      }
      else
      {
        return null;
      }
    }

    public async Task InsertOneAsync(Student stu)
    {
      string sql = "INSERT INTO S(SCLASS, SNO, SNAME, SSEX, SAGE, SDEPT) VALUES (@cls, @number, @name, @sex, @age, @dept);";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("cls", stu.Cls);
      cmd.Parameters.AddWithValue("number", stu.Number);
      cmd.Parameters.AddWithValue("name", stu.Name);
      cmd.Parameters.AddWithValue("sex", stu.Sex);
      cmd.Parameters.AddWithValue("age", stu.Age);
      cmd.Parameters.AddWithValue("dept", stu.Dept);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task UpdateOneAsync(Student stu)
    {
      string sql = "UPDATE S SET SNAME = @name, SSEX = @sex, SAGE = @age, SDEPT = @dept WHERE SCLASS = @cls AND SNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("cls", stu.Cls);
      cmd.Parameters.AddWithValue("number", stu.Number);
      cmd.Parameters.AddWithValue("name", stu.Name);
      cmd.Parameters.AddWithValue("sex", stu.Sex);
      cmd.Parameters.AddWithValue("age", stu.Age);
      cmd.Parameters.AddWithValue("dept", stu.Dept);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task DeleteOneAsync(Student stu)
    {
      string sql = "DELETE FROM S WHERE S.SCLASS = @stuCls AND S.SNO = @stuNumber;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("stuCls", stu.Cls);
      cmd.Parameters.AddWithValue("stuNumber", stu.Number);

      await cmd.ExecuteNonQueryAsync();
    }
  }
}
