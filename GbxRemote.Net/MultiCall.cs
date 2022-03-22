using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GbxRemoteNet
{
    /// <summary>
    /// A multicall builder.
    /// </summary>
    public class MultiCall
    {
        /// <summary>
        /// Holds information about a method call.
        /// </summary>
        public class MethodInfo
        {
            public string MethodName { get; }
            public object[] Arguments { get; }

            /// <summary>
            /// Create a new MethodInfo instance from a method name and arbitrary arguments.
            /// </summary>
            /// <param name="method"></param>
            /// <param name="args"></param>
            public MethodInfo(string method, object[] args)
            {
                MethodName = method;
                Arguments = args;
            }
        }

        /// <summary>
        /// The calls for this multicall.
        /// </summary>
        public List<MethodInfo> MethodCalls { get; } = new();

        /// <summary>
        /// Adds information about a method call to the list of calls
        /// for this multicall.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private MultiCall AddMethod(string method, params object[] args)
        {
            MethodCalls.Add(new MethodInfo(method, args));
            return this;
        }

        /// <summary>
        /// Add a call to this multicall using the name of a async method or directly a XML-RPC method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add(string method, params object[] args)
            => AddMethod(method, args);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R>(Func<Task<R>> method)
            => AddMethod(method.Method.Name);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1>(Func<T1, Task<R>> method, T1 a1)
            => AddMethod(method.Method.Name, a1);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2>(Func<T1, T2, Task<R>> method, T1 a1, T2 a2)
            => AddMethod(method.Method.Name, a1, a2);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3>(Func<T1, T2, T3, Task<R>> method, T1 a1, T2 a2, T3 a3)
            => AddMethod(method.Method.Name, a1, a2, a3);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task<R>> method, T1 a1, T2 a2, T3 a3, T4 a4)
            => AddMethod(method.Method.Name, a1, a2, a3, a4);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, Task<R>> method, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
            => AddMethod(method.Method.Name, a1, a2, a3, a4, a5);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, Task<R>> method, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
            => AddMethod(method.Method.Name, a1, a2, a3, a4, a5, a6);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, Task<R>> method, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
            => AddMethod(method.Method.Name, a1, a2, a3, a4, a5, a6, a7);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<R>> method, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
            => AddMethod(method.Method.Name, a1, a2, a3, a4, a5, a6, a7, a8);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<R>> method, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
            => AddMethod(method.Method.Name, a1, a2, a3, a4, a5, a6, a7, a8, a9);

        /// <summary>
        /// Add a call to this multicall using a c# method.
        /// </summary>
        /// <returns>Multicall object so you can chain these methods.</returns>
        public MultiCall Add<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<R>> method, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
            => AddMethod(method.Method.Name, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
    }
}
