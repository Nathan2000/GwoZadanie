namespace ZegarekWinForms
{
    partial class Form1
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
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.clockFace = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.clockFace)).BeginInit();
            this.SuspendLayout();
            // 
            // timePicker
            // 
            this.timePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(51, 178);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(54, 20);
            this.timePicker.TabIndex = 0;
            this.timePicker.ValueChanged += new System.EventHandler(this.timePicker_ValueChanged);
            // 
            // clockFace
            // 
            this.clockFace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clockFace.Location = new System.Drawing.Point(12, 12);
            this.clockFace.Name = "clockFace";
            this.clockFace.Size = new System.Drawing.Size(160, 160);
            this.clockFace.TabIndex = 1;
            this.clockFace.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Angle:";
            // 
            // txtAngle
            // 
            this.txtAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAngle.Location = new System.Drawing.Point(51, 204);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.ReadOnly = true;
            this.txtAngle.Size = new System.Drawing.Size(54, 20);
            this.txtAngle.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 232);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clockFace);
            this.Controls.Add(this.timePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.clockFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.PictureBox clockFace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAngle;
    }
}

