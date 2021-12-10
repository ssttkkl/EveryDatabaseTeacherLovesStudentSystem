using EveryDatabaseTeacherLovesStudentSystem.Constraint;
using EveryDatabaseTeacherLovesStudentSystem.Constraint.Utils;
using EveryDatabaseTeacherLovesStudentSystem.Controller;
using EveryDatabaseTeacherLovesStudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  /// <summary>
  /// EditCourseWindow.xaml 的交互逻辑
  /// </summary>
  public partial class EditCourseWindow : Window, IEditCourseView
  {
    IEditCourseController controller;
    public EditCourseWindow(NewOrEdit mode, Course course)
    {
      InitializeComponent();
      controller = new EditCourseController(this, mode, course);

      if (mode == NewOrEdit.Edit)
      {
        TbNumber.IsEnabled = false;
        if (course == null)
        {
          throw new ArgumentNullException(nameof(course));
        }
        else
        {
          TbNumber.Text = course.Number.ToString();
          TbName.Text = course.Name;
          TbCredit.Text = course.Credit.ToString();

          if (course.PrevCourseNumber == null)
          {
            CbPrevCourseNull.IsChecked = true;
          }
          else
          {
            for (int i = 0; i < CbPrevCourse.Items.Count; i++)
            {
              if (((Course)CbPrevCourse.Items[i]).Number == course.PrevCourseNumber)
              {
                CbPrevCourse.SelectedIndex = i;
                break;
              }
            }
          }
        }
      }
    }

    public void UpdatePrevCourseItems(IEnumerable<Course> courses)
    {
      CbPrevCourse.ItemsSource = courses;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
      int number, credit;
      int? prevCourseNumber = null;

      if (CbPrevCourseNull.IsChecked == false)
      {
        if (CbPrevCourse.SelectedIndex != -1)
        {
          prevCourseNumber = ((Course)CbPrevCourse.SelectedItem).Number;
        }
        else
        {
          MessageBox.Show("请选择先修课程", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
          return;
        }
      }
      
      string name = TbName.Text;
      if (int.TryParse(TbNumber.Text, out number) && int.TryParse(TbCredit.Text, out credit))
      {
        try
        {
          controller.Save(new Course(number, name, prevCourseNumber, credit));
        }
        catch (Exception exc)
        {
          MessageBox.Show(exc.Message, "发生错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        Close();
      }
      else
      {
        MessageBox.Show("请输入正确的学生信息", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private void CbPrevCourseNull_Click(object sender, RoutedEventArgs e)
    {
      CbPrevCourse.IsEnabled = CbPrevCourseNull.IsChecked != true;
    }
  }
}
