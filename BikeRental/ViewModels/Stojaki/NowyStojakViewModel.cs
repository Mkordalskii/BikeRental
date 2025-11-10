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
            Sprawny = true;
        }
        #endregion
        #region Properties
        public Stacja Stacja
        {
            get
            {
                return item.Stacja;
            }
            set
            {
                if (item.Stacja != value)
                {
                    item.Stacja = value;
                    OnPropertyChanged(() => Stacja);
                }
            }
        }
        public int NumerMiejsca
        {
            get
            {
                return item.NumerMiejsca;
            }
            set
            {
                if (item.NumerMiejsca != value)
                {
                    item.NumerMiejsca = value;
                    OnPropertyChanged(() => NumerMiejsca);
                }
            }
        }
        public bool Sprawny
        {
            get
            {
                return item.Sprawny;
            }
            set
            {
                if (item.Sprawny != value)
                {
                    item.Sprawny = value;
                    OnPropertyChanged(() => Sprawny);
                    OnPropertyChanged(() => Niesprawny);
                }
            }
        }
        public bool Niesprawny
        {
            get => !Sprawny;
            set
            {
                //ustawiamy Sprawny jako negację value
                Sprawny = !value;
            }
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
