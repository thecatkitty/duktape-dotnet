namespace Duktape
{
    public partial class Interop
    {
        /* Duktape version, (major * 10000) + (minor * 100) + patch.  Allows C code
         * to #if (DUK_VERSION >= NNN) against Duktape API version.  The same value
         * is also available to Ecmascript code in Duktape.version.  Unofficial
         * development snapshots have 99 for patch level (e.g. 0.10.99 would be a
         * development version after 0.10.0 but before the next official release).
         */
        public const uint DUK_VERSION = 20200;

        /* Git commit, describe, and branch for Duktape build.  Useful for
         * non-official snapshot builds so that application code can easily log
         * which Duktape snapshot was used.  Not available in the Ecmascript
         * environment.
         */
        public const string DUK_GIT_COMMIT = "a459cf3c9bd1779fc01b435d69302b742675a08f";
        public const string DUK_GIT_DESCRIBE = "v2.2.0";
        public const string DUK_GIT_BRANCH = "master";

        /* Duktape debug protocol version used by this build. */
        public const uint DUK_DEBUG_PROTOCOL_VERSION = 2;

        /* Used to represent invalid index; if caller uses this without checking,
         * this index will map to a non-existent stack entry.  Also used in some
         * API calls as a marker to denote "no value".
         */
        public const int DUK_INVALID_INDEX = int.MinValue;

        /* Indicates that a native function does not have a fixed number of args,
         * and the argument stack should not be capped/extended at all.
         */
        public const int DUK_VARARGS = -1;

        /* Number of value stack entries (in addition to actual call arguments)
         * guaranteed to be allocated on entry to a Duktape/C function.
         */
        public const uint DUK_API_ENTRY_STACK = 64;

        /* Value types, used by e.g. duk_get_type() */
        public const int DUK_TYPE_MIN = 0;
        public const int DUK_TYPE_NONE = 0;    /* no value, e.g. invalid index */
        public const int DUK_TYPE_UNDEFINED = 1;    /* Ecmascript undefined */
        public const int DUK_TYPE_NULL = 2;    /* Ecmascript null */
        public const int DUK_TYPE_BOOLEAN = 3;    /* Ecmascript boolean: 0 or 1 */
        public const int DUK_TYPE_NUMBER = 4;    /* Ecmascript number: double */
        public const int DUK_TYPE_STRING = 5;    /* Ecmascript string: CESU-8 / extended UTF-8 encoded */
        public const int DUK_TYPE_OBJECT = 6;    /* Ecmascript object: includes objects, arrays, functions, threads */
        public const int DUK_TYPE_BUFFER = 7;    /* fixed or dynamic, garbage collected byte buffer */
        public const int DUK_TYPE_POINTER = 8;    /* raw void pointer */
        public const int DUK_TYPE_LIGHTFUNC = 9;    /* lightweight function pointer */
        public const int DUK_TYPE_MAX = 9;

        /* Value mask types, used by e.g. duk_get_type_mask() */
        public const int DUK_TYPE_MASK_NONE = (1 << DUK_TYPE_NONE);
        public const int DUK_TYPE_MASK_UNDEFINED = (1 << DUK_TYPE_UNDEFINED);
        public const int DUK_TYPE_MASK_NULL = (1 << DUK_TYPE_NULL);
        public const int DUK_TYPE_MASK_BOOLEAN = (1 << DUK_TYPE_BOOLEAN);
        public const int DUK_TYPE_MASK_NUMBER = (1 << DUK_TYPE_NUMBER);
        public const int DUK_TYPE_MASK_STRING = (1 << DUK_TYPE_STRING);
        public const int DUK_TYPE_MASK_OBJECT = (1 << DUK_TYPE_OBJECT);
        public const int DUK_TYPE_MASK_BUFFER = (1 << DUK_TYPE_BUFFER);
        public const int DUK_TYPE_MASK_POINTER = (1 << DUK_TYPE_POINTER);
        public const int DUK_TYPE_MASK_LIGHTFUNC = (1 << DUK_TYPE_LIGHTFUNC);
        public const int DUK_TYPE_MASK_THROW = (1 << 10);  /* internal flag value: throw if mask doesn't match */
        public const int DUK_TYPE_MASK_PROMOTE = (1 << 11);  /* internal flag value: promote to object if mask matches */

        /* Coercion hints */
        public const uint DUK_HINT_NONE = 0;    /* prefer number, unless input is a Date, in which
                                                 * case prefer string (E5 Section 8.12.8)
                                                 */
        public const uint DUK_HINT_STRING = 1;    /* prefer string */
        public const uint DUK_HINT_NUMBER = 2;    /* prefer number */

        /* Enumeration flags for duk_enum() */
        public const uint DUK_ENUM_INCLUDE_NONENUMERABLE = (1 << 0);    /* enumerate non-numerable properties in addition to enumerable */
        public const uint DUK_ENUM_INCLUDE_HIDDEN = (1 << 1);    /* enumerate hidden symbols too (in Duktape 1.x called internal properties) */
        public const uint DUK_ENUM_INCLUDE_SYMBOLS = (1 << 2);    /* enumerate symbols */
        public const uint DUK_ENUM_EXCLUDE_STRINGS = (1 << 3);    /* exclude strings */
        public const uint DUK_ENUM_OWN_PROPERTIES_ONLY = (1 << 4);    /* don't walk prototype chain, only check own properties */
        public const uint DUK_ENUM_ARRAY_INDICES_ONLY = (1 << 5);    /* only enumerate array indices */
                                                                      /* XXX: misleading name */
        public const uint DUK_ENUM_SORT_ARRAY_INDICES = (1 << 6);    /* sort array indices (applied to full enumeration result, including inherited array indices); XXX: misleading name */
        public const uint DUK_ENUM_NO_PROXY_BEHAVIOR = (1 << 7);    /* enumerate a proxy object itself without invoking proxy behavior */

        /* Compilation flags for duk_compile() and duk_eval() */
        /* DUK_COMPILE_xxx bits 0-2 are reserved for an internal 'nargs' argument.
         */
        public const uint DUK_COMPILE_EVAL = (1 << 3);    /* compile eval code (instead of global code) */
        public const uint DUK_COMPILE_FUNCTION = (1 << 4);    /* compile function code (instead of global code) */
        public const uint DUK_COMPILE_STRICT = (1 << 5);    /* use strict (outer) context for global, eval, or function code */
        public const uint DUK_COMPILE_SHEBANG = (1 << 6);    /* allow shebang ('#! ...') comment on first line of source */
        public const uint DUK_COMPILE_SAFE = (1 << 7);    /* (internal) catch compilation errors */
        public const uint DUK_COMPILE_NORESULT = (1 << 8);    /* (internal) omit eval result */
        public const uint DUK_COMPILE_NOSOURCE = (1 << 9);    /* (internal) no source string on stack */
        public const uint DUK_COMPILE_STRLEN = (1 << 10);   /* (internal) take strlen() of src_buffer (avoids double evaluation in macro) */
        public const uint DUK_COMPILE_NOFILENAME = (1 << 11);   /* (internal) no filename on stack */
        public const uint DUK_COMPILE_FUNCEXPR = (1 << 12);   /* (internal) source is a function expression (used for Function constructor) */

        /* Flags for duk_def_prop() and its variants; base flags + a lot of convenience shorthands */
        public const uint DUK_DEFPROP_WRITABLE = (1 << 0);    /* set writable (effective if DUK_DEFPROP_HAVE_WRITABLE set) */
        public const uint DUK_DEFPROP_ENUMERABLE = (1 << 1);    /* set enumerable (effective if DUK_DEFPROP_HAVE_ENUMERABLE set) */
        public const uint DUK_DEFPROP_CONFIGURABLE = (1 << 2);    /* set configurable (effective if DUK_DEFPROP_HAVE_CONFIGURABLE set) */
        public const uint DUK_DEFPROP_HAVE_WRITABLE = (1 << 3);    /* set/clear writable */
        public const uint DUK_DEFPROP_HAVE_ENUMERABLE = (1 << 4);    /* set/clear enumerable */
        public const uint DUK_DEFPROP_HAVE_CONFIGURABLE = (1 << 5);    /* set/clear configurable */
        public const uint DUK_DEFPROP_HAVE_VALUE = (1 << 6);    /* set value (given on value stack) */
        public const uint DUK_DEFPROP_HAVE_GETTER = (1 << 7);    /* set getter (given on value stack) */
        public const uint DUK_DEFPROP_HAVE_SETTER = (1 << 8);    /* set setter (given on value stack) */
        public const uint DUK_DEFPROP_FORCE = (1 << 9);    /* force change if possible, may still fail for e.g. virtual properties */
        public const uint DUK_DEFPROP_SET_WRITABLE = (DUK_DEFPROP_HAVE_WRITABLE | DUK_DEFPROP_WRITABLE);
        public const uint DUK_DEFPROP_CLEAR_WRITABLE = DUK_DEFPROP_HAVE_WRITABLE;
        public const uint DUK_DEFPROP_SET_ENUMERABLE = (DUK_DEFPROP_HAVE_ENUMERABLE | DUK_DEFPROP_ENUMERABLE);
        public const uint DUK_DEFPROP_CLEAR_ENUMERABLE = DUK_DEFPROP_HAVE_ENUMERABLE;
        public const uint DUK_DEFPROP_SET_CONFIGURABLE = (DUK_DEFPROP_HAVE_CONFIGURABLE | DUK_DEFPROP_CONFIGURABLE);
        public const uint DUK_DEFPROP_CLEAR_CONFIGURABLE = DUK_DEFPROP_HAVE_CONFIGURABLE;
        public const uint DUK_DEFPROP_W = DUK_DEFPROP_WRITABLE;
        public const uint DUK_DEFPROP_E = DUK_DEFPROP_ENUMERABLE;
        public const uint DUK_DEFPROP_C = DUK_DEFPROP_CONFIGURABLE;
        public const uint DUK_DEFPROP_WE = (DUK_DEFPROP_WRITABLE | DUK_DEFPROP_ENUMERABLE);
        public const uint DUK_DEFPROP_WC = (DUK_DEFPROP_WRITABLE | DUK_DEFPROP_CONFIGURABLE);
        public const uint DUK_DEFPROP_WEC = (DUK_DEFPROP_WRITABLE | DUK_DEFPROP_ENUMERABLE | DUK_DEFPROP_CONFIGURABLE);
        public const uint DUK_DEFPROP_HAVE_W = DUK_DEFPROP_HAVE_WRITABLE;
        public const uint DUK_DEFPROP_HAVE_E = DUK_DEFPROP_HAVE_ENUMERABLE;
        public const uint DUK_DEFPROP_HAVE_C = DUK_DEFPROP_HAVE_CONFIGURABLE;
        public const uint DUK_DEFPROP_HAVE_WE = (DUK_DEFPROP_HAVE_WRITABLE | DUK_DEFPROP_HAVE_ENUMERABLE);
        public const uint DUK_DEFPROP_HAVE_WC = (DUK_DEFPROP_HAVE_WRITABLE | DUK_DEFPROP_HAVE_CONFIGURABLE);
        public const uint DUK_DEFPROP_HAVE_WEC = (DUK_DEFPROP_HAVE_WRITABLE | DUK_DEFPROP_HAVE_ENUMERABLE | DUK_DEFPROP_HAVE_CONFIGURABLE);
        public const uint DUK_DEFPROP_SET_W = DUK_DEFPROP_SET_WRITABLE;
        public const uint DUK_DEFPROP_SET_E = DUK_DEFPROP_SET_ENUMERABLE;
        public const uint DUK_DEFPROP_SET_C = DUK_DEFPROP_SET_CONFIGURABLE;
        public const uint DUK_DEFPROP_SET_WE = (DUK_DEFPROP_SET_WRITABLE | DUK_DEFPROP_SET_ENUMERABLE);
        public const uint DUK_DEFPROP_SET_WC = (DUK_DEFPROP_SET_WRITABLE | DUK_DEFPROP_SET_CONFIGURABLE);
        public const uint DUK_DEFPROP_SET_WEC = (DUK_DEFPROP_SET_WRITABLE | DUK_DEFPROP_SET_ENUMERABLE | DUK_DEFPROP_SET_CONFIGURABLE);
        public const uint DUK_DEFPROP_CLEAR_W = DUK_DEFPROP_CLEAR_WRITABLE;
        public const uint DUK_DEFPROP_CLEAR_E = DUK_DEFPROP_CLEAR_ENUMERABLE;
        public const uint DUK_DEFPROP_CLEAR_C = DUK_DEFPROP_CLEAR_CONFIGURABLE;
        public const uint DUK_DEFPROP_CLEAR_WE = (DUK_DEFPROP_CLEAR_WRITABLE | DUK_DEFPROP_CLEAR_ENUMERABLE);
        public const uint DUK_DEFPROP_CLEAR_WC = (DUK_DEFPROP_CLEAR_WRITABLE | DUK_DEFPROP_CLEAR_CONFIGURABLE);
        public const uint DUK_DEFPROP_CLEAR_WEC = (DUK_DEFPROP_CLEAR_WRITABLE | DUK_DEFPROP_CLEAR_ENUMERABLE | DUK_DEFPROP_CLEAR_CONFIGURABLE);
        public const uint DUK_DEFPROP_ATTR_W = (DUK_DEFPROP_HAVE_WEC | DUK_DEFPROP_W);
        public const uint DUK_DEFPROP_ATTR_E = (DUK_DEFPROP_HAVE_WEC | DUK_DEFPROP_E);
        public const uint DUK_DEFPROP_ATTR_C = (DUK_DEFPROP_HAVE_WEC | DUK_DEFPROP_C);
        public const uint DUK_DEFPROP_ATTR_WE = (DUK_DEFPROP_HAVE_WEC | DUK_DEFPROP_WE);
        public const uint DUK_DEFPROP_ATTR_WC = (DUK_DEFPROP_HAVE_WEC | DUK_DEFPROP_WC);
        public const uint DUK_DEFPROP_ATTR_WEC = (DUK_DEFPROP_HAVE_WEC | DUK_DEFPROP_WEC);

        /* Flags for duk_push_thread_raw() */
        public const uint DUK_THREAD_NEW_GLOBAL_ENV = (1 << 0);    /* create a new global environment */

        /* Flags for duk_gc() */
        public const uint DUK_GC_COMPACT = (1 << 0);    /* compact heap objects */

        /* Error codes (must be 8 bits at most, see duk_error.h) */
        public const int DUK_ERR_NONE = 0;    /* no error (e.g. from duk_get_error_code()) */
        public const int DUK_ERR_ERROR = 1;    /* Error */
        public const int DUK_ERR_EVAL_ERROR = 2;    /* EvalError */
        public const int DUK_ERR_RANGE_ERROR = 3;    /* RangeError */
        public const int DUK_ERR_REFERENCE_ERROR = 4;    /* ReferenceError */
        public const int DUK_ERR_SYNTAX_ERROR = 5;    /* SyntaxError */
        public const int DUK_ERR_TYPE_ERROR = 6;    /* TypeError */
        public const int DUK_ERR_URI_ERROR = 7;    /* URIError */

        /* Return codes for C functions (shortcut for throwing an error) */
        public const int DUK_RET_ERROR = (-DUK_ERR_ERROR);
        public const int DUK_RET_EVAL_ERROR = (-DUK_ERR_EVAL_ERROR);
        public const int DUK_RET_RANGE_ERROR = (-DUK_ERR_RANGE_ERROR);
        public const int DUK_RET_REFERENCE_ERROR = (-DUK_ERR_REFERENCE_ERROR);
        public const int DUK_RET_SYNTAX_ERROR = (-DUK_ERR_SYNTAX_ERROR);
        public const int DUK_RET_TYPE_ERROR = (-DUK_ERR_TYPE_ERROR);
        public const int DUK_RET_URI_ERROR = (-DUK_ERR_URI_ERROR);

        /* Return codes for protected calls (duk_safe_call(), duk_pcall()) */
        public const uint DUK_EXEC_SUCCESS = 0;
        public const uint DUK_EXEC_ERROR = 1;

        /* Debug levels for DUK_USE_DEBUG_WRITE(). */
        public const uint DUK_LEVEL_DEBUG = 0;
        public const uint DUK_LEVEL_DDEBUG = 1;
        public const uint DUK_LEVEL_DDDEBUG = 2;
    }
}
