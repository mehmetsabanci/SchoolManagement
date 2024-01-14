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
    public partial class FrmVeliPanelii : Form
    {
        public FrmVeliPanelii()
        {
            InitializeComponent();
        }
        public string TCNO;
        sqlbaglantisii bgl = new sqlbaglantisii();
        private void FrmVeliPanelii_Load(object sender, EventArgs e)
        {
            //Öğrenci TC kimlik No Çekme
            LblTC.Text = TCNO;


            //Öğrenci Ad - Soyad çekme
            SqlCommand komut = new SqlCommand("Select OgrenciAd,OgrenciSoyad,OgrenciNo From Tbl_Ogrencilerr where OgrenciTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1].ToString();
                LblOkulNo.Text = dr[2].ToString();

            }
            bgl.baglanti().Close();
            // datagridview1' e öğrenci not bilgileri çekme

            DataTable dt = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("Select Türkce,Matematik,SosyalBilgiler,İngilizce,BedenEgitimi From Tbl_Ogrencilerr where OgrenciTC='" + LblTC.Text + "'", bgl.baglanti());
            daa.Fill(dt);
            dataGridView1.DataSource = dt;

            //datagridviex2'ye öğrenci devamsızlk bilgisi girme
            DataTable dtt = new DataTable();
            SqlDataAdapter daaa = new SqlDataAdapter("Select OzurluDevamsizlik,OzursuzDevamsizlik From Tbl_Ogrencilerr where OgrenciTC='" + LblTC.Text + "'", bgl.baglanti());
            daaa.Fill(dtt);
            dataGridView2.DataSource = dtt;
        }

       
    }
}
