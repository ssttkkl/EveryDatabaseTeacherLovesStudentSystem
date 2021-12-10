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
  /// LoginWindow.xaml 的交互逻辑
  /// </summary>
  public partial class LoginWindow : Window
  {
    public LoginWindow()
    {
      InitializeComponent();
    }

    private void BtnConn_Click(object sender, RoutedEventArgs e)
    {
      int port;
      if (int.TryParse(TbPort.Text, out port))
      {
        MyDatabase.Instance.OpenConnection(TbHost.Text, port, TbUser.Text, TbPasswd.Password, TbDbName.Text);
        Close();
      }
    }

    private void Window_Closed(object sender, EventArgs e)
    {
      if (!MyDatabase.Instance.ConnectionOpened)
      {
        System.Environment.Exit(0);
      }
    }
  }
}
