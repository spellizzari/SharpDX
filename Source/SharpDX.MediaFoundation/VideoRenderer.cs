using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    partial class VideoRenderer
    {
        /// <summary>	
        /// <p> </p><p>Sets a new mixer or presenter for the enhanced video renderer (EVR).</p>	
        /// </summary>	
        /// <param name="videoMixer"><dd> <p>Pointer to the <strong><see cref="SharpDX.MediaFoundation.Transform"/></strong> interface of the mixer to use. This parameter can be <strong><c>null</c></strong>. If this parameter is <strong><c>null</c></strong>, the EVR uses its default mixer.</p> </dd></param>	
        /// <param name="videoPresenter"><dd> <p>Pointer to the <strong><see cref="SharpDX.MediaFoundation.VideoPresenter"/></strong> interface of the presenter to use. This parameter can be <strong><c>null</c></strong>. If this parameter is <strong><c>null</c></strong>, the EVR uses its default presenter.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> <tr><td> <dl> <dt><strong>E_INVALIDARG</strong></dt> </dl> </td><td> <p>Either the mixer or the presenter is invalid.</p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidRequest"/></strong></dt> </dl> </td><td> <p>The mixer and presenter cannot be replaced in the current state. (EVR media sink.)</p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.Shutdown"/></strong></dt> </dl> </td><td> <p>The video renderer has been shut down.</p> </td></tr> <tr><td> <dl> <dt><strong>VFW_E_WRONG_STATE</strong></dt> </dl> </td><td> <p>One or more input pins are connected. (DirectShow EVR filter.)</p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>Call this method directly after creating the EVR, before you do any of the following:</p><ul> <li> <p>Call <strong><see cref="SharpDX.MediaFoundation.ServiceProvider.GetService"/></strong> on the EVR.</p> </li> <li> <p>Call <strong><see cref="SharpDX.MediaFoundation.FilterConfig.SetNumberOfStreams"/></strong> on the EVR.</p> </li> <li> <p>Connect any pins on the EVR filter, or set any media types on EVR media sink.</p> </li> </ul><p>The EVR filter returns VFW_E_WRONG_STATE if any of the filter's pins are connected. The EVR media sink returns <see cref="SharpDX.MediaFoundation.ResultCode.InvalidRequest"/> if a media type is set on any of the streams, or the presentation clock is running or paused.</p><p>The device identifiers for the mixer and the presenter must match. The <strong><see cref="SharpDX.MediaFoundation.VideoDeviceID.GetDeviceID"/></strong> method returns the device identifier. If they do not match, the method returns E_INVALIDARG.</p><p>If the video renderer is in the protected media path (PMP), the mixer and presenter objects must be certified safe components and pass any trust authority verification that is being enforced. Otherwise, this method will fail.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFVideoRenderer::InitializeRenderer']/*"/>	
        /// <msdn-id>ms704667</msdn-id>	
        /// <unmanaged>HRESULT IMFVideoRenderer::InitializeRenderer([In, Optional] IMFTransform* pVideoMixer,[In, Optional] IMFVideoPresenter* pVideoPresenter)</unmanaged>	
        /// <unmanaged-short>IMFVideoRenderer::InitializeRenderer</unmanaged-short>	
        public void InitializeRenderer(Transform videoMixer, ComObject videoPresenter)
        {
            InitializeRenderer_(videoMixer, videoPresenter?.NativePointer ?? IntPtr.Zero);
        }
    }
}
