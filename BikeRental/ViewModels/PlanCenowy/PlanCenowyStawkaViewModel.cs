using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class PlanCenowyStawkaViewModel : WszystkieViewModel<PlanCenowyStawkaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PlanCenowyStawkaForAllView>
                (
                    from stawka in db.PlanCenowyStawka
                    where stawka.CzyAktywny == true
                    select new PlanCenowyStawkaForAllView
                    {
                        StawkaId = stawka.StawkaId,
                        PlanCenowyNazwa = stawka.PlanCenowy.Nazwa,
                        Typ =
                            stawka.Typ == 0 ? "czas" :
                            stawka.Typ == 1 ? "strefa" :
                            stawka.Typ == 2 ? "oplata stala" :
                            stawka.Typ == 3 ? "kara" : "blad",
                        OdMinuty = stawka.OdMinuty,
                        DoMinuty = stawka.DoMinuty,
                        CenaZaMin = stawka.CenaZaMin,
                        OplataStartowa = stawka.OplataStartowa,
                        LimitDarmowychMin = stawka.LimitDarmowychMin,
                        DoplataPoLimicie = stawka.DoplataPoLimicie
                    }
                );
        }
        #endregion
        #region Constructor
        public PlanCenowyStawkaViewModel()
            : base()
        {
            base.DisplayName = "Stawki planow cenowych";
        }
        #endregion
    }
}
