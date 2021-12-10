﻿using EveryDatabaseTeacherLovesStudentSystem.Model.Dao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace EveryDatabaseTeacherLovesStudentSystem.Model
{
  public class MyDatabase
  {
    internal MySqlConnection conn = null;
    public StudentDao StudentDao { get; private set; }
    public CourseDao CourseDao { get; private set; }
    public StudentCourseDao StudentCourseDao { get; private set; }

    private MyDatabase()
    {
    }

    public void OpenConnection(string server, int port, string user, string passwd, string database)
    {
      conn = new MySqlConnection();
      conn.ConnectionString = string.Format("server={0};port={1};user={2};password={3};database={4}", server, port, user, passwd, database);
      conn.Open();

      StudentDao = new StudentDao(conn);
      CourseDao = new CourseDao(conn);
      StudentCourseDao = new StudentCourseDao(conn);
    }

    public bool ConnectionOpened
    {
      get
      {
        return conn != null;
      }
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
