using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Controller;
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
  /// EditStudentCourseWindow.xaml 的交互逻辑
  /// </summary>
  public partial class EditStudentCourseWindow : Window, IEditStudentCourseView
  {
    private IEditStudentCourseController controller;
    public EditStudentCourseWindow(NewOrEdit mode, StudentCourse stuCourse, Student stu, Course course)
    {
      InitializeComponent();
      controller = new EditStudentCourseController(this, mode, stuCourse, stu, course);

      if (stu != null)
      {
        TbStuCls.IsEnabled = false;
        TbStuNum.IsEnabled = false;
        TbStuCls.Text = stu.Cls.ToString();
        TbStuNum.Text = stu.Number.ToString();
        LbStuName.Content = stu.Name;
      }
      else if (course != null)
      {
        CbCourse.IsEnabled = false;
      }

      if (mode == NewOrEdit.Edit)
      {
        TbStuCls.IsEnabled = false;
        TbStuNum.IsEnabled = false;
        CbCourse.IsEnabled = false;
        if (stuCourse == null)
        {
          throw new ArgumentNullException(nameof(stuCourse));
        }
        else
        {
          TbStuCls.Text = stuCourse.StudentCls.ToString();
          TbStuNum.Text = stuCourse.StudentNumber.ToString();
          TbGrade.Text = stuCourse.Grade.ToString();
        }
      }

      TbStuCls.TextChanged += TbStuCls_TbStuNum_TextChanged;
      TbStuNum.TextChanged += TbStuCls_TbStuNum_TextChanged;
    }

    public void UpdateCourseItems(IEnumerable<Course> courses, Course selectedCourse)
    {
      CbCourse.ItemsSource = courses;
      CbCourse.SelectedItem = selectedCourse;
    }

    public void UpdateStudentName(string studentName)
    {
      LbStuName.Content = studentName;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
      int stuCls, stuNum, courseNum, grade;

      if (CbCourse.SelectedIndex != -1)
      {
        courseNum = ((Course)CbCourse.SelectedItem).Number;
      }
      else
      {
        MessageBox.Show("请选择课程", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
      }

      if (int.TryParse(TbStuCls.Text, out stuCls) && int.TryParse(TbStuNum.Text, out stuNum) && int.TryParse(TbGrade.Text, out grade))
      {
        try
        {
          await controller.SaveAsync(new StudentCourse(stuCls, stuNum, courseNum, grade));
        }
        catch (Exception exc)
        {
          MessageBox.Show(exc.Message, "发生错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        Close();
      }
      else
      {
        MessageBox.Show("请输入正确的选课信息", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private async void TbStuCls_TbStuNum_TextChanged(object sender, TextChangedEventArgs e)
    {
      int stuCls, stuNum;
      if (int.TryParse(TbStuCls.Text, out stuCls) && int.TryParse(TbStuNum.Text, out stuNum))
      {
        await controller.OnStuClsAndStuNumChangedAsync(stuCls, stuNum);
      }
    }
  }
}
