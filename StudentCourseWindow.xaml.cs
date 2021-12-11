﻿using EveryDatabaseTeacherLovesStudentSystem.Constraint;
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

    public StudentCourseWindow(Student stu)
    {
      InitializeComponent();

      LbCls.Content = stu.Cls.ToString();
      LbNumber.Content = stu.Number.ToString();
      LbName.Content = stu.Name;
      LbSex.Content = stu.Sex;
      LbAge.Content = stu.Age.ToString();
      LbDept.Content = stu.Dept.ToString();

      controller = new StudentCourseController(this, stu);
      controller.LoadAllStudentCoursesAsync();
    }

    public void ShowEditStudentCourseView(NewOrEdit mode, StudentCourse stuCourse, Student student)
    {
      EditStudentCourseWindow view = new EditStudentCourseWindow(mode, stuCourse, student, null);
      view.Closed += async (sender, e) =>
      {
        await controller.LoadAllStudentCoursesAsync();
      };
      view.ShowDialog();
    }

    public void UpdateStudentCourseData(IEnumerable<StudentCourse> data)
    {
      DgCourse.ItemsSource = data;
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
      if (DgCourse.SelectedIndex != -1)
      {
        controller.EditStudentCourse((StudentCourse)DgCourse.SelectedItem);
        await controller.LoadAllStudentCoursesAsync();
      }
    }

    private async void BtnRemove_Click(object sender, RoutedEventArgs e)
    {
      if (DgCourse.SelectedIndex != -1)
      {
        await controller.RemoveStudentCourseAsync((StudentCourse)DgCourse.SelectedItem);
        await controller.LoadAllStudentCoursesAsync();
      }
    }
  }
}
