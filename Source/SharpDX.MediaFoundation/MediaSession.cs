using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    partial class MediaSession
    {
        /// <summary>	
        /// <p> Gets a topology from the Media Session.</p><p>This method can get the current topology or a queued topology.</p>	
        /// </summary>	
        /// <param name="dwGetFullTopologyFlags"><dd> <p> Bitwise <strong>OR</strong> of zero or more flags from the <strong><see cref="SharpDX.MediaFoundation.SessionGetFullTopologyFlags"/></strong> enumeration. </p> </dd></param>	
        /// <param name="topoId"><dd> <p>The identifier of the topology. This parameter is ignored if the <em>dwGetFullTopologyFlags</em> parameter contains the <strong><see cref="SharpDX.MediaFoundation.SessionGetFullTopologyFlags.Current"/></strong> flag. To get the identifier of a topology, call <strong><see cref="SharpDX.MediaFoundation.Topology.GetTopologyID"/></strong>. </p> </dd></param>	
        /// <param name="fullTopologyOut"><dd> <p> Receives a reference to the <strong><see cref="SharpDX.MediaFoundation.Topology"/></strong> interface of the topology. The caller must release the interface. </p> </dd></param>	
        /// <returns><p> The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table. </p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.Shutdown"/></strong></dt> </dl> </td><td> <p> The Media Session has been shut down. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p> If the <strong><see cref="SharpDX.MediaFoundation.SessionGetFullTopologyFlags.Current"/></strong> flag is specified in the <em>dwGetFullTopologyFlags</em> parameter, the method returns the topology for the current presentation. Otherwise, the method searches all of the queued topologies for one that matches the identifier given in the <em>TopoId</em> parameter. </p><p> This method can be used to retrieve the topology for the current presentation or any pending presentations. It cannot be used to retrieve a topology that has already ended. </p><p> The topology returned in <em>ppFullTopo</em> is a full topology, not a partial topology. </p>	
        /// </remarks>	
        /// <msdn-id>bb970422</msdn-id>	
        /// <unmanaged>HRESULT IMFMediaSession::GetFullTopology([In] unsigned int dwGetFullTopologyFlags,[In] unsigned longlong TopoId,[Out] IMFTopology** ppFullTopology)</unmanaged>	
        /// <unmanaged-short>IMFMediaSession::GetFullTopology</unmanaged-short>	
        public Result TryGetFullTopology(int dwGetFullTopologyFlags, long topoId, out Topology fullTopologyOut)
        {
            unsafe
            {
                IntPtr fullTopologyOut_ = IntPtr.Zero;
                Result result;
                result = LocalInterop.Calliint(_nativePointer, dwGetFullTopologyFlags, topoId, &fullTopologyOut_, ((void**)(*(void**)_nativePointer))[16]);
                fullTopologyOut = (fullTopologyOut_ == IntPtr.Zero) ? null : new Topology(fullTopologyOut_);
                return result;
            }
        }
    }
}
