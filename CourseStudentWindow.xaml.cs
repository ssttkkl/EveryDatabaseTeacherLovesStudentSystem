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
  /// CourseStudentWindow.xaml 的交互逻辑
  /// </summary>
  public partial class CourseStudentWindow : Window, ICourseStudentView
  {
    private ICourseStudentController controller;
    public CourseStudentWindow(MyDatabase db, Course course)
    {
      InitializeComponent();
      controller = new CourseStudentController(this, db, course);
      controller.LoadAllStudentCourses();
    }

    public void ShowEditStudentCourseView(MyDatabase db, NewOrEdit mode, StudentCourse stuCourse, Course course)
    {
      EditStudentCourseWindow view = new EditStudentCourseWindow(db, mode, stuCourse, null, course);
      view.Closed += (object sender, EventArgs e) =>
      {
        controller.LoadAllStudentCourses();
      };
      view.ShowDialog();
    }

    public void UpdateStudentCourseData(IEnumerable<StudentCourse> data)
    {
      DgStudent.ItemsSource = data;
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
      if (DgStudent.SelectedIndex != -1)
      {
        controller.EditStudentCourse((StudentCourse)DgStudent.SelectedItem);
        controller.LoadAllStudentCourses();
      }
    }

    private void BtnRemove_Click(object sender, RoutedEventArgs e)
    {
      if (DgStudent.SelectedIndex != -1)
      {
        controller.RemoveStudentCourse((StudentCourse)DgStudent.SelectedItem);
        controller.LoadAllStudentCourses();
      }
    }
  }
}
