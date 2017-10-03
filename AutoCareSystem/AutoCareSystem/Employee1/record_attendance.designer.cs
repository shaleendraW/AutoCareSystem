namespace AutoCareSystem
{
    partial class record_attendance
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
            this.components = new System.ComponentModel.Container();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxVehicleNo = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.btnRepairClear = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRepairTypeAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRepairTypeAdd);
            this.groupBox4.Controls.Add(this.btnRepairClear);
            this.groupBox4.Controls.Add(this.tbxVehicleNo);
            this.groupBox4.Controls.Add(this.materialLabel1);
            this.groupBox4.Controls.Add(this.materialLabel2);
            this.groupBox4.Controls.Add(this.materialLabel4);
            this.groupBox4.Controls.Add(this.materialLabel6);
            this.groupBox4.Location = new System.Drawing.Point(289, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 248);
            this.groupBox4.TabIndex = 110;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Record Attendace";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // tbxVehicleNo
            // 
            this.tbxVehicleNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbxVehicleNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxVehicleNo.HintForeColor = System.Drawing.Color.Empty;
            this.tbxVehicleNo.HintText = "";
            this.tbxVehicleNo.isPassword = false;
            this.tbxVehicleNo.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.tbxVehicleNo.LineIdleColor = System.Drawing.Color.Gray;
            this.tbxVehicleNo.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.tbxVehicleNo.LineThickness = 2;
            this.tbxVehicleNo.Location = new System.Drawing.Point(196, 17);
            this.tbxVehicleNo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVehicleNo.Name = "tbxVehicleNo";
            this.tbxVehicleNo.Size = new System.Drawing.Size(136, 33);
            this.tbxVehicleNo.TabIndex = 36;
            this.tbxVehicleNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 31);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(52, 19);
            this.materialLabel1.TabIndex = 15;
            this.materialLabel1.Text = "Tag ID";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(35, 73);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(49, 19);
            this.materialLabel2.TabIndex = 22;
            this.materialLabel2.Text = "Name";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(35, 113);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(43, 19);
            this.materialLabel4.TabIndex = 24;
            this.materialLabel4.Text = "Time";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(35, 155);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(47, 19);
            this.materialLabel6.TabIndex = 26;
            this.materialLabel6.Text = "Mode";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(28, 402);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 102);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(165, 50);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(47, 19);
            this.materialLabel3.TabIndex = 37;
            this.materialLabel3.Text = "timed";
            // 
            // btnRepairClear
            // 
            this.btnRepairClear.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRepairClear.BorderRadius = 7;
            this.btnRepairClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRepairClear.ButtonText = " Clear";
            this.btnRepairClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepairClear.DisabledColor = System.Drawing.Color.Gray;
            this.btnRepairClear.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRepairClear.Iconimage = global::AutoCareSystem.Properties.Resources.Erase_32px;
            this.btnRepairClear.Iconimage_right = null;
            this.btnRepairClear.Iconimage_right_Selected = null;
            this.btnRepairClear.Iconimage_Selected = null;
            this.btnRepairClear.IconMarginLeft = 0;
            this.btnRepairClear.IconMarginRight = 0;
            this.btnRepairClear.IconRightVisible = true;
            this.btnRepairClear.IconRightZoom = 0D;
            this.btnRepairClear.IconVisible = true;
            this.btnRepairClear.IconZoom = 50D;
            this.btnRepairClear.IsTab = false;
            this.btnRepairClear.Location = new System.Drawing.Point(232, 192);
            this.btnRepairClear.Name = "btnRepairClear";
            this.btnRepairClear.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairClear.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btnRepairClear.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRepairClear.selected = false;
            this.btnRepairClear.Size = new System.Drawing.Size(100, 40);
            this.btnRepairClear.TabIndex = 139;
            this.btnRepairClear.Text = " Clear";
            this.btnRepairClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairClear.Textcolor = System.Drawing.Color.White;
            this.btnRepairClear.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnRepairTypeAdd
            // 
            this.btnRepairTypeAdd.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairTypeAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairTypeAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRepairTypeAdd.BorderRadius = 7;
            this.btnRepairTypeAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRepairTypeAdd.ButtonText = "   Add";
            this.btnRepairTypeAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepairTypeAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btnRepairTypeAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRepairTypeAdd.Iconimage = global::AutoCareSystem.Properties.Resources.Plus_32px;
            this.btnRepairTypeAdd.Iconimage_right = null;
            this.btnRepairTypeAdd.Iconimage_right_Selected = null;
            this.btnRepairTypeAdd.Iconimage_Selected = null;
            this.btnRepairTypeAdd.IconMarginLeft = 0;
            this.btnRepairTypeAdd.IconMarginRight = 0;
            this.btnRepairTypeAdd.IconRightVisible = true;
            this.btnRepairTypeAdd.IconRightZoom = 0D;
            this.btnRepairTypeAdd.IconVisible = true;
            this.btnRepairTypeAdd.IconZoom = 50D;
            this.btnRepairTypeAdd.IsTab = false;
            this.btnRepairTypeAdd.Location = new System.Drawing.Point(105, 192);
            this.btnRepairTypeAdd.Name = "btnRepairTypeAdd";
            this.btnRepairTypeAdd.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairTypeAdd.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btnRepairTypeAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRepairTypeAdd.selected = false;
            this.btnRepairTypeAdd.Size = new System.Drawing.Size(100, 40);
            this.btnRepairTypeAdd.TabIndex = 140;
            this.btnRepairTypeAdd.Text = "   Add";
            this.btnRepairTypeAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairTypeAdd.Textcolor = System.Drawing.Color.White;
            this.btnRepairTypeAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // record_attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "record_attendance";
            this.Size = new System.Drawing.Size(729, 549);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tbxVehicleNo;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Bunifu.Framework.UI.BunifuFlatButton btnRepairClear;
        private Bunifu.Framework.UI.BunifuFlatButton btnRepairTypeAdd;
    }
}
