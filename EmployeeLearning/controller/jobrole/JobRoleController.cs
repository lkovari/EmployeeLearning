using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.jobrole
{
    public class JobRoleController : IJobRoleControler
    {
        private JobRole _jobRole;

        public JobRoleController(JobRole jobRole) { 
            _jobRole = jobRole;
        }

        public void addVideo(Video video)
        {
            _jobRole.addVideo(video);
        }

        public void removeVideo(int videoId)
        {
            _jobRole.removeVideo(videoId);
        }
    }
}
