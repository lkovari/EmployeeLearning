using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.adapters.watchhistory
{
    public class DisplayHistoryOfWatchedVideosConsoleAdapter : IDisplayHistoryOfWatchedVideos
    {
        public void DisplayHistory(string text)
        {
            Console.WriteLine(text);
        }
    }
}
