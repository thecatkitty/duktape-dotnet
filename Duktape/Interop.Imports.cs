using System;
using System.Runtime.InteropServices;

namespace Duktape
{
    public partial class Interop
    {
        /*
         *  Context management
         */
        [DllImport("libduktape.dll")]
        public static extern UIntPtr duk_create_heap(Delegate alloc_func, Delegate realloc_func, Delegate free_func, UIntPtr heap_data, Delegate fatal_handler);
        [DllImport("libduktape.dll")]
        public static extern void duk_destroy_heap(UIntPtr ctx);

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
        [DllImport("libduktape.dll")]
        public static extern int duk_get_int(UIntPtr ctx, int idx);

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
        [DllImport("libduktape.dll")]
        public static extern int duk_eval_raw(UIntPtr ctx, [MarshalAs(UnmanagedType.LPStr)] string src_buffer, uint src_length, uint flags);

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
