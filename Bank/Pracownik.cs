namespace Finanse.Pracownicy
{
    using System;
    using System.Collections.Generic;
    using BankFinanse.Pracownicy;

    public class Pracownik : Osoba
    {
        public Pracownik(Wynagrodzenie wynagrodzenie, int czasUmowyWMiesiacach, string imie, string nazwisko, string nazwaStanowiska, TypUmowy umowa, bool umowaNaCzasNieokreslony, ulong numerKonta, DateTime dataUrodzenia) : base(imie, nazwisko, dataUrodzenia)
        {
            this._wynagrodzenie = wynagrodzenie;
            this._czasUmowyWMiesiacach = czasUmowyWMiesiacach;
            this.NazwaStanowiska = nazwaStanowiska;
            this.Umowa = umowa;
            this.UmowaNaCzasNieokreslony = umowaNaCzasNieokreslony;
            this.NumerKonta = numerKonta;
        }

        public Pracownik(Wynagrodzenie wynagrodzenie, int czasUmowyWMiesiacach, string imie, string nazwisko, string nazwaStanowiska, TypUmowy umowa, ulong numerKonta, DateTime dataUrodzenia) : base(imie, nazwisko, dataUrodzenia)
        {
            this._wynagrodzenie = wynagrodzenie;
            this._czasUmowyWMiesiacach = czasUmowyWMiesiacach;
            this.NazwaStanowiska = nazwaStanowiska;
            this.Umowa = umowa;
            this.NumerKonta = numerKonta;
        }

        public Pracownik(string imie, string nazwisko, string nazwaStanowiska, ulong numerKonta, DateTime dataUrodzenia) : base(imie, nazwisko, dataUrodzenia)
        {
            this.NazwaStanowiska = nazwaStanowiska;
            this.NumerKonta = numerKonta;
            this.Umowa = TypUmowy.OPace;
            this.UmowaNaCzasNieokreslony = true;
        }

        ~Pracownik() { }

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

        public string NazwaStanowiska { get; private set; }

        public double DodatekWakacyjny()
        {
            return _dodatekWakacyjny;
        }

        public void ZmienDodatekWakacyjny(double wartosc)
        {
            _dodatekWakacyjny = wartosc;
        }

        protected static double _dodatekWakacyjny = 1000;

        protected List<Operacja> _operacje = new List<Operacja>();

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
            this._wynagrodzenie = new Wynagrodzenie(placaZasadnicza, dodatekStazowy, kosztUzyskaniaPrzychodu);
        }

        public void WyplacWynagrodzenie()
        {
            var operacja = new Operacja(DateTime.Now, this._wynagrodzenie.PobierzWartoscWynagrodzenia(), this.NumerKonta, true, "Wyplata wynagrodzenia");
            this._operacje.Add(operacja);
        }

        protected Wynagrodzenie _wynagrodzenie;

        public TypUmowy Umowa { get; set; }

        public int CzasUmowyWMiesiacach()
        {
            return this._czasUmowyWMiesiacach;
        }

        protected int _czasUmowyWMiesiacach;

        public bool UmowaNaCzasNieokreslony { get; set; }

        public ulong NumerKonta { get; set; }

        public void ZmienNazweStanowiska(string nazwa)
        {
            this.NazwaStanowiska = nazwa;
        }

        public Operacja this[int index]
        {
            get { return this._operacje[index]; }
            set { this._operacje[index] = value; }
        }

        public static Pracownik UtworzPracownika(string imie, string nazwisko)
        {
            var podstawoweWynagrodzenie = new Wynagrodzenie(1500, 0, 1.0);

            return new Pracownik(podstawoweWynagrodzenie, 0, imie, nazwisko, "pracownik", TypUmowy.OPace, 0, new DateTime());
        }
    }
}