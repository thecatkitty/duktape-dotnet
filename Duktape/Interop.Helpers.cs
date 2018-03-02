using System;
using System.Runtime.InteropServices;

namespace Duktape {

  public partial class Interop {
    /*
     *  Context management
     */
    public static IntPtr duk_create_heap_default() {
      return duk_create_heap(null, null, null, IntPtr.Zero, null);
    }

    /*
     *  Memory management
     *
     *  Raw functions have no side effects (cannot trigger GC).
     */

    /*
     *  Error handling
     */
    public static int duk_throw(IntPtr ctx) {
      duk_throw_raw(ctx);
      return 0;
    }

    public static int duk_fatal(IntPtr ctx, string err_msg) {
      duk_fatal_raw(ctx, err_msg);
      return 0;
    }

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
    public static void duk_eval_string(IntPtr ctx, string src) {
      duk_eval_raw(ctx, src, 0, DUK_COMPILE_EVAL | DUK_COMPILE_NOSOURCE | DUK_COMPILE_STRLEN | DUK_COMPILE_NOFILENAME);
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
