using System;

namespace UNBKGo.Service.IO
{
    public interface IFileRegistrar
    {
        string StoragePath { get; set; }

        void Store(string source, FileKind type);
        FileDescriptor GetDescriptorForRequest(Uri uri);
    }
}