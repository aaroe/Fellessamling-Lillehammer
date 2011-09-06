using System;
using System.Windows;
using Cageball.Lib.Model;
using Cageball.Lib.ViewModel;

namespace Cageball.Views
{
    public partial class SignedCageballEventView
    {
        int _id;
        bool _signUp;

        public SignedCageballEventView()
        {
            InitializeComponent();
            Loaded += SignedCageballEventLoaded;
           
        }

        void SignedCageballEventLoaded(object sender, RoutedEventArgs e)
        {
            _id = Convert.ToInt32(NavigationContext.QueryString["id"]);
            
            if (_id == 0)
                throw new ArgumentException("CageballId 0 er ikke gyldig!");

            
            SetTextOnButton();
        }

        private void SetTextOnButton()
        {
            _signUp = Convert.ToBoolean(NavigationContext.QueryString["signUp"]);

            if (_signUp)
                SignupBtn.Content += " på";
            else
                SignupBtn.Content += " av";
        }


        private void SignupBtnClick(object sender, RoutedEventArgs e)
        {
            var cageballService = new SignedCageballEventViewModel();

            ResponseEntity retur = cageballService.SignUpForCageballEvent(_id,_signUp);
              responseTxt.Text = retur.Description;
              SignupBtn.IsEnabled = retur.Error;

        }
    }
}