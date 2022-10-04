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
    public partial class frmRegister : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public frmRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (txtUsename.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username or Password fields are empty","Registration Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (txtPassword.Text == txtComPassword.Text && txtPassword.Text.Trim().Length != 0)
                {
                    if (txtPassword.Text.Trim().Length > 6 && txtComPassword.Text.Trim().Length > 6)
                    {

                        if (txtUsename.Text != "" && txtPassword.Text != "" && txtComPassword.Text != "" || txtPassword.Text == txtComPassword.Text && txtPassword.Text.Trim().Length != 0 || txtPassword.Text.Trim().Length > 6 && txtComPassword.Text.Trim().Length > 6)
                        {
                            String register = $"select * from tbl_login where Username = '{ txtUsename.Text}'";
                            MySqlCommand cmd = new MySqlCommand(register, conn);
                            DataTable dt = new DataTable();
                            new MySqlDataAdapter(cmd).Fill(dt);
                            

                            if (dt.Rows.Count < 1)
                            {
                                String register1 = "INSERT INTO tbl_login (Username , Password) VALUES('" + txtUsename.Text + "','" + txtPassword.Text + "')";
                                MySqlCommand cmd1 = new MySqlCommand(register1, conn);
                                conn.Open();
                                cmd1.ExecuteNonQuery();
                                conn.Close();

                                txtUsename.Text = "";
                                txtPassword.Text = "";
                                txtComPassword.Text = "";

                                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Username มีผู้ใช้แล้ว", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUsename.Text = "";
                                txtPassword.Text = "";
                                txtComPassword.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Text = "";
                            txtComPassword.Text = "";
                            txtPassword.Focus();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Password too weak ( > 6 character)", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Passwords doesn't match,Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtComPassword.Text = "";
                    txtPassword.Focus();
                }
            }

        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }
//clear
        private void button2_Click(object sender, EventArgs e)
        {
            txtUsename.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsename.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void txtUsename_KeyPress(object sender, KeyPressEventArgs e) //allow digit + char
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
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtComPassword_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}