using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
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
                    Typ = oplata.SlownikWypozyczenieOplataTyp.Nazwa
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
