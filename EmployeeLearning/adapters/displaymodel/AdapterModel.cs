using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.adapters.displaymodel
{
    public class AdapterModel
    {
        public string? Tittle { get; set; }
        public Dictionary<string, object>? Parameters { get; set; }
        public string? Text { get; set; }
    }
}
