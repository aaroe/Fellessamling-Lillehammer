using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cageball.Lib.DataServices;

namespace CageballDroid
{
    [Activity(Label = "CageballDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CageballService.Dispatcher = new DispatchAdapter(this);
            SetContentView(Resource.Layout.Main);

            Android.Widget.Button cageballEvents_button = FindViewById<Button>(Resource.Id.allCageballEvents_button);
            cageballEvents_button.Click += getAllCageBallEvents;

            Android.Widget.Button myCageballEvents_button = FindViewById<Button>(Resource.Id.myCageballEvents_button);
            myCageballEvents_button.Click += getMyCageBallEvents;

        }


        public void getAllCageBallEvents(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(AllCageballEventsActivity));
            StartActivity(intent);
        }

        public void getMyCageBallEvents(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(MyCageballEventsActivity));
            StartActivity(intent);
        }

  
    }
}

