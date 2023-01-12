using EmployeeLearning.model.video;


namespace EmployeeLearning.model.employee
{
    public interface IEmployee
    {
        public void WatchAVideo(int videoId);
        public void ResetVideoWatches();
        public List<Video> GetWatchedVideos();
        public Video GetVideoById(int videoId);
        public List<Video> GetAssignedVideos();
    }
}
