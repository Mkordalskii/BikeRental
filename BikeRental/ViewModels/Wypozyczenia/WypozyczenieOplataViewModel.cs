using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class WypozyczenieOplataViewModel : WszystkieViewModel<WypozyczenieOplataForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<WypozyczenieOplataForAllView>
                (
                from oplata in db.WypozyczenieOplata
                where oplata.CzyAktywny == true
                select new WypozyczenieOplataForAllView
                {
                    OplataId = oplata.OplataId,
                    WypozyczenieId = oplata.WypozyczenieId,
                    Typ =
                        oplata.Typ == 0 ? "start" :
                        oplata.Typ == 1 ? "czas" :
                        oplata.Typ == 2 ? "doplata" :
                        oplata.Typ == 3 ? "strefa" :
                        oplata.Typ == 4 ? "kara" : "blad"
                }
                );
        }
        #endregion
        #region Constructor
        public WypozyczenieOplataViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie oplaty za wypozyczenie";
        }
        #endregion
    }
}
