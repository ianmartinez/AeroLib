using System.Windows.Forms;
using AeroLib;
using System.Drawing;

/**
 * (C) 2012 Ian Martinez
 * License: MIT
 */ 
namespace AeroLib
{
    /// <summary>
    /// Adjust Aero for a window.
    /// </summary>
    public static class Window
    {
       public static void AeroExtend(Form Window, int Left, int Right, int Top, int Bottom)
        {
            if (Desktop.DWMEnabled())
            {
                Win32.Margins AeroMargins = new Win32.Margins();
                AeroMargins.cxLeftWidth = Left;
                AeroMargins.cxRightWidth = Right;
                AeroMargins.cyTopHeight = Top;
                AeroMargins.cyBottomHeight = Bottom;
                Win32.DwmExtendFrameIntoClientArea(Window.Handle, ref AeroMargins);
            }
        }

        public static void AeroRetract(Form Window)
        {
            if (Desktop.DWMEnabled())
            {
                Win32.Margins AeroMargins = new Win32.Margins();
                AeroMargins.cxLeftWidth = 0;
                AeroMargins.cxRightWidth = 0;
                AeroMargins.cyTopHeight = 0;
                AeroMargins.cyBottomHeight = 0;
                Win32.DwmExtendFrameIntoClientArea(Window.Handle, ref AeroMargins);
            }
        }

        public static void AeroToolbar(Form Window, Control Cont)
        {
            AeroExtend(Window, 0, 0, Cont.Height, 0);
        }

        public static void AeroFill(Form Window)
        {
            if (Desktop.DWMEnabled())
                AeroExtend(Window, -1, -1, -1, -1);
        }

        public static void AeroSurroundControl(Form Window, Control Control)
        {
            if (Desktop.DWMEnabled())
                AeroExtend(Window, Control.Left, Window.ClientSize.Width - Control.Right, Control.Top, Window.ClientSize.Height - Control.Bottom);
        }

        public static void RemoveFromAeroPeek(Form Window)
        {
            if (Desktop.DWMEnabled() && System.Environment.OSVersion.Version.Minor == 1)
            {
                int attrValue = 1;
                Win32.DwmSetWindowAttribute(Window.Handle, 12, ref attrValue, 4);
            }
        }

        public static void AddToAeroPeek(Form Window)
        {
            if (Desktop.DWMEnabled() && System.Environment.OSVersion.Version.Minor == 1)
            {
                int attrValue = 0;
                Win32.DwmSetWindowAttribute(Window.Handle, 12, ref attrValue, 4);
            }
        }

        public static void FillScreen(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.Location = new Point(0, 0);
            form.Size = new Size(Desktop.GetWidth(), Desktop.GetHeight());
        }
    }
}