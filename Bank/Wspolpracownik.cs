namespace Finanse.Pracownicy
{
    using System;

    public class Wspolpracownik : IOsoba
    {
        public string Imie { get; }
        public string Nazwisko { get; }
        public DateTime DataUrodzenia { get; }
    }
}