using System;
using System.IO;
using UNBKGo.Service.Net;

namespace UNBKGo.Service.IO
{
    public class FileRegistrar : IFileRegistrar
    {
        private const string ClientUri = "/client";
        private const string ChromeUri = "/chrome";
        private const string ExambroUri = "/exambro";
        private const string NetFrameworkUri = "/netfx";
        
        private readonly IFileSystemAdapter _fileSystem;

        public string StoragePath { get; set; }

        public FileRegistrar(IFileSystemAdapter fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Store(string source, FileKind type)
        {
            var path = Path.Combine(StoragePath, GetFileNameForType(type));
            _fileSystem.CopyFile(source, path, true);
        }

        public static string GetUrlForFile(string serverHost, FileKind type)
        {
            return $"http://{serverHost}/{GetUriForFileType(type)}";
        }

        public FileDescriptor GetDescriptorForRequest(Uri uri)
        {
            FileKind type = GetFileKindForUri(uri);
            string fileName = GetFileNameForType(type);
            string fullPath = Path.Combine(StoragePath, fileName);
            if (type == FileKind.Index)
            {
                return new FileDescriptor
                {
                    FilePath = fullPath,
                    IsExist = _fileSystem.ExistsFile(fullPath),
                    MimeType = "text/html"
                };
            }
            return new FileDescriptor
            {
                FilePath = fullPath,
                IsExist = _fileSystem.ExistsFile(fullPath),
                MimeType = "application/octet-stream"
            };
        }

        #region Private Methods

        private string GetFileNameForType(FileKind type)
        {
            switch (type)
            {
                case FileKind.Client:
                    return "UNBKGoClient.zip";
                case FileKind.NetFramework:
                    return "NetFxSetup.exe";
                case FileKind.GoogleChrome:
                    return "ChromeSetup.exe";
                case FileKind.ExamBrowser:
                    return "Exambro.zip";
                case FileKind.Index:
                    return "index.html";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private FileKind GetFileKindForUri(Uri uri)
        {
            switch (uri.AbsolutePath)
            {
                case ClientUri:
                    return FileKind.Client;
                case NetFrameworkUri:
                    return FileKind.NetFramework;
                case ChromeUri:
                    return FileKind.GoogleChrome;
                case ExambroUri:
                    return FileKind.ExamBrowser;
                default:
                    return FileKind.Index;
            }
        }

        private static string GetUriForFileType(FileKind type)
        {
            switch (type)
            {
                case FileKind.Client:
                    return ClientUri;
                case FileKind.NetFramework:
                    return NetFrameworkUri;
                case FileKind.GoogleChrome:
                    return ChromeUri;
                case FileKind.ExamBrowser:
                    return ExambroUri;
                case FileKind.Index:
                    return "";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        } 

        #endregion
    }
}
