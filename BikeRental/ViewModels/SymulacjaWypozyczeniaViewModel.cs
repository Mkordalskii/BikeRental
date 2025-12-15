using BikeRental.Helper;
using BikeRental.Models;
using BikeRental.Models.BusinessLogic;
using BikeRental.Models.EntitiesForView;
using System.Linq;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class SymulacjaWypozyczeniaViewModel : WorkspaceViewModel
    {
        #region Baza danych
        private readonly BikeRentalDbEntities db;
        #endregion

        #region Konstruktor
        public SymulacjaWypozyczeniaViewModel()
        {
            base.DisplayName = "Symulacja wypożyczenia";

            db = new BikeRentalDbEntities();
            Godziny = null;
            Dni = null;
            Koszt = null;
        }
        #endregion

        #region Pola i wlasciwosci
        private int? _PlanCenowyId;
        public int? PlanCenowyId
        {
            get
            {
                return _PlanCenowyId;
            }
            set
            {
                if (_PlanCenowyId != value)
                {
                    _PlanCenowyId = value;
                    OnPropertyChanged(() => PlanCenowyId);
                }
            }
        }

        private int? _Godziny;
        public int? Godziny
        {
            get
            {
                return _Godziny;
            }
            set
            {
                if (_Godziny != value)
                {
                    _Godziny = value;
                    OnPropertyChanged(() => Godziny);
                }
            }
        }

        private int? _Dni;
        public int? Dni
        {
            get
            {
                return _Dni;
            }
            set
            {
                if (_Dni != value)
                {
                    _Dni = value;
                    OnPropertyChanged(() => Dni);
                }
            }
        }

        private decimal? _Koszt;
        public decimal? Koszt
        {
            get
            {
                return _Koszt;
            }
            set
            {
                if (_Koszt != value)
                {
                    _Koszt = value;
                    OnPropertyChanged(() => Koszt);
                }
            }
        }

        // ComboBox: plany cenowe (KeyAndValue)
        public IQueryable<KeyAndValue> PlanyCenoweComboBoxItems
        {
            get
            {
                return new PlanCenowyB(db).GetPlanyCenoweKeyAndValueItems();
            }
        }
        #endregion

        #region Komendy
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(obliczClick);
                return _ObliczCommand;
            }
        }

        private void obliczClick()
        {
            if (!PlanCenowyId.HasValue)
            {
                Koszt = null;
                return;
            }

            int lacznaIloscGodzin = 0;

            if (Godziny.HasValue && Godziny.Value > 0)
                lacznaIloscGodzin = Godziny.Value;
            else if (Dni.HasValue && Dni.Value > 0)
                lacznaIloscGodzin = Dni.Value * 24;

            if (lacznaIloscGodzin <= 0)
            {
                Koszt = null;
                return;
            }

            Koszt = new SymulacjaWypozyczeniaB(db)
                .SymulujKosztGodzinowo(PlanCenowyId.Value, lacznaIloscGodzin);
        }

        private BaseCommand _WyczyscCommand;
        public ICommand WyczyscCommand
        {
            get
            {
                if (_WyczyscCommand == null)
                    _WyczyscCommand = new BaseCommand(wyczyscClick);
                return _WyczyscCommand;
            }
        }

        private void wyczyscClick()
        {
            PlanCenowyId = null;
            Godziny = null;
            Dni = null;
            Koszt = null;
        }
        #endregion
    }
}
