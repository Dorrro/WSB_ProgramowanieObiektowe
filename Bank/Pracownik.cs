namespace Finanse.Pracownicy
{
    using System;
    using BankFinanse.Pracownicy;

    public class Pracownik
    {
        public void UstawInformacjeOPracowniku(string imie, string nazwisko, string nazwaStanowiska, Wynagrodzenie wynagrodzenie, TypUmowy umowa, int czasUmowyWMiesiacach, bool umowaNaCzasNieokreslony, ulong numerKonta)
        {
            this._imie = imie;
            this._nazwisko = nazwisko;
            this._nazwaStanowiska = nazwaStanowiska;
            this._wynagrodzenie = wynagrodzenie;
            this._umowa = umowa;
            this._czasUmowyWMiesiacach = czasUmowyWMiesiacach;
            this._umowaNaCzasNieokreslony = umowaNaCzasNieokreslony;
            this._numerKonta = numerKonta;
        }

        public string Imie()
        {
            return this._imie;
        }

        private string _imie;

        public string Nazwisko()
        {
            return this._nazwisko;
        }

        private string _nazwisko;

        public string NazwaStanowiska()
        {
            return this._nazwaStanowiska;
        }

        private string _nazwaStanowiska;

        public double DodatekWakacyjny()
        {
            return _dodatekWakacyjny;
        }

        public void ZmienDodatekWakacyjny(double wartosc)
        {
            _dodatekWakacyjny = wartosc;
        }

        private static double _dodatekWakacyjny = 1000;

        private Operacja[] _operacje = new Operacja[400];

        public double Wynagrodzenie()
        {
            return this._wynagrodzenie.PobierzWartoscWynagrodzenia();
        }

        public void ZmienWynagrodzenie(double placaZasadnicza, double dodatekStazowy, float kosztUzyskaniaPrzychodu)
        {
            this._wynagrodzenie = this._wynagrodzenie.ZmienWartosci(placaZasadnicza, dodatekStazowy, kosztUzyskaniaPrzychodu);
        }

        public void WyplacWynagrodzenie()
        {
            var operacja = new Operacja();
            operacja.UstawDane(DateTime.Now, this._wynagrodzenie.PobierzWartoscWynagrodzenia(), this._numerKonta, true, "Wyplata wynagrodzenia");
            this._operacje[0] = operacja;
        }

        private Wynagrodzenie _wynagrodzenie;

        public TypUmowy TypUmowy()
        {
            return this._umowa;
        }

        private TypUmowy _umowa;

        public int CzasPracyWMiesiacach()
        {
            return this._czasUmowyWMiesiacach;
        }

        private int _czasUmowyWMiesiacach;

        public bool UmowaNaCzasNieokreslony()
        {
            return this._umowaNaCzasNieokreslony;
        }

        private bool _umowaNaCzasNieokreslony;

        public ulong NumerKonta()
        {
            return this._numerKonta;
        }

        private ulong _numerKonta;
    }
}