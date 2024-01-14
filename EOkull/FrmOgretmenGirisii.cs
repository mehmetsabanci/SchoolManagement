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
    public partial class FrmOgretmenGirisii : Form
    {
        public FrmOgretmenGirisii()
        {
            InitializeComponent();
        }
        sqlbaglantisii bgl = new sqlbaglantisii();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ogretmenlerr where OgretmenKullaniciAd=@p1 and OgretmenSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                if (label3.Text == TxtCaptcha.Text)
                {
                    FrmOgretmenPanelii fr = new FrmOgretmenPanelii();
                    fr.TCNo = TxtKullaniciAdi.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kod , Kullanıcı Adı veya Şifre!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Hatalı Kod , Kullanıcı Adı veya Şifre!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bgl.baglanti().Close();
        }

        private void FrmOgretmenGirisii_Load(object sender, EventArgs e)
        {
            string[] buyuk_harf = {"A","B","C","D","E","F","G","H","I","İ","J","K","L","M","N","O","Ö"
                    ,"P","R","S","Ş","T","U","Ü","V","Y","Z"};
            string[] kucuk_harf = {"a","b","c","d","e","f","g","h","ı","i","j","k","l","m","n","o","ö"
            ,"p","r","s","ş","t","u","ü","v","y","z"};
            int s1, s2, s3, s4, s5;
            Random r = new Random();
            s1 = r.Next(0, buyuk_harf.Length);
            s2 = r.Next(0, kucuk_harf.Length);
            s3 = r.Next(1, 9);
            s4 = r.Next(1, 9);
            s5 = r.Next(1, 9);
            label3.Text = s5.ToString() + buyuk_harf[s1].ToString() +
                s4.ToString() + kucuk_harf[s2].ToString() + s3.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string[] buyuk_harf = {"A","B","C","D","E","F","G","H","I","İ","J","K","L","M","N","O","Ö"
                    ,"P","R","S","Ş","T","U","Ü","V","Y","Z"};
            string[] kucuk_harf = {"a","b","c","d","e","f","g","h","ı","i","j","k","l","m","n","o","ö"
            ,"p","r","s","ş","t","u","ü","v","y","z"};
            int s1, s2, s3, s4, s5;
            Random r = new Random();
            s1 = r.Next(0, buyuk_harf.Length);
            s2 = r.Next(0, kucuk_harf.Length);
            s3 = r.Next(1, 9);
            s4 = r.Next(1, 9);
            s5 = r.Next(1, 9);
            label3.Text = s5.ToString() + buyuk_harf[s1].ToString() +
                s4.ToString() + kucuk_harf[s2].ToString() + s3.ToString();
        }
    }
}
