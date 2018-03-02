using System;

namespace Duktape {

  public class Undefined { }
  
  public class Context : IDisposable {
    private IntPtr _ctx;
    public static implicit operator IntPtr(Context ctx) => ctx._ctx;

    /*
     *  Context management
     */
    public Context() {
      _ctx = Interop.duk_create_heap_default();

      if(_ctx == IntPtr.Zero)
        throw new OutOfMemoryException("Couldn't create Duktape context");
    }

    public Context(
      Delegate allocFunc, Delegate reallocFunc, Delegate freeFunc,
      IntPtr heapData, Delegate fatalHandler) {
      _ctx = Interop.duk_create_heap(
        allocFunc, reallocFunc, freeFunc, heapData, fatalHandler);
    }

    public void Dispose() {
      Interop.duk_destroy_heap(_ctx);
    }

    public ThreadState Suspend() {
      Interop.duk_thread_state state;
      Interop.duk_suspend(_ctx, ref state);
      return new ThreadState(state);
    }

    public void Resume(ThreadState state) {
      Interop.duk_resume(_ctx, state);
    }


    public object Run(string code) {
      Interop.duk_eval_string(_ctx, code);
      return Pop();
    }

    /*
     *  Push operations
     *
     *  Push functions return the absolute (relative to bottom of frame)
     *  position of the pushed value for convenience.
     *
     *  Note: duk_dup() is technically a push.
     */
    public void PushUndefined() {
      Interop.duk_push_undefined(_ctx);
    }

    public void PushNull() {
      Interop.duk_push_null(_ctx);
    }

    public void PushNaN() {
      Interop.duk_push_nan(_ctx);
    }

    public void Push(bool value) {
      Interop.duk_push_boolean(_ctx, value);
    }

    public void Push(double value) {
      if(Double.IsNaN(value))
        Interop.duk_push_nan(_ctx);

      else
        Interop.duk_push_number(_ctx, value);
    }

    public void Push(int value) {
      Interop.duk_push_int(_ctx, value);
    }

    public void Push(uint value) {
      Interop.duk_push_uint(_ctx, value);
    }

    public void Push(string value) {
      Interop.duk_push_string(_ctx, value);
    }
    
    /*
     *  Function (method) calls
     */
    public void Call(int nargs) {
      Interop.duk_call(_ctx, nargs);
    }
    

    private object Pop() {
      object value = null;

      if(Interop.duk_is_undefined(_ctx, -1))
        value = new Undefined();

      if(Interop.duk_is_null(_ctx, -1))
        value = null;

      else if(Interop.duk_is_boolean(_ctx, -1))
        value = Interop.duk_get_boolean(_ctx, -1);

      else if(Interop.duk_is_number(_ctx, -1)) {
        var number = Interop.duk_get_number(_ctx, -1);
        if((number % 1) == 0)
          value = System.Convert.ToInt32(number);
        else
          value = number;
      }

      else if(Interop.duk_is_string(_ctx, -1))
        value = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(
        Interop.duk_to_string(_ctx, -1));

      else if(Interop.duk_is_array(_ctx, -1))
        throw new NotImplementedException("JS to C# Arrays not implemented");

      else if(Interop.duk_is_object(_ctx, -1))
        throw new NotImplementedException("JS to C# Objects not implemented");

      return value;
    }
  }

}
