
namespace Bai2
{
    partial class Form1
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
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lstAvailableServices = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lstSelectedServices = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTongTienChuaGiam = new System.Windows.Forms.Label();
            this.nudChietKhau = new System.Windows.Forms.NumericUpDown();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChietKhau)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(12, 12);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(180, 21);
            this.cboCategory.TabIndex = 0;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // lstAvailableServices
            // 
            this.lstAvailableServices.FormattingEnabled = true;
            this.lstAvailableServices.Location = new System.Drawing.Point(12, 49);
            this.lstAvailableServices.Name = "lstAvailableServices";
            this.lstAvailableServices.Size = new System.Drawing.Size(180, 199);
            this.lstAvailableServices.TabIndex = 1;
            this.lstAvailableServices.SelectedIndexChanged += new System.EventHandler(this.lstAvailableServices_SelectedIndexChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(213, 49);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = ">";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(213, 91);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(213, 132);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "<<";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // lstSelectedServices
            // 
            this.lstSelectedServices.FormattingEnabled = true;
            this.lstSelectedServices.Location = new System.Drawing.Point(304, 49);
            this.lstSelectedServices.Name = "lstSelectedServices";
            this.lstSelectedServices.Size = new System.Drawing.Size(180, 199);
            this.lstSelectedServices.TabIndex = 5;
            this.lstSelectedServices.SelectedIndexChanged += new System.EventHandler(this.lstSelectedServices_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblThanhTien);
            this.groupBox1.Controls.Add(this.nudChietKhau);
            this.groupBox1.Controls.Add(this.lblTongTienChuaGiam);
            this.groupBox1.Location = new System.Drawing.Point(514, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 199);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thanh toán && Chiết khấu";
            // 
            // lblTongTienChuaGiam
            // 
            this.lblTongTienChuaGiam.AutoSize = true;
            this.lblTongTienChuaGiam.Location = new System.Drawing.Point(6, 42);
            this.lblTongTienChuaGiam.Name = "lblTongTienChuaGiam";
            this.lblTongTienChuaGiam.Size = new System.Drawing.Size(90, 13);
            this.lblTongTienChuaGiam.TabIndex = 0;
            this.lblTongTienChuaGiam.Text = "Tổng tiền: 0 VNĐ";
            // 
            // nudChietKhau
            // 
            this.nudChietKhau.Location = new System.Drawing.Point(87, 74);
            this.nudChietKhau.Name = "nudChietKhau";
            this.nudChietKhau.Size = new System.Drawing.Size(79, 20);
            this.nudChietKhau.TabIndex = 1;
            this.nudChietKhau.ValueChanged += new System.EventHandler(this.nudChietKhau_ValueChanged);
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(6, 105);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(96, 13);
            this.lblThanhTien.TabIndex = 2;
            this.lblThanhTien.Text = "Thành tiền: 0 VNĐ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chiết khấu (%):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstSelectedServices);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lstAvailableServices);
            this.Controls.Add(this.cboCategory);
            this.Name = "Form1";
            this.Text = "BẢNG TÍNH TIỀN DỊCH VỤ VÀ CHIẾT KHẤU ĐƠN HÀNG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChietKhau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ListBox lstAvailableServices;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.ListBox lstSelectedServices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudChietKhau;
        private System.Windows.Forms.Label lblTongTienChuaGiam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThanhTien;
    }
}

