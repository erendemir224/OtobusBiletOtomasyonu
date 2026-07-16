# 🚌 Bus Ticket Automation System (Otobüs Bilet Satış Otomasyonu)

Bu proje, C# Windows Forms ve SQL Server kullanılarak geliştirilmiş, gerçek dünya iş mantığı (business logic) kurallarını barındıran kapsamlı bir masaüstü bilet satış otomasyonudur. Standart "veri ekle/göster" (CRUD) işlemlerinin ötesine geçerek, dinamik arayüz yönetimi ve algoritmik veritabanı kontrollerine odaklanılmıştır.

## 🎯 Öne Çıkan Özellikler ve Mimari

*   **Dinamik UI Üretimi (Dynamic Controls):** Kullanıcı bir sefer seçtiğinde, arka planda çalışan SQL `INNER JOIN` sorgusu otobüsün kapasitesini (Örn: 38 veya 41 koltuk) tespit eder. Koltuklar arayüze sürükle-bırak yöntemiyle statik olarak eklenmemiştir; tamamen bu kapasite sayısına göre çalışma zamanında (Runtime) döngülerle sıfırdan çizdirilir.
*   **Akıllı Cinsiyet Kontrolü (Business Logic):** Seyahat kuralları gereği, yan yana olan koltuklarda farklı cinsiyetten yolcuların seyahat etmesini engelleyen matematiksel bir algoritma (Mod 2 aritmetiği) kullanılmıştır. Sistem, seçilen koltuğun yanındaki yolcuyu veritabanından anlık olarak (`ExecuteScalar`) sorgular ve kural ihlali varsa satışı arayüz seviyesinde bloklar.
*   **İlişkisel Veritabanı Mimarisi:** Seferler, Otobüsler, Yolcular ve Biletler verileri tamamen birbirine bağlı (Foreign Key) tablolar üzerinden yönetilir. 

## 🛠️ Kullanılan Teknolojiler

*   **Programlama Dili:** C#
*   **Platform:** .NET Framework (Windows Forms)
*   **Veritabanı:** MS SQL Server
*   **Veri Erişimi:** ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`)
*   **Sorgulama:** T-SQL (Relational Queries, INNER JOIN)

## ⚙️ Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için şu adımları izleyebilirsiniz:

1. Bu depoyu bilgisayarınıza klonlayın: 
   ```bash
   git clone [https://github.com/erendemir224/OtobusBiletOtomasyonu.git](https://github.com/erendemir224/OtobusBiletOtomasyonu.git)

2. Proje dosyaları içerisindeki SQL Script dosyasını (eğer ekliyse) SQL Server Management Studio (SSMS) üzerinden çalıştırarak veritabanı tablolarını oluşturun.
3. Visual Studio üzerinde projeyi açın. Kod içerisindeki (veya App.config içerisindeki) SqlConnection dizesini kendi SQL Server adınıza (Data Source=SizinSunucuAdiniz) göre güncelleyin.
4. F5 tuşu ile projeyi başlatın.
📸 Ekran Görüntüleri
<img width="1917" height="991" alt="Ekran görüntüsü 2026-07-16 151747" src="https://github.com/user-attachments/assets/e515cb69-c913-4ee6-a08c-f2904187f10f" />
<img width="1917" height="985" alt="Ekran görüntüsü 2026-07-16 151815" src="https://github.com/user-attachments/assets/42c1afc0-ab1d-4b37-be99-0d5fc4dd7951" />
<img width="1917" height="987" alt="Ekran görüntüsü 2026-07-16 151829" src="https://github.com/user-attachments/assets/c82ed2ae-43ee-478b-8c78-48d32b148c8a" />
<img width="1917" height="985" alt="Ekran görüntüsü 2026-07-16 151839" src="https://github.com/user-attachments/assets/82bb404b-01b4-4a4c-8ddf-567c34907800" />




