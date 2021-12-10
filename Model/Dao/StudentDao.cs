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

    public async Task InsertOne(Student stu)
    {
      string sql = "INSERT INTO S(SCLASS, SNO, SNAME, SSEX, SAGE, SDEPT) VALUES (@cls, @number, @name, @sex, @age, @dept);";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      cmd.Parameters.AddWithValue("cls", stu.Cls);
      cmd.Parameters.AddWithValue("number", stu.Number);
      cmd.Parameters.AddWithValue("name", stu.Name);
      cmd.Parameters.AddWithValue("sex", stu.Sex);
      cmd.Parameters.AddWithValue("age", stu.Age);
      cmd.Parameters.AddWithValue("dept", stu.Dept);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task UpdateOne(Student stu)
    {
      string sql = "UPDATE S SET SNAME = @name, SSEX = @sex, SAGE = @age, SDEPT = @dept WHERE SCLASS = @cls AND SNO = @number;";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      cmd.Parameters.AddWithValue("cls", stu.Cls);
      cmd.Parameters.AddWithValue("number", stu.Number);
      cmd.Parameters.AddWithValue("name", stu.Name);
      cmd.Parameters.AddWithValue("sex", stu.Sex);
      cmd.Parameters.AddWithValue("age", stu.Age);
      cmd.Parameters.AddWithValue("dept", stu.Dept);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task DeleteOne(Student stu)
    {
      string sql = "DELETE FROM S WHERE S.SCLASS = @stuCls AND S.SNO = @stuNumber";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      cmd.Parameters.AddWithValue("stuCls", stu.Cls);
      cmd.Parameters.AddWithValue("stuNumber", stu.Number);

      await cmd.ExecuteNonQueryAsync();
    }
  }
}
