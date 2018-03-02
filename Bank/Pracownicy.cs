namespace Finanse.Pracownicy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Pracownicy : IEnumerable<Pracownik>, IEnumerator<Pracownik>
    {
        private List<Pracownik> ListaPracownikow = new List<Pracownik>();

        public Pracownik this[string imie, string nazwisko]
        {
            get
            {
                return this.ListaPracownikow.FirstOrDefault(p => p.Imie == imie && p.Nazwisko == nazwisko);
            }
        }

        public void Add(Pracownik pracownik)
        {
            this.ListaPracownikow.Add(pracownik);
        }

        public void UsunPracownika(Pracownik pracownik)
        {
            try
            {
                this.ListaPracownikow.Remove(pracownik);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd usuwania pracownika\n{0}", e);
            }
        }

        public Pracownik PobierzPracownika(Func<Pracownik, bool> filter)
        {
            return this.ListaPracownikow.SingleOrDefault(filter);
        }

        public IEnumerator<Pracownik> GetEnumerator()
        {
            return this.ListaPracownikow.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            foreach (var pracownik in this.ListaPracownikow)
            {
                pracownik.Dispose();
            }
        }

        public bool MoveNext()
        {
            return this.ListaPracownikow.GetEnumerator()
                .MoveNext();
        }

        public void Reset()
        { 
        }

        public Pracownik Current { get; }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }
    }
}
