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

namespace SharpDX.MediaFoundation
{
    [Shadow(typeof(SinkWriterCallbackShadow))]
    public partial interface ISinkWriterCallback
    {
        /// <summary>	
        /// <p>Called when the <strong><see cref="SharpDX.MediaFoundation.SinkWriter.Finalize"/></strong> method completes.</p>	
        /// </summary>	
        /// <param name="hrStatus">No documentation.</param>	
        /// <returns><p>Returns an <strong><see cref="SharpDX.Result"/></strong> value. Currently, the sink writer ignores the return value.</p></returns>	
        /// <remarks>	
        /// <p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFSinkWriterCallback::OnFinalize']/*"/>	
        /// <msdn-id>dd374644</msdn-id>	
        /// <unmanaged>HRESULT IMFSinkWriterCallback::OnFinalize([In] HRESULT hrStatus)</unmanaged>	
        /// <unmanaged-short>IMFSinkWriterCallback::OnFinalize</unmanaged-short>	
        void OnFinalize(SharpDX.Result hrStatus);

        /// <summary>	
        /// <p>Called when the <strong><see cref="SharpDX.MediaFoundation.SinkWriter.PlaceMarker"/></strong> method completes.</p>	
        /// </summary>	
        /// <param name="dwStreamIndex">No documentation.</param>	
        /// <param name="vContextRef">No documentation.</param>	
        /// <returns><p>Returns an <strong><see cref="SharpDX.Result"/></strong> value. Currently, the sink writer ignores the return value.</p></returns>	
        /// <remarks>	
        /// <p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFSinkWriterCallback::OnMarker']/*"/>	
        /// <msdn-id>dd374645</msdn-id>	
        /// <unmanaged>HRESULT IMFSinkWriterCallback::OnMarker([In] unsigned int dwStreamIndex,[In] void* pvContext)</unmanaged>	
        /// <unmanaged-short>IMFSinkWriterCallback::OnMarker</unmanaged-short>	
        void OnMarker(int dwStreamIndex, System.IntPtr vContextRef);
    }
}
