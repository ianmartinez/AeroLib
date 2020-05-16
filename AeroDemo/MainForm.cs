using System;
using System.Windows.Forms;
using AeroLib;
using System.Drawing;

/**
 * (C) 2012 Ian Martinez
 * License: MIT
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
            Window.AeroFill(this);
        }

        private void RetractButton_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
            Window.AeroRetract(this);
        }

        private void GetColorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aero Glass Color: " + Desktop.GetColor());
        }

        private void SetColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog.Color = Desktop.GetColor();
            if (ColorDialog.ShowDialog() == DialogResult.OK)
                Desktop.SetAllColors(ColorDialog.Color);
        }
    }
}
