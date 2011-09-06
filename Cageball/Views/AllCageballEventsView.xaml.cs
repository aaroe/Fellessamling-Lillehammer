using System;
using System.Windows;
using System.Windows.Controls;
using Cageball.Lib.ViewModel;

namespace Cageball.Views
{
    public partial class AllCageballEventsView
    {
        public AllCageballEventsView()
        {
            InitializeComponent();
            Loaded += AllCageballEventsViewLoaded;
        }

        CageballEventsViewModel _viewModel;

        void AllCageballEventsViewLoaded(object sender, RoutedEventArgs e)
        {

            var fileUri = new Uri("Cageball;component/Content/CageballEvents.xml", UriKind.Relative);
            using (var stream = Application.GetResourceStream(fileUri).Stream)
            {
                     _viewModel = new CageballEventsViewModel();
                    DataContext = _viewModel;
                    _viewModel.CageballService.SetDummyAllCageballEventsResponse(stream);
                    _viewModel.SetAllCageballEvents();
            }
        }



        private void CageballeventsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
 
            if (_viewModel.SelectedCageballEvent != null)
            {
                var sigedCageballEvent = new Uri(String.Format("/../Views/SignedCageballEventView.xaml?id={0}&signUp={1}", _viewModel.SelectedCageballEvent.Id, true), UriKind.Relative);
                NavigationService.Navigate(sigedCageballEvent);
            }
        }
    }
}