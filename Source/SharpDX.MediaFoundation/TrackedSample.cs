using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    partial class TrackedSample
    {
        /// <summary>	
        /// <p> </p><p>Sets the owner for the sample.</p>	
        /// </summary>	
        /// <param name="sampleAllocator"><dd> <p>Pointer to the <strong><see cref="SharpDX.MediaFoundation.IAsyncCallback"/></strong> interface of a callback object. The caller must implement this interface.</p> </dd></param>	
        /// <param name="unkState"><dd> <p>Pointer to the <strong><see cref="SharpDX.ComObject"/></strong> interface of a state object, defined by the caller. This parameter can be <strong><c>null</c></strong>. You can use this object to hold state information. The object is returned to the caller when the callback is invoked.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.NotAccepting"/></strong></dt> </dl> </td><td> <p>The owner was already set. This method cannot be called twice on the sample.</p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>When this method is called, the sample holds an additional reference count on itself. When every other object releases its reference counts on the sample, the sample invokes the <em>pSampleAllocator</em> callback method. To get a reference to the sample, call <strong><see cref="SharpDX.MediaFoundation.AsyncResult.GetObject"/></strong> on the asynchronous result object given to the callback's <strong><see cref="SharpDX.MediaFoundation.IAsyncCallback.Invoke"/></strong> method.</p><p>After the callback is invoked, the sample clears the callback. To reinstate the callback, you must call <strong>SetAllocator</strong> again.</p><p>It is safe to pass in the sample's <strong><see cref="SharpDX.MediaFoundation.Sample"/></strong> interface reference as the state object (<em>pUnkState</em>) for the callback. If <em>pUnkState</em> points to the sample, the <strong>SetAllocator</strong> method accounts for the additional reference count on <em>pUnkState</em>.</p>	
        /// </remarks>	
        /// <msdn-id>ms704797</msdn-id>	
        /// <unmanaged>HRESULT IMFTrackedSample::SetAllocator([In] IMFAsyncCallback* pSampleAllocator,[In] void* pUnkState)</unmanaged>	
        /// <unmanaged-short>IMFTrackedSample::SetAllocator</unmanaged-short>	
        public void SetAllocator(IAsyncCallback sampleAllocator, IntPtr unkState)
        {
            unsafe
            {
                SharpDX.Result __result__;
                __result__ =
                SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, (void*)AsyncCallbackShadow.ToIntPtr(sampleAllocator), (void*)unkState, ((void**)(*(void**)_nativePointer))[3]);
                __result__.CheckError();
            }
        }
    }
}
