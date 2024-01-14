using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOkull
{
    public partial class FrmOgrenciEklee : Form
    {
        public FrmOgrenciEklee()
        {
            InitializeComponent();
        }
        sqlbaglantisii bgl = new sqlbaglantisii();
        
            private void FrmOgrenciEklee_Load(object sender, EventArgs e)
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
            SqlCommand komut = new SqlCommand("insert into Tbl_Ogrencilerr (OgrenciAd,OgrenciSoyad,OgrenciTC,OgrenciNo) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", TxtOkulNo.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bgl.baglanti().Close();
            special_ogrenci_liste();
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTC.Text = "";
            TxtOkulNo.Text = "";
            
            
        }

        private void TxtOkulNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtOkulNo.Text.Length > 4)
            {
                MessageBox.Show("Öğrenci Numarası 4 Karakterden fazla olamaz! Lütfen kontrol ediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
