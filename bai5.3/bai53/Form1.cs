using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bai53
{
    public partial class Form1 : Form
    {
        private List<Product> _productList = new List<Product>();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            _bindingSource.DataSource = _productList;
            dgvProducts.DataSource = _bindingSource;

            if (cboCategory.Items.Count == 0)
            {
                cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Phụ kiện" });
            }

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            dgvProducts.CellClick += DgvProducts_CellClick;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text) || string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã SP và Tên SP!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product newProduct = new Product
            {
                ProductId = txtProductId.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                UnitPrice = decimal.TryParse(txtUnitPrice.Text, out decimal price) ? price : 0,
                Quantity = int.TryParse(txtQuantity.Text, out int qty) ? qty : 0,
                Category = cboCategory.SelectedItem?.ToString() ?? ""
            };

            _productList.Add(newProduct);
            _bindingSource.ResetBindings(false);
            ClearInputs();
        }

        private void DgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.CurrentRow != null)
            {
                if (dgvProducts.CurrentRow.DataBoundItem is Product selectedProduct)
                {
                    txtProductId.Text = selectedProduct.ProductId;
                    txtProductName.Text = selectedProduct.ProductName;
                    txtUnitPrice.Text = selectedProduct.UnitPrice.ToString();
                    txtQuantity.Text = selectedProduct.Quantity.ToString();
                    cboCategory.SelectedItem = selectedProduct.Category;
                }
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product selectedProduct)
            {
                selectedProduct.ProductId = txtProductId.Text.Trim();
                selectedProduct.ProductName = txtProductName.Text.Trim();
                selectedProduct.UnitPrice = decimal.TryParse(txtUnitPrice.Text, out decimal price) ? price : 0;
                selectedProduct.Quantity = int.TryParse(txtQuantity.Text, out int qty) ? qty : 0;
                selectedProduct.Category = cboCategory.SelectedItem?.ToString() ?? "";

                _bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product selectedProduct)
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa SP: {selectedProduct.ProductName}?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _productList.Remove(selectedProduct);
                    _bindingSource.ResetBindings(false);
                    ClearInputs();
                }
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                _bindingSource.DataSource = _productList;
            }
            else
            {
                var filteredList = _productList.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList();
                _bindingSource.DataSource = filteredList;
            }
            _bindingSource.ResetBindings(false);
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            txtProductId.Focus();
        }
    }

    public class Product
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}