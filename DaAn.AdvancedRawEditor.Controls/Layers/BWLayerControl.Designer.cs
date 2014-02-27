namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    partial class BWLayerControl
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
            this.redTB = new System.Windows.Forms.TrackBar();
            this.blueTB = new System.Windows.Forms.TrackBar();
            this.greenTB = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.redTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTB)).BeginInit();
            this.SuspendLayout();
            // 
            // redTB
            // 
            this.redTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.redTB.Location = new System.Drawing.Point(3, 3);
            this.redTB.Maximum = 100;
            this.redTB.Name = "redTB";
            this.redTB.Size = new System.Drawing.Size(425, 45);
            this.redTB.TabIndex = 0;
            this.redTB.Value = 100;
            this.redTB.MouseCaptureChanged += new System.EventHandler(this.redTB_MouseCaptureChanged);
            // 
            // blueTB
            // 
            this.blueTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blueTB.Location = new System.Drawing.Point(3, 105);
            this.blueTB.Maximum = 100;
            this.blueTB.Name = "blueTB";
            this.blueTB.Size = new System.Drawing.Size(428, 45);
            this.blueTB.TabIndex = 0;
            this.blueTB.Value = 100;
            this.blueTB.MouseCaptureChanged += new System.EventHandler(this.blueTB_MouseCaptureChanged);
            // 
            // greenTB
            // 
            this.greenTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.greenTB.Location = new System.Drawing.Point(3, 54);
            this.greenTB.Maximum = 100;
            this.greenTB.Name = "greenTB";
            this.greenTB.Size = new System.Drawing.Size(425, 45);
            this.greenTB.TabIndex = 0;
            this.greenTB.Value = 100;
            this.greenTB.MouseCaptureChanged += new System.EventHandler(this.greenTB_MouseCaptureChanged);
            // 
            // BWLayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.greenTB);
            this.Controls.Add(this.blueTB);
            this.Controls.Add(this.redTB);
            this.Name = "BWLayerControl";
            this.Size = new System.Drawing.Size(431, 293);
            ((System.ComponentModel.ISupportInitialize)(this.redTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar redTB;
        private System.Windows.Forms.TrackBar blueTB;
        private System.Windows.Forms.TrackBar greenTB;
    }
}
