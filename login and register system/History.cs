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
    public partial class History : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public History()
        {
            InitializeComponent();
        }

        public string txtofhis; //ใช้รับค่าจากform2
        private void History_Load(object sender, EventArgs e)
        {
            label1.Text = txtofhis;
            Getinfor();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Home h = new Home();
            //h.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            h.labelofHome = label1.Text;
            h.ShowDialog();
        }
        void otherForm_FormClosed(object sender, FormClosedEventArgs e)

        {
            this.Show();
        }

        private void Getinfor()
        {
            DataSet ds = new DataSet();
            //เคลียร์ข้อมูลเก่า
            if (ds.Tables.Contains("dttbl_infor"))
                ds.Tables.Remove("dttbl_infor");

            //เรียกdata in SqlServer to Gridview
            string sql = "SELECT * FROM tbl_infor WHERE Username= '" + label1.Text + "'";
            MySqlConnection conn = databaseConnection();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(ds, "dttbl_infor");
            dgv3.DataSource = ds.Tables["dttbl_infor"];
        }


        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv3.CurrentRow.Selected = true;
                textBox1.Text = dgv3.Rows[e.RowIndex].Cells["myOrder"].FormattedValue.ToString();
                textBox9.Text = dgv3.Rows[e.RowIndex].Cells["Deli_date"].FormattedValue.ToString();
                textBox10.Text = dgv3.Rows[e.RowIndex].Cells["Deli_time"].FormattedValue.ToString();
                textBox3.Text = dgv3.Rows[e.RowIndex].Cells["FLname"].FormattedValue.ToString();
                textBox5.Text = dgv3.Rows[e.RowIndex].Cells["Phone1"].FormattedValue.ToString();
                textBox4.Text = dgv3.Rows[e.RowIndex].Cells["FLname_Deli"].FormattedValue.ToString();
                textBox6.Text = dgv3.Rows[e.RowIndex].Cells["Phone2"].FormattedValue.ToString();
                textBox7.Text = dgv3.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                textBox8.Text = dgv3.Rows[e.RowIndex].Cells["ZipCode"].FormattedValue.ToString();
                textBox11.Text = dgv3.Rows[e.RowIndex].Cells["buyD"].FormattedValue.ToString();
                txtBox1.Text = dgv3.Rows[e.RowIndex].Cells["status"].FormattedValue.ToString();
                textBox2.Text = dgv3.Rows[e.RowIndex].Cells["total"].FormattedValue.ToString();

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
