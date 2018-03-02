using System;
using System.Runtime;

namespace Duktape {

  public class Context : IDisposable {
    private IntPtr _ctx;
    public static implicit operator IntPtr(Context ctx) => ctx._ctx;

    /*
     *  Context management
     */
    public Context() {
      _ctx = Interop.duk_create_heap_default();
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

    public Interop.duk_thread_state Suspend() {
      Interop.duk_thread_state state;
      Interop.duk_suspend(_ctx, ref state);
      return state;
    }

    public void Resume(Interop.duk_thread_state state) {
      Interop.duk_resume(_ctx, state);
    }

    /*
     *  Memory management
     *
     *  Raw functions have no side effects (cannot trigger GC).
     */

    /*
     *  Error handling
     */

    /*
     *  Other state related functions
     */

    /*
     *  Stack management
     */

    /*
     *  Stack manipulation (other than push/pop)
     */

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
     *  Pop operations
     */

    /*
     *  Type checks
     *
     *  duk_is_none(), which would indicate whether index it outside of stack,
     *  is not needed; duk_is_valid_index() gives the same information.
     */

    /*
     *  Get operations: no coercion, returns default value for invalid
     *  indices and invalid value types.
     *
     *  duk_get_undefined() and duk_get_null() would be pointless and
     *  are not included.
     */
    public bool GetBoolean(int index = -1) {
      return Interop.duk_get_boolean(_ctx, index);
    }

    public double GetDouble(int index = -1) {
      return Interop.duk_get_number(_ctx, index);
    }

    public int GetInt(int index = -1) {
      return Interop.duk_get_int(_ctx, index);
    }

    public uint GetUInt(int index = -1) {
      return Interop.duk_get_uint(_ctx, index);
    }

    public string GetString(int index = -1) {
      return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(
        Interop.duk_get_string(_ctx, index));
    }

    /*
     *  Get-with-explicit default operations: like get operations but with an
     *  explicit default value.
     */

    /*
     *  Opt operations: like require operations but with an explicit default value
     *  when value is undefined or index is invalid, null and non-matching types
     *  cause a TypeError.
     */


    /*
     *  Require operations: no coercion, throw error if index or type
     *  is incorrect.  No defaulting.
     */

    /*
     *  Coercion operations: in-place coercion, return coerced value where
     *  applicable.  If index is invalid, throw error.  Some coercions may
     *  throw an expected error (e.g. from a toString() or valueOf() call)
     *  or an internal error (e.g. from out of memory).
     */

    /*
     *  Value length
     */

    /*
     *  Misc conversion
     */

    /*
     *  Buffer
     */

    /*
     *  Property access
     *
     *  The basic function assumes key is on stack.  The _string variant takes
     *  a C string as a property name, while the _index variant takes an array
     *  index as a property name (e.g. 123 is equivalent to the key "123").
     */

    /*
     *  Inspection
     */

    /*
     *  Object prototype
     */

    /*
     *  Object finalizer
     */

    /*
     *  Global object
     */

    /*
     *  Duktape/C function magic value
     */

    /*
     *  Module helpers: put multiple function or constant properties
     */

    /*
     *  Object operations
     */

    /*
     *  String manipulation
     */

    /*
     *  Ecmascript operators
     */

    /*
     *  Function (method) calls
     */

    /*
     *  Compilation and evaluation
     */
    public void Eval(string str) {
      Interop.duk_eval_string(_ctx, str);
    }

    /*
     *  Bytecode load/dump
     */

    /*
     *  Debugging
     */

    /*
     *  Debugger (debug protocol)
     */

    /*
     *  Time handling
     */
  }

}
