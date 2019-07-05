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
    public partial class CarAdmin : Form
    {
        AutoSalonEntities db;
        Car SelectedCar;
        public CarAdmin()
        {
            InitializeComponent();
            db = new AutoSalonEntities();

        }

        private void CarAdmin_Load(object sender, EventArgs e)
        {
            UpdateDatagrid();
            cmbBrand.DataSource = db.Brands.Select(b => new ComboItem
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();

            List<int> Year = new List<int>();

            for (int i = 1900; i < DateTime.Now.Year; i++)
            {
                Year.Add(i);
            }
            cmbYear.DataSource = Year;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void UpdateDatagrid()
        {
            dgvCars.DataSource = db.Cars.Select(c => new
            {
                c.Id,
                Model = c.Name,
                Brand = c.Brand.Name,
                c.Fueltype,
                c.EnginePower,
                c.Year,
                c.Ordered

            }).ToList();
            dgvCars.Columns[0].Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            string Carname = txtCarName.Text;
            ComboItem Brandname = cmbBrand.SelectedItem as ComboItem;
            int year = (int)cmbYear.SelectedItem;
            string EnginePower = txtengine.Text;
            string Fueltype = txtFuelType.Text;
            bool order = chbOrdered.ThreeState;

            Car newcar = new Car()
            {
                Name = Carname,
                BrandId = Brandname.Id,
                Year = year,
                EnginePower = EnginePower,
                Fueltype = Fueltype,
                Ordered = order
            };

            if (Carname != null && EnginePower != null && Fueltype != null && Carname != "" && EnginePower != "" && Fueltype != "")
            {
                db.Cars.Add(newcar);
            }
            else if (Carname == null || Carname == "")
            {
                
                MessageBox.Show("You are not include Car name");
            }
            else if (EnginePower == null || EnginePower == "")
            {
                MessageBox.Show("You are not include Engine Power");
            }

            else if (Fueltype == null || Fueltype == "")
            {
                MessageBox.Show("You are not include Fuel type");
            }
            UpdateDatagrid();
            db.SaveChanges();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Carname = txtCarName.Text;
            ComboItem Brandname = cmbBrand.SelectedItem as ComboItem;
            int year = (int)cmbYear.SelectedItem;
            string EnginePower = txtengine.Text;
            string Fueltype = txtFuelType.Text;
            bool order = chbOrdered.ThreeState;
            SelectedCar.Name = Carname;
            SelectedCar.BrandId = Brandname.Id;
            SelectedCar.Year = year;
            SelectedCar.EnginePower = EnginePower;
            SelectedCar.Fueltype = Fueltype;
            SelectedCar.Ordered = order;
            UpdateDatagrid();`
            db.SaveChanges();
        }

        private void dgvCars_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            int ID = (int)dgvCars.Rows[e.RowIndex].Cells[0].Value;
            SelectedCar = db.Cars.Where(b => b.Id == ID).FirstOrDefault();
            txtCarName.Text = SelectedCar.Name;
            txtFuelType.Text = SelectedCar.Fueltype;
            txtengine.Text = SelectedCar.EnginePower;
            cmbBrand.SelectedItem = SelectedCar.Brand;
            cmbYear.SelectedItem = SelectedCar.Year;
            btnCreate.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           DialogResult res = MessageBox.Show("Do you want to remove this Car ?", "Delete", MessageBoxButtons.YesNo);
            if (res==DialogResult.Yes)
            {
                db.Cars.Remove(SelectedCar);
                db.SaveChanges();
                UpdateDatagrid();
                ClearTextbox();
            }
           
        }

        public void ClearTextbox()
        {
            txtCarName.Text = "";
            txtFuelType.Text = "";
            txtengine.Text = "";
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
