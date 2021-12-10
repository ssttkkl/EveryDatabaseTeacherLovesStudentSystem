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
  /// EditStudentWindow.xaml 的交互逻辑
  /// </summary>
  public partial class EditStudentWindow : Window, IEditStudentView
  {
    private IEditStudentController controller;
    public EditStudentWindow(NewOrEdit mode, Student stu)
    {
      InitializeComponent();
      controller = new EditStudentController(this, mode, stu);

      if (mode == NewOrEdit.Edit)
      {
        TbCls.IsEnabled = false;
        TbNumber.IsEnabled = false;
        if (stu == null)
        {
          throw new ArgumentNullException(nameof(stu));
        }
        else
        {
          TbCls.Text = stu.Cls.ToString();
          TbNumber.Text = stu.Number.ToString();
          TbName.Text = stu.Name;
          CbSex.Text = stu.Sex;
          TbAge.Text = stu.Age.ToString();
          TbDept.Text = stu.Dept.ToString();
        }
      }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
      int cls, number, age;
      string name = TbName.Text, sex = CbSex.Text, dept = TbDept.Text;
      if (int.TryParse(TbCls.Text, out cls) && int.TryParse(TbNumber.Text, out number) && int.TryParse(TbAge.Text, out age))
      {
        try
        {
          controller.Save(new Student(cls, number, name, sex, age, dept));
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
  }
}
