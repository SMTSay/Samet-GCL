
/*
using System;
using System.Collections;

public class ListeYazma
{
    public static void Main(string[] args)
    {
        ArrayList Tamsayılar = new ArrayList();
        Tamsayılar.Add(5);
        Tamsayılar.Add(4);
        Tamsayılar.Add(23);
        Tamsayılar.Add(43);
        Tamsayılar.Add(21);
        Tamsayılar.Add(14);

        Console.WriteLine("Tam Sayılar:");
        foreach (int sayi in Tamsayılar)
        {
            Console.WriteLine(sayi);
        }
        int toplam = 0;
        foreach (int sayi in Tamsayılar)
        {
            toplam += sayi;
        }
        Console.WriteLine("Tam Sayıların Toplamı:" + toplam);
    }
}
*/




/*
using System;
public class KelimeSayar
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bir Cümle Giriniz:");
        string cumle = Console.ReadLine();
        string[] kelime = cumle.Split(' ');
        int kelimesayi = kelime.Length;
        Console.WriteLine("Cümledeki Kelime Sayısı:" + kelimesayi);
    }

}
*/


/*
using System;
using System.Collections;
public class Sıralama
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Birinci İsimi Giriniz:");
        string isim1 = Console.ReadLine();
        Console.WriteLine("ikinci İsimi Giriniz:");
        string isim2 = Console.ReadLine();
        Console.WriteLine("Üçüncü İsimi Giriniz:");
        string isim3 = Console.ReadLine();
        Console.WriteLine("Dördüncü İsimi Giriniz:");
        string isim4 = Console.ReadLine();
        Console.WriteLine("Beşinci İsimi Giriniz:");
        string isim5 = Console.ReadLine();
        ArrayList İsimler = new ArrayList();
        İsimler.Add(isim1);
        İsimler.Add(isim2);
        İsimler.Add(isim3);
        İsimler.Add(isim4);
        İsimler.Add(isim5);
        İsimler.Sort();
        Console.WriteLine("Alfabeye Göre Sıralanışı:");
        foreach(string s in İsimler)
        {
            Console.WriteLine(s);
        }
    }
}
*/



/*
using System;
using System.Collections;
public class Fibonacci
{
    public static void Main(string[] args)
    {
        Console.WriteLine("İstediğiniz Fibonacci Sayısını Giriniz:");
        int adet = Convert.ToInt32(Console.ReadLine());
        int a = 0; int b = 1;
        Console.WriteLine(a + "\n" + b );
        for (int i = 0; i < adet; i++)
        {
            int c = a + b;
            Console.WriteLine(c + " ");
            a = b;
            b = c;
        }
    }

}
*/


/*
using System;
using System.Collections;
public class Tahmin
{
    public static void Main(string[] args)
    {
        
        Random rastsay = new Random();
        int rastsayi = rastsay.Next(1, 101);
        int tahmin;
        bool doğru = false;
        Console.WriteLine("1 ile 100 Arası Bir Sayı Tuttum!" + "\nTahmin Et Bakalım:");
        do
        {
            tahmin = Convert.ToInt32(Console.ReadLine());
            if (tahmin < rastsayi)
            {
                Console.WriteLine("Yaklaştın Biraz Daha Yüksek Tahminde Bulun");
            }
            else if (tahmin > rastsayi)
            {
                Console.WriteLine("Yaklaştın Biraz Daha Düşük Tahminde Bulun");
            }
            else
            {
                Console.WriteLine("Helal Olsun Bildin!!" + "\nTebrik Ederim");
                doğru = true;
            }
            
        }
        while (!doğru);
    }
}
*/


/*
using System;
using System.Collections;
public static class HesapMakinası
{
    public static void Main(string[] args)
    {
        string islem;
        do
        {
            Console.WriteLine("Lütfen Yapmak İstediğiniz İşlem Türünü Seçiniz (+,-,*,/) veya Exit Yazınız");
            islem = Console.ReadLine();
            if (islem.ToLower() == "Exit")
                break;
            Console.WriteLine("Bir Sayı Giriniz:");
            double sayi1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("İkinci Bir Sayı Giriniz");
            double sayi2 = Convert.ToDouble(Console.ReadLine());
            switch (islem)
            {
                case "+":
                    Console.WriteLine("Sonuç: " + (sayi1 + sayi2));
                    break;
                case "-":
                    Console.WriteLine("Sonuç: " + (sayi1 - sayi2));
                    break;
                case "*":
                    Console.WriteLine("Sonuç: " + (sayi1 * sayi2));
                    break;
                case "/":
                    if (sayi2 == 0)
                    {
                        Console.WriteLine("Hata: Sıfıra bölme hatası!");
                    }
                    else
                    {
                        Console.WriteLine("Sonuç: " + (sayi1 / sayi2));
                    }
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem türü!");
                    break;

            }
        } while (true);
    }
}
*/


/*
using System;
using System.Collections;
public class ToplamaOyunu
{
    public static void Main(string[] args)
    {
        int toplam = 0;
        List<int> sayilar = new List<int>();
        do
        {
            Console.WriteLine("Pozitif Sayı Girişi Yapınız:");
            int sayı = Convert.ToInt32(Console.ReadLine());
            if (sayı == 0)
            {
                Console.WriteLine("Sıfır Girişi Yaptınız!");
                break;
            }
            else if (sayı < 0)
            {
                Console.WriteLine("Negatif Sayı Girmeyiniz!!");
                break;
            }
            else
            {
                sayilar.Add(sayı);
                toplam += sayı;
            }
        } while (true);
        Console.WriteLine("Girilen sayıların toplamı: " + toplam);
        Console.WriteLine("Girilen sayılar:");
        for (int i = 0; i < sayilar.Count; i++)
        {
            Console.WriteLine(sayilar[i]);
        }
        Console.ReadKey();
    }
}
*/


