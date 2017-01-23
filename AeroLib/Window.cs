using System.Windows.Forms;
using static AeroLib.Win32;
using static AeroLib.Window;
using static AeroLib.Desktop;
using System.Drawing;

namespace AeroLib
{
    public static class Window
    {
       public static void AeroExtend(Form Window, int Left, int Right, int Top, int Bottom)
        {
            if (DWMEnabled())
            {
                Margins AeroMargins = new Margins();
                AeroMargins.cxLeftWidth = Left;
                AeroMargins.cxRightWidth = Right;
                AeroMargins.cyTopHeight = Top;
                AeroMargins.cyBottomHeight = Bottom;
                DwmExtendFrameIntoClientArea(Window.Handle, ref AeroMargins);
            }
        }

        public static void AeroRetract(Form Window)
        {
            if (DWMEnabled())
            {
                Margins AeroMargins = new Margins();
                AeroMargins.cxLeftWidth = 0;
                AeroMargins.cxRightWidth = 0;
                AeroMargins.cyTopHeight = 0;
                AeroMargins.cyBottomHeight = 0;
                DwmExtendFrameIntoClientArea(Window.Handle, ref AeroMargins);
            }
        }

        public static void AeroToolbar(Form Window, Control Cont)
        {
            AeroExtend(Window, 0, 0, Cont.Height, 0);
        }

        public static void AeroFill(Form Window)
        {
            if (DWMEnabled())
                AeroExtend(Window, -1, -1, -1, -1);
        }

        public static void AeroSurroundControl(Form Window, Control Control)
        {
            if (DWMEnabled())
                AeroExtend(Window, Control.Left, Window.ClientSize.Width - Control.Right, Control.Top, Window.ClientSize.Height - Control.Bottom);
        }

        public static void RemoveFromAeroPeek(Form Window)
        {
            if (DWMEnabled() && System.Environment.OSVersion.Version.Minor == 1)
            {
                int attrValue = 1;
                DwmSetWindowAttribute(Window.Handle, 12, ref attrValue, 4);
            }
        }

        public static void AddToAeroPeek(Form Window)
        {
            if (DWMEnabled() && System.Environment.OSVersion.Version.Minor == 1)
            {
                int attrValue = 0;
                DwmSetWindowAttribute(Window.Handle, 12, ref attrValue, 4);
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
