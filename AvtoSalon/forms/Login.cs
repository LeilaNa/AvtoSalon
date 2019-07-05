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
using AvtoSalon.forms;

namespace AvtoSalon.forms
{
    public partial class Login : Form
    {
        AutoSalonEntities db;
        public Login()
        {
            InitializeComponent();
            db = new AutoSalonEntities();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            Admin admin = db.Admins.FirstOrDefault();
            User user = db.Users.FirstOrDefault();
        }
        public void btnLogin_Click(object sender, EventArgs e)
        {
            string Password = txtPassword.Text;
            string Name = txtName.Text;
            if (rdbAdmin.Checked)
            {
                Admin LoggedAdmin = db.Admins.Where(a => a.Name == Name).FirstOrDefault();
                if (Extension.checkPassword(Password, LoggedAdmin.Password))
                {
                    AdminPage adm = new AdminPage();
                    adm.Show();
                    MessageBox.Show(" You are succesfully logged in");
                }
                else if (LoggedAdmin.Name == Name && LoggedAdmin.Password != Password)
                {
                    MessageBox.Show("Your Password is incorrect", "Error");
                }
                else if (LoggedAdmin.Name != Name)
                {
                    MessageBox.Show("This Admin not found", "Error");
                }
            }

            if (rdbUser.Checked)
            {
                User LoggedUser = db.Users.Where(u => u.Email == Name).FirstOrDefault();
                if (Extension.checkPassword(Password, LoggedUser.Password))
                {
                    UserPage adm = new UserPage();
                    adm.Show();
                    MessageBox.Show("You are succesfully logged in");
                }
                else if (LoggedUser.Email == Name && LoggedUser.Password != Password)
                {
                    MessageBox.Show("Your Password is incorrect", "Error");
                }
                else if (LoggedUser.Email != Name)
                {
                    MessageBox.Show("This Admin not found", "Error");
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
