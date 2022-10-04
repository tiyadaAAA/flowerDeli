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

    public partial class Admin2 : Form
    {
        public Admin2()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void showProduct()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from tbl_product";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dgv2.DataSource = ds.Tables[0].DefaultView;
        }

        private void Admin2_Load(object sender, EventArgs e)
        {
            showProduct();
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv2.CurrentRow.Selected = true;
                textBox1.Text = dgv2.Rows[e.RowIndex].Cells["nameProduct"].FormattedValue.ToString();
                textBox2.Text = dgv2.Rows[e.RowIndex].Cells["qtyItem"].FormattedValue.ToString();
                textBox3.Text = dgv2.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();

                string name = dgv2.Rows[e.RowIndex].Cells["codeProduct"].Value.ToString();
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `tbl_product` WHERE codeProduct = '{name}'", conn);
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
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("ต้องการบันทึกใช่หรือไม่?", "คำเตือน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    byte[] imagess = null;
                    FileStream Streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(Streem);
                    imagess = brs.ReadBytes((int)Streem.Length);

                    MySqlConnection conn = databaseConnection();

                    string sql = "insert into tbl_product (nameProduct, qtyItem, 	price,images ) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',@images)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add(new MySqlParameter("@images", imagess));
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                        showProduct();

                    }
                        
                 }
                catch {
                    MessageBox.Show("กรุณาเพิ่มรูปภาพ", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("ต้องการแก้ใช่หรือไม่?", "คำเตือน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {

                    int selectedRow = dgv2.CurrentCell.RowIndex;
                    int editCodePD = Convert.ToInt32(dgv2.Rows[selectedRow].Cells["CodeProduct"].Value);
                    MySqlConnection conn = databaseConnection();

                    string sql = "update tbl_product set nameProduct = '" + textBox1.Text + "',qtyItem = '" + textBox2.Text + "',price = '" + textBox3.Text + "' where CodeProduct ='" + editCodePD + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                        showProduct();
                    }
                }
                catch { }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = databaseConnection();
            connection.Open();
            MySqlCommand cnd;
            cnd = connection.CreateCommand();
            //string SearchData = txtSearch.Text;
            cnd.CommandText = "select * from tbl_product where nameProduct LIKE '%" + textBox4.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cnd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            MySqlDataReader reader = cnd.ExecuteReader();
            dgv2.DataSource = ds.Tables[0].DefaultView;
            if (reader.Read() == true)
            {

                connection.Close();

            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
            }
        }

        //Refresh
        private void button1_Click(object sender, EventArgs e)
        {
            showProduct();
            textBox4.Clear();
        }

        //addpic
        string imgLocation = "";
        private void label6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("ต้องการลบใช่หรือไม่?", "คำเตือน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int selectedRow = dgv2.CurrentCell.RowIndex;
                int editCodePD = Convert.ToInt32(dgv2.Rows[selectedRow].Cells["CodeProduct"].Value);
                MySqlConnection conn = databaseConnection();
                string sql = "delete from tbl_product where CodeProduct ='" + editCodePD + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("ลบข้อมูลสำเร็จ");
                    showProduct();
                }
            }
        }
    }
    }

