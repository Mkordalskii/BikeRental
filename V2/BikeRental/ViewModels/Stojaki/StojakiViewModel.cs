using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    internal class StojakiViewModel : WszystkieViewModel<StojakiForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<StojakiForAllView>
                (
                from stojak in db.Stojak
                where stojak.CzyAktywny == true
                select new StojakiForAllView
                {
                    StojakId = stojak.StojakId,
                    NazwaStacji = stojak.Stacja.Nazwa,
                    NumerMiejsca = stojak.NumerMiejsca,
                    CzySprawny =
                        stojak.Sprawny == true ? "Tak" :
                        stojak.Sprawny == false ? "Nie" : "Nieznany"
                }
                );
        }
        #endregion Lista
        #region Constructor
        public StojakiViewModel() : base()
        {
            DisplayName = "Wszystkie stojaki";
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
