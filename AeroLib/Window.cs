using System.Windows.Forms;

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
    /// Adjust Aero for a window.
    /// </summary>
    public static class Window
    {
        /// <summary>
        /// Extend Aero glass into the client area of a form from
        /// the left, right, top, and bottom margins.
        /// </summary>
        /// 
        /// <param name="form">The form to extend Aero glass into.</param>
        /// <param name="left">The form's left margin.</param>
        /// <param name="right">The form's right margin.</param>
        /// <param name="top">The form's top margin.</param>
        /// <param name="bottom">The form's bottom margin.</param>        
        public static void AeroExtend(Form form, int left, int right, int top, int bottom)
        {
            if (Desktop.DWMEnabled)
            {
                var AeroMargins = new Win32.Margins
                {
                    cxLeftWidth = left,
                    cxRightWidth = right,
                    cyTopHeight = top,
                    cyBottomHeight = bottom
                };

                Win32.DwmExtendFrameIntoClientArea(form.Handle, ref AeroMargins);
            }
        }

        /// <summary>
        /// Remove expanded Aero glass from a form's client area.
        /// </summary>
        /// 
        /// <param name="form">The form to retract the Aero glass from.</param>
        public static void AeroRetract(Form form)
        {
            if (Desktop.DWMEnabled)
            {
                var AeroMargins = new Win32.Margins
                {
                    cxLeftWidth = 0,
                    cxRightWidth = 0,
                    cyTopHeight = 0,
                    cyBottomHeight = 0
                };

                Win32.DwmExtendFrameIntoClientArea(form.Handle, ref AeroMargins);
            }
        }

        /// <summary>
        /// Extend Aero glass into the client area of a form from the top (for
        /// a toolbar).
        /// </summary>
        /// 
        /// <param name="form">The form to extend Aero glass into.</param>
        /// <param name="control">The toolbar control.</param>
        public static void AeroToolbar(Form form, Control control)
        {
            AeroExtend(form, 0, 0, control.Height, 0);
        }

        /// <summary>
        /// Extend Aero glass to cover the entire client area of a form.
        /// </summary>
        /// 
        /// <param name="form">The form to extend Aero glass into.</param>
        public static void AeroFill(Form form)
        {
            AeroExtend(form, -1, -1, -1, -1);
        }

        /// <summary>
        /// Extend Aero glass into the client area of a form to surround a
        /// control.
        /// </summary>
        /// 
        /// <param name="form">The form to extend Aero glass into.</param>
        /// <param name="control">The control to surround.</param>
        public static void AeroSurroundControl(Form form, Control control)
        {
            AeroExtend(form, control.Left, form.ClientSize.Width - control.Right, control.Top, form.ClientSize.Height - control.Bottom);
        }

        /// <summary>
        /// Remove a form from Aero Peek.
        /// </summary>
        /// 
        /// <param name="form">The form to remove from Aero Peek.</param>
        public static void RemoveFromAeroPeek(Form form)
        {
            if (Desktop.SupportsAeroPeek)
            {
                int attrValue = 1;
                Win32.DwmSetWindowAttribute(form.Handle, 12, ref attrValue, 4);
            }
        }

        /// <summary>
        /// Add a form to Aero Peek.
        /// </summary>
        /// 
        /// <param name="form">The form to add to Aero Peek.</param>
        public static void AddToAeroPeek(Form form)
        {
            if (Desktop.SupportsAeroPeek)
            {
                int attrValue = 0;
                Win32.DwmSetWindowAttribute(form.Handle, 12, ref attrValue, 4);
            }
        }
    }
}