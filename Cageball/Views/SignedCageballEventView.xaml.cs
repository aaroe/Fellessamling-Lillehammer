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
    public partial class SignedCageballEventView : PhoneApplicationPage
    {
        int id;
        bool signUp;

        public SignedCageballEventView()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(SignedCageballEvent_Loaded);
           
        }

        void SignedCageballEvent_Loaded(object sender, RoutedEventArgs e)
        {
            id = Convert.ToInt32(NavigationContext.QueryString["id"]);
            
            if (id == 0)
                throw new ArgumentException("CageballId 0 er ikke gyldig!");

            
            SetTextOnButton();
        }

        private void SetTextOnButton()
        {
            signUp = Convert.ToBoolean(NavigationContext.QueryString["signUp"]);

            if (signUp)
                SignupBtn.Content += " på";
            else
                SignupBtn.Content += " av";
        }


        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            var cageballService = new SignedCageballEventViewModel();
               
              ResponseEntity retur;
              retur = cageballService.SignUpForCageballEvent(id,signUp);
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