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
    public partial class FrmLogin : Form
    {
        //public static FrmLogin instance;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public FrmLogin() 
        {
            InitializeComponent();
            //instance = this;
        }

        public string txtofLogin;
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            label1.Text = txtofLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = databaseConnection();
            String login = "SELECT * FROM tbl_login WHERE Username= '" + txtUsername.Text + "'and Password= '" + txtPassword.Text + "'";
            MySqlCommand cmd = new MySqlCommand(login, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (txtUsername.Text == "admin" && txtPassword.Text == "1234567")
            {
                Admin1 a = new Admin1();
                this.Hide();
                a.ShowDialog();
            }
            else 
            {
                //check if user and pass in table
                if (dr.Read() == true)
                {
                    Home h = new Home();
                    h.labelofHome = txtUsername.Text;
                    //new Home().ShowDialog();
                    // Home.instance.label1.Text = txtUsername.Text;
                    this.Hide();
                    h.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password,Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                }
            }
        }
//clear txetbox
        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
        //sign up
        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar})> 1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
      
    }
}
