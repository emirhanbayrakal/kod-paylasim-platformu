Kod Paylaşım ve Tartışma Platformu

Bu proje, yazılımcıların kendi kodlarını paylaşabildiği, tartışabildiği ve favorilerine ekleyebildiği modern bir web uygulamasıdır. Proje hem frontend hem de backend bileşenleriyle birlikte geliştirilmiştir.

---

Proje Yapısı

```plaintext
 HTML/                   → Frontend dosyaları (HTML, CSS, JS)
 WEB API/WebApplication1/ → ASP.NET Core Web API backend projesi
```

---
Kullanılan Teknolojiler
Frontend:
- HTML5, CSS3, Vanilla JavaScript
- Modüler yapı (navbar.html, footer.html ile component bazlı)
- Modern ve kullanıcı dostu arayüz

Backend:
- ASP.NET Core Web API (.NET 6+)
- Kullanıcı kayıt ve giriş sistemi
- SQL Server desteği (veritabanı bağlantısı appsettings.json içinde yapılandırılır)

---

Temel Özellikler

| Özellik                       | Açıklama |
|------------------------------|----------|
| Kayıt & Giriş              | Kullanıcılar kayıt olabilir ve giriş yapabilir. |
| Kod Paylaşımı              | Kullanıcılar başlık, açıklama ve kod içeriği ile paylaşım yapabilir. |
| Kod Detayı Sayfası         | Her kodun detayları ayrı sayfada görüntülenebilir. |
| Favorilere Ekleme          | Kullanıcılar kodları favorilerine ekleyebilir. |
| Profil Sayfası             | Kullanıcının kendi paylaşımlarını görebileceği profil sayfası |

---

##  Projenin Yapım Süreci

### 1. Planlama
Sistemde yer alacak temel özellikler ve sayfa yapısı belirlendi.

### 2. Frontend Geliştirme
HTML, CSS ve JavaScript kullanılarak modüler yapı kuruldu. Sayfalar oluşturuldu ve arayüz tasarımı yapıldı.

### 3. Backend Geliştirme
ASP.NET Core Web API ile kullanıcı kayıt ve giriş sistemi geliştirildi. SQL Server bağlantısı yapıldı.

### 4. Entegrasyon
Frontend formları fetch API ile backend’e bağlandı. Kullanıcı oturumu localStorage ile simüle edildi.

### 5. Test ve Yayınlama
Tüm sayfalar ve API’ler test edildi. Yayınlama için Render.com ve GitHub Pages gibi seçenekler değerlendirildi.

---

##  Kurulum

### Backend:
```bash
cd "WEB API/WebApplication1"
dotnet restore
dotnet run
```

### Frontend:
```bash
cd HTML
open index.html # veya çift tıklayarak çalıştır
```

---

##  İletişim
Bu proje ödev maksadıyla yapılmış bir öğrenci projesidir.
Herhangi bir katkı, geri bildirim veya hata bildirimi için benimle iletişime geçebilirsiniz.  
**E-posta:** emirhanbayrakal0@gmail.com
