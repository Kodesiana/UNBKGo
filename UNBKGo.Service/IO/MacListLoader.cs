using System.Collections.Generic;
using System.IO;

namespace UNBKGo.Service.IO
{
    public class MacListLoader : IMacListLoader
    {
        public IEnumerable<string> EnumerateMacList(string path)
        {
            return File.ReadLines(path);
        }

        public void SaveMacList(string path, IEnumerable<string> macList)
        {
            File.WriteAllLines(path, macList);
        }
    }
}
