using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace UNBKGo.Service.Application
{
    public class NotifyPropertyChangedBase : IAutoNotifyPropertyChanged
    {
        protected Dispatcher Synchronization { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public NotifyPropertyChangedBase(Dispatcher context)
        {
            Synchronization = context;
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var invocation = new Action(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
            if (Synchronization != null)
            {
                Synchronization.Invoke(invocation);
            }
            else
            {
                invocation();
            }
        }
    }
}
