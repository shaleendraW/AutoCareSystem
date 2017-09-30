namespace AutoCareSystem
{
    partial class bills_expenses
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
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.cmb_source = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCustomDataGrid1
            // 
            this.bunifuCustomDataGrid1.AllowUserToAddRows = false;
            this.bunifuCustomDataGrid1.AllowUserToDeleteRows = false;
            this.bunifuCustomDataGrid1.AllowUserToResizeColumns = false;
            this.bunifuCustomDataGrid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(76)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bunifuCustomDataGrid1.DoubleBuffered = false;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(76)))), ((int)(((byte)(157)))));
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(10, 103);
            this.bunifuCustomDataGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.ReadOnly = true;
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.RowHeadersWidth = 4;
            this.bunifuCustomDataGrid1.RowTemplate.Height = 24;
            this.bunifuCustomDataGrid1.ShowEditingIcon = false;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(696, 420);
            this.bunifuCustomDataGrid1.TabIndex = 35;
            // 
            // cmb_source
            // 
            this.cmb_source.FormattingEnabled = true;
            this.cmb_source.ItemHeight = 23;
            this.cmb_source.Items.AddRange(new object[] {
            "All Sources",
            "Maintenance",
            "Order",
            "Other",
            "Select Bill Source"});
            this.cmb_source.Location = new System.Drawing.Point(164, 12);
            this.cmb_source.Name = "cmb_source";
            this.cmb_source.Size = new System.Drawing.Size(192, 29);
            this.cmb_source.TabIndex = 147;
            this.cmb_source.UseSelectable = true;
            this.cmb_source.SelectedIndexChanged += new System.EventHandler(this.cmb_source_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(45, 22);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(79, 18);
            this.materialLabel1.TabIndex = 146;
            this.materialLabel1.Text = "Bill Source";
            // 
            // bills_expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmb_source);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.bunifuCustomDataGrid1);
            this.Name = "bills_expenses";
            this.Size = new System.Drawing.Size(717, 536);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private MetroFramework.Controls.MetroComboBox cmb_source;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
