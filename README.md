# :car: ReCapProject Araba Kiralama Sistemi :car:

## :gem: Introduction

### ReCapProject Engin Demiroğ tarafından düzenlenen Nitelikli Yazılım Geliştirici Yetiştirme Kampı Araç Kiralama Projesidir.

##### Proje:

  * Entities 
  * DataAccess 
  * Business 
  * Core
  * ConsoleUI
  katmanlarından oluşan bir araba kiralama projesidir.
  
## :earth_africa: Ecosystem
 * EntityFramework
 * ConsoleTables
 * SQL Server

## :construction_worker: Layers

### Entities

Bu katmanda proje boyunca kullanacağımız ana classlarımızı belirliyoruz yani gerçek nesnelerimizi belirlediğimiz yer burası. Burada belirlediğimiz nesnelerimiz ile veri tabanında kayıtlı olan nesnelerimizi eşleştiriyoruz. 

### Data Access

Bu katmanda sadece veritabanı işlemleri yapılmaktadır. Bu katmanın görevi veriyi ekleme, silme, güncelleme ve veritabanından çekme işlemidir. Bu katmanda bu işlemlerden başka herhangi bir işlem yapılmamaktadır.

### Business

Bu katmanda iş yüklerimizi yazıyoruz. Bu katman Data Access tarafından projeye çekilmiş olan verileri alarak işleyecek olan katmandır. Uygulamalarımızda Data Access katmanını direk olarak kullanmayız. Araya Business katmanını koyarak bizim yerimize Business’ın yapmasını sağlarız. Kullanıcıdan gelen veriler öncelikle Business katmanına gider oradan işlenerek Data Access katmanına aktarılır. Business katmanında ayrıca bu verilere kimlerin erişeceğini belirtiyoruz. Örneğin Arge ve IK bölümü var. Arge bölümünün veri tabanına ekleme işlemleri yapmasını istiyoruz ancak IK bölümünün sadece verileri çekmesini istiyorsak bunu Business Katmanında gerçekleştiriyoruz.

## Core

Bu katmanda tüm projelerin ortak olarak kullanabileceği base classları bulunduruyoruz.

## Console UI

Bu katman kullanıcı ile  etkileşimin yapıldığı katmandır. Kullanıcı ile etkileşim Console arayüzü ile yapılmaktadır.

## :exclamation: Updates
 * EntityFramework eklentisi eklendi.
 * Proje artık bir database üzerinden çalışmakta.
 * Color ve Brand objeleri eklendi.
 * Core Katmanı Eklendi.
 * DTO (Data Transfer Object) Eklendi.
 
### Console menu tasarımı aşağıda ki gibidir. Menu geçişleri yön okları yardımı ile yapılabilir.

![AnaMenu](https://user-images.githubusercontent.com/71039908/107114171-03413700-6875-11eb-8362-3f1078a77a81.PNG)

### Araç listeleme aşağıda ki gibi tablo şeklinde yapılmıştır.

![Table](https://user-images.githubusercontent.com/71039908/107200979-77144880-6a09-11eb-9cfa-340d2247b506.PNG)

### Yukarıda ki tabloyu kullanabilmek için ConsoleTables adlı bir paketi kullandım. Sizde denemek isterseniz aşağıda ki adımları uygulayarak paketi yükleyebilirsiniz.

   ##### Menuden Tools sekmesini açarak görselde gösterilen NuGet Package Manager sekmesine gelin ve ardından Package Manager Console sekmesini tıklayın.
   
    
![Packet](https://user-images.githubusercontent.com/71039908/106589742-696c4800-655d-11eb-9290-1d2012357f02.PNG)

   ##### Açılan konsola görselde belirtilen kodu girerek paketi yükleyin.
    
![Console](https://user-images.githubusercontent.com/71039908/106589782-75580a00-655d-11eb-8c48-b98b1bcf607e.PNG)

### Projede kullanılan tüm klasör ve dosyalar aşağıda ki gibidir:

![Klasor](https://user-images.githubusercontent.com/71039908/107201072-8e533600-6a09-11eb-9961-ef4638ef7f13.PNG)


### Proje Geliştirilmeye devam edilecektir.

