using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    [Guid("56a868a2-0ad4-11ce-b03a-0020af0ba770")]
    public class MediaEventSink : ComObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaEventSink"/> class.
        /// </summary>
        /// <param name="nativePtr">The native pointer.</param>	
        public MediaEventSink(IntPtr nativePtr) : base(nativePtr)
        {
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="MediaEventSink"/>. (This method is a shortcut to <see cref="CppObject.NativePointer"/>) 
        /// </summary>
        /// <param name="nativePointer">The native pointer.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator MediaEventSink(IntPtr nativePointer)
        {
            return nativePointer == IntPtr.Zero ? null : new MediaEventSink(nativePointer);
        }

        /// <summary>The <see cref="Notify"/> method notifies the Filter Graph Manager of an event.</summary>
        /// <param name="eventCode">Identifier of the event.</param>
        /// <param name="eventParam1">First event parameter.</param>
        /// <param name="eventParam2">Second event parameter.</param>
        public void Notify(EventNotificationCode eventCode, IntPtr eventParam1, IntPtr eventParam2)
        {
            unsafe
            {
                Result __result__;
                __result__ =
                LocalInterop.Calliint(_nativePointer, (int)eventCode, (void*)eventParam1, (void*)eventParam2, ((void**)(*(void**)_nativePointer))[3]);
                __result__.CheckError();
            }
        }
    }

    /// <summary></summary>
    public enum EventNotificationCode : int
    {
        Complete = 0x01,
        UserAbort = 0x02,
        ErrorAbort = 0x03,
        Time = 0x04,
        Repaint = 0x05,
        StreamErrorStopped = 0x06,
        StreamErrorStillPlaying = 0x07,
        ErrorStillPlaying = 0x08,
        PaletteChanged = 0x09,
        VideoSizeChanged = 0x0A,
        QualityChange = 0x0B,
        ShuttingDown = 0x0C,
        ClockChanged = 0x0D,
        Paused = 0x0E,
        OpeningFile = 0x10,
        BufferingData = 0x11,
        FullScreenLost = 0x12,
        Activate = 0x13,
        NeedRestart = 0x14,
        WindowDestroyed = 0x15,
        DisplayChanged = 0x16,
        Starvation = 0x17,
        OleEvent = 0x18,
        NotifyWindow = 0x19,
        StreamControlStopped = 0x1A,
        StreamControlStarted = 0x1B,
        EndOfSegment = 0x1C,
        SegmentStarted = 0x1D,
        LengthChanged = 0x1E,
        DeviceLost = 0x1f,
        SampleNeeded = 0x20,
        ProcessingLatency = 0x21,
        SampleLatency = 0x22,
        ScrubTime = 0x23,
        StepComplete = 0x24,
        TimeCodeAvailable = 0x30,
        ExtDeviceModeChange = 0x31,
        StateChange = 0x32,
        GraphChanged = 0x50,
        ClockUnset = 0x51,
        RenderDeviceSet = 0x53,
        RenderDeviceOverlay = 0x01,
        RenderDeviceVidMem = 0x02,
        RenderDeviceSysMem = 0x04,
        VmrSurfaceFlipped = 0x54,
        VmrReconnectionFailed = 0x55,
        PreprocessComplete = 0x56,
        CodecApiEvent = 0x57
    }
}
