using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using Cageball.Lib.ViewModel;
using Cageball.Lib.DataServices;

namespace Cageball.Views
{
    public class CageballEventHelper : PhoneApplicationPage
    {

        public static CageballEventsViewModel SetCageballEvents()
        {
            var fileUri = new Uri("Cageball;component/Content/CageballEvents.xml", UriKind.Relative);

            using (var stream = Application.GetResourceStream(fileUri).Stream)
            {
                var _viewModel = new CageballEventsViewModel();
               // Temperær XML response stream. Slett nå tjenestene på plass
                _viewModel.CageballService.TemporaryResponseStream = stream;
                _viewModel.SetAllCageballEvents();
                return _viewModel;
            }
        }
    }
}
