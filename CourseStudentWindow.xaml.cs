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

    public void UpdateStudentCourseData(IEnumerable<StudentCourse> data)
    {
      DgStudent.ItemsSource = data;
    }

    private void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
      controller.LoadAllStudentCourses();
    }
  }
}
