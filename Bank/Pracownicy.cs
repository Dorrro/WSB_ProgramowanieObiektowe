namespace Finanse.Pracownicy
{
    using System.Collections.Generic;
    using System.Linq;

    public class Pracownicy
    {
        public List<Pracownik> ListaPracownikow = new List<Pracownik>();

        public Pracownik this[string imie, string nazwisko]
        {
            get
            {
                return this.ListaPracownikow.FirstOrDefault(p => p.Imie == imie && p.Nazwisko == nazwisko);
            }
        }
    }
}
