using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Threading;
namespace ConsoleApp2
{
    class yonetici
    {
        public void yoneticipanel(string kullaniciad)
        {

            int secim;
            Console.WriteLine("--- Yönetici Paneline Hoşgeldiniz ---" + kullaniciad);
            Console.WriteLine("1-Veri Eklemek İçin");
            Console.WriteLine("2-Veri Silmek İçin");
            Console.WriteLine("3-Veri Güncellemek için");
            Console.WriteLine("4-Veri Okumak İçin");
            Console.WriteLine("5-Çıkmak İçin");
            Console.Write("Seçimi yapıp ENTER tuşunua basınız : "); secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1: adddata(kullaniciad); break;
                case 2: deletedata(kullaniciad); break;
                case 3: updatedata(kullaniciad); break;
                case 4: verigoster(kullaniciad); break;
                case 5: Console.Write("Program Kapatılıyor.."); Thread.Sleep(2000); Environment.Exit(0); break;
            }
        }
        public void adddata(string kullaniciad)
        {
            int i = 1, cnt = 0;
            string satir, tur,bilgiler,birlestir1,birlestir2,birlestir3,birlestir4,adsoyad,sigara,tcno,yas,ilac;
            string dosya_yolu = @"kan.txt";
            FileStream fs2 = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader oku = new StreamReader(fs2);
            while (!oku.EndOfStream)
            {
                satir = oku.ReadLine();
                i++;
            }
            cnt = i;
            i = 1;
            oku.Close();
            fs2.Close();
            FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
            StreamWriter yaz = new StreamWriter(fs);
            Console.Write(i + ".Kan Turunu Giriniz : "); tur = Convert.ToString(Console.ReadLine());           
            Console.Write("AdSoyad Giriniz Boşluk Bırakmadan : "); adsoyad = Convert.ToString(Console.ReadLine());
            Console.Write("Sigara Durumu EVET/HAYIR girin : "); sigara = Convert.ToString(Console.ReadLine());
            Console.Write("TCNO GİRİN: "); tcno = Convert.ToString(Console.ReadLine());
            Console.Write("Yaşını Girin : "); yas = Convert.ToString(Console.ReadLine());
            Console.Write("Kullandığı İlacı Girin : "); ilac = Convert.ToString(Console.ReadLine());
            birlestir1 = string.Concat(adsoyad," "+ sigara);
            birlestir2 = string.Concat(birlestir1," "+ tcno);
            birlestir3 = string.Concat(birlestir2," "+ yas);
            birlestir4 = string.Concat(birlestir3," "+ ilac);
            bilgiler = birlestir4;
            yaz.WriteLine("id: " + cnt + " " + tur+" "+bilgiler);
            i++;
            cnt++;
            while (true)
            {
                Console.Write(i + ".Kan Turunu Giriniz : "); tur = Convert.ToString(Console.ReadLine());
                if (tur != "1")
                {
                    Console.Write("AdSoyad Giriniz Boşluk Bırakmadan : "); adsoyad = Convert.ToString(Console.ReadLine());
                    Console.Write("Sigara Durumu EVET/HAYIR girin : "); sigara = Convert.ToString(Console.ReadLine());
                    Console.Write("TCNO GİRİN: "); tcno = Convert.ToString(Console.ReadLine());
                    Console.Write("Yaşını Girin : "); yas = Convert.ToString(Console.ReadLine());
                    Console.Write("Kullandığı İlacı Girin : "); ilac = Convert.ToString(Console.ReadLine());
                    birlestir1 = string.Concat(adsoyad, " " + sigara);
                    birlestir2 = string.Concat(birlestir1, " " + tcno);
                    birlestir3 = string.Concat(birlestir2, " " + yas);
                    birlestir4 = string.Concat(birlestir3, " " + ilac);
                    bilgiler = birlestir4;
                    yaz.WriteLine("id: " + cnt + " " + tur + " " + bilgiler);
                }
                else
                {
                    Console.WriteLine("İşlem Bitti");
                    yaz.Close();
                    fs.Close();
                    Console.WriteLine("Ekleme İşlemi Bitti Geri Dönüyorsunuz");
                    Thread.Sleep(2000);//ms
                    Console.Clear();
                    yoneticipanel(kullaniciad);
                }              
                cnt++;
                i++;
            }
           
        }
        public void deletedata(string kullaniciad)
        {
            string dosya_yolu = @"kan.txt";
            int counter = 0;
            int i;
            string izin;
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            ArrayList arrlist = new ArrayList();
            ArrayList arlist = new ArrayList();
            StreamReader sw = new StreamReader(fs);
            Console.Write("Silmek İstediğiniz İd numarasını yazınız: "); i = Convert.ToInt32(Console.ReadLine());
            Console.Write("Silmek İstediğinize Eminmisiniz E/H : ");izin = Convert.ToString(Console.ReadLine());
            if (izin == "E"||izin=="e")
            {
                string yazi = sw.ReadLine();
                while (yazi != null)
                {
                    arrlist.Add(yazi);
                    yazi = sw.ReadLine();
                }
                arrlist.RemoveAt(i - 1);
                counter = 0;
                sw.Close();
                fs.Close();
                File.Delete(dosya_yolu);
                FileStream ds = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                int t = 1;
                string don, birlestir, birlestir2,birlestir3,birlestir4,birlestir5, birlestir6, birlestir7;
                StreamWriter yaz = new StreamWriter(ds);
                int r = 0;
                counter = 0;
                while (counter < arrlist.Count)
                {

                    don = Convert.ToString(t);
                    string[] ayir = arrlist[counter].ToString().Split(' ');
                    ayir[r + 1] = don;
                    birlestir = string.Concat(ayir[r].ToString() + " ", don);
                    birlestir2 = string.Concat(birlestir, (" " + ayir[r+2]));
                    birlestir3 = string.Concat(birlestir2,(" " + ayir[r+3]));
                    birlestir4 = string.Concat(birlestir3,(" " + ayir[r+4]));
                    birlestir5 = string.Concat(birlestir4,(" " + ayir[r+5]));
                    birlestir6 = string.Concat(birlestir5,(" " + ayir[r+6]));
                    birlestir7 = string.Concat(birlestir6,(" " + ayir[r+7]));
                    yaz.WriteLine(birlestir7);
                    counter++;

                    t++;
                }
                counter = 0;
                yaz.Close();
                ds.Close();
                Console.Write("Veri Silindi Panele Yönlendiriliyorsunuz");
                Thread.Sleep(2000);
                Console.Clear();
                yoneticipanel(kullaniciad);
            }
            else if(izin == "H"||izin=="h")
            {
                Console.Write("Silme Gerçekleşmedi Panele Yönlendiriyoruz");
                Thread.Sleep(2000);//ms
                Console.Clear();
                yoneticipanel(kullaniciad);
            }
        }
        public void updatedata(string kullaniciad)
        {
            StringBuilder strng = new StringBuilder();
            int i;
            string yenideger, tur, birlestir1, birlestir2, birlestir3, birlestir4, adsoyad, sigara, tcno, yas, ilac;
            string deger = string.Empty;
            string[] dosya = File.ReadAllLines(@"kan.txt");
            Console.Write("Güncellemek İstediğiniz Satır ID giriniz : "); i = Convert.ToInt32(Console.ReadLine());
            Console.Write(i + ".Kan Turunu Giriniz : "); tur = Convert.ToString(Console.ReadLine());
            Console.Write("AdSoyad Giriniz Boşluk Bırakmadan : "); adsoyad = Convert.ToString(Console.ReadLine());
            Console.Write("Sigara Durumu EVET/HAYIR girin : "); sigara = Convert.ToString(Console.ReadLine());
            Console.Write("TCNO GİRİN: "); tcno = Convert.ToString(Console.ReadLine());
            Console.Write("Yaşını Girin : "); yas = Convert.ToString(Console.ReadLine());
            Console.Write("Kullandığı İlacı Girin : "); ilac = Convert.ToString(Console.ReadLine());

            birlestir1 = string.Concat(adsoyad, " " + sigara);
            birlestir2 = string.Concat(birlestir1, " " + tcno);
            birlestir3 = string.Concat(birlestir2, " " + yas);
            birlestir4 = string.Concat(birlestir3, " " + ilac);
            yenideger = birlestir4;
            string[] arrLine = File.ReadAllLines(@"kan.txt");
            arrLine[i - 1] = "id: " + i + " " + tur + " " + yenideger;
            File.WriteAllLines(@"kan.txt", arrLine);
            Console.Write("Veri Güncellendi Panele Yönlendiriliyorsunuz");
            Thread.Sleep(2000);
            Console.Clear();
            yoneticipanel(kullaniciad);
        }
        public void verigoster(string kullaniciad)
        { int istenilen;
            string yazi;
            string dosya_yolu = @"kan.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            ArrayList arrlist = new ArrayList();
            ArrayList arlist = new ArrayList();
            StreamReader sw = new StreamReader(fs);
            yazi = sw.ReadLine();
            while (yazi != null)
            {
                arlist.Add(yazi);
                yazi = sw.ReadLine();
            }
            Console.Write("Okumak İstediğiniz ID kaç: "); istenilen = Convert.ToInt32(Console.ReadLine());
            string[] ayir = arlist[istenilen - 1].ToString().Split(' ');
            Console.Write("İd: " + ayir[1].ToString()+" "+"Kan Grubu: "+ ayir[2].ToString()+" "+ " AdıSoyadı: "+ayir[3].ToString()+" "+"Sigara Kullanıyormu: "+ ayir[4].ToString()+" "+ "TCNO: "+ ayir[5].ToString()+" "+"Yaşı: "+ayir[6].ToString()+ " "+"Kullandığı İlaç: "+ayir[7].ToString());
            Console.Write("\n");
            Console.Write("Panel için 0 yazıp ENTER tuşuna basın : "); istenilen = Convert.ToInt32(Console.ReadLine());
            if (istenilen == 0) 
            {
                Console.Write("Panele Yönlendiriliyorsunuz..");
                Thread.Sleep(2000);//ms
                Console.Clear();
                yoneticipanel(kullaniciad);
            }
            
        }

    }
    class personel
    {
        public void personelpanel(string kullaniciad)
        {


            int secim;
            Console.WriteLine("--- Personel Paneline Hoşgeldiniz ---" + kullaniciad);
            Console.WriteLine("1-Veri Eklemek İçin");          
            Console.WriteLine("2-Veri Güncellemek için");
            Console.WriteLine("3-Veri Okumak İçin");
            Console.WriteLine("4-Geri Dönmek İçin");

            Console.Write("Seçimi yapıp ENTER tuşunua basınız : "); secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1: adddata(kullaniciad); break;
                case 2: updatedata(kullaniciad); break;
                case 3: verigoster(kullaniciad); break;
                case 4: Console.Write("Program Kapatılıyor.."); Thread.Sleep(2000); Environment.Exit(0); break;
            }

        }
        public void adddata(string kullaniciad)
        {
            int i = 1, cnt = 0;
            string satir, tur, bilgiler, birlestir1, birlestir2, birlestir3, birlestir4, adsoyad, sigara, tcno, yas, ilac;
            string dosya_yolu = @"kan.txt";
            FileStream fs2 = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader oku = new StreamReader(fs2);
            while (!oku.EndOfStream)
            {
                satir = oku.ReadLine();
                i++;
            }
            cnt = i;
            i = 1;
            oku.Close();
            fs2.Close();
            FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
            StreamWriter yaz = new StreamWriter(fs);
            Console.Write(i + ".Kan Turunu Giriniz : "); tur = Convert.ToString(Console.ReadLine());
            Console.Write("AdSoyad Giriniz Boşluk Bırakmadan : "); adsoyad = Convert.ToString(Console.ReadLine());
            Console.Write("Sigara Durumu EVET/HAYIR girin : "); sigara = Convert.ToString(Console.ReadLine());
            Console.Write("TCNO GİRİN: "); tcno = Convert.ToString(Console.ReadLine());
            Console.Write("Yaşını Girin : "); yas = Convert.ToString(Console.ReadLine());
            Console.Write("Kullandığı İlacı Girin : "); ilac = Convert.ToString(Console.ReadLine());
            birlestir1 = string.Concat(adsoyad, " " + sigara);
            birlestir2 = string.Concat(birlestir1, " " + tcno);
            birlestir3 = string.Concat(birlestir2, " " + yas);
            birlestir4 = string.Concat(birlestir3, " " + ilac);
            bilgiler = birlestir4;
            yaz.WriteLine("id: " + cnt + " " + tur + " " + bilgiler);
            i++;
            cnt++;
                while (true)
                {
                    Console.Write(i + ".Kan Turunu Giriniz : "); tur = Convert.ToString(Console.ReadLine());
                    if (tur != "1")
                    {
                        Console.Write("AdSoyad Giriniz Boşluk Bırakmadan : "); adsoyad = Convert.ToString(Console.ReadLine());
                        Console.Write("Sigara Durumu EVET/HAYIR girin : "); sigara = Convert.ToString(Console.ReadLine());
                        Console.Write("TCNO GİRİN: "); tcno = Convert.ToString(Console.ReadLine());
                        Console.Write("Yaşını Girin : "); yas = Convert.ToString(Console.ReadLine());
                        Console.Write("Kullandığı İlacı Girin : "); ilac = Convert.ToString(Console.ReadLine());
                        birlestir1 = string.Concat(adsoyad, " " + sigara);
                        birlestir2 = string.Concat(birlestir1, " " + tcno);
                        birlestir3 = string.Concat(birlestir2, " " + yas);
                        birlestir4 = string.Concat(birlestir3, " " + ilac);
                        bilgiler = birlestir4;
                        yaz.WriteLine("id: " + cnt + " " + tur + " " + bilgiler);
                    }
                    else
                    {
                        Console.WriteLine("İşlem Bitti");
                        yaz.Close();
                        fs.Close();
                        Console.WriteLine("Ekleme İşlemi Bitti Geri Dönüyorsunuz");
                        Thread.Sleep(2000);//ms
                        Console.Clear();
                        personelpanel(kullaniciad);
                    }
                    cnt++;
                    i++;
                }         
        }
        public void updatedata(string kullaniciad)
        {
            StringBuilder strng = new StringBuilder();
            int i;
            string yenideger,tur, birlestir1, birlestir2, birlestir3, birlestir4, adsoyad, sigara, tcno, yas, ilac;
            string deger = string.Empty;
            string[] dosya = File.ReadAllLines(@"kan.txt");
            Console.Write("Güncellemek İstediğiniz Satır ID giriniz : "); i = Convert.ToInt32(Console.ReadLine());
            Console.Write(i + ".Kan Turunu Giriniz : "); tur = Convert.ToString(Console.ReadLine());
            Console.Write("AdSoyad Giriniz Boşluk Bırakmadan : "); adsoyad = Convert.ToString(Console.ReadLine());
            Console.Write("Sigara Durumu EVET/HAYIR girin : "); sigara = Convert.ToString(Console.ReadLine());
            Console.Write("TCNO GİRİN: "); tcno = Convert.ToString(Console.ReadLine());
            Console.Write("Yaşını Girin : "); yas = Convert.ToString(Console.ReadLine());
            Console.Write("Kullandığı İlacı Girin : "); ilac = Convert.ToString(Console.ReadLine());

            birlestir1 = string.Concat(adsoyad, " " + sigara);
            birlestir2 = string.Concat(birlestir1, " " + tcno);
            birlestir3 = string.Concat(birlestir2, " " + yas);
            birlestir4 = string.Concat(birlestir3, " " + ilac);
            yenideger = birlestir4;
            string[] arrLine = File.ReadAllLines(@"kan.txt");
            arrLine[i - 1] = "id: "+i+ " "+tur+" "+ yenideger;
            File.WriteAllLines(@"kan.txt", arrLine);
            Console.Write("Veri Güncellendi Panele Yönlendiriliyorsunuz");
            Thread.Sleep(2000);
            Console.Clear();
            personelpanel(kullaniciad);
        }
        public void verigoster(string kullaniciad)
        {
            int istenilen;
            string yazi;
            string dosya_yolu = @"kan.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            ArrayList arrlist = new ArrayList();
            ArrayList arlist = new ArrayList();
            StreamReader sw = new StreamReader(fs);
            yazi = sw.ReadLine();
            while (yazi != null)
            {
                arlist.Add(yazi);
            }
            Console.Write("Okumak İstediğiniz ID kaç"); istenilen = Convert.ToInt32(Console.ReadLine());
            string[] ayir = arlist[istenilen - 1].ToString().Split(' ');
            Console.Write("İd: " + ayir[1].ToString() + " " + "Kan Grubu: " + ayir[2].ToString() + " " + " AdıSoyadı: " + ayir[3].ToString() + " " + "Sigara Kullanıyormu: " + ayir[4].ToString() + " " + "TCNO: " + ayir[5].ToString() + " " + "Yaşı: " + ayir[6].ToString() + " " + "Kullandığı İlaç: " + ayir[7].ToString());
            Console.Write("\n");
            Console.Write("Panel için 0 yazıp ENTER tuşuna basın"); istenilen = Convert.ToInt32(Console.ReadLine());
            if (istenilen == 0)
            {
                Console.Write("Panele Yönlendiriliyorsunuz..");
                Thread.Sleep(2000);//ms
                Console.Clear();
                personelpanel(kullaniciad);
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            yonetici yopanel = new yonetici();
            personel pepanel = new personel();
            ArrayList arlist = new ArrayList();
            string kad, ksifre, statusbe = "admin",statuspe="kullanici";
            int i = 0, y = 1, z = 2,counter=0;
            bool stat = false;
            Console.Write("Kullanıcı Adı: "); kad = Convert.ToString(Console.ReadLine());
            Console.Write("Kullanıcı Şifresi: "); ksifre = Convert.ToString(Console.ReadLine());
            string dosya_yolu = @"kullan.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader kullanici = new StreamReader(fs);
            string[] arr = kullanici.ReadLine().Split(';');
            string[] arr2 = new string[100];
            foreach (var st in arr)
            {
                arlist.Add(st);
            }          
            i = 0; y = 1; z = 2;
            counter = 0;
            while (counter<arlist.Count) {
                if(!arlist.Contains(kad) || !arlist.Contains(ksifre))
                {
                    Console.WriteLine("Yanlış Girdiniz Sistemi Yeniden Başlatınız");
                    Thread.Sleep(2000);//ms
                    Environment.Exit(0); 
                    break;                   
                }
                if (kad == arlist[i].ToString() && ksifre== arlist[y].ToString() && statusbe == arlist[z].ToString())
                {
                    Console.WriteLine("Giriş Başarılı Giriş Türü: Yönetici, Kullanıcı Adı : " + kad);
                    stat = true;
                    kullanici.Close();
                    fs.Close();
                    break;
                }               
                if (arlist[i].ToString() == kad && arlist[y].ToString() == ksifre && arlist[z].ToString()== statuspe)
                {
                    Console.WriteLine("Giriş Başarılı Giriş Türü: Personel, Kullanıcı Adı : " + kad);
                    stat = false;
                    fs.Close();
                    kullanici.Close();
                    break;
                }
                else
                {
                    i += 5; y += 5; z += 5;
                }
                counter++;
            }
            if (stat == true)
            {
                Console.WriteLine("Yönetici Paneline Yönlendiriliyorsuzz..");
                Thread.Sleep(2000);//ms
                Console.Clear();
                fs.Close();
                kullanici.Close();
                yopanel.yoneticipanel(kad);
            }else if (stat == false)
            {
                Console.WriteLine("Personel Paneline Yönlendiriliyorsunuz..");
                Thread.Sleep(2000);//ms
                Console.Clear();
                fs.Close();
                kullanici.Close();
                pepanel.personelpanel(kad);
            }
            else
            {
                Console.WriteLine("Bilgileri Yanlış Girdiniz Yetkili İle Görüşün");
                fs.Close();
                kullanici.Close();
            }
        Console.ReadKey();
        }      
    }
}
