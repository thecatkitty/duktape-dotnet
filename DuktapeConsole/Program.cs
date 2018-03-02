using System;
using System.Collections.Generic;
using System.Text;

namespace DuktapeConsole {
  class Program {

    static void Main(string[] args) {
      Console.Title = "Celones Duktape.NET Console, version "
        + System.Reflection.Assembly.GetExecutingAssembly().GetName()
        .Version.ToString();

      using(var js = new Duktape.Context()) {
        var line = "";
        while(true) {
          Console.Write("> ");
          line = Console.ReadLine();

          if(line == "exit")
            break;

          try {
            var value = js.Run(line);
            Console.WriteLine(value.ToString());
          } catch(Exception e) {
            Console.Error.WriteLine(e.GetType().Name + ": " + e.Message);
          }
        }
      }
    }

  }
}
