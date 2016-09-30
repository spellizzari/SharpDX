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
    /// Internal SourceReaderCallback Callback
    /// </summary>
    internal class SourceReaderCallbackShadow : SharpDX.ComObjectShadow
    {
        private static readonly SourceReaderCallbackVtbl Vtbl = new SourceReaderCallbackVtbl();

        /// <summary>
        /// Return a pointer to the unmanaged version of this callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <returns>A pointer to a shadow c++ callback</returns>
        public static IntPtr ToIntPtr(ISourceReaderCallback2 callback)
        {
            return ToCallbackPtr<ISourceReaderCallback2>(callback);
        }

        public class SourceReaderCallbackVtbl : ComObjectVtbl
        {
            public SourceReaderCallbackVtbl() : base(5)
            {
                AddMethod(new OnReadSampleDelegate(OnReadSampleImpl));
                AddMethod(new OnFlushDelegate(OnFlushImpl));
                AddMethod(new OnEventDelegate(OnEventImpl));
                AddMethod(new OnTransformChangeDelegate(OnTransformChangeImpl));
                AddMethod(new OnStreamErrorDelegate(OnStreamErrorImpl));
            }

            /// <unmanaged>HRESULT OnReadSample(HRESULT hrStatus, DWORD dwStreamIndex, DWORD dwStreamFlags, LONGLONG llTimestamp, IMFSample* pSample)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnReadSampleDelegate(IntPtr thisPtr, int hrStatus, int dwStreamIndex, SourceReaderFlags dwStreamFlags, long llTimestamp, IntPtr pSample);
            private static int OnReadSampleImpl(IntPtr thisPtr, int hrStatus, int dwStreamIndex, SourceReaderFlags dwStreamFlags, long llTimestamp, IntPtr pSample)
            {
                try
                {
                    var shadow = ToShadow<SourceReaderCallbackShadow>(thisPtr);
                    var callback = (ISourceReaderCallback)shadow.Callback;
                    callback.OnReadSample(hrStatus, dwStreamIndex, dwStreamFlags, llTimestamp, pSample == IntPtr.Zero ? null : new Sample(pSample));
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }

            /// <unmanaged>HRESULT OnFlush(DWORD dwStreamIndex)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnFlushDelegate(IntPtr thisPtr, int dwStreamIndex);
            private static int OnFlushImpl(IntPtr thisPtr, int dwStreamIndex)
            {
                try
                {
                    var shadow = ToShadow<SourceReaderCallbackShadow>(thisPtr);
                    var callback = (ISourceReaderCallback)shadow.Callback;
                    callback.OnFlush(dwStreamIndex);
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }

            /// <unmanaged>HRESULT OnEvent(DWORD dwStreamIndex, IMFMediaEvent *pEvent)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnEventDelegate(IntPtr thisPtr, int dwStreamIndex, IntPtr pEvent);
            private static int OnEventImpl(IntPtr thisPtr, int dwStreamIndex, IntPtr pEvent)
            {
                try
                {
                    var shadow = ToShadow<SourceReaderCallbackShadow>(thisPtr);
                    var callback = (ISourceReaderCallback)shadow.Callback;
                    callback.OnEvent(dwStreamIndex, pEvent == IntPtr.Zero ? null : new MediaEvent(pEvent));
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }

            /// <unmanaged>HRESULT OnTransformChange(void)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnTransformChangeDelegate(IntPtr thisPtr);
            private static int OnTransformChangeImpl(IntPtr thisPtr)
            {
                try
                {
                    var shadow = ToShadow<SourceReaderCallbackShadow>(thisPtr);
                    var callback = (ISourceReaderCallback2)shadow.Callback;
                    callback.OnTransformChange();
                }
                catch (Exception exception)
                {
                    return (int)Result.GetResultFromException(exception);
                }
                return Result.Ok.Code;
            }

            /// <unmanaged>HRESULT OnStreamError(_In_ DWORD dwStreamIndex, _In_ HRESULT hrStatus)</unmanaged>	
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int OnStreamErrorDelegate(IntPtr thisPtr, int dwStreamIndex, int hrStatus);
            private static int OnStreamErrorImpl(IntPtr thisPtr, int dwStreamIndex, int hrStatus)
            {
                try
                {
                    var shadow = ToShadow<SourceReaderCallbackShadow>(thisPtr);
                    var callback = (ISourceReaderCallback2)shadow.Callback;
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
