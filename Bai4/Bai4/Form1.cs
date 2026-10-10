using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    // CLASS FORM1 PHẢI ĐẶT ĐẦU TIÊN ĐỂ TRÁNH LỖI DESIGNER
    public partial class Form1 : Form
    {
        // Danh sách nhân viên toàn công ty lưu trong bộ nhớ
        private List<NhanVien> _dsNhanVien = new List<NhanVien>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình chi tiết cột cho ListView
            CauHinhListView();

            // 2. Tạo ImageList động cho icon TreeView và ListView
            TaoImageListMacDinh();

            // 3. Nạp danh mục chế độ xem (View Mode) vào ComboBox
            cboViewMode.Items.Clear();
            cboViewMode.Items.AddRange(new string[] { "Details", "LargeIcon", "SmallIcon", "List", "Tile" });
            cboViewMode.SelectedItem = "Details";

            // 4. Khởi tạo dữ liệu mẫu và xây dựng cây phân cấp
            KhoiTaoDuLieuNhanVien();
            XayDungCayPhongBan();
        }

        // ==========================================
        // CẤU HÌNH CỘT LISTVIEW (YÊU CẦU 3)
        // ==========================================
        private void CauHinhListView()
        {
            lsvEmployees.View = View.Details;
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
            lsvEmployees.Columns.Clear();

            lsvEmployees.Columns.Add("Mã NV", 90, HorizontalAlignment.Left);
            lsvEmployees.Columns.Add("Họ Tên", 160, HorizontalAlignment.Left);
            lsvEmployees.Columns.Add("Chức vụ", 130, HorizontalAlignment.Left);
            lsvEmployees.Columns.Add("Ngày vào làm", 120, HorizontalAlignment.Center);
        }

        // ==========================================
        // YÊU CẦU 1: XÂY DỰNG CẤU TRÚC CÂY DỮ LIỆU MẪU
        // ==========================================
        private void XayDungCayPhongBan()
        {
            tvDepartments.Nodes.Clear();

            // Root: Toàn công ty
            TreeNode root = new TreeNode("Tổng Công Ty Công Nghệ", 0, 0);
            root.Tag = "ALL";

            // Phòng Kỹ thuật & các nhóm
            TreeNode pbKyThuat = new TreeNode("Phòng Kỹ Thuật", 1, 1);
            pbKyThuat.Tag = "KT";

            TreeNode nhomWeb = new TreeNode("Nhóm Web Development", 2, 2);
            nhomWeb.Tag = "KT_WEB";

            TreeNode nhomApp = new TreeNode("Nhóm Mobile & Desktop App", 2, 2);
            nhomApp.Tag = "KT_APP";

            pbKyThuat.Nodes.Add(nhomWeb);
            pbKyThuat.Nodes.Add(nhomApp);

            // Phòng Kinh doanh & các nhóm
            TreeNode pbKinhDoanh = new TreeNode("Phòng Kinh Doanh", 1, 1);
            pbKinhDoanh.Tag = "KD";

            TreeNode nhomMarketing = new TreeNode("Nhóm Marketing", 2, 2);
            nhomMarketing.Tag = "KD_MKT";

            TreeNode nhomSales = new TreeNode("Nhóm Bán Hàng", 2, 2);
            nhomSales.Tag = "KD_SALES";

            pbKinhDoanh.Nodes.Add(nhomMarketing);
            pbKinhDoanh.Nodes.Add(nhomSales);

            // Phòng Nhân sự
            TreeNode pbNhanSu = new TreeNode("Phòng Nhân Sự", 1, 1);
            pbNhanSu.Tag = "HR";

            root.Nodes.Add(pbKyThuat);
            root.Nodes.Add(pbKinhDoanh);
            root.Nodes.Add(pbNhanSu);

            tvDepartments.Nodes.Add(root);
            tvDepartments.ExpandAll();
            tvDepartments.SelectedNode = root; // Mặc định chọn Node gốc
        }

        private void KhoiTaoDuLieuNhanVien()
        {
            _dsNhanVien = new List<NhanVien>
            {
                new NhanVien("NV01", "Nguyễn Văn An", "Trưởng phòng KT", new DateTime(2020, 3, 15), "KT"),
                new NhanVien("NV02", "Trần Thị Bình", "Lập trình viên Fullstack", new DateTime(2021, 6, 1), "KT_WEB"),
                new NhanVien("NV03", "Lê Hoàng Cường", "Lập trình viên Frontend", new DateTime(2022, 8, 20), "KT_WEB"),
                new NhanVien("NV04", "Phạm Minh Đức", "Kỹ sư WinForms/C#", new DateTime(2023, 2, 10), "KT_APP"),
                new NhanVien("NV05", "Đỗ Thu Dung", "Trưởng phòng KD", new DateTime(2019, 11, 5), "KD"),
                new NhanVien("NV06", "Vũ Hải Đăng", "Chuyên viên SEO", new DateTime(2022, 1, 12), "KD_MKT"),
                new NhanVien("NV07", "Hoàng Kim Loan", "Tư vấn viên", new DateTime(2023, 5, 18), "KD_SALES"),
                new NhanVien("NV08", "Ngô Bích Thảo", "Chuyên viên Tuyển dụng", new DateTime(2021, 9, 25), "HR")
            };
        }

        // ==========================================
        // YÊU CẦU 2: CHỌN NODE TRÊN TREEVIEW -> NẠP LISTVIEW
        // ==========================================
        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null) return;

            string maDonVi = e.Node.Tag.ToString();
            List<NhanVien> ketQua;

            if (maDonVi == "ALL")
            {
                ketQua = _dsNhanVien;
            }
            else
            {
                // Lấy nhân viên thuộc nhóm này hoặc thuộc các nhóm con của phòng ban
                ketQua = _dsNhanVien
                    .Where(nv => nv.MaDonVi == maDonVi || nv.MaDonVi.StartsWith(maDonVi + "_"))
                    .ToList();
            }

            HienThiNhanVienLenListView(ketQua);
        }

        private void HienThiNhanVienLenListView(List<NhanVien> danhSach)
        {
            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();

            foreach (var nv in danhSach)
            {
                ListViewItem item = new ListViewItem(nv.MaNV);
                item.ImageIndex = 0;
                item.SubItems.Add(nv.HoTen);
                item.SubItems.Add(nv.ChucVu);
                item.SubItems.Add(nv.NgayVaoLam.ToString("dd/MM/yyyy"));

                lsvEmployees.Items.Add(item);
            }

            lsvEmployees.EndUpdate();
        }

        // ==========================================
        // CHUYỂN ĐỔI CHẾ ĐỘ XEM (VIEW MODE)
        // ==========================================
        private void cboViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboViewMode.SelectedItem == null) return;

            switch (cboViewMode.SelectedItem.ToString())
            {
                case "Details":
                    lsvEmployees.View = View.Details;
                    break;
                case "LargeIcon":
                    lsvEmployees.View = View.LargeIcon;
                    break;
                case "SmallIcon":
                    lsvEmployees.View = View.SmallIcon;
                    break;
                case "List":
                    lsvEmployees.View = View.List;
                    break;
                case "Tile":
                    lsvEmployees.View = View.Tile;
                    break;
            }
        }

        private void cboViewMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cboViewMode_SelectedIndexChanged(sender, e);
        }

        // Tạo icon màu động cho TreeView và ListView để không phụ thuộc file ảnh ngoài
        private void TaoImageListMacDinh()
        {
            ImageList imgTree = new ImageList { ImageSize = new Size(16, 16) };
            ImageList imgLarge = new ImageList { ImageSize = new Size(32, 32) };
            ImageList imgSmall = new ImageList { ImageSize = new Size(16, 16) };

            Bitmap bmp1 = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp1)) g.Clear(Color.DarkBlue);
            Bitmap bmp2 = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp2)) g.Clear(Color.SeaGreen);
            Bitmap bmp3 = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp3)) g.Clear(Color.Goldenrod);

            imgTree.Images.Add(bmp1);
            imgTree.Images.Add(bmp2);
            imgTree.Images.Add(bmp3);
            tvDepartments.ImageList = imgTree;

            Bitmap bmpNvLarge = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmpNvLarge)) g.Clear(Color.SteelBlue);
            imgLarge.Images.Add(bmpNvLarge);
            lsvEmployees.LargeImageList = imgLarge;

            Bitmap bmpNvSmall = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpNvSmall)) g.Clear(Color.SteelBlue);
            imgSmall.Images.Add(bmpNvSmall);
            lsvEmployees.SmallImageList = imgSmall;
        }

        // Các hàm sự kiện lỡ tạo giữ nguyên để không gây lỗi Designer
        private void lsvEmployees_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void lsvEmployees_SelectedIndexChanged(object sender, EventArgs e) { }
    }

    // ĐẶT LỚP NHÂN VIÊN DƯỚI CÙNG FILE
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string MaDonVi { get; set; }

        public NhanVien(string ma, string ten, string cv, DateTime ngay, string donVi)
        {
            MaNV = ma;
            HoTen = ten;
            ChucVu = cv;
            NgayVaoLam = ngay;
            MaDonVi = donVi;
        }
    }
}