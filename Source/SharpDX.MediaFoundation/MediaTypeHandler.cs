using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    public partial class MediaTypeHandler
    {
        /// <summary>	
        /// <p> </p><p>Retrieves a media type from the object's list of supported media types.</p>	
        /// </summary>	
        /// <param name="dwIndex"><dd> <p> Zero-based index of the media type to retrieve. To get the number of media types in the list, call <strong><see cref="SharpDX.MediaFoundation.MediaTypeHandler.GetMediaTypeCount"/></strong>. </p> </dd></param>	
        /// <param name="typeOut"><dd> <p> Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface. The caller must release the interface. </p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.NoMoreTypes"/></strong></dt> </dl> </td><td> <p> The <em>dwIndex</em> parameter is out of range. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>Media types are returned in the approximate order of preference. The list of supported types is not guaranteed to be complete. To test whether a particular media type is supported, call <strong><see cref="SharpDX.MediaFoundation.MediaTypeHandler.IsMediaTypeSupported"/></strong>.</p><p>This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:</p><ul> <li>Windows?XP with Service Pack?2 (SP2) and later.</li> <li>Windows?XP Media Center Edition?2005 with KB900325 (Windows?XP Media Center Edition?2005) and KB925766 (October 2006 Update Rollup for Windows?XP Media Center Edition) installed.</li> </ul>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFMediaTypeHandler::GetMediaTypeByIndex']/*"/>	
        /// <msdn-id>bb970473</msdn-id>	
        /// <unmanaged>HRESULT IMFMediaTypeHandler::GetMediaTypeByIndex([In] unsigned int dwIndex,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFMediaTypeHandler::GetMediaTypeByIndex</unmanaged-short>	
        public MediaType GetMediaTypeByIndex(int dwIndex)
        {
            MediaType mediaType;
            this.GetMediaTypeByIndex(dwIndex, out mediaType);
            return mediaType;
        }

        /// <summary>	
        /// <p> </p><p>Sets the object's media type.</p>	
        /// </summary>	
        /// <param name="mediaTypeRef"><dd> <p>Pointer to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface of the new media type.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidRequest"/></strong></dt> </dl> </td><td> <p> Invalid request. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>For media sources, setting the media type means the source will generate data that conforms to that media type. For media sinks, setting the media type means the sink can receive data that conforms to that media type.</p><p>Any implementation of this method should check whether <em>pMediaType</em> differs from the object's current media type. If the types are identical, the method should return <see cref="SharpDX.Result.Ok"/> but avoid releasing and recreating resources unnecessarily. If the types are not identical, the method should validate the new type.</p><p>This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:</p><ul> <li>Windows?XP with Service Pack?2 (SP2) and later.</li> <li>Windows?XP Media Center Edition?2005 with KB900325 (Windows?XP Media Center Edition?2005) and KB925766 (October 2006 Update Rollup for Windows?XP Media Center Edition) installed.</li> </ul>	
        /// </remarks>	
        /// <msdn-id>bb970432</msdn-id>	
        /// <unmanaged>HRESULT IMFMediaTypeHandler::SetCurrentMediaType([In] IMFMediaType* pMediaType)</unmanaged>	
        /// <unmanaged-short>IMFMediaTypeHandler::SetCurrentMediaType</unmanaged-short>	
        public bool TrySetCurrentMediaType(SharpDX.MediaFoundation.MediaType mediaTypeRef)
        {
            unsafe
            {
                Result result;
                result = LocalInterop.Calliint(_nativePointer, (void*)((mediaTypeRef == null) ? IntPtr.Zero : mediaTypeRef.NativePointer), ((void**)(*(void**)_nativePointer))[6]);
                return result.Success;
            }
        }

        /// <summary>	
        /// <p> </p><p>Retrieves the current media type of the object.</p>	
        /// </summary>	
        /// <param name="mediaTypeOut"><dd> <p>Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface. The caller must release the interface.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.NotInitializeD"/></strong></dt> </dl> </td><td> <p> No media type is set. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:</p><ul> <li>Windows?XP with Service Pack?2 (SP2) and later.</li> <li>Windows?XP Media Center Edition?2005 with KB900325 (Windows?XP Media Center Edition?2005) and KB925766 (October 2006 Update Rollup for Windows?XP Media Center Edition) installed.</li> </ul>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFMediaTypeHandler::GetCurrentMediaType']/*"/>	
        /// <msdn-id>bb970492</msdn-id>	
        /// <unmanaged>HRESULT IMFMediaTypeHandler::GetCurrentMediaType([Out] IMFMediaType** ppMediaType)</unmanaged>	
        /// <unmanaged-short>IMFMediaTypeHandler::GetCurrentMediaType</unmanaged-short>	
        public bool TryGetCurrentMediaType(out SharpDX.MediaFoundation.MediaType mediaTypeOut)
        {
            unsafe
            {
                IntPtr mediaTypeOut_ = IntPtr.Zero;
                Result result;
                result = LocalInterop.Calliint(_nativePointer, &mediaTypeOut_, ((void**)(*(void**)_nativePointer))[7]);
                mediaTypeOut = (mediaTypeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.MediaType(mediaTypeOut_);
                if (result.Success)
                    return true;
                if (result == ResultCode.NotInitializeD)
                    return false;
                result.CheckError();
                return false;
            }
        }

        /// <summary>	
        /// <p> </p><p>Queries whether the object supports a specified media type.</p>	
        /// </summary>	
        /// <param name="mediaTypeRef"><dd> <p> Pointer to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface of the media type to check. </p> </dd></param>	
        /// <param name="mediaTypeOut"><dd> <p> Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface of the closest matching media type, or receives the value <strong><c>null</c></strong>. If non-<strong><c>null</c></strong>, the caller must release the interface. This parameter can be <strong><c>null</c></strong>. See Remarks. </p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.InvalidMediaType"/></strong></dt> </dl> </td><td> <p> The object does not support this media type. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> If the object supports the media type given in <em>pMediaType</em>, the method returns <strong><see cref="SharpDX.Result.Ok"/></strong>. For a media source, it means the source can generate data that conforms to that media type. For a media sink, it means the sink can receive data that conforms to that media type. If the object does not support the media type, the method fails. </p><p> The <em>ppMediaType</em> parameter is optional. If the method fails, the object might use <em>ppMediaType</em> to return a media type that the object does support, and which closely matches the one given in <em>pMediaType</em>. The method is not guaranteed to return a media type in <em>ppMediaType</em>. If no type is returned, this parameter receives a <strong><c>null</c></strong> reference. If the method succeeds, this parameter receives a <strong><c>null</c></strong> reference. If the caller sets <em>ppMediaType</em> to <strong><c>null</c></strong>, this parameter is ignored. </p><p>This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:</p><ul> <li>Windows?XP with Service Pack?2 (SP2) and later.</li> <li>Windows?XP Media Center Edition?2005 with KB900325 (Windows?XP Media Center Edition?2005) and KB925766 (October 2006 Update Rollup for Windows?XP Media Center Edition) installed.</li> </ul><p>This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:</p><ul> <li>Windows?XP with SP2 and later.</li> <li>Windows?XP Media Center Edition?2005 with KB900325 (Windows?XP Media Center Edition?2005) and KB925766 (October 2006 Update Rollup for Windows?XP Media Center Edition) installed.</li> </ul>	
        /// </remarks>	
        /// <msdn-id>bb970559</msdn-id>	
        /// <unmanaged>HRESULT IMFMediaTypeHandler::IsMediaTypeSupported([In] IMFMediaType* pMediaType,[Out, Optional] IMFMediaType** ppMediaType)</unmanaged>	
        /// <unmanaged-short>IMFMediaTypeHandler::IsMediaTypeSupported</unmanaged-short>	
        public Result TryIsMediaTypeSupported(SharpDX.MediaFoundation.MediaType mediaTypeRef, out SharpDX.MediaFoundation.MediaType mediaTypeOut)
        {
            unsafe
            {
                IntPtr mediaTypeOut_ = IntPtr.Zero;
                Result result;
                result = LocalInterop.Calliint(_nativePointer, (void*)((mediaTypeRef == null) ? IntPtr.Zero : mediaTypeRef.NativePointer), &mediaTypeOut_, ((void**)(*(void**)_nativePointer))[3]);
                mediaTypeOut = (mediaTypeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.MediaType(mediaTypeOut_);
                return result;
            }
        }
    }
}
