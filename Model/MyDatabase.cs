using EveryDatabaseTeacherLovesStudentSystem.Model.Dao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EveryDatabaseTeacherLovesStudentSystem.Model
{
  public class MyDatabase
  {
    internal MySqlConnection conn = null;
    public StudentDao StudentDao { get; private set; }
    public CourseDao CourseDao { get; private set; }
    public StudentCourseDao StudentCourseDao { get; private set; }

    private string server, user, passwd, database;
    private int port;

    public async Task OpenConnectionAsync(string server, int port, string user, string passwd, string database)
    {
      this.server = server;
      this.port = port;
      this.user = user;
      this.passwd = passwd;
      this.database = database;

      conn = new MySqlConnection
      {
        ConnectionString = string.Format("server={0};port={1};user={2};password={3};", server, port, user, passwd, database)
      };
      await conn.OpenAsync();

      StudentDao = new StudentDao(conn);
      CourseDao = new CourseDao(conn);
      StudentCourseDao = new StudentCourseDao(conn);

      try
      {
        string sql = "CREATE DATABASE " + database;
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        await cmd.ExecuteNonQueryAsync();
      }
      catch (Exception)
      {
        // pass
      }

      await conn.ChangeDatabaseAsync(database);

      await StudentDao.InitializeAsync();
      await CourseDao.InitializeAsync();
      await StudentCourseDao.InitializeAsync();
    }

    public bool ConnectionOpened
    {
      get
      {
        return conn != null;
      }
    }

    public void Import(string fileName, string mySqlFileName = "mysql")
    {
      using FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
      using StreamReader reader = new StreamReader(stream);

      using var process = new Process();
      process.StartInfo.FileName = "cmd.exe";
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.RedirectStandardInput = true;
      process.Start();

      process.StandardInput.WriteLine(string.Format("\"{0}\" -u{1} -p{2} {3} < \"{4}\"", mySqlFileName, user, passwd, database, fileName));
      process.StandardInput.WriteLine("exit");

      process.WaitForExit();
      process.Close();
    }

    public void Export(string fileName, string mySqlDumpFileName = "mysqldump")
    {
      using FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

      using var process = new Process();
      process.StartInfo.FileName = mySqlDumpFileName;
      process.StartInfo.Arguments = string.Format("-u{0} -p{1} {2}", user, passwd, database);
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();

      process.StandardOutput.BaseStream.CopyTo(stream);

      process.WaitForExit();
      process.Close();
    }

    private static MyDatabase INSTANCE = null;

    private static readonly object LOCKER = new object();

    public static MyDatabase Instance
    {
      get
      {
        if (INSTANCE == null)
        {
          lock (LOCKER)
          {
            if (INSTANCE == null)
            {
              INSTANCE = new MyDatabase();
            }
          }
        }
        return INSTANCE;
      }
    }
  }
}
