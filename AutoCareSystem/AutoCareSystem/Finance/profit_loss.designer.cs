namespace AutoCareSystem
{
    partial class profit_loss
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel2
            // 
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.Size = new System.Drawing.Size(52, 19);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.Size = new System.Drawing.Size(39, 19);
            // 
            // radPie
            // 
            this.radPie.CheckedChanged += new System.EventHandler(this.SetChartType);
            // 
            // radBar
            // 
            this.radBar.CheckedChanged += new System.EventHandler(this.SetChartType);
            // 
            // radLine
            // 
            this.radLine.CheckedChanged += new System.EventHandler(this.SetChartType);
            // 
            // profit_loss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "profit_loss";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
