using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UNBKGo.Service.Application
{
    public interface IAutoNotifyPropertyChanged : INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}
