# 🛒 E-Commerce Web API

Bu proje, ASP.NET Core ile geliştirilen bir **e-ticaret sistemine ait backend API**'dir.  
MongoDB kullanılarak veri saklama işlemleri yapılır. JWT kullanılarak kullanıcı kimlik doğrulama ve yetkilendirme sağlanır.

---

## 🚀 Özellikler

- 👥 Kullanıcı kayıt & giriş (JWT Authentication)
- 🔐 Token bazlı erişim kontrolü
- 🧑‍💼 Rol tabanlı yetkilendirme (Admin / User)
- 📦 Ürün CRUD işlemleri
- 🗂️ Kategori CRUD işlemleri
- 🛒 Sepet sistemi (Cart)
- 🧾 Sipariş oluşturma ve geçmiş listeleme
- ✅ FluentValidation ile giriş verisi doğrulama
- 📄 Swagger UI ile test ve dökümantasyon

---

## 🧱 Kullanılan Teknolojiler

| Alan | Teknoloji |
|------|-----------|
| Backend | ASP.NET Core Web API |
| Veritabanı | MongoDB |
| Auth | JWT Token |
| Şifreleme | BCrypt.Net |
| Mapper | AutoMapper |
| Validasyon | FluentValidation |
| Dokümantasyon | Swagger (Swashbuckle) |

---

## 📁 Katmanlı Mimari Yapısı

```plaintext
📁 Controllers       → API endpoint'leri
📁 Services          → Business logic
📁 Repositories      → MongoDB işlemleri
📁 DTOs              → Veri taşıyıcı sınıflar
📁 Entities          → Mongo veri modelleri
📁 Validators        → FluentValidation kuralları
📁 AutoMappers       → DTO <=> Entity eşleştirme
📁 Context           → MongoDbSettings


🔐 JWT Authentication
Giriş yapan kullanıcıya JWT token üretilir
[Authorize] ile endpoint'ler korunur
[Authorize(Roles = "Admin")] ile admin yetkili işlemler tanımlanır
Token içerisinde kullanıcı kimliği (email, id, role) taşınır

🔗 API Endpoint Örnekleri
🔑 Auth
POST   /api/auth/register
POST   /api/auth/login

👤 Kullanıcı
GET    /api/user/me         → Token ile erişilen profil

🛍️ Ürün
GET    /api/product
POST   /api/product         → Admin
PUT    /api/product/{id}    → Admin
DELETE /api/product/{id}    → Admin

🗂️ Kategori
GET    /api/category
POST   /api/category        → Admin

🛒 Sepet
GET    /api/cart/{userId}
POST   /api/cart/{userId}
DELETE /api/cart/{cartItemId}

🧾 Sipariş
POST   /api/order
GET    /api/order/user/{userId}
GET    /api/order/all       → Admin

🧪 Swagger Kullanımı
Proje çalıştığında https://localhost:<port>/swagger adresinden tüm endpoint'leri test edebilirsin.
✅ Giriş yaptıktan sonra Swagger'da Authorize butonuna basarak JWT token'ı şu formatta girebilirsin:
Bearer eyJhbGciOiJIUzI1NiIsInR...

🛠️ Kurulum
1. Projeyi klonla:
git clone https://github.com/kullaniciadi/ECommerceApi.git

2. MongoDB servisini başlat
3. appsettings.json dosyasındaki bağlantıyı düzenle
4.Terminalde:
dotnet restore
dotnet run

📦 Varsayılan Kullanıcı Roller
Varsayılan tüm kullanıcılar User rolü ile oluşturulur
Admin kullanıcıyı elle MongoDB'ye şu şekilde ekleyebilirsin:
  {
    "email": "admin@mail.com",
    "passwordHash": "bcryptlenmiş-şifre",
    "role": "Admin"
  }

✨ Geliştirme Önerileri (Next Steps)
  🧠 Refresh Token sistemi
  📩 Email onayı / şifre sıfırlama
  📦 Ürün filtreleme, sayfalama, sıralama
  📎 Resim yükleme (File Upload)
  💳 Ödeme entegrasyonu (Mock veya gerçek)

📌 Notlar
Bu proje tamamen öğrenme ve geliştirme amaçlıdır.
Gerçek ortamda kullanmadan önce güvenlik ve performans açısından detaylı test yapılmalıdır.

👨‍💻 Geliştirici
Bu proje, Hakan tarafından ASP.NET Web API öğrenme sürecinde geliştirilmiştir.
