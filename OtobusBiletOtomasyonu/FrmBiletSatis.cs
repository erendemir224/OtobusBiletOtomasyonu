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
    public partial class FrmBiletSatis : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FrmBiletSatis()
        {
            InitializeComponent();
        }

        private void FrmBiletSatis_Load(object sender, EventArgs e)
        {
            SeferleriGetir();
            
        }

        void SeferleriGetir()
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT SeferID, KalkisNoktasi + ' - ' + VarisNoktasi + ' / ' + FORMAT(TarihSaat, 'HH:mm') AS SeferBilgisi FROM Seferler", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbSefer.DisplayMember = "SeferBilgisi";
            cmbSefer.ValueMember = "SeferID";
            cmbSefer.DataSource = dt;
            cmbSefer.SelectedIndex = -1;
        }

        private void cmbSefer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSefer.SelectedIndex == -1)
            {
                pnlKoltuklar.Controls.Clear();
                return;
            }

            pnlKoltuklar.Controls.Clear();

            int secilenSeferID = Convert.ToInt32(cmbSefer.SelectedValue);
            int koltukSayisi = 0;

            SqlCommand komut = new SqlCommand("SELECT Otobusler.KoltukSayisi FROM Seferler INNER JOIN Otobusler ON Seferler.OtobusID = Otobusler.OtobusID WHERE SeferID = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", secilenSeferID);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                koltukSayisi = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();

            int sayac = 1;
            int x = 10;
            int y = 10;

            for (int i = 0; i < koltukSayisi; i++)
            {
                Button btn = new Button();
                btn.Width = 40;
                btn.Height = 40;
                btn.Text = sayac.ToString();
                btn.BackColor = Color.LightGray;
                btn.Location = new Point(x, y);
                btn.Click += Koltuk_Tıklandiginda;

                pnlKoltuklar.Controls.Add(btn);

                if (sayac % 4 == 1) x += 45;
                else if (sayac % 4 == 2) x += 80;
                else if (sayac % 4 == 3) x += 45;
                else if (sayac % 4 == 0)
                {
                    x = 10;
                    y += 45;
                }
                sayac++;
            }


            SqlCommand komutDolu = new SqlCommand("SELECT Biletler.KoltukNo, Yolcular.Cinsiyet FROM Biletler INNER JOIN Yolcular ON Biletler.YolcuID = Yolcular.YolcuID WHERE Biletler.SeferID = @p1", bgl.baglanti());
            komutDolu.Parameters.AddWithValue("@p1", secilenSeferID);

            SqlDataReader drDolu = komutDolu.ExecuteReader();
            while (drDolu.Read())
            {
                string doluKoltukNo = drDolu[0].ToString();
                string cinsiyet = drDolu[1].ToString();

                foreach (Control item in pnlKoltuklar.Controls)
                {
                    if (item is Button && item.Text == doluKoltukNo)
                    {

                        if (cinsiyet == "Kadın")
                            item.BackColor = Color.Pink;
                        else
                            item.BackColor = Color.LightBlue;

                        
                    }
                }
            }
            bgl.baglanti().Close();
        }

        private void Koltuk_Tıklandiginda(object sender, EventArgs e)
        {
            Button basilanKoltuk = sender as Button;
            txtKoltukNo.Text = basilanKoltuk.Text;

          
            if (basilanKoltuk.BackColor == Color.LightGray)
            {
                
                txtTC.Clear();
                txtAd.Clear();
                txtSoyad.Clear();
                txtTelefon.Clear();
                cmbCinsiyet.SelectedIndex = -1;

                btnSatis.Enabled = true; 
            }
            
            else
            {
                
                SqlConnection baglan = bgl.baglanti();
                SqlCommand komut = new SqlCommand("SELECT Yolcular.TCNo, Yolcular.Ad, Yolcular.Soyad, Yolcular.Telefon, Yolcular.Cinsiyet FROM Biletler INNER JOIN Yolcular ON Biletler.YolcuID = Yolcular.YolcuID WHERE Biletler.SeferID = @p1 AND Biletler.KoltukNo = @p2", baglan);

                komut.Parameters.AddWithValue("@p1", cmbSefer.SelectedValue);
                komut.Parameters.AddWithValue("@p2", basilanKoltuk.Text);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) // Yolcu bulunduysa kutulara yazdır
                {
                    txtTC.Text = dr[0].ToString();
                    txtAd.Text = dr[1].ToString();
                    txtSoyad.Text = dr[2].ToString();
                    txtTelefon.Text = dr[3].ToString();
                    cmbCinsiyet.Text = dr[4].ToString();
                }
                baglan.Close();

                btnSatis.Enabled = false; 
            }
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTC.Text) || string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) || string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtKoltukNo.Text) || cmbCinsiyet.SelectedIndex == -1 ||
                cmbSefer.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen yolcu bilgilerini, cinsiyeti ve koltuk numarasını eksiksiz doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglan = bgl.baglanti();
            int secilenSeferID = Convert.ToInt32(cmbSefer.SelectedValue);
            int secilenNo = Convert.ToInt32(txtKoltukNo.Text);

            int yanKoltukNo = (secilenNo % 2 == 0) ? secilenNo - 1 : secilenNo + 1;

            SqlCommand komutKontrol = new SqlCommand("SELECT Yolcular.Cinsiyet FROM Biletler INNER JOIN Yolcular ON Biletler.YolcuID = Yolcular.YolcuID WHERE SeferID = @s1 AND KoltukNo = @k1", baglan);
            komutKontrol.Parameters.AddWithValue("@s1", secilenSeferID);
            komutKontrol.Parameters.AddWithValue("@k1", yanKoltukNo);

            object sonuc = komutKontrol.ExecuteScalar();
            if (sonuc != null)
            {
                string yanCinsiyet = sonuc.ToString();
                if (yanCinsiyet != cmbCinsiyet.Text)
                {
                    MessageBox.Show("Satış Engellendi: Seçilen koltukda farklı cinsiyette bir yolcu oturuyor!", "Kural İhlali", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglan.Close();
                    return;
                }
            }

            SqlCommand komutYolcu = new SqlCommand("INSERT INTO Yolcular (TCNo, Ad, Soyad, Telefon, Cinsiyet) OUTPUT INSERTED.YolcuID VALUES (@p1, @p2, @p3, @p4, @p5)", baglan);
            komutYolcu.Parameters.AddWithValue("@p1", txtTC.Text);
            komutYolcu.Parameters.AddWithValue("@p2", txtAd.Text);
            komutYolcu.Parameters.AddWithValue("@p3", txtSoyad.Text);
            komutYolcu.Parameters.AddWithValue("@p4", txtTelefon.Text);
            komutYolcu.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);

            int kaydedilenYolcuID = (int)komutYolcu.ExecuteScalar();

            SqlCommand komutBilet = new SqlCommand("INSERT INTO Biletler (SeferID, YolcuID, KoltukNo) VALUES (@b1, @b2, @b3)", baglan);
            komutBilet.Parameters.AddWithValue("@b1", secilenSeferID);
            komutBilet.Parameters.AddWithValue("@b2", kaydedilenYolcuID);
            komutBilet.Parameters.AddWithValue("@b3", secilenNo);

            komutBilet.ExecuteNonQuery();
            baglan.Close();

            DialogResult secim = MessageBox.Show("Bilet başarıyla satıldı! \n\nYolcu için bilet çıktısı alınsın mı?", "Yazdırma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (secim == DialogResult.Yes)
            {
                string gidenAdSoyad = txtAd.Text + " " + txtSoyad.Text;
                string gidenTC = txtTC.Text;
                string gidenSefer = cmbSefer.Text; 
                string gidenKoltuk = txtKoltukNo.Text;
                string islemTarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm"); 

                
                FrmBiletCikti frmCikti = new FrmBiletCikti(gidenAdSoyad, gidenTC, gidenSefer, gidenKoltuk, islemTarihi);
                frmCikti.StartPosition = FormStartPosition.CenterScreen; 
                frmCikti.ShowDialog();
            }


            foreach (Control item in pnlKoltuklar.Controls)
            {
                if (item is Button && item.Text == txtKoltukNo.Text)
                {
                    if (cmbCinsiyet.Text == "Kadın")
                        item.BackColor = Color.Pink;
                    else
                        item.BackColor = Color.LightBlue;

                   
                    break;
                }
            }

            txtTC.Clear(); txtAd.Clear(); txtSoyad.Clear(); txtTelefon.Clear(); txtKoltukNo.Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void FrmBiletSatis_Load_2(object sender, EventArgs e)
        {
            SeferleriGetir();
            cmbSefer.SelectedIndex = -1;    

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            
            if (txtKoltukNo.Text == "" || cmbSefer.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen iptal edilecek seferi ve koltuk numarasını seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DialogResult cevap = MessageBox.Show(txtKoltukNo.Text + " numaralı koltuğun biletini iptal etmek istediğinize emin misiniz?", "İptal Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                SqlConnection baglan = bgl.baglanti();
                int secilenSeferID = Convert.ToInt32(cmbSefer.SelectedValue);
                int secilenNo = Convert.ToInt32(txtKoltukNo.Text);

                
                SqlCommand komutSil = new SqlCommand("DELETE FROM Biletler WHERE SeferID = @s1 AND KoltukNo = @k1", baglan);
                komutSil.Parameters.AddWithValue("@s1", secilenSeferID);
                komutSil.Parameters.AddWithValue("@k1", secilenNo);

                int etkilenenKayit = komutSil.ExecuteNonQuery(); 
                baglan.Close();

                
                if (etkilenenKayit > 0)
                {
                    MessageBox.Show("Bilet başarıyla iptal edildi. Koltuk yeniden satışa açıldı.", "İptal Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    foreach (Control item in pnlKoltuklar.Controls)
                    {
                        if (item is Button && item.Text == txtKoltukNo.Text)
                        {
                            item.BackColor = Color.LightGray; 
                            item.Enabled = true;             
                            break;
                        }
                    }

                    txtKoltukNo.Clear(); 
                    btnSatis.Enabled = true; 
                    txtTC.Clear(); txtAd.Clear(); txtSoyad.Clear(); txtTelefon.Clear(); cmbCinsiyet.SelectedIndex = -1; 
                }
                else
                {
                    
                    MessageBox.Show("Bu koltuğa ait satılmış bir bilet bulunamadı! Zaten boş olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
        