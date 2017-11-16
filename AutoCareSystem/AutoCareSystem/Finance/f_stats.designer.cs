namespace AutoCareSystem
{
    partial class f_stats
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radWeekly = new MaterialSkin.Controls.MaterialRadioButton();
            this.radMonthly = new MaterialSkin.Controls.MaterialRadioButton();
            this.radYearly = new MaterialSkin.Controls.MaterialRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbYear = new MetroFramework.Controls.MetroComboBox();
            this.cmbMonth = new MetroFramework.Controls.MetroComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radPie = new MaterialSkin.Controls.MaterialRadioButton();
            this.radBar = new MaterialSkin.Controls.MaterialRadioButton();
            this.radLine = new MaterialSkin.Controls.MaterialRadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radTotal = new MaterialSkin.Controls.MaterialRadioButton();
            this.radSeparate = new MaterialSkin.Controls.MaterialRadioButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radWeekly);
            this.groupBox1.Controls.Add(this.radMonthly);
            this.groupBox1.Controls.Add(this.radYearly);
            this.groupBox1.Location = new System.Drawing.Point(155, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 165);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Period of View";
            // 
            // radWeekly
            // 
            this.radWeekly.AutoSize = true;
            this.radWeekly.Depth = 0;
            this.radWeekly.Font = new System.Drawing.Font("Roboto", 10F);
            this.radWeekly.Location = new System.Drawing.Point(11, 114);
            this.radWeekly.Margin = new System.Windows.Forms.Padding(0);
            this.radWeekly.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radWeekly.MouseState = MaterialSkin.MouseState.HOVER;
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Ripple = true;
            this.radWeekly.Size = new System.Drawing.Size(107, 30);
            this.radWeekly.TabIndex = 39;
            this.radWeekly.TabStop = true;
            this.radWeekly.Text = "Weekly View";
            this.radWeekly.UseVisualStyleBackColor = true;
            this.radWeekly.CheckedChanged += new System.EventHandler(this.radWeekly_CheckedChanged);
            // 
            // radMonthly
            // 
            this.radMonthly.AutoSize = true;
            this.radMonthly.Depth = 0;
            this.radMonthly.Font = new System.Drawing.Font("Roboto", 10F);
            this.radMonthly.Location = new System.Drawing.Point(11, 69);
            this.radMonthly.Margin = new System.Windows.Forms.Padding(0);
            this.radMonthly.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radMonthly.MouseState = MaterialSkin.MouseState.HOVER;
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Ripple = true;
            this.radMonthly.Size = new System.Drawing.Size(112, 30);
            this.radMonthly.TabIndex = 38;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "Monthly View";
            this.radMonthly.UseVisualStyleBackColor = true;
            this.radMonthly.CheckedChanged += new System.EventHandler(this.radMonthly_CheckedChanged);
            // 
            // radYearly
            // 
            this.radYearly.AutoSize = true;
            this.radYearly.Depth = 0;
            this.radYearly.Font = new System.Drawing.Font("Roboto", 10F);
            this.radYearly.Location = new System.Drawing.Point(11, 24);
            this.radYearly.Margin = new System.Windows.Forms.Padding(0);
            this.radYearly.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radYearly.MouseState = MaterialSkin.MouseState.HOVER;
            this.radYearly.Name = "radYearly";
            this.radYearly.Ripple = true;
            this.radYearly.Size = new System.Drawing.Size(101, 30);
            this.radYearly.TabIndex = 37;
            this.radYearly.TabStop = true;
            this.radYearly.Text = "Yearly View";
            this.radYearly.UseVisualStyleBackColor = true;
            this.radYearly.CheckedChanged += new System.EventHandler(this.radYearly_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.materialLabel2);
            this.groupBox2.Controls.Add(this.materialLabel1);
            this.groupBox2.Controls.Add(this.cmbYear);
            this.groupBox2.Controls.Add(this.cmbMonth);
            this.groupBox2.Location = new System.Drawing.Point(325, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 165);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Period";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(7, 101);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(52, 19);
            this.materialLabel2.TabIndex = 38;
            this.materialLabel2.Text = "Month";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(7, 49);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(39, 19);
            this.materialLabel1.TabIndex = 37;
            this.materialLabel1.Text = "Year";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.ItemHeight = 23;
            this.cmbYear.Location = new System.Drawing.Point(63, 39);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 29);
            this.cmbYear.TabIndex = 37;
            this.cmbYear.UseSelectable = true;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.ItemHeight = 23;
            this.cmbMonth.Items.AddRange(new object[] {
            "Select",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(63, 91);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 29);
            this.cmbMonth.TabIndex = 38;
            this.cmbMonth.UseSelectable = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radPie);
            this.groupBox3.Controls.Add(this.radBar);
            this.groupBox3.Controls.Add(this.radLine);
            this.groupBox3.Location = new System.Drawing.Point(11, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 165);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chart Type";
            // 
            // radPie
            // 
            this.radPie.AutoSize = true;
            this.radPie.Depth = 0;
            this.radPie.Font = new System.Drawing.Font("Roboto", 10F);
            this.radPie.Location = new System.Drawing.Point(11, 114);
            this.radPie.Margin = new System.Windows.Forms.Padding(0);
            this.radPie.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radPie.MouseState = MaterialSkin.MouseState.HOVER;
            this.radPie.Name = "radPie";
            this.radPie.Ripple = true;
            this.radPie.Size = new System.Drawing.Size(85, 30);
            this.radPie.TabIndex = 39;
            this.radPie.TabStop = true;
            this.radPie.Text = "Pie Chart";
            this.radPie.UseVisualStyleBackColor = true;
            // 
            // radBar
            // 
            this.radBar.AutoSize = true;
            this.radBar.Depth = 0;
            this.radBar.Font = new System.Drawing.Font("Roboto", 10F);
            this.radBar.Location = new System.Drawing.Point(11, 24);
            this.radBar.Margin = new System.Windows.Forms.Padding(0);
            this.radBar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.radBar.Name = "radBar";
            this.radBar.Ripple = true;
            this.radBar.Size = new System.Drawing.Size(87, 30);
            this.radBar.TabIndex = 38;
            this.radBar.TabStop = true;
            this.radBar.Text = "Bar Chart";
            this.radBar.UseVisualStyleBackColor = true;
            // 
            // radLine
            // 
            this.radLine.AutoSize = true;
            this.radLine.Depth = 0;
            this.radLine.Font = new System.Drawing.Font("Roboto", 10F);
            this.radLine.Location = new System.Drawing.Point(11, 69);
            this.radLine.Margin = new System.Windows.Forms.Padding(0);
            this.radLine.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radLine.MouseState = MaterialSkin.MouseState.HOVER;
            this.radLine.Name = "radLine";
            this.radLine.Ripple = true;
            this.radLine.Size = new System.Drawing.Size(92, 30);
            this.radLine.TabIndex = 40;
            this.radLine.TabStop = true;
            this.radLine.Text = "Line Chart";
            this.radLine.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radTotal);
            this.groupBox4.Controls.Add(this.radSeparate);
            this.groupBox4.Location = new System.Drawing.Point(547, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 165);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Display Mode";
            // 
            // radTotal
            // 
            this.radTotal.AutoSize = true;
            this.radTotal.Depth = 0;
            this.radTotal.Font = new System.Drawing.Font("Roboto", 10F);
            this.radTotal.Location = new System.Drawing.Point(15, 96);
            this.radTotal.Margin = new System.Windows.Forms.Padding(0);
            this.radTotal.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.radTotal.Name = "radTotal";
            this.radTotal.Ripple = true;
            this.radTotal.Size = new System.Drawing.Size(61, 30);
            this.radTotal.TabIndex = 1;
            this.radTotal.TabStop = true;
            this.radTotal.Text = "Total";
            this.radTotal.UseVisualStyleBackColor = true;
            // 
            // radSeparate
            // 
            this.radSeparate.AutoSize = true;
            this.radSeparate.Depth = 0;
            this.radSeparate.Font = new System.Drawing.Font("Roboto", 10F);
            this.radSeparate.Location = new System.Drawing.Point(15, 38);
            this.radSeparate.Margin = new System.Windows.Forms.Padding(0);
            this.radSeparate.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radSeparate.MouseState = MaterialSkin.MouseState.HOVER;
            this.radSeparate.Name = "radSeparate";
            this.radSeparate.Ripple = true;
            this.radSeparate.Size = new System.Drawing.Size(138, 30);
            this.radSeparate.TabIndex = 0;
            this.radSeparate.TabStop = true;
            this.radSeparate.Text = "Separate Sources";
            this.radSeparate.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(11, 185);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(714, 387);
            this.chart1.TabIndex = 38;
            this.chart1.Text = "chart1";
            // 
            // f_stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "f_stats";
            this.Size = new System.Drawing.Size(737, 590);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        protected MaterialSkin.Controls.MaterialRadioButton radYearly;
        protected MaterialSkin.Controls.MaterialRadioButton radMonthly;
        protected MaterialSkin.Controls.MaterialRadioButton radWeekly;
        protected MaterialSkin.Controls.MaterialLabel materialLabel2;
        protected MaterialSkin.Controls.MaterialLabel materialLabel1;
        protected MetroFramework.Controls.MetroComboBox cmbYear;
        protected MetroFramework.Controls.MetroComboBox cmbMonth;
        protected MaterialSkin.Controls.MaterialRadioButton radPie;
        protected MaterialSkin.Controls.MaterialRadioButton radBar;
        protected MaterialSkin.Controls.MaterialRadioButton radLine;
        private System.Windows.Forms.GroupBox groupBox4;
        protected MaterialSkin.Controls.MaterialRadioButton radTotal;
        protected MaterialSkin.Controls.MaterialRadioButton radSeparate;
        protected System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
