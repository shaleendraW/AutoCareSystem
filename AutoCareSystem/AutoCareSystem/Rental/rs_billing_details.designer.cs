namespace AutoCareSystem
{
    partial class rs_billing_details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rs_billing_details));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_bill_id = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_bill_final_millage = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_bill_damage_amount = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.datepicker_bill_date = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_bill_rent_id = new MetroFramework.Controls.MetroComboBox();
            this.txt_bill_total_amount = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_add = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_remove = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_clear = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_update = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.PictureBox();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_search = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(8, 170);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 211;
            this.materialLabel1.Text = "Bill Date";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(8, 21);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(48, 19);
            this.materialLabel5.TabIndex = 209;
            this.materialLabel5.Text = "Bill ID";
            // 
            // txt_bill_id
            // 
            this.txt_bill_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bill_id.Enabled = false;
            this.txt_bill_id.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_bill_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_bill_id.HintForeColor = System.Drawing.Color.Empty;
            this.txt_bill_id.HintText = "";
            this.txt_bill_id.isPassword = false;
            this.txt_bill_id.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_id.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_bill_id.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_id.LineThickness = 2;
            this.txt_bill_id.Location = new System.Drawing.Point(131, 12);
            this.txt_bill_id.Margin = new System.Windows.Forms.Padding(4);
            this.txt_bill_id.Name = "txt_bill_id";
            this.txt_bill_id.Size = new System.Drawing.Size(134, 28);
            this.txt_bill_id.TabIndex = 208;
            this.txt_bill_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_bill_final_millage
            // 
            this.txt_bill_final_millage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bill_final_millage.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_bill_final_millage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_bill_final_millage.HintForeColor = System.Drawing.Color.Empty;
            this.txt_bill_final_millage.HintText = "";
            this.txt_bill_final_millage.isPassword = false;
            this.txt_bill_final_millage.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_final_millage.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_bill_final_millage.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_final_millage.LineThickness = 2;
            this.txt_bill_final_millage.Location = new System.Drawing.Point(131, 84);
            this.txt_bill_final_millage.Margin = new System.Windows.Forms.Padding(4);
            this.txt_bill_final_millage.Name = "txt_bill_final_millage";
            this.txt_bill_final_millage.Size = new System.Drawing.Size(134, 28);
            this.txt_bill_final_millage.TabIndex = 215;
            this.txt_bill_final_millage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(8, 93);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(94, 19);
            this.materialLabel3.TabIndex = 214;
            this.materialLabel3.Text = "Final Millage";
            // 
            // txt_bill_damage_amount
            // 
            this.txt_bill_damage_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bill_damage_amount.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_bill_damage_amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_bill_damage_amount.HintForeColor = System.Drawing.Color.Empty;
            this.txt_bill_damage_amount.HintText = "";
            this.txt_bill_damage_amount.isPassword = false;
            this.txt_bill_damage_amount.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_damage_amount.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_bill_damage_amount.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_damage_amount.LineThickness = 2;
            this.txt_bill_damage_amount.Location = new System.Drawing.Point(132, 124);
            this.txt_bill_damage_amount.Margin = new System.Windows.Forms.Padding(4);
            this.txt_bill_damage_amount.Name = "txt_bill_damage_amount";
            this.txt_bill_damage_amount.Size = new System.Drawing.Size(134, 28);
            this.txt_bill_damage_amount.TabIndex = 217;
            this.txt_bill_damage_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_bill_damage_amount.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox3_OnValueChanged);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(8, 133);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(121, 19);
            this.materialLabel4.TabIndex = 216;
            this.materialLabel4.Text = "Damage Amount";
            this.materialLabel4.Click += new System.EventHandler(this.materialLabel4_Click);
            // 
            // datepicker_bill_date
            // 
            this.datepicker_bill_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepicker_bill_date.Location = new System.Drawing.Point(131, 170);
            this.datepicker_bill_date.Name = "datepicker_bill_date";
            this.datepicker_bill_date.Size = new System.Drawing.Size(134, 20);
            this.datepicker_bill_date.TabIndex = 218;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_bill_rent_id);
            this.groupBox1.Controls.Add(this.txt_bill_total_amount);
            this.groupBox1.Controls.Add(this.materialLabel6);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.btn_add);
            this.groupBox1.Controls.Add(this.btn_remove);
            this.groupBox1.Controls.Add(this.datepicker_bill_date);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.btn_clear);
            this.groupBox1.Controls.Add(this.txt_bill_damage_amount);
            this.groupBox1.Controls.Add(this.btn_update);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.txt_bill_id);
            this.groupBox1.Controls.Add(this.txt_bill_final_millage);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Location = new System.Drawing.Point(22, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 219);
            this.groupBox1.TabIndex = 221;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Billing Details";
            // 
            // cmb_bill_rent_id
            // 
            this.cmb_bill_rent_id.FormattingEnabled = true;
            this.cmb_bill_rent_id.ItemHeight = 23;
            this.cmb_bill_rent_id.Location = new System.Drawing.Point(131, 57);
            this.cmb_bill_rent_id.Name = "cmb_bill_rent_id";
            this.cmb_bill_rent_id.Size = new System.Drawing.Size(135, 29);
            this.cmb_bill_rent_id.TabIndex = 243;
            this.cmb_bill_rent_id.UseSelectable = true;
            this.cmb_bill_rent_id.DropDown += new System.EventHandler(this.cmb_bill_rent_id_DropDown);
            // 
            // txt_bill_total_amount
            // 
            this.txt_bill_total_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bill_total_amount.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_bill_total_amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_bill_total_amount.HintForeColor = System.Drawing.Color.Empty;
            this.txt_bill_total_amount.HintText = "";
            this.txt_bill_total_amount.isPassword = false;
            this.txt_bill_total_amount.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_total_amount.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_bill_total_amount.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.txt_bill_total_amount.LineThickness = 2;
            this.txt_bill_total_amount.Location = new System.Drawing.Point(546, 161);
            this.txt_bill_total_amount.Margin = new System.Windows.Forms.Padding(4);
            this.txt_bill_total_amount.Name = "txt_bill_total_amount";
            this.txt_bill_total_amount.Size = new System.Drawing.Size(134, 28);
            this.txt_bill_total_amount.TabIndex = 222;
            this.txt_bill_total_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(404, 170);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(126, 19);
            this.materialLabel6.TabIndex = 221;
            this.materialLabel6.Text = "Total Bill Amount";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(8, 57);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(57, 19);
            this.materialLabel2.TabIndex = 219;
            this.materialLabel2.Text = "Rent ID";
            // 
            // btn_add
            // 
            this.btn_add.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.BorderRadius = 7;
            this.btn_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_add.ButtonText = "   Add";
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btn_add.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_add.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_add.Iconimage")));
            this.btn_add.Iconimage_right = null;
            this.btn_add.Iconimage_right_Selected = null;
            this.btn_add.Iconimage_Selected = null;
            this.btn_add.IconMarginLeft = 0;
            this.btn_add.IconMarginRight = 0;
            this.btn_add.IconRightVisible = true;
            this.btn_add.IconRightZoom = 0D;
            this.btn_add.IconVisible = true;
            this.btn_add.IconZoom = 50D;
            this.btn_add.IsTab = false;
            this.btn_add.Location = new System.Drawing.Point(472, 36);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_add.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btn_add.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_add.selected = false;
            this.btn_add.Size = new System.Drawing.Size(100, 40);
            this.btn_add.TabIndex = 144;
            this.btn_add.Text = "   Add";
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add.Textcolor = System.Drawing.Color.White;
            this.btn_add.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click_1);
            // 
            // btn_remove
            // 
            this.btn_remove.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_remove.BorderRadius = 7;
            this.btn_remove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_remove.ButtonText = "Remove";
            this.btn_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_remove.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btn_remove.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_remove.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_remove.Iconimage")));
            this.btn_remove.Iconimage_right = null;
            this.btn_remove.Iconimage_right_Selected = null;
            this.btn_remove.Iconimage_Selected = null;
            this.btn_remove.IconMarginLeft = 0;
            this.btn_remove.IconMarginRight = 0;
            this.btn_remove.IconRightVisible = true;
            this.btn_remove.IconRightZoom = 0D;
            this.btn_remove.IconVisible = true;
            this.btn_remove.IconZoom = 50D;
            this.btn_remove.IsTab = false;
            this.btn_remove.Location = new System.Drawing.Point(580, 84);
            this.btn_remove.Margin = new System.Windows.Forms.Padding(4);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_remove.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btn_remove.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_remove.selected = false;
            this.btn_remove.Size = new System.Drawing.Size(100, 40);
            this.btn_remove.TabIndex = 143;
            this.btn_remove.Text = "Remove";
            this.btn_remove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_remove.Textcolor = System.Drawing.Color.White;
            this.btn_remove.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_clear.BorderRadius = 7;
            this.btn_clear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_clear.ButtonText = " Clear";
            this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btn_clear.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_clear.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_clear.Iconimage")));
            this.btn_clear.Iconimage_right = null;
            this.btn_clear.Iconimage_right_Selected = null;
            this.btn_clear.Iconimage_Selected = null;
            this.btn_clear.IconMarginLeft = 0;
            this.btn_clear.IconMarginRight = 0;
            this.btn_clear.IconRightVisible = true;
            this.btn_clear.IconRightZoom = 0D;
            this.btn_clear.IconVisible = true;
            this.btn_clear.IconZoom = 50D;
            this.btn_clear.IsTab = false;
            this.btn_clear.Location = new System.Drawing.Point(580, 36);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_clear.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btn_clear.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_clear.selected = false;
            this.btn_clear.Size = new System.Drawing.Size(100, 40);
            this.btn_clear.TabIndex = 145;
            this.btn_clear.Text = " Clear";
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_clear.Textcolor = System.Drawing.Color.White;
            this.btn_clear.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_update
            // 
            this.btn_update.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_update.BorderRadius = 7;
            this.btn_update.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_update.ButtonText = "Update";
            this.btn_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btn_update.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_update.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_update.Iconimage")));
            this.btn_update.Iconimage_right = null;
            this.btn_update.Iconimage_right_Selected = null;
            this.btn_update.Iconimage_Selected = null;
            this.btn_update.IconMarginLeft = 0;
            this.btn_update.IconMarginRight = 0;
            this.btn_update.IconRightVisible = true;
            this.btn_update.IconRightZoom = 0D;
            this.btn_update.IconVisible = true;
            this.btn_update.IconZoom = 50D;
            this.btn_update.IsTab = false;
            this.btn_update.Location = new System.Drawing.Point(472, 84);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.btn_update.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.btn_update.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_update.selected = false;
            this.btn_update.Size = new System.Drawing.Size(100, 40);
            this.btn_update.TabIndex = 146;
            this.btn_update.Text = "Update";
            this.btn_update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_update.Textcolor = System.Drawing.Color.White;
            this.btn_update.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_search);
            this.groupBox3.Controls.Add(this.bunifuCustomDataGrid1);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txt_search);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(22, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 288);
            this.groupBox3.TabIndex = 220;
            this.groupBox3.TabStop = false;
            // 
            // btn_search
            // 
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.Location = new System.Drawing.Point(645, 19);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(35, 38);
            this.btn_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_search.TabIndex = 141;
            this.btn_search.TabStop = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // bunifuCustomDataGrid1
            // 
            this.bunifuCustomDataGrid1.AllowUserToAddRows = false;
            this.bunifuCustomDataGrid1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGrid1.ColumnHeadersHeight = 21;
            this.bunifuCustomDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGrid1.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.GridColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.LightSkyBlue;
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.Black;
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(16, 65);
            this.bunifuCustomDataGrid1.MultiSelect = false;
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.ReadOnly = true;
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(662, 209);
            this.bunifuCustomDataGrid1.TabIndex = 58;
            this.bunifuCustomDataGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGrid1_CellClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(12, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 24);
            this.label15.TabIndex = 55;
            this.label15.Text = "Billing Details";
            // 
            // txt_search
            // 
            this.txt_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_search.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_search.HintForeColor = System.Drawing.Color.Silver;
            this.txt_search.HintText = "Bill ID";
            this.txt_search.isPassword = false;
            this.txt_search.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.txt_search.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_search.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.txt_search.LineThickness = 2;
            this.txt_search.Location = new System.Drawing.Point(499, 29);
            this.txt_search.Margin = new System.Windows.Forms.Padding(4);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(149, 31);
            this.txt_search.TabIndex = 53;
            this.txt_search.Text = "BILL ID";
            this.txt_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 7;
            this.bunifuFlatButton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton1.ButtonText = "      Print The BIll";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = global::AutoCareSystem.Properties.Resources.Print_32px;
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
            this.bunifuFlatButton1.Location = new System.Drawing.Point(34, 535);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(111)))), ((int)(((byte)(194)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(181, 40);
            this.bunifuFlatButton1.TabIndex = 164;
            this.bunifuFlatButton1.Text = "      Print The BIll";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // rs_billing_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "rs_billing_details";
            this.Size = new System.Drawing.Size(741, 589);
            this.Load += new System.EventHandler(this.rs_billing_details_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.rs_billing_details_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_bill_id;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_bill_final_millage;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_bill_damage_amount;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.DateTimePicker datepicker_bill_date;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_add;
        private Bunifu.Framework.UI.BunifuFlatButton btn_remove;
        private Bunifu.Framework.UI.BunifuFlatButton btn_clear;
        private Bunifu.Framework.UI.BunifuFlatButton btn_update;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox btn_search;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private System.Windows.Forms.Label label15;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_search;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_bill_total_amount;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private MetroFramework.Controls.MetroComboBox cmb_bill_rent_id;
    }
}
