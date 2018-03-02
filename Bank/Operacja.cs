namespace Finanse.Pracownicy
{
    using System;

    public class Operacja
    {
        public Operacja(DateTime data, double kwota, ulong numerKonta, string tytul)
        {
            this.Data = data;
            this.Kwota = kwota;
            this.NumerKonta = numerKonta;
            this.Tytul = tytul;
            this.Realizacja = true;
        }

        public Operacja(DateTime data, double kwota, ulong numerKonta, bool realizacja, string tytul)
        {
            this.Data = data;
            this.Kwota = kwota;
            this.NumerKonta = numerKonta;
            this.Realizacja = realizacja;
            this.Tytul = tytul;
        }

        public Operacja()
        { }

        ~Operacja() { }

        public void UstawDane(DateTime data, double kwota, ulong numerKonta, bool realizacja, string tytul)
        {
            this.Data = data;
            this.Kwota = kwota;
            this.NumerKonta = numerKonta;
            this.Realizacja = realizacja;
            this.Tytul = tytul;
        }

        public DateTime Data { get; private set; }
        public double Kwota { get; private set; }
        public ulong NumerKonta { get; private set; }
        public bool Realizacja { get; private set; }
        public string Tytul { get; private set; }

        public string PobierzDane()
        {
            return string.Format("" +
                                 "===============  Informacja o operacji ===============\n" +
                                 "Tytul: {0}\n" +
                                 "Kwota: {1}\n" +
                                 "Data: {2}\n" +
                                 "Numer konta: {3}", this.Tytul, this.Kwota, this.Data, this.NumerKonta);
        }
    }
}