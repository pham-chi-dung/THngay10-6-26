using System;
using System.Windows.Forms;

namespace bai51
{
    public partial class Form1 : Form
    {
        // Khai báo ErrorProvider theo yêu cầu bài toán
        private ErrorProvider epCheck;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Cài đặt thuộc tính ẩn mật khẩu
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            // Khởi tạo ErrorProvider
            epCheck = new ErrorProvider();
            epCheck.BlinkStyle = ErrorBlinkStyle.NeverBlink; // Tùy chọn không nhấp nháy liên tục

            // Gắn sự kiện cho các nút bấm
            btnRegister.Click += BtnRegister_Click;
            btnReset.Click += BtnReset_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ cảnh báo lỗi cũ trước khi kiểm tra lại
            epCheck.Clear();
            bool isValid = true;

            // 1. Kiểm tra Tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                epCheck.SetError(txtUsername, "Tên đăng nhập không được để trống!");
                isValid = false;
            }

            // 2. Kiểm tra Mật khẩu
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                epCheck.SetError(txtPassword, "Mật khẩu không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Xác nhận mật khẩu
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                epCheck.SetError(txtConfirmPassword, "Mật khẩu nhập lại không khớp!");
                isValid = false;
            }

            // 4. Kiểm tra độ tuổi (>= 18 tuổi)
            DateTime today = DateTime.Today;
            int age = today.Year - dtpDateOfBirth.Value.Year;
            // Trừ đi 1 tuổi nếu chưa đến sinh nhật trong năm nay
            if (dtpDateOfBirth.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age < 18)
            {
                epCheck.SetError(dtpDateOfBirth, "Bạn phải đủ 18 tuổi trở lên!");
                isValid = false;
            }

            // 5. Kiểm tra đồng ý điều khoản
            if (!chkTerms.Checked)
            {
                epCheck.SetError(chkTerms, "Bạn phải đồng ý với Điều khoản dịch vụ!");
                isValid = false;
            }

            // 6. Nếu tất cả đều hợp lệ
            if (isValid)
            {
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu các ô nhập liệu
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            // Đưa ngày sinh về thời điểm hiện tại
            dtpDateOfBirth.Value = DateTime.Now;

            // Đặt lại các lựa chọn
            if (radMale != null) radMale.Checked = true;
            chkTerms.Checked = false;

            // Xóa toàn bộ thông báo lỗi
            epCheck.Clear();

            // Đưa con trỏ chuột về ô đầu tiên
            txtUsername.Focus();
        }
    }
}