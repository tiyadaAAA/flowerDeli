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
    
    public partial class payment : Form
    {

        string imgLocation = "";
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void Getorder()
        {
            MySqlConnection con = databaseConnection();
            DataSet ds = new DataSet();
            con.Open();
            //เคลียร์ข้อมูลเก่า
            if (ds.Tables.Contains("dttbl_infor"))
                ds.Tables.Remove("dttbl_infor");

            //เรียกdata in SqlServer to Gridview
            string sql = "SELECT * FROM tbl_infor WHERE Username= '" + label7.Text + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "dttbl_infor");
            dgvorder.DataSource = ds.Tables["dttbl_infor"];
        }
        public payment()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
                
            }
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("ต้องการบันทึกใช่หรือไม่?", "คำเตือน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int selectedRow = dgvorder.CurrentCell.RowIndex;
                int editCodePD = Convert.ToInt32(dgvorder.Rows[selectedRow].Cells["orderNum"].Value);
                MySqlConnection conn = databaseConnection();

                byte[] imagess = null;
                FileStream Streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Streem);
                imagess = brs.ReadBytes((int)Streem.Length);

                string sql = "update tbl_infor set images = @images where orderNum ='" + editCodePD + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@images", imagess));
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("อัพโหลดสำเร็จ");
                    Getorder();
                }


            }
        }


        public string txtofpay; //ไว้ใช้รับค่ามาจากฟอร์ม2
        private void payment_Load(object sender, EventArgs e)
        {
            label7.Text = txtofpay;
            Getorder();
        }

        private void dgvorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvorder.CurrentRow.Selected = true;

                string name = dgvorder.Rows[e.RowIndex].Cells["orderNum"].Value.ToString();
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
