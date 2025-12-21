using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class RezerwacjeViewModel : WszystkieViewModel<RezerwacjeForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<RezerwacjeForAllView>
                (
                  from rezerwacja in db.Rezerwacja
                  where rezerwacja.CzyAktywny == true
                  select new RezerwacjeForAllView
                  {
                      RezerwacjaId = rezerwacja.RezerwacjaId,
                      KlientImie = rezerwacja.Klient.Imie,
                      KlientNazwisko = rezerwacja.Klient.Nazwisko,
                      KodFloty = rezerwacja.Rower.KodFloty,
                      DataOd = rezerwacja.DataOdUtc,
                      DataDo = rezerwacja.DataDoUtc
                  }
                );
        }
        #endregion
        #region Constructor
        public RezerwacjeViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie rezerwacje";
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
