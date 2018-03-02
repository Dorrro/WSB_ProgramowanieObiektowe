namespace Finanse.Pracownicy
{
    using System;

    public struct Wynagrodzenie
    {
        private double _placaZasadnicza;
        private double _dodatekStazowy;
        private double _kosztUzyskaniaPrzychodu;

        public Wynagrodzenie(double placaZasadnicza, double dodatekStazowy, double kosztUzyskaniaPrzychodu)
        {
            if (kosztUzyskaniaPrzychodu > 1 || kosztUzyskaniaPrzychodu < 0)
            {
                throw new ArgumentException("Koszt uzyskania przychodu powinien mieć wartość pomiędzy 0, a 1");
            }
            this._placaZasadnicza = placaZasadnicza;
            this._dodatekStazowy = dodatekStazowy;
            this._kosztUzyskaniaPrzychodu = kosztUzyskaniaPrzychodu;
        }

        public double PobierzWartoscWynagrodzenia()
        {
            var wartoscDoOpodatkowania = this._placaZasadnicza + this._dodatekStazowy;

            var podatek = wartoscDoOpodatkowania * 23 / 100 * this._kosztUzyskaniaPrzychodu;

            return wartoscDoOpodatkowania - podatek;
        }
    }
}