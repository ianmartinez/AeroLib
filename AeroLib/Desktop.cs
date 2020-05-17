using System;
using System.Drawing;
using System.IO;

/**
 * MIT License
 * Copyright (c) 2011-2020 Ian Martinez
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
namespace AeroLib
{
    /// <summary>
    /// Get and configure desktop parameters related to DWM.
    /// 
    /// All properties are nullable and check if DWM is enabled
    /// or even exists before setting a value. If DWM is not enabled
    /// or does not exist, the value of these properties will be null.
    /// </summary>
    public static class Desktop
    {
        /// <summary>
        /// If the DWM exists on the system.
        /// </summary>
        public static bool HasDWM
        {
            get
            {
                return Environment.OSVersion.Version.Major >= 6
                    && Environment.OSVersion.Version.Build >= 5600
                    && File.Exists(Environment.SystemDirectory + "\\dwmapi.dll");
            }
        }

        /// <summary>
        /// If the DWM exists on the system and its composition is enabled.
        /// </summary>
        public static bool DWMEnabled
        {
            get
            {
                return HasDWM && Win32.DwmIsCompositionEnabled();
            }
        }

        /// <summary>
        /// If the OS supports Aero Peek (i.e. is Windows 7 or greater).
        /// </summary>
        public static bool SupportsAeroPeek
        {
            get
            {
                return HasDWM && Environment.OSVersion.Version.Minor == 1;
            }
        }
               
        /// <summary>
        /// Enable DWM composition.
        /// </summary>
        public static void EnableComposition()
        {
            if (HasDWM)
                Win32.Win32DwmEnableComposition(Win32.DWM_EC_ENABLECOMPOSITION);
        }

        /// <summary>
        /// Disable DWM composition.
        /// </summary>
        public static void DisableComposition()
        {
            if (HasDWM)
                Win32.Win32DwmEnableComposition(Win32.DWM_EC_DISABLECOMPOSITION);
        }

        /// <summary>
        /// The primary Aero color. Will return null if on a system that
        /// doesn't have Aero. Setting it to null will have no effect.
        /// </summary>
        public static Color? AeroColor
        {
            get
            {
                if (!DWMEnabled)
                    return null;

                var aeroParameters = GetParameters();
                return Color.FromArgb(aeroParameters.ColorizationColor);
            }

            set
            {
                if (value != null && DWMEnabled)
                {
                    var aeroParameters = GetParameters();
                    aeroParameters.ColorizationColor = Color.FromArgb(255, value.Value.R, value.Value.G, value.Value.B).ToArgb();
                    SetParameters(aeroParameters);
                }
            }
        }

        /// <summary>
        /// The secondary (afterglow) Aero color. Will return null if on a system
        /// that doesn't have Aero. Setting it to null will have no effect.
        /// </summary>
        public static Color? AfterglowColor
        {
            get
            {
                if (!DWMEnabled)
                    return null;

                var aeroParameters = GetParameters();
                return Color.FromArgb(aeroParameters.ColorizationAfterglow);
            }

            set
            {
                if(value != null && DWMEnabled)
                {
                    var aeroParameters = GetParameters();
                    aeroParameters.ColorizationAfterglow = Color.FromArgb(255, value.Value.R, value.Value.G, value.Value.B).ToArgb();
                    SetParameters(aeroParameters);
                }
            }
        }

        /// <summary>
        /// Aero's opacity. Will return null if on a system
        /// that doesn't have Aero. Setting it to null will have no effect.
        /// </summary>
        public static bool? AeroOpacity
        {
            get
            {
                if (!DWMEnabled)
                    return null;

                return Convert.ToBoolean(GetParameters().ColorizationOpaqueBlend);
            }

            set
            {
                if (value != null && DWMEnabled)
                {
                    var aeroParameters = GetParameters();
                    aeroParameters.ColorizationOpaqueBlend = Convert.ToInt32(value.Value);
                    SetParameters(aeroParameters);
                }
            }
        }

        /// <summary>
        /// Aero's color balance (0-100). Will return null if on a system
        /// that doesn't have Aero. Setting it to null will have no effect.
        /// </summary>
        public static int? AeroColorBalance
        {
            get
            {
                if (!DWMEnabled)
                    return null;

                return GetParameters().ColorizationColorBalance;
            }

            set
            {
                if (value != null && DWMEnabled)
                {
                    var aeroParameters = GetParameters();
                    aeroParameters.ColorizationColorBalance = value.Value;
                    SetParameters(aeroParameters);
                }
            }
        }

        /// <summary>
        /// Aero's afterglow balance. Will return null if on a system
        /// that doesn't have Aero. Setting it to null will have no effect.
        /// </summary>
        public static int? AeroAfterglowBalance
        {
            get
            {
                if (!DWMEnabled)
                    return null;

                return GetParameters().ColorizationAfterglowBalance;
            }

            set
            {
                if (value != null && DWMEnabled)
                {
                    var aeroParameters = GetParameters();
                    aeroParameters.ColorizationAfterglowBalance = value.Value;
                    SetParameters(aeroParameters);
                }
            }
        }

        /// <summary>
        /// Aero's blur balance. Will return null if on a system
        /// that doesn't have Aero. Setting it to null will have no effect.
        /// </summary>
        public static int? AeroBlurBalance
        {
            get
            {
                if (!DWMEnabled)
                    return null;

                return GetParameters().ColorizationBlurBalance;
            }

            set
            {
                if (value != null && DWMEnabled)
                {
                    var aeroParameters = GetParameters();
                    aeroParameters.ColorizationBlurBalance = value.Value;
                    SetParameters(aeroParameters);
                }
            }
        }

        /// <summary>
        /// Aero's glass reflection intensity. Will return null if on a system
        /// that doesn't have Aero. Setting it to null will have no effect.
        /// </summary>
        public static int? AeroGlassReflectionIntensity
        {
            get
            {
                if (!DWMEnabled)
                    return null;

                return GetParameters().ColorizationGlassReflectionIntensity;
            }

            set
            {
                if (value != null && DWMEnabled)
                {
                    var aeroParameters = GetParameters();
                    aeroParameters.ColorizationGlassReflectionIntensity = value.Value;
                    SetParameters(aeroParameters);
                }
            }
        }
                     
        /// <summary>
        /// Set both the primary Aero color and the afterglow color to a color.
        /// </summary>
        /// 
        /// <param name="color">The color to set it to.</param>
        public static void SetAllColors(Color color)
        {
            if(DWMEnabled)
            {
                var aeroParameters = GetParameters();
                aeroParameters.ColorizationColor = Color.FromArgb(255, color.R, color.G, color.B).ToArgb();
                aeroParameters.ColorizationAfterglow = Color.FromArgb(255, color.R, color.G, color.B).ToArgb();
                SetParameters(aeroParameters);
            }
        }

        /// <summary>
        /// Get the AeroParameters struct used in the Windows API for
        /// configuring Aero.
        /// </summary>
        /// 
        /// <returns>The AeroParameters struct.</returns>
        public static Win32.AeroParameters GetParameters()
        {
            if (DWMEnabled == true)
            {
                Win32.AeroParameters aeroParameters = default(Win32.AeroParameters);
                Win32.DwmGetColorizationParameters(ref aeroParameters);
                return aeroParameters;
            }
            else
            {
                return new Win32.AeroParameters();
            }
        }

        /// <summary>
        /// Set the AeroParameters struct used in the Windows API for
        /// configuring Aero.
        /// </summary>
        /// 
        /// <param name="aeroParameters">The AeroParameters struct.</param>
        public static void SetParameters(Win32.AeroParameters aeroParameters)
        {
            if (DWMEnabled)
                Win32.DwmSetColorizationParameters(ref aeroParameters, Win32.UnsignedInteger);
        }
    }
}