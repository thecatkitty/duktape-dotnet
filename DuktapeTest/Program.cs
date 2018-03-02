using System;
using System.Collections.Generic;
using System.Text;

namespace DuktapeTest {
  class Program {

    static void Main(string[] args) {
      using(var js = new Duktape.Context()) {
        js.Eval("1+2");
        var i = js.GetInt();
        Console.WriteLine(String.Format("1+2={0}", i));

        js.Eval("Array(16).join('a'-1) + ' Batmaaaan!'");
        var s = js.GetString();
        Console.WriteLine(s);
      }

      Console.ReadKey();
    }

  }
}
