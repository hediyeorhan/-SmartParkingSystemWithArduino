#  SmartParkingSystemWithArduino
 
<h2> 1.	PROJE KONUSU VE HEDEFİ </h2>
Proje, Arduino UNO [1] kartı ile geliştirilmiş bir gömülü sistem çalışmasıdır. Projenin konusu kapalı otopark sistemidir. Projede araç ekleme ve silme, yangın sistemi, havalandırma sistemi ve aydınlatma sistemi bulunmaktadır. Projenin hedefi otopark kapasitesi kadar araç ekleyebilme, araç silebilme, yangın sistemi kontrolünü sağlama, katlarda araç olması durumunda aydınlatma ve havalandırma sistemini çalıştırmaktır. Arduino UNO kartına bağlı duman sensörü MQ-2 [2] ile ortamdaki gaz durumu kontrol edilmektedir. Sensörden istenilen değerin üzerinde bir değer okunduğunda sistemde bulunan buzzer ile sesli uyarı verilmektedir. Ayrıca tasarlanan ara yüz ekranında da kullanıcı uyarılmaktadır. Tasarlanan ara yüz ekranından kullanıcı araç ekleme ve silme yapabilmektedir. Otopark kapasitesi dolduğunda ara yüz kullanıcının araç eklemesine izin vermemektedir. Otoparkta toplamda iki kat bulunmaktadır. Her kat için ayrı aydınlatma ve havalandırma sistemi tasarlanmıştır. Mevcut katta en az bir araç bulunuyorsa o katın aydınlatma sistemi ve havalandırma sistemi çalışmaktadır. Araç sayısının anlık durumu ile duman sensöründen okunan veriler tarih ve saat bilgileriyle birlikte veri tabanında tutulmaktadır. Şekil 1’ de proje için oluşturulan donanım ve yazılım görülmektedir.

 	 

Şekil 1: Proje donanımı ve yazılımı






<h2> 2.	PROJEDE KULLANILAN DONANIM VE YAZILIMLAR </h2>

<h3> 2.1.	  PROJEDE KULLANILAN DONANIMLAR VE TEKNİK ÖZELLİKLERİ </h3>

<h4> 2.1.1.  ARDUINO UNO </h4>

Arduino kartları arasında sıklıkla kullanılan kartlardan biridir. Bir sisteme entegre edilmesi kolay olduğu için pek çok kullanım alanları vardır. Akıllı ev sistemleri, robot sistemleri gibi gelişmiş sistemlerde kullanılabilir. Onun haricinde okul projelerinde bireysel küçük çaplı projelerde de kullanım kolaylığı açısından tercih edilmektedir. Elektronik devrelerin kontrol edilmesi ve çalıştırılmasını sağlar [3].
•	Dijital çıkış pini sayısı : 14
•	PWM çıkışı sayısı : 5
•	Analog giriş sayısı : 6
•	Çalışma gerilimi  : 5 V
•	Mikrodenetleyici : Atmega328
•	EEPROM : 1 KB
•	SRAM : 2 KB
•	Saat hızı : 16 MHz
•	I/O için akım : 40 mA
•	3.3 V çıkış için akım : 50 mA

<h4> 2.1.2.	DUMAN - GAZ SENSÖRÜ </h4>

  MQ serisi gaz sensörleri içerisinde gazı algılamaya duyarlı bir tel, ısıtıcı eleman ve bir yük direnci bulunmaktadır. Çalışma prensipleri genel olarak aynıdır. Isıtıcının etkisiyle ısınan metan gazı sensördeki telin üzerinden geçerek telin direncinin değişmesine etki eder. Analog direnç değerini, 0 ile 5V aralığına eş bir değere çevirmek için bir yük direnci kullanılır. Yük direnci pini, Arduino’nun analog giriş pinlerinden birine bağlanarak Arduino’ya bilgi aktarımı sağlanır [4].
•	Ölçme konsantrasyonu : 300 – 10000ppm Yanıcı Gaz
•	Besleme voltajı : < 24V 
•	Istıcı voltajı: 5.0V ± 0.2V 
•	Yük direnci : Ayarlanabilir
•	Isıtıcı güç sarfiyatı : < 900mW

<h4> 2.1.3.	 DC FAN  </h4>

DC fan, kurulan sistemi soğutmakta kullanılmaktadır. Projede belirlenen şartlar doğrultusunda ya da sürekli olarak çalıştırılabilir.



•	Çalışma gerilimi : 12VDC
•	Akım : 0.28A
•	Kablo sayısı : 2
•	Boyutlar : 120x120x25mm

<h4> 2.1.4.	 BUZZER </h4>

Geniş alanlara ses sinyalleri yaymaktadır. Projeye göre istenilen şartlar sağlandığında ses sinyalleri ile uyarı vermektedir. Alarm işlevi görmektedir [5].
•	Maksimum akım : 30 mA
•	10 cm’deki minimum ses çıkışı : 85 dB
•	Titreşim frekansı : 2300 +/- 300 Hz
•	Çalışma voltajı : 4-8V




<h4> 2.1.5.	 LED </h4>

Elektrik enerjisini ışığa dönüştüren yarı iletken bir devre elemanıdır. Belirli miktarda voltaj verildiğinde etrafa ışık saçmaktadırlar. Projede sarı, yeşil ve kırmızı renkte ledler kullanılmıştır.
•	Boyut : 5 mm
•	Çalışma voltajı : 1.5 - 3 V
•	Önerilen kullanım akımı : 16 - 18 mA
•	Maksimum akım : 20 mA

<h4> 2.1.6.	 JUMPER KABLO </h4>

Arduino ve breadboard arasında bağlantı yapılmasını sağlar. Örnek olarak projede kullanım alanlarından biri; arduino üzerinden gelen 5V, jumper kablolar ile breadboard üzerine aktarılmıştır ve 5V pini bu şekilde çoğaltılmıştır.

<h4> 2.1.7.	 BREADBOARD </h4>


Teknik terim olarak devre tahtası denilebilir. Üzerine sensör bağlanarak arduino kartı ile sensörün bağlantısının sağlanmasında kullanılmıştır.
•	Gerilim : 300 V
•	Akım : 3A ~ 5A
•	Boyut : 17cm x 5.5cm



<h3> 2.2.	PROJEDE KULLANILAN YAZILIMLAR </h3>
Projede kullanılan arduino kodları Arduino IDE [6] ortamında yazılmıştır. Arduino IDE, Arduino için entegre geliştirme ortamıdır. C ve C++ programlama dilleri ile yazılmış bir platformlar arası uygulamadır. Arduino uyumlu kartlara program yazmak ve yüklemek için kullanılır. Kullanıcıya kullanım kolaylığı sağlamak amacıyla C# programlama dili ile Visual Studio ortamında bir ara yüz geliştirilmiştir. Geliştirilen ara yüz ile arduino bağlantısı sağlanmıştır ve kullanıcı ara yüz üzerinden sistemi kontrol etmektedir. Sistemde bulunan verileri kayıt altına almak için Microsoft Sql Server veri tabanı kullanılmıştır. Oluşturulan ara yüz dosyası içerisinde sql sorguları ile veri tabanı bağlantısı sağlanmıştır. Sistemde bulunan veriler veri tabanına kayıt edilmiştir.



<h2> 3.	PROJENİN YAPIM AŞAMALARI </h2>
Projenin planlanması için olarak bir akış şeması oluşturulmuştur. Projedeki kodların çalışma mantığı ve sırası Şekil 2’ de akış şemasında görülmektedir.

 
Şekil 2: Akış şeması

Projede öncelikle arduino kodlarının akışı planlanmıştır ve arduino kodları yazılmıştır. Arduino kodunda duman sensöründen gelen değerin iki saniye aralıklarla okunması sağlanmıştır. Duman sensörü analog girişten değer okumaktadır. İki saniye aralıklarla değer okunması için arduino koduna bir timer eklenmiştir. Şekil 3’ te gerekli timer ayarları ve iki saniye aralıklarla değer okunması görülmektedir. Sensörden okunan değer kod içerisinde belirlenen değerden fazla olursa buzzer tetiklenmektedir ve uyarı vermektedir.
 
 
Şekil 3: Timer ile iki saniye aralıklarla değer okunması


Duman sensöründen değer okunurken kullanıcıdan araç ekleme ve silme için değer beklenmektedir. Araç ekleme ve silme arduino kodu içerisinde 1 ve 0’lar ile kontrol edilmektedir. 1 değeri ile araç eklenmektedir, 0 değeri ile araç silinmektedir. Araç sayısı 1’den büyük olduğunda birinci kat için aydınlatma ve havalandırma sistemi çalışmaktadır. Araç sayısı 3’den büyük olduğunda ikinci kat için de aydınlatma ve havalandırma sistemi çalışmaktadır. 
Algoritmanın kodlanması bittikten sonra donanım üzerinde sensörler ve arduino bağlantılı hale getirilmiştir. Arduino üzerindeki sensörlerin bağlantısı Fritzing programı kullanılarak görselleştirilmiştir. Şekil 4’ te Fritzing programında çizilen devre şeması görülmektedir.

 
Şekil 4: Devre şeması
Projenin donanımsal bağlantıları sağlandıktan sonra C# ile ara yüz tasarımı yapılmıştır. Ara yüzde ilk olarak arduino ile bağlantı sağlanmıştır. Bağlantının sağlanması ve kesilmesi için iki adet buton oluşturulmuştur. Şekil 5’ te C# ile COM bağlantısı görülmektedir.
 	 
Şekil 5: Arduino bağlantısının sağlanması

Ara yüzde arduino bağlantısının sağlanması Şekil 6’ da görülmektedir. Bağlantı sağlandığında bağlantı başlat butonu aktifliğini kaybetmektedir. Bağlantı yokken bağlantı kes butonu aktifliğini kaybetmektedir.
 	 
Şekil 6: Bağlantı sağlandı / kesildi


Arduino bağlantısı sağlandıktan sonra duman sensöründen gelen değer ara yüze aktarılmıştır. Sensörden gelen değer belirli bir seviyenin üzerine çıktığında ara yüz kullanıcıya uyarı mesajı vermektedir. Sensörden okunan değer ve ara yüzün kullanıcıya verdiği uyarı mesajı Şekil 7’ de görülmektedir. Şekil 7’ ye bakıldığında sensörden 403 değeri okunmuştur. Tehlikeli bir değer olduğu için kırmızı renktedir.
 
Şekil 7: Sensörden veri alınması ve uyarı mesajı

Kullanıcı ara yüzden kolaylıkla araç ekleme ve silme yapabilmektedir. Araç ekle butonuna tıklandığında seri porta 1 değeri yazılmaktadır ve araç sayısı artırılmaktadır. Araç sil butonuna tıklandığında seri porta 0 değeri yazılmaktadır ve araç sayısı azaltılmaktadır. Otopark boş olduğunda araç sil butonu aktifliğini kaybetmektedir. Otopark tamamen dolduğunda ise araç ekle butonu aktifliğini kaybetmektedir. Ara yüzde birinci kat ve ikinci kat hakkında da ekstra bilgi verilmektedir. Şekil 8’ de otopark tamamen dolu olduğunda ara yüzün çalışma şekli görülmektedir.

 
Şekil 8: Otoparkın dolu olduğu durumda ara yüz

Araç sayısına bağlı olarak birinci kat aydınlatması ve havalandırması, ikinci kat aydınlatması ve havalandırması açılmaktadır. Otopark dolduğunda ise kırmızı uyarı ışığı yanmaktadır. Şekil 9’ da ara yüz ekranında görülen araç sayısına bağlı olarak birinci kat aydınlatmasının açıldığı görülmektedir. 

 
Şekil 9: Birinci kat için aydınlatma ve havalandırma sistemi çalışması


Şekil 10’ da ikinci katta araç olduğunda ikinci kat aydınlatmasının açıldığı ve otopark maksimum araç kapasitesine ulaştığında kırmızı uyarı ışığının yandığı görülmektedir.

 
Şekil 10: İkinci kat için aydınlatma ve havalandırma sistemi çalışması 
 Otopark dolu uyarısı

Ara yüzde yapılan tüm bu değişiklikler; araç sayısındaki değişimler ve sensörden okunan değerler veri tabanında kayıt edilmektedir. Şekil 11’ de kullanılan veri tabanı programı görülmektedir.

 
Şekil 11: Kullanılan veri tabanı - Mssql

Veri tabanında verileri kaydetmek için oluşturulan tablo yapısı Şekil 12’ de görülmektedir.

 
Şekil 12: Kullanılan tablo yapısı

Sql sorgusu ile kod içerisinde alınan veriler tabloya eklenmiştir. Şekil 13’ te tabloya kayıt edilen verilerin bir kısmı görülmektedir.
 
Şekil 13: Veri tabanında kayıtlı tutulan verilerin bir kısmı

Sonuç olarak öncelikle projenin Arduino kodu yazılmıştır, sonrasında donanımsal olarak sistem kurulmuştur ve kod test edilmiştir. Kullanıcı kolaylığı olması için bir ara yüz tasarımı yapılmıştır. Tasarlanan ara yüz içerisindeki veriler veri tabanına kayıt edilmiştir.


Projenin çalışma aşamasından bazı görseller aşağıda görülmektedir:
 
Şekil 14: Projenin donanım kısmı

 
Şekil 15: İstenilen şartlara göre donanımın çalışması

 
Şekil 16: İstenilen şartlara göre donanımın çalışması


<h2> KAYNAKÇA </h2>
[1]	Arduino Datasheet. Available: https://docs.arduino.cc/resources/datasheets/A000066-datasheet.pdf

[2]	MQ-2 Sensör Datasheet. Available: https://www.mouser.com/datasheet/2/321/605-00008-MQ-2-Datasheet-370464.pdf

[3]	Arduino UNO. Available: https://maker.robotistan.com/arduino-uno/

[4]	MQ2 - Duman Sensörü. Available: https://maker.robotistan.com/arduino-mq-gaz-sensorleri/

[5]	Buzzer. Available: https://maker.robotistan.com/arduino-dersleri-9-buzzer-ile-ses-cikisi-alma-2/

[6]	Arduino IDE. Available: https://tr.wikipedia.org/wiki/Arduino_IDE

