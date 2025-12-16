using BikeRental.Helper;
using BikeRental.Models;
using BikeRental.Models.BusinessLogic;
using BikeRental.Models.EntitiesForView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class ListaDoSerwisuViewModel : WorkspaceViewModel
    {
        private readonly BikeRentalDbEntities db;

        private int? _IdStacji;
        private bool _TylkoDostepne;
        private decimal? _ProgPrzebieguKm;
        private int? _ProgDniOdPrzegladu;

        private ObservableCollection<RowerDoSerwisuForAllView> _Lista;

        public ListaDoSerwisuViewModel()
        {
            DisplayName = "Lista do serwisu";
            db = new BikeRentalDbEntities();

            TylkoDostepne = false;
            ProgPrzebieguKm = null;
            ProgDniOdPrzegladu = null;

            Lista = new ObservableCollection<RowerDoSerwisuForAllView>();
        }
        #region Propertiesy

        public int? IdStacji
        {
            get { return _IdStacji; }
            set
            {
                if (_IdStacji != value)
                {
                    _IdStacji = value;
                    OnPropertyChanged(() => IdStacji);
                }
            }
        }

        public bool TylkoDostepne
        {
            get { return _TylkoDostepne; }
            set
            {
                if (_TylkoDostepne != value)
                {
                    _TylkoDostepne = value;
                    OnPropertyChanged(() => TylkoDostepne);
                }
            }
        }

        public decimal? ProgPrzebieguKm
        {
            get { return _ProgPrzebieguKm; }
            set
            {
                if (_ProgPrzebieguKm != value)
                {
                    _ProgPrzebieguKm = value;
                    OnPropertyChanged(() => ProgPrzebieguKm);
                }
            }
        }

        public int? ProgDniOdPrzegladu
        {
            get { return _ProgDniOdPrzegladu; }
            set
            {
                if (_ProgDniOdPrzegladu != value)
                {
                    _ProgDniOdPrzegladu = value;
                    OnPropertyChanged(() => ProgDniOdPrzegladu);
                }
            }
        }
        public IQueryable<KeyAndValue> StacjeComboBoxItems
        {
            get
            {
                return new StacjaB(db).GetStacjeKeyAndValueItems();
            }
        }

        public ObservableCollection<RowerDoSerwisuForAllView> Lista
        {
            get { return _Lista; }
            set
            {
                if (_Lista != value)
                {
                    _Lista = value;
                    OnPropertyChanged(() => Lista);
                }
            }
        }
        #endregion

        #region Komendy

        private BaseCommand _SzukajCommand;
        public ICommand SzukajCommand
        {
            get
            {
                if (_SzukajCommand == null)
                {
                    _SzukajCommand = new BaseCommand(szukajClick);
                }
                return _SzukajCommand;
            }
        }

        private void szukajClick()
        {
            SerwisB serwis = new SerwisB(db);

            List<RowerDoSerwisuForAllView> lista =
                serwis.PobierzListeDoSerwisu(
                    IdStacji,
                    TylkoDostepne,
                    ProgPrzebieguKm,
                    ProgDniOdPrzegladu);

            Lista = new ObservableCollection<RowerDoSerwisuForAllView>(lista);
        }

        private BaseCommand _WyczyscCommand;
        public ICommand WyczyscCommand
        {
            get
            {
                if (_WyczyscCommand == null)
                {
                    _WyczyscCommand = new BaseCommand(wyczyscClick);
                }
                return _WyczyscCommand;
            }
        }

        private void wyczyscClick()
        {
            IdStacji = null;
            TylkoDostepne = true;
            ProgPrzebieguKm = null;
            ProgDniOdPrzegladu = null;

            Lista = new ObservableCollection<RowerDoSerwisuForAllView>();
        }
        #endregion
    }
}
