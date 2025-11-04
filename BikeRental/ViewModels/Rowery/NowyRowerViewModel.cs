using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowyRowerViewModel : JedenViewModel<Rower>
    {
        #region Constructor
        public NowyRowerViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj Rower";
            item = new Rower();
        }
        #endregion
        #region Properties
        public string NumerSeryjny
        {
            get
            {
                return item.NumerSeryjny;
            }
            set
            {
                if (item.NumerSeryjny != value)
                {
                    item.NumerSeryjny = value;
                    OnPropertyChanged(() => NumerSeryjny);
                }
            }
        }
        #endregion
        #region Commands
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 5;
            item.KiedyDodal = DateTime.Now;
            db.Rower.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
