using System;
using System.Collections.Generic;
using System.Text;

namespace Duktape {

  public class Context : IDisposable {
    private UIntPtr _ctx;
    public static implicit operator UIntPtr(Context ctx) => ctx._ctx;


    public Context() {
      _ctx = Interop.duk_create_heap_default();
    }

    public Context(Delegate allocFunc, Delegate reallocFunc, Delegate freeFunc, UIntPtr heapData, Delegate fatalHandler) {
      _ctx = Interop.duk_create_heap(allocFunc, reallocFunc, freeFunc, heapData, fatalHandler);
    }

    public void Dispose() {
      Interop.duk_destroy_heap(_ctx);
    }


    public void Eval(string str) {
      Interop.duk_eval_string(_ctx, str);
    }

    public int GetInt(int index) {
      return Interop.duk_get_int(_ctx, index);
    }
  }

}
