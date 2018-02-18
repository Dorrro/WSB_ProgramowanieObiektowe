namespace Finanse.Pracownicy
{
    using System;
    using BankFinanse.Pracownicy;

    public class Pracownik
    {
        public void UstawInformacjeOPracowniku(string imie, string nazwisko, string nazwaStanowiska, Wynagrodzenie wynagrodzenie, TypUmowy umowa, int czasUmowyWMiesiacach, bool umowaNaCzasNieokreslony, ulong numerKonta)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.NazwaStanowiska = nazwaStanowiska;
            this._wynagrodzenie = wynagrodzenie;
            this.Umowa = umowa;
            this._czasUmowyWMiesiacach = czasUmowyWMiesiacach;
            this.UmowaNaCzasNieokreslony = umowaNaCzasNieokreslony;
            this.NumerKonta = numerKonta;
        }

        public string Imie { get; private set; }

        public string Nazwisko { get; private set; }


        public string NazwaStanowiska { get; private set; }

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

        public double Pensja
        {
            get
            {
                Console.WriteLine("Wymagana autoryzacja");
                Console.Write("Login: ");
                var login = Console.ReadLine();
                Console.Write("Haslo: ");
                var haslo = Console.ReadLine();
                if (login == "admin" && haslo == "admin")
                {
                    return this._wynagrodzenie.PobierzWartoscWynagrodzenia();
                }
                else
                {
                    Console.WriteLine("Blad autoryzacji");
                    return -1;
                }
            }
        }

        public void ZmienWynagrodzenie(double placaZasadnicza, double dodatekStazowy, float kosztUzyskaniaPrzychodu)
        {
            this._wynagrodzenie = this._wynagrodzenie.ZmienWartosci(placaZasadnicza, dodatekStazowy, kosztUzyskaniaPrzychodu);
        }

        public void WyplacWynagrodzenie()
        {
            var operacja = new Operacja();
            operacja.UstawDane(DateTime.Now, this._wynagrodzenie.PobierzWartoscWynagrodzenia(), this.NumerKonta, true, "Wyplata wynagrodzenia");
            this._operacje[0] = operacja;
        }

        private Wynagrodzenie _wynagrodzenie;

        public TypUmowy Umowa { get; set; }

        public int CzasUmowyWMiesiacach()
        {
            return this._czasUmowyWMiesiacach;
        }

        private int _czasUmowyWMiesiacach;

        public bool UmowaNaCzasNieokreslony { get; set; }

        public ulong NumerKonta { get; set; }
    }
}