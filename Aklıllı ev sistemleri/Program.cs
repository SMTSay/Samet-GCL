
using System;
using System.Collections.Generic;
using NAudio.Wave;
using System.Linq;

class ElektronikEsya
{
    // Elektronik eşyanın adı
    public string Ad { get; private set; }

    // Elektronik eşyanın ışıklı olup olmadığını belirten özellik
    public bool IsikliMi { get; private set; }

    // Elektronik eşyanın açık/kapalı durumunu tutan özellik
    public bool AcikMi { get; private set; }

    // Elektronik eşya sınıfının kurucusu
    public ElektronikEsya(string ad, bool isikliMi)
    {
        Ad = ad; // Eşyanın adı atanır
        IsikliMi = isikliMi; // Eşyanın ışıklı olup olmadığı atanır
        AcikMi = false; // Varsayılan olarak eşya kapalı başlar
    }

    // Eşyanın durumunu güncelleyen metot (açık/kapalı)
    public void DurumGuncelle(bool durum)
    {
        AcikMi = durum; // Açık/kapalı durumu güncellenir
        Console.WriteLine($"{Ad} {(AcikMi ? "açıldı" : "kapandı")}.");
    }
}

class Oda
{
    // Odanın adı
    public string Ad { get; private set; }

    // Odanın sıcaklık değeri
    public double Sicaklik { get; private set; }

    // Odadaki elektronik eşyaların listesi
    private List<ElektronikEsya> Esyalar { get; set; }

    // Oda sınıfının kurucusu
    public Oda(string ad, double baslangicSicaklik)
    {
        Ad = ad; // Oda adı atanır
        Sicaklik = baslangicSicaklik; // Başlangıç sıcaklığı atanır
        Esyalar = new List<ElektronikEsya>(); // Elektronik eşya listesi başlatılır
    }

    // Oda sıcaklığını değiştiren metot
    public void SicaklikDegistir(double yeniSicaklik)
    {
        // Sıcaklık değerinin 15 ile 30 arasında olup olmadığını kontrol eder
        if (yeniSicaklik < 15 || yeniSicaklik > 30)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hatalı giriş: Sıcaklık değeri 15 ile 30 arasında olmalıdır.");
            Console.ResetColor();
        }
        else
        {
            Sicaklik = yeniSicaklik; // Sıcaklık değeri güncellenir
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Ad} odasının sıcaklığı {Sicaklik}°C olarak güncellendi.");
            Console.ResetColor();
        }
    }

    // Odaya yeni bir eşya ekleyen metot
    public void EsyaEkle(ElektronikEsya esya)
    {
        Esyalar.Add(esya); // Eşya listeye eklenir
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{esya.Ad} {Ad} odasına eklendi.");
        Console.ResetColor();
    }

    // Odadaki eşyaların durumlarını listeleyen metot
    public void EsyaDurumlariniListele()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n{Ad} odası (Sıcaklık: {Sicaklik}°C):");
        foreach (var esya in Esyalar)
        {
            Console.WriteLine($"- {esya.Ad}: {(esya.AcikMi ? "Açık" : "Kapalı")}");
        }
        Console.ResetColor();
    }

    // Odadaki bir eşyanın açık/kapalı durumunu güncelleyen metot
    public void EsyaDurumGuncelle(int esyaIndex, bool durum)
    {
        // Geçerli bir eşya numarası girilip girilmediğini kontrol eder
        if (esyaIndex >= 0 && esyaIndex < Esyalar.Count)
        {
            Esyalar[esyaIndex].DurumGuncelle(durum); // Durumu günceller
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hatalı seçim: Geçerli bir eşya numarası giriniz.");
            Console.ResetColor();
        }
    }

    // Odadaki eşyaların listesini döndüren metot
    public List<ElektronikEsya> GetEsyalar()
    {
        return Esyalar; // Elektronik eşya listesini döndürür
    }
    public void EsyaSil(ElektronikEsya esya)
    {
        Esyalar.Remove(esya);
    }

}


class Program
{
    // Kullanıcı bilgilerini tutan bir sözlük
    static Dictionary<string, string> kullanicilar = new Dictionary<string, string>(); // Kullanıcı adı ve şifrelerin tutulduğu sözlük
    static string kayitAnaSifresi = "Y1S2aZ"; // Yeni kullanıcı kayıtları için gerekli ürün anahtarı

    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                // Ekranı temizle ve başlık kısmını yazdır
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("=========================================");
                Console.ResetColor();
                Console.WriteLine("         \u001b[1;33m KULLANICI GİRİŞ EKRANI  \u001b[0m");
                Console.WriteLine("=========================================");

                // Menü seçeneklerini ekrana yazdır
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. \u001b[1;34mKayıt Ol\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2. \u001b[1;34mGiriş Yap\u001b[0m");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3. \u001b[1;34mÇıkış\u001b[0m");
                Console.ResetColor();

                // Kullanıcıdan seçim girişi al
                Console.ResetColor();
                Console.Write("\nLütfen seçmek istediğiniz öğenin numarasını tuşlayınız: ");
                string secim = Console.ReadLine();

                // Kullanıcı seçimine göre işlemleri gerçekleştir
                switch (secim)
                {
                    case "1":
                        KayitOl(); // Yeni kullanıcı kaydı yap
                        break;
                    case "2":
                        if (GirisYap()) // Kullanıcı giriş yaparsa menüye yönlendir
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Giriş başarılı! Menüye yönlendiriliyorsunuz...");
                            Console.ResetColor();
                            Console.ReadKey();
                            ProgramMenu(); // Kullanıcı menüsüne yönlendirme
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            HataMesaji("Giriş başarısız. Lütfen kullanıcı adı ve şifrenizi kontrol ediniz.");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\u001b[1;33mÇıkış yapılıyor. Güle güle! \u001b[0m");
                        Console.ResetColor();
                        return; // Programdan çıkış
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        HataMesaji("Hatalı seçim: Lütfen 1, 2 veya 3 seçeneklerinden birini giriniz.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
                Console.ReadKey(); // Kullanıcının mesajı görmesi için bekleme
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                HataMesaji($"Bir hata oluştu: {ex.Message}"); // Hata durumunda mesaj yazdır
                Console.ResetColor();
            }
        }
    }

    // Kullanıcı giriş işlemini gerçekleştiren metot
    static bool GirisYap()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("=== Giriş Yap ===");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Kullanıcı adı: ");
        Console.ResetColor();
        string kullaniciAd = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Şifre: ");
        Console.ResetColor();
        string sifre = Console.ReadLine();

        // Kullanıcı adı ve şifre kontrolü
        if (kullanicilar.TryGetValue(kullaniciAd, out var storedSifre) && storedSifre == sifre)
        {
            return true; // Giriş başarılı
        }

        return false; // Giriş başarısız
    }

    // Yeni kullanıcı kaydı işlemini gerçekleştiren metot
    static void KayitOl()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("=== Kayıt Ol ===");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Lütfen kayıt olmak için size ait 6 haneli şifreyi giriniz: ");
        Console.ResetColor();
        string girilenAnaSifre = Console.ReadLine();

        if (girilenAnaSifre != kayitAnaSifresi) // Ürün anahtarı kontrolü
        {
            Console.ForegroundColor = ConsoleColor.Red;
            HataMesaji("Hatalı şifre. Kayıt işlemi iptal edildi.");
            Console.ResetColor();
            return;
        }

        string kullaniciAd;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Kullanıcı adı belirleyin (en az bir harf içermelidir): ");
            Console.ResetColor();
            kullaniciAd = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(kullaniciAd) && kullaniciAd.Any(char.IsLetter)) // Kullanıcı adı geçerliliği kontrolü
            {
                if (kullanicilar.ContainsKey(kullaniciAd))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    HataMesaji("Bu kullanıcı adı zaten alınmış. Lütfen farklı bir kullanıcı adı belirleyiniz.");
                    Console.ResetColor();
                }
                else
                {
                    break; // Geçerli bir kullanıcı adı
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                HataMesaji("Geçersiz kullanıcı adı. Lütfen en az bir harf içeren bir kullanıcı adı giriniz.");
                Console.ResetColor();
            }
        }

        string sifre;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Şifre belirleyin (en az 8 karakter, bir büyük harf, bir küçük harf ve bir rakam içermelidir): ");
            Console.ResetColor();
            sifre = Console.ReadLine();
            if (SifreKontrol(sifre)) // Şifre kriterlerini kontrol eden metodun çağrılması
                break;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            HataMesaji("Şifre geçerli değil. Lütfen belirtilen kriterlere uygun bir şifre giriniz.");
            Console.ResetColor();

        }

        kullanicilar.Add(kullaniciAd, sifre); // Yeni kullanıcı eklenmesi
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Kayıt başarılı! Şimdi giriş yapabilirsiniz.");
        Console.ResetColor();
    }

    // Şifre kriterlerini kontrol eden yardımcı metot
    static bool SifreKontrol(string sifre)
    {
        return sifre.Length >= 8 // En az 8 karakter
            && sifre.Any(char.IsUpper) // En az bir büyük harf
            && sifre.Any(char.IsLower) // En az bir küçük harf
            && sifre.Any(char.IsDigit); // En az bir rakam
    }

    // Hata mesajlarını ekrana yazdıran yardımcı metot
    static void HataMesaji(string mesaj)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mesaj);
        Console.ResetColor();
    }


    // Kullanıcıdan string türünde bir girdi alan ve hatalı girişlerde uyarı mesajı gösteren fonksiyon
    static string StringGirdiAl(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj); // Kullanıcıya mesaj gösterilir
            string girdi = Console.ReadLine(); // Kullanıcıdan girdi alınır
            if (!double.TryParse(girdi, out _)) // Girdi yalnızca harflerden oluşuyorsa kabul edilir
                return girdi;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hatalı giriş: Lütfen yalnızca harflerden oluşan bir isim giriniz.");
                Console.ResetColor();
            }
        }
    }

    // Kullanıcıdan tam sayı türünde bir girdi alan ve belirli bir aralıkta olmasını kontrol eden fonksiyon
    static int IntGirdiAl(string mesaj, int minDeger = 0, int maxDeger = 100)
    {
        int deger;
        while (true)
        {
            Console.Write(mesaj); // Kullanıcıya mesaj gösterilir
            if (int.TryParse(Console.ReadLine(), out deger) && deger >= minDeger && deger <= maxDeger) // Girdi doğrulanır
                return deger;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Geçersiz değer. Lütfen {minDeger} ile {maxDeger} arasında bir tam sayı giriniz.");
            Console.ResetColor();
        }
    }

    // Kullanıcıdan double türünde bir girdi alan ve belirli bir aralıkta olmasını kontrol eden fonksiyon
    static double DoubleGirdiAl(string mesaj, double min, double max)
    {
        while (true)
        {
            Console.Write(mesaj); // Kullanıcıya mesaj gösterilir
            try
            {
                double sonuc = double.Parse(Console.ReadLine()); // Kullanıcıdan girdi alınır
                if (sonuc >= min && sonuc <= max) // Girdi doğrulanır
                    return sonuc;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Hatalı giriş: Değer {min} ile {max} arasında olmalıdır.");
                    Console.ResetColor();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hatalı giriş: Lütfen geçerli bir sayı giriniz.");
                Console.ResetColor();
            }
        }
    }

    // Kullanıcıdan eşya bilgilerini alarak mevcut bir odaya eşya ekleyen fonksiyon
    static void YeniEsyaEkle(List<Oda> odalar)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string odaAdi = StringGirdiAl("Eşya eklemek istediğiniz odanın adını giriniz: "); // Kullanıcıdan oda adı alınır
        Console.ResetColor();
        var oda = odalar.Find(o => o.Ad == odaAdi); // Oda listesinde arama yapılır
        Console.Clear();

        if (oda != null) // Oda bulunduysa
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Seçilen oda: {odaAdi}");
            Console.WriteLine("===============================");
            Console.ResetColor();

            int esyaSayisi = IntGirdiAl("Eklemek istediğiniz eşya sayısını giriniz (1-100): ", 1, 100); // Eklenecek eşya sayısı alınır
            Console.Clear();

            for (int i = 0; i < esyaSayisi; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string yeniEsyaAdi = StringGirdiAl($"Eşya {i + 1} adını giriniz: "); // Eşya adı alınır
                Console.ResetColor();

                bool isikliMi = yeniEsyaAdi.ToLower() == "lamba" || yeniEsyaAdi.ToLower() == "televizyon"; // Varsayılan ışıklı eşya tanımı
                ElektronikEsya yeniEsya = new ElektronikEsya(yeniEsyaAdi, isikliMi); // Yeni eşya oluşturulur
                oda.EsyaEkle(yeniEsya); // Odaya eşya eklenir

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\u001b[1;32m{yeniEsyaAdi} başarıyla {odaAdi} odasına eklendi.\u001b[0m");
                Console.ResetColor();
            }
        }
        else // Oda bulunamadıysa
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\u001b[1;31mBelirttiğiniz isimde bir oda bulunamadı.\u001b[0m");
            Console.ResetColor();
        }
    }

    // Kullanıcıdan oda bilgilerini alarak yeni bir oda ekleyen fonksiyon
    static void YeniOdaEkle(List<Oda> odalar)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("===============================");
        Console.ResetColor();
        Console.WriteLine($"\u001b[1;33m Yeni Oda bilgilerini giriniz:  \u001b[0m");
        Console.WriteLine("===============================");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string yeniOdaAdi = StringGirdiAl("Yeni odanın adını giriniz: "); // Oda adı alınır
        Console.ResetColor();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("===============================");
        Console.ResetColor();
        Console.WriteLine($"\u001b[1;33m Yeni Oda bilgilerini giriniz:  \u001b[0m");
        Console.WriteLine("===============================");
        Console.ForegroundColor = ConsoleColor.Yellow;
        double yeniSicaklik = DoubleGirdiAl("Yeni odanın sıcaklığını (15-30°C arası) giriniz: ", 15, 30); // Oda sıcaklığı alınır
        Console.ResetColor();
        Console.Clear();

        Oda yeniOda = new Oda(yeniOdaAdi, yeniSicaklik); // Yeni oda oluşturulur
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("===============================");
        Console.ResetColor();
        Console.WriteLine($"\u001b[1;33m Yeni oda Eşya bilgileri  \u001b[0m");
        Console.WriteLine("===============================");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int yeniEsyaSayisi = IntGirdiAl("Bu oda için kaç eşya eklemek istiyorsunuz? ", 1, 100); // Eklenecek eşya sayısı alınır
        Console.ResetColor();
        Console.Clear();
        for (int i = 0; i < yeniEsyaSayisi; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===============================");
            Console.ResetColor();
            Console.WriteLine($"\u001b[1;33m Yeni oda Eşya bilgileri  \u001b[0m");
            Console.WriteLine("===============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string yeniEsyaAdi = StringGirdiAl($"Eşya {i + 1} adını giriniz: "); // Eşya adı alınır
            Console.ResetColor();
            bool isikliMi = yeniEsyaAdi.ToLower() == "lamba" || yeniEsyaAdi.ToLower() == "televizyon"; // Varsayılan ışıklı eşya tanımı
            ElektronikEsya yeniEsya = new ElektronikEsya(yeniEsyaAdi, isikliMi); // Yeni eşya oluşturulur
            yeniOda.EsyaEkle(yeniEsya); // Odaya eşya eklenir
            Console.Clear();
        }

        odalar.Add(yeniOda); // Oda listeye eklenir
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\u001b[1;32m{yeniOdaAdi} başarıyla eklendi.\u001b[0m");
        Console.ResetColor();
    }

    // Programın ana ekranına dönmesini sağlayan fonksiyon
    static void GirisEkraninaDon()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\u001b[1;34mGiriş ekranına dönülüyor...\u001b[0m");
        Console.ResetColor();
        Main(null); // Programın ana ekranını yeniden çalıştırır
    }
    static void OdaSil(List<Oda> odalar)
    {
        // Kullanıcıya mevcut odaları listeler
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Mevcut odalar:");
        Console.ResetColor();
        for (int i = 0; i < odalar.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {odalar[i].Ad}");
        }
        Console.ResetColor();

        // Silinecek odanın adını sorar
        Console.ForegroundColor = ConsoleColor.Yellow;
        string odaAdi = StringGirdiAl("Silmek istediğiniz odanın adını giriniz: ");
        Console.ResetColor();

        // Girilen ad ile eşleşen oda var mı kontrol edilir
        var oda = odalar.Find(o => o.Ad == odaAdi);

        

        if (oda != null)
        {
            // Oda listeden kaldırılır
            odalar.Remove(oda);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\u001b[1;32m{odaAdi} başarıyla silindi.\u001b[0m");
            Console.ResetColor();
        }
        else
        {
            // Oda bulunamazsa hata mesajı
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\u001b[1;31mHata: Belirttiğiniz isimde bir oda bulunamadı.\u001b[0m");
            Console.ResetColor();
        }



    }
    static void EsyaSil(List<Oda> odalar)
    {
        // Kullanıcıya mevcut odaları listeler
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Mevcut odalar:");
        for (int i = 0; i < odalar.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {odalar[i].Ad}");
        }
        Console.ResetColor();

        // Kullanıcıdan oda adı alınır
        Console.ForegroundColor = ConsoleColor.Yellow;
        string odaAdi = StringGirdiAl("Eşya silmek istediğiniz odanın adını giriniz: ");
        Console.ResetColor();

        // Girilen ada sahip oda bulunur
        var oda = odalar.Find(o => o.Ad == odaAdi);
        if (oda != null)
        {
            // Oda içindeki eşyalar listelenir
            var esyalar = oda.GetEsyalar();
            if (esyalar.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\u001b[1;31mBu odada hiç eşya yok.\u001b[0m");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{odaAdi} odasındaki mevcut eşyalar:");
            for (int i = 0; i < esyalar.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {esyalar[i].Ad}");
            }
            Console.ResetColor();

            // Kullanıcıdan silinecek eşya seçimi alınır
            Console.ForegroundColor = ConsoleColor.Yellow;
            int esyaIndex = IntGirdiAl("Silmek istediğiniz eşyanın numarasını giriniz: ") - 1;
            Console.ResetColor();

            // Girilen numara doğrulanır
            if (esyaIndex >= 0 && esyaIndex < esyalar.Count)
            {
                var silinecekEsya = esyalar[esyaIndex];
                oda.EsyaSil(silinecekEsya);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\u001b[1;32m{silinecekEsya.Ad} başarıyla silindi.\u001b[0m");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\u001b[1;31mHata: Geçerli bir eşya numarası giriniz.\u001b[0m");
                Console.ResetColor();
            }
        }
        else
        {
            // Oda bulunamazsa hata mesajı
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\u001b[1;31mHata: Belirttiğiniz isimde bir oda bulunamadı.\u001b[0m");
            Console.ResetColor();
        }
    }




    static void ProgramMenu()
    {
        // Konsolu temizle ve hoş geldin mesajını göster
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("===============================");
        Console.ResetColor();
        Console.WriteLine("\u001b[1;33m Akıllı Ev Sistemine Hoş Geldiniz!  \u001b[0m");
        Console.WriteLine("===============================");

        // Odaları tutacak listeyi oluştur
        List<Oda> odalar = new List<Oda>();

        // Kullanıcıdan eklemek istediği oda sayısını al
        Console.ForegroundColor = ConsoleColor.Yellow;
        int odaSayisi = IntGirdiAl("Kaç oda eklemek istiyorsunuz? ");
        Console.ResetColor();

        // Kullanıcının belirttiği sayıda oda ekle
        for (int i = 0; i < odaSayisi; i++)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===============================");
            Console.ResetColor();
            Console.WriteLine($"\u001b[1;33m {i + 1}. Oda bilgilerini giriniz:  \u001b[0m");
            Console.WriteLine("===============================");

            // Kullanıcıdan oda adı ve sıcaklık bilgilerini al
            Console.ForegroundColor = ConsoleColor.Yellow;
            string odaAdi = StringGirdiAl($"Oda {i + 1} ismini giriniz: ");
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===============================");
            Console.ResetColor();
            Console.WriteLine($"\u001b[1;33m {i + 1}. Oda bilgilerini giriniz:  \u001b[0m");
            Console.WriteLine("===============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double baslangicSicaklik = DoubleGirdiAl($"{odaAdi} sıcaklığını (15-30°C arası) giriniz: ", 15, 30);
            Oda yeniOda = new Oda(odaAdi, baslangicSicaklik);
            Console.ResetColor();
            Console.Clear();

            // Kullanıcıdan oda için eşya sayısını al ve eşyaları ekle
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===============================");
            Console.ResetColor();
            Console.WriteLine($"\u001b[1;33m {i + 1}. Oda bilgilerini giriniz:  \u001b[0m");
            Console.WriteLine("===============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int esyaSayisi = IntGirdiAl($"{odaAdi} için kaç eşya eklemek istiyorsunuz? ");
            Console.ResetColor();
            Console.Clear();

            // Eşyaların adlarını ve durumlarını kullanıcıdan al ve odaya ekle
            for (int j = 0; j < esyaSayisi; j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("===============================");
                Console.ResetColor();
                Console.WriteLine($"\u001b[1;33m {i + 1}. Oda Eşya bilgilerini giriniz:  \u001b[0m");
                Console.WriteLine("===============================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string esyaAdi = StringGirdiAl($"Eşya {j + 1} adını giriniz: ");
                bool isikliMi = esyaAdi.ToLower() == "lamba" || esyaAdi.ToLower() == "televizyon";
                ElektronikEsya yeniEsya = new ElektronikEsya(esyaAdi, isikliMi);
                yeniOda.EsyaEkle(yeniEsya);
                Console.ResetColor();
            }

            // Odayı listeye ekle
            odalar.Add(yeniOda);
        }

        // Ana menüyü döngü içinde göster
        Console.Clear();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n=========================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("              MENÜ            ");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            // Menü seçeneklerini göster
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1.\u001b[1;29m Oda sıcaklığını değiştir\u001b[0m");
            Console.ResetColor();
            Console.WriteLine("2.\u001b[1;29m Eşyaların durumunu değiştir\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3.\u001b[1;29m Eşyaları ve odaların sıcaklıklarını listele\u001b[0m");
            Console.ResetColor();
            Console.WriteLine("4.\u001b[1;29m Yeni eşya ekleme\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("5.\u001b[1;29m Yeni oda ekleme\u001b[0m");
            Console.ResetColor();
            Console.WriteLine("6.\u001b[1;29m Oda sil\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("7.\u001b[1;29m Eşya sil\u001b[0m");
            Console.ResetColor();
            Console.WriteLine("8.\u001b[1;29m Müzik (Aç-Kapa)\u001b[0m");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("9.\u001b[1;29m Giriş ekranına dön\u001b[0m");
            Console.ResetColor();
            Console.WriteLine("10.\u001b[1;29m Çıkış\u001b[0m");
            





            string secim = Console.ReadLine(); // Kullanıcıdan bir seçim al  
            Console.Clear(); // Ekranı temizle  

            switch (secim) // Kullanıcının yaptığı seçime göre işlemleri belirle  
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Yellow; // Konsol yazı rengini sarı yap  
                    string odaAdi = StringGirdiAl("Sıcaklığını değiştirmek istediğiniz odanın adını giriniz: "); // Odanın adını kullanıcıdan al  
                    var oda = odalar.Find(o => o.Ad == odaAdi); // Belirtilen adı taşımayan odayı bul  
                    Console.Clear(); // Ekranı temizle  

                    if (oda != null) // Oda bulunduysa  
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                        double yeniSicaklik = DoubleGirdiAl("Yeni sıcaklığı (15-30°C arası) giriniz: ", 15, 30); // Kullanıcıdan yeni sıcaklığı al  
                        oda.SicaklikDegistir(yeniSicaklik); // Odanın sıcaklığını güncelle  
                        Console.Clear(); // Ekranı temizle  
                    }
                    else // Oda bulunamadıysa  
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                        Console.WriteLine("Hatalı seçim: Belirttiğiniz isimde bir oda bulunamadı."); // Hata mesajı göster  
                        Console.ResetColor(); // Rengi sıfırla  
                    }
                    break;

                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                    odaAdi = StringGirdiAl("Durumunu değiştirmek istediğiniz odanın adını giriniz: "); // Odanın adını kullanıcıdan al  
                    oda = odalar.Find(o => o.Ad == odaAdi); // Odayı bul  
                    Console.ResetColor(); // Rengi sıfırla  

                    if (oda != null) // Oda bulunduysa  
                    {
                        var esyalar = oda.GetEsyalar(); // Odanın eşyalarını al  
                        for (int i = 0; i < esyalar.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {esyalar[i].Ad}"); // Eşyaların adını numaralı olarak göster  
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                        int esyaIndex = IntGirdiAl("Durumunu değiştirmek istediğiniz eşyanın numarasını giriniz: ") - 1; // Kullanıcıdan eşya numarasını al  
                        Console.ResetColor(); // Rengi sıfırla  

                        if (esyaIndex >= 0 && esyaIndex < esyalar.Count) // Geçerli bir eşya numarasıysa  
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                            string durum = StringGirdiAl("Eşya için işlem seçiniz (Aç/Kapat): ").ToLower(); // Kullanıcıdan aç/kapat durumu al  
                            if (durum == "aç" || durum == "a") // "aç" veya "a" komutu için  
                            {
                                oda.EsyaDurumGuncelle(esyaIndex, true); // Eşya durumunu aç  
                            }
                            else if (durum == "kapat" || durum == "k") // "kapat" veya "k" komutu için  
                            {
                                oda.EsyaDurumGuncelle(esyaIndex, false); // Eşya durumunu kapat  
                            }
                            else // Hatalı giriş  
                            {
                                Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                                Console.WriteLine("Hatalı seçim: Lütfen 'Aç' veya 'Kapat' yazınız."); // Hata mesajı göster  
                                Console.ResetColor(); // Rengi sıfırla  
                            }
                            Console.ResetColor(); // Rengi sıfırla  
                        }
                        else // Geçersiz eşya numarası  
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                            Console.WriteLine("Hatalı seçim: Geçerli bir eşya numarası giriniz."); // Hata mesajı göster  
                            Console.ResetColor(); // Rengi sıfırla  
                        }
                    }
                    else // Oda bulunamadıysa  
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                        Console.WriteLine("Hatalı seçim: Belirttiğiniz isimde bir oda bulunamadı."); // Hata mesajı göster  
                        Console.ResetColor(); // Rengi sıfırla  
                    }
                    break;

                case "3":
                    foreach (var o in odalar) // Tüm odalar için  
                    {
                        o.EsyaDurumlariniListele(); // Odanın eşya durumlarını listele  
                    }
                    break;

                case "4":
                    YeniEsyaEkle(odalar); // Yeni eşya ekleme fonksiyonu  
                    break;

                case "5":
                    YeniOdaEkle(odalar); // Yeni oda ekleme fonksiyonu  
                    break;
                case "6":
                    OdaSil(odalar);
                    break;

                case "7":
                    EsyaSil(odalar);
                    break;

                case "8":
                    Console.ForegroundColor = ConsoleColor.White; // Yazı rengini beyaza döndür  
                    Console.WriteLine("//Ses Sistemi Kontrol Programı: 'aç' yazarak müziği başlatabilir, 'kapat' yazarak durdurabilirsiniz."); // Kullanım talimatını göster  
                    Console.WriteLine("Programdan çıkmak için 'çıkış' yazabilirsiniz.//"); // Çıkış talimatını göster  
                    Console.ResetColor(); // Rengi sıfırla  

                    WaveOutEvent outputDevice = null; // Ses çıkışı aygıtı için değişken  
                    AudioFileReader audioFile = null; // Müzik dosyasını okumak için değişken  
                    bool isPlaying = false; // Müzik durumunu takip etmek için değişken  

                    try
                    {
                        // Müzik dosyasının yolu  
                        string filePath = @"C:\Users\hp\Downloads\Kıraç.mp3"; // Oynatılacak müzik dosyasının yolu  
                        audioFile = new AudioFileReader(filePath); // Müzik dosyasını oku  
                        outputDevice = new WaveOutEvent(); // Yeni ses çıkışı aygıtı oluştur  
                        outputDevice.Init(audioFile); // Ses çıkışını müzik dosyasına bağla  

                        while (true) // Sonsuz döngü, kullanıcıdan komut almak için  
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan; // Yazı rengini açık maviye ayarla  
                            Console.Write("\nKomut giriniz \u001b[1;33m (aç/kapat/çıkış):\u001b[0m "); // Kullanıcıdan bir komut girmesini iste  
                            string command = Console.ReadLine().ToLower(); // Kullanıcının girdiği komutu küçük harflere çevir  
                            Console.ResetColor(); // Rengi sıfırla  

                            if (command == "aç") // Kullanıcının komutu 'aç' ise  
                            {
                                if (!isPlaying) // Eğer müzik çalmıyorsa  
                                {
                                    outputDevice.Play(); // Müziği başlat  
                                    isPlaying = true; // Müzik çalıyor olarak durumu güncelle  
                                    Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                                    Console.WriteLine("Müzik çalmaya başladı."); // Müziğin başladığını bildir  
                                    Console.ResetColor(); // Rengi sıfırla  
                                }
                                else // Müzik zaten çalıyorsa  
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                                    Console.WriteLine("Müzik zaten çalıyor."); // Kullanıcıya hata mesajı göster  
                                    Console.ResetColor(); // Rengi sıfırla  
                                }
                            }
                            else if (command == "kapat") // Kullanıcının komutu 'kapat' ise  
                            {
                                if (isPlaying) // Eğer müzik çalıyorsa  
                                {
                                    outputDevice.Stop(); // Müziği durdur  
                                    isPlaying = false; // Müzik durdu olarak durumu güncelle  
                                    Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                                    Console.WriteLine("Müzik durduruldu."); // Müziğin durdurulduğunu bildir  
                                    Console.ResetColor(); // Rengi sıfırla  
                                }
                                else // Müzik zaten durdurulmuşsa  
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                                    Console.WriteLine("Müzik zaten durdurulmuş."); // Kullanıcıya hata mesajı göster  
                                    Console.ResetColor(); // Rengi sıfırla  
                                }
                            }
                            else if (command == "çıkış") // Kullanıcının komutu 'çıkış' ise  
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                                Console.WriteLine("MP3 Kontrol Programından çıkılıyor..."); // Çıkılırken mesajı göster  
                                Console.ResetColor(); // Rengi sıfırla  
                                break; // Döngüden çık  
                            }
                            else // Geçersiz komut girişinde  
                            {
                                Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                                Console.WriteLine("Hatalı komut: Lütfen 'aç', 'kapat' veya 'çıkış' giriniz."); // Hata mesajı göster  
                                Console.ResetColor(); // Rengi sıfırla  
                            }
                        }
                    }
                    catch (Exception ex) // Hata yakalama bloğu  
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                        Console.WriteLine($"Hata: {ex.Message}"); // Hata mesajını göster  
                        Console.ResetColor(); // Rengi sıfırla  
                    }
                    finally // Kaynakları temizleme bloğu  
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                        outputDevice?.Dispose(); // Ses çıkış aygıtını serbest bırak (varsa)  
                        audioFile?.Dispose(); // Müzik dosyasını serbest bırak (varsa)  
                        Console.WriteLine("Müzik kaynakları temizlendi."); // Temizlenme mesajı göster  
                        Console.ResetColor(); // Rengi sıfırla  
                    }
                    break; // 'case "6"' bitişi  



                
                case "9":
                    GirisEkraninaDon(); // Kullanıcı giriş ekranına geri dönmesini sağlayan fonksiyonu çağır  
                    break; // 'case "7"' bitişi  

                case "10":
                    Console.ForegroundColor = ConsoleColor.Yellow; // Yazı rengini sarıya döndür  
                    Console.WriteLine("Çıkış yapılıyor. Güle güle!"); // Çıkış mesajını göster  
                    Console.ResetColor(); // Rengi sıfırla  
                    return; // Programı sonlandırarak çıkış yap  

                default:
                    Console.ForegroundColor = ConsoleColor.Red; // Hata mesajı için kırmızı renk  
                    Console.WriteLine("Hatalı giriş: Lütfen geçerli bir seçim yapınız."); // Hatalı giriş mesajını göster  
                    Console.ResetColor(); // Rengi sıfırla  
                    break; // 'default' kısmının sonu  






     
            }
        }



       
    }
}


