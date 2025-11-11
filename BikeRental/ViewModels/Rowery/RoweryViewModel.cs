using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
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
                       Stan =
                        rower.Stan == 0 ? "dostepny" :
                        rower.Stan == 1 ? "wypozyczony" :
                        rower.Stan == 2 ? "serwis" :
                        rower.Stan == 3 ? "zgubiony / ukradziony" : "nieznany",
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
    }
}