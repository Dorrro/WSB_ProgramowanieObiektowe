namespace ZarzadzaniePracownikami
{
    using System;
    using BankFinanse.Pracownicy;
    using Finanse.Pracownicy;

    class Program
    {
        static void Main(string[] args)
        {
            var pracownik = new Pracownik();
            var wynagrodzenie = new Wynagrodzenie().ZmienWartosci(100, 100, 0.9);
            pracownik.UstawInformacjeOPracowniku("Jan", "Kowalski", "regular", wynagrodzenie, TypUmowy.Dzielo, 1, false, 1231445345435);
            Console.WriteLine(pracownik.Pensja);
            Console.WriteLine(pracownik.Imie);
        }
    }
}
