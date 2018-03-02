namespace Finanse.Pracownicy
{
    using System;

    public class Klient : Osoba
    {
        public DateTime DataUtworzeniaKlienta { get; }

        public Klient(string imie, string nazwisko, DateTime dataUrodzenia) : base(imie, nazwisko, dataUrodzenia)
        {
            this.DataUtworzeniaKlienta = DateTime.Now;
        }

        public override void Zainteresowania(string zainteresowanie)
        {
            throw new NotImplementedException();
        }
    }
}