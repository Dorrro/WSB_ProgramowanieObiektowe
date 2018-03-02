namespace Finanse.Pracownicy
{
    using System;
    using System.Collections.Generic;
    using BankFinanse.Pracownicy;

    public class Pracownik : Osoba, IEquatable<Pracownik>, IComparable<Pracownik>, ICloneable, IDisposable
    {
        public Pracownik(Wynagrodzenie wynagrodzenie, int czasUmowyWMiesiacach, string imie, string nazwisko, string nazwaStanowiska, TypUmowy umowa, bool umowaNaCzasNieokreslony, ulong numerKonta, DateTime dataUrodzenia) : base(imie, nazwisko, dataUrodzenia)
        {
            if (umowaNaCzasNieokreslony && umowa == TypUmowy.OPace)
            {
                throw new ArgumentException("Pierwsza umowa nie może być na czas nieokreślony");
            }
            if (wynagrodzenie.PobierzWartoscWynagrodzenia() > 10000)
            {
                throw new ArgumentException("Wynagrodzenie nie może być wyższe niż 10000");
            }
            this._wynagrodzenie = wynagrodzenie;
            this._czasUmowyWMiesiacach = czasUmowyWMiesiacach;
            this.NazwaStanowiska = nazwaStanowiska;
            this.Umowa = umowa;
            this.UmowaNaCzasNieokreslony = umowaNaCzasNieokreslony;
            this.NumerKonta = numerKonta;
        }

        public Pracownik(Wynagrodzenie wynagrodzenie, int czasUmowyWMiesiacach, string imie, string nazwisko, string nazwaStanowiska, TypUmowy umowa, ulong numerKonta, DateTime dataUrodzenia) : base(imie, nazwisko, dataUrodzenia)
        {
            if (wynagrodzenie.PobierzWartoscWynagrodzenia() > 10000)
            {
                throw new ArgumentException("Wynagrodzenie nie może być wyższe niż 10000");
            }
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

        public bool Equals(Pracownik other)
        {
            if (other == null)
                return false;

            if (this.Imie == other.Imie && this.Nazwisko == other.Nazwisko)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(Pracownik other)
        {
            if (other == null)
                return -1;

            if (this.Equals(other))
            {
                return 0;
            }

            return 1;
        }

        ~Pracownik() {
        }

        public override void Zainteresowania(string zainteresowanie)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return this.PobierzDane();
        }

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
            try
            {
                var staraWartosc = this._wynagrodzenie.PobierzWartoscWynagrodzenia();
                this._wynagrodzenie = new Wynagrodzenie(placaZasadnicza, dodatekStazowy, kosztUzyskaniaPrzychodu);
                var nowaWartosc = this._wynagrodzenie.PobierzWartoscWynagrodzenia();
                if (this.OnZmianaWynagrodzenia != null)
                {
                    this.OnZmianaWynagrodzenia(staraWartosc, nowaWartosc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd podczas zmiany wynagrodzenia\n{0}", e);
            }
        }

        public void WyplacWynagrodzenie()
        {
            try
            {
                var operacja = new Operacja(DateTime.Now, this._wynagrodzenie.PobierzWartoscWynagrodzenia(), this.NumerKonta, true, "Wyplata wynagrodzenia");
                this._operacje.Add(operacja);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd dodawania operacji do listy\n{0}", e);
            }
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
            get
            {
                Operacja operacja = null;
                try
                {
                    operacja = this._operacje[index];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wystąpił błąd pobierania operacji przez index\n{0}", e);
                }
                return operacja;
            }
        }

        public static Pracownik UtworzPracownika(string imie, string nazwisko)
        {
            var podstawoweWynagrodzenie = new Wynagrodzenie(1500, 0, 1.0);

            return new Pracownik(podstawoweWynagrodzenie, 0, imie, nazwisko, "pracownik", TypUmowy.OPace, 0, new DateTime());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public static bool operator ==(Pracownik p1, Pracownik p2)
        {
            return Equals(p2, p1) || (!Equals(null, p1) && !Equals(null, p2) && p1.Equals(p2));
        }

        public static bool operator !=(Pracownik p1, Pracownik p2)
        {
            return Equals(null, p1) || Equals(null, p2) || !p1.Equals(p2);
        }

        public static explicit operator double(Pracownik p)
        {
            return p._wynagrodzenie.PobierzWartoscWynagrodzenia();
        }

        public delegate void ZmianaWynagrodzenia(double staraWartosc, double nowaWartosc);

        public ZmianaWynagrodzenia OnZmianaWynagrodzenia;
    }
}