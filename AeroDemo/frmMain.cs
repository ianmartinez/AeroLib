using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AeroDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            AeroLib.Window.AeroFill(this);
        }

        private void btnRetract_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
            AeroLib.Window.AeroRetract(this);
        }

        private void btnGetColor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aero Glass Color: " + AeroLib.Desktop.GetColor());
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            dlgColor.Color = AeroLib.Desktop.GetColor();
            if (dlgColor.ShowDialog() == DialogResult.OK)
                AeroLib.Desktop.SetAllColors(dlgColor.Color);
        }
    }
}
