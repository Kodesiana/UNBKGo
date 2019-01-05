using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using UNBKGo.Service.Application;

namespace UNBKGo.Monitor.ViewModels
{
    public class WakeLanViewModel : NotifyPropertyChangedBase
    {
        public WakeLanViewModel(Dispatcher context) : base(context)
        {
        }
    }
}
