using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
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
            return new List<string> { "nazwa", "cena za minute", "oplata startowa", "doplata" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "nazwa" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<PlanCenowyStawkaForAllView>(List.OrderBy(item => item.PlanCenowyNazwa));
            if (SortField == "cena za minute")
                List = new ObservableCollection<PlanCenowyStawkaForAllView>(List.OrderBy(item => item.CenaZaMin));
            if (SortField == "oplata startowa")
                List = new ObservableCollection<PlanCenowyStawkaForAllView>(List.OrderBy(item => item.OplataStartowa));
            if (SortField == "oplata startowa")
                List = new ObservableCollection<PlanCenowyStawkaForAllView>(List.OrderBy(item => item.DoplataPoLimicie));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "nazwa")
                    List = new ObservableCollection<PlanCenowyStawkaForAllView>(List.Where(item => item.PlanCenowyNazwa != null && item.PlanCenowyNazwa.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
