using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// MIDL_INTERFACE("6AB0000C-FECE-4d1f-A2AC-A9573530656E")
//    IMFVideoProcessor : public IUnknown
//    {
//    public:
//        virtual HRESULT STDMETHODCALLTYPE GetAvailableVideoProcessorModes(
//            /* [out][in] */ __RPC__inout UINT *lpdwNumProcessingModes,
//            /* [size_is][size_is][out] */ __RPC__deref_out_ecount_full_opt(*lpdwNumProcessingModes) GUID** ppVideoProcessingModes) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE GetVideoProcessorCaps(
//            /* [in] */ __RPC__in LPGUID lpVideoProcessorMode,
//            /* [out] */ __RPC__out DXVA2_VideoProcessorCaps *lpVideoProcessorCaps) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE GetVideoProcessorMode(
//            /* [out] */ __RPC__out LPGUID lpMode) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE SetVideoProcessorMode(
//            /* [in] */ __RPC__in LPGUID lpMode) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE GetProcAmpRange(
//            DWORD dwProperty,
//            /* [out] */ __RPC__out DXVA2_ValueRange *pPropRange) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE GetProcAmpValues(
//            DWORD dwFlags,
//            /* [out] */ __RPC__out DXVA2_ProcAmpValues *Values) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE SetProcAmpValues(
//            DWORD dwFlags,
//            /* [in] */ __RPC__in DXVA2_ProcAmpValues *pValues) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE GetFilteringRange(
//            DWORD dwProperty,
//            /* [out] */ __RPC__out DXVA2_ValueRange *pPropRange) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE GetFilteringValue(
//            DWORD dwProperty,
//            /* [out] */ __RPC__out DXVA2_Fixed32 *pValue) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE SetFilteringValue(
//            DWORD dwProperty,
//            /* [in] */ __RPC__in DXVA2_Fixed32 *pValue) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE GetBackgroundColor(
//            /* [out] */ __RPC__out COLORREF *lpClrBkg) = 0;
//        
//        virtual HRESULT STDMETHODCALLTYPE SetBackgroundColor(
//            COLORREF ClrBkg) = 0;
//        
//    };

namespace SharpDX.MediaFoundation
{
    [Guid("6AB0000C-FECE-4d1f-A2AC-A9573530656E")]
    public class VideoProcessor : ComObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoProcessor"/> class.
        /// </summary>
        /// <param name="nativePtr">The native pointer.</param>	
        public VideoProcessor(IntPtr nativePtr) : base(nativePtr)
        {
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="SharpDX.MediaFoundation.VideoProcessor"/>. (This method is a shortcut to <see cref="SharpDX.CppObject.NativePointer"/>) 
        /// </summary>
        /// <param name="nativePointer">The native pointer.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator VideoProcessor(IntPtr nativePointer)
        {
            return nativePointer == IntPtr.Zero ? null : new VideoProcessor(nativePointer);
        }

        public Guid[] AvailableVideoProcessorModes
        {
            get
            {
                int count = 0;
                Guid[] guids;
                GetAvailableVideoProcessorModes(ref count, out guids);
                return guids;
            }
        }

        internal void GetAvailableVideoProcessorModes(ref int lpdwNumProcessingModes, out Guid[] ppVideoProcessingModes)
        {
            unsafe
            {
                Guid* ppVideoProcessingModesRef;
                Result __result__;
                fixed (int* lpdwNumProcessingModesRef = &lpdwNumProcessingModes)
                    __result__ = LocalInterop.Calliint(_nativePointer, lpdwNumProcessingModesRef, &ppVideoProcessingModesRef, ((void**)(*(void**)_nativePointer))[3]);
                if (ppVideoProcessingModesRef != null)
                {
                    ppVideoProcessingModes = new Guid[lpdwNumProcessingModes];
                    for (int i = 0; i < ppVideoProcessingModes.Length; i++)
                        ppVideoProcessingModes[i] = ppVideoProcessingModesRef[i];
                    Marshal.FreeCoTaskMem((IntPtr)ppVideoProcessingModesRef);
                }
                else ppVideoProcessingModes = null;
                __result__.CheckError();
            }
        }

        public void GetVideoProcessorCaps(Guid lpVideoProcessorMode, out DirectX.VideoProcessorCaps lpVideoProcessorCaps)
        {
            unsafe
            {
                Result __result__;
                fixed (DirectX.VideoProcessorCaps* lpVideoProcessorCapsRef = &lpVideoProcessorCaps)
                    __result__ = LocalInterop.Calliint(_nativePointer, &lpVideoProcessorMode, lpVideoProcessorCapsRef, ((void**)(*(void**)_nativePointer))[4]);
                __result__.CheckError();
            }
        }

        public Guid VideoProcessorMode
        {
            get
            {
                Guid value;
                GetVideoProcessorMode(out value);
                return value;
            }
            set
            {
                SetVideoProcessorMode(value);
            }
        }

        internal void GetVideoProcessorMode(out Guid lpMode)
        {
            unsafe
            {
                Result __result__;
                fixed (Guid* lpModeRef = &lpMode)
                    __result__ = LocalInterop.Calliint(_nativePointer, lpModeRef, ((void**)(*(void**)_nativePointer))[5]);
                __result__.CheckError();
            }
        }

        internal void SetVideoProcessorMode(Guid lpMode)
        {
            unsafe
            {
                Result __result__;
                __result__ = LocalInterop.Calliint(_nativePointer, &lpMode, ((void**)(*(void**)_nativePointer))[6]);
                __result__.CheckError();
            }
        }

        public void GetProcAmpRange(int dwProperty, out DirectX.ValueRange pPropRange)
        {
            unsafe
            {
                Result __result__;
                fixed (DirectX.ValueRange* pPropRangeRef = &pPropRange)
                    __result__ = LocalInterop.Calliint(_nativePointer, dwProperty, pPropRangeRef, ((void**)(*(void**)_nativePointer))[7]);
                __result__.CheckError();
            }
        }

        public void GetProcAmpValues(int dwFlags, out DirectX.ProcAmpValues Values)
        {
            unsafe
            {
                Result __result__;
                fixed (DirectX.ProcAmpValues* ValuesRef = &Values)
                    __result__ = LocalInterop.Calliint(_nativePointer, dwFlags, ValuesRef, ((void**)(*(void**)_nativePointer))[8]);
                __result__.CheckError();
            }
        }

        public void SetProcAmpValues(int dwFlags, DirectX.ProcAmpValues Values)
        {
            unsafe
            {
                Result __result__;
                __result__ = LocalInterop.Calliint(_nativePointer, dwFlags, &Values, ((void**)(*(void**)_nativePointer))[9]);
                __result__.CheckError();
            }
        }

        public void GetFilteringRange(int dwProperty, out DirectX.ValueRange pPropRange)
        {
            unsafe
            {
                Result __result__;
                fixed (DirectX.ValueRange* pPropRangeRef = &pPropRange)
                    __result__ = LocalInterop.Calliint(_nativePointer, dwProperty, pPropRangeRef, ((void**)(*(void**)_nativePointer))[10]);
                __result__.CheckError();
            }
        }

        public void GetFilteringValue(int dwProperty, out DirectX.Fixed32 pValue)
        {
            unsafe
            {
                Result __result__;
                fixed (DirectX.Fixed32* pValueRef = &pValue)
                    __result__ = LocalInterop.Calliint(_nativePointer, dwProperty, pValueRef, ((void**)(*(void**)_nativePointer))[11]);
                __result__.CheckError();
            }
        }

        public void SetFilteringValue(int dwProperty, DirectX.Fixed32 pValue)
        {
            unsafe
            {
                Result __result__;
                __result__ = LocalInterop.Calliint(_nativePointer, dwProperty, &pValue, ((void**)(*(void**)_nativePointer))[12]);
                __result__.CheckError();
            }
        }

        public void GetBackgroundColor(out int lpClrBkg)
        {
            unsafe
            {
                Result __result__;
                fixed (int* lpClrBkgRef = &lpClrBkg)
                    __result__ = LocalInterop.Calliint(_nativePointer, lpClrBkgRef, ((void**)(*(void**)_nativePointer))[13]);
                __result__.CheckError();
            }
        }

        public void SetBackgroundColor(int ClrBkg)
        {
            unsafe
            {
                Result __result__;
                __result__ = LocalInterop.Calliint(_nativePointer, ClrBkg, ((void**)(*(void**)_nativePointer))[14]);
                __result__.CheckError();
            }
        }
    }
}
