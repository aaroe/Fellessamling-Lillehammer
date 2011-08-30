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
using Cageball.Lib.ViewModel;
using Cageball.Lib.Model;

namespace CageballDroid
{
    [Activity(Label = "My Activity")]
    public class MyCageballEventsActivity : ListActivity
    {
        CageballEventsViewModel viewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.CageballEventsActivity);

            using (var stream = Assets.Open("CageballEvents.xml"))
            {
                viewModel = CageballEventsHelper.SetCageballEvents(stream); 
                ListAdapter = new ArrayAdapter<CageballEvent>(this, Android.Resource.Layout.SimpleListItem1, viewModel.CageballEvents);
            }

            ListView.ItemClick += ListView_ItemClick;
        }

        void ListView_ItemClick(object sender, ItemEventArgs e)
        {
            viewModel.SelectedCageballEvent = viewModel.CageballEvents[e.Position];
            var intent = new Intent();
            intent.SetClass(this, typeof(SignedCageballEventActivity));
            intent.PutExtra("id", viewModel.SelectedCageballEvent.Id);
            intent.PutExtra("signUp", false);
            
            StartActivity(intent);
        }
    }
}