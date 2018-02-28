﻿using System;
using System.Runtime.InteropServices;

namespace Duktape
{
    public partial class Interop
    {
        [DllImport("libduktape.dll")]
        public static extern UIntPtr duk_create_heap(Delegate alloc_func, Delegate realloc_func, Delegate free_func, UIntPtr heap_data, Delegate fatal_handler);
        
        [DllImport("libduktape.dll")]
        public static extern int duk_eval_raw(UIntPtr ctx, [MarshalAs(UnmanagedType.LPStr)] string src_buffer, uint src_length, uint flags);
        
        [DllImport("libduktape.dll")]
        public static extern void duk_destroy_heap(UIntPtr ctx);

        [DllImport("libduktape.dll")]
        public static extern int duk_get_int(UIntPtr ctx, int idx);
    }
}
