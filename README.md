# ProjeITAnketSistemi
Admin, Şirket, Personel Rolleriyle Dinamik Anketlerin Tanımlanması ve Sonuçlarının Analizinin Yapılmasını Sağlayan MVC Web Projesi

* Proje İçerisinde Öncelikle Migrations İşlemleri Başlatılmalıdır.
1- Paket Yönetici Konsolu Açılır ve Ardından İşlenecek Kısım Data-Access-Layer Olarak Belirlenir.
2- " enable-migrations " İşlemi Başlatılır ve Oluşturulan Konfigürasyon Dosyasındaki İzin "True" Olarak Ayarlanır.
3- " update-database " İşlemi Başlatılır ve Veritabanı Hazırlanır.

*Proje Nasıl Çalışır ?
1- Admin Girişi İçin Veritabanında Örnek Bir Kullanıcı Oluşturulmalıdır.
2- Admin Panelinde Şirket, Personel ve Anket Tanımlamaları Bulunmaktadır.

*Şirket Tanımlarken Ne Yapılmalı
1- Şirket Ekle Sayfası Açıldıktan Sonra Şirketteki Müdüre ve Şirketin İsmine Değer Girişi Yapıldıktan Sonra " Değişiklikleri Kaydet " Denir.

*Personel Tanımlarken Ne Yapılmalı
1- Personel Ekle Sayfası Açıldıktan Sonra Personelin DropDownList ile Şirketi Seçilir ve Personelin İsmine Değer Girişi Yapıldıktan Sonra " Değişiklikleri Kaydet " Denir.

*Anket Tanımlarken Ne Yapılmalı
1- Anket Ekle Sayfası Açıldıktan Sonra Anket Adı, Tipi ve Anketin Şirketi DropDownList ile Seçildikten Sonra " Değişiklikleri Kaydet " Denir.


*Ankete Soru Eklerken Ne Yapılmalı
1- Anketler Sayfasındaki Listelenen Anketler Üzerindeki " Soru Ekle " Yönlendirmesine Basılır ve O Ankete Ait Soruların, Tiplerinin Tanımlanabileceği Sayfa Açılır
Buradan Soru Adı Girilerek ve Tipi Seçilerek " Değişiklikleri Kaydet " Denir.

*Anket Sorularına Opsiyon Eklerken Ne Yapılmalı 
1- Anketler Menüsünden Eklediğimiz Soruları Görüntüleyebileceğimiz " Soru Görüntüle " Yönlendirmesine Tıklanır. Ankete Ait Soruların Listelendiği Sayfa Üzerindeki
Soruya Opsiyon Ekle Butonu İle Soruya Opsiyon Eklenebilecek Sayfaya Yönlendirilir. Burada Opsiyon Adı Girilerek " Değişiklikleri Kaydet " Denir.
Sorulara Ait Eklenen Opsiyonlar Soru Görüntülediğimiz Sayfa Üzerinden " Opsiyon Görüntüle " Yönlendirmesiyle Gidilen Sayfada Görüntülenebilir.

*Anketler Nasıl Cevaplanır
1- Personel Paneline Kullanıcı Adı ve Şifre (Personel Adının İlk 2 Harfi ve Bulunduğumuz Ayın Rakamsal Değeri) İle Giriş Yapılır. 
2- Panel Üzerindeki Anketler Bölümünde Personelin Ait Olduğu Şirket İçindeki Tanımlanmış Anketler Listelenmektedir.
3- Buradan " Cevapla " Seçeneği İle Ankete Giriş Sağlanır.
4- Sorulara Verilen Cevapların Ardından Son Kısımda Personelin Ankete Özel Yorum Yapması İstenir. (Bu Bölüm Boş Bırakılamaz!)

*Anket Cevapları Nasıl Görüntülenir
1- Admin veya Şirket Müdürü Anketler Menüsünde Tanımladığı Anketlerin Bulunduğu Satırlarda " Cevap Görüntüle " Yönlendirmesine Tıklayarak 
İlgili Anketin Cevaplarını ve Cevaplayan Personellerini Görüntüleyebilir (Eğer Anket Anonim Değil ise..) 

*Anket Yorumları Nasıl Görüntülenir
1- Admin veya Şirket Müdürü Anketler Menüsünde Tanımladığı Anketlerin Bulunduğu Satırlarda " Cevap Görüntüle " Yönlendirmesine Tıklayarak 
İlgili Anketin Cevaplarının Bulunduğu Tablo Üzerinde Alt Kısımda Ankete Ait Yorumların Bulunduğu Yönlendirme Butonuna Tıklamalıdır.
2- Bu Bölümde Ankete Yapılan Yorumlar ve Yapan Kişiler Görüntülenebilir (Eğer Anket Anonim Değil ise..)

!! Anketteki Soru Tipleri ve Opsiyonlar Tamamen Şirket veya Admin Tarafından Dinamik Olarak Oluşturulur.!

!! Admin Anket Tipinden Bağımsız Olarak Tüm Listeleme İşlemlerinde Personel İsimlerini Görebilmektedir.!

!! Şirket Paneli de Çoğunlukla Admin İle Yapılabilen İşlemleri Yapmaktadır. Genel Tek Fark DashBoard Yapısıdır.!
