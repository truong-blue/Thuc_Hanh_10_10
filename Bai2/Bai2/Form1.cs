using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Form1 : Form
    {
        // 1. Model đại diện cho một dịch vụ
        public class DichVu
        {
            public string TenDichVu { get; set; }
            public decimal DonGia { get; set; }
            public string LoaiDichVu { get; set; }

            public DichVu(string ten, decimal gia, string loai)
            {
                TenDichVu = ten;
                DonGia = gia;
                LoaiDichVu = loai;
            }

            public override string ToString()
            {
                return $"{TenDichVu} - ({DonGia:N0} VNĐ)";
            }
        }

        // Kho dữ liệu nguồn
        private List<DichVu> _khoDichVu = new List<DichVu>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo kho dịch vụ
            KhoiTaoDuLieu();

            // Nạp danh mục vào ComboBox
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new string[] { "Khám bệnh", "Xét nghiệm", "Chụp X-Quang", "Vắc-xin" });
            cboCategory.SelectedIndex = 0;

            // Cấu hình NumericUpDown chiết khấu (%)
            nudChietKhau.Minimum = 0;
            nudChietKhau.Maximum = 100;
            nudChietKhau.Value = 0;
            nudChietKhau.Increment = 5;

            // Hỗ trợ Double Click để chuyển qua lại
            lstAvailableServices.DoubleClick += (s, ev) => ChuyenDichVuSangChon();
            lstSelectedServices.DoubleClick += (s, ev) => LoaiBoDichVuDaChon();

            TinhToanChiPhi();
        }

        private void KhoiTaoDuLieu()
        {
            _khoDichVu = new List<DichVu>
            {
                new DichVu("Khám tổng quát", 150000m, "Khám bệnh"),
                new DichVu("Khám chuyên khoa Tim mạch", 250000m, "Khám bệnh"),
                new DichVu("Khám Tai - Mũi - Họng", 120000m, "Khám bệnh"),

                new DichVu("Xét nghiệm máu tổng quát", 350000m, "Xét nghiệm"),
                new DichVu("Xét nghiệm đường huyết", 80000m, "Xét nghiệm"),
                new DichVu("Xét nghiệm chức năng gan", 220000m, "Xét nghiệm"),

                new DichVu("Chụp X-Quang lồng ngực", 200000m, "Chụp X-Quang"),
                new DichVu("Chụp X-Quang cột sống", 250000m, "Chụp X-Quang"),

                new DichVu("Tiêm Vắc-xin Cúm mùa", 320000m, "Vắc-xin"),
                new DichVu("Tiêm Vắc-xin Uốn ván", 120000m, "Vắc-xin"),
                new DichVu("Tiêm Vắc-xin Viêm gan B", 280000m, "Vắc-xin")
            };
        }

        // ==========================================
        // YÊU CẦU 1: CHỌN DANH MỤC -> LOAD LISTBOX TRÁI
        // ==========================================
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem != null)
            {
                LoadDichVuTheoLoai(cboCategory.SelectedItem.ToString());
            }
        }

        private void LoadDichVuTheoLoai(string loai)
        {
            lstAvailableServices.Items.Clear();

            // Chỉ hiển thị các dịch vụ chưa được chọn sang bên phải
            var danhSach = _khoDichVu
                .Where(dv => dv.LoaiDichVu == loai && !lstSelectedServices.Items.Cast<DichVu>().Any(s => s.TenDichVu == dv.TenDichVu))
                .ToList();

            foreach (var dv in danhSach)
            {
                lstAvailableServices.Items.Add(dv);
            }
        }

        // ==========================================
        // YÊU CẦU 2: NÚT > (CHUYỂN SANG ĐÃ CHỌN)
        // ==========================================
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ChuyenDichVuSangChon();
        }

        private void ChuyenDichVuSangChon()
        {
            if (lstAvailableServices.SelectedItem is DichVu dv)
            {
                lstSelectedServices.Items.Add(dv);
                lstAvailableServices.Items.Remove(dv);
                TinhToanChiPhi();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ từ danh sách bên trái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // NÚT < (BỎ DỊCH VỤ ĐÃ CHỌN)
        // ==========================================
        private void btnRemove_Click(object sender, EventArgs e)
        {
            LoaiBoDichVuDaChon();
        }

        private void LoaiBoDichVuDaChon()
        {
            if (lstSelectedServices.SelectedItem is DichVu dv)
            {
                lstSelectedServices.Items.Remove(dv);

                // Trả lại danh sách bên trái nếu đúng loại đang xem
                if (cboCategory.SelectedItem != null && dv.LoaiDichVu == cboCategory.SelectedItem.ToString())
                {
                    lstAvailableServices.Items.Add(dv);
                }

                TinhToanChiPhi();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần loại bỏ từ danh sách bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // NÚT << (XÓA TẤT CẢ DỊCH VỤ ĐÃ CHỌN)
        // ==========================================
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.Items.Count == 0) return;

            lstSelectedServices.Items.Clear();
            if (cboCategory.SelectedItem != null)
            {
                LoadDichVuTheoLoai(cboCategory.SelectedItem.ToString());
            }

            TinhToanChiPhi();
        }

        // ==========================================
        // YÊU CẦU 3: TÍNH TỔNG TIỀN & CHIẾT KHẤU REALTIME
        // ==========================================
        private void nudChietKhau_ValueChanged(object sender, EventArgs e)
        {
            TinhToanChiPhi();
        }

        private void TinhToanChiPhi()
        {
            decimal tongChuaGiam = 0m;

            foreach (DichVu dv in lstSelectedServices.Items)
            {
                tongChuaGiam += dv.DonGia;
            }

            decimal phanTramGiam = nudChietKhau.Value;
            decimal tienGiam = tongChuaGiam * (phanTramGiam / 100m);
            decimal thanhTien = tongChuaGiam - tienGiam;

            lblTongTienChuaGiam.Text = $"Tổng tiền: {tongChuaGiam:N0} VNĐ";
            lblThanhTien.Text = $"Thành tiền: {thanhTien:N0} VNĐ";
        }

        // Các hàm sự kiện thừa giữ nguyên để không gây lỗi Designer
        private void lstAvailableServices_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lstSelectedServices_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}