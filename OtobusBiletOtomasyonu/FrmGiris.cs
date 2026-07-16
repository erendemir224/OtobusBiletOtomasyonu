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

namespace OtobusBiletOtomasyonu
{
    public partial class FrmGiris : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public static string kullaniciRolu = "";
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
         
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = bgl.baglanti();

            
            SqlCommand komut = new SqlCommand("SELECT Rol FROM Kullanicilar WHERE KullaniciAdi=@p1 AND Sifre=@p2", baglan);

            komut.Parameters.AddWithValue("@p1", txtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read()) 
            {
                kullaniciRolu = dr[0].ToString(); 

                AnaForm frm = new AnaForm();
                frm.Show(); 
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglan.Close();
        }
    }
}
