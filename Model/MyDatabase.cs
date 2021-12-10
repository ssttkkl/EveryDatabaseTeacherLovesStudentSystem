using EveryDatabaseTeacherLovesStudentSystem.Model.Dao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace EveryDatabaseTeacherLovesStudentSystem.Model
{
  public class MyDatabase
  {
    internal MySqlConnection conn;
    public StudentDao StudentDao { get; }
    public CourseDao CourseDao { get; }
    public StudentCourseDao StudentCourseDao { get; }
    public MyDatabase(string server, int port, string user, string passwd, string database)
    {
      conn = new MySqlConnection();
      conn.ConnectionString = string.Format("server={0};port={1};user={2};password={3};database={4}", server, port, user, passwd, database);

      StudentDao = new StudentDao(this);
      CourseDao = new CourseDao(this);
      StudentCourseDao = new StudentCourseDao(this);
    }

    public void Open()
    {
      conn.Open();
    }
  }
}
