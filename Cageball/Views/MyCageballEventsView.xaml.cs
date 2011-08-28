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
    public partial class MyCageballEventsView : PhoneApplicationPage
    {
        MyCageballEventsViewModel _viewModel;

        public MyCageballEventsView()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MyCageballEventsView_Loaded);
        }

        
        void MyCageballEventsView_Loaded(object sender, RoutedEventArgs e)
        {
 

            var service = new CageballService();
            var fileUri = new Uri("Cageball;component/Content/CageballEvents.xml", UriKind.Relative);

            using (var stream = Application.GetResourceStream(fileUri).Stream)
            {
                _viewModel = new MyCageballEventsViewModel(stream);
                DataContext = _viewModel;
            }

        }

        private void MenyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void _myCageballevents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var entry = (CageballEvent)listbox.SelectedItem;

            if (entry != null)
            {
                Uri sigedCageballEvent = new Uri(string.Format("/../Views/SignedCageballEvent.xaml?id={0}&meldMeg={1}", entry.Id, " av"), UriKind.Relative);
                NavigationService.Navigate(sigedCageballEvent);
            }
        }
    }
}