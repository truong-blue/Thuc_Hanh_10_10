using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form1 : Form
    {
        // 2. KHAI BÁO DANH SÁCH LƯU TRONG BỘ NHỚ VÀ BINDINGSOURCE
        private List<Product> _danhSachSP = new List<Product>();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu ComboBox Danh mục
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Linh kiện", "Phụ kiện" });
            cboCategory.SelectedIndex = 0;

            // Dữ liệu mẫu ban đầu
            _danhSachSP.Add(new Product("SP01", "Laptop Dell XPS", 25000000m, 5, "Laptop"));
            _danhSachSP.Add(new Product("SP02", "Chuột Logitech G102", 400000m, 15, "Phụ kiện"));

            // Đăng ký sự kiện click dòng trên DataGridView
            dgvProducts.CellClick += DgvProducts_CellClick;

            // Hiển thị lên DataGridView
            CapNhatDataGridView(_danhSachSP);
        }

        // Cập nhật DataGridView qua BindingSource
        private void CapNhatDataGridView(List<Product> nguonDuLieu)
        {
            _bindingSource.DataSource = null;
            _bindingSource.DataSource = nguonDuLieu;
            dgvProducts.DataSource = _bindingSource;

            // Cấu hình tiêu đề cột tiếng Việt
            if (dgvProducts.Columns["ProductId"] != null) dgvProducts.Columns["ProductId"].HeaderText = "Mã SP";
            if (dgvProducts.Columns["ProductName"] != null) dgvProducts.Columns["ProductName"].HeaderText = "Tên SP";
            if (dgvProducts.Columns["UnitPrice"] != null)
            {
                dgvProducts.Columns["UnitPrice"].HeaderText = "Đơn giá (VNĐ)";
                dgvProducts.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            }
            if (dgvProducts.Columns["Quantity"] != null) dgvProducts.Columns["Quantity"].HeaderText = "Số lượng";
            if (dgvProducts.Columns["Category"] != null) dgvProducts.Columns["Category"].HeaderText = "Danh mục";
        }

        // ==========================================
        // YÊU CẦU 2: NÚT THÊM
        // ==========================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtProductId.Text.Trim();
            string ten = txtProductName.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_danhSachSP.Any(p => p.ProductId.Equals(ma, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Mã sản phẩm '{ma}' đã tồn tại!", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductId.Focus();
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ và không âm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitPrice.Focus();
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            Product spMoi = new Product(ma, ten, donGia, soLuong, cboCategory.SelectedItem.ToString());
            _danhSachSP.Add(spMoi);

            CapNhatDataGridView(_danhSachSP);
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaTrangForm();
        }

        // ==========================================
        // YÊU CẦU 3: CLICK DÒNG ĐẨY LÊN TEXTBOX
        // ==========================================
        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].DataBoundItem is Product sp)
            {
                txtProductId.Text = sp.ProductId;
                txtProductName.Text = sp.ProductName;
                txtUnitPrice.Text = sp.UnitPrice.ToString("G0");
                txtQuantity.Text = sp.Quantity.ToString();
                cboCategory.SelectedItem = sp.Category;

                txtProductId.ReadOnly = true; // Khóa mã SP khi sửa
            }
        }

        // ==========================================
        // NÚT SỬA
        // ==========================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtProductId.Text.Trim();
            Product sp = _danhSachSP.FirstOrDefault(p => p.ProductId.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitPrice.Focus();
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            sp.ProductName = txtProductName.Text.Trim();
            sp.UnitPrice = donGia;
            sp.Quantity = soLuong;
            sp.Category = cboCategory.SelectedItem.ToString();

            CapNhatDataGridView(_danhSachSP);
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaTrangForm();
        }

        // ==========================================
        // YÊU CẦU 4: NÚT XÓA (XÁC NHẬN MESSAGEBOX)
        // ==========================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || !(dgvProducts.CurrentRow.DataBoundItem is Product spDangChon))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm [{spDangChon.ProductId} - {spDangChon.ProductName}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _danhSachSP.Remove(spDangChon);
                CapNhatDataGridView(_danhSachSP);
                XoaTrangForm();
                MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // NÚT TÌM KIẾM THEO TÊN
        // ==========================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                CapNhatDataGridView(_danhSachSP);
                return;
            }

            var ketQua = _danhSachSP
                .Where(p => p.ProductName.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            CapNhatDataGridView(ketQua);
        }

        // ==========================================
        // NÚT LÀM MỚI
        // ==========================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            XoaTrangForm();
            CapNhatDataGridView(_danhSachSP);
        }

        private void XoaTrangForm()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            txtProductId.ReadOnly = false;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            txtProductId.Focus();
        }

        // Các hàm click lỡ tạo trên Label để nguyên tránh lỗi Designer
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        // 1. ĐỊNH NGHĨA LỚP PRODUCT
        public class Product
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public string Category { get; set; }

            public Product() { }

            public Product(string id, string name, decimal price, int quantity, string category)
            {
                ProductId = id;
                ProductName = name;
                UnitPrice = price;
                Quantity = quantity;
                Category = category;
            }
        }
    }
}