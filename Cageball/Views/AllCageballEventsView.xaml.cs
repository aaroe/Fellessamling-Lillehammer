using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Cageball.Lib.DataServices;
using Cageball.Lib.Model;
using Cageball.Lib.ViewModel;

namespace Cageball.Views
{
    public partial class AllCageballEventsView : PhoneApplicationPage
    {
        public AllCageballEventsView()
        {
            InitializeComponent();
            Loaded += AllCageballEventsView_Loaded;
        }

        AllCageballEventsViewModel _viewModel;

        void AllCageballEventsView_Loaded(object sender, RoutedEventArgs e)
        {

            var service = new CageballService();
            var fileUri = new Uri("Cageball;component/Content/CageballEvents.xml", UriKind.Relative);

            using (var stream = Application.GetResourceStream(fileUri).Stream)
            {
                _viewModel = new AllCageballEventsViewModel(stream);
                DataContext = _viewModel;           
            }
                 
        }



        private void _cageballevents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Uten databinding:
            //var listbox = (ListBox)sender;
            //var entry = (CageballEvent)listbox.SelectedItem;

            //if (entry != null)
            //{
            //    Uri sigedCageballEvent = new Uri("/../Views/SignedCageballEvent.xaml?id=" + entry.Id, UriKind.Relative);
            //    NavigationService.Navigate(sigedCageballEvent);
            //}


            //Uten databinding:
            if (_viewModel.SelectedCageballEvent != null)
            {
                Uri sigedCageballEvent = new Uri(String.Format("/../Views/SignedCageballEvent.xaml?id={0}&meldMeg={1}", _viewModel.SelectedCageballEvent.Id," på"), UriKind.Relative);
                NavigationService.Navigate(sigedCageballEvent);
            }
        }

        private void MenyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}