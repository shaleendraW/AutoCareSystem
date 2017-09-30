namespace AutoCareSystem
{
    partial class bills
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.income_bill1 = new AutoCareSystem.bills_income();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.bills_expenses1 = new AutoCareSystem.bills_expenses();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.bills_manage1 = new AutoCareSystem.bills_manage();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(3, 3);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(731, 584);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.income_bill1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(723, 542);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Income Bills";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // income_bill1
            // 
            this.income_bill1.BackColor = System.Drawing.Color.White;
            this.income_bill1.Location = new System.Drawing.Point(3, 3);
            this.income_bill1.Name = "income_bill1";
            this.income_bill1.Size = new System.Drawing.Size(717, 536);
            this.income_bill1.TabIndex = 2;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.bills_expenses1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(723, 542);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Expense Bills";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // bills_expenses1
            // 
            this.bills_expenses1.BackColor = System.Drawing.Color.White;
            this.bills_expenses1.Location = new System.Drawing.Point(3, 3);
            this.bills_expenses1.Name = "bills_expenses1";
            this.bills_expenses1.Size = new System.Drawing.Size(717, 536);
            this.bills_expenses1.TabIndex = 2;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.bills_manage1);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(723, 542);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Manage Other Bills";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // bills_manage1
            // 
            this.bills_manage1.BackColor = System.Drawing.Color.White;
            this.bills_manage1.Location = new System.Drawing.Point(3, 3);
            this.bills_manage1.Name = "bills_manage1";
            this.bills_manage1.Size = new System.Drawing.Size(717, 536);
            this.bills_manage1.TabIndex = 2;
            // 
            // bills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroTabControl1);
            this.Name = "bills";
            this.Size = new System.Drawing.Size(737, 590);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private bills_expenses bills_expenses1;
        private bills_income income_bill1;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private bills_manage bills_manage1;
    }
}
