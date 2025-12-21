using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class StacjeViewModel : WszystkieViewModel<Stacja>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Stacja>
                (
                db.Stacja.ToList()
                );
        }
        #endregion
        #region Constructor
        public StacjeViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie stacje";
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
