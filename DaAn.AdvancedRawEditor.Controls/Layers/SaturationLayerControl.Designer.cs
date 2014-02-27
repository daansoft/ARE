namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    partial class SaturationLayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saturationTB = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTB)).BeginInit();
            this.SuspendLayout();
            // 
            // saturationTB
            // 
            this.saturationTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saturationTB.Location = new System.Drawing.Point(3, 20);
            this.saturationTB.Maximum = 400;
            this.saturationTB.Name = "saturationTB";
            this.saturationTB.Size = new System.Drawing.Size(385, 45);
            this.saturationTB.TabIndex = 0;
            this.saturationTB.TickFrequency = 10;
            this.saturationTB.Value = 100;
            this.saturationTB.MouseCaptureChanged += new System.EventHandler(this.saturationTB_MouseCaptureChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Saturation";
            // 
            // SaturationLayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saturationTB);
            this.Name = "SaturationLayerControl";
            this.Size = new System.Drawing.Size(391, 282);
            ((System.ComponentModel.ISupportInitialize)(this.saturationTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar saturationTB;
        private System.Windows.Forms.Label label1;
    }
}
