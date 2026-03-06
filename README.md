# 🌍 ViTour - Dynamic Tour Booking Platform

Modern bir tur rezervasyon platformudur.  
Proje **ASP.NET Core MVC + MongoDB** kullanılarak geliştirilmiştir ve tamamen **dinamik veri yönetimi** üzerine kuruludur.

Bu proje **ViTour Case Study** kapsamında geliştirilmiştir.

---

# 🚀 Proje Özellikleri

## 🧭 Tur Listeleme (Archive Tour)

- MongoDB üzerinden dinamik tur verileri çekilir
- Sayfalama (Pagination) sistemi vardır
- Her sayfada **6 tur listelenir**
- Kategori ve lokasyon filtreleri bulunur

---

## 🗺️ Tur Detay Sayfası

Tur detay sayfasında **5 farklı dinamik sekme bulunmaktadır:**

### 📌 Information
- Tur açıklaması
- Kapasite
- Gün sayısı
- Fiyat bilgisi

### 📅 Tour Planning
- Gün gün tur programı
- MongoDB `TourPlanning` koleksiyonundan çekilir

### 🗺️ Location Share
- Google Maps kullanılmamıştır
- **Gemini AI ile oluşturulmuş Pixar tarzı harita görselleri kullanılmıştır**

### ⭐ Reviews
- Kullanıcı yorumları
- 5 yıldız değerlendirme sistemi
- Ortalama puan hesaplama

### 🖼️ Gallery
- Tur görselleri
- `TourImages` koleksiyonundan dinamik çekilir

---

# 🧾 Rezervasyon Sistemi

Rezervasyon sayfası tamamen **sıfırdan tasarlanmıştır.**

## Özellikler

- Modern UI
- Kişi sayısına göre otomatik fiyat hesaplama
- Kontenjan kontrolü
- Rezervasyon kaydı MongoDB'ye yazılır

---

# 🧑‍💻 Admin Panel

Admin panel tamamen **custom olarak geliştirilmiştir.**

## Yönetilebilir Modüller

- Tours
- Categories
- Location
- Reviews
- Reservations

## Admin Özellikleri

- CRUD işlemleri
- Rezervasyon raporlama
- Excel / PDF export
- Türkçeleştirilmiş panel

---

# 🌐 Çoklu Dil (Localization)

Sistem üç dili destekler:

- Türkçe
- İngilizce
- Fransızca

Dil seçimi **cookie tabanlıdır**.

---

# 🧱 Proje Mimarisi

Proje aşağıdaki klasör yapısına sahiptir:

```
Project3ViTour
│
├── Entities
├── Services
├── DTOs
├── Controllers
├── ViewComponents
├── Views
└── wwwroot
```

### Kullanılan Mimari

- MVC Architecture
- Service Layer Pattern
- Async MongoDB Driver
- Interface Segregation

---

# 🛠️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|--------|--------|
| ASP.NET Core MVC | Backend Framework |
| MongoDB | NoSQL Database |
| MongoDB.Driver | Database bağlantısı |
| Tailwind CSS | Modern UI tasarımı |
| JavaScript | Dinamik işlemler |
| Razor View Engine | Frontend templating |
| Localization | Çoklu dil desteği |

---

# 📸 Proje Ekran Görüntüleri
<img width="1912" height="948" alt="Ekran görüntüsü 2026-03-06 172554" src="https://github.com/user-attachments/assets/d2e8bc33-7517-448f-908b-4351d14bf75b" />
<img width="1907" height="943" alt="Ekran görüntüsü 2026-03-06 173134" src="https://github.com/user-attachments/assets/16aa7b02-6452-4401-a170-7f0c50b6e560" />
<img width="712" height="880" alt="Ekran görüntüsü 2026-03-06 172930" src="https://github.com/user-attachments/assets/afad2325-8c4a-495e-a093-ecbfcfae6851" />
<img width="1912" height="925" alt="Ekran görüntüsü 2026-03-06 172842" src="https://github.com/user-attachments/assets/861cb9b9-9bb2-4835-9146-59aea2720b77" />
<img width="1900" height="938" alt="Ekran görüntüsü 2026-03-06 172826" src="https://github.com/user-attachments/assets/0a8f8bda-bcca-4329-ba65-b012e5618b9a" />
<img width="1914" height="830" alt="Ekran görüntüsü 2026-03-06 172718" src="https://github.com/user-attachments/assets/63781670-1b45-42cf-817a-75d60cc1b2e2" />
<img width="1913" height="770" alt="Ekran görüntüsü 2026-03-06 173208" src="https://github.com/user-attachments/assets/7fb349a0-f792-4398-8164-ff3e8e900438" />
<img width="1914" height="943" alt="Ekran görüntüsü 2026-03-06 173200" src="https://github.com/user-attachments/assets/d801d2f0-7d80-440c-b715-6b8d95a248f8" />
<img width="1917" height="920" alt="Ekran görüntüsü 2026-03-06 173406" src="https://github.com/user-attachments/assets/ecc0609b-8024-40e8-99fd-5a2365807471" />
<img width="1909" height="934" alt="Ekran görüntüsü 2026-03-06 173257" src="https://github.com/user-attachments/assets/6a7aa354-3cfe-4aa4-8b84-84628e8ed33a" />
<img width="1901" height="933" alt="Ekran görüntüsü 2026-03-06 173246" src="https://github.com/user-attachments/assets/b2728075-91a6-4ca2-8c90-af22afb69b99" />
<img width="1907" height="940" alt="Ekran görüntüsü 2026-03-06 173238" src="https://github.com/user-attachments/assets/c250ef0c-2c65-4840-9d22-92ab4224db70" />
<img width="1913" height="944" alt="Ekran görüntüsü 2026-03-06 173221" src="https://github.com/user-attachments/assets/0c6b8f53-937e-472d-b4e0-c06f1de53053" />
<img width="1902" height="941" alt="Ekran görüntüsü 2026-03-06 174241" src="https://github.com/user-attachments/assets/2916338c-17dd-4db2-bd3a-5fa525cc1318" />
<img width="1892" height="941" alt="Ekran görüntüsü 2026-03-06 174205" src="https://github.com/user-attachments/assets/a9f54f0a-823b-472d-997c-fd73d721c3db" />
<img width="1897" height="941" alt="Ekran görüntüsü 2026-03-06 173950" src="https://github.com/user-attachments/assets/0ef1cb4d-5bc2-4ceb-929c-d350379ff7a2" />
<img width="1893" height="920" alt="Ekran görüntüsü 2026-03-06 173724" src="https://github.com/user-attachments/assets/f886b363-5baa-4fc2-b961-5b5764d54a4c" />
<img width="1904" height="943" alt="Ekran görüntüsü 2026-03-06 173715" src="https://github.com/user-attachments/assets/73e201f2-62ab-4380-b167-c78a59e518e6" />
<img width="1914" height="940" alt="Ekran görüntüsü 2026-03-06 173657" src="https://github.com/user-attachments/assets/f2e474d2-9ddb-4b7f-836b-cd0cfd1fc6cd" />
<img width="1915" height="940" alt="Ekran görüntüsü 2026-03-06 173627" src="https://github.com/user-attachments/assets/3e362b31-c2e6-4443-808e-cacb18dc70ff" />
<img width="1903" height="848" alt="Ekran görüntüsü 2026-03-06 173417" src="https://github.com/user-attachments/assets/fd34dec0-7b43-4757-b601-122a20a47419" />



---

# ⚙️ Kurulum

## 1️⃣ Repository'i klonlayın

```bash
git clone https://github.com/UmutCan37/Project3ViTour.git
```

## 2️⃣ Projeyi açın

```
Project3ViTour.sln
```

## 3️⃣ MongoDB bağlantısını ayarlayın

`appsettings.json`

```json
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "ViTourDb"
}
```

## 4️⃣ Projeyi çalıştırın

```bash
dotnet run
```

---

# 📂 MongoDB Koleksiyonları

Projede kullanılan koleksiyonlar:

```
Tours
Categories
Locations
TourPlanning
TourImages
Reviews
Bookings
```

---

# 🎯 Case Gereksinimleri

Bu proje aşağıdaki gereksinimleri karşılayacak şekilde geliştirilmiştir:

- Dinamik tur listeleme
- Tur detay sekmeleri
- AI harita görseli
- Tur planı
- Kullanıcı değerlendirmeleri
- Dinamik galeri
- Modern rezervasyon sistemi
- Admin panel yönetimi

---

# 👨‍💻 Developer

**Umut Can Yavru**

GitHub  
https://github.com/UmutCan37

---

# ⭐ Destek

Projeyi beğendiysen ⭐ vermeyi unutma.
