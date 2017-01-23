using System;
using System.Windows.Forms;
using static AeroLib.Win32;
using System.Drawing;
using System.IO;

namespace AeroLib
{
    public static class Desktop
    {

        public static bool DWMEnabled()
        {
            return (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Build >= 5600) && File.Exists(Environment.SystemDirectory + "\\dwmapi.dll");
        }

        public static void DisableComposition()
        {
            if (DWMEnabled())
                Win32DwmEnableComposition(DWM_EC_DISABLECOMPOSITION);
        }

        public static void EnableComposition()
        {
            if (DWMEnabled())
                Win32DwmEnableComposition(DWM_EC_ENABLECOMPOSITION);
        }

        public static void SetColor(Color AeroColor)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationColor = System.Drawing.Color.FromArgb(255, AeroColor.R, AeroColor.G, AeroColor.B).ToArgb();
            SetParameters(AeroParameters);
        }

        public static void SetAllColors(Color AeroColor)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationColor = System.Drawing.Color.FromArgb(255, AeroColor.R, AeroColor.G, AeroColor.B).ToArgb();
            AeroParameters.ColorizationAfterglow = System.Drawing.Color.FromArgb(255, AeroColor.R, AeroColor.G, AeroColor.B).ToArgb();
            SetParameters(AeroParameters);
        }

        public static void SetAfterglowColor(Color AfterglowColor)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationAfterglow = System.Drawing.Color.FromArgb(255, AfterglowColor.R, AfterglowColor.G, AfterglowColor.B).ToArgb();
            SetParameters(AeroParameters);
        }

        public static void SetBlurBalance(int BlurBalance)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationBlurBalance = BlurBalance;
            SetParameters(AeroParameters);
        }

        public static void SetAfterglowBalance(int AfterglowBalance)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationAfterglowBalance = AfterglowBalance;
            SetParameters(AeroParameters);
        }

        public static void SetGlassReflectionIntensity(int GlassReflectionIntensity)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationGlassReflectionIntensity = GlassReflectionIntensity;
            SetParameters(AeroParameters);
        }

        public static void SetColorBalance(int ColorBalance)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationColorBalance = ColorBalance;
            SetParameters(AeroParameters);
        }

        public static int GetColorBalance()
        {
            if (DWMEnabled() == false)
                return 0;
            AeroParameters AeroParameters = GetParameters();
            return AeroParameters.ColorizationColorBalance;
        }

        public static int GetAfterglowBalance()
        {
            if (DWMEnabled() == false)
                return 0;
            AeroParameters AeroParameters = GetParameters();
            return AeroParameters.ColorizationAfterglowBalance;
        }

        public static int GetBlurBalance()
        {
            if (DWMEnabled() == false)
                return 0;
            AeroParameters AeroParameters = GetParameters();
            return AeroParameters.ColorizationBlurBalance;
        }

        public static int GetGlassReflectionIntensity()
        {
            if (DWMEnabled() == false)
                return 0;
            AeroParameters AeroParameters = GetParameters();
            return AeroParameters.ColorizationGlassReflectionIntensity;
        }

        public static Color GetColor()
        {
            if (DWMEnabled() == false)
                return new Color();
            AeroParameters AeroParameters = GetParameters();
            return Color.FromArgb(AeroParameters.ColorizationColor);
        }

        public static Color GetAfterglowColor()
        {
            if (DWMEnabled() == false)
                return new Color();
            AeroParameters AeroParameters = GetParameters();
            return Color.FromArgb(AeroParameters.ColorizationAfterglow);
        }

        public static bool GetOpacity()
        {
            if (DWMEnabled() == false)
                return false;
            return Convert.ToBoolean(GetParameters().ColorizationOpaqueBlend);
        }
        public static void SetOpacity(bool Opaque)
        {
            if (DWMEnabled() == false)
                return;
            AeroParameters AeroParameters = GetParameters();
            AeroParameters.ColorizationOpaqueBlend = Convert.ToInt32(Opaque);
            SetParameters(AeroParameters);
        }

        public static AeroParameters GetParameters()
        {
            if (DWMEnabled() == true)
            {
                AeroParameters AeroParameters = default(AeroParameters);
                DwmGetColorizationParameters(ref AeroParameters);
                return AeroParameters;
            }
            else
            {
                return new AeroParameters();
            }
        }

        public static void SetParameters(AeroParameters AeroParameters)
        {
            if (DWMEnabled() == true)
                DwmSetColorizationParameters(ref AeroParameters, UnsignedInteger);
        }

        public static int GetHeight()
        {
            return Screen.PrimaryScreen.Bounds.Height;
        }

        public static int GetWidth()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }
    }
}
