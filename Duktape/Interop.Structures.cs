using System;
using System.Runtime.InteropServices;

namespace Duktape {

  public partial class Interop {

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct duk_thread_state {
      public fixed char data[128];
    }

  }

}
