namespace Finanse.Pracownicy
{
    using System;

    public class Osoba
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public DateTime DataUrodzenia { get; private set; }

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
    }
}
