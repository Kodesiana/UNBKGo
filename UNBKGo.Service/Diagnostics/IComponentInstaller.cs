using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNBKGo.Service.Diagnostics
{
    public interface IComponentInstaller
    {
        void Install();
        void Uninstall();
    }
}
