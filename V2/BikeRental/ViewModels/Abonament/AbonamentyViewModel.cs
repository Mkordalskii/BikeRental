using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class AbonamentyViewModel : WszystkieViewModel<AbonamentyForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<AbonamentyForAllView>
                (
                  from abonament in db.Abonament
                  where abonament.CzyAktywny == true
                  select new AbonamentyForAllView
                  {
                      AbonamentId = abonament.AbonamentId,
                      ImieKlienta = abonament.Klient.Imie,
                      NazwiskoKlienta = abonament.Klient.Nazwisko,
                      PlanCenowyNazwa = abonament.PlanCenowy.Nazwa,
                      DataStart = abonament.DataStart,
                      DataKoniec = abonament.DataKoniec,
                      Status = abonament.SlownikAbonamentStatus.Nazwa
                  }
                );
        }
        #endregion
        #region Constructor
        public AbonamentyViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie abonamenty";
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
