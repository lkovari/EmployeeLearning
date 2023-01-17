using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;

namespace EmployeeLearning.datahandler.employee
{
    public interface IEmployeeDataHandler
    {
        public List<JobRole> GetJobRoles();
        public JobRole GetJobRoleById(Guid jobRoleId);
        public void RemoveJobRoleById(Guid jobRoleId);
        public void AddJobRole(JobRole jobRole);
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
