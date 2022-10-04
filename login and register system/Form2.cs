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

    public partial class Home : Form
    {
        public static Home instance;
        public Label Showuse1;

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public Home()
        {
            InitializeComponent();
            instance = this;
            Showuse1 = label1;
        }

        private void GetProduct()
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
            dgvProduct.DataSource = ds.Tables[0].DefaultView;
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
        //ประกาศตัวแปรรอส่ง-รับค่าจากฟอร์มต่างๆ
        public string labelofHome;
        public string labelofpay;
        private void Home_Load(object sender, EventArgs e)
        {
            label1.Text = labelofHome;
            showCart();
            GetProduct();
        }
        //Order
        private void btnProducts_Click(object sender, EventArgs e)
        {
            //panel3.Show();
            //txtTotal.Show(); //อันนี้คือpanel
        }
//แจ้งชำระ
        private void btn8_Click(object sender, EventArgs e)
        {
            payment p = new payment();
            p.txtofpay = label1.Text;
            p.ShowDialog();
        }
//History
        private void btnContact_Click_1(object sender, EventArgs e)
        {
            this.Close();
            History p = new History();
            p.txtofhis = label1.Text;
            p.Show();
        }
//log out
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        //remove
        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("ต้องการลบสินค้าใช่หรือไม่?", "คำเตือน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int selectedRow = dgv2.CurrentCell.RowIndex;
                int deleteItem = Convert.ToInt32(dgv2.Rows[selectedRow].Cells["รายการ2"].Value);

                MySqlConnection conn = databaseConnection();

                String sql = "DELETE FROM tbl_cart WHERE รายการ2 = '" + deleteItem + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                showCart();
            }
        }
        //ไปที่order
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
                listBox1.Items.Add("สินค้า " + dt.Rows[n][2].ToString() + "\tจำนวน " + dt.Rows[n][3].ToString()  + "\tราคา " + dt.Rows[n][4].ToString() );
                n++;
            }
            reader.Close();
            connection.Close();
        }
        private void order()
        {
            MySqlConnection connection = databaseConnection();
            connection.Open();
            MySqlCommand cmd;
            cmd = connection.CreateCommand();
            cmd.CommandText = "select * from tbl_cart ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> firstlist = new List<string>();
            List<int> qty = new List<int>();
            while (reader.Read())
            {
                firstlist.Add(reader.GetString(2));//ชื่อสินค้า
                qty.Add(Convert.ToInt32(reader.GetString(3)));//จำนวน
            }
            reader.Close();
            connection.Close();

            for (int i = 0; i < qty.Count; i++)//ลูปจำนวนสินค้าในตะกร้า
            {

                string sql = "SELECT * FROM `tbl_product` WHERE nameProduct= '" + firstlist[i] + "'";//เอาชื่อสินค้าที่อยู่ในลิสที่เราaddเข้าไป ไปทำการค้นหาในตารางproduct
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd_ = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader_ = cmd_.ExecuteReader();
                if (reader_.Read())
                {
                    //เพื่อที่จะเอาจำนวนสิรค้าที่มีอยู่ในตารางProductมาลบกับจำนวนสินค้าในตะกร้าหรือก็คือจำนวนที่เราซื้อ
                    int ss_ss = Convert.ToInt32(reader_.GetString("qtyItem")) - Convert.ToInt32(qty[i]);
                    string sql2 = $"UPDATE `tbl_product` SET `qtyItem` = {ss_ss} WHERE `nameProduct` = '{firstlist[i]}' ";//แล้วทำการอัพเดทจำนวนเข้าไปใหม่ที่ตารางproduct
                    MySqlConnection con2 = databaseConnection();
                    MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                    con2.Open();
                    int rows2 = cmd2.ExecuteNonQuery();
                    con2.Close();

                    string sql2_ = "DELETE FROM tbl_cart";//ลบข้อมูลในตารางตะกร้าออกทั้งหมด เคลียร์ตะกร้าเพื่อรอรับออเดอร์คำสั่งซื้อใหม่
                    MySqlConnection con2_ = databaseConnection();
                    MySqlCommand cmd2_ = new MySqlCommand(sql2_, con2_);
                    con2_.Open();
                    int rows2_ = cmd2_.ExecuteNonQuery();
                    con2_.Close();


                }
            }
            showCart();
        }

        //total
        private void btnTotal_Click_1(object sender, EventArgs e)
        {
            order_list();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object item in listBox1.Items)
            {
                sb.Append(item.ToString());
                sb.Append("\n");
            }

            //total
            label2.Text = "0";
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                label2.Text = Convert.ToString(double.Parse(label2.Text) + double.Parse(dgv2.Rows[i].Cells[4].Value.ToString()));
            }


            txtResult.Clear();
            txtResult.Text += "-----------------------------------------------------------------------------------------\n";
            txtResult.Text += "-----------------------------------      Receipt     -----------------------------------\n";
            txtResult.Text += "-----------------------------------------------------------------------------------------\n";
            txtResult.Text += "Flower Mai Shop\n";
            txtResult.Text += "Date : "+DateTime.Now+"\n";
            txtResult.Text += "Username : " + label1.Text + "\n\n\n";
            txtResult.Text += "----------------------------------------------------------------------------------------\n";
            txtResult.Text += "                                                  รายการสินค้า                                  \n" +
                "----------------------------------------------------------------------------------------\n" + sb.ToString() + "\n";
            txtResult.Text += "-----------------------------------------------------------------------------------------\n\n";

            txtResult.Text += "Total : " + label2.Text + "\n\n";

            txtResult.Text += "\n                                           **  Thank You  **";
            txtResult.Text += "\n                                         Contact Us : 0933260783";

        }
        //pay

        private void btnPay_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (label2.Text == "0")//ราคารวม
                {
                    MessageBox.Show("กรุณาทำรายการสั่งซื้อ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    listBox1.Items.Clear();


                    delivery d = new delivery();//เรียนฟอร์มเดลิมาเพื่อให้โปรแกรมรู้ว่าเราจะเข้าไปเขียนโปรแกรมให้กับฟอร์มเดลิ
                    d.txtoftotal = label2.Text;
                    d.txtofdeli = label1.Text;//ส่งค่าจากlabel1ไปยังตัวแปรtxtofdeliที่อยู่ในฟอร์มdeli username
                    d.ShowDialog();
                    order();

                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
            }
            catch
            {

            }
        }


        int rakha;
        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv2.CurrentRow.Selected = true;
                //จำนวน คำนวณ
                textBox4.Text = dgv2.Rows[e.RowIndex].Cells["qty2"].FormattedValue.ToString();
                rakha = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells["cost2"].FormattedValue.ToString()) / Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells["qty2"].FormattedValue.ToString());
            }
            catch
            {

            }
            
        }


        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvProduct.CurrentRow.Selected = true;
                txtBox1.Text = dgvProduct.Rows[e.RowIndex].Cells["nameProduct"].FormattedValue.ToString();
                txtBox3.Text = dgvProduct.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();

                string name = dgvProduct.Rows[e.RowIndex].Cells["codeProduct"].Value.ToString();
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `tbl_product` WHERE codeProduct = '{name}'", conn);
                DataTable dt = new DataTable();
                var ap = new MySqlDataAdapter(cmd);
                ap.Fill(dt);
                byte[] img = (byte[])dt.Rows[0]["images"];
                var ms = new MemoryStream(img);
                pictureBox2.Image = Image.FromStream(ms);
                ap.Dispose();
            }
            catch
            {

            }
           
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
                int selectedRow = dgv2.CurrentCell.RowIndex;
                int editCodePD = Convert.ToInt32(dgv2.Rows[selectedRow].Cells["รายการ2"].Value);
                MySqlConnection conn = databaseConnection();
                string sql = "update tbl_cart set qty2 = '" + textBox4.Text + "',cost2 = '" + rakha * Convert.ToInt32(textBox4.Text) + "' where รายการ2 ='" +
                    editCodePD + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("แก้ไขตะกร้าสำเร็จ");
                    showCart();
                }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtResult.Text, new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        //จำนวน
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
       

        private void btnAddd_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                string sql = "insert into tbl_cart (Username2, nameProduct2, qty2, 	cost2) values('" + label1.Text + "','" + txtBox1.Text + "'," +
                    "'" + txtBox2.Text + "','" + Convert.ToInt32(txtBox3.Text) * Convert.ToInt32(txtBox2.Text) + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("เพิ่มสินค้าสำเร็จ");
                    showCart();

                }
            }
            catch
            {

            }
        }
    }
        
}
