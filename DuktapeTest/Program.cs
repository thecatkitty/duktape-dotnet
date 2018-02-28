using System;
using System.Collections.Generic;
using System.Text;

namespace DuktapeTest {
  class Program {

    static void Main(string[] args) {
      using(var js = new Duktape.Context()) {
        js.Eval("1+2");
        Console.WriteLine(String.Format("1+2={0}", js.GetInt(-1)));
      }

      Console.ReadKey();
    }

  }
}
