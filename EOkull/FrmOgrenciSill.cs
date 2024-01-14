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
using System.Data.OleDb;

namespace EOkull
{
    public partial class FrmOgrenciSill : Form
    {
        public FrmOgrenciSill()
        {
            InitializeComponent();
        }
        sqlbaglantisii bgl = new sqlbaglantisii();      
        private void FrmOgrenciSill_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ogrencid,OgrenciAd,OgrenciSoyad,OgrenciTC,OgrenciNo From Tbl_Ogrencilerr", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }
        void special_ogrenci_liste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ogrencid,OgrenciAd,OgrenciSoyad,OgrenciTC,OgrenciNo from Tbl_Ogrencilerr", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Ogrencilerr where OgrenciTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglanti().Close();
            special_ogrenci_liste();

            
        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komutsilara = new SqlCommand("Select * From Tbl_Ogrencilerr where OgrenciAd like '%" + TxtAd.Text + "%'", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komutsilara);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            MskTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtOkulNo.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

        }
    }
}
