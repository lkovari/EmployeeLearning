using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.datahandler.employee
{
    public interface IEmployeeDataHandler
    {
        public void WatchingAVideo(Guid videoId);
        public void ResetVideoWatches();
        public Video GetAssignedVideoById(Guid videoId);

        public List<Video> GetAssignedVideos();
        public List<Video> GetWatchedVideos();

        public void DisplayEmployee();
        public void DisplayAssignedVideos();
        public void DisplayWatchHistory();
    }
}
