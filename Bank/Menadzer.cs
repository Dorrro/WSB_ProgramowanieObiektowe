namespace Finanse.Pracownicy
{
    using System;
    using BankFinanse.Pracownicy;

    public class Menadzer : Pracownik
    {
        public Menadzer(Wynagrodzenie wynagrodzenie, int czasUmowyWMiesiacach, string imie, string nazwisko, TypUmowy umowa, bool umowaNaCzasNieokreslony, ulong numerKonta, string zarzadzanyZespol, DateTime dataUrodzenia) : base(wynagrodzenie, czasUmowyWMiesiacach, imie, nazwisko, "menadżer", umowa, umowaNaCzasNieokreslony, numerKonta, dataUrodzenia)
        {
            this.ZarzadzanyZespol = zarzadzanyZespol;
        }

        public Menadzer(Wynagrodzenie wynagrodzenie, int czasUmowyWMiesiacach, string imie, string nazwisko, TypUmowy umowa, ulong numerKonta, string zarzadzanyZespol, DateTime dataUrodzenia) : base(wynagrodzenie, czasUmowyWMiesiacach, imie, nazwisko, "menadżer", umowa, numerKonta, dataUrodzenia)
        {
            this.ZarzadzanyZespol = zarzadzanyZespol;
        }

        public Menadzer(string imie, string nazwisko, ulong numerKonta, string zarzadzanyZespol, DateTime dataUrodzenia) : base(imie, nazwisko, "menadżer", numerKonta, dataUrodzenia)
        {
            this.ZarzadzanyZespol = zarzadzanyZespol;
        }

        public Menadzer()
        { }

        public string ZarzadzanyZespol { get; set; }
    }
}