namespace ZarzadzaniePracownikami
{
    using System;
    using BankFinanse.Pracownicy;
    using Finanse.Pracownicy;

    class Program
    {
        static void Main(string[] args)
        {
            var wynagrodzenie = new Wynagrodzenie(100, 100, 0.9);
            var pracownik = new Pracownik(wynagrodzenie, 1, "Jan", "Kowalski", "regular", TypUmowy.OPace, 1233421431241, DateTime.Parse("01-01-2000"));
            Console.WriteLine(pracownik.Pensja);
            InformacjeOOsobie(pracownik);

//            var osoba = new Osoba("Jan", "Kowalski", DateTime.Parse("01-02-2000"));
//            InformacjeOOsobie(osoba);

            var klient = new Klient("Test", "Test", DateTime.Parse("01-03-2000"));
            Console.WriteLine(klient.DataUtworzeniaKlienta);
            InformacjeOOsobie(klient);

            var menadzer = new Menadzer(new Wynagrodzenie(10000, 100, 50), 23, "Albert", "Einstein", TypUmowy.OPace, 1231231234123, "Test", DateTime.Parse("01-04-2000"));
            InformacjeOOsobie(menadzer);

            ZmienNazweStanowiska(pracownik, "test");
            ZmienNazweStanowiska(menadzer, "test2");

            var pracownicy = new Pracownicy();
            pracownicy.DodajPracownika(menadzer);
            pracownicy.DodajPracownika(pracownik);
            pracownicy.DodajPracownika(Pracownik.UtworzPracownika("test","test"));

            var janKowalski = pracownicy["Jan", "Kowalski"];
            Console.WriteLine(janKowalski.NazwaStanowiska);
            janKowalski.WyplacWynagrodzenie();
            Console.WriteLine(janKowalski[0].Tytul);

            pracownicy.UsunPracownika(janKowalski);
            var usunietyPracownik = pracownicy["Jan", "Kowalski"];
            Console.WriteLine(usunietyPracownik == null);
            Console.WriteLine(pracownicy.PobierzPracownika(p => p.Imie == "test").Nazwisko);

            Console.WriteLine(menadzer.Equals(pracownik));
            Console.WriteLine(pracownik.Equals(usunietyPracownik));

            Console.WriteLine(menadzer.CompareTo(pracownik));
            Console.WriteLine(pracownik.CompareTo(usunietyPracownik));

            foreach (var p in pracownicy)
            {
                Console.WriteLine(p.ToString());
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
