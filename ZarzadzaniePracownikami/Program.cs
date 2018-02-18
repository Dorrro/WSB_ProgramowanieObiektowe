namespace ZarzadzaniePracownikami
{
    using System;
    using BankFinanse.Pracownicy;
    using Finanse.Pracownicy;

    class Program
    {
        static void Main(string[] args)
        {
            var wynagrodzenie = new Wynagrodzenie().ZmienWartosci(100, 100, 0.9);
            var pracownik = new Pracownik(wynagrodzenie, 1, "Jan", "Kowalski", "regular", TypUmowy.OPace, 1233421431241);
            Console.WriteLine(pracownik.Pensja);
            Console.WriteLine(pracownik.Imie);
        }
    }
}
