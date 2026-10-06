using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bai54
{
    public partial class Form1 : Form
    {
        // Danh sách nhân viên mẫu
        private List<Employee> _allEmployees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            InitData();
            SetupListView();
            SetupTreeView();
            SetupComboBox();

            // Đăng ký sự kiện chọn Node trên TreeView và đổi chế độ xem trên ComboBox
            tvDepartments.AfterSelect += TvDepartments_AfterSelect;
            cboView.SelectedIndexChanged += CboView_SelectedIndexChanged;

            // Mở rộng toàn bộ các nhánh cây khi khởi chạy
            tvDepartments.ExpandAll();
        }

        // 1. Cấu hình các cột cho ListView ở chế độ Details
        private void SetupListView()
        {
            lsvEmployees.View = View.Details;
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;

            lsvEmployees.Columns.Clear();
            lsvEmployees.Columns.Add("Mã NV", 100);
            lsvEmployees.Columns.Add("Họ Tên", 180);
            lsvEmployees.Columns.Add("Chức vụ", 150);
            lsvEmployees.Columns.Add("Ngày vào làm", 120);
        }

        // Cấu hình danh sách các chế độ xem cho ComboBox
        private void SetupComboBox()
        {
            cboView.Items.Clear();
            cboView.Items.AddRange(new string[] { "Details", "LargeIcon", "SmallIcon", "List", "Tile" });
            cboView.SelectedIndex = 0; // Mặc định chọn Details
        }

        // 2. Dựng cấu trúc cây dữ liệu mẫu cho TreeView (Công ty -> Phòng ban -> Nhóm)
        private void SetupTreeView()
        {
            tvDepartments.Nodes.Clear();

            TreeNode rootNode = new TreeNode("Công ty ABC") { Tag = "CongTy" };

            TreeNode techNode = new TreeNode("Phòng Kỹ thuật") { Tag = "KyThuat" };
            techNode.Nodes.Add(new TreeNode("Nhóm Web") { Tag = "Web" });
            techNode.Nodes.Add(new TreeNode("Nhóm Mobile") { Tag = "Mobile" });

            TreeNode salesNode = new TreeNode("Phòng Kinh doanh") { Tag = "KinhDoanh" };
            salesNode.Nodes.Add(new TreeNode("Nhóm Bán hàng") { Tag = "BanHang" });
            salesNode.Nodes.Add(new TreeNode("Nhóm Marketing") { Tag = "Marketing" });

            TreeNode hrNode = new TreeNode("Phòng Nhân sự") { Tag = "NhanSu" };

            rootNode.Nodes.Add(techNode);
            rootNode.Nodes.Add(salesNode);
            rootNode.Nodes.Add(hrNode);

            tvDepartments.Nodes.Add(rootNode);
        }

        // Dữ liệu mẫu danh sách nhân viên
        private void InitData()
        {
            _allEmployees = new List<Employee>
            {
                new Employee { EmployeeId = "NV01", FullName = "Nguyễn Văn A", Position = "Trưởng phòng Kỹ thuật", StartDate = new DateTime(2020, 1, 15), DepartmentTag = "KyThuat" },
                new Employee { EmployeeId = "NV02", FullName = "Trần Thị B", Position = "Lập trình viên Web", StartDate = new DateTime(2021, 3, 10), DepartmentTag = "Web" },
                new Employee { EmployeeId = "NV03", FullName = "Lê Văn C", Position = "Lập trình viên Mobile", StartDate = new DateTime(2022, 5, 20), DepartmentTag = "Mobile" },
                new Employee { EmployeeId = "NV04", FullName = "Phạm Thị D", Position = "Trưởng phòng Kinh doanh", StartDate = new DateTime(2019, 8, 12), DepartmentTag = "KinhDoanh" },
                new Employee { EmployeeId = "NV05", FullName = "Hoàng Văn E", Position = "Nhân viên Bán hàng", StartDate = new DateTime(2023, 2, 1), DepartmentTag = "BanHang" },
                new Employee { EmployeeId = "NV06", FullName = "Vũ Thị F", Position = "Chuyên viên Marketing", StartDate = new DateTime(2022, 11, 15), DepartmentTag = "Marketing" },
                new Employee { EmployeeId = "NV07", FullName = "Đặng Văn G", Position = "Trưởng phòng HR", StartDate = new DateTime(2018, 4, 25), DepartmentTag = "NhanSu" }
            };
        }

        // 3. Xử lý sự kiện click chọn Node trên TreeView -> Lọc danh sách nạp vào ListView
        private void TvDepartments_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            string selectedTag = e.Node.Tag?.ToString() ?? "";
            LoadEmployeesToListView(selectedTag);
        }

        private void LoadEmployeesToListView(string deptTag)
        {
            lsvEmployees.Items.Clear();

            List<Employee> filteredList;
            if (deptTag == "CongTy" || string.IsNullOrEmpty(deptTag))
            {
                filteredList = _allEmployees;
            }
            else if (deptTag == "KyThuat")
            {
                filteredList = _allEmployees.Where(emp => emp.DepartmentTag == "KyThuat" || emp.DepartmentTag == "Web" || emp.DepartmentTag == "Mobile").ToList();
            }
            else if (deptTag == "KinhDoanh")
            {
                filteredList = _allEmployees.Where(emp => emp.DepartmentTag == "KinhDoanh" || emp.DepartmentTag == "BanHang" || emp.DepartmentTag == "Marketing").ToList();
            }
            else
            {
                filteredList = _allEmployees.Where(emp => emp.DepartmentTag == deptTag).ToList();
            }

            foreach (var emp in filteredList)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId);
                item.SubItems.Add(emp.FullName);
                item.SubItems.Add(emp.Position);
                item.SubItems.Add(emp.StartDate.ToString("dd/MM/yyyy"));
                lsvEmployees.Items.Add(item);
            }
        }

        // 4. Xử lý đổi chế độ hiển thị ListView qua ComboBox
        private void CboView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboView.SelectedItem == null) return;

            string selectedView = cboView.SelectedItem.ToString() ?? "Details";
            switch (selectedView)
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
    }

    // Lớp đối tượng Employee (Nhân viên)
    public class Employee
    {
        public string EmployeeId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string DepartmentTag { get; set; } = string.Empty;
    }
}