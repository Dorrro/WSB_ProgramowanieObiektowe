namespace Bank
{
    using System;

    public class Osoba
    {
        private string _imie;
        private string _nazwisko;
        private DateTime _dataUrodzenia;

        public void UstawInformacjeOOsobie(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            this._imie = imie;
            this._nazwisko = nazwisko;
            this._dataUrodzenia = dataUrodzenia;
        }

        public string PobierzDane()
        {
            return string.Format("=========== Informacje o pracowniku ============\nImie i nazwisko: {0} {1}\nData urodzenia: {2}", this._imie, this._nazwisko, this._dataUrodzenia);
        }
    }
}
