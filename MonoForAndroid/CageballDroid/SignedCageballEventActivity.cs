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
        string påEllerAv;
        int Id;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignedCageballEventActivity);
            signup_button = FindViewById<Button>(Resource.Id.sign_button);
            signup_button.Click += new EventHandler(signup_button_Click);
            Id = bundle.GetInt("id");
            påEllerAv = bundle.GetString("signUp");
            signup_button.Text += påEllerAv;
        
        }

        void signup_button_Click(object sender, EventArgs e)
        {
            bool signUp = påEllerAv == " på";
            ResponseEntity retur = new SignedCageballEventViewModel().SignUpForCageballEvent(Id, signUp);
            Android.Widget.TextView signup_label = FindViewById<TextView>(Resource.Id.signed_text);
            signup_label.Text = retur.Description;
            signup_button.Enabled = retur.Error;
        }

       

    }
}