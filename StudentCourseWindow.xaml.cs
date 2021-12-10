using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
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

    public void ShowEditStudentCourseView(MyDatabase db, NewOrEdit mode, StudentCourse stuCourse, Student student)
    {
      EditStudentCourseWindow view = new EditStudentCourseWindow(db, mode, stuCourse, student, null);
      view.Closed += (object sender, EventArgs e) =>
      {
        controller.LoadAllStudentCourses();
      };
      view.ShowDialog();
    }

    public void UpdateStudentCourseData(IEnumerable<StudentCourse> data)
    {
      DgCourse.ItemsSource = data;
    }

    private void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
      controller.LoadAllStudentCourses();
    }

    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
      controller.AddStudentCourse();
      controller.LoadAllStudentCourses();
    }

    private void BtnEdit_Click(object sender, RoutedEventArgs e)
    {
      if (DgCourse.SelectedIndex != -1)
      {
        controller.EditStudentCourse((StudentCourse)DgCourse.SelectedItem);
        controller.LoadAllStudentCourses();
      }
    }

    private void BtnRemove_Click(object sender, RoutedEventArgs e)
    {
      if (DgCourse.SelectedIndex != -1)
      {
        controller.RemoveStudentCourse((StudentCourse)DgCourse.SelectedItem);
        controller.LoadAllStudentCourses();
      }
    }
  }
}
