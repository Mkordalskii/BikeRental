using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    internal class NowyStojakViewModel : JedenViewModel<Stojak>
    {
        #region Constructor
        public NowyStojakViewModel() : base()
        {
            DisplayName = "Dodaj stojak";
            item = new Stojak();
        }
        #endregion
        #region Commands
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = 5; ///np. zalogowany użytkownik
            item.KiedyDodal = DateTime.Now;
            db.Stojak.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }

        #endregion Commands
    }
}
