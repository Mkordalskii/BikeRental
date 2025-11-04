using BikeRental.Helper;
using BikeRental.Models;
using System.Windows.Input;

namespace BikeRental.ViewModels.Abstract
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel //T typ ktory bedzie dodawany
    {
        #region Database
        protected BikeRentalDbEntities db;
        protected T item;
        #endregion
        #region Constructor 
        public JedenViewModel()
        {
            db = new BikeRentalDbEntities();
        }
        #endregion

        #region Commands
        //to jest komenda ktora zostanie podpieta pod przycisk zapisz i zamknij
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null) _SaveAndCloseCommand = new BaseCommand(saveAndClose); //ta komenda wywola metode saveAndClose ktora jest zdefiniowana nizej
                return _SaveAndCloseCommand;
            }
        }
        public abstract void Save();
        private void saveAndClose()
        {
            Save();
            //zamykamy zakladke przez metode z WorkSpaceViewModel
            OnRequestClose();//najpierw zmien w WorkspaceViewModel z private na protected
        }
        #endregion
    }
}