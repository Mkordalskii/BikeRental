using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class RaportWypozyczenPodsumowanieB : DatabaseClass
    {
        #region Konstruktor
        public RaportWypozyczenPodsumowanieB(BikeRentalDbEntities db) : base(db) { }
        #endregion

        #region Funkcje biznesowe
        public int LiczbaWypozyczenOkres(
            DateTime odData, DateTime doData,
            int? klientId, int? rowerId, int? stacjaStartId, int? stacjaKoniecId)
        {
            IQueryable<Wypozyczenie> q = Filtruj(odData, doData, klientId, rowerId, stacjaStartId, stacjaKoniecId);
            return q.Count();
        }

        public int LacznyCzasMinOkres(
            DateTime odData, DateTime doData,
            int? klientId, int? rowerId, int? stacjaStartId, int? stacjaKoniecId)
        {

            return Filtruj(odData, doData, klientId, rowerId, stacjaStartId, stacjaKoniecId)
                .Select(w => new { w.StartUtc, w.KoniecUtc })
                .ToList().Sum(x => (int)(x.KoniecUtc - x.StartUtc).TotalMinutes);
        }

        public decimal LacznyDystansKmOkres(
            DateTime odData, DateTime doData,
            int? klientId, int? rowerId, int? stacjaStartId, int? stacjaKoniecId)
        {
            IQueryable<Wypozyczenie> q = Filtruj(odData, doData, klientId, rowerId, stacjaStartId, stacjaKoniecId);

            return q.Select(w => (decimal?)(w.OdlegloscKm) ?? 0m).ToList().Sum();
        }

        public decimal PrzychodOkres(
            DateTime odData, DateTime doData,
            int? klientId, int? rowerId, int? stacjaStartId, int? stacjaKoniecId)
        {
            List<decimal> q = Filtruj(odData, doData, klientId, rowerId, stacjaStartId, stacjaKoniecId)
                .Select(w => w.WypozyczenieOplata.Sum(o => (decimal?)o.Kwota) ?? 0m)
                .ToList();

            return q.Sum();
        }

        private IQueryable<Wypozyczenie> Filtruj(
            DateTime odData, DateTime doData,
            int? klientId, int? rowerId, int? stacjaStartId, int? stacjaKoniecId)
        {
            //ważne: "Do" jako cały dzień z DatePickera
            DateTime od = odData.Date;
            DateTime doExclusive = doData.Date.AddDays(1);

            IQueryable<Wypozyczenie> q =
                from w in db.Wypozyczenie
                where w.StartUtc >= od && w.StartUtc < doExclusive
                select w;

            if (klientId.HasValue) q = q.Where(w => w.KlientId == klientId.Value);
            if (rowerId.HasValue) q = q.Where(w => w.RowerId == rowerId.Value);
            if (stacjaStartId.HasValue) q = q.Where(w => w.StartStacjaId == stacjaStartId.Value);
            if (stacjaKoniecId.HasValue) q = q.Where(w => w.KoniecStacjaId == stacjaKoniecId.Value);

            return q;
        }
        #endregion
    }
}
