using EmployeeLearning.adapters.displaymodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.adapters.displayemployee
{
    public class DisplayEmployeeConsoleAdapter : IDisplayEmployee
    {
        public void DisplayEmployee(AdapterModel model)
        {
            Console.WriteLine();
            Console.WriteLine(model.Tittle);
            Console.WriteLine(model.Text);
            Console.WriteLine();
        }
    }
}
