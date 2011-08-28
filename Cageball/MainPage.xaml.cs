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

namespace Cageball
{
    public partial class MainPage : PhoneApplicationPage
    {

        public MainPage()
        {
            InitializeComponent();
         
        }

        void AllCageballEventsBtn_Click(object sender, RoutedEventArgs e)
            
        {
            var _allCageballEventsView = new Uri("/Views/AllCageballEventsView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(_allCageballEventsView);
        }

        private void MyCageballEvents_Click(object sender, RoutedEventArgs e)
        {
            var _myCageballEventsView = new Uri("/Views/MyCageballEventsView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(_myCageballEventsView);
        }

        private void CreateCageballEvent_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}