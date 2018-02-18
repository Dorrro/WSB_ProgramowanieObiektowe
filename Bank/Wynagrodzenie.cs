namespace Finanse.Pracownicy
{
    public struct Wynagrodzenie
    {
        private double _placaZasadnicza;
        private double _dodatekStazowy;
        private double _kosztUzyskaniaPrzychodu;

        public Wynagrodzenie(double placaZasadnicza, double dodatekStazowy, double kosztUzyskaniaPrzychodu)
        {
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