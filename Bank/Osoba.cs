namespace Finanse.Pracownicy
{
    using System;

    public abstract class Osoba : IOsoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }

        public Osoba(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = dataUrodzenia;
        }

        ~Osoba()
        { }

        public abstract void Zainteresowania(string zainteresowanie);

        public void UstawInformacjeOOsobie(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = dataUrodzenia;
        }

        public string PobierzDane()
        {
            return string.Format("=========== Informacje o pracowniku ============\nImie i nazwisko: {0} {1}\nData urodzenia: {2}", this.Imie,
                this.Nazwisko, this.DataUrodzenia);
        }
    }
}