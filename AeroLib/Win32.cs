using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/**
 * (C) 2012 Ian Martinez
 * License: MIT
 */ 
namespace AeroLib
{
    /// <summary>
    /// Stores all of the Win32 interop and P/Invokes.
    /// </summary>
    public static class Win32
    {
        public static uint UnsignedInteger = 0;
        public struct BlurBehindStructure
        {
            public BlurBehindFlags Flags;
            public bool Enable;
            public IntPtr Region;
            public bool TransitionOnMaximized;
        }

        [Flags()]
        public enum BlurBehindFlags : byte
        {
            DwmBbEnable = 1,
            DwmBbBlurregion = 2,
            DwmBbTransitiononmaximized = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Margins
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        public struct AeroParameters
        {
            public int ColorizationColor;
            public int ColorizationAfterglow;
            public int ColorizationColorBalance;
            public int ColorizationAfterglowBalance;
            public int ColorizationBlurBalance;
            public int ColorizationGlassReflectionIntensity;
            public int ColorizationOpaqueBlend;
        }
        
        public const uint DWM_EC_DISABLECOMPOSITION = 0;
        public const uint DWM_EC_ENABLECOMPOSITION = 1;

        [Flags]
        public enum BbFlags : byte //Blur Behind Flags
        {
            DwmBbEnable = 1,
            DwmBbBlurregion = 2,
            DwmBbTransitiononmaximized = 4,
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct BlurBehindStruct
        {
            public BbFlags Flags;
            public bool Enable;
            public IntPtr Region;
            public bool TransitionOnMaximized;
        }

        [DllImport("dwmapi.dll", EntryPoint = "#127", PreserveSig = false)]
        public static extern void DwmGetColorizationParameters(ref AeroParameters parameters);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();

        [DllImport("dwmapi.dll", EntryPoint = "#131", PreserveSig = true)]
        public static extern void DwmSetColorizationParameters(ref AeroParameters parameters, uint uUnknown);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("DwmApi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref Margins pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref BlurBehindStructure blurBehind);

        [DllImport("dwmapi.dll", EntryPoint = "DwmEnableComposition")]
        public static extern uint Win32DwmEnableComposition(uint uCompositionAction);
    }
}
