using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        // ==========================================
        // YÊU CẦU 1 & 2: KIỂM TRA ĐIỀU KIỆN & BẮT LỖI
        // ==========================================
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ cảnh báo lỗi cũ
            epCheck.Clear();

            bool hopLe = true;

            // 1. Kiểm tra Tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                epCheck.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống!");
                hopLe = false;
            }

            // 2. Kiểm tra Mật khẩu
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                epCheck.SetError(txtMatKhau, "Mật khẩu không được để trống!");
                hopLe = false;
            }

            // 3. Kiểm tra Xác nhận mật khẩu
            if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                epCheck.SetError(txtXacNhanMatKhau, "Vui lòng nhập lại mật khẩu xác nhận!");
                hopLe = false;
            }
            else if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                epCheck.SetError(txtXacNhanMatKhau, "Mật khẩu xác nhận không trùng khớp!");
                hopLe = false;
            }

            // 4. Kiểm tra Độ tuổi >= 18
            DateTime ngaySinh = dtpNgaySinh.Value.Date;
            DateTime homNay = DateTime.Today;
            int tuoi = homNay.Year - ngaySinh.Year;

            if (ngaySinh > homNay.AddYears(-tuoi))
            {
                tuoi--;
            }

            if (tuoi < 18)
            {
                epCheck.SetError(dtpNgaySinh, $"Yêu cầu từ đủ 18 tuổi trở lên (Hiện tại: {tuoi} tuổi)!");
                hopLe = false;
            }

            // 5. Kiểm tra Điều khoản dịch vụ
            if (!chkDieuKhoan.Checked)
            {
                epCheck.SetError(chkDieuKhoan, "Bạn cần chấp thuận Điều khoản dịch vụ!");
                hopLe = false;
            }

            // Nếu tất cả thông tin hợp lệ
            if (hopLe)
            {
                string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                string thongBao = $"Đăng ký tài khoản thành công!\n\n" +
                                  $"- Tên đăng nhập: {txtTenDangNhap.Text.Trim()}\n" +
                                  $"- Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy} ({tuoi} tuổi)\n" +
                                  $"- Giới tính: {gioiTinh}";

                MessageBox.Show(thongBao, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // XỬ LÝ LÀM MỚI
        // ==========================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void LamMoiForm()
        {
            epCheck.Clear();

            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtXacNhanMatKhau.Clear();

            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
            rdoNam.Checked = true;
            chkDieuKhoan.Checked = false;

            txtTenDangNhap.Focus();
        }

        // Các hàm sự kiện click/change lỡ tạo giữ nguyên để không gây lỗi Designer
        private void label1_Click(object sender, EventArgs e) { }
        private void rdoNam_CheckedChanged(object sender, EventArgs e) { }
        private void rdoNu_CheckedChanged(object sender, EventArgs e) { }
        private void chkDieuKhoan_CheckedChanged(object sender, EventArgs e) { }
    }
}