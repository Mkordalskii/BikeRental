using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowyPlanCenowyViewModel : JedenViewModel<PlanCenowy>
    {
        #region Constructor

        public NowyPlanCenowyViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj Plan cenowy";
            item = new PlanCenowy { AktywnaOd = DateTime.Today }; //ustawiam AktywnyOd, bo pole to nie jest Nullable i domyslnie ustawia date na 01.01.0001
        }

        #endregion Constructor

        #region Properties

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

        public string Waluta
        {
            get
            {
                return item.Waluta;
            }
            set
            {
                if (item.Waluta != value)
                {
                    item.Waluta = value;
                    OnPropertyChanged(() => Waluta);
                }
            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }

        public DateTime AktywnaOd
        {
            get
            {
                return item.AktywnaOd;
            }
            set
            {
                if (item.AktywnaOd != value)
                {
                    item.AktywnaOd = value;
                    OnPropertyChanged(() => AktywnaOd);
                }
            }
        }

        public DateTime? AktywnaDo
        {
            get
            {
                return item.AktywnaDo;
            }
            set
            {
                if (item.AktywnaDo != value)
                {
                    item.AktywnaDo = value;
                    OnPropertyChanged(() => AktywnaDo);
                }
            }
        }

        #endregion Properties

        #region Commands

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 5;
            item.KiedyDodal = DateTime.Now;
            db.PlanCenowy.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }

        #endregion Commands
    }
}
