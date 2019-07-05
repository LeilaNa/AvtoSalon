using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvtoSalon.Models;

namespace AvtoSalon.forms
{
    public partial class BrandAdmin : Form
    {
        AutoSalonEntities db;
        Brand SelectedBrand;

        public BrandAdmin()
        {
            InitializeComponent();
            db = new AutoSalonEntities();
        }

        private void BrandAdmin_Load(object sender, EventArgs e)
        {
            UpdateDatagrid();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void UpdateDatagrid()
        {

            dgvBrands.DataSource = db.Brands.Select(b => new
            {
                b.Id,
                b.Name
            }).ToList();
            dgvBrands.Columns[0].Visible = false;
        }
      

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string BrandName = txtBrandName.Text;
            Brand NewBrand = new Brand()
            {
                Name = BrandName
            };
            db.Brands.Add(NewBrand);
            UpdateDatagrid();
            db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Newbr = txtBrandName.Text;
             SelectedBrand.Name=Newbr;
            UpdateDatagrid();
            db.SaveChanges();
        }

        private void dgvBrands_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ID = (int)dgvBrands.Rows[e.RowIndex].Cells[0].Value;
            SelectedBrand = db.Brands.Where(b => b.Id == ID).FirstOrDefault();
            txtBrandName.Text = SelectedBrand.Name;
            btnCreate.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            db.Brands.Remove(SelectedBrand);
            db.SaveChanges();
            UpdateDatagrid();

        }
    }
}
