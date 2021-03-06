﻿namespace ZarzadzaniePracownikami
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using BankFinanse.Pracownicy;
    using Finanse.Pracownicy;

    class Program
    {
        static void Main(string[] args)
        {
            var wynagrodzenie = new Wynagrodzenie(100, 100, 0.9);
            var pracownik = new Pracownik(wynagrodzenie, 1, "Jan", "Kowalski", "regular", TypUmowy.OPace, 1233421431241,
                DateTime.Parse("01-01-2000"));
            Console.WriteLine(pracownik.Pensja);
            InformacjeOOsobie(pracownik);

//            var osoba = new Osoba("Jan", "Kowalski", DateTime.Parse("01-02-2000"));
//            InformacjeOOsobie(osoba);

            var klient = new Klient("Test", "Test", DateTime.Parse("01-03-2000"));
            Console.WriteLine(klient.DataUtworzeniaKlienta);
            InformacjeOOsobie(klient);

            var menadzer = new Menadzer(new Wynagrodzenie(10000, 100, 0.5), 23, "Albert", "Einstein", TypUmowy.OPace, 1231231234123, "Test",
                DateTime.Parse("01-04-2000"));
            InformacjeOOsobie(menadzer);

            ZmienNazweStanowiska(pracownik, "test");
            ZmienNazweStanowiska(menadzer, "test2");

            var pracownicy = new Pracownicy();
            pracownicy.Add(menadzer);
            pracownicy.Add(pracownik);
            pracownicy.Add(Pracownik.UtworzPracownika("test", "test"));

            var janKowalski = pracownicy["Jan", "Kowalski"];
            Console.WriteLine(janKowalski.NazwaStanowiska);
            janKowalski.WyplacWynagrodzenie();
            Console.WriteLine(janKowalski[0]
                .Tytul);

            pracownicy.UsunPracownika(janKowalski);
            var usunietyPracownik = pracownicy["Jan", "Kowalski"];
            Console.WriteLine(usunietyPracownik == null);
            Console.WriteLine(pracownicy.PobierzPracownika(p => p.Imie == "test")
                .Nazwisko);

            Console.WriteLine(menadzer.Equals(pracownik));
            Console.WriteLine(pracownik.Equals(usunietyPracownik));

            Console.WriteLine(menadzer.CompareTo(pracownik));
            Console.WriteLine(pracownik.CompareTo(usunietyPracownik));

            foreach (var p in pracownicy)
            {
                Console.WriteLine(p.ToString());
            }

            try
            {
                new Pracownik(wynagrodzenie, 10, "Umowa", "O prace", "na czas nieokreslony", TypUmowy.OPace, true, 123454645, DateTime.Now);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                new Pracownik(new Wynagrodzenie(100000, 10000, 1), 10, "Zbyt", "wysokie", "wynagrodzenie", TypUmowy.OPace, false, 123454645,
                    DateTime.Now);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(menadzer == pracownik);
            Console.WriteLine(menadzer != pracownik);

            Console.WriteLine((double)menadzer);

            menadzer.OnZmianaWynagrodzenia += (staraWartosc, nowaWartosc) =>
                                              {
                                                  Console.WriteLine("Zmiana wynagrodzenia. Stara wartosc: {0}. Nowa wartosc: {1}", staraWartosc,
                                                      nowaWartosc);
                                              };

            menadzer.ZmienWynagrodzenie(6000, 3000, 0);


            var xmlSerializer = new XmlSerializer(typeof(Pracownicy));
            using (var stream = new StreamWriter(new FileStream("pracownicy.xml", FileMode.OpenOrCreate)))
            {
                xmlSerializer.Serialize(stream, pracownicy);
            }

            using (var stream = new StreamReader(new FileStream("pracownicy.xml", FileMode.OpenOrCreate)))
            {
                var deserialize = xmlSerializer.Deserialize(stream) as Pracownicy;
                if (deserialize == null) return;

                foreach (var p in deserialize)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

        private static void ZmienNazweStanowiska(Pracownik pracownik, string nazwa)
        {
            pracownik.ZmienNazweStanowiska(nazwa);
            Console.WriteLine(pracownik.NazwaStanowiska);
        }

        private static void InformacjeOOsobie(Osoba osoba)
        {
            Console.WriteLine(osoba.Imie);
            Console.WriteLine(osoba.Nazwisko);
        }
    }
}