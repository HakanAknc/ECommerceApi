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
