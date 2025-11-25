using BikeRental.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;

namespace BikeRental.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {

                new CommandViewModel(
                    "Dodaj/edytuj Klienta",
                    new BaseCommand(() => this.CreateView(new NowyKlientViewModel()))),

                new CommandViewModel(
                    "Klienci",
                    new BaseCommand(() => this.ShowAll<KlienciViewModel>())),

                new CommandViewModel(
                    "Platnosci",
                    new BaseCommand(() => this.ShowAll<PlatnosciViewModel>())),

                new CommandViewModel(
                    "Dodaj/edytuj platnosc",
                    new BaseCommand(() => this.CreateView(new NowaPlatnoscViewModel()))),

                new CommandViewModel(
                    "Rezerwacje",
                    new BaseCommand(() => this.ShowAll<RezerwacjeViewModel>())),

                   new CommandViewModel(
                    "Dodaj/edytuj rezerwacje",
                    new BaseCommand(() => this.CreateView(new NowaRezerwacjaViewModel()))),

                new CommandViewModel(
                    "Dodaj/edytuj rower",
                    new BaseCommand(() => this.CreateView(new NowyRowerViewModel()))),

                new CommandViewModel(
                    "Rowery",
                    new BaseCommand(() => this.ShowAll<RoweryViewModel>())),

                new CommandViewModel(
                    "Dodaj/edytuj stacje",
                    new BaseCommand(() => this.CreateView(new NowaStacjaViewModel()))),

                new CommandViewModel(
                    "Stacje",
                    new BaseCommand(() => this.ShowAll<StacjeViewModel>())),

                new CommandViewModel(
                    "Aktywne wypozyczenia",
                    new BaseCommand(() => this.ShowAll<AktywneWypozyczeniaViewModel>())),

                new CommandViewModel(
                    "Dodaj/edytuj wypozyczenie",
                    new BaseCommand(() => this.CreateView(new NoweWypozyczenieViewModel()))),

                new CommandViewModel(
                    "Dodaj/edytuj modele",
                    new BaseCommand(() => this.CreateView(new NowyModelRoweruViewModel()))),

                new CommandViewModel(
                    "Modele rowerow",
                    new BaseCommand(() => this.ShowAll<ModeleRowerowViewModel>())),

                new CommandViewModel(
                    "Dodaj/edytuj stojak",
                    new BaseCommand(() => this.CreateView(new NowyStojakViewModel()))),

                new CommandViewModel(
                    "Stojaki",
                    new BaseCommand(() => this.ShowAll<StojakiViewModel>())),

                new CommandViewModel(
                    "Plany cenowe",
                    new BaseCommand(() => this.ShowAll<PlanCenowyViewModel>())),

                new CommandViewModel(
                    "Dodaj/edytuj plan cenowy",
                    new BaseCommand(() =>  this.CreateView(new NowyPlanCenowyViewModel()))),

                new CommandViewModel(
                    "Oplata wypozyczenia",
                    new BaseCommand(() => this.ShowAll<WypozyczenieOplataViewModel>()))
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace); //dodajemy zakladkie do kolekcji zakladek
            this.SetActiveWorkspace(workspace); //aktywowanie zakladki (zeby byla wlaczona)
        }
        private void ShowAll<T>() where T : WorkspaceViewModel, new() // T musi dziedziczyc po WorkspaceViewModel i ma pusty konstruktor
        {
            T workspace =
                this.Workspaces.FirstOrDefault(vm => vm is T)
                as T;
            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
