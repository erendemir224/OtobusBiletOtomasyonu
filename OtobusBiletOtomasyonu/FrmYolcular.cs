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
    public partial class FrmYolcular : Form
    {
        public FrmYolcular()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void FrmYolcular_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Yolcular", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedIndex == -1)
            {
                // Kutuya ilk harf girildiğinde uyarı verir ve yazıyı siler
                if (textBox1.Text.Length > 0)
                {
                    MessageBox.Show("Lütfen önce bir arama kategorisi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                }
                return;
            }

            // 2. ComboBox'taki Türkçe isimleri, SQL'deki gerçek sütun isimleriyle eşleştiriyoruz
            string aranacakSutun = "";
            if (cmbKategori.Text == "TC Kimlik") aranacakSutun = "TCNo";
            else if (cmbKategori.Text == "Ad") aranacakSutun = "Ad";
            else if (cmbKategori.Text == "Soyad") aranacakSutun = "Soyad";
            else if (cmbKategori.Text == "Telefon") aranacakSutun = "Telefon";
            else if (cmbKategori.Text == "Cinsiyet") aranacakSutun = "Cinsiyet";

            // 3. SQL'de "İçinde geçenleri bul" mantığı olan LIKE komutunu kullanarak arama yapıyoruz
            SqlConnection baglan = bgl.baglanti();

            // Güvenli arama sorgusu: Seçilen sütuna göre LIKE operatörü ile arama
            SqlCommand komut = new SqlCommand($"SELECT * FROM Yolcular WHERE {aranacakSutun} LIKE @aranan", baglan);

            // TextBox'a yazılan metnin başına ve sonuna % işareti koyarak "içinde geçenleri getir" diyoruz
            komut.Parameters.AddWithValue("@aranan", "%" + textBox1.Text + "%");

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt; // Tabloyu anında filtrelenmiş verilerle güncelle

            baglan.Close();
        }
    }
}
