
//Girilen sayının çift - tek kontrolü (if)

/*
Console.WriteLine("Bir Sayı Tuşlayınız:");
int a = int.Parse(Console.ReadLine());
if (a % 2 == 0)
    Console.WriteLine("Seçtiğiniz Sayı Çifttir.");
else
    Console.WriteLine("Seçtiğiniz Sayı Tektir.");
*/

//1 den 10 a kadar sayıları ekrana yazı değeri olarak
//yazma işlemi (örn 1 girildiğinde ekrana BİR yazılsın - switch yapısı)


/*
int sayı;
Console.WriteLine("1 ile 10 Dahil Bir Sayı Giriniz:");
sayı = int.Parse(Console.ReadLine());
switch (sayı)
{
    case 1:
        Console.WriteLine("Bir");
        break;
    case 2:
        Console.WriteLine("İki");
        break;
    case 3:
        Console.WriteLine("Üç");
        break;
    case 4:
        Console.WriteLine("Dört");
        break;
    case 5:
        Console.WriteLine("Beş");
        break;
    case 6:
        Console.WriteLine("Altı");
        break;
    case 7:
        Console.WriteLine("Yedi");
        break;
    case 8:
        Console.WriteLine("Sekiz");
        break;
    case 9:
        Console.WriteLine("Dokuz");
        break;
    case 10:
        Console.WriteLine("On");
        break;
    default:
        Console.WriteLine("1 ile 10 Dahil Bir Sayı Giriniz!!!");
        break;
}
*/

//Kullanıcı adı admin ve şifre Admin_32453@ olduğunda giriş başarılı değilse başarısız uyarısı veren c# kodu

/*
using System;

class Program
{
    static void Main()
    {
        string Ka = "admin";
        string pass = "Admin_32453@";

        Console.Write("Kullanıcı adınızı girin: ");
        string username = Console.ReadLine();

        Console.Write("Şifrenizi girin: ");
        string password = Console.ReadLine();

        if (username == Ka && password == pass)
        {
            Console.WriteLine("Giriş başarılı!");
        }
        else
        {
            Console.WriteLine("Giriş başarısız. Lütfen kullanıcı adı ve şifreyi kontrol edin.");
        }
    }
}
*/

//10-20 20-30 30-40 arası sıcaklık durumlarına göre ekrana (normal - sıcak - çok sıcak)
//uyarısı veren veren c# kodu (if else if else if else yapısı)

/*
using System;

public class SicaklikUyarisi
{
    public static void Main(string[] args)
    {
        Console.Write("Sıcaklık değerini girin: ");
        double sicaklik = Convert.ToDouble(Console.ReadLine());

        if (sicaklik >= 10 && sicaklik < 20)
        {
            Console.WriteLine("Normal");
        }
        else if (sicaklik >= 20 && sicaklik < 30)
        {
            Console.WriteLine("Sıcak");
        }
        else if (sicaklik >= 30 && sicaklik <= 40)
        {
            Console.WriteLine("Çok sıcak");
        }
        else
        {
            Console.WriteLine("Geçersiz sıcaklık değeri!");
        }

        Console.ReadKey();
    }
}
*/
