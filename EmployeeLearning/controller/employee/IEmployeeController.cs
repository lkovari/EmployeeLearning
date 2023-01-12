using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.employee
{
    public interface IEmployeeController
    {
        public List<Video> GetAssignedVideos();
        public void DisplayJobRoleBasedAssignedVideos();
        public void DisplayWatchHistory();
        public void WatchingAVideo(int videoId);
    }
}
