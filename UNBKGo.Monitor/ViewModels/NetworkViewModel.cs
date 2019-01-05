using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using UNBKGo.Service.Application;

namespace UNBKGo.Monitor.ViewModels
{
    public class NetworkViewModel : NotifyPropertyChangedBase
    {
        public RelayCommand MulaiCommand { get; set; }

        public NetworkViewModel(Dispatcher context) : base(context)
        {
        }
    }
}
