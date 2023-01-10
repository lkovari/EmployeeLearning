using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.video
{
    public interface IVideoController
    {
        public void MarkAsWatched();
        public void MarkAsUnWatched();
    }
}
