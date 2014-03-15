namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    partial class RGBMatrixLayerControl
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
            this.value00TB = new System.Windows.Forms.TextBox();
            this.value01TB = new System.Windows.Forms.TextBox();
            this.value02TB = new System.Windows.Forms.TextBox();
            this.value10TB = new System.Windows.Forms.TextBox();
            this.value11TB = new System.Windows.Forms.TextBox();
            this.value12TB = new System.Windows.Forms.TextBox();
            this.value20TB = new System.Windows.Forms.TextBox();
            this.value21TB = new System.Windows.Forms.TextBox();
            this.value22TB = new System.Windows.Forms.TextBox();
            this.refreshBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // value00TB
            // 
            this.value00TB.Location = new System.Drawing.Point(3, 3);
            this.value00TB.Name = "value00TB";
            this.value00TB.Size = new System.Drawing.Size(50, 20);
            this.value00TB.TabIndex = 0;
            this.value00TB.TextChanged += new System.EventHandler(this.ValueChanged);
            this.value00TB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValueDown);
            this.value00TB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ValueUp);
            // 
            // value01TB
            // 
            this.value01TB.Location = new System.Drawing.Point(59, 3);
            this.value01TB.Name = "value01TB";
            this.value01TB.Size = new System.Drawing.Size(50, 20);
            this.value01TB.TabIndex = 0;
            this.value01TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // value02TB
            // 
            this.value02TB.Location = new System.Drawing.Point(115, 3);
            this.value02TB.Name = "value02TB";
            this.value02TB.Size = new System.Drawing.Size(50, 20);
            this.value02TB.TabIndex = 0;
            this.value02TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // value10TB
            // 
            this.value10TB.Location = new System.Drawing.Point(3, 29);
            this.value10TB.Name = "value10TB";
            this.value10TB.Size = new System.Drawing.Size(50, 20);
            this.value10TB.TabIndex = 0;
            this.value10TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // value11TB
            // 
            this.value11TB.Location = new System.Drawing.Point(59, 29);
            this.value11TB.Name = "value11TB";
            this.value11TB.Size = new System.Drawing.Size(50, 20);
            this.value11TB.TabIndex = 0;
            this.value11TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // value12TB
            // 
            this.value12TB.Location = new System.Drawing.Point(115, 29);
            this.value12TB.Name = "value12TB";
            this.value12TB.Size = new System.Drawing.Size(50, 20);
            this.value12TB.TabIndex = 0;
            this.value12TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // value20TB
            // 
            this.value20TB.Location = new System.Drawing.Point(3, 55);
            this.value20TB.Name = "value20TB";
            this.value20TB.Size = new System.Drawing.Size(50, 20);
            this.value20TB.TabIndex = 0;
            this.value20TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // value21TB
            // 
            this.value21TB.Location = new System.Drawing.Point(59, 55);
            this.value21TB.Name = "value21TB";
            this.value21TB.Size = new System.Drawing.Size(50, 20);
            this.value21TB.TabIndex = 0;
            this.value21TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // value22TB
            // 
            this.value22TB.Location = new System.Drawing.Point(115, 55);
            this.value22TB.Name = "value22TB";
            this.value22TB.Size = new System.Drawing.Size(50, 20);
            this.value22TB.TabIndex = 0;
            this.value22TB.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // refreshBT
            // 
            this.refreshBT.Location = new System.Drawing.Point(3, 81);
            this.refreshBT.Name = "refreshBT";
            this.refreshBT.Size = new System.Drawing.Size(75, 23);
            this.refreshBT.TabIndex = 1;
            this.refreshBT.Text = "Refresh";
            this.refreshBT.UseVisualStyleBackColor = true;
            this.refreshBT.Click += new System.EventHandler(this.refreshBT_Click);
            // 
            // RGBMatrixLayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refreshBT);
            this.Controls.Add(this.value22TB);
            this.Controls.Add(this.value12TB);
            this.Controls.Add(this.value02TB);
            this.Controls.Add(this.value21TB);
            this.Controls.Add(this.value11TB);
            this.Controls.Add(this.value01TB);
            this.Controls.Add(this.value20TB);
            this.Controls.Add(this.value10TB);
            this.Controls.Add(this.value00TB);
            this.Name = "RGBMatrixLayerControl";
            this.Size = new System.Drawing.Size(431, 293);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox value00TB;
        private System.Windows.Forms.TextBox value01TB;
        private System.Windows.Forms.TextBox value02TB;
        private System.Windows.Forms.TextBox value10TB;
        private System.Windows.Forms.TextBox value11TB;
        private System.Windows.Forms.TextBox value12TB;
        private System.Windows.Forms.TextBox value20TB;
        private System.Windows.Forms.TextBox value21TB;
        private System.Windows.Forms.TextBox value22TB;
        private System.Windows.Forms.Button refreshBT;

    }
}
