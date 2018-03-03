using System;
using System.Reflection;

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


    public object GetParameter(string name) => Run(name);

    public void SetParameter(string name, object obj) {
      Push(obj);
      Interop.duk_put_global_string(_ctx, name);
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

      else if(Interop.duk_is_array(_ctx, -1)) {
        Interop.duk_pop(_ctx);
        throw new NotImplementedException("JS to C# Arrays not implemented");
      }

      else if(Interop.duk_is_object(_ctx, -1)) {
        Interop.duk_pop(_ctx);
        throw new NotImplementedException("JS to C# Objects not implemented");
      }

      Interop.duk_pop(_ctx);
      return value;
    }

    private void Push(object obj) {
      if(obj == null)
        Interop.duk_push_null(_ctx);

      else if(obj.GetType() == typeof(Undefined))
        Interop.duk_push_undefined(_ctx);

      else if(obj.GetType() == typeof(bool))
        Interop.duk_push_boolean(_ctx, (bool)obj);

      else if(obj.GetType() == typeof(double)) {
        if(double.IsNaN((double)obj))
          Interop.duk_push_nan(_ctx);
        else
          Interop.duk_push_number(_ctx, (double)obj);
      } else if(obj.GetType() == typeof(int))
        Interop.duk_push_int(_ctx, (int)obj);

      else if(obj.GetType() == typeof(uint))
        Interop.duk_push_uint(_ctx, (uint)obj);

      else if(obj.GetType() == typeof(string))
        Interop.duk_push_string(_ctx, (string)obj);

      else if(obj.GetType().IsArray) {
        var arrId = Interop.duk_push_array(_ctx);
        uint i = 0;
        foreach(object o in (Array)obj) {
          Push(o);
          Interop.duk_put_prop_index(_ctx, arrId, i);
          i++;
        }
      }

      else {
        /*var typeInfo = obj.GetType().GetTypeInfo();
        foreach(MemberInfo memberInfo in typeInfo.GetMembers()) {
          
        }*/
        throw new NotImplementedException("C# to JS Objects not implemented");
      }
    }

  }

}
