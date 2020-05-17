using System;
using System.Windows.Forms;
using AeroLib;
using System.Drawing;

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
namespace AeroDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            SurroundedPanel.BackColor = Color.Transparent;
            Window.AeroFill(this);
        }

        private void RetractButton_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
            SurroundedPanel.BackColor = Color.Transparent;
            Window.AeroRetract(this);
        }

        private void GetColorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aero Glass Color: " + Desktop.AeroColor);
        }

        private void SetColorButton_Click(object sender, EventArgs e)
        {
            // Get the aero color of the desktop
            var aeroColor = Desktop.AeroColor;

            // Check if the color exists, which might
            // not be the case if on an older system
            // or when using the Classic theme
            if(aeroColor != null)
            {
                ColorDialog.Color = aeroColor.Value;

                if (ColorDialog.ShowDialog() == DialogResult.OK)
                    Desktop.SetAllColors(ColorDialog.Color);
            }
        }

        private void SurroundPanelButton_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            SurroundedPanel.BackColor = SystemColors.Control;
            Window.AeroSurroundControl(this, SurroundedPanel);
        }
    }
}
