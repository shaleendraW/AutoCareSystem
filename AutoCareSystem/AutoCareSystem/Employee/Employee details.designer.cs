namespace AutoCareSystem
{
    partial class Employee_details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_details));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearch = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.DataGridEmployee = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtApt_hollyday = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtFname = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbPosition = new MetroFramework.Controls.MetroComboBox();
            this.dpBirthday = new System.Windows.Forms.DateTimePicker();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.txtCardid = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtNIC = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtLame = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtEmpID = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCity = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtAddressline2 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtTelephone = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtAddressLine1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRepairUpdate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRepairRemove = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRepairClear = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmployee)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtsearch);
            this.groupBox4.Controls.Add(this.DataGridEmployee);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(15, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 315);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(415, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "Employee List";
            // 
            // txtsearch
            // 
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtsearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsearch.HintForeColor = System.Drawing.Color.Silver;
            this.txtsearch.HintText = "Search Employee";
            this.txtsearch.isPassword = false;
            this.txtsearch.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.txtsearch.LineIdleColor = System.Drawing.Color.Gray;
            this.txtsearch.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.txtsearch.LineThickness = 2;
            this.txtsearch.Location = new System.Drawing.Point(266, 22);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(149, 31);
            this.txtsearch.TabIndex = 65;
            this.txtsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsearch_KeyPress);
            // 
            // DataGridEmployee
            // 
            this.DataGridEmployee.AllowUserToAddRows = false;
            this.DataGridEmployee.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridEmployee.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridEmployee.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridEmployee.ColumnHeadersHeight = 21;
            this.DataGridEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridEmployee.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridEmployee.DoubleBuffered = true;
            this.DataGridEmployee.EnableHeadersVisualStyles = false;
            this.DataGridEmployee.GridColor = System.Drawing.Color.White;
            this.DataGridEmployee.HeaderBgColor = System.Drawing.Color.LightSkyBlue;
            this.DataGridEmployee.HeaderForeColor = System.Drawing.Color.Black;
            this.DataGridEmployee.Location = new System.Drawing.Point(6, 60);
            this.DataGridEmployee.MultiSelect = false;
            this.DataGridEmployee.Name = "DataGridEmployee";
            this.DataGridEmployee.ReadOnly = true;
            this.DataGridEmployee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridEmployee.Size = new System.Drawing.Size(449, 246);
            this.DataGridEmployee.TabIndex = 64;
            this.DataGridEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridEmployee_CellClick);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.txtApt_hollyday);
            this.groupBox5.Controls.Add(this.materialLabel4);
            this.groupBox5.Controls.Add(this.txtFname);
            this.groupBox5.Controls.Add(this.materialLabel3);
            this.groupBox5.Controls.Add(this.cmbPosition);
            this.groupBox5.Controls.Add(this.dpBirthday);
            this.groupBox5.Controls.Add(this.rbMale);
            this.groupBox5.Controls.Add(this.rbFemale);
            this.groupBox5.Controls.Add(this.txtCardid);
            this.groupBox5.Controls.Add(this.txtNIC);
            this.groupBox5.Controls.Add(this.txtLame);
            this.groupBox5.Controls.Add(this.txtEmpID);
            this.groupBox5.Controls.Add(this.materialLabel1);
            this.groupBox5.Controls.Add(this.materialLabel12);
            this.groupBox5.Controls.Add(this.materialLabel13);
            this.groupBox5.Controls.Add(this.materialLabel14);
            this.groupBox5.Controls.Add(this.materialLabel15);
            this.groupBox5.Controls.Add(this.materialLabel16);
            this.groupBox5.Controls.Add(this.materialLabel17);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(482, 184);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(236, 365);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "General Info";
            // 
            // txtApt_hollyday
            // 
            this.txtApt_hollyday.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApt_hollyday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtApt_hollyday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtApt_hollyday.HintForeColor = System.Drawing.Color.Empty;
            this.txtApt_hollyday.HintText = "";
            this.txtApt_hollyday.isPassword = false;
            this.txtApt_hollyday.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtApt_hollyday.LineIdleColor = System.Drawing.Color.Gray;
            this.txtApt_hollyday.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtApt_hollyday.LineThickness = 2;
            this.txtApt_hollyday.Location = new System.Drawing.Point(95, 279);
            this.txtApt_hollyday.Margin = new System.Windows.Forms.Padding(4);
            this.txtApt_hollyday.Name = "txtApt_hollyday";
            this.txtApt_hollyday.Size = new System.Drawing.Size(136, 28);
            this.txtApt_hollyday.TabIndex = 82;
            this.txtApt_hollyday.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(15, 272);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(76, 38);
            this.materialLabel4.TabIndex = 81;
            this.materialLabel4.Text = "Accepted \r\nholydays :";
            this.materialLabel4.Click += new System.EventHandler(this.materialLabel4_Click);
            // 
            // txtFname
            // 
            this.txtFname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtFname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFname.HintForeColor = System.Drawing.Color.Empty;
            this.txtFname.HintText = "";
            this.txtFname.isPassword = false;
            this.txtFname.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtFname.LineIdleColor = System.Drawing.Color.Gray;
            this.txtFname.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtFname.LineThickness = 2;
            this.txtFname.Location = new System.Drawing.Point(93, 51);
            this.txtFname.Margin = new System.Windows.Forms.Padding(4);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(135, 27);
            this.txtFname.TabIndex = 80;
            this.txtFname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(5, 59);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(91, 19);
            this.materialLabel3.TabIndex = 79;
            this.materialLabel3.Text = "First Name :";
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.ItemHeight = 23;
            this.cmbPosition.Items.AddRange(new object[] {
            "Select Position",
            "Head Technician ",
            "Senior Technician",
            "Junior Technician ",
            "Clerk"});
            this.cmbPosition.Location = new System.Drawing.Point(95, 208);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(136, 29);
            this.cmbPosition.TabIndex = 78;
            this.cmbPosition.UseSelectable = true;
            // 
            // dpBirthday
            // 
            this.dpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpBirthday.Location = new System.Drawing.Point(93, 153);
            this.dpBirthday.Name = "dpBirthday";
            this.dpBirthday.Size = new System.Drawing.Size(137, 20);
            this.dpBirthday.TabIndex = 77;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(92, 179);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(58, 22);
            this.rbMale.TabIndex = 49;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(154, 179);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(75, 22);
            this.rbFemale.TabIndex = 50;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // txtCardid
            // 
            this.txtCardid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCardid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCardid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCardid.HintForeColor = System.Drawing.Color.Empty;
            this.txtCardid.HintText = "";
            this.txtCardid.isPassword = false;
            this.txtCardid.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtCardid.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCardid.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtCardid.LineThickness = 2;
            this.txtCardid.Location = new System.Drawing.Point(94, 239);
            this.txtCardid.Margin = new System.Windows.Forms.Padding(4);
            this.txtCardid.Name = "txtCardid";
            this.txtCardid.Size = new System.Drawing.Size(136, 27);
            this.txtCardid.TabIndex = 43;
            this.txtCardid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtNIC
            // 
            this.txtNIC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNIC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNIC.HintForeColor = System.Drawing.Color.Empty;
            this.txtNIC.HintText = "";
            this.txtNIC.isPassword = false;
            this.txtNIC.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtNIC.LineIdleColor = System.Drawing.Color.Gray;
            this.txtNIC.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtNIC.LineThickness = 2;
            this.txtNIC.Location = new System.Drawing.Point(93, 112);
            this.txtNIC.Margin = new System.Windows.Forms.Padding(4);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.Size = new System.Drawing.Size(136, 27);
            this.txtNIC.TabIndex = 39;
            this.txtNIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtLame
            // 
            this.txtLame.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtLame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLame.HintForeColor = System.Drawing.Color.Empty;
            this.txtLame.HintText = "";
            this.txtLame.isPassword = false;
            this.txtLame.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtLame.LineIdleColor = System.Drawing.Color.Gray;
            this.txtLame.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtLame.LineThickness = 2;
            this.txtLame.Location = new System.Drawing.Point(92, 82);
            this.txtLame.Margin = new System.Windows.Forms.Padding(4);
            this.txtLame.Name = "txtLame";
            this.txtLame.Size = new System.Drawing.Size(136, 27);
            this.txtLame.TabIndex = 38;
            this.txtLame.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtEmpID
            // 
            this.txtEmpID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtEmpID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmpID.HintForeColor = System.Drawing.Color.Empty;
            this.txtEmpID.HintText = "";
            this.txtEmpID.isPassword = false;
            this.txtEmpID.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtEmpID.LineIdleColor = System.Drawing.Color.Gray;
            this.txtEmpID.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtEmpID.LineThickness = 2;
            this.txtEmpID.Location = new System.Drawing.Point(92, 12);
            this.txtEmpID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(136, 27);
            this.txtEmpID.TabIndex = 37;
            this.txtEmpID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(26, 242);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(66, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Card ID :";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(20, 213);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(73, 19);
            this.materialLabel12.TabIndex = 5;
            this.materialLabel12.Text = "Position :";
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(29, 182);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(64, 19);
            this.materialLabel13.TabIndex = 4;
            this.materialLabel13.Text = "Gender :";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(23, 150);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(71, 19);
            this.materialLabel14.TabIndex = 3;
            this.materialLabel14.Text = "Birthday :";
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(52, 120);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(42, 19);
            this.materialLabel15.TabIndex = 2;
            this.materialLabel15.Text = "NIC :";
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel16.Location = new System.Drawing.Point(6, 90);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(90, 19);
            this.materialLabel16.TabIndex = 1;
            this.materialLabel16.Text = "Last Name :";
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel17.Location = new System.Drawing.Point(63, 20);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(31, 19);
            this.materialLabel17.TabIndex = 0;
            this.materialLabel17.Text = "ID :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtCity);
            this.groupBox3.Controls.Add(this.materialLabel7);
            this.groupBox3.Controls.Add(this.txtAddressline2);
            this.groupBox3.Controls.Add(this.materialLabel2);
            this.groupBox3.Controls.Add(this.txtTelephone);
            this.groupBox3.Controls.Add(this.txtAddressLine1);
            this.groupBox3.Controls.Add(this.materialLabel10);
            this.groupBox3.Controls.Add(this.materialLabel11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(473, 112);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contact Info";
            // 
            // txtCity
            // 
            this.txtCity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCity.HintForeColor = System.Drawing.Color.Empty;
            this.txtCity.HintText = "";
            this.txtCity.isPassword = false;
            this.txtCity.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtCity.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCity.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtCity.LineThickness = 2;
            this.txtCity.Location = new System.Drawing.Point(338, 13);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(112, 29);
            this.txtCity.TabIndex = 77;
            this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(295, 23);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(35, 19);
            this.materialLabel7.TabIndex = 76;
            this.materialLabel7.Text = "City";
            this.materialLabel7.Click += new System.EventHandler(this.materialLabel7_Click);
            // 
            // txtAddressline2
            // 
            this.txtAddressline2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddressline2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtAddressline2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddressline2.HintForeColor = System.Drawing.Color.Empty;
            this.txtAddressline2.HintText = "";
            this.txtAddressline2.isPassword = false;
            this.txtAddressline2.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtAddressline2.LineIdleColor = System.Drawing.Color.Gray;
            this.txtAddressline2.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtAddressline2.LineThickness = 2;
            this.txtAddressline2.Location = new System.Drawing.Point(137, 41);
            this.txtAddressline2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddressline2.Name = "txtAddressline2";
            this.txtAddressline2.Size = new System.Drawing.Size(136, 27);
            this.txtAddressline2.TabIndex = 47;
            this.txtAddressline2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(22, 49);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(116, 19);
            this.materialLabel2.TabIndex = 46;
            this.materialLabel2.Text = "Address Line 2 :";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTelephone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTelephone.HintForeColor = System.Drawing.Color.Empty;
            this.txtTelephone.HintText = "";
            this.txtTelephone.isPassword = false;
            this.txtTelephone.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtTelephone.LineIdleColor = System.Drawing.Color.Gray;
            this.txtTelephone.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtTelephone.LineThickness = 2;
            this.txtTelephone.Location = new System.Drawing.Point(138, 70);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(136, 27);
            this.txtTelephone.TabIndex = 45;
            this.txtTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddressLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtAddressLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddressLine1.HintForeColor = System.Drawing.Color.Empty;
            this.txtAddressLine1.HintText = "";
            this.txtAddressLine1.isPassword = false;
            this.txtAddressLine1.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtAddressLine1.LineIdleColor = System.Drawing.Color.Gray;
            this.txtAddressLine1.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txtAddressLine1.LineThickness = 2;
            this.txtAddressLine1.Location = new System.Drawing.Point(138, 13);
            this.txtAddressLine1.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(136, 27);
            this.txtAddressLine1.TabIndex = 44;
            this.txtAddressLine1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(53, 79);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(87, 19);
            this.materialLabel10.TabIndex = 1;
            this.materialLabel10.Text = "Telephone :";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(22, 21);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(116, 19);
            this.materialLabel11.TabIndex = 0;
            this.materialLabel11.Text = "Address Line 1 :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.bunifuFlatButton1);
            this.groupBox2.Controls.Add(this.imageBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(482, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 172);
            this.groupBox2.TabIndex = 139;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter_1);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 7;
            this.bunifuFlatButton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton1.ButtonText = " Browse";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = global::AutoCareSystem.Properties.Resources.icons8_Camera_Identification_Filled_32__2_;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 50D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(63, 115);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(100, 43);
            this.bunifuFlatButton1.TabIndex = 136;
            this.bunifuFlatButton1.Text = " Browse";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // imageBox
            // 
            this.imageBox.Image = global::AutoCareSystem.Properties.Resources.icons8_User_100__1_;
            this.imageBox.InitialImage = null;
            this.imageBox.Location = new System.Drawing.Point(57, 13);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(106, 96);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnRepairUpdate);
            this.groupBox1.Controls.Add(this.btnRepairRemove);
            this.groupBox1.Controls.Add(this.btnRepairClear);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 445);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnRepairUpdate
            // 
            this.btnRepairUpdate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRepairUpdate.BorderRadius = 7;
            this.btnRepairUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRepairUpdate.ButtonText = "Update";
            this.btnRepairUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepairUpdate.DisabledColor = System.Drawing.Color.Gray;
            this.btnRepairUpdate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRepairUpdate.Iconimage = global::AutoCareSystem.Properties.Resources.Available_Updates_32px;
            this.btnRepairUpdate.Iconimage_right = null;
            this.btnRepairUpdate.Iconimage_right_Selected = null;
            this.btnRepairUpdate.Iconimage_Selected = null;
            this.btnRepairUpdate.IconMarginLeft = 0;
            this.btnRepairUpdate.IconMarginRight = 0;
            this.btnRepairUpdate.IconRightVisible = true;
            this.btnRepairUpdate.IconRightZoom = 0D;
            this.btnRepairUpdate.IconVisible = true;
            this.btnRepairUpdate.IconZoom = 50D;
            this.btnRepairUpdate.IsTab = false;
            this.btnRepairUpdate.Location = new System.Drawing.Point(74, 34);
            this.btnRepairUpdate.Name = "btnRepairUpdate";
            this.btnRepairUpdate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairUpdate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btnRepairUpdate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRepairUpdate.selected = false;
            this.btnRepairUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnRepairUpdate.TabIndex = 136;
            this.btnRepairUpdate.Text = "Update";
            this.btnRepairUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairUpdate.Textcolor = System.Drawing.Color.White;
            this.btnRepairUpdate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepairUpdate.Click += new System.EventHandler(this.btnRepairUpdate_Click);
            // 
            // btnRepairRemove
            // 
            this.btnRepairRemove.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRepairRemove.BorderRadius = 7;
            this.btnRepairRemove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRepairRemove.ButtonText = "Remove";
            this.btnRepairRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepairRemove.DisabledColor = System.Drawing.Color.Gray;
            this.btnRepairRemove.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRepairRemove.Iconimage = global::AutoCareSystem.Properties.Resources.Trash_32px;
            this.btnRepairRemove.Iconimage_right = null;
            this.btnRepairRemove.Iconimage_right_Selected = null;
            this.btnRepairRemove.Iconimage_Selected = null;
            this.btnRepairRemove.IconMarginLeft = 0;
            this.btnRepairRemove.IconMarginRight = 0;
            this.btnRepairRemove.IconRightVisible = true;
            this.btnRepairRemove.IconRightZoom = 0D;
            this.btnRepairRemove.IconVisible = true;
            this.btnRepairRemove.IconZoom = 50D;
            this.btnRepairRemove.IsTab = false;
            this.btnRepairRemove.Location = new System.Drawing.Point(180, 34);
            this.btnRepairRemove.Name = "btnRepairRemove";
            this.btnRepairRemove.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairRemove.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btnRepairRemove.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRepairRemove.selected = false;
            this.btnRepairRemove.Size = new System.Drawing.Size(100, 40);
            this.btnRepairRemove.TabIndex = 137;
            this.btnRepairRemove.Text = "Remove";
            this.btnRepairRemove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairRemove.Textcolor = System.Drawing.Color.White;
            this.btnRepairRemove.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepairRemove.Click += new System.EventHandler(this.btnRepairRemove_Click);
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
            this.btnRepairClear.Location = new System.Drawing.Point(286, 34);
            this.btnRepairClear.Name = "btnRepairClear";
            this.btnRepairClear.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btnRepairClear.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btnRepairClear.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRepairClear.selected = false;
            this.btnRepairClear.Size = new System.Drawing.Size(100, 40);
            this.btnRepairClear.TabIndex = 138;
            this.btnRepairClear.Text = " Clear";
            this.btnRepairClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairClear.Textcolor = System.Drawing.Color.White;
            this.btnRepairClear.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepairClear.Click += new System.EventHandler(this.btnRepairClear_Click);
            // 
            // Employee_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Name = "Employee_details";
            this.Size = new System.Drawing.Size(729, 578);
            this.Load += new System.EventHandler(this.Employee_details_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmployee)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private Bunifu.Framework.UI.BunifuCustomDataGrid DataGridEmployee;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtsearch;
        private Bunifu.Framework.UI.BunifuFlatButton btnRepairUpdate;
        private Bunifu.Framework.UI.BunifuFlatButton btnRepairRemove;
        private System.Windows.Forms.GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private System.Windows.Forms.GroupBox groupBox5;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private Bunifu.Framework.UI.BunifuFlatButton btnRepairClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox imageBox;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtEmpID;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCardid;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtNIC;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtLame;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTelephone;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtAddressLine1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtAddressline2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.DateTimePicker dpBirthday;
        private MetroFramework.Controls.MetroComboBox cmbPosition;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtFname;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCity;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtApt_hollyday;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}
