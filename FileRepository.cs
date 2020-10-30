using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LogFileViewer
{
    public class FileRepository 
    {
        public ConcurrentDictionary<String, IFileContent> Files
        {
            get;
            set;
        }

        public FileRepository()
        {
            String id = "fileId";

            Files = new ConcurrentDictionary<string, IFileContent>();
            FileContent fc = new FileContent(id);
            for (int i = 0; i < 5; i++)
            {
                fc.AddLine($"Line____{i}");
            }
            Files.TryAdd(id, fc);
        }
        public void AddFile(IFileContent ifc)
        {
            Files.TryAdd(ifc.FileId, ifc);
        }
    }
}