namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    partial class ExposureLayerControl
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
            this.exposureTB = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.exposureTB)).BeginInit();
            this.SuspendLayout();
            // 
            // exposureTB
            // 
            this.exposureTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exposureTB.Location = new System.Drawing.Point(3, 20);
            this.exposureTB.Maximum = 400;
            this.exposureTB.Minimum = -400;
            this.exposureTB.Name = "exposureTB";
            this.exposureTB.Size = new System.Drawing.Size(385, 45);
            this.exposureTB.TabIndex = 0;
            this.exposureTB.TickFrequency = 10;
            this.exposureTB.MouseCaptureChanged += new System.EventHandler(this.exposureTB_MouseCaptureChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exposure";
            // 
            // ExposureLayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exposureTB);
            this.Name = "ExposureLayerControl";
            this.Size = new System.Drawing.Size(391, 79);
            ((System.ComponentModel.ISupportInitialize)(this.exposureTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar exposureTB;
        private System.Windows.Forms.Label label1;
    }
}
