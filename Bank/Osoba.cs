namespace Finanse.Pracownicy
{
    using System;

    public abstract class Osoba : IOsoba
    {
        public string Imie { get; protected set; }
        public string Nazwisko { get; protected set; }
        public DateTime DataUrodzenia { get; private set; }

        public Osoba(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = dataUrodzenia;
        }

        ~Osoba() { }

        public void UstawInformacjeOOsobie(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = dataUrodzenia;
        }

        public string PobierzDane()
        {
            return string.Format("=========== Informacje o pracowniku ============\nImie i nazwisko: {0} {1}\nData urodzenia: {2}", this.Imie, this.Nazwisko, this.DataUrodzenia);
        }

        public abstract void Zainteresowania(string zainteresowanie);
    }
}
