using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNBKGo.Admin.Domain
{
    public class ClientEntry
    {
        public string Hostname { get; set; }
        public string IpAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string Status { get; set; }
    }
}
