using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class ModeleRowerowViewModel : WszystkieViewModel<RowerModel>
    {

        #region Lista

        public override void Load()
        {
            List = new ObservableCollection<RowerModel>
                (
                db.RowerModel.ToList()
                );
        }

        #endregion Lista
        #region Constructor
        public ModeleRowerowViewModel() : base()
        {
            DisplayName = "Modele rowerow";
        }
        #endregion
    }
}