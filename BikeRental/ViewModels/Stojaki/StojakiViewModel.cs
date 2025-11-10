using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    internal class StojakiViewModel : WszystkieViewModel<Stojak>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Stojak>
                (
                db.Stojak.ToList()
                );
        }
        #endregion Lista
        #region Constructor
        public StojakiViewModel() : base()
        {
            DisplayName = "Wszystkie stojaki";
        }
        #endregion
    }
}
