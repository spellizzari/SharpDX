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

using SharpDX.Multimedia;

namespace SharpDX.MediaFoundation
{
    public partial class MediaType
    {
        /// <summary>	
        /// Creates an empty media type.	
        /// </summary>	
        /// <remarks>	
        /// <p> The media type is created without any attributes. </p>	
        /// </remarks>	
        /// <msdn-id>ms693861</msdn-id>	
        /// <unmanaged>HRESULT MFCreateMediaType([Out] IMFMediaType** ppMFType)</unmanaged>	
        /// <unmanaged-short>MFCreateMediaType</unmanaged-short>	
        public MediaType()
        {
            MediaFactory.CreateMediaType(this);
        }

        /// <summary>	
        /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p> </p><p>Converts a Media Foundation audio media type to a <strong><see cref="SharpDX.Multimedia.WaveFormat"/></strong> structure.</p>	
        /// </summary>	
        /// <param name="bufferSize"><dd> <p>Receives the size of the <strong><see cref="SharpDX.Multimedia.WaveFormat"/></strong> structure.</p> </dd></param>	
        /// <param name="flags"><dd> <p>Contains a flag from the <strong><see cref="SharpDX.MediaFoundation.WaveFormatExConvertFlags"/></strong> enumeration.</p> </dd></param>	
        /// <returns>a reference to the <strong><see cref="SharpDX.Multimedia.WaveFormat"/></strong> structure.</returns>	
        /// <remarks>	
        /// <p>If the <strong>wFormatTag</strong> member of the returned structure is <strong><see cref="SharpDX.Multimedia.WaveFormatEncoding.Extensible"/></strong>, you can cast the reference to a <strong><see cref="SharpDX.Multimedia.WaveFormatExtensible"/></strong> structure.</p>	
        /// </remarks>	
        /// <msdn-id>ms702177</msdn-id>	
        /// <unmanaged>HRESULT MFCreateWaveFormatExFromMFMediaType([In] IMFMediaType* pMFType,[Out] void** ppWF,[Out, Optional] unsigned int* pcbSize,[In] unsigned int Flags)</unmanaged>	
        /// <unmanaged-short>MFCreateWaveFormatExFromMFMediaType</unmanaged-short>	
        public WaveFormat ExtracttWaveFormat(out int bufferSize, WaveFormatExConvertFlags flags = WaveFormatExConvertFlags.Normal)
        {
            IntPtr waveFormat;
            MediaFactory.CreateWaveFormatExFromMFMediaType(this, out waveFormat, out bufferSize, (int)flags);
            return WaveFormat.MarshalFrom(waveFormat);
        }

        /// <summary>	
        /// <p> Compares two media types and determines whether they are identical. If they are not identical, the method indicates how the two formats differ. </p>	
        /// </summary>	
        /// <param name="mediaType"><dd> <p>Pointer to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface of the media type to compare.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong>S_FALSE</strong></dt> </dl> </td><td> <p> The types are not equal. Examine the <em>pdwFlags</em> parameter to determine how the types differ. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The types are equal. </p> </td></tr> <tr><td> <dl> <dt><strong>E_INVALIDARG</strong></dt> </dl> </td><td> <p> One or both media types are invalid. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> Both of the media types must have a major type, or the method returns <strong>E_INVALIDARG</strong>. </p><p> If the method succeeds and all of the comparison flags are set in <em>pdwFlags</em>, the return value is <strong><see cref="SharpDX.Result.Ok"/></strong>. If the method succeeds but one or more comparison flags are not set, the method returns <strong>S_FALSE</strong>. </p><p>This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:</p><ul> <li>Windows?XP with Service Pack?2 (SP2) and later.</li> <li>Windows?XP Media Center Edition?2005 with KB900325 (Windows?XP Media Center Edition?2005) and KB925766 (October 2006 Update Rollup for Windows?XP Media Center Edition) installed.</li> </ul>	
        /// </remarks>	
        /// <msdn-id>ms696980</msdn-id>	
        /// <unmanaged>HRESULT IMFMediaType::IsEqual([In] IMFMediaType* pIMediaType,[Out] unsigned int* pdwFlags)</unmanaged>	
        /// <unmanaged-short>IMFMediaType::IsEqual</unmanaged-short>	
        public Result IsEqual(MediaType mediaType)
        {
            int flags;
            return IsEqual(mediaType, out flags);
        }

        /// <summary>	
        /// <p> Compares two media types and determines whether they are identical. If they are not identical, the method indicates how the two formats differ. </p>	
        /// </summary>	
        /// <param name="mediaType"><dd> <p>Pointer to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface of the media type to compare.</p> </dd></param>	
        /// <param name="flags"><dd> <p>Receives a bitwise <strong>OR</strong> of zero or more flags, indicating the degree of similarity between the two media types. The following flags are defined.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td><dl> <dt><strong>MF_MEDIATYPE_EQUAL_MAJOR_TYPES</strong></dt> <dt>0x00000001</dt> </dl> </td><td> <p>The major types are the same. The major type is specified by the <strong><see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.MajorType"/></strong> attribute.</p> </td></tr> <tr><td><dl> <dt><strong>MF_MEDIATYPE_EQUAL_FORMAT_TYPES</strong></dt> <dt>0x00000002</dt> </dl> </td><td> <p>The subtypes are the same, or neither media type has a subtype. The subtype is specified by the <strong><see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.Subtype"/></strong> attribute.</p> </td></tr> <tr><td><dl> <dt><strong>MF_MEDIATYPE_EQUAL_FORMAT_DATA</strong></dt> <dt>0x00000004</dt> </dl> </td><td> <p>The attributes in one of the media types are a  subset of the attributes in the other, and the values of these attributes match, excluding the value of the <strong><see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.UserData"/></strong>, <see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.FrameRateRangeMin"/>,  and <see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.FrameRateRangeMax"/> attributes.</p> <p>Specifically, the method takes the media type with the smaller number of attributes and checks whether each attribute from that type is present in the other media type and has the same value (not including <strong><see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.UserData"/></strong>, <see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.FrameRateRangeMin"/>,  and <see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.FrameRateRangeMax"/>). </p> <p>To perform other comparisons, use the <strong><see cref="SharpDX.MediaFoundation.MediaAttributes.Compare"/></strong> method. For example, the <strong>Compare</strong> method can test for identical attributes, or test the intersection of the two attribute sets. For more information, see <strong><see cref="SharpDX.MediaFoundation.AttributesMatchType"/></strong>.</p> </td></tr> <tr><td><dl> <dt><strong>MF_MEDIATYPE_EQUAL_FORMAT_USER_DATA</strong></dt> <dt>0x00000008</dt> </dl> </td><td> <p>The user data is identical, or neither media type contains user data. User data is specified by the <strong><see cref="SharpDX.MediaFoundation.MediaTypeAttributeKeys.UserData"/></strong> attribute.</p> </td></tr> </table> <p>?</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong>S_FALSE</strong></dt> </dl> </td><td> <p> The types are not equal. Examine the <em>pdwFlags</em> parameter to determine how the types differ. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The types are equal. </p> </td></tr> <tr><td> <dl> <dt><strong>E_INVALIDARG</strong></dt> </dl> </td><td> <p> One or both media types are invalid. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> Both of the media types must have a major type, or the method returns <strong>E_INVALIDARG</strong>. </p><p> If the method succeeds and all of the comparison flags are set in <em>pdwFlags</em>, the return value is <strong><see cref="SharpDX.Result.Ok"/></strong>. If the method succeeds but one or more comparison flags are not set, the method returns <strong>S_FALSE</strong>. </p><p>This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:</p><ul> <li>Windows?XP with Service Pack?2 (SP2) and later.</li> <li>Windows?XP Media Center Edition?2005 with KB900325 (Windows?XP Media Center Edition?2005) and KB925766 (October 2006 Update Rollup for Windows?XP Media Center Edition) installed.</li> </ul>	
        /// </remarks>	
        /// <msdn-id>ms696980</msdn-id>	
        /// <unmanaged>HRESULT IMFMediaType::IsEqual([In] IMFMediaType* pIMediaType,[Out] unsigned int* pdwFlags)</unmanaged>	
        /// <unmanaged-short>IMFMediaType::IsEqual</unmanaged-short>	
        public Result IsEqual(MediaType mediaType, out MediaTypeEqualFlags flags)
        {
            int flags_;
            var hr = IsEqual(mediaType, out flags_);
            flags = (MediaTypeEqualFlags)flags_;
            return hr;
        }
    }

    /// <summary></summary>
    [Flags]
    public enum MediaTypeEqualFlags : int
    {
        /// <summary>No flags.</summary>
        None = 0,
        /// <summary>The major types are the same.</summary>
        EqualMajorTypes = 1,
        /// <summary>The subtypes are the same, or neither media type has a subtype.</summary>
        EqualFormatTypes = 2,
        /// <summary>The attributes in one of the media types are a subset of the attributes in the other, and the values of these attributes match, excluding the value of the MF_MT_USER_DATA, MF_MT_FRAME_RATE_RANGE_MIN, and MF_MT_FRAME_RATE_RANGE_MAX attributes.</summary>
        EqualFormatData = 4,
        /// <summary>The user data is identical, or neither media type contains user data.</summary>
        EqualFormatUserData = 8,
    }
}