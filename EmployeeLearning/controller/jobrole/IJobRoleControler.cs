using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.jobrole
{
    public interface IJobRoleControler
    {
        public void addVideo(Video video);
        public void removeVideo(int videoId);
    }
}
