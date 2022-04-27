using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProjeOdevim.Formlar
{
    public partial class FShopping : Form
    {
        public FShopping()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        void ShoppingList()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,MAGAZA From TBLMAGAZA", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }
        private void FShopping_Load(object sender, EventArgs e)
        {
            ShoppingList();
            gridView1.FocusedRowHandle = gridView1.DataRowCount;
            gridView1.Columns[0].Visible = false;
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TId.Text = dr["ID"].ToString();
        }

        string picture1, picture2, picture3;

        void Clear()
        {
            PShop1.ImageLocation = "";
            PShop2.ImageLocation = "";
            PShop3.ImageLocation = "";
            pictureBox1.ImageLocation = null;
            pictureBox2.ImageLocation = null;
            pictureBox3.ImageLocation = null;
            pictureBox4.ImageLocation = null;
            pictureBox5.ImageLocation = null;
            pictureBox6.ImageLocation = null;
            pictureBox7.ImageLocation = null;
            pictureBox8.ImageLocation = null;
            pictureBox9.ImageLocation = null;
            pictureBox10.ImageLocation = null;
            pictureBox11.ImageLocation = null;
            pictureBox12.ImageLocation = null;
            pictureBox13.ImageLocation = null;
            pictureBox14.ImageLocation = null;
            pictureBox15.ImageLocation = null;
            pictureBox16.ImageLocation = null;
            pictureBox17.ImageLocation = null;
            pictureBox18.ImageLocation = null;
            pictureBox19.ImageLocation = null;
            pictureBox20.ImageLocation = null;
        }
        private void BClear_Click(object sender, EventArgs e)
        {
            Formlar.FAddShopping fAdd = new FAddShopping();
            fAdd.ShowDialog();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.DataRowCount >= 1)
            {
                DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                if (pictureBox1.ImageLocation == null)
                {
                    pictureBox1.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox2.ImageLocation == null)
                {
                    pictureBox2.ImageLocation = dr["FOTO"].ToString();

                }
                else if (pictureBox3.ImageLocation == null)
                {
                    pictureBox3.ImageLocation = dr["FOTO"].ToString();

                }
                else if (pictureBox4.ImageLocation == null)
                {
                    pictureBox4.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox5.ImageLocation == null)
                {
                    pictureBox5.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox6.ImageLocation == null)
                {
                    pictureBox6.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox7.ImageLocation == null)
                {
                    pictureBox7.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox8.ImageLocation == null)
                {
                    pictureBox8.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox9.ImageLocation == null)
                {
                    pictureBox9.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox10.ImageLocation == null)
                {
                    pictureBox10.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox11.ImageLocation == null)
                {
                    pictureBox11.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox12.ImageLocation == null)
                {
                    pictureBox12.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox13.ImageLocation == null)
                {
                    pictureBox13.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox14.ImageLocation == null)
                {
                    pictureBox14.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox15.ImageLocation == null)
                {
                    pictureBox15.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox16.ImageLocation == null)
                {
                    pictureBox16.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox17.ImageLocation == null)
                {
                    pictureBox17.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox18.ImageLocation == null)
                {
                    pictureBox18.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox19.ImageLocation == null)
                {
                    pictureBox19.ImageLocation = dr["FOTO"].ToString();
                }
                else if (pictureBox20.ImageLocation == null)
                {
                    pictureBox20.ImageLocation = dr["FOTO"].ToString();
                }
            }
        }
        private void BSave_Click(object sender, EventArgs e)
        {
            Clear();
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select DEPARTMAN as 'Görevi',AD as 'Ad Soyad',PUAN,FOTO,MAGAZAID From TBLPERSONEL" +
                " inner join TBLDEPARTMAN on TBLPERSONEL.DEPARTMANID = TBLDEPARTMAN.ID where MAGAZAID=" + TId.Text + "order by DEPARTMANID asc", connection);
            da.Fill(dt);
            gridControl2.DataSource = dt;
            connection.Close();
            gridView2.Columns[3].Visible = false;
            gridView2.Columns[4].Visible = false;

            connection.Open();
            SqlCommand command = new SqlCommand("Select ID,MAGAZA,ADRES,IL,ILCE,FOTO1,FOTO2,FOTO3 From TBLMAGAZA where ID=" + TId.Text, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                picture1 = reader["FOTO1"].ToString();
                picture2 = reader["FOTO2"].ToString();
                picture3 = reader["FOTO3"].ToString();
                LName.Text = reader["MAGAZA"].ToString();
                LAdres.Text = reader["ADRES"].ToString() + " " + reader["ILCE"].ToString() + "/" + reader["IL"].ToString();
            }
            connection.Close();
            PShop1.ImageLocation = picture1.ToString();
            PShop2.ImageLocation = picture2.ToString();
            PShop3.ImageLocation = picture3.ToString();
            //////////////////////////////////////
            int row = gridView2.DataRowCount;
            for (int i = 0; i < row; i++)
            {
                gridView2.FocusedRowHandle = i;
            }
        }
    }
}
