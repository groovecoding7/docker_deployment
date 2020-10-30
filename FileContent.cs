using System;
using System.Collections.Generic;
using System.IO;

namespace LogFileViewer
{
    public class FileContent : IFileContent
    {
        public IList<FileLine> Lines { get; set; }
        public String FileId { get; set; }
        public FileContent()
        {
            Lines = new List<FileLine>();
            FileId = Guid.NewGuid().ToString();
        }
        public FileContent(String fileId)
        {
            Lines = new List<FileLine>();
            FileId = fileId;
        }
        public void AddLine(String line)
        {
            Lines.Add(new FileLine(line, Lines.Count+1));
        }
        public IList<IFileLineMatchInfo> Find(String searchTerm)
        {
            IList<IFileLineMatchInfo> matchingLineInfo = new List<IFileLineMatchInfo>();

            for (int lineIdx = 1; lineIdx < Lines.Count; lineIdx++)
            {
                (bool match, int startIdx, int endIdx) = Lines[lineIdx].Find(searchTerm);
                if (match)
                {
                    matchingLineInfo.Add(new FileLineMatchInfo(FileId, lineIdx, startIdx, endIdx));
                }
               
            }
            return matchingLineInfo;
        }

    }

}