namespace UNBKGo.Service.IO
{
    public interface IFileSystemAdapter
    {
        string GetExecutableDirectory();
        void MoveFile(string source, string dest, bool overwrite = false);
        void CopyFile(string source, string dest, bool overwrite = false);
        bool ExistsFile(string path);
        bool ExistsDir(string path);
    }
}
