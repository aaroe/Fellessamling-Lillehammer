using System;
using System.Windows;
using Cageball.Lib;

namespace Cageball
{
    public class DispatchAdapter : IDispatchOnUIThread
    {
        public void Invoke(Action action)
        {
            Deployment.Current.Dispatcher.BeginInvoke(action);

        }
    }
}
