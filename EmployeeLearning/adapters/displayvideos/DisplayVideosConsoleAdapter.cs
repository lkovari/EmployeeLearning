using EmployeeLearning.adapters.displaymodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.adapters.displayvideos
{
    public class DisplayVideosConsoleAdapter : IDisplayVideos
    {
        void IDisplayVideos.DisplayVideos(AdapterModel model)
        {
            Console.WriteLine();
            Console.WriteLine(model.Tittle);
            if (model.Data != null && model.Data.Count > 0)
            {
                model.Data.ForEach(data => Console.WriteLine(data));
            }
            Console.WriteLine();
        }
    }
}
