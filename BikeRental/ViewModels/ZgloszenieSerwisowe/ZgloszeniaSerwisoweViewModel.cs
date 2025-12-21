using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class ZgloszeniaSerwisoweViewModel : WszystkieViewModel<ZgloszenieSerwisoweForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZgloszenieSerwisoweForAllView>
                (
                  from zgloszenie in db.ZgloszenieSerwisowe
                  where zgloszenie.CzyAktywny == true
                  select new ZgloszenieSerwisoweForAllView
                  {
                      ZgloszenieId = zgloszenie.ZgloszenieId,
                      KodFloty = zgloszenie.Rower.KodFloty,
                      NumerSeryjny = zgloszenie.Rower.NumerSeryjny,
                      NazwiskoKlienta = zgloszenie.Klient.Nazwisko,
                      DataZgloszeniaUtc = zgloszenie.DataZgloszeniaUtc,
                      Priorytet = zgloszenie.SlownikZgloszeniePriorytet.Nazwa,
                      Opis = zgloszenie.Opis,
                      Status = zgloszenie.SlownikZgloszenieStatus.Nazwa,
                      KodStacji = zgloszenie.Stacja.Kod
                  }
                );
        }
        #endregion
        #region Constructor
        public ZgloszeniaSerwisoweViewModel()
            : base()
        {
            base.DisplayName = "Zgloszenia serwisowe";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "cena", "kod", "nazwa" };
        }
        public override List<string> getComboBoxFindList()
        {
            return null;
        }
        public override void Sort()
        { }
        public override void Find()
        {

        }
        #endregion
    }
}
