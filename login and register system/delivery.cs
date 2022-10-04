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
    
    public partial class delivery : Form
    {
       
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public delivery()
        {
            InitializeComponent();
        }
        //Name
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text== "Name Lastname | ชื่อ สกุล")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
            
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Name Lastname | ชื่อ สกุล";
                textBox1.ForeColor = Color.DarkGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Phone Number | เบอร์โทรศัพท์")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Phone Number | เบอร์โทรศัพท์";
                textBox2.ForeColor = Color.DarkGray;
            }
        
        }


        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Name Lastname | ชื่อ สกุล")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Name Lastname | ชื่อ สกุล";
                textBox6.ForeColor = Color.DarkGray;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Phone Number | เบอร์โทรศัพท์")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Phone Number | เบอร์โทรศัพท์";
                textBox5.ForeColor = Color.DarkGray;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "Shipping address | ที่อยู่ในการจัดส่ง")
            {
                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Shipping address | ที่อยู่ในการจัดส่ง";
                textBox8.ForeColor = Color.DarkGray;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "ZIP code | รหัสไปรษณีย์")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "ZIP code | รหัสไปรษณีย์";
                textBox7.ForeColor = Color.DarkGray;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "Card Message(If) | การ์ดข้อความ(ถ้ามี)")
            {
                textBox9.Text = "";
                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "Card Message(If) | การ์ดข้อความ(ถ้ามี)";
                textBox9.ForeColor = Color.DarkGray;
            }
        }

        private void showCart()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from tbl_cart";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dgv2.DataSource = ds.Tables[0].DefaultView;
        }

        private void order_list()
        {
            listBox1.Items.Clear();
            int n = 0;
            MySqlConnection connection = databaseConnection();
            connection.Open();
            MySqlCommand cmd;
            cmd = connection.CreateCommand();
            cmd.CommandText = "select * from tbl_cart ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add("สินค้า " + dt.Rows[n][2].ToString() + "\tจำนวน " + dt.Rows[n][3].ToString() + "\tราคา " + dt.Rows[n][4].ToString());
                n++;
            }
            reader.Close();
            connection.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            order_list();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object item in listBox1.Items)
            {
                sb.Append(item.ToString());
                sb.Append("\n");
            }

            DialogResult dr = MessageBox.Show("ต้องการบันทึกใช่หรือไม่", "คำเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (textBox1.Text == "Name Lastname | ชื่อ สกุล" || textBox2.Text == "Phone Number | เบอร์โทรศัพท์" || textBox6.Text == "Name Lastname | ชื่อ สกุล" || textBox5.Text == "Phone Number | เบอร์โทรศัพท์" || textBox8.Text == "Shipping address | ที่อยู่ในการจัดส่ง" || textBox7.Text == "ZIP code | รหัสไปรษณีย์")
                    {
                        MessageBox.Show("Please fill up this form", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MySqlConnection conn = databaseConnection();
                        String inforr = "INSERT INTO tbl_infor (status ,Username ,myOrder ,total ,FLname , Phone1, FLname_Deli, Phone2, Deli_date, Deli_time, Address, ZipCode, 	Province, Card, buyD ) VALUES('pending','" + label7.Text + "','" + sb.ToString() + "','" + label10.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + this.dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','" + comboBox1.Text + "','" + textBox8.Text + "','" + textBox7.Text + "',' Roi Et ','" + textBox9.Text + "','" + this.dateTimePicker1.Value.ToString("dd-MM-yyyy") + "')";
                        MySqlCommand cmd = new MySqlCommand(inforr, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox6.Text = "";
                        textBox5.Text = "";
                        textBox8.Text = "";
                        textBox7.Text = "";
                       
                        this.Close();
                    }
                }

        }

        public string txtofdeli;//ไว้ใช้รับค่ามาจากฟอร์มอื่น
        public string txtoftotal;
        private void delivery_Load(object sender, EventArgs e)
        {
            //username
            label7.Text = txtofdeli;
            //total
            label10.Text = txtoftotal;
            showCart();
        }

    }
}
