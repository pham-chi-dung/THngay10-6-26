namespace bai52
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboCategory = new ComboBox();
            lstAvailableServices = new ListBox();
            lstSelectedServices = new ListBox();
            btnRemove = new Button();
            btnSelect = new Button();
            btnClearAll = new Button();
            txtSubTotal = new TextBox();
            txtDiscount = new TextBox();
            txtTotal = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(170, 12);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 0;
            // 
            // lstAvailableServices
            // 
            lstAvailableServices.FormattingEnabled = true;
            lstAvailableServices.Location = new Point(12, 203);
            lstAvailableServices.Name = "lstAvailableServices";
            lstAvailableServices.Size = new Size(150, 104);
            lstAvailableServices.TabIndex = 1;
            // 
            // lstSelectedServices
            // 
            lstSelectedServices.FormattingEnabled = true;
            lstSelectedServices.Location = new Point(284, 203);
            lstSelectedServices.Name = "lstSelectedServices";
            lstSelectedServices.Size = new Size(150, 104);
            lstSelectedServices.TabIndex = 2;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(12, 356);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 29);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "<";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(240, 356);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(94, 29);
            btnSelect.TabIndex = 4;
            btnSelect.Text = ">";
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(12, 409);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(94, 29);
            btnClearAll.TabIndex = 5;
            btnClearAll.Text = "<<";
            btnClearAll.UseVisualStyleBackColor = true;
            // 
            // txtSubTotal
            // 
            txtSubTotal.Location = new Point(663, 94);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.ReadOnly = true;
            txtSubTotal.Size = new Size(125, 27);
            txtSubTotal.TabIndex = 6;
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(663, 162);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(125, 27);
            txtDiscount.TabIndex = 7;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(663, 227);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(125, 27);
            txtTotal.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(511, 101);
            label1.Name = "label1";
            label1.Size = new Size(146, 20);
            label1.TabIndex = 9;
            label1.Text = "Tổng tiền chưa giảm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(520, 162);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 10;
            label2.Text = "Tỷ lệ chiết khấu (%)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(504, 230);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 11;
            label3.Text = "Thành tiền thanh toán";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 20);
            label4.Name = "label4";
            label4.Size = new Size(125, 20);
            label4.TabIndex = 12;
            label4.Text = "danh mục dịch vụ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-1, 180);
            label5.Name = "label5";
            label5.Size = new Size(240, 20);
            label5.TabIndex = 13;
            label5.Text = "dịch vụ thuộc danh mục được chọn";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(284, 180);
            label6.Name = "label6";
            label6.Size = new Size(194, 20);
            label6.TabIndex = 14;
            label6.Text = "dịch vụ người dùng đã chọn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTotal);
            Controls.Add(txtDiscount);
            Controls.Add(txtSubTotal);
            Controls.Add(btnClearAll);
            Controls.Add(btnSelect);
            Controls.Add(btnRemove);
            Controls.Add(lstSelectedServices);
            Controls.Add(lstAvailableServices);
            Controls.Add(cboCategory);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategory;
        private ListBox lstAvailableServices;
        private ListBox lstSelectedServices;
        private Button btnRemove;
        private Button btnSelect;
        private Button btnClearAll;
        private TextBox txtSubTotal;
        private TextBox txtDiscount;
        private TextBox txtTotal;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
