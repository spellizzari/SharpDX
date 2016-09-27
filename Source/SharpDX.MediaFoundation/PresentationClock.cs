using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    partial class PresentationClock
    {
        /// <summary>	
        /// <p> </p><p>Registers an object to be notified whenever the clock starts, stops, or pauses, or changes rate.</p>	
        /// </summary>	
        /// <param name="stateSink"><dd> <p>Pointer to the object's <see cref="SharpDX.MediaFoundation.ClockStateSink"/> interface.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>Before releasing the object, call <see cref="SharpDX.MediaFoundation.PresentationClock.RemoveClockStateSink_"/> to unregister the object for state-change notifications.</p>	
        /// </remarks>	
        /// <msdn-id>ms703129</msdn-id>	
        /// <unmanaged>HRESULT IMFPresentationClock::AddClockStateSink([In, Optional] IMFClockStateSink* pStateSink)</unmanaged>	
        /// <unmanaged-short>IMFPresentationClock::AddClockStateSink</unmanaged-short>	
        public void AddClockStateSink(IntPtr stateSink)
        {
            AddClockStateSink_(stateSink);
        }

        /// <summary>	
        /// <p> </p><p>Unregisters an object that is receiving state-change notifications from the clock.</p>	
        /// </summary>	
        /// <param name="stateSink"><dd> <p>Pointer to the object's <see cref="SharpDX.MediaFoundation.ClockStateSink"/> interface.</p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> </table><p>?</p></returns>	
        /// <msdn-id>ms703032</msdn-id>	
        /// <unmanaged>HRESULT IMFPresentationClock::RemoveClockStateSink([In, Optional] IMFClockStateSink* pStateSink)</unmanaged>	
        /// <unmanaged-short>IMFPresentationClock::RemoveClockStateSink</unmanaged-short>	
        public void RemoveClockStateSink(IntPtr stateSink)
        {
            RemoveClockStateSink_(stateSink);
        }
    }
}
