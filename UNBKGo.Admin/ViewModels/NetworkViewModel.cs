using System.Collections.ObjectModel;
using System.Windows.Input;
using UNBKGo.Admin.Domain;

namespace UNBKGo.Admin.ViewModels
{
    public class NetworkViewModel : PropertyChangedBase
    {
        public ObservableCollection<ClientEntryViewModel> ClientItems { get; set; }

        public ICommand BroadcastSyncCommand { get; set; }
        public ICommand BroadcastExambroCommand { get; set; }
        public ICommand BroadcastShutdownCommand { get; set; }

        public NetworkViewModel()
        {
            BroadcastSyncCommand = new RelayCommand(BroadcastSync_Command);
            BroadcastExambroCommand = new RelayCommand(BroadcastExambro_Command);
            BroadcastShutdownCommand = new RelayCommand(BroadcastShutdown_Command);

            ClientItems = new ObservableCollection<ClientEntryViewModel>
            {
                new ClientEntryViewModel
                {
                    Hostname = "FAHMI-PC",
                    IpAddress = "192.168.1.1",
                    PhysicalAddress = "FF-FF-FF-FF-FF-FF",
                    Status = ClientStatus.Ready
                },
                new ClientEntryViewModel
                {
                    Hostname = "FAHMI-PC",
                    IpAddress = "192.168.1.1",
                    PhysicalAddress = "FF-FF-FF-FF-FF-FF",
                    Status = ClientStatus.Update
                },
                new ClientEntryViewModel
                {
                    Hostname = "FAHMI-PC",
                    IpAddress = "192.168.1.1",
                    PhysicalAddress = "FF-FF-FF-FF-FF-FF",
                    Status = ClientStatus.Disconnected
                },
            };
        }

        private void BroadcastSync_Command()
        {
            foreach (ClientEntryViewModel item in ClientItems)
            {
                item.SyncCommand.Execute(null);
            }
        }

        private void BroadcastExambro_Command()
        {
            foreach (ClientEntryViewModel item in ClientItems)
            {
                item.ExambroCommand.Execute(null);
            }
        }

        private void BroadcastShutdown_Command()
        {
            foreach (ClientEntryViewModel item in ClientItems)
            {
                item.ShutdownCommand.Execute(null);
            }
        }
    }
}
