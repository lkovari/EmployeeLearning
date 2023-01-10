using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.jobrole
{
    public interface IJobRole
    {
        public Video FindVideoById(int videoId);
        public void MarkAllAsUnWatched();
    }
}
