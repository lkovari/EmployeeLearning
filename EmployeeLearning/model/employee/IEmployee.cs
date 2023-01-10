using EmployeeLearning.model.video;


namespace EmployeeLearning.model.employee
{
    public interface IEmployee
    {
        public void WatcVideo(int videoId);
        public void MarkAllVideoAsUnWatched();
        public List<Video> GetWatchedVideos();
        public Video GetVideoById(int videoId);
    }
}
