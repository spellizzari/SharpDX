using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    partial class Clock
    {
        /// <summary>	
        /// <p> Retrieves the last clock time that was correlated with system time. </p>	
        /// </summary>	
        /// <param name="dwReserved"><dd> <p> Reserved, must be zero. </p> </dd></param>	
        /// <param name="llClockTimeRef"><dd> <p> Receives the last known clock time, in units of the clock's frequency. </p> </dd></param>	
        /// <param name="hnsSystemTimeRef"><dd> <p> Receives the system time that corresponds to the clock time returned in <em>pllClockTime</em>, in 100-nanosecond units. </p> </dd></param>	
        /// <returns><p>The method returns an <strong><see cref="SharpDX.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.Result.Ok"/></strong></dt> </dl> </td><td> <p> The method succeeded. </p> </td></tr> <tr><td> <dl> <dt><strong><see cref="SharpDX.MediaFoundation.ResultCode.ClockNoTimeSource"/></strong></dt> </dl> </td><td> <p> The clock does not have a time source. </p> </td></tr> </table><p>?</p></returns>	
        /// <remarks>	
        /// <p>At some fixed interval, a clock correlates its internal clock ticks with the system time. (The system time is the time returned by the high-resolution performance counter.) This method returns:</p><ul> <li> The most recent clock time that was correlated with system time. </li> <li> The system time when the correlation was performed. </li> </ul><p> The clock time is returned in the <em>pllClockTime</em> parameter and is expressed in units of the clock's frequency. If the clock's <strong><see cref="SharpDX.MediaFoundation.Clock.GetClockCharacteristics"/></strong> method returns the <strong><see cref="SharpDX.MediaFoundation.ClockCharacteristicsFlags.Frequency10mhz"/></strong> flag, the clock's frequency is 10 MHz (each clock tick is 100 nanoseconds). Otherwise, you can get the clock's frequency by calling <strong><see cref="SharpDX.MediaFoundation.Clock.GetProperties"/></strong>. The frequency is given in the <strong>qwClockFrequency</strong> member of the <strong><see cref="SharpDX.MediaFoundation.ClockProperties"/></strong> structure returned by that method. </p><p> The system time is returned in the <em>phnsSystemTime</em> parameter, and is always expressed in 100-nanosecond units. </p><p> To find out how often the clock correlates its clock time with the system time, call <strong>GetProperties</strong>. The correlation interval is given in the <strong>qwCorrelationRate</strong> member of the <strong><see cref="SharpDX.MediaFoundation.ClockProperties"/></strong> structure. If <strong>qwCorrelationRate</strong> is zero, it means the clock performs the correlation whenever <strong>GetCorrelatedTime</strong> is called. Otherwise, you can calculate the current clock time by extrapolating from the last correlated time. </p><p> Some clocks support rate changes through the <strong><see cref="SharpDX.MediaFoundation.RateControl"/></strong> interface. If so, the clock time advances at a speed of frequency ? current rate. If a clock does not expose the <strong><see cref="SharpDX.MediaFoundation.RateControl"/></strong> interface, the rate is always 1.0. </p><p>For the presentation clock, the clock time is the presentation time, and is always relative to the starting time specified in <strong><see cref="SharpDX.MediaFoundation.PresentationClock.Start"/></strong>. You can also get the presentation time by calling <strong><see cref="SharpDX.MediaFoundation.PresentationClock.GetTime"/></strong>.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='IMFClock::GetCorrelatedTime']/*"/>	
        /// <msdn-id>ms694122</msdn-id>	
        /// <unmanaged>HRESULT IMFClock::GetCorrelatedTime([In] unsigned int dwReserved,[Out] longlong* pllClockTime,[Out] longlong* phnsSystemTime)</unmanaged>	
        /// <unmanaged-short>IMFClock::GetCorrelatedTime</unmanaged-short>	
        public bool TryGetCorrelatedTime(int dwReserved, out long llClockTimeRef, out long hnsSystemTimeRef)
        {
            unsafe
            {
                SharpDX.Result __result__;
                fixed (void* llClockTimeRef_ = &llClockTimeRef)
                fixed (void* hnsSystemTimeRef_ = &hnsSystemTimeRef)
                    __result__ =
                    SharpDX.MediaFoundation.LocalInterop.Calliint(_nativePointer, dwReserved, llClockTimeRef_, hnsSystemTimeRef_, ((void**)(*(void**)_nativePointer))[4]);
                if (!__result__.Success)
                {
                    llClockTimeRef = 0;
                    hnsSystemTimeRef = 0;
                    return false;
                }
                return true;
            }
        }
    }
}
