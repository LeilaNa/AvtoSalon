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
    public partial class MyOrders : Form
    {
        AutoSalonEntities db;
        public MyOrders()
        {
            InitializeComponent();
            db = new AutoSalonEntities();
        }

        public void UpdateDatagrid()
        {
            dgvMyOrders.DataSource = db.Cars.Where(c => c.Ordered == true).Select(c => new
            {
                c.Id,
                Model = c.Name,
                Brand = c.Brand.Name,
                c.Fueltype,
                c.EnginePower,
                c.Year,
            }).ToList();
            dgvMyOrders.Columns[0].Visible = false;
        }
        private void MyOrders_Load(object sender, EventArgs e)
        {
            UpdateDatagrid();
        }
    }
}
