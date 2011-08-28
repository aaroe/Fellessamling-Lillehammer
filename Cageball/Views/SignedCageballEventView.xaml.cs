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
    public partial class SignedCageballEvent : PhoneApplicationPage
    {
        int?  id;
        string påEllerAv;

        public SignedCageballEvent()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(SignedCageballEvent_Loaded);
           
        }

        void SignedCageballEvent_Loaded(object sender, RoutedEventArgs e)
        {
            id = Convert.ToInt32(NavigationContext.QueryString["id"]);
            påEllerAv = NavigationContext.QueryString["meldMeg"];
            SignupBtn.Content += påEllerAv;

            if (id == null)
                throw new ArgumentException();

            
        }


        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            var cageballService = new SignedCageballEventViewModel();
               
              ResponseEntity retur;
              bool signUp = påEllerAv ==" på";
              retur = cageballService.SignUpForCageballEvent(id.Value,signUp);
              responseTxt.Text = retur.Description;
              SignupBtn.IsEnabled = retur.Error;

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void MenyBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}