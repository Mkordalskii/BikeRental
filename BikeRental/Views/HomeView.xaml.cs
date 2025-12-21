using BikeRental.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace BikeRental.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }
        private void NoweWypozyczenie_Click(object sender, RoutedEventArgs e)
        {
            var mainVm = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainVm == null) return;

            mainVm.CreateView(new NoweWypozyczenieViewModel());
        }
        private void NowaRezerwacja_Click(object sender, RoutedEventArgs e)
        {
            var mainVm = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainVm == null) return;

            mainVm.CreateView(new NowaRezerwacjaViewModel());
        }
        private void NowyKlient_Click(object sender, RoutedEventArgs e)
        {
            var mainVm = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainVm == null) return;

            mainVm.CreateView(new NowyKlientViewModel());
        }
    }
}
