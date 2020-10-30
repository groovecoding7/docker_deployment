using System;
using System.Collections.Generic;

namespace LogFileViewer
{
    public interface IFileContent
    {
        IList<FileLine> Lines { get; set; }
        String FileId { get; set; }
        void AddLine(String line);
        IList<IFileLineMatchInfo> Find(String searchTerm);
    }
}