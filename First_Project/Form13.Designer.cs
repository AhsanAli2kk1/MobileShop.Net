namespace First_Project
{
    partial class Form13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form13));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Close_Btn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Installment_label = new System.Windows.Forms.Label();
            this.Installment_No_Box = new System.Windows.Forms.TextBox();
            this.Amount_Box = new System.Windows.Forms.TextBox();
            this.Installment_Amount_Label = new System.Windows.Forms.Label();
            this.Okay = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Cyan;
            this.guna2GradientPanel1.Controls.Add(this.Close_Btn);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(351, 30);
            this.guna2GradientPanel1.TabIndex = 3;
            // 
            // Close_Btn
            // 
            this.Close_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.Close_Btn.IconColor = System.Drawing.Color.White;
            this.Close_Btn.Location = new System.Drawing.Point(313, 7);
            this.Close_Btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Close_Btn.Name = "Close_Btn";
            this.Close_Btn.Size = new System.Drawing.Size(29, 20);
            this.Close_Btn.TabIndex = 1;
            this.Close_Btn.Click += new System.EventHandler(this.Close_Btn_Click);
            // 
            // Installment_label
            // 
            this.Installment_label.AutoSize = true;
            this.Installment_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Installment_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Installment_label.Location = new System.Drawing.Point(32, 73);
            this.Installment_label.Name = "Installment_label";
            this.Installment_label.Size = new System.Drawing.Size(115, 21);
            this.Installment_label.TabIndex = 13;
            this.Installment_label.Text = "Installment No.";
            // 
            // Installment_No_Box
            // 
            this.Installment_No_Box.Location = new System.Drawing.Point(204, 78);
            this.Installment_No_Box.Name = "Installment_No_Box";
            this.Installment_No_Box.Size = new System.Drawing.Size(112, 20);
            this.Installment_No_Box.TabIndex = 14;
            this.Installment_No_Box.TextChanged += new System.EventHandler(this.Installment_No_Box_TextChanged);
            // 
            // Amount_Box
            // 
            this.Amount_Box.Location = new System.Drawing.Point(204, 132);
            this.Amount_Box.Name = "Amount_Box";
            this.Amount_Box.Size = new System.Drawing.Size(112, 20);
            this.Amount_Box.TabIndex = 16;
            this.Amount_Box.TextChanged += new System.EventHandler(this.Amount_Box_TextChanged);
            this.Amount_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_Box_KeyPress);
            // 
            // Installment_Amount_Label
            // 
            this.Installment_Amount_Label.AutoSize = true;
            this.Installment_Amount_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Installment_Amount_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Installment_Amount_Label.Location = new System.Drawing.Point(32, 127);
            this.Installment_Amount_Label.Name = "Installment_Amount_Label";
            this.Installment_Amount_Label.Size = new System.Drawing.Size(147, 21);
            this.Installment_Amount_Label.TabIndex = 15;
            this.Installment_Amount_Label.Text = "Installment Amount";
            // 
            // Okay
            // 
            this.Okay.BorderRadius = 1;
            this.Okay.BorderThickness = 2;
            this.Okay.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.Okay.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Okay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Okay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Okay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Okay.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Okay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Okay.FillColor = System.Drawing.Color.Empty;
            this.Okay.FillColor2 = System.Drawing.Color.Empty;
            this.Okay.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Okay.ForeColor = System.Drawing.Color.White;
            this.Okay.Location = new System.Drawing.Point(110, 198);
            this.Okay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Okay.Name = "Okay";
            this.Okay.Size = new System.Drawing.Size(118, 29);
            this.Okay.TabIndex = 17;
            this.Okay.Text = "Add";
            this.Okay.Click += new System.EventHandler(this.Okay_Click);
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(351, 267);
            this.Controls.Add(this.Okay);
            this.Controls.Add(this.Amount_Box);
            this.Controls.Add(this.Installment_Amount_Label);
            this.Controls.Add(this.Installment_No_Box);
            this.Controls.Add(this.Installment_label);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form13";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form13";
            this.Load += new System.EventHandler(this.Form13_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox Close_Btn;
        private System.Windows.Forms.Label Installment_label;
        private System.Windows.Forms.TextBox Installment_No_Box;
        private System.Windows.Forms.TextBox Amount_Box;
        private System.Windows.Forms.Label Installment_Amount_Label;
        private Guna.UI2.WinForms.Guna2GradientButton Okay;
    }
}