using System;

namespace Duktape {

  public class ThreadState {
    private Interop.duk_thread_state _st;
    public static implicit operator Interop.duk_thread_state(ThreadState state)
      => state._st;

    public ThreadState(Interop.duk_thread_state state) {
      _st = state;
    }
  }
}
