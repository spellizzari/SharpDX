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

namespace SharpDX.MediaFoundation
{
    public partial class Transform
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.MediaFoundation.Transform"/> class.
        /// </summary>
        /// <param name="guid">Guid of the Media Foundation Transform.</param>
        public Transform(Guid guid)
        {
            Utilities.CreateComInstance(guid, Utilities.CLSCTX.ClsctxInprocServer, Utilities.GetGuidFromType(typeof(Transform)), this);
        }

        /// <summary>	
        /// <p> Adds one or more new input streams to this Media Foundation transform (MFT). </p>	
        /// </summary>	
        /// <param name="streamIDs"><dd> <p> Array of stream identifiers. The new stream identifiers must not match any existing input streams. </p> </dd></param>	
        /// <msdn-id>ms696211</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::AddInputStreams([In] unsigned int cStreams,[Buffer] unsigned int* adwStreamIDs)</unmanaged>	
        /// <unmanaged-short>IMFTransform::AddInputStreams</unmanaged-short>	
        public void AddInputStreams(int[] streamIDs)
        {
            AddInputStreams(streamIDs?.Length ?? 0, streamIDs);
        }

        /// <summary>
        /// Gets the stream identifiers for the input and output streams on this Media Foundation transform (MFT).
        /// </summary>
        /// <param name="dwInputIDsRef">An array allocated by the caller. The method fills the array with the input stream identifiers. The array size must be at least equal to the number of input streams. To get the number of input streams, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamCount" /></strong>.<para>If the caller passes an array that is larger than the number of input streams, the MFT must not write values into the extra array entries.</para></param>
        /// <param name="dwOutputIDsRef">An array allocated by the caller. The method fills the array with the output stream identifiers. The array size must be at least equal to the number of output streams. To get the number of output streams, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamCount" /></strong>.<para>If the caller passes an array that is larger than the number of output streams, the MFT must not write values into the extra array entries.</para></param>
        /// <returns><c>true</c> if Both streams IDs for input and output are valid, <c>false</c> otherwise</returns>
        /// <msdn-id>ms693988</msdn-id>
        ///   <unmanaged>HRESULT IMFTransform::GetStreamIDs([In] unsigned int dwInputIDArraySize,[Out, Buffer] unsigned int* pdwInputIDs,[In] unsigned int dwOutputIDArraySize,[Out, Buffer] unsigned int* pdwOutputIDs)</unmanaged>
        ///   <unmanaged-short>IMFTransform::GetStreamIDs</unmanaged-short>
        public bool TryGetStreamIDs(int[] dwInputIDsRef, int[] dwOutputIDsRef)
        {
            bool isStreamIDsValid = true;
            var result = GetStreamIDs(dwInputIDsRef.Length, dwInputIDsRef, dwOutputIDsRef.Length, dwOutputIDsRef);

            //if not implemented
            if (result == Result.NotImplemented)
            {
                isStreamIDsValid = false;
            }
            else
            {
                result.CheckError();
            }

            return isStreamIDsValid;
        }

        /// <summary>
        /// Generates output from the current input data.
        /// </summary>
        /// <param name="flags">Bitwise OR of zero or more flags from the <strong><see cref="SharpDX.MediaFoundation.TransformProcessOutputFlags" /></strong> enumeration.</param>
        /// <param name="outputSamples">Pointer to an array of <strong><see cref="SharpDX.MediaFoundation.TOutputDataBuffer" /></strong> structures, allocated by the caller. The MFT uses this array to return output data to the caller.</param>
        /// <param name="status">Receives a bitwise OR of zero or more flags from the <strong><see cref="SharpDX.MediaFoundation.TransformProcessOutputStatus" /></strong> enumeration.</param>
        /// <returns><c>true</c> if the transform cannot produce output data until it receives more input data, <c>false</c> otherwise</returns>
        /// <msdn-id>ms704014</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::ProcessOutput([In] _MFT_PROCESS_OUTPUT_FLAGS dwFlags,[In] unsigned int cOutputBufferCount,[In] MFT_OUTPUT_DATA_BUFFER* pOutputSamples,[Out] _MFT_PROCESS_OUTPUT_STATUS* pdwStatus)</unmanaged>	
        /// <unmanaged-short>IMFTransform::ProcessOutput</unmanaged-short>	
        public Result ProcessOutput(TransformProcessOutputFlags flags, TOutputDataBuffer[] outputSamples, out TransformProcessOutputStatus status)
        {
            unsafe
            {
                SharpDX.Result __result__;
                fixed (void* dwStatusRef_ = &status)
                fixed (TOutputDataBuffer* outputSamplesRef = outputSamples)
                    __result__ =
                    SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, unchecked((int)flags), outputSamples.Length, outputSamplesRef, dwStatusRef_, ((void**)(*(void**)_nativePointer))[25]);
                return __result__;
            }
        }

        /// <summary>	
        /// <p> Gets an available media type for an input stream on this Media Foundation transform (MFT). </p>	
        /// </summary>	
        /// <param name="dwInputStreamID"><dd> <p> Input stream identifier. To get the list of stream identifiers, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamIDs"/></strong>. </p> </dd></param>	
        /// <param name="dwTypeIndex"><dd> <p> Index of the media type to retrieve. Media types are indexed from zero and returned in approximate order of preference. </p> </dd></param>	
        /// <param name="typeOut"><dd> <p> Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface. </p> </dd></param>	
        /// <returns><p> The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table. </p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong>E_NOTIMPL</strong></dt> </dl> </td><td> <p> The MFT does not have a list of available input types. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidStreamNumber"/></strong></dt> </dl> </td><td> <p> Invalid stream identifier. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.NoMoreTypes"/></strong></dt> </dl> </td><td> <p> The <em>dwTypeIndex</em> parameter is out of range. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong></dt> </dl> </td><td> <p> You must set the output types before setting the input types. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> The MFT defines a list of available media types for each input stream and orders them by preference. This method enumerates the available media types for an input stream. To enumerate the available types, increment <em>dwTypeIndex</em> until the method returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.NoMoreTypes"/></strong>. </p><p> Setting the media type on one stream might change the available types for another stream, or change the preference order. However, an MFT is not required to update the list of available types dynamically. The only guaranteed way to test whether you can set a particular input type is to call <strong><see cref="SharpDX.MediaFoundation.Transform.SetInputType"/></strong>. </p><p> In some cases, an MFT cannot return a list of input types until one or more output types are set. If so, the method returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong>. </p><p> An MFT is not required to implement this method. However, most MFTs should implement this method, unless the supported types are simple and can be discovered through the <strong><see cref="SharpDX.MediaFoundation.MediaFactory.TGetInfo"/></strong> function.</p><p>If <strong>MFT_UNIQUE_METHOD_NAMES</strong> is defined before including mftransform.h, this method is renamed <strong>MFTGetInputAvailableType</strong>. See Creating Hybrid DMO/MFT Objects.</p><p>For encoders, after the output type is set, <strong>GetInputAvailableType</strong> must return a list of input types that are compatible with the current output type. This means that all types returned by <strong>GetInputAvailableType</strong> after the output type is set must be valid types for <strong>SetInputType</strong>.</p><p>Encoders should reject input types if the attributes of the input media type and output media type do not match, such as resolution setting with <see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.FrameSize"/>, nominal range setting with <see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.VideoNominalRange"/>, or frame rate setting with <see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.FrameSize"/></p>	
        /// </remarks>	
        /// <msdn-id>ms704814</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::GetInputAvailableType([In] unsigned int dwInputStreamID,[In] unsigned int dwTypeIndex,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFTransform::GetInputAvailableType</unmanaged-short>	
        public bool TryGetInputAvailableType(int dwInputStreamID, int dwTypeIndex, out SharpDX.MediaFoundation.MediaType typeOut)
        {
            unsafe
            {
                IntPtr typeOut_ = IntPtr.Zero;
                var result = (Result)LocalInterop.Calliint(_nativePointer, dwInputStreamID, dwTypeIndex, &typeOut_, ((void**)(*(void**)_nativePointer))[13]);
                typeOut = (typeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.MediaType(typeOut_);
                if (result.Success)
                    return true;
                if (result == ResultCode.NoMoreTypes)
                    return false;
                result.CheckError();
                return false;
            }
        }

        /// <summary>	
        /// <p> Gets an available media type for an output stream on this Media Foundation transform (MFT). </p>	
        /// </summary>	
        /// <param name="dwOutputStreamID"><dd> <p> Output stream identifier. To get the list of stream identifiers, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamIDs"/></strong>. </p> </dd></param>	
        /// <param name="dwTypeIndex"><dd> <p> Index of the media type to retrieve. Media types are indexed from zero and returned in approximate order of preference. </p> </dd></param>	
        /// <param name="typeOut"><dd> <p> Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface. The caller must release the interface. </p> </dd></param>	
        /// <returns><p> The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table. </p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong>E_NOTIMPL</strong></dt> </dl> </td><td> <p> The MFT does not have a list of available output types. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidStreamNumber"/></strong></dt> </dl> </td><td> <p> Invalid stream identifier. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.NoMoreTypes"/></strong></dt> </dl> </td><td> <p> The <em>dwTypeIndex</em> parameter is out of range. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong></dt> </dl> </td><td> <p> You must set the input types before setting the output types. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> The MFT defines a list of available media types for each output stream and orders them by preference. This method enumerates the available media types for an output stream. To enumerate the available types, increment <em>dwTypeIndex</em> until the method returns MF_<strong>E_NO_MORE_TYPES</strong>. </p><p> Setting the media type on one stream can change the available types for another stream (or change the preference order). However, an MFT is not required to update the list of available types dynamically. The only guaranteed way to test whether you can set a particular input type is to call <strong><see cref="SharpDX.MediaFoundation.Transform.SetOutputType"/></strong>. </p><p> In some cases, an MFT cannot return a list of output types until one or more input types are set. If so, the method returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong>. </p><p> An MFT is not required to implement this method. However, most MFTs should implement this method, unless the supported types are simple and can be discovered through the <strong><see cref="SharpDX.MediaFoundation.MediaFactory.TGetInfo"/></strong> function. </p><p> This method can return a <em>partial</em> media type. A partial media type contains an incomplete description of a format, and is used to provide a hint to the caller. For example, a partial type might include just the major type and subtype GUIDs. However, after the client sets the input types on the MFT, the MFT should generally return at least one complete output type, which can be used without further modification. For more information, see Complete and Partial Media Types.</p><p>Some MFTs cannot provide an accurate list of output types until the MFT receives the first input sample. For example, the MFT might need to read the first packet header to deduce the format. An MFT should handle this situation as follows:</p><ol> <li> Before the MFT receives any input, it offers a list of one or more output types that it could possibly produce. For example, an MPEG-2 decoder might return a media type that describes the MPEG-2 main profile/main level. </li> <li> The client selects one of these types (generally the first) and sets it on the output stream. </li> <li> The client delivers the first input sample by calling <strong><see cref="SharpDX.MediaFoundation.Transform.ProcessInput"/></strong>. </li> <li> If the output type does not conform to the input data, the transform signals a format change in the <strong>ProcessOutput</strong> method. For more information about format changes, see <strong><see cref="SharpDX.MediaFoundation.Transform.ProcessOutput"/></strong>. </li> <li> The calls <strong>GetOutputAvailableType</strong> again. At this point, the method should return an updated list of types that reflects the input data. </li> <li> The client selects a new output type from this list and calls <strong>SetOutputType</strong>. </li> </ol><p>If <strong>MFT_UNIQUE_METHOD_NAMES</strong> is defined before including mftransform.h, this method is renamed <strong>MFTGetOutputAvailableType</strong>. See Creating Hybrid DMO/MFT Objects.</p>	
        /// </remarks>	
        /// <msdn-id>ms703812</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::GetOutputAvailableType([In] unsigned int dwOutputStreamID,[In] unsigned int dwTypeIndex,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFTransform::GetOutputAvailableType</unmanaged-short>	
        public bool TryGetOutputAvailableType(int dwOutputStreamID, int dwTypeIndex, out SharpDX.MediaFoundation.MediaType typeOut)
        {
            unsafe
            {
                IntPtr typeOut_ = IntPtr.Zero;
                var result = (Result)LocalInterop.Calliint(_nativePointer, dwOutputStreamID, dwTypeIndex, &typeOut_, ((void**)(*(void**)_nativePointer))[14]);
                typeOut = (typeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.MediaType(typeOut_);
                if (result.Success)
                    return true;
                if (result == ResultCode.NoMoreTypes)
                    return false;
                result.CheckError();
                return false;
            }
        }

        /*
        /// <summary>	
        /// <p> Sets, tests, or clears the media type for an input stream on this Media Foundation transform (MFT). </p>	
        /// </summary>	
        /// <param name="dwInputStreamID"><dd> <p> Input stream identifier. To get the list of stream identifiers, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamIDs"/></strong>. </p> </dd></param>	
        /// <param name="typeRef"><dd> <p> Pointer to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface, or <strong><c>null</c></strong>. </p> </dd></param>	
        /// <param name="dwFlags"><dd> <p> Zero or more flags from the <strong>_MFT_SET_TYPE_FLAGS</strong> enumeration. </p> </dd></param>	
        /// <returns><p> The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table. </p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidMediaType"/></strong></dt> </dl> </td><td> <p> The MFT cannot use the proposed media type. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidStreamNumber"/></strong></dt> </dl> </td><td> <p> Invalid stream identifier. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidType"/></strong></dt> </dl> </td><td> <p> The proposed type is not valid. This error code indicates that the media type itself is not configured correctly; for example, it might contain mutually contradictory attributes. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformCannotChangeMediaTypeWhileProcessing"/></strong></dt> </dl> </td><td> <p> The MFT cannot switch types while processing data. Try draining or flushing the MFT. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong></dt> </dl> </td><td> <p> You must set the output types before setting the input types. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.UnsupportedD3DType"/></strong></dt> </dl> </td><td> <p> The MFT could not find a suitable DirectX Video Acceleration (DXVA) configuration. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>This method can be used to set, test without setting, or clear the media type:</p><ul> <li> To set the media type, set <em>dwFlags</em> to zero and set <em>pType</em> to a non-<strong><c>null</c></strong> reference that specifies the media type. </li> <li> To test the media type without setting it, set <em>dwFlags</em> to <strong><see cref="SharpDX.MediaFoundation.MftSetTypeFlags.MftSetTypeTestOnly"/></strong> and set <em>pType</em> to a non-<strong><c>null</c></strong> reference that specifies the media type. If the media type is acceptable, the method return <strong><see cref="SharpDX.Result.Ok"/></strong>. Otherwise, it returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidMediaType"/></strong>. Regardless of the return value, the current media type does not change. </li> <li> To clear the media type, set <em>pType</em> to <strong><c>null</c></strong>. </li> </ul><p> Setting the media type on one stream may change the acceptable types on another stream. </p><p> An MFT may require the caller to set one or more output types before setting the input type. If so, the method returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong>. </p><p> If the MFT supports DirectX Video Acceleration (DXVA) but is unable to find a suitable DXVA configuration (for example, if the graphics driver does not have the right capabilities), the method should return <strong><see cref="SharpDX.MediaFoundation.ResultCode.UnsupportedD3DType"/></strong>. For more information, see Supporting DXVA 2.0 in Media Foundation. </p><p>If <strong>MFT_UNIQUE_METHOD_NAMES</strong> is defined before including mftransform.h, this method is renamed <strong>MFTSetInputType</strong>. See Creating Hybrid DMO/MFT Objects.</p>	
        /// </remarks>	
        /// <msdn-id>ms700113</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::SetInputType([In] unsigned int dwInputStreamID,[In, Optional] IMFMediaType* pType,[In] unsigned int dwFlags)</unmanaged>	
        /// <unmanaged-short>IMFTransform::SetInputType</unmanaged-short>	
        public void SetInputType(int dwInputStreamID, SharpDX.MediaFoundation.MediaType typeRef, int dwFlags)
        {
            unsafe
            {
                SharpDX.Result __result__;
                __result__ =
                SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, dwInputStreamID, (void*)((typeRef == null) ? IntPtr.Zero : typeRef.NativePointer), dwFlags, ((void**)(*(void**)_nativePointer))[15]);
                __result__.CheckError();
            }
        }

        /// <summary>	
        /// <p> Sets, tests, or clears the media type for an output stream on this Media Foundation transform (MFT). </p>	
        /// </summary>	
        /// <param name="dwOutputStreamID"><dd> <p> Output stream identifier. To get the list of stream identifiers, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamIDs"/></strong>. </p> </dd></param>	
        /// <param name="typeRef"><dd> <p> Pointer to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface, or <strong><c>null</c></strong>. </p> </dd></param>	
        /// <param name="dwFlags"><dd> <p> Zero or more flags from the <strong>_MFT_SET_TYPE_FLAGS</strong> enumeration. </p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidMediaType"/></strong></dt> </dl> </td><td> <p> The transform cannot use the proposed media type. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidStreamNumber"/></strong></dt> </dl> </td><td> <p> Invalid stream identifier. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidType"/></strong></dt> </dl> </td><td> <p> The proposed type is not valid. This error code indicates that the media type itself is not configured correctly; for example, it might contain mutually contradictory flags. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformCannotChangeMediaTypeWhileProcessing"/></strong></dt> </dl> </td><td> <p> The MFT cannot switch types while processing data. Try draining or flushing the MFT. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong></dt> </dl> </td><td> <p> You must set the input types before setting the output types. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.UnsupportedD3DType"/></strong></dt> </dl> </td><td> <p> The MFT could not find a suitable DirectX Video Acceleration (DXVA) configuration. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>This method can be used to set, test without setting, or clear the media type:</p><ul> <li> To set the media type, set <em>dwFlags</em> to zero and set <em>pType</em> to a non-<strong><c>null</c></strong> reference that specifies the media type. </li> <li> To test the media type without setting it, set <em>dwFlags</em> to <strong><see cref="SharpDX.MediaFoundation.MftSetTypeFlags.MftSetTypeTestOnly"/></strong> and set <em>pType</em> to a non-<strong><c>null</c></strong> reference that specifies the media type. If the media type is acceptable, the method return <strong><see cref="SharpDX.Result.Ok"/></strong>. Otherwise, it returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidMediaType"/></strong>. Regardless of the return value, the current media type does not change. </li> <li> To clear the media type, set <em>pType</em> to <strong><c>null</c></strong>. </li> </ul><p> Setting the media type on one stream may change the acceptable types on another stream. </p><p> An MFT may require the caller to set one or more input types before setting the output type. If so, the method returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong>. </p><p>If the MFT supports DirectX Video Acceleration (DXVA) but is unable to find a suitable DXVA configuration (for example, if the graphics driver does not have the right capabilities), the method should return <strong><see cref="SharpDX.MediaFoundation.ResultCode.UnsupportedD3DType"/></strong>. For more information, see Supporting DXVA 2.0 in Media Foundation.</p><p>If <strong>MFT_UNIQUE_METHOD_NAMES</strong> is defined before including mftransform.h, this method is renamed <strong>MFTSetOutputType</strong>. See Creating Hybrid DMO/MFT Objects.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFTransform::SetOutputType']/*"/>	
        /// <msdn-id>ms702016</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::SetOutputType([In] unsigned int dwOutputStreamID,[In, Optional] IMFMediaType* pType,[In] unsigned int dwFlags)</unmanaged>	
        /// <unmanaged-short>IMFTransform::SetOutputType</unmanaged-short>	
        public SharpDX.Result SetOutputType(int dwOutputStreamID, SharpDX.MediaFoundation.MediaType typeRef, int dwFlags)
        {
            unsafe
            {
                SharpDX.Result __result__;
                __result__ =
                SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, dwOutputStreamID, (void*)((typeRef == null) ? IntPtr.Zero : typeRef.NativePointer), dwFlags, ((void**)(*(void**)_nativePointer))[16]);
                return __result__;
            }
        }
        */

        /// <summary>	
        /// <p> Gets the current media type for an input stream on this Media Foundation transform (MFT). </p>	
        /// </summary>	
        /// <param name="dwInputStreamID"><dd> <p> Input stream identifier. To get the list of stream identifiers, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamIDs"/></strong>. </p> </dd></param>	
        /// <param name="typeOut"><dd> <p> Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface. The caller must release the interface. </p> </dd></param>	
        /// <returns><p> The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table. </p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidStreamNumber"/></strong></dt> </dl> </td><td> <p> Invalid stream identifier. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong></dt> </dl> </td><td> <p> The input media type has not been set. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> If the specified input stream does not yet have a media type, the method returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong>. Most MFTs do not set any default media types when first created. Instead, the client must set the media type by calling <strong><see cref="SharpDX.MediaFoundation.Transform.SetInputType"/></strong>. </p><p>If <strong>MFT_UNIQUE_METHOD_NAMES</strong> is defined before including mftransform.h, this method is renamed <strong>MFTGetInputCurrentType</strong>. See Creating Hybrid DMO/MFT Objects.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFTransform::GetInputCurrentType']/*"/>	
        /// <msdn-id>ms705607</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::GetInputCurrentType([In] unsigned int dwInputStreamID,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFTransform::GetInputCurrentType</unmanaged-short>	
        public bool TryGetInputCurrentType(int dwInputStreamID, out SharpDX.MediaFoundation.MediaType typeOut)
        {
            unsafe
            {
                IntPtr typeOut_ = IntPtr.Zero;
                var result = (Result)LocalInterop.Calliint(_nativePointer, dwInputStreamID, &typeOut_, ((void**)(*(void**)_nativePointer))[17]);
                typeOut = (typeOut_ == IntPtr.Zero) ? null : new MediaType(typeOut_);
                if (result.Success)
                    return true;
                if (result == ResultCode.TransformTypeNotSet)
                    return false;
                result.CheckError();
                return false;
            }
        }

        /// <summary>	
        /// <p> Gets the current media type for an output stream on this Media Foundation transform (MFT). </p>	
        /// </summary>	
        /// <param name="dwOutputStreamID"><dd> <p> Output stream identifier. To get the list of stream identifiers, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamIDs"/></strong>. </p> </dd></param>	
        /// <param name="typeOut"><dd> <p> Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface. The caller must release the interface. </p> </dd></param>	
        /// <returns><p> The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table. </p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidStreamNumber"/></strong></dt> </dl> </td><td> <p> Invalid stream identifier. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong></dt> </dl> </td><td> <p> The output media type has not been set. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> If the specified output stream does not yet have a media type, the method returns <strong><see cref="SharpDX.MediaFoundation.ResultCode.TransformTypeNotSet"/></strong>. Most MFTs do not set any default media types when first created. Instead, the client must set the media type by calling <strong><see cref="SharpDX.MediaFoundation.Transform.SetOutputType"/></strong>. </p><p>If <strong>MFT_UNIQUE_METHOD_NAMES</strong> is defined before including mftransform.h, this method is renamed <strong>MFTGetOutputCurrentType</strong>. See Creating Hybrid DMO/MFT Objects.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFTransform::GetOutputCurrentType']/*"/>	
        /// <msdn-id>ms696985</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::GetOutputCurrentType([In] unsigned int dwOutputStreamID,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFTransform::GetOutputCurrentType</unmanaged-short>	
        public bool TryGetOutputCurrentType(int dwOutputStreamID, out MediaType typeOut)
        {
            unsafe
            {
                IntPtr typeOut_ = IntPtr.Zero;
                var result = (Result)LocalInterop.Calliint(_nativePointer, dwOutputStreamID, &typeOut_, ((void**)(*(void**)_nativePointer))[18]);
                typeOut = (typeOut_ == IntPtr.Zero) ? null : new MediaType(typeOut_);
                result.CheckError();
                if (result.Success)
                    return true;
                if (result == ResultCode.TransformTypeNotSet)
                    return false;
                result.CheckError();
                return false;
            }
        }
    }
}