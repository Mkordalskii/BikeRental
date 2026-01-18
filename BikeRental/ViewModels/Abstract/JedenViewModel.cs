using BikeRental.Helper;
using BikeRental.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (IsValid())
            {
                Save();
                //zamykamy zakladke przez metode z WorkSpaceViewModel
                ShowMessageBox("Dodano dokument");
                OnRequestClose();//najpierw zmien w WorkspaceViewModel z private na protected
            }
            else
                ShowMessageBox("Popraw bledy");
        }
        protected static void Fill(ObservableCollection<ForeignKeyIdAndNameRecord> target, IEnumerable<ForeignKeyIdAndNameRecord> items)
        {
            target.Clear();
            foreach (var x in items) target.Add(x);
        }
        #endregion
        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion
    }
}