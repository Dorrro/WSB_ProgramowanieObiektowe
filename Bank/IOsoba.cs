namespace Finanse.Pracownicy
{
    using System;

    public interface IOsoba
    {
        string Imie { get; }
        string Nazwisko { get; }
        DateTime DataUrodzenia { get; }
    }
}