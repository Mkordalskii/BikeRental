using BikeRental.Helper;
using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class NowyRowerViewModel : JedenViewModel<Rower>
    {
        #region Constructor

        public NowyRowerViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj Rower";
            item = new Rower();
            DostepneStany = db.SlownikRowerStan
                .OrderBy(s => s.Kolejnosc)
                .ToList();
            Stan = (byte)DostepneStany[0].StanId; // ustawienie domyslnego typu
            DostepneModele = new ObservableCollection<ForeignKeyIdAndNameRecord>();
            DostepneStacje = new ObservableCollection<ForeignKeyIdAndNameRecord>();
            DostepneStojaki = new ObservableCollection<ForeignKeyIdAndNameRecord>();
            loadForeignKeyIdAndName();
        }

        #endregion Constructor

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

        public int RowerModelId
        {
            get
            {
                return item.RowerModelId;
            }
            set
            {
                if (item.RowerModelId != value)
                {
                    item.RowerModelId = value;
                    OnPropertyChanged(() => RowerModelId);
                }
            }
        }

        public string KodFloty
        {
            get
            {
                return item.KodFloty;
            }
            set
            {
                if (item.KodFloty != value)
                {
                    item.KodFloty = value;
                    OnPropertyChanged(() => KodFloty);
                }
            }
        }

        public byte Stan // 0 dostepny, 1 wypozyczony, 2 serwis, 3 zgubiony/ukradziony
        {
            get
            {
                return item.Stan;
            }
            set
            {
                if (item.Stan != value)
                {
                    item.Stan = value;
                    OnPropertyChanged(() => Stan);
                }
            }
        }

        public int? OstatniaStacjaId
        {
            get
            {
                return item.OstatniaStacjaId;
            }
            set
            {
                if (item.OstatniaStacjaId != value)
                {
                    item.OstatniaStacjaId = value;
                    OnPropertyChanged(() => OstatniaStacjaId);
                    LoadStojakiForStation(value); // po wybraniu stacji przeladuje stojaki
                }
            }
        }

        public int? OstatniStojakId
        {
            get
            {
                return item.OstatniStojakId;
            }
            set
            {
                if (item.OstatniStojakId != value)
                {
                    item.OstatniStojakId = value;
                    OnPropertyChanged(() => OstatniStojakId);
                }
            }
        }

        public decimal? OstatniaSzerGeo
        {
            get
            {
                return item.OstatniaSzerGeo;
            }
            set
            {
                if (item.OstatniaSzerGeo != value)
                {
                    item.OstatniaSzerGeo = value;
                    OnPropertyChanged(() => OstatniaSzerGeo);
                }
            }
        }

        public decimal? OstatniaDlugGeo
        {
            get
            {
                return item.OstatniaDlugGeo;
            }
            set
            {
                if (item.OstatniaDlugGeo != value)
                {
                    item.OstatniaDlugGeo = value;
                    OnPropertyChanged(() => OstatniaDlugGeo);
                }
            }
        }

        public decimal? PrzebiegKm
        {
            get
            {
                return item.PrzebiegKm;
            }
            set
            {
                if (item.PrzebiegKm != value)
                {
                    item.PrzebiegKm = value;
                    OnPropertyChanged(() => PrzebiegKm);
                }
            }
        }

        public byte? PoziomBateriiProc
        {
            get
            {
                return item.PoziomBateriiProc;
            }
            set
            {
                if (item.PoziomBateriiProc != value)
                {
                    item.PoziomBateriiProc = value;
                    OnPropertyChanged(() => PoziomBateriiProc);
                }
            }
        }

        public DateTime? DataPrzegladu
        {
            get
            {
                return item.DataPrzegladu;
            }
            set
            {
                if (item.DataPrzegladu != value)
                {
                    item.DataPrzegladu = value;
                    OnPropertyChanged(() => DataPrzegladu);
                }
            }
        }

        #endregion Properties

        #region Commands

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.Rower.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }

        #endregion Commands

        #region ComboBoxList
        public List<SlownikRowerStan> DostepneStany { get; }

        public ObservableCollection<ForeignKeyIdAndNameRecord> DostepneModele { get; }
        public ObservableCollection<ForeignKeyIdAndNameRecord> DostepneStacje { get; }
        public ObservableCollection<ForeignKeyIdAndNameRecord> DostepneStojaki { get; }

        private void loadForeignKeyIdAndName()
        {
            Fill(DostepneModele, db.RowerModel
                .AsNoTracking()
                .OrderBy(x => x.Nazwa)
                .Select(x => new ForeignKeyIdAndNameRecord { Id = x.RowerModelId, Name = x.Nazwa })
                .ToList());

            Fill(DostepneStacje, db.Stacja
                .AsNoTracking()
                .OrderBy(x => x.Nazwa)
                .Select(x => new ForeignKeyIdAndNameRecord { Id = x.StacjaId, Name = x.Nazwa })
                .ToList());
        }

        private void LoadStojakiForStation(int? stacjaId)
        {
            DostepneStojaki.Clear();
            if (!stacjaId.HasValue)
            {
                OstatniStojakId = null;
                return;
            }
            List<ForeignKeyIdAndNameRecord> stojaki = db.Stojak
                .AsNoTracking()
                .Where(s => s.StacjaId == stacjaId.Value && s.Sprawny == true)
                .OrderBy(s => s.NumerMiejsca)
                .Select(s => new ForeignKeyIdAndNameRecord
                {
                    Id = s.StojakId,
                    Name = s.NumerMiejsca.ToString()
                })
                .ToList();
            Fill(DostepneStojaki, stojaki); // wypelnienie dostepnych stojakow przefiltrowanymi stojakami
            OstatniStojakId = null; // ustawienie ostatniego stojaka na null
        }

        #endregion ComboBoxList
    }
}