using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public class StudentCourseDao : Dao
  {
    public StudentCourseDao(MyDatabase db) : base(db) { }

    public async Task<IEnumerable<StudentCourse>> GetByStudent(Student stu)
    {
      string sql = "SELECT SC.SCLASS, SC.SNO, SC.CNO, SC.GRADE, C.CNAME, C.CCREDIT FROM SC, C " +
        "WHERE SC.CNO = C.CNO AND SC.SCLASS = @stuCls AND SC.SNO = @stuNumber;";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      cmd.Parameters.AddWithValue("stuCls", stu.Cls);
      cmd.Parameters.AddWithValue("stuNumber", stu.Number);
      using DbDataReader reader = await cmd.ExecuteReaderAsync();

      LinkedList<StudentCourse> result = new LinkedList<StudentCourse>();
      while (await reader.ReadAsync())
      {
        result.AddLast(new StudentCourse
        (
          reader.GetInt32(0),
          reader.GetInt32(1),
          reader.GetInt32(2),
          reader.GetInt32(3),
          stu.Name,
          reader.GetString(4),
          reader.GetInt32(5)
        ));
      }
      return result;
    }

    public async Task<IEnumerable<StudentCourse>> GetByCourse(Course course)
    {
      string sql = "SELECT SC.SCLASS, SC.SNO, SC.CNO, SC.GRADE, S.SNAME FROM SC, S " +
        "WHERE SC.SCLASS = S.SCLASS AND SC.SNO = S.SNO AND SC.CNO = @courseNumber;";
      MySqlCommand cmd = new MySqlCommand(sql, db.conn);
      cmd.Parameters.AddWithValue("courseNumber", course.Number);
      using DbDataReader reader = await cmd.ExecuteReaderAsync();

      LinkedList<StudentCourse> result = new LinkedList<StudentCourse>();
      while (await reader.ReadAsync())
      {
        result.AddLast(new StudentCourse
        (
          reader.GetInt32(0),
          reader.GetInt32(1),
          reader.GetInt32(2),
          reader.GetInt32(3),
          reader.GetString(4),
          course.Name,
          course.Credit
        ));
      }
      return result;
    }
  }
}
