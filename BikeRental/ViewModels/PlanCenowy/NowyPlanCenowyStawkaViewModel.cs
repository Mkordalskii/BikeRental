using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class NowyPlanCenowyStawkaViewModel : JedenViewModel<PlanCenowyStawka>
    {
        #region Constructor

        public NowyPlanCenowyStawkaViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj stawke";
            item = new PlanCenowyStawka();
        }

        #endregion Constructor

        #region Properties

        public int PlanCenowyId
        {
            get
            {
                return item.PlanCenowyId;
            }
            set
            {
                if (item.PlanCenowyId != value)
                {
                    item.PlanCenowyId = value;
                    OnPropertyChanged(() => PlanCenowyId);
                }
            }
        }

        public byte Typ
        {
            get
            {
                return item.Typ;
            }
            set
            {
                if (item.Typ != value)
                {
                    item.Typ = value;
                    OnPropertyChanged(() => Typ);
                }
            }
        }

        public int? OdMinuty
        {
            get
            {
                return item.OdMinuty;
            }
            set
            {
                if (item.OdMinuty != value)
                {
                    item.OdMinuty = value;
                    OnPropertyChanged(() => OdMinuty);
                }
            }
        }

        public int? DoMinuty
        {
            get
            {
                return item.DoMinuty;
            }
            set
            {
                if (item.DoMinuty != value)
                {
                    item.DoMinuty = value;
                    OnPropertyChanged(() => DoMinuty);
                }
            }
        }

        public decimal? CenaZaMin
        {
            get
            {
                return item.CenaZaMin;
            }
            set
            {
                if (item.CenaZaMin != value)
                {
                    item.CenaZaMin = value;
                    OnPropertyChanged(() => CenaZaMin);
                }
            }
        }
        public decimal? OplataStartowa
        {
            get
            {
                return item.OplataStartowa;
            }
            set
            {
                if (item.OplataStartowa != value)
                {
                    item.OplataStartowa = value;
                    OnPropertyChanged(() => OplataStartowa);
                }
            }
        }
        public int? LimitDarmowychMin
        {
            get
            {
                return item.LimitDarmowychMin;
            }
            set
            {
                if (item.LimitDarmowychMin != value)
                {
                    item.LimitDarmowychMin = value;
                    OnPropertyChanged(() => LimitDarmowychMin);
                }
            }
        }
        public decimal? DoplataPoLimicie
        {
            get
            {
                return item.DoplataPoLimicie;
            }
            set
            {
                if (item.DoplataPoLimicie != value)
                {
                    item.DoplataPoLimicie = value;
                    OnPropertyChanged(() => DoplataPoLimicie);
                }
            }
        }

        #endregion
        #region Combobox
        public IQueryable<SlownikPlanCenowyStawkaTyp> TypItems
        {
            get
            {
                return
                    (
                        from typ in db.SlownikPlanCenowyStawkaTyp
                        select typ
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<PlanCenowy> PlanCenowyItems
        {
            get
            {
                return
                    (
                        from planCenowy in db.PlanCenowy
                        where planCenowy.CzyAktywny == true
                        select planCenowy
                    ).ToList().AsQueryable();
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.PlanCenowyStawka.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }

        #endregion
    }
}
