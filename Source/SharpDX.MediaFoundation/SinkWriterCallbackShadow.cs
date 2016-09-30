// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Runtime.InteropServices;

namespace SharpDX.MediaFoundation
{
    /// <summary>
    /// Internal SinkWriterCallback Callback
    /// </summary>
    internal class SinkWriterCallbackShadow : SharpDX.ComObjectShadow
    {
        private static readonly SinkWriterCallbackVtbl Vtbl = new SinkWriterCallbackVtbl();

        /// <summary>
        /// Return a pointer to the unmanaged version of this callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <returns>A pointer to a shadow c++ callback</returns>
        public static IntPtr ToIntPtr(ISinkWriterCallback2 callback)
        {
            return ToCallbackPtr<ISinkWriterCallback2>(callback);
        }

        public class SinkWriterCallbackVtbl : ComObjectVtbl
        {
            public SinkWriterCallbackVtbl() : base(4)
            {
                AddMethod(new OnFinalizeDelegate(OnFinalizeImpl));
                AddMethod(new OnMarkerDelegate(OnMarkerImpl));
                AddMethod(new OnTransformChangeDelegate(OnTransformChangeImpl));
                AddMethod(new OnStreamErrorDelegate(OnStreamErrorImpl));
            }

            /// <unmanaged>HRESULT OnFinalize(HRESULT hrStatus)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnFinalizeDelegate(IntPtr thisPtr, int hrStatus);
            private static int OnFinalizeImpl(IntPtr thisPtr, int hrStatus)
            {
                try
                {
                    var shadow = ToShadow<SinkWriterCallbackShadow>(thisPtr);
                    var callback = (ISinkWriterCallback)shadow.Callback;
                    callback.OnFinalize(hrStatus);
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }

            /// <unmanaged>HRESULT STDMETHODCALLTYPE OnMarker(__in DWORD dwStreamIndex, __in LPVOID pvContext)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnMarkerDelegate(IntPtr thisPtr, int dwStreamIndex, IntPtr pvContext);
            private static int OnMarkerImpl(IntPtr thisPtr, int dwStreamIndex, IntPtr pvContext)
            {
                try
                {
                    var shadow = ToShadow<SinkWriterCallbackShadow>(thisPtr);
                    var callback = (ISinkWriterCallback)shadow.Callback;
                    callback.OnMarker(dwStreamIndex, pvContext);
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }

            /// <unmanaged>HRESULT STDMETHODCALLTYPE OnTransformChange(void)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnTransformChangeDelegate(IntPtr thisPtr);
            private static int OnTransformChangeImpl(IntPtr thisPtr)
            {
                try
                {
                    var shadow = ToShadow<SinkWriterCallbackShadow>(thisPtr);
                    var callback = (ISinkWriterCallback2)shadow.Callback;
                    callback.OnTransformChange();
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }

            /// <unmanaged>HRESULT STDMETHODCALLTYPE OnStreamError(_In_ DWORD dwStreamIndex, _In_ HRESULT hrStatus)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnStreamErrorDelegate(IntPtr thisPtr, int dwStreamIndex, int hrStatus);
            private static int OnStreamErrorImpl(IntPtr thisPtr, int dwStreamIndex, int hrStatus)
            {
                try
                {
                    var shadow = ToShadow<SinkWriterCallbackShadow>(thisPtr);
                    var callback = (ISinkWriterCallback2)shadow.Callback;
                    callback.OnStreamError(dwStreamIndex, hrStatus);
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }
        }

        protected override CppObjectVtbl GetVtbl
        {
            get { return Vtbl; }
        }
    }
}
