namespace AeroDemo
{
    partial class MainForm
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
            this.FillButton = new System.Windows.Forms.Button();
            this.RetractButton = new System.Windows.Forms.Button();
            this.GetColorButton = new System.Windows.Forms.Button();
            this.SetColorButton = new System.Windows.Forms.Button();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // FillButton
            // 
            this.FillButton.Location = new System.Drawing.Point(12, 12);
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(445, 23);
            this.FillButton.TabIndex = 0;
            this.FillButton.Text = "Fill Window With Glass";
            this.FillButton.UseCompatibleTextRendering = true;
            this.FillButton.UseVisualStyleBackColor = true;
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // RetractButton
            // 
            this.RetractButton.Location = new System.Drawing.Point(12, 41);
            this.RetractButton.Name = "RetractButton";
            this.RetractButton.Size = new System.Drawing.Size(445, 23);
            this.RetractButton.TabIndex = 1;
            this.RetractButton.Text = "Retract Glass";
            this.RetractButton.UseCompatibleTextRendering = true;
            this.RetractButton.UseVisualStyleBackColor = true;
            this.RetractButton.Click += new System.EventHandler(this.RetractButton_Click);
            // 
            // GetColorButton
            // 
            this.GetColorButton.Location = new System.Drawing.Point(12, 70);
            this.GetColorButton.Name = "GetColorButton";
            this.GetColorButton.Size = new System.Drawing.Size(221, 23);
            this.GetColorButton.TabIndex = 2;
            this.GetColorButton.Text = "Get Color";
            this.GetColorButton.UseCompatibleTextRendering = true;
            this.GetColorButton.UseVisualStyleBackColor = true;
            this.GetColorButton.Click += new System.EventHandler(this.GetColorButton_Click);
            // 
            // SetColorButton
            // 
            this.SetColorButton.Location = new System.Drawing.Point(236, 70);
            this.SetColorButton.Name = "SetColorButton";
            this.SetColorButton.Size = new System.Drawing.Size(221, 23);
            this.SetColorButton.TabIndex = 3;
            this.SetColorButton.Text = "Set Color";
            this.SetColorButton.UseCompatibleTextRendering = true;
            this.SetColorButton.UseVisualStyleBackColor = true;
            this.SetColorButton.Click += new System.EventHandler(this.SetColorButton_Click);
            // 
            // ColorDialog
            // 
            this.ColorDialog.AnyColor = true;
            this.ColorDialog.FullOpen = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 108);
            this.Controls.Add(this.SetColorButton);
            this.Controls.Add(this.GetColorButton);
            this.Controls.Add(this.RetractButton);
            this.Controls.Add(this.FillButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AeroLib Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FillButton;
        private System.Windows.Forms.Button RetractButton;
        private System.Windows.Forms.Button GetColorButton;
        private System.Windows.Forms.Button SetColorButton;
        private System.Windows.Forms.ColorDialog ColorDialog;
    }
}

