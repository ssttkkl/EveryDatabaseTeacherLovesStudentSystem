using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  /// <summary>
  /// StudentCourseWindow.xaml 的交互逻辑
  /// </summary>
  public partial class StudentCourseWindow : Window, IStudentCourseView
  {
    private IStudentCourseController controller;

    public StudentCourseWindow(MyDatabase db, Student stu)
    {
      InitializeComponent();
      controller = new StudentCourseController(this, db, stu);
      controller.LoadAllStudentCourses();
    }

    public void UpdateStudentCourseData(IEnumerable<StudentCourse> data)
    {
      DgCourse.ItemsSource = data;
    }

    private void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
      controller.LoadAllStudentCourses();
    }
  }
}
