using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bai52
{
    // Lớp mô tả Dịch vụ để lưu trữ thông tin và hiển thị lên ListBox
    public class ServiceItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        // Định dạng cách hiển thị từng dòng trên ListBox
        public override string ToString()
        {
            return $"{Name} - {Price:N0} đ";
        }
    }

    public partial class Form1 : Form
    {
        // Danh sách toàn bộ dịch vụ mẫu của phòng khám
        private List<ServiceItem> _allServices;

        public Form1()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load Form
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();

            // Load danh sách danh mục vào ComboBox
            cboCategory.Items.AddRange(new string[] { "Khám bệnh", "Xét nghiệm", "Chụp X-Quang", "Vắc-xin" });

            // Đăng ký các sự kiện tương tác
            cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged;
            btnSelect.Click += BtnSelect_Click;
            btnRemove.Click += BtnRemove_Click;
            btnClearAll.Click += BtnClearAll_Click;

            // Yêu cầu: Double Click vào item ở lstAvailableServices thì chuyển sang lstSelectedServices[cite: 5]
            lstAvailableServices.DoubleClick += BtnSelect_Click;

            // Xử lý khi thay đổi % giảm giá thì tính lại tiền
            if (this.Controls.Find("txtDiscount", true).FirstOrDefault() is TextBox txtDiscount)
            {
                txtDiscount.TextChanged += (s, ev) => CalculateTotal();
                txtDiscount.Text = "0"; // Gán mặc định là 0%
            }

            // Chọn mặc định mục đầu tiên, kích hoạt tự động load lstAvailableServices[cite: 5]
            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
        }

        // Tạo dữ liệu mẫu
        private void InitData()
        {
            _allServices = new List<ServiceItem>
            {
                new ServiceItem { Name = "Khám nội chung", Category = "Khám bệnh", Price = 150000 },
                new ServiceItem { Name = "Khám chuyên khoa", Category = "Khám bệnh", Price = 250000 },
                new ServiceItem { Name = "Xét nghiệm máu cơ bản", Category = "Xét nghiệm", Price = 300000 },
                new ServiceItem { Name = "Xét nghiệm sinh hóa", Category = "Xét nghiệm", Price = 450000 },
                new ServiceItem { Name = "Chụp X-Quang phổi", Category = "Chụp X-Quang", Price = 200000 },
                new ServiceItem { Name = "Chụp X-Quang xương", Category = "Chụp X-Quang", Price = 250000 },
                new ServiceItem { Name = "Vắc-xin cúm", Category = "Vắc-xin", Price = 350000 },
                new ServiceItem { Name = "Vắc-xin dại", Category = "Vắc-xin", Price = 500000 }
            };
        }

        // Yêu cầu 1: Load danh sách dịch vụ tương ứng khi thay đổi ComboBox[cite: 5]
        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();
            if (cboCategory.SelectedItem == null) return;

            string selectedCategory = cboCategory.SelectedItem.ToString();

            var filteredServices = _allServices.Where(s => s.Category == selectedCategory).ToList();
            foreach (var service in filteredServices)
            {
                lstAvailableServices.Items.Add(service);
            }
        }

        // Yêu cầu 2: Chuyển item sang danh sách đã chọn[cite: 5]
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                // Lấy đối tượng đang chọn
                ServiceItem selectedService = (ServiceItem)lstAvailableServices.SelectedItem;

                // Tránh thêm trùng lặp (tùy chọn)
                if (!lstSelectedServices.Items.Contains(selectedService))
                {
                    lstSelectedServices.Items.Add(selectedService);
                    CalculateTotal(); // Cập nhật lại tổng tiền[cite: 5]
                }
            }
        }

        // Chức năng nút <
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Remove(lstSelectedServices.SelectedItem);
                CalculateTotal(); // Cập nhật lại tổng tiền[cite: 5]
            }
        }

        // Chức năng nút <<
        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            lstSelectedServices.Items.Clear();
            CalculateTotal(); // Cập nhật lại tổng tiền[cite: 5]
        }

        // Yêu cầu 3: Tự động tính tổng chi phí dựa trên lstSelectedServices[cite: 5]
        private void CalculateTotal()
        {
            decimal subTotal = 0;

            // Tính tổng tiền các dịch vụ đã chọn
            foreach (ServiceItem item in lstSelectedServices.Items)
            {
                subTotal += item.Price;
            }

            // Lấy Tỷ lệ chiết khấu
            decimal discountRate = 0;
            TextBox txtDiscount = this.Controls.Find("txtDiscount", true).FirstOrDefault() as TextBox;
            if (txtDiscount != null && decimal.TryParse(txtDiscount.Text, out decimal rate))
            {
                discountRate = rate;
            }

            // Tính toán
            decimal discountAmount = subTotal * (discountRate / 100);
            decimal total = subTotal - discountAmount;

            // Hiển thị ra UI
            TextBox txtSubTotal = this.Controls.Find("txtSubTotal", true).FirstOrDefault() as TextBox;
            TextBox txtTotal = this.Controls.Find("txtTotal", true).FirstOrDefault() as TextBox;

            if (txtSubTotal != null) txtSubTotal.Text = subTotal.ToString("N0") + " đ";
            if (txtTotal != null) txtTotal.Text = total.ToString("N0") + " đ";
        }
    }
}