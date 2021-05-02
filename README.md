# LinkedIn Profil Sayfası
## Back-end'i hazırlamak

Back-end Asp.net Core Web API altyapısıyla geliştirilmiştir. .Net 5 sürümü ile katmanlı mimari yapısı kullanılmıştır.

Sırasıyla;


#### Core 
Bu bölümde benim her projemde kullandığım ve sürekli geliştirmekte olduğum yapılar (base ve soyut sınıflar, cross cutting concerns, extensions) bulunmaktadır. 
#### Entity
Bu bölümde veritabanımızın class olarak karşılıkları ve dtolar  bulunmaktadır. Bir ORM aracı ile veritabanına bağlantı kurulabilir.
#### Data Access
Veritabanına ulaştığımız bölüm.
#### Business
Mantık işlerinin yapıldığı bölüm.
#### WebApi
Api bölümümüz.

### Çalıştırma
Dosyayı zipten çıkarın ve .sln uzantılı dosyaya tıklayın. Visual Studio'da proje açılacaktır. İlk olarak data access içerisinde LinkedInContext dosyasının içindeki localdatabase adresini kontrol edin. Eğer sizin localdatabase adresiniz buradakinden farklıysa lütfen gerekli olan localdb adresinizi koyun ve Database= bölümünün sağ tarafına veritabanı için vermek istediğiniz ismi koyun. 
```
 optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Database=LinkedIn;Trusted_Connection=true");
```

Visual Studio içerisinde Package Manager Console'u açın. 

Eğer DataAccess içerisinde migration dosyaları yoksa ilk yapmanız gereken 
```
add-migration CreateDatabase
```
komutunu girmeniz, eğer build ederken bir hata yoksa migration dosyanızı oluşturacaktır.Eğer migration dosyaları varsa bu adımı atlayın!

Başlangıç projesini data access olarak ayarlayın ve package manager'ın çalışma bölümünü data access seçin.


Konsola 
```
update-database 
```
yazarak veritabanının oluşturulmasını sağlayın. Bu adımdan sonra projeyi çalıştırabilirsiniz.
