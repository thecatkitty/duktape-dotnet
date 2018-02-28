using System;
using System.Runtime.InteropServices;

namespace Duktape
{
    public partial class Interop
    {
        public static UIntPtr duk_create_heap_default()
        {
            return duk_create_heap(null, null, null, UIntPtr.Zero, null);
        }

        public static void duk_eval_string(UIntPtr ctx, string src)
        {
            duk_eval_raw(ctx, src, 0, DUK_COMPILE_EVAL | DUK_COMPILE_NOSOURCE | DUK_COMPILE_STRLEN | DUK_COMPILE_NOFILENAME);
        }
    }
}
