namespace Finanse.Pracownicy
{
    using System;

    public class Klient : Osoba
    {
        public Klient(string imie, string nazwisko, DateTime dataUrodzenia) : base(imie, nazwisko, dataUrodzenia)
        {
            this.DataUtworzeniaKlienta = DateTime.Now;
        }

        public DateTime DataUtworzeniaKlienta { get; private set; }
    }
}