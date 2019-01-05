using System.Collections.Generic;

namespace UNBKGo.Service.IO
{
    public interface IMacListLoader
    {
        IEnumerable<string> EnumerateMacList(string path);
        void SaveMacList(string path, IEnumerable<string> macList);
    }
}