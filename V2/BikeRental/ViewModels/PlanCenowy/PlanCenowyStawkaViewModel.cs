using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
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
                        Typ = stawka.SlownikPlanCenowyStawkaTyp.Nazwa,
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
