

/*
using System;

public class UcgenAlanHesaplayici
{
    public static double UcgenAlaniHesapla()
    {
        Console.Write("Üçgenin taban uzunluğunu girin: ");
        double taban = Convert.ToDouble(Console.ReadLine());

        Console.Write("Üçgenin yüksekliğini girin: ");
        double yukseklik = Convert.ToDouble(Console.ReadLine());

        double alan = (taban * yukseklik) / 2;
        return alan;
    }

    public static void Main(string[] args)
    {
        double alan = UcgenAlaniHesapla();
        Console.WriteLine("Üçgenin alanı: " + alan);
    }
}
*/

/*
public class DiziIslemleri
{
    public static int EnBuyukDegeriBul(int[] dizi)
    {
        int enBuyuk = dizi[0]; // Dizinin ilk elemanını başlangıçta en büyük olarak kabul et

        foreach (int sayi in dizi)
        {
            if (sayi > enBuyuk)
            {
                enBuyuk = sayi;
            }
        }

        return enBuyuk;
    }

    public static void Main(string[] args)
    {
        int[] sayilar = { 5, 12, 3, 8, 1, 9 };
        int enBuyukSayi = EnBuyukDegeriBul(sayilar);
        Console.WriteLine("Dizideki en büyük değer: " + enBuyukSayi);
    }
}
*/


/*
public class Hesaplama
{
    // İki int sayıyı toplayan metot
    public static int CalculateSum(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;
    }

    // İki double sayıyı toplayan metot
    public static double CalculateSum(double sayi1, double sayi2)
    {
        return sayi1 + sayi2;
    }

    // Üç int sayıyı toplayan metot
    public static int CalculateSum(int sayi1, int sayi2, int sayi3)
    {
        return sayi1 + sayi2 + sayi3;
    }

    public static void Main(string[] args)
    {
        // Metotları farklı parametrelerle çağırma örnekleri
        int toplam1 = CalculateSum(5, 10);
        double toplam2 = CalculateSum(3.14, 2.71);
        int toplam3 = CalculateSum(2, 4, 6);

        Console.WriteLine("İki int sayının toplamı: " + toplam1);
        Console.WriteLine("İki double sayının toplamı: " + toplam2);
        Console.WriteLine("Üç int sayının toplamı: " + toplam3);
    }
}
*/


/*
public class FibonacciHesaplayici
{
    public static int Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    public static void Main(string[] args)
    {
        int sayi = 5;
        int fibonacciSayisi = Fibonacci(sayi);
        Console.WriteLine(sayi + ". Fibonacci sayısı: " + fibonacciSayisi);
    }
}
*/


/*
public class OrtalamaHesaplayici
{
    public static double OrtalamaHesapla(params double[] sayilar)
    {
        double toplam = 0;
        foreach (double sayi in sayilar)
        {
            toplam += sayi;
        }

        return toplam / sayilar.Length;
    }

    public static void Main(string[] args)
    {
        double ortalama1 = OrtalamaHesapla(5, 10, 15);
        double ortalama2 = OrtalamaHesapla(2.5, 3.7, 4.1, 6.8);

        Console.WriteLine("Ortalama 1: " + ortalama1);
        Console.WriteLine("Ortalama 2: " + ortalama2);
    }
}
*/


/*
public class DiziIslemleri
{
    public static int ToplaVeFiltrele(int[] dizi, int filtreDegeri)
    {
        int toplam = 0;

        foreach (int sayi in dizi)
        {
            if (sayi > filtreDegeri)
            {
                toplam += sayi;
            }
        }

        return toplam;
    }

    public static void Main(string[] args)
    {
        int[] sayilar = { 5, 12, 3, 8, 1, 9 };
        int filtre = 5;
        int filtrelenmisToplam = ToplaVeFiltrele(sayilar, filtre);
        Console.WriteLine("Filtre değerinden büyük sayıların toplamı: " + filtrelenmisToplam);
    }
}
*/


/*
public class YasHesaplayici
{
    public static int YasHesapla(int yas = 18)
    {
        return yas - 18;
    }

    public static void Main(string[] args)
    {
        int yas1 = YasHesapla(25); 
        int yas2 = YasHesapla();  

        Console.WriteLine("25 yaş, 18 yaşından " + yas1 + " yıl fazladır.");
        Console.WriteLine("Varsayılan yaş (18), 18 yaşından " + yas2 + " yıl fazladır.");
    }
}
*/


/*

using System.Collections.Generic;

public class DiziIslemleri
{
    public static List<string> Filtrele(string[] dizi)
    {
        List<string> filtrelenmisListe = new List<string>();

        foreach (string kelime in dizi)
        {
            if (kelime.Length > 5)
            {
                filtrelenmisListe.Add(kelime);
            }
        }

        return filtrelenmisListe;
    }

    public static void Main(string[] args)
    {
        string[] kelimeler = { "elma", "armut", "karpuz", "üzüm", "mandalina", "kiraz" };
        List<string> filtrelenmisKelimeler = Filtrele(kelimeler);

        Console.WriteLine("Filtrelenmiş kelimeler:");
        foreach (string kelime in filtrelenmisKelimeler)
        {
            Console.WriteLine(kelime);
        }
    }
}
*/