using BikeRental.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class SerwisB : DatabaseClass
    {
        public SerwisB(BikeRentalDbEntities db) : base(db)
        {
        }


        //Zwraca listę rowerów do serwisu wg reguł:
        //przegląd starszy niż (dzisiaj - progDniOdPrzegladu) (jeśli prog podany)
        //przebieg >= progPrzebieguKm (jeśli prog podany)
        //filtr po stacji (ostatnia)
        //opcjonalnie tylko dostępne (StanId = 0)
        public List<RowerDoSerwisuForAllView> PobierzListeDoSerwisu(
            int? stacjaId,
            bool tylkoDostepne,
            decimal? progPrzebieguKm,
            int? progDniOdPrzegladu)
        {
            DateTime dzisiaj = DateTime.Today;
            DateTime? granicaPrzegladu = null;

            if (progDniOdPrzegladu.HasValue)
            {
                granicaPrzegladu = dzisiaj.AddDays(-progDniOdPrzegladu.Value);
            }

            IQueryable<Rower> q =
                from r in db.Rower
                where r.CzyAktywny == true
                select r;

            if (stacjaId.HasValue)
            {
                q = q.Where(r => r.OstatniaStacjaId == stacjaId.Value);
            }

            if (tylkoDostepne == true)
            {
                //0 = Dostępny
                q = q.Where(r => r.Stan == 0);
            }

            //Filtr reguł serwisowych
            if (progPrzebieguKm.HasValue || granicaPrzegladu.HasValue)
            {
                //Jeśli użytkownik podał oba progi, rower wpada na listę gdy spełni którykolwiek
                q = q.Where(r =>
                    (progPrzebieguKm.HasValue && (r.PrzebiegKm ?? 0m) >= progPrzebieguKm.Value)
                    ||
                    (granicaPrzegladu.HasValue && r.DataPrzegladu.HasValue && r.DataPrzegladu.Value <= granicaPrzegladu.Value)
                    ||
                    (granicaPrzegladu.HasValue && !r.DataPrzegladu.HasValue) //jeśli brak daty przeglądu to też ma być wyświetlone
                );
            }

            //Bierzemy dane do pamięci
            List<Rower> rowery = q.ToList();

            List<RowerDoSerwisuForAllView> wynik = new List<RowerDoSerwisuForAllView>();

            foreach (Rower r in rowery)
            {
                string powod = ZbudujPowod(r, progPrzebieguKm, granicaPrzegladu);

                RowerDoSerwisuForAllView dto = new RowerDoSerwisuForAllView();
                dto.RowerId = r.RowerId;
                dto.KodFloty = r.KodFloty;
                dto.NumerSeryjny = r.NumerSeryjny;
                dto.Model = (r.RowerModel != null) ? (r.RowerModel.Producent + " " + r.RowerModel.Nazwa) : null;
                dto.Stan = (r.SlownikRowerStan != null) ? r.SlownikRowerStan.Nazwa : r.Stan.ToString();
                dto.Stacja = (r.Stacja != null) ? r.Stacja.Nazwa : null;
                dto.PrzebiegKm = r.PrzebiegKm;
                dto.DataPrzegladu = r.DataPrzegladu;
                dto.Powod = powod;

                wynik.Add(dto);
            }

            //Sortowanie: najpierw "najgorsze" przypadki po przebiegu, a potem po kodzie floty
            List<RowerDoSerwisuForAllView> posortowane =
                wynik
                .OrderByDescending(x => x.PrzebiegKm.HasValue ? x.PrzebiegKm.Value : 0m)
                .ThenBy(x => x.KodFloty)
                .ToList();

            return posortowane;
        }

        private string ZbudujPowod(Rower r, decimal? progPrzebieguKm, DateTime? granicaPrzegladu)
        {
            List<string> powody = new List<string>();

            if (progPrzebieguKm.HasValue)
            {
                decimal przebieg = r.PrzebiegKm.HasValue ? r.PrzebiegKm.Value : 0m;
                if (przebieg >= progPrzebieguKm.Value)
                {
                    powody.Add("Przebieg przekroczył " + progPrzebieguKm.Value.ToString("0.##") + " km");
                }
            }

            if (granicaPrzegladu.HasValue)
            {
                if (!r.DataPrzegladu.HasValue)
                {
                    powody.Add("Brak daty przeglądu");
                }
                else if (r.DataPrzegladu.Value <= granicaPrzegladu.Value)
                {
                    powody.Add("Data przeglądu przekroczona " + granicaPrzegladu.Value.ToString("yyyy-MM-dd"));
                }
            }

            if (powody.Count == 0)
            {
                return "Spełnia kryteria serwisowe";
            }

            return string.Join(", ", powody);
        }
    }
}
