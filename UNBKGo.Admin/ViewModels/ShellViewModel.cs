using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UNBKGo.Admin.Annotations;
using UNBKGo.Admin.Domain;

namespace UNBKGo.Admin.ViewModels
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        string name;

        public ObservableCollection<ClientEntry> Dgv { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(CanSayHello));
            }
        }

        public ShellViewModel()
        {
            Dgv = new ObservableCollection<ClientEntry>();
            Dgv.Add(new ClientEntry
            {
                Hostname = "FAHMI-PC",
                IpAddress="192.168.1.1",
                PhysicalAddress = "FF-FF-FF-FF-FF-FF",
                Status = "Connected"
            });
        }

        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello()
        {
            MessageBox.Show(string.Format("Hello {0}!", Name)); //Don't do this in real life :)
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
