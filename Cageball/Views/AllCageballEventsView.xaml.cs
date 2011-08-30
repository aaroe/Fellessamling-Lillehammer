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

        CageballEventsViewModel _viewModel;

        void AllCageballEventsView_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = CageballEventHelper.SetCageballEvents();
            DataContext = _viewModel;
        }



        private void _cageballevents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
 
            if (_viewModel.SelectedCageballEvent != null)
            {
                Uri sigedCageballEvent = new Uri(String.Format("/../Views/SignedCageballEventView.xaml?id={0}&signUp={1}", _viewModel.SelectedCageballEvent.Id, true), UriKind.Relative);
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