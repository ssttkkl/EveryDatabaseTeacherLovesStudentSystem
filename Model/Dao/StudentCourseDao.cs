using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model.Dao
{
  public class StudentCourseDao : Dao
  {
    public StudentCourseDao(MySqlConnection conn) : base(conn) { }

    public async Task<IEnumerable<StudentCourse>> GetByStudent(Student stu)
    {
      string sql = "SELECT SC.SCLASS, SC.SNO, SC.CNO, SC.GRADE, C.CNAME, C.CCREDIT FROM SC, C " +
        "WHERE SC.CNO = C.CNO AND SC.SCLASS = @stuCls AND SC.SNO = @stuNumber;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
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
      MySqlCommand cmd = new MySqlCommand(sql, conn);
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

    public async Task InsertOne(StudentCourse stuCourse)
    {
      string sql = "INSERT INTO SC(SCLASS, SNO, CNO, GRADE) VALUES (@stuCls, @stuNumber, @courseNumber, @grade);";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("stuCls", stuCourse.StudentCls);
      cmd.Parameters.AddWithValue("stuNumber", stuCourse.StudentNumber);
      cmd.Parameters.AddWithValue("courseNumber", stuCourse.CourseNumber);
      cmd.Parameters.AddWithValue("grade", stuCourse.Grade);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task UpdateOne(StudentCourse stuCourse)
    {
      string sql = "UPDATE SC SET GRADE = @grade WHERE SC.SCLASS = @stuCls AND SC.SNO = @stuNumber AND SC.CNO = @courseNumber;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("stuCls", stuCourse.StudentCls);
      cmd.Parameters.AddWithValue("stuNumber", stuCourse.StudentNumber);
      cmd.Parameters.AddWithValue("courseNumber", stuCourse.CourseNumber);
      cmd.Parameters.AddWithValue("grade", stuCourse.Grade);

      await cmd.ExecuteNonQueryAsync();
    }

    public async Task DeleteOne(StudentCourse stuCourse)
    {
      string sql = "DELETE FROM SC WHERE SC.SCLASS = @stuCls AND SC.SNO = @stuNumber AND SC.CNO = @courseNumber;";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.AddWithValue("stuCls", stuCourse.StudentCls);
      cmd.Parameters.AddWithValue("stuNumber", stuCourse.StudentNumber);
      cmd.Parameters.AddWithValue("courseNumber", stuCourse.CourseNumber);

      await cmd.ExecuteNonQueryAsync();
    }
  }
}
