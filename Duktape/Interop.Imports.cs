using System;
using System.Runtime.InteropServices;

namespace Duktape {

  public partial class Interop {
    /*
     *  Context management
     */
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_create_heap(
      Delegate alloc_func, Delegate realloc_func, Delegate free_func,
      IntPtr heap_data, Delegate fatal_handler);
    [DllImport("libduktape.dll")]
    public static extern void duk_destroy_heap(IntPtr ctx);

    [DllImport("libduktape.dll")]
    public static extern void duk_suspend(
      IntPtr ctx, ref duk_thread_state state);
    [DllImport("libduktape.dll")]
    public static extern void duk_resume(IntPtr ctx, duk_thread_state state);

    /*
     *  Memory management
     *
     *  Raw functions have no side effects (cannot trigger GC).
     */
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_alloc_raw(IntPtr ctx, uint size);
    [DllImport("libduktape.dll")]
    public static extern void duk_free_raw(IntPtr ctx, IntPtr ptr);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_realloc_raw(
      IntPtr ctx, IntPtr ptr, uint size);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_alloc(IntPtr ctx, uint size);
    [DllImport("libduktape.dll")]
    public static extern void duk_free(IntPtr ctx, IntPtr ptr);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_realloc(IntPtr ctx, IntPtr ptr, uint size);
    [DllImport("libduktape.dll")]
    public static extern void duk_get_memory_functions(
      IntPtr ctx, IntPtr out_funcs);
    [DllImport("libduktape.dll")]
    public static extern void duk_gc(IntPtr ctx, uint flags);


    /*
     *  Error handling
     */
    [DllImport("libduktape.dll")]
    public static extern void duk_throw_raw(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_fatal_raw(
      IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)] string err_msg);
    [DllImport("libduktape.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void duk_error_raw(
      IntPtr ctx, int err_code,
      [MarshalAs(UnmanagedType.LPStr)] string filename, int line,
      [MarshalAs(UnmanagedType.LPStr)] string fmt, __arglist);

    /*
     *  Other state related functions
     */
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_strict_call(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_constructor_call(IntPtr ctx);

    /*
     *  Stack management
     */
    [DllImport("libduktape.dll")]
    public static extern int duk_normalize_index(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern int duk_require_normalize_index(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_valid_index(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern void duk_require_valid_index(IntPtr ctx, int idx);

    [DllImport("libduktape.dll")]
    public static extern int duk_get_top(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_set_top(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern int duk_get_top_index(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern int duk_require_top_index( IntPtr ctx);

    [DllImport("libduktape.dll")]
    public static extern bool duk_check_stack(IntPtr ctx, int extra);
    [DllImport("libduktape.dll")]
    public static extern void duk_require_stack(IntPtr ctx, int extra);
    [DllImport("libduktape.dll")]
    public static extern bool duk_check_stack_top(IntPtr ctx, int top);
    [DllImport("libduktape.dll")]
    public static extern void duk_require_stack_top(IntPtr ctx, int top);

    /*
     *  Stack manipulation (other than push/pop)
     */
    [DllImport("libduktape.dll")]
    public static extern void duk_swap(IntPtr ctx, int idx1, int idx2);
    [DllImport("libduktape.dll")]
    public static extern void duk_swap_top(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern void duk_dup(IntPtr ctx, int from_idx);
    [DllImport("libduktape.dll")]
    public static extern void duk_dup_top(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_insert(IntPtr ctx, int to_idx);
    [DllImport("libduktape.dll")]
    public static extern void duk_replace(IntPtr ctx, int to_idx);
    [DllImport("libduktape.dll")]
    public static extern void duk_copy(IntPtr ctx, int from_idx, int to_idx);
    [DllImport("libduktape.dll")]
    public static extern void duk_remove(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern void duk_xcopymove_raw(
      IntPtr to_ctx, IntPtr from_ctx, int count, bool is_copy);

    /*
     *  Push operations
     *
     *  Push functions return the absolute (relative to bottom of frame)
     *  position of the pushed value for convenience.
     *
     *  Note: duk_dup() is technically a push.
     */
    [DllImport("libduktape.dll")]
    public static extern void duk_push_undefined(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_null(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_boolean(IntPtr ctx, bool val);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_true(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_false(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_number(IntPtr ctx, double val);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_nan(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_int(IntPtr ctx, int val);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_uint(IntPtr ctx, uint val);
    [DllImport("libduktape.dll", CharSet = CharSet.Ansi)]
    public static extern string duk_push_string(IntPtr ctx,
      [MarshalAs(UnmanagedType.LPStr)] string str);
    [DllImport("libduktape.dll", CharSet = CharSet.Ansi)]
    public static extern string duk_push_lstring(IntPtr ctx,
      [MarshalAs(UnmanagedType.LPStr)] string str, uint len);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_pointer(IntPtr ctx, IntPtr p);
    [DllImport("libduktape.dll",
      CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern string duk_push_sprintf(
      IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)] string fmt, __arglist);
    [DllImport("libduktape.dll", CharSet = CharSet.Ansi)]
    public static extern string duk_push_vsprintf(
      IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr ap);

    [DllImport("libduktape.dll")]
    public static extern void duk_push_this(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_current_function(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_current_thread(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_global_object(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_heap_stash(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_global_stash(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_push_thread_stash(
      IntPtr ctx, IntPtr target_ctx);

    [DllImport("libduktape.dll")]
    public static extern int duk_push_object(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern int duk_push_bare_object(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern int duk_push_array(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern int duk_push_c_function(
      IntPtr ctx, Delegate func, int nargs);
    [DllImport("libduktape.dll")]
    public static extern int duk_push_c_lightfunc(
      IntPtr ctx, Delegate func, int nargs, int length, int magic);
    [DllImport("libduktape.dll")]
    public static extern int duk_push_thread_raw(IntPtr ctx, uint flags);
    [DllImport("libduktape.dll")]
    public static extern int duk_push_proxy(IntPtr ctx, uint proxy_flags);

    [DllImport("libduktape.dll",
      CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern int duk_push_error_object_raw(
      IntPtr ctx, int err_code,
      [MarshalAs(UnmanagedType.LPStr)] string filename, int line,
      [MarshalAs(UnmanagedType.LPStr)] string fmt, __arglist);
    [DllImport("libduktape.dll", CharSet = CharSet.Ansi)]
    public static extern int duk_push_error_object_va_raw(
      IntPtr ctx, int err_code,
      [MarshalAs(UnmanagedType.LPStr)] string filename, int line,
      [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr ap);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_push_buffer_raw(
      IntPtr ctx, uint size, uint flags);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_push_buffer_object(
      IntPtr ctx, int idx_buffer, uint byte_offset, uint byte_length,
      uint flags);
    [DllImport("libduktape.dll")]
    public static extern int duk_push_heapptr(IntPtr ctx, IntPtr ptr);

    /*
     *  Pop operations
     */
    [DllImport("libduktape.dll")]
    public static extern void duk_pop(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_pop_n(IntPtr ctx, int count);
    [DllImport("libduktape.dll")]
    public static extern void duk_pop_2(IntPtr ctx);
    [DllImport("libduktape.dll")]
    public static extern void duk_pop_3(IntPtr ctx);

    /*
     *  Type checks
     *
     *  duk_is_none(), which would indicate whether index it outside of stack,
     *  is not needed; duk_is_valid_index() gives the same information.
     */
    [DllImport("libduktape.dll")]
    public static extern int duk_get_type(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_check_type(IntPtr ctx, int idx, int type);
    [DllImport("libduktape.dll")]
    public static extern uint duk_get_type_mask(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_check_type_mask(
      IntPtr ctx, int idx, uint mask);

    [DllImport("libduktape.dll")]
    public static extern bool duk_is_undefined(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_null(IntPtr ctx, int idx);

    [DllImport("libduktape.dll")]
    public static extern bool duk_is_boolean(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_number(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_nan(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_string(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_object(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_buffer(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_buffer_data(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_pointer(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_lightfunc(IntPtr ctx, int idx);

    [DllImport("libduktape.dll")]
    public static extern bool duk_is_symbol(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_array(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_function(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_c_function(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_ecmascript_function(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_bound_function(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_thread(IntPtr ctx, int idx);

    [DllImport("libduktape.dll")]
    public static extern bool duk_is_dynamic_buffer(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_fixed_buffer(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern bool duk_is_external_buffer(IntPtr ctx, int idx);

    [DllImport("libduktape.dll")]
    public static extern int duk_get_error_code(IntPtr ctx, int idx);

    /*
     *  Get operations: no coercion, returns default value for invalid
     *  indices and invalid value types.
     *
     *  duk_get_undefined() and duk_get_null() would be pointless and
     *  are not included.
     */
    [DllImport("libduktape.dll")]
    public static extern bool duk_get_boolean(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern double duk_get_number(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern int duk_get_int(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern uint duk_get_uint(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_get_string(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_get_lstring(
      IntPtr ctx, int idx, ref uint out_len);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_get_buffer(
      IntPtr ctx, int idx, ref uint out_size);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_get_buffer_data(
      IntPtr ctx, int idx, ref uint out_size);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_get_pointer(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern Delegate duk_get_c_function(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_get_context(IntPtr ctx, int idx);
    [DllImport("libduktape.dll")]
    public static extern IntPtr duk_get_heapptr(IntPtr ctx, int idx);

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
    public static extern int duk_eval_raw(
      IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)] string src_buffer,
      uint src_length, uint flags);

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
