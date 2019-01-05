using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNBKGo.Service.IO
{
    public class FileSystemAdapter : IFileSystemAdapter
    {
        public string GetExecutableDirectory()
        {
            throw new NotImplementedException();
        }

        public void MoveFile(string source, string dest, bool overwrite = false)
        {
            throw new NotImplementedException();
        }

        public void CopyFile(string source, string dest, bool overwrite = false)
        {
            throw new NotImplementedException();
        }

        public bool ExistsFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool ExistsDir(string path)
        {
            throw new NotImplementedException();
        }
    }
}
