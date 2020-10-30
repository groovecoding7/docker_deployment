using System;

namespace LogFileViewer
{
    public class FileLine
    {
        public int LineIdx { get; set; }
        public String Line { get; set; }

        public FileLine()
        {
        }
        public FileLine(String line, int lineIdx)
        {
            Line = line;
            LineIdx = lineIdx;
        }
        public (bool match, int startIdx, int endIdx) Find(String searchTerm)
        {
            int startIdx = Line.IndexOf(searchTerm);
            int endIdx = -1;
            if (startIdx != -1)
            {
                endIdx = startIdx + searchTerm.Length;
            }
            return (startIdx!=-1, startIdx, endIdx);
        }

    }

}