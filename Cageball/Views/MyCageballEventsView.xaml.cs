using System;
using System.Windows;
using System.Windows.Controls;
using Cageball.Lib.Model;
using Cageball.Lib.ViewModel;

namespace Cageball.Views
{
    public partial class MyCageballEventsView
    {
        CageballEventsViewModel _viewModel;

        public MyCageballEventsView()
        {
            InitializeComponent();
            Loaded += MyCageballEventsViewLoaded;
        }


        void MyCageballEventsViewLoaded(object sender, RoutedEventArgs e)
        {

            var fileUri = new Uri("Cageball;component/Content/CageballEvents.xml", UriKind.Relative);
            using (var stream = Application.GetResourceStream(fileUri).Stream)
            {
                _viewModel = new CageballEventsViewModel();
                DataContext = _viewModel;
                _viewModel.CageballService.SetDummyMyCageballEventsResponse(stream);
                _viewModel.SetMyCageballEvents();
            }
        }

        private void MyCageballeventsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var entry = (CageballEvent)listbox.SelectedItem;

            if (entry == null) return;
            var sigedCageballEvent = new Uri(string.Format("/../Views/SignedCageballEventView.xaml?id={0}&signUp={1}", entry.Id, false), UriKind.Relative);
            NavigationService.Navigate(sigedCageballEvent);
        }
    }
}