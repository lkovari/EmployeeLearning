using EmployeeLearning.model.video;

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
