using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using Microsoft.Win32;
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

      LoginWindow login = new LoginWindow();
      login.Closed += async (sender, e) => {
        controller = new MainController(this);
        await controller.LoadAllStudentsAsync();
        await controller.LoadAllCoursesAsync();
      };
      login.ShowDialog();
    }

    public void UpdateStudentData(IEnumerable<Student> data)
    {
      DgStudent.ItemsSource = data;
    }

    public void UpdateCourseData(IEnumerable<Course> data)
    {
      DgCourse.ItemsSource = data;
    }

    public void ShowStudentCourseView(Student stu)
    {
      StudentCourseWindow view = new StudentCourseWindow(stu);
      view.Show();
    }

    public void ShowCourseStudentView(Course course)
    {
      CourseStudentWindow view = new CourseStudentWindow(course);
      view.Show();
    }

    public void ShowEditStudentView(NewOrEdit mode, Student stu)
    {
      EditStudentWindow view = new EditStudentWindow( mode, stu);
      view.Closed += async (sender, e) =>
      {
        await controller.LoadAllStudentsAsync();
      };
      view.ShowDialog();
    }

    public void ShowEditCourseView(NewOrEdit mode, Course course)
    {
      EditCourseWindow view = new EditCourseWindow(mode, course);
      view.Closed += async (sender, e) =>
      {
        await controller.LoadAllCoursesAsync();
      };
      view.ShowDialog();
    }

    private async void BtnStuRefresh_Click(object sender, RoutedEventArgs e)
    {
      await controller.LoadAllStudentsAsync();
    }

    private async void BtnRefreshCourse_Click(object sender, RoutedEventArgs e)
    {
      await controller.LoadAllCoursesAsync();
    }

    private async void BtnSearchStu_Click(object sender, RoutedEventArgs e)
    {
      if (int.TryParse(TbStuNum.Text, out int num))
      {
        await controller.SearchStudentByNumberAsync(num);
      }
      else
      {
        MessageBox.Show("请输入正确的学号", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private async void BtnSearchCourse_Click(object sender, RoutedEventArgs e)
    {
      if (int.TryParse(TbCourseNum.Text, out int num))
      {
        await controller.SearchCourseByNumberAsync(num);
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

    private async void BtnRemoveStu_Click(object sender, RoutedEventArgs e)
    {
      if (DgStudent.SelectedIndex != -1)
      {
        MessageBoxResult result = MessageBox.Show("确定删除该学生信息吗？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
          try
          {
            await controller.RemoveStudentAsync((Student)DgStudent.SelectedItem);
            await controller.LoadAllStudentsAsync();
          }
          catch (Exception exc)
          {
            MessageBox.Show(exc.Message, "发生错误", MessageBoxButton.OK, MessageBoxImage.Error);
          }
        }
      }
    }

    private void BtnAddStu_Click(object sender, RoutedEventArgs e)
    {
      controller.AddStudent();
    }

    private void BtnEditStu_Click(object sender, RoutedEventArgs e)
    {
      if (DgStudent.SelectedIndex != -1)
      {
        controller.EditStudent((Student) DgStudent.SelectedItem);
      }
    }

    private void BtnAddCourse_Click(object sender, RoutedEventArgs e)
    {
      controller.AddCourse();
    }

    private void BtnEditCourse_Click(object sender, RoutedEventArgs e)
    {
      if (DgCourse.SelectedIndex != -1)
      {
        controller.EditCourse((Course)DgCourse.SelectedItem);
      }
    }

    private async void BtnRemoveCourse_Click(object sender, RoutedEventArgs e)
    {
      if (DgCourse.SelectedIndex != -1)
      {
        MessageBoxResult result = MessageBox.Show("确定删除该课程信息吗？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
          try
          {
            await controller.RemoveCourseAsync((Course)DgCourse.SelectedItem);
            await controller.LoadAllCoursesAsync();
          }
          catch (Exception exc)
          {
            MessageBox.Show(exc.Message, "发生错误", MessageBoxButton.OK, MessageBoxImage.Error);
          }
        }
      }
    }

    private async void BtnImport_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.DefaultExt = "sql";
      if (dialog.ShowDialog() == true)
      {
        try
        {
          controller.Import(dialog.FileName);
          MessageBox.Show("导入成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exc)
        {
          MessageBox.Show("导入失败！" + exc.Message, "失败", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        await controller.LoadAllStudentsAsync();
        await controller.LoadAllCoursesAsync();
      }
    }

    private void BtnExport_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.DefaultExt = "sql";
      if (dialog.ShowDialog() == true)
      {
        try
        {
          controller.Export(dialog.FileName);
          MessageBox.Show("导出成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exc)
        {
          MessageBox.Show("导出失败！" + exc.Message, "失败", MessageBoxButton.OK, MessageBoxImage.Error);
        }
      }
    }
  }
}
