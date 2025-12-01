using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{

    public class NowaStacjaViewModel : JedenViewModel<Stacja>
    {
        #region Constructor
        public NowaStacjaViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj stacje";
            item = new Stacja();
        }
        #endregion
        #region Properties
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public decimal SzerGeo
        {
            get
            {
                return item.SzerGeo;
            }
            set
            {
                if (item.SzerGeo != value)
                {
                    item.SzerGeo = value;
                    OnPropertyChanged(() => SzerGeo);
                }
            }
        }
        public decimal DlugGeo
        {
            get
            {
                return item.DlugGeo;
            }
            set
            {
                if (item.DlugGeo != value)
                {
                    item.DlugGeo = value;
                    OnPropertyChanged(() => DlugGeo);
                }
            }
        }
        public string GodzinyOtwarcia
        {
            get
            {
                return item.GodzinyOtwarcia;
            }
            set
            {
                if (item.GodzinyOtwarcia != value)
                {
                    item.GodzinyOtwarcia = value;
                    OnPropertyChanged(() => GodzinyOtwarcia);
                }
            }
        }
        #endregion
        #region Commands
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.Stacja.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
