using System;

namespace LogFileViewer
{
    public class FileLineMatchInfo : IFileLineMatchInfo
    {
        public String FileId { get; set; }
        public int LineIdx { get; set; }
        public int StartIdx { get; set; }
        public int EndIdx { get; set; }

        public FileLineMatchInfo()
        {

        }
        public FileLineMatchInfo(String fileId, int lineIdx, int startIdx, int endIdx)
        {
            FileId = fileId;
            LineIdx = lineIdx;
            StartIdx = startIdx;
            EndIdx = endIdx;
        }
    }
}