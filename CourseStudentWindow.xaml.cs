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
    public CourseStudentWindow(Course course)
    {
      InitializeComponent();

      LbNumber.Content = course.Number;
      LbName.Content = course.Name;
      LbPrevCourseName.Content = course.PrevCourseName;
      LbCredit.Content = course.Credit;

      controller = new CourseStudentController(this, course);
      controller.LoadAllStudentCoursesAsync();
    }

    public void ShowEditStudentCourseView(NewOrEdit mode, StudentCourse stuCourse, Course course)
    {
      EditStudentCourseWindow view = new EditStudentCourseWindow(mode, stuCourse, null, course);
      view.Closed += async (sender, e) =>
      {
        await controller.LoadAllStudentCoursesAsync();
      };
      view.ShowDialog();
    }

    public void UpdateStudentCourseData(IEnumerable<StudentCourse> data)
    {
      DgStudent.ItemsSource = data;
    }

    private async void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
      await controller.LoadAllStudentCoursesAsync();
    }

    private async void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
      controller.AddStudentCourse();
      await controller.LoadAllStudentCoursesAsync();
    }

    private async void BtnEdit_Click(object sender, RoutedEventArgs e)
    {
      if (DgStudent.SelectedIndex != -1)
      {
        controller.EditStudentCourse((StudentCourse)DgStudent.SelectedItem);
        await controller.LoadAllStudentCoursesAsync();
      }
    }

    private async void BtnRemove_Click(object sender, RoutedEventArgs e)
    {
      if (DgStudent.SelectedIndex != -1)
      {
        await controller.RemoveStudentCourseAsync((StudentCourse)DgStudent.SelectedItem);
        await controller.LoadAllStudentCoursesAsync();
      }
    }
  }
}
