using System.Collections.Generic;

namespace DashboardDesigner
{
  internal class Data
  {
    static public IEnumerable<object> Get1() => new[]
    {
      new { f1 = "Silverlight", Count = 10 },
      new { f1 = "IIS 7",       Count = 11 },
      new { f1 = "IE 8",        Count = 12 },
      new { f1 = "C#",          Count = 13 },
      new { f1 = "Azure",       Count = 13 },
    };

    static public IEnumerable<object> Get2() => new[]
    {
      new { f1 = "Silverlight", Count = 1 },
      new { f1 = "Silverlight", Count = 2 },
      new { f1 = "Silverlight", Count = 3 },
      new { f1 = "C#",          Count = 4 },
      new { f1 = "Azure",       Count = 5 },
    };
  }
}
