using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class SymulacjaWypozyczeniaB : DatabaseClass
    {
        public SymulacjaWypozyczeniaB(BikeRentalDbEntities db) : base(db)
        {
        }
        #region Funkcje biznesowe
        public decimal? SymulujKosztGodzinowo(int planCenowyId, int godziny)
        {
            if (godziny <= 0) return null;

            int totalMin = godziny * 60;

            //Pobieramy wszystkie stawki planu
            List<PlanCenowyStawka> stawki = db.PlanCenowyStawka
            .Where(s => s.CzyAktywny == true && s.PlanCenowyId == planCenowyId)
            .ToList();

            if (!stawki.Any()) return null;

            decimal oplataStartowa = stawki
                .Where(s => s.OplataStartowa.HasValue)
                .Select(s => s.OplataStartowa.Value)
                .DefaultIfEmpty(0m)
                .Max();

            int darmoweMin = stawki
                .Where(s => s.LimitDarmowychMin.HasValue)
                .Select(s => s.LimitDarmowychMin.Value)
                .DefaultIfEmpty(0)
                .Max();

            int paidFromMin = darmoweMin + 1; // minuty > darmowe są płatne

            decimal koszt = oplataStartowa;

            //Jeśli mamy przedziały czasowe (Typ=0, CenaZaMin) -> liczymy przedziałami (Standard)
            var przedzialy = stawki
                .Where(s => s.Typ == 0 && s.CenaZaMin.HasValue)
                .OrderBy(s => s.OdMinuty ?? 0)
                .ToList();

            if (przedzialy.Any())
            {
                foreach (var p in przedzialy)
                {
                    int od = (p.OdMinuty ?? 0);
                    int doM = p.DoMinuty ?? int.MaxValue;

                    //płacimy tylko za część wspólną: [paidFromMin..totalMin] czyli [od..doM]
                    int start = Math.Max(paidFromMin, od);
                    int end = Math.Min(totalMin, doM);

                    if (end < start) continue;

                    int iloscMinut = (end - start) + 1;
                    koszt += iloscMinut * p.CenaZaMin.Value;
                }

                return Math.Round(koszt, 2);
            }

            //Jeśli NIE mamy Typ=0 (np. Firma), to liczymy: darmowe minuty + DoplataPoLimicie
            int platneMinuty = Math.Max(0, totalMin - darmoweMin);

            decimal doplataPoLimicie = stawki
                .Where(s => s.DoplataPoLimicie.HasValue)
                .Select(s => s.DoplataPoLimicie.Value)
                .DefaultIfEmpty(0m)
                .Max();

            //awaryjnie: gdyby ktoś trzymał stawkę w CenaZaMin mimo braku przedziałów
            if (doplataPoLimicie == 0m)
            {
                doplataPoLimicie = stawki
                    .Where(s => s.CenaZaMin.HasValue)
                    .Select(s => s.CenaZaMin.Value)
                    .DefaultIfEmpty(0m)
                    .Max();
            }

            koszt += platneMinuty * doplataPoLimicie;

            return Math.Round(koszt, 2);
        }
        #endregion
    }
}
