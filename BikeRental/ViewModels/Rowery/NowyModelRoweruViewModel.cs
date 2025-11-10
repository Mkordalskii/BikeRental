using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowyModelRoweruViewModel : JedenViewModel<RowerModel>
    {
        #region MyRegion
        public NowyModelRoweruViewModel() : base()
        {
            DisplayName = "Dodaj/edytuj modele";
            item = new RowerModel();
        }
        #endregion
        #region Commands

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = 5; ///np. zalogowany użytkownik
            item.KiedyDodal = DateTime.Now;
            db.RowerModel.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }

        #endregion Commands
    }
}
