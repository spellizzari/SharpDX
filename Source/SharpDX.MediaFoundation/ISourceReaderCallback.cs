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
    public partial interface ISourceReaderCallback
    {
        /// <summary>	
        /// <p>Called when the <strong><see cref="SharpDX.MediaFoundation.SourceReader.ReadSample"/></strong> method completes.</p>	
        /// </summary>	
        /// <param name="hrStatus">No documentation.</param>	
        /// <param name="dwStreamIndex">No documentation.</param>	
        /// <param name="dwStreamFlags">No documentation.</param>	
        /// <param name="llTimestamp">No documentation.</param>	
        /// <param name="sampleRef">No documentation.</param>	
        /// <returns><p>Returns an <strong><see cref="SharpDX.Result"/></strong> value. Currently, the source reader ignores the return value.</p></returns>	
        /// <remarks>	
        /// <p>The <em>pSample</em> parameter might be <strong><c>null</c></strong>. For example, when the source reader reaches the end of a stream, <em>dwStreamFlags</em> contains the <strong><see cref="SharpDX.MediaFoundation.SourceReaderFlags.Endofstream"/></strong> flag, and <em>pSample</em> is <strong><c>null</c></strong>. </p><p>If there is a gap in the stream, <em>dwStreamFlags</em> contains the <strong><see cref="SharpDX.MediaFoundation.SourceReaderFlags.StreamTick"/></strong> flag, <em>pSample</em> is <strong><c>null</c></strong>, and <em>llTimestamp</em> indicates the time when the gap occurred.  </p><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFSourceReaderCallback::OnReadSample']/*"/>	
        /// <msdn-id>dd374658</msdn-id>	
        /// <unmanaged>HRESULT IMFSourceReaderCallback::OnReadSample([In] HRESULT hrStatus,[In] unsigned int dwStreamIndex,[In] unsigned int dwStreamFlags,[In] longlong llTimestamp,[In, Optional] IMFSample* pSample)</unmanaged>	
        /// <unmanaged-short>IMFSourceReaderCallback::OnReadSample</unmanaged-short>	
        void OnReadSample(Result hrStatus, int dwStreamIndex, SourceReaderFlags dwStreamFlags, long llTimestamp, Sample sampleRef);

        /// <summary>	
        /// <p>Called when the <strong><see cref="SharpDX.MediaFoundation.SourceReader.Flush"/></strong> method completes.</p>	
        /// </summary>	
        /// <param name="dwStreamIndex">No documentation.</param>	
        /// <returns><p>Returns an <strong><see cref="SharpDX.Result"/></strong> value. Currently, the source reader ignores the return value.</p></returns>	
        /// <remarks>	
        /// <p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFSourceReaderCallback::OnFlush']/*"/>	
        /// <msdn-id>dd374657</msdn-id>	
        /// <unmanaged>HRESULT IMFSourceReaderCallback::OnFlush([In] unsigned int dwStreamIndex)</unmanaged>	
        /// <unmanaged-short>IMFSourceReaderCallback::OnFlush</unmanaged-short>	
        void OnFlush(int dwStreamIndex);

        /// <summary>	
        /// <p>Called when the source reader receives certain events from the media source.</p>	
        /// </summary>	
        /// <param name="dwStreamIndex"><dd> <p>For stream events, the value is the zero-based index of the stream that sent the event. For source events, the value is <strong><see cref="SharpDX.MediaFoundation.SourceReaderIndex.MediaSource"/></strong>.</p> </dd></param>	
        /// <param name="eventRef"><dd> <p>A reference to the <strong><see cref="SharpDX.MediaFoundation.MediaEvent"/></strong> interface of the event.</p> </dd></param>	
        /// <returns><p>Returns an <strong><see cref="SharpDX.Result"/></strong> value. Currently, the source reader ignores the return value.</p></returns>	
        /// <remarks>	
        /// <p>In the current implementation,  the source reader uses this method to forward the following events to the application:</p><ul> <li> <see cref="SharpDX.MediaFoundation.MediaEventTypes.BufferingStarted"/> </li> <li> <see cref="SharpDX.MediaFoundation.MediaEventTypes.BufferingStopped"/> </li> <li> <see cref="SharpDX.MediaFoundation.MediaEventTypes.ConnectEnd"/> </li> <li> <see cref="SharpDX.MediaFoundation.MediaEventTypes.ConnectStart"/> </li> <li> <see cref="SharpDX.MediaFoundation.MediaEventTypes.ExtendedType"/> </li> <li> <see cref="SharpDX.MediaFoundation.MediaEventTypes.SourceCharacteristicsChanged"/> </li> <li> <see cref="SharpDX.MediaFoundation.MediaEventTypes.SourceMetadataChanged"/> </li> </ul><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFSourceReaderCallback::OnEvent']/*"/>	
        /// <msdn-id>dd743367</msdn-id>	
        /// <unmanaged>HRESULT IMFSourceReaderCallback::OnEvent([In] unsigned int dwStreamIndex,[In] IMFMediaEvent* pEvent)</unmanaged>	
        /// <unmanaged-short>IMFSourceReaderCallback::OnEvent</unmanaged-short>	
        void OnEvent(int dwStreamIndex, MediaEvent eventRef);
    }
}
