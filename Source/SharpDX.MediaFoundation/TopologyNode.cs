using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    partial class TopologyNode
    {
        /// <summary>	
        /// <p> </p><p>Retrieves the node that is connected to a specified input stream on this node.</p>	
        /// </summary>	
        /// <param name="dwInputIndex"><dd> <p>Zero-based index of an input stream on this node.</p> </dd></param>	
        /// <param name="upstreamNodeOut"><dd> <p>Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.TopologyNode"/></strong> interface of the node that is connected to the specified input stream. The caller must release the interface.</p> </dd></param>	
        /// <param name="dwOutputIndexOnUpstreamNodeRef"><dd> <p>Receives the index of the output stream that is connected to this node's input stream.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> <tr><td> <dl> <dt><strong>E_INVALIDARG</strong></dt> </dl> </td><td> <p>The index is out of range.</p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.NotFound"/></strong></dt> </dl> </td><td> <p>The specified input stream is not connected to another node.</p> </td></tr> </table><p>?</p></returns>	
        /// <msdn-id>ms697020</msdn-id>	
        /// <unmanaged>HRESULT IMFTopologyNode::GetInput([In] unsigned int dwInputIndex,[Out] IMFTopologyNode** ppUpstreamNode,[Out] unsigned int* pdwOutputIndexOnUpstreamNode)</unmanaged>	
        /// <unmanaged-short>IMFTopologyNode::GetInput</unmanaged-short>	
        public bool TryGetInput(int dwInputIndex, out SharpDX.MediaFoundation.TopologyNode upstreamNodeOut, out int dwOutputIndexOnUpstreamNodeRef)
        {
            unsafe
            {
                IntPtr upstreamNodeOut_ = IntPtr.Zero;
                SharpDX.Result result;
                fixed (void* dwOutputIndexOnUpstreamNodeRef_ = &dwOutputIndexOnUpstreamNodeRef)
                    result =
                    SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, dwInputIndex, &upstreamNodeOut_, dwOutputIndexOnUpstreamNodeRef_, ((void**)(*(void**)_nativePointer))[42]);
                upstreamNodeOut = (upstreamNodeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.TopologyNode(upstreamNodeOut_);
                if (result.Success)
                    return true;
                if (result == ResultCode.NotFound)
                    return false;
                result.CheckError();
                return false;
            }
        }

        /// <summary>	
        /// <p> </p><p>Retrieves the node that is connected to a specified output stream on this node.</p>	
        /// </summary>	
        /// <param name="dwOutputIndex"><dd> <p>Zero-based index of an output stream on this node.</p> </dd></param>	
        /// <param name="downstreamNodeOut"><dd> <p>Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.TopologyNode"/></strong> interface of the node that is connected to the specified output stream. The caller must release the interface.</p> </dd></param>	
        /// <param name="dwInputIndexOnDownstreamNodeRef"><dd> <p>Receives the index of the input stream that is connected to this node's output stream.</p> </dd></param>	
        /// <returns><p>The method returns an <see cref="SharpDX.Result"/>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> <tr><td> <dl> <dt><strong>E_INVALIDARG</strong></dt> </dl> </td><td> <p>The index is out of range.</p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.NotFound"/></strong></dt> </dl> </td><td> <p>The specified input stream is not connected to another node.</p> </td></tr> </table><p>?</p></returns>	
        /// <msdn-id>bb970327</msdn-id>	
        /// <unmanaged>HRESULT IMFTopologyNode::GetOutput([In] unsigned int dwOutputIndex,[Out] IMFTopologyNode** ppDownstreamNode,[Out] unsigned int* pdwInputIndexOnDownstreamNode)</unmanaged>	
        /// <unmanaged-short>IMFTopologyNode::GetOutput</unmanaged-short>	
        public bool TryGetOutput(int dwOutputIndex, out SharpDX.MediaFoundation.TopologyNode downstreamNodeOut, out int dwInputIndexOnDownstreamNodeRef)
        {
            unsafe
            {
                IntPtr downstreamNodeOut_ = IntPtr.Zero;
                SharpDX.Result result;
                fixed (void* dwInputIndexOnDownstreamNodeRef_ = &dwInputIndexOnDownstreamNodeRef)
                    result =
                    SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, dwOutputIndex, &downstreamNodeOut_, dwInputIndexOnDownstreamNodeRef_, ((void**)(*(void**)_nativePointer))[43]);
                downstreamNodeOut = (downstreamNodeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.TopologyNode(downstreamNodeOut_);
                if (result.Success)
                    return true;
                if (result == ResultCode.NotFound)
                    return false;
                result.CheckError();
                return false;
            }
        }

        /// <summary>	
        /// <p> </p><p>Retrieves the preferred media type for an output stream on this node.</p>	
        /// </summary>	
        /// <param name="dwOutputIndex"><dd> <p>Zero-based index of the output stream.</p> </dd></param>	
        /// <param name="typeOut"><dd> <p>Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface of the media type. The caller must release the interface.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> <tr><td> <dl> <dt><strong>E_FAIL</strong></dt> </dl> </td><td> <p>This node does not have a preferred output type.</p> </td></tr> <tr><td> <dl> <dt><strong>E_INVALIDARG</strong></dt> </dl> </td><td> <p>Invalid stream index.</p> </td></tr> <tr><td> <dl> <dt><strong>E_NOTIMPL</strong></dt> </dl> </td><td> <p>This node is an output node.</p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>Output nodes cannot have outputs. If this method is called on an output node, it returns E_NOTIMPL.</p><p>The preferred output type provides a hint to the topology loader. In a fully resolved topology, there is no guarantee that every topology node will have a preferred output type. To get the actual media type for a node, you must get a reference to the node's underlying object. (For more information, see <strong><see cref="SharpDX.MediaFoundation.TopologyType"/></strong> enumeration.)</p>	
        /// </remarks>	
        /// <msdn-id>ms701571</msdn-id>	
        /// <unmanaged>HRESULT IMFTopologyNode::GetOutputPrefType([In] unsigned int dwOutputIndex,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFTopologyNode::GetOutputPrefType</unmanaged-short>	
        public bool TryGetOutputPrefType(int dwOutputIndex, out SharpDX.MediaFoundation.MediaType typeOut)
        {
            unsafe
            {
                IntPtr typeOut_ = IntPtr.Zero;
                SharpDX.Result result;
                result =
                SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, dwOutputIndex, &typeOut_, ((void**)(*(void**)_nativePointer))[45]);
                typeOut = (typeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.MediaType(typeOut_);
                if (result.Success)
                    return true;
                if (result == Result.Fail)
                    return false;
                result.CheckError();
                return false;
            }
        }

        /// <summary>	
        /// <p> </p><p>Retrieves the preferred media type for an input stream on this node.</p>	
        /// </summary>	
        /// <param name="dwInputIndex"><dd> <p>Zero-based index of the input stream.</p> </dd></param>	
        /// <param name="typeOut"><dd> <p>Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.MediaType"/></strong> interface of the media type. The caller must release the interface.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> <tr><td> <dl> <dt><strong>E_FAIL</strong></dt> </dl> </td><td> <p>This node does not have a preferred input type.</p> </td></tr> <tr><td> <dl> <dt><strong>E_INVALIDARG</strong></dt> </dl> </td><td> <p>Invalid stream index.</p> </td></tr> <tr><td> <dl> <dt><strong>E_NOTIMPL</strong></dt> </dl> </td><td> <p>This node is a source node.</p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>Source nodes cannot have inputs. If this method is called on a source node, it returns E_NOTIMPL.</p><p>The preferred input type provides a hint to the topology loader. In a fully resolved topology, there is no guarantee that every topology node will have a preferred input type. To get the actual media type for a node, you must get a reference to the node's underlying object. (For more information, see <strong><see cref="SharpDX.MediaFoundation.TopologyType"/></strong> enumeration.)</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFTopologyNode::GetInputPrefType']/*"/>	
        /// <msdn-id>ms696221</msdn-id>	
        /// <unmanaged>HRESULT IMFTopologyNode::GetInputPrefType([In] unsigned int dwInputIndex,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFTopologyNode::GetInputPrefType</unmanaged-short>	
        public bool TryGetInputPrefType(int dwInputIndex, out SharpDX.MediaFoundation.MediaType typeOut)
        {
            unsafe
            {
                IntPtr typeOut_ = IntPtr.Zero;
                SharpDX.Result result;
                result =
                SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, dwInputIndex, &typeOut_, ((void**)(*(void**)_nativePointer))[47]);
                typeOut = (typeOut_ == IntPtr.Zero) ? null : new SharpDX.MediaFoundation.MediaType(typeOut_);
                if (result.Success)
                    return true;
                if (result == Result.Fail)
                    return false;
                result.CheckError();
                return false;
            }
        }
    }
}
