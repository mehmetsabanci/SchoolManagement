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
    public partial class FrmOgretmenPanelii : Form
    {
        public FrmOgretmenPanelii()
        {
            InitializeComponent();
        }
        sqlbaglantisii bgl = new sqlbaglantisii();
        public string TCNo;
        void Ogrenci_Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Ogrencilerr",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmOgretmenPanelii_Load(object sender, EventArgs e)
        {
            LblKullaniciAd.Text = TCNo;
            SqlCommand komut = new SqlCommand("Select OgretmenAd,OgretmenSoyad From Tbl_Ogretmenlerr where OgretmenKullaniciAd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblKullaniciAd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1].ToString();
            }
            bgl.baglanti().Close();

            //Öğrenciler

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Ogrencilerr", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtOgrenciNo.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtTurkce.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString(); //ad'ın textboxuna saçilen satırdaki 5. hücreyi ata anlamına gelir.
            TxtMatematik.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            TxtSosyalBilgiler.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            Txtingilizce.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            TxtBedenEgitimi.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //*********************************************************************************************
            SqlCommand komut = new SqlCommand("Update Tbl_Ogrencilerr set OgrenciNo=@d7,Türkce=@d1,Matematik=@d2,SosyalBilgiler=@d3,İngilizce=@d4,BedenEgitimi=@d5 where Ogrencid=@d6", bgl.baglanti());
            komut.Parameters.AddWithValue("d1", TxtTurkce.Text);
            komut.Parameters.AddWithValue("d2", TxtMatematik.Text);
            komut.Parameters.AddWithValue("d3", TxtSosyalBilgiler.Text);
            komut.Parameters.AddWithValue("d4", Txtingilizce.Text);
            komut.Parameters.AddWithValue("d5", TxtBedenEgitimi.Text);
            komut.Parameters.AddWithValue("d6", Txtid.Text);
            komut.Parameters.AddWithValue("d7", TxtOgrenciNo.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglanti().Close();
            Ogrenci_Listele();
            
        }

        private void BtnOgrenciEkle_Click(object sender, EventArgs e)
        {
            FrmOgrenciEklee fr = new FrmOgrenciEklee();
            fr.Show();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            FrmOgrenciSill fr = new FrmOgrenciSill();
            fr.Show();
        }

        private void TxtOgrenciNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtOgrenciNo.Text.Length > 4)
            {
                MessageBox.Show("Öğrenci Numarası 4 Karakterden fazla olamaz! Lütfen kontrol ediniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }    
        }

        private void TxtTurkce_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TxtTurkce.Text) <= 100)
            {
                
            }
            else
            {
                MessageBox.Show("Not 100'den büyük olamaz! Lütfen kontrol ediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtMatematik_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TxtMatematik.Text) <= 100)
            {

            }
            else
            {
                MessageBox.Show("Not 100'den büyük olamaz! Lütfen kontrol ediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtSosyalBilgiler_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TxtSosyalBilgiler.Text) <= 100)
            {

            }
            else
            {
                MessageBox.Show("Not 100'den büyük olamaz! Lütfen kontrol ediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Txtingilizce_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Txtingilizce.Text) <= 100)
            {

            }
            else
            {
                MessageBox.Show("Not 100'den büyük olamaz! Lütfen kontrol ediniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void TxtBedenEgitimi_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TxtBedenEgitimi.Text) <= 100)
            {

            }
            else
            {
                MessageBox.Show("Not 100'den büyük olamaz! Lütfen kontrol ediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }

