using System;

namespace LogFileViewer
{
    public interface IFileLineMatchInfo
    {
        String FileId { get; set; }
        int LineIdx { get; set; }
        int StartIdx { get; set; }
        int EndIdx { get; set; }
    }
}