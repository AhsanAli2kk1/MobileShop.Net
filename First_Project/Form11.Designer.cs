namespace First_Project
{
    partial class Purchase_History_form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_History_form));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Accessories = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.UCustomerConatiner = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.backbtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Search_Box = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DealersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEI1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEI2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Printbtn = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.UCustomerConatiner.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Cyan;
            this.guna2GradientPanel1.Controls.Add(this.Accessories);
            this.guna2GradientPanel1.Controls.Add(this.guna2ControlBox1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1024, 37);
            this.guna2GradientPanel1.TabIndex = 88;
            // 
            // Accessories
            // 
            this.Accessories.AutoSize = true;
            this.Accessories.BackColor = System.Drawing.Color.OldLace;
            this.Accessories.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accessories.Location = new System.Drawing.Point(111, 7);
            this.Accessories.Name = "Accessories";
            this.Accessories.Size = new System.Drawing.Size(179, 30);
            this.Accessories.TabIndex = 49;
            this.Accessories.Text = "Purchase History";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(973, 9);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(39, 25);
            this.guna2ControlBox1.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.guna2Panel1.Controls.Add(this.UCustomerConatiner);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 37);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(113, 539);
            this.guna2Panel1.TabIndex = 89;
            // 
            // UCustomerConatiner
            // 
            this.UCustomerConatiner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.UCustomerConatiner.Controls.Add(this.backbtn);
            this.UCustomerConatiner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.UCustomerConatiner.Location = new System.Drawing.Point(0, 24);
            this.UCustomerConatiner.Name = "UCustomerConatiner";
            this.UCustomerConatiner.Size = new System.Drawing.Size(106, 36);
            this.UCustomerConatiner.TabIndex = 11;
            // 
            // backbtn
            // 
            this.backbtn.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.backbtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.backbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.backbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.backbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.backbtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.backbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.backbtn.FillColor = System.Drawing.Color.Empty;
            this.backbtn.FillColor2 = System.Drawing.Color.Empty;
            this.backbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.backbtn.ForeColor = System.Drawing.Color.White;
            this.backbtn.Location = new System.Drawing.Point(0, 0);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(106, 36);
            this.backbtn.TabIndex = 8;
            this.backbtn.Text = "Back";
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Search_Box);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(119, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 107);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // Search_Box
            // 
            this.Search_Box.Location = new System.Drawing.Point(19, 50);
            this.Search_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Search_Box.Name = "Search_Box";
            this.Search_Box.Size = new System.Drawing.Size(173, 33);
            this.Search_Box.TabIndex = 16;
            this.Search_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Search_Box_KeyPress);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SearchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.Location = new System.Drawing.Point(221, 47);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(175, 36);
            this.SearchBtn.TabIndex = 5;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DealersName,
            this.CNIC,
            this.MobileBrand,
            this.MobileModel,
            this.IMEI1,
            this.IMEI2,
            this.TransactionType,
            this.TotalPrice});
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.Location = new System.Drawing.Point(116, 156);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(908, 357);
            this.dataGridView2.TabIndex = 91;
            // 
            // DealersName
            // 
            this.DealersName.DataPropertyName = "DealersName";
            this.DealersName.HeaderText = "Name";
            this.DealersName.Name = "DealersName";
            this.DealersName.Width = 110;
            // 
            // CNIC
            // 
            this.CNIC.DataPropertyName = "CNIC";
            this.CNIC.HeaderText = "CNIC";
            this.CNIC.Name = "CNIC";
            this.CNIC.Width = 110;
            // 
            // MobileBrand
            // 
            this.MobileBrand.DataPropertyName = "MobileBrand";
            this.MobileBrand.HeaderText = "Brand";
            this.MobileBrand.Name = "MobileBrand";
            this.MobileBrand.Width = 105;
            // 
            // MobileModel
            // 
            this.MobileModel.DataPropertyName = "MobileModel";
            this.MobileModel.HeaderText = "Model";
            this.MobileModel.Name = "MobileModel";
            this.MobileModel.Width = 120;
            // 
            // IMEI1
            // 
            this.IMEI1.DataPropertyName = "IMEI1";
            this.IMEI1.HeaderText = "IMEI1";
            this.IMEI1.Name = "IMEI1";
            // 
            // IMEI2
            // 
            this.IMEI2.DataPropertyName = "IMEI2";
            this.IMEI2.HeaderText = "IMEI2";
            this.IMEI2.Name = "IMEI2";
            // 
            // TransactionType
            // 
            this.TransactionType.DataPropertyName = "TransactionType";
            this.TransactionType.HeaderText = "Transection_Method";
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.Width = 120;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "Total_Price";
            this.TotalPrice.Name = "TotalPrice";
            // 
            // Printbtn
            // 
            this.Printbtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Printbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Printbtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Printbtn.Location = new System.Drawing.Point(770, 520);
            this.Printbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Printbtn.Name = "Printbtn";
            this.Printbtn.Size = new System.Drawing.Size(241, 43);
            this.Printbtn.TabIndex = 92;
            this.Printbtn.Text = "Print";
            this.Printbtn.UseVisualStyleBackColor = false;
            this.Printbtn.Click += new System.EventHandler(this.Printbtn_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Purchase_History_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1024, 576);
            this.Controls.Add(this.Printbtn);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Purchase_History_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form11";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.UCustomerConatiner.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label Accessories;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel UCustomerConatiner;
        private Guna.UI2.WinForms.Guna2GradientButton backbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button Printbtn;
        private System.Windows.Forms.TextBox Search_Box;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMEI1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMEI2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
    }
}