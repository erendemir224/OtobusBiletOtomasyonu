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

namespace OtobusBiletOtomasyonu
{
    public partial class FrmSeferler : Form
    {
        public FrmSeferler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void OtobusleriGetir()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT OtobusID, Plaka FROM Otobusler", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbOtobus.DisplayMember = "Plaka";     
            cmbOtobus.ValueMember = "OtobusID";    
            cmbOtobus.DataSource = dt;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmSeferler_Load(object sender, EventArgs e)
        {
            OtobusleriGetir();
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT SeferID, KalkisNoktasi, VarisNoktasi, TarihSaat, BiletFiyati, Plaka FROM Seferler INNER JOIN Otobusler ON Seferler.OtobusID = Otobusler.OtobusID", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DateTime tarih = dtpTarih.Value.Date; 
            TimeSpan saat = TimeSpan.Parse(mtxtSaat.Text);

            DateTime tamZaman = tarih.Add(saat);
            SqlCommand komut = new SqlCommand("INSERT INTO Seferler (KalkisNoktasi, VarisNoktasi, TarihSaat, BiletFiyati, OtobusID) VALUES (@p1, @p2, @p3, @p4, @p5)", bgl.baglanti());

            
            komut.Parameters.AddWithValue("@p1", txtKalkis.Text); 
            komut.Parameters.AddWithValue("@p2", txtVaris.Text);
            
            komut.Parameters.AddWithValue("@p3", tamZaman);


            

            
            komut.Parameters.AddWithValue("@p4", Convert.ToDecimal(txtFiyat.Text));

            
            komut.Parameters.AddWithValue("@p5", cmbOtobus.SelectedValue);

            komut.ExecuteNonQuery(); 
            bgl.baglanti().Close();  

            MessageBox.Show("Sefer başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        void Listele()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT SeferID, KalkisNoktasi, VarisNoktasi, TarihSaat, BiletFiyati, Plaka FROM Seferler INNER JOIN Otobusler ON Seferler.OtobusID = Otobusler.OtobusID", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
