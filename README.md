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
