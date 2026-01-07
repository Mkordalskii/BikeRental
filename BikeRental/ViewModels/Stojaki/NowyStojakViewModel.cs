using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Linq;

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
        public int StacjaId
        {
            get
            {
                return item.StacjaId;
            }
            set
            {
                if (item.StacjaId != value)
                {
                    item.StacjaId = value;
                    OnPropertyChanged(() => StacjaId);
                    NumerMiejsca = GetNextNumerMiejsca(value);
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
        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = 1; ///np. zalogowany użytkownik
            item.KiedyDodal = DateTime.Now;
            db.Stojak.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        //podpowiada kolejny wolny numer miejsca
        private int GetNextNumerMiejsca(int stacjaId)
        {
            var max = db.Stojak
                .Where(s => s.StacjaId == stacjaId)
                .Select(s => (int?)s.NumerMiejsca)
                .Max();

            return (max ?? 0) + 1;
        }

        #endregion
        #region ComboBox
        public IQueryable<Stacja> StacjaItems
        {
            get
            {
                return
                    (
                        from stacja in db.Stacja
                        where stacja.CzyAktywny == true
                        select stacja
                    ).ToList().AsQueryable();
            }
        }

        #endregion
    }
}
