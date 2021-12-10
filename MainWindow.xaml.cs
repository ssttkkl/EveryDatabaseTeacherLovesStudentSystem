using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, IMainView
  {
    private IMainController controller;

    public MainWindow()
    {
      InitializeComponent();
      controller = new MainController(this);
      controller.LoadAllStudents();
      controller.LoadAllCourses();
    }

    public void UpdateStudentData(IEnumerable<Student> data)
    {
      DgStudent.ItemsSource = data;
    }

    public void UpdateCourseData(IEnumerable<Course> data)
    {
      DgCourse.ItemsSource = data;
    }

    public void ShowStudentCourseView(MyDatabase db, Student stu)
    {
      StudentCourseWindow view = new StudentCourseWindow(db, stu);
      view.Show();
    }

    public void ShowCourseStudentView(MyDatabase db, Course course)
    {
      CourseStudentWindow view = new CourseStudentWindow(db, course);
      view.Show();
    }

    private void BtnStuRefresh_Click(object sender, RoutedEventArgs e)
    {
      controller.LoadAllStudents();
    }

    private void BtnRefreshCourse_Click(object sender, RoutedEventArgs e)
    {
      controller.LoadAllCourses();
    }

    private void BtnSearchStu_Click(object sender, RoutedEventArgs e)
    {
      if (int.TryParse(TbStuNum.Text, out int num))
      {
        controller.SearchStudentByNumber(num);
      }
      else
      {
        MessageBox.Show("请输入正确的学号", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private void BtnSearchCourse_Click(object sender, RoutedEventArgs e)
    {
      if (int.TryParse(TbCourseNum.Text, out int num))
      {
        controller.SearchCourseByNumber(num);
      }
      else
      {
        MessageBox.Show("请输入正确的序号", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private void BtnViewStu_Click(object sender, RoutedEventArgs e)
    {
      if (DgStudent.SelectedIndex != -1)
      {
        controller.ViewStudentDetail((Student)DgStudent.SelectedItem);
      }
    }

    private void BtnViewCourse_Click(object sender, RoutedEventArgs e)
    {
      if (DgCourse.SelectedIndex != -1)
      {
        controller.ViewCourseDetail((Course)DgCourse.SelectedItem);
      }
    }
  }
}
