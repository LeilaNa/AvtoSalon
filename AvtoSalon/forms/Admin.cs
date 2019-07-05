using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvtoSalon.forms
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {

        }
        BrandAdmin Brands = new BrandAdmin();
        CarAdmin Cars = new CarAdmin();
        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brands.Show();
            Cars.Hide();
                this.IsMdiContainer = true;
                Brands.MdiParent = this;
                Brands.TopLevel = false;
                Brands.Show();
                Brands.FormBorderStyle= FormBorderStyle.None;
            
        }

        private void carToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cars.Show();
            Brands.Hide();
            this.IsMdiContainer = true;
            Cars.MdiParent = this;
            Cars.TopLevel = false;
            Cars.Show();
            Cars.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
