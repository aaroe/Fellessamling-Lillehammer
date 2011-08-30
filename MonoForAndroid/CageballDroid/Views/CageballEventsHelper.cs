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
using System.IO;
using Cageball.Lib.DataServices;

namespace CageballDroid
{
    public sealed class CageballEventsHelper
    {
        
        public static CageballEventsViewModel SetCageballEvents(Stream stream)
        {
            
                var viewModel = new CageballEventsViewModel();
                #region Temperær XML response stream. Slett nå tjenestene på plass
                viewModel.CageballService.TemporaryResponseStream = stream;
                #endregion
                viewModel.SetMyCageballEvents();
                return viewModel;

        }

    }
}

