namespace AutoCareSystem
{
    partial class income
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.btnLoadTable = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnLoadChart = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(3, 194);
            this.chart1.Size = new System.Drawing.Size(732, 394);
            // 
            // radYearly
            // 
            this.radYearly.CheckedChanged += new System.EventHandler(this.radYearly_CheckedChanged);
            // 
            // radMonthly
            // 
            this.radMonthly.CheckedChanged += new System.EventHandler(this.radMonthly_CheckedChanged);
            // 
            // radWeekly
            // 
            this.radWeekly.CheckedChanged += new System.EventHandler(this.radWeekly_CheckedChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
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
            // radTotal
            // 
            this.radTotal.CheckedChanged += new System.EventHandler(this.radTotal_CheckedChanged);
            // 
            // radSeparate
            // 
            this.radSeparate.CheckedChanged += new System.EventHandler(this.radSeparate_CheckedChanged);
            // 
            // DataGrid1
            // 
            this.DataGrid1.AllowUserToAddRows = false;
            this.DataGrid1.AllowUserToDeleteRows = false;
            this.DataGrid1.AllowUserToResizeColumns = false;
            this.DataGrid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(76)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid1.DoubleBuffered = false;
            this.DataGrid1.EnableHeadersVisualStyles = false;
            this.DataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(76)))), ((int)(((byte)(157)))));
            this.DataGrid1.HeaderForeColor = System.Drawing.Color.White;
            this.DataGrid1.Location = new System.Drawing.Point(176, 194);
            this.DataGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.DataGrid1.Name = "DataGrid1";
            this.DataGrid1.ReadOnly = true;
            this.DataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGrid1.RowHeadersWidth = 4;
            this.DataGrid1.RowTemplate.Height = 24;
            this.DataGrid1.ShowEditingIcon = false;
            this.DataGrid1.Size = new System.Drawing.Size(306, 337);
            this.DataGrid1.TabIndex = 38;
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.Depth = 0;
            this.btnLoadTable.Location = new System.Drawing.Point(134, 168);
            this.btnLoadTable.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.Primary = true;
            this.btnLoadTable.Size = new System.Drawing.Size(194, 21);
            this.btnLoadTable.TabIndex = 41;
            this.btnLoadTable.Text = "Load Table";
            this.btnLoadTable.UseVisualStyleBackColor = true;
            this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
            // 
            // btnLoadChart
            // 
            this.btnLoadChart.Depth = 0;
            this.btnLoadChart.Location = new System.Drawing.Point(365, 168);
            this.btnLoadChart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoadChart.Name = "btnLoadChart";
            this.btnLoadChart.Primary = true;
            this.btnLoadChart.Size = new System.Drawing.Size(194, 21);
            this.btnLoadChart.TabIndex = 42;
            this.btnLoadChart.Text = "Load Chart";
            this.btnLoadChart.UseVisualStyleBackColor = true;
            this.btnLoadChart.Click += new System.EventHandler(this.btnLoadChart_Click);
            // 
            // income
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadChart);
            this.Controls.Add(this.btnLoadTable);
            this.Controls.Add(this.DataGrid1);
            this.Name = "income";
            this.Controls.SetChildIndex(this.chart1, 0);
            this.Controls.SetChildIndex(this.DataGrid1, 0);
            this.Controls.SetChildIndex(this.btnLoadTable, 0);
            this.Controls.SetChildIndex(this.btnLoadChart, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomDataGrid DataGrid1;
        private MaterialSkin.Controls.MaterialRaisedButton btnLoadTable;
        private MaterialSkin.Controls.MaterialRaisedButton btnLoadChart;
    }
}
