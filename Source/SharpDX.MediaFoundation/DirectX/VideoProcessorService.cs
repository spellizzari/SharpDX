// Copyright (c) 2010-2014 SharpDX - SharpDX Team
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

namespace SharpDX.MediaFoundation.DirectX
{
    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps only</p><p>Provides access to DirectX Video Acceleration (DXVA) video processing services.</p><p>Use this interface to query which hardware-accelerated video processing operations are available and to create DXVA video processor devices. To obtain a reference to this interface, call <strong><see cref="SharpDX.MediaFoundation.DirectX.Direct3DDeviceManager.GetVideoService"/></strong> or <strong><see cref="SharpDX.MediaFoundation.DirectX.DXVAFactory.CreateVideoService"/></strong> with the interface identifier <strong>IID_IDirectXVideoProcessorService</strong>.</p>	
    /// </summary>	
    /// <include file='..\Documentation\CodeComments.xml' path="/comments/comment[@id='IDirectXVideoProcessorService']/*"/>	
    /// <msdn-id>ms705631</msdn-id>	
    /// <unmanaged>IDirectXVideoProcessorService</unmanaged>	
    /// <unmanaged-short>IDirectXVideoProcessorService</unmanaged-short>
    public partial class VideoProcessorService
    {
        /// <summary>	
        /// <p><strong>Applies to: </strong>desktop apps only</p><p>Creates a DirectX Video Acceleration (DXVA) services object. Call this function if your application uses DXVA directly, without using DirectShow or Media Foundation. </p>	
        /// </summary>	
        /// <param name="device"><dd> <p> A reference to the <strong><see cref="SharpDX.Direct3D9.Device"/></strong> interface of a Direct3D device. </p> </dd></param>	
        /// <returns><p>If this function succeeds, it returns <strong><see cref="SharpDX.Result.Ok"/></strong>. Otherwise, it returns an <strong><see cref="SharpDX.Result"/></strong> error code.</p></returns>	
        /// <include file='..\Documentation\CodeComments.xml' path="/comments/comment[@id='DXVA2CreateVideoService']/*"/>	
        /// <msdn-id>ms704721</msdn-id>	
        /// <unmanaged>HRESULT DXVA2CreateVideoService([In] IDirect3DDevice9* pDD,[In] const GUID&amp; riid,[Out] void** ppService)</unmanaged>	
        /// <unmanaged-short>DXVA2CreateVideoService</unmanaged-short>	        
        public VideoProcessorService(SharpDX.Direct3D9.Device device)
            : base(device)
        {
        }

        /// <summary>	
        /// <p> Gets an array of GUIDs which identify the video processors supported by the graphics hardware. </p>	
        /// </summary>	
        /// <param name="videoDesc"><dd> <p> Pointer to a <strong><see cref="SharpDX.MediaFoundation.DirectX.VideoDesc"/></strong> structure that describes the video content. </p> </dd></param>	
        /// <param name="guids"><dd> <p> Receives an array of GUIDs. The size of the array is retrieved in the <em>pCount</em> parameter. The method allocates the memory for the array. The caller must free the memory by calling <strong>CoTaskMemFree</strong>. </p> </dd></param>	
        /// <returns><p>If this method succeeds, it returns <strong><see cref="SharpDX.Result.Ok"/></strong>. Otherwise, it returns an <strong><see cref="SharpDX.Result"/></strong> error code.</p></returns>	
        /// <remarks>	
        /// <p>The following video processor GUIDs are predefined.</p><table> <tr><th><see cref="System.Guid"/></th><th>Description</th></tr> <tr><td><strong>DXVA2_VideoProcBobDevice</strong></td><td>Bob deinterlace device. This device uses a "bob" algorithm to deinterlace the video. Bob algorithms create missing field lines by interpolating the lines in a single field.</td></tr> <tr><td><strong>DXVA2_VideoProcProgressiveDevice</strong></td><td>Progressive video device. This device is available for progressive video, which does not require a deinterlace algorithm.</td></tr> <tr><td><strong>DXVA2_VideoProcSoftwareDevice</strong></td><td>Reference (software) device.</td></tr> </table><p>?</p><p>The graphics device may define additional vendor-specific GUIDs. The driver provides the list of GUIDs in descending quality order. The mode with the highest quality is first in the list. To get the capabilities of each mode, call <strong><see cref="SharpDX.MediaFoundation.DirectX.VideoProcessorService.GetVideoProcessorCaps"/></strong> and pass in the <see cref="System.Guid"/> for the mode.</p>	
        /// </remarks>	
        /// <msdn-id>ms695370</msdn-id>	
        /// <unmanaged>HRESULT IDirectXVideoProcessorService::GetVideoProcessorDeviceGuids([In] const DXVA2_VideoDesc* pVideoDesc,[Out] unsigned int* pCount,[Out, Buffer, Optional] GUID** pGuids)</unmanaged>	
        /// <unmanaged-short>IDirectXVideoProcessorService::GetVideoProcessorDeviceGuids</unmanaged-short>	
        public void GetVideoProcessorDeviceGuids(ref VideoDesc videoDesc, out System.Guid[] guids)
        {
            unsafe
            {
                int countRef_ = 0;
                IntPtr guidsRef_ = IntPtr.Zero;
                Result __result__;
                fixed (void* videoDescRef_ = &videoDesc)
                    __result__ =
                    LocalInterop.Calliint(_nativePointer, videoDescRef_, &countRef_, &guidsRef_, ((void**)(*(void**)_nativePointer))[5]);
                if (guidsRef_ == IntPtr.Zero)
                    guids = null;
                else
                {
                    guids = new Guid[countRef_];
                    for (int i = 0; i < countRef_; i++)
                        guids[i] = ((Guid*)guidsRef_)[i];
                    Marshal.FreeCoTaskMem(guidsRef_);
                }
                __result__.CheckError();
            }
        }

        /// <summary>	
        /// <p> Gets the render target formats that a video processor device supports. The list may include RGB and YUV formats. </p>	
        /// </summary>	
        /// <param name="videoProcDeviceGuid"><dd> <p> A <see cref="System.Guid"/> that identifies the video processor device. To get the list of video processor GUIDs, call <strong><see cref="SharpDX.MediaFoundation.DirectX.VideoProcessorService.GetVideoProcessorDeviceGuids"/></strong>.</p> </dd></param>	
        /// <param name="videoDesc"><dd> <p> A reference to a <strong><see cref="SharpDX.MediaFoundation.DirectX.VideoDesc"/></strong> structure that describes the video content. </p> </dd></param>	
        /// <param name="formats"><dd> <p> Receives an array of formats, specified as <strong><see cref="SharpDX.Direct3D9.Format"/></strong> values. The size of the array is retrieved in the <em>pCount</em> parameter. The method allocates the memory for the array. The caller must free the memory by calling <strong>CoTaskMemFree</strong>. </p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> </table><p>?</p></returns>	
        /// <msdn-id>ms702118</msdn-id>	
        /// <unmanaged>HRESULT IDirectXVideoProcessorService::GetVideoProcessorRenderTargets([In] const GUID&amp; VideoProcDeviceGuid,[In] const DXVA2_VideoDesc* pVideoDesc,[Out] unsigned int* pCount,[Out, Buffer, Optional] D3DFORMAT** pFormats)</unmanaged>	
        /// <unmanaged-short>IDirectXVideoProcessorService::GetVideoProcessorRenderTargets</unmanaged-short>	
        public void GetVideoProcessorRenderTargets(Guid videoProcDeviceGuid, ref VideoDesc videoDesc, out Direct3D9.Format[] formats)
        {
            unsafe
            {
                int countRef_ = 0;
                IntPtr formatsRef_ = IntPtr.Zero;
                SharpDX.Result __result__;
                fixed (void* videoDescRef_ = &videoDesc)
                    __result__ =
                    LocalInterop.Calliint(_nativePointer, &videoProcDeviceGuid, videoDescRef_, &countRef_, &formatsRef_, ((void**)(*(void**)_nativePointer))[6]);
                if (formatsRef_ == IntPtr.Zero)
                    formats = null;
                else
                {
                    formats = new Direct3D9.Format[countRef_];
                    for (int i = 0; i < countRef_; i++)
                        formats[i] = ((Direct3D9.Format*)formatsRef_)[i];
                    Marshal.FreeCoTaskMem(formatsRef_);
                }
                __result__.CheckError();
            }
        }

        /// <summary>	
        /// <p> Gets a list of substream formats supported by a specified video processor device. </p>	
        /// </summary>	
        /// <param name="videoProcDeviceGuid"><dd> <p> A <see cref="System.Guid"/> that identifies the video processor device.  To get the list of video processor GUIDs, call <strong><see cref="SharpDX.MediaFoundation.DirectX.VideoProcessorService.GetVideoProcessorDeviceGuids"/></strong>.</p> </dd></param>	
        /// <param name="videoDesc"><dd> <p> A reference to a <strong><see cref="SharpDX.MediaFoundation.DirectX.VideoDesc"/></strong> structure that describes the video content. </p> </dd></param>	
        /// <param name="renderTargetFormat"><dd> <p> The format of the render target surface, specified as a <strong><see cref="SharpDX.Direct3D9.Format"/></strong> value. For more information, see the Direct3D documentation. You can also use a FOURCC code to specify a format that is not defined in the <strong><see cref="SharpDX.Direct3D9.Format"/></strong> enumeration. See Video FOURCCs. </p> </dd></param>	
        /// <param name="countRef"><dd> <p> Receives the number of elements returned in the <em>ppFormats</em> array. </p> </dd></param>	
        /// <param name="formats"><dd> <p> Receives an array of <strong><see cref="SharpDX.Direct3D9.Format"/></strong> values. The caller must free the array by calling <strong>CoTaskMemFree</strong>. The array can contain both RGB and YUB pixel formats. </p> </dd></param>	
        /// <returns><p>If this method succeeds, it returns <strong><see cref="SharpDX.Result.Ok"/></strong>. Otherwise, it returns an <strong><see cref="SharpDX.Result"/></strong> error code.</p></returns>	
        /// <msdn-id>ms694271</msdn-id>	
        /// <unmanaged>HRESULT IDirectXVideoProcessorService::GetVideoProcessorSubStreamFormats([In] const GUID&amp; VideoProcDeviceGuid,[In] const DXVA2_VideoDesc* pVideoDesc,[In] D3DFORMAT RenderTargetFormat,[Out] unsigned int* pCount,[Out, Buffer, Optional] D3DFORMAT** pFormats)</unmanaged>	
        /// <unmanaged-short>IDirectXVideoProcessorService::GetVideoProcessorSubStreamFormats</unmanaged-short>	
        public void GetVideoProcessorSubStreamFormats(Guid videoProcDeviceGuid, ref VideoDesc videoDesc, Direct3D9.Format renderTargetFormat, out Direct3D9.Format[] formats)
        {
            unsafe
            {
                int countRef_ = 0;
                IntPtr formatsRef_ = IntPtr.Zero;
                SharpDX.Result __result__;
                fixed (void* videoDescRef_ = &videoDesc)
                    __result__ =
                    LocalInterop.Calliint(_nativePointer, &videoProcDeviceGuid, videoDescRef_, unchecked((int)renderTargetFormat), &countRef_, &formatsRef_, ((void**)(*(void**)_nativePointer))[7]);
                if (formatsRef_ == IntPtr.Zero)
                    formats = null;
                else
                {
                    formats = new Direct3D9.Format[countRef_];
                    for (int i = 0; i < countRef_; i++)
                        formats[i] = ((Direct3D9.Format*)formatsRef_)[i];
                    Marshal.FreeCoTaskMem(formatsRef_);
                }
                __result__.CheckError();
            }
        }
    }
}