using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace ProjeOdevim.Formlar
{
    public partial class FrmList : Form
    {
        public FrmList()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        public void CategoryList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLKATEGORI", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        public void ProductList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLURUN", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        public void DepartmentList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLDEPARTMAN", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        public void ShoppingList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLMAGAZA", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        public void PersonelList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLPERSONEL", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        public void CustomerList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLMUSTERI", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Test_Load(object sender, EventArgs e)
        {

            if (label1.Text == "Category")
            {
                CategoryList();
            }
            else if (label1.Text == "Product")
            {
                ProductList();
            }
            else if (label1.Text == "Department")
            {
                DepartmentList();
            }
            else if (label1.Text == "Shopping")
            {
                ShoppingList();
            }
            else if (label1.Text == "Personel")
            {
                PersonelList();
            }
            else if (label1.Text=="Customer")
            {
                CustomerList();
            }
        }
    }
}
