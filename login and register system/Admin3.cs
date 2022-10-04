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
using System.IO;

namespace login_and_register_system
{

    public partial class Admin3 : Form
    {
        public Admin3()
        {
            InitializeComponent();
        }


        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }



        private void showOrder()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from tbl_infor";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dgv3.DataSource = ds.Tables[0].DefaultView;
        } 

        private void Admin3_Load(object sender, EventArgs e)
        {
            showOrder();
        }

        //edit status
            private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("ต้องการแก้ไขใช่หรือไม่?", "คำเตือน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int selectedRow = dgv3.CurrentCell.RowIndex;
                int editCodePD = Convert.ToInt32(dgv3.Rows[selectedRow].Cells["orderNum"].Value);
                MySqlConnection conn = databaseConnection();
                string sql = "update tbl_infor set status = '" + comboBox1.Text + "' where orderNum ='" + editCodePD + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                    showOrder();
                }
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string fromDateStringISO = Convert.ToDateTime(dateTimePicker1.Value).ToString("dd-MM-yyyy");
                string toDateStringISO = Convert.ToDateTime(dateTimePicker2.Value).ToString("dd-MM-yyyy");

                MySqlConnection connection = databaseConnection();
                connection.Open();
                MySqlCommand cmd;
                cmd = connection.CreateCommand();

                cmd.CommandText = "select * from tbl_infor where buyD BETWEEN '" + fromDateStringISO + "' and '" + toDateStringISO + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    dgv3.DataSource = ds.Tables[0].DefaultView;
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connection.Close();
                }
            }
            catch { }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            showOrder();
        }

        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv3.CurrentRow.Selected = true;
                comboBox1.Text = dgv3.Rows[e.RowIndex].Cells["status"].FormattedValue.ToString();
                textBox6.Text = dgv3.Rows[e.RowIndex].Cells["myOrder"].FormattedValue.ToString();
                textBox2.Text = dgv3.Rows[e.RowIndex].Cells["total"].FormattedValue.ToString();
                textBox9.Text = dgv3.Rows[e.RowIndex].Cells["Deli_date"].FormattedValue.ToString();
                textBox10.Text = dgv3.Rows[e.RowIndex].Cells["Deli_time"].FormattedValue.ToString();
                textBox3.Text = dgv3.Rows[e.RowIndex].Cells["FLname"].FormattedValue.ToString();
                textBox5.Text = dgv3.Rows[e.RowIndex].Cells["Phone1"].FormattedValue.ToString();
                textBox1.Text = dgv3.Rows[e.RowIndex].Cells["FLname_Deli"].FormattedValue.ToString();
                textBox11.Text = dgv3.Rows[e.RowIndex].Cells["Phone2"].FormattedValue.ToString();
                textBox7.Text = dgv3.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                textBox8.Text = dgv3.Rows[e.RowIndex].Cells["ZipCode"].FormattedValue.ToString();

                string name = dgv3.Rows[e.RowIndex].Cells["orderNum"].Value.ToString();
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `tbl_infor` WHERE orderNum  = '{name}'", conn);
                DataTable dt = new DataTable();
                var ap = new MySqlDataAdapter(cmd);
                ap.Fill(dt);

                byte[] img = (byte[])dt.Rows[0]["images"];
                var ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
                ap.Dispose();
            }
            catch { }
        }
    }
}
