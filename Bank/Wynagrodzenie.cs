namespace Bank
{
    public struct Wynagrodzenie
    {
        private double _placaZasadnicza;
        private double _dodatekStazowy;
        private float _kosztUzyskaniaPrzychodu;

        public Wynagrodzenie ZmienWartosci(double placaZasadnicza, double dodatekStazowy, float kosztUzyskaniaPrzychodu)
        {
            this._placaZasadnicza = placaZasadnicza;
            this._dodatekStazowy = dodatekStazowy;
            this._kosztUzyskaniaPrzychodu = kosztUzyskaniaPrzychodu;

            return this;
        }

        public double PobierzWartoscWynagrodzenia()
        {
            var wartoscDoOpodatkowania = this._placaZasadnicza + this._dodatekStazowy;

            var podatek = wartoscDoOpodatkowania * 23 / 100 * this._kosztUzyskaniaPrzychodu;

            return wartoscDoOpodatkowania - podatek;
        }
    }
}