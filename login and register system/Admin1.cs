using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace login_and_register_system
{
    public partial class Admin1 : Form
    {
        public Admin1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            //Environment.Exit(0);
        }
        private Form activeForm = null;
        private void openChildForm(Form chilForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(chilForm);
            panel2.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();

        }

        private void btnAdmin2_Click(object sender, EventArgs e)
        {
            openChildForm(new Admin2());
        }

        private void btnAdmin3_Click(object sender, EventArgs e)
        {
            openChildForm(new Admin3());
        }

        private void Admin1_Load(object sender, EventArgs e)
        {
        }
    }
}
