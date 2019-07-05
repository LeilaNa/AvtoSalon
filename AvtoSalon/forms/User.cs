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
    public partial class UserPage : Form
    {
        AutoSalonEntities db;
        Car SelectedCar;
        public UserPage()
        {
            InitializeComponent();
            db = new AutoSalonEntities();
        }
        public void UpdateDatagrid()
        {
            dgvCars.DataSource = db.Cars.Where(c=>c.Ordered==false).Select(c => new
            {
                c.Id,
                Model = c.Name,
                Brand = c.Brand.Name,
                c.Fueltype,
                c.EnginePower,
                c.Year,
            }).ToList();
            dgvCars.Columns[0].Visible = false;
        }

        private void dgvCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            UpdateDatagrid();
            btnOrder.Enabled = false;
        }

        private void dgvCars_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ID = (int)dgvCars.Rows[e.RowIndex].Cells[0].Value;
            SelectedCar = db.Cars.Where(b => b.Id == ID).FirstOrDefault();
            btnOrder.Enabled= true;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SelectedCar.Ordered = true;
            MessageBox.Show("You are succesfully ordered this Car");
            UpdateDatagrid();
            db.SaveChanges();
        }

        private void myOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyOrders orders = new MyOrders();
            orders.Show();
            this.IsMdiContainer = true;
            orders.MdiParent = this;
            orders.TopLevel = false;
            orders.Show();
            orders.FormBorderStyle = FormBorderStyle.None;
            dgvCars.Hide();
            btnOrder.Hide();
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserPage us = new UserPage();
            us.Show();
        }
    }
}
