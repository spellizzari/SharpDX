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
    [Shadow(typeof(SourceReaderCallbackShadow))]
    public partial interface ISourceReaderCallback2
    {
        /// <summary>	
        /// <p>[Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.]</p><p>Called when the transform chain in the <strong><see cref="SharpDX.MediaFoundation.SourceReader"/></strong> is built or modified.</p>	
        /// </summary>	
        /// <returns><p>Returns an <strong><see cref="SharpDX.Result"/></strong> value. Currently, the source reader ignores the return value.</p></returns>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFSourceReaderCallback2::OnTransformChange']/*"/>	
        /// <msdn-id>dn949420</msdn-id>	
        /// <unmanaged>HRESULT IMFSourceReaderCallback2::OnTransformChange()</unmanaged>	
        /// <unmanaged-short>IMFSourceReaderCallback2::OnTransformChange</unmanaged-short>	
        void OnTransformChange();

        /// <summary>	
        /// <p>[Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.]</p><p>Called when an asynchronous error occurs with the <strong><see cref="SharpDX.MediaFoundation.SourceReader"/></strong>.</p>	
        /// </summary>	
        /// <param name="dwStreamIndex">No documentation.</param>	
        /// <param name="hrStatus">No documentation.</param>	
        /// <returns><p>Returns an <strong><see cref="SharpDX.Result"/></strong> value. Currently, the source reader ignores the return value.</p></returns>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFSourceReaderCallback2::OnStreamError']/*"/>	
        /// <msdn-id>dn949419</msdn-id>	
        /// <unmanaged>HRESULT IMFSourceReaderCallback2::OnStreamError([In] unsigned int dwStreamIndex,[In] HRESULT hrStatus)</unmanaged>	
        /// <unmanaged-short>IMFSourceReaderCallback2::OnStreamError</unmanaged-short>	
        void OnStreamError(int dwStreamIndex, Result hrStatus);
    }
}
