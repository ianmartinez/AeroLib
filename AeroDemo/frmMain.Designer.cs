namespace AeroDemo
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFill = new System.Windows.Forms.Button();
            this.btnRetract = new System.Windows.Forms.Button();
            this.btnGetColor = new System.Windows.Forms.Button();
            this.btnSetColor = new System.Windows.Forms.Button();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(12, 12);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(445, 23);
            this.btnFill.TabIndex = 0;
            this.btnFill.Text = "Fill Window With Glass";
            this.btnFill.UseCompatibleTextRendering = true;
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnRetract
            // 
            this.btnRetract.Location = new System.Drawing.Point(12, 41);
            this.btnRetract.Name = "btnRetract";
            this.btnRetract.Size = new System.Drawing.Size(445, 23);
            this.btnRetract.TabIndex = 1;
            this.btnRetract.Text = "Retract Glass";
            this.btnRetract.UseCompatibleTextRendering = true;
            this.btnRetract.UseVisualStyleBackColor = true;
            this.btnRetract.Click += new System.EventHandler(this.btnRetract_Click);
            // 
            // btnGetColor
            // 
            this.btnGetColor.Location = new System.Drawing.Point(12, 70);
            this.btnGetColor.Name = "btnGetColor";
            this.btnGetColor.Size = new System.Drawing.Size(221, 23);
            this.btnGetColor.TabIndex = 2;
            this.btnGetColor.Text = "Get Color";
            this.btnGetColor.UseCompatibleTextRendering = true;
            this.btnGetColor.UseVisualStyleBackColor = true;
            this.btnGetColor.Click += new System.EventHandler(this.btnGetColor_Click);
            // 
            // btnSetColor
            // 
            this.btnSetColor.Location = new System.Drawing.Point(236, 70);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Size = new System.Drawing.Size(221, 23);
            this.btnSetColor.TabIndex = 3;
            this.btnSetColor.Text = "Set Color";
            this.btnSetColor.UseCompatibleTextRendering = true;
            this.btnSetColor.UseVisualStyleBackColor = true;
            this.btnSetColor.Click += new System.EventHandler(this.btnSetColor_Click);
            // 
            // dlgColor
            // 
            this.dlgColor.AnyColor = true;
            this.dlgColor.FullOpen = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 108);
            this.Controls.Add(this.btnSetColor);
            this.Controls.Add(this.btnGetColor);
            this.Controls.Add(this.btnRetract);
            this.Controls.Add(this.btnFill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "AeroLib Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnRetract;
        private System.Windows.Forms.Button btnGetColor;
        private System.Windows.Forms.Button btnSetColor;
        private System.Windows.Forms.ColorDialog dlgColor;
    }
}

