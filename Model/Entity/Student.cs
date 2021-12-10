using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDatabaseTeacherLovesStudentSystem
{
  public class Student
  {
    public int Cls { get;  }
    public int Number { get;  }
    public string Name { get;  }
    public string Sex { get;  }
    public int Age { get;  }
    public string Dept { get;  }

    public Student(int cls, int number, string name, string sex, int age, string dept)
    {
      Cls = cls;
      Number = number;
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Sex = sex ?? throw new ArgumentNullException(nameof(sex));
      Age = age;
      Dept = dept ?? throw new ArgumentNullException(nameof(dept));
    }
  }
}
