using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.adapters.assignedvideos
{
    public class DisplayAssignedVideosConsoleAdapter : IDisplayAssignedVideos
    {
        public void DisplayAssignedVideos(string text)
        {
            Console.WriteLine(text);
        }
    }
}
