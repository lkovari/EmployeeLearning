using EmployeeLearning.model.jobrole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.employee
{
    public interface IEmployee
    {
        public void WatcVideo(int videoId);
        public void MarkAllVideoAsUnWatched();
    }
}
