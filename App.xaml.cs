using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {

    public static void ExecFile(string fileName, string arguments, Stream input, Stream output)
    {
      using var process = new Process();
      process.StartInfo.Arguments = arguments;
      process.StartInfo.FileName = fileName;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.RedirectStandardInput = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();

      Task t1 = null, t2 = null;
      if (input != null)
        t1 = input.CopyToAsync(process.StandardInput.BaseStream);
      if (output != null)
        t2 = process.StandardOutput.BaseStream.CopyToAsync(output);
      t1?.Wait();
      t2?.Wait();

      process.WaitForExit();
      process.Close();
    }
  }
}
