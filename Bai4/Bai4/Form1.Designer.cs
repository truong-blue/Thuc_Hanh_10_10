
namespace Bai4
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDepartments = new System.Windows.Forms.TreeView();
            this.lsvEmployees = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboViewMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDepartments);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lsvEmployees);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvDepartments
            // 
            this.tvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDepartments.Location = new System.Drawing.Point(0, 0);
            this.tvDepartments.Name = "tvDepartments";
            this.tvDepartments.Size = new System.Drawing.Size(266, 404);
            this.tvDepartments.TabIndex = 0;
            this.tvDepartments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDepartments_AfterSelect);
            // 
            // lsvEmployees
            // 
            this.lsvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvEmployees.FullRowSelect = true;
            this.lsvEmployees.GridLines = true;
            this.lsvEmployees.HideSelection = false;
            this.lsvEmployees.Location = new System.Drawing.Point(0, 0);
            this.lsvEmployees.Name = "lsvEmployees";
            this.lsvEmployees.Size = new System.Drawing.Size(530, 404);
            this.lsvEmployees.TabIndex = 0;
            this.lsvEmployees.UseCompatibleStateImageBehavior = false;
            this.lsvEmployees.View = System.Windows.Forms.View.Details;
            this.lsvEmployees.SelectedIndexChanged += new System.EventHandler(this.lsvEmployees_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboViewMode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 46);
            this.panel2.TabIndex = 2;
            // 
            // cboViewMode
            // 
            this.cboViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewMode.FormattingEnabled = true;
            this.cboViewMode.Location = new System.Drawing.Point(108, 9);
            this.cboViewMode.Name = "cboViewMode";
            this.cboViewMode.Size = new System.Drawing.Size(121, 21);
            this.cboViewMode.TabIndex = 1;
            this.cboViewMode.SelectedIndexChanged += new System.EventHandler(this.cboViewMode_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chế độ xem:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "TRÌNH QUẢN LÝ TẬP TIN DẠNG CHUYÊN NGHIỆP";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboViewMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvEmployees;
        private System.Windows.Forms.TreeView tvDepartments;
    }
}

