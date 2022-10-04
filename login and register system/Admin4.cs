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
    public partial class Admin4 : Form
    {
        public Admin4()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        public static string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";

        private void Getinfor()
        {
            //เคลียร์ข้อมูลเก่า
            if (ds.Tables.Contains("dttbl_infor"))
                ds.Tables.Remove("dttbl_infor");

            //เรียกdata in SqlServer to Gridview
            string sql = "SELECT * FROM tbl_infor ";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "dttbl_infor");
            dgv3.DataSource = ds.Tables["dttbl_infor"];
        }

        private void Admin4_Load(object sender, EventArgs e)
        {
            Getinfor();
            /*string sql = "SELECT * FROM tbl_infor";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "dttbl_infor");*/
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            /*string ConnectionString  = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            string SearchData = txtSearch.Text;
            string Query = "SELECT * FROM tbl_infor WHERE Username LIKE '%" + SearchData + "%' OR FLname LIKE '%" + SearchData + "%' ";
            MySqlCommand cmd = new MySqlCommand(Query, con);

            var reader = cmd.ExecuteReader();
            /*dgv3.Rows.Clear();
            while (reader.Read())
            {
                dgv3.Rows.Add(reader["list"], reader["Username"], reader["FLname"],"Edit","Delete");
            
            con.Close();    */
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=member";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = databaseConnection();
            connection.Open();
            MySqlCommand cnd;
            cnd = connection.CreateCommand();
            //string SearchData = txtSearch.Text;
            cnd.CommandText = "select * from tbl_infor where orderNum LIKE '%" + txtSearch.Text + "%' OR Username LIKE '%" + txtSearch.Text + "%' OR FLname LIKE '%" + txtSearch.Text + "%' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cnd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            MySqlDataReader reader = cnd.ExecuteReader();
            dgv3.DataSource = ds.Tables[0].DefaultView;
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


        private void button1_Click(object sender, EventArgs e)
        {
            Getinfor();
            txtSearch.Clear();
        }
    }
    
}
