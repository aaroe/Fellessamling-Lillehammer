using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cageball.Lib.Model;
using Cageball.Lib.ViewModel;

namespace CageballDroid
{
    [Activity(Label = "My Activity")]
    public class SignedCageballEventActivity : Activity
    {
        Android.Widget.Button signup_button;
        bool signUp;
        int id = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignedCageballEventActivity);
            signup_button = FindViewById<Button>(Resource.Id.sign_button);
            signup_button.Click += new EventHandler(Signup_button_Click);
            GetDataFromIntent();
            SetTextOnButtons();
        }

        private void GetDataFromIntent()
        {
            signUp = Intent.GetBooleanExtra("signUp", true);
            id = Intent.GetIntExtra("id", 0);
        }

        private void SetTextOnButtons()
        {
            if (signUp)
                signup_button.Text += " på";
            else
                signup_button.Text += " av";
        }

        void Signup_button_Click(object sender, EventArgs e)
        {
            ResponseEntity retur = new SignedCageballEventViewModel().SignUpForCageballEvent(id, signUp);
            Android.Widget.TextView signup_label = FindViewById<TextView>(Resource.Id.signed_text);
            signup_label.Text = retur.Description;
            signup_button.Enabled = retur.Error;
        }

       

    }
}