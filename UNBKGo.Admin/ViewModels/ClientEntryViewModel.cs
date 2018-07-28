using UNBKGo.Admin.Domain;

namespace UNBKGo.Admin.ViewModels
{
    public class ClientEntryViewModel : PropertyChangedBase
    {
        private string _hostname;
        private string _ipAddress;
        private string _physicalAddress;
        private ClientStatus _status;

        public string Hostname
        {
            get => _hostname;
            set
            {
                _hostname = value; 
                OnPropertyChanged();
            }
        }
        public string IpAddress
        {
            get => _ipAddress;
            set
            {
                _ipAddress = value; 
                OnPropertyChanged();
            }
        }
        public string PhysicalAddress
        {
            get => _physicalAddress;
            set
            {
                _physicalAddress = value; 
                OnPropertyChanged();
            }
        }
        public ClientStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SyncCommand { get; set; }
        public RelayCommand ExambroCommand { get; set; }
        public RelayCommand ShutdownCommand { get; set; }

        public ClientEntryViewModel()
        {
            SyncCommand = new RelayCommand(Sync, x => Status != ClientStatus.Disconnected);
            ExambroCommand = new RelayCommand(Exambro, x => Status != ClientStatus.Disconnected);
            ShutdownCommand = new RelayCommand(Shutdown, x => Status != ClientStatus.Disconnected);
        }

        private void Sync()
        {
            Status = ClientStatus.Ready;
        }

        private void Exambro()
        {
            Status = ClientStatus.Update;
        }

        private void Shutdown()
        {
            Status = ClientStatus.Update;
        }
    }
}
