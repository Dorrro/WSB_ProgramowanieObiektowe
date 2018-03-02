namespace Finanse.Pracownicy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pracownicy
    {
        private List<Pracownik> ListaPracownikow = new List<Pracownik>();

        public Pracownik this[string imie, string nazwisko]
        {
            get
            {
                return this.ListaPracownikow.FirstOrDefault(p => p.Imie == imie && p.Nazwisko == nazwisko);
            }
        }

        public void DodajPracownika(Pracownik pracownik)
        {
            this.ListaPracownikow.Add(pracownik);
        }

        public void UsunPracownika(Pracownik pracownik)
        {
            this.ListaPracownikow.Remove(pracownik);
        }

        public Pracownik PobierzPracownika(Func<Pracownik, bool> filter)
        {
            return this.ListaPracownikow.SingleOrDefault(filter);
        }
    }
}
