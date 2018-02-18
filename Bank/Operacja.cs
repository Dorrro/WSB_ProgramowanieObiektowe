namespace Finanse.Pracownicy
{
    using System;

    internal class Operacja
    {
        public void UstawDane(DateTime data, double kwota, ulong numerKonta, bool realizacja, string tytul)
        {
            this._data = data;
            this._kwota = kwota;
            this._numerKonta = numerKonta;
            this._realizacja = realizacja;
            this._tytul = tytul;
        }

        private DateTime _data;
        private double _kwota;
        private ulong _numerKonta;
        private bool _realizacja;
        private string _tytul;

        public string PobierzDane()
        {
            return string.Format("" +
                                 "===============  Informacja o operacji ===============\n" +
                                 "Tytul: {0}\n" +
                                 "Kwota: {1}\n" +
                                 "Data: {2}\n" +
                                 "Numer konta: {3}", this._tytul, this._kwota, this._data, this._numerKonta);
        }
    }
}