namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    partial class ContrastLayerControl
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
            this.contrastTB = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.enabledCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTB)).BeginInit();
            this.SuspendLayout();
            // 
            // contrastTB
            // 
            this.contrastTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contrastTB.Location = new System.Drawing.Point(3, 23);
            this.contrastTB.Maximum = 400;
            this.contrastTB.Name = "contrastTB";
            this.contrastTB.Size = new System.Drawing.Size(385, 45);
            this.contrastTB.TabIndex = 0;
            this.contrastTB.TickFrequency = 5;
            this.contrastTB.MouseCaptureChanged += new System.EventHandler(this.contrastTB_MouseCaptureChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contrast";
            // 
            // enabledCB
            // 
            this.enabledCB.AutoSize = true;
            this.enabledCB.Checked = true;
            this.enabledCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledCB.Location = new System.Drawing.Point(3, 3);
            this.enabledCB.Name = "enabledCB";
            this.enabledCB.Size = new System.Drawing.Size(15, 14);
            this.enabledCB.TabIndex = 2;
            this.enabledCB.UseVisualStyleBackColor = true;
            this.enabledCB.CheckedChanged += new System.EventHandler(this.enabledCB_CheckedChanged);
            // 
            // ContrastLayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enabledCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contrastTB);
            this.Name = "ContrastLayerControl";
            this.Size = new System.Drawing.Size(391, 88);
            ((System.ComponentModel.ISupportInitialize)(this.contrastTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar contrastTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox enabledCB;
    }
}
