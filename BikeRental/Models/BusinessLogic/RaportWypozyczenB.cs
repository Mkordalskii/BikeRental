using BikeRental.Models.EntitiesForView;
using System;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class RaportWypozyczenB : DatabaseClass
    {
        #region Konstruktor
        public RaportWypozyczenB(BikeRentalDbEntities db) : base(db)
        {
        }
        #endregion
        #region Funkcje pomocnicze
        public IQueryable<KeyAndValue> GetKlienciCollection()
        {
            return
                db.Klient
                .Where(klient => klient.CzyAktywny == true)
                .Select(klient => new KeyAndValue
                {
                    Key = klient.KlientId,
                    Value = klient.Imie == null ? klient.Nazwisko : klient.Imie + " " + klient.Nazwisko
                }).ToList().AsQueryable();
        }

        public IQueryable<KeyAndValue> GetStacjeCollection()
        {
            return
                db.Stacja
                .Where(stacja => stacja.CzyAktywny == true)
                .Select(stacja => new KeyAndValue
                {
                    Key = stacja.StacjaId,
                    Value = stacja.Nazwa
                }).ToList().AsQueryable();
        }

        public IQueryable<KeyAndValue> GetRoweryCollection()
        {
            return
                db.Rower
                .Where(rower => rower.CzyAktywny == true)
                .Select(rower => new KeyAndValue
                {
                    Key = rower.RowerId,
                    Value = rower.KodFloty
                }).ToList().AsQueryable();
        }

        public RaportWypozyczenPodsumowanieB GenerujPodsumowanie(
            DateTime dataOd,
            DateTime dataDo,
            int? klientId,
            int? rowerId,
            int? stacjaStartId,
            int? stacjaKoniecId)
        {
            IQueryable<Wypozyczenie> q = db.Wypozyczenie
                .Where(w => w.StartUtc >= dataOd && w.KoniecUtc <= dataDo);

            if (klientId.HasValue)
                q = q.Where(w => w.KlientId == klientId.Value);

            if (rowerId.HasValue)
                q = q.Where(w => w.RowerId == rowerId.Value);

            if (stacjaStartId.HasValue)
                q = q.Where(w => w.StartStacjaId == stacjaStartId.Value);

            if (stacjaKoniecId.HasValue)
                q = q.Where(w => w.KoniecStacjaId == stacjaKoniecId.Value);

            var dane = q.Select(w => new
            {
                w.StartUtc,
                w.KoniecUtc,
                Kilometry = w.OdlegloscKm ?? 0m,
                Kwota = w.WypozyczenieOplata.Sum(o => (decimal?)o.Kwota) ?? 0m
            }).ToList();

            return new RaportWypozyczenPodsumowanieB
            {
                LiczbaWypozyczen = dane.Count,
                LacznyCzasMin = dane.Sum(x => (int)(x.KoniecUtc - x.StartUtc).TotalMinutes),
                LacznyDystansKm = dane.Sum(x => x.Kilometry),
                Przychod = dane.Sum(x => x.Kwota)
            };
            #endregion
        }
    }
}
