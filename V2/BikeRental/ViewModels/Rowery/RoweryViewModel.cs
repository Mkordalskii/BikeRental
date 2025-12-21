using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class RoweryViewModel : WszystkieViewModel<RoweryForAllView>
    {
        #region Lista

        public override void Load()
        {
            List = new ObservableCollection<RoweryForAllView>
                (
                   from rower in db.Rower
                   where rower.CzyAktywny == true
                   select new RoweryForAllView
                   {
                       RowerId = rower.RowerId,
                       RowerProducent = rower.RowerModel.Producent,
                       RowerNazwaModelu = rower.RowerModel.Nazwa,
                       NumerSeryjny = rower.NumerSeryjny,
                       KodFloty = rower.KodFloty,
                       Stan = rower.SlownikRowerStan.Nazwa,
                       OstatniaStacjaNazwa = rower.Stacja.Nazwa,
                       OstatniStojakId = rower.OstatniStojakId,
                       OstatniaSzerGeo = rower.OstatniaSzerGeo,
                       OstatniaDlugGeo = rower.OstatniaDlugGeo,
                       PrzebiegKm = rower.PrzebiegKm,
                       PoziomBateriiProc = rower.PoziomBateriiProc,
                       DataPrzegladu = rower.DataPrzegladu
                   }
                );
        }

        #endregion Lista

        #region Constructor

        public RoweryViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie rowery";
        }

        #endregion Constructor
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