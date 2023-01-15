using EmployeeLearning.model.video;

namespace EmployeeLearning.datahandler.videos
{
    public interface IVideosDataHandler
    {
        public void AddVideo(Video video);
        public void RemoveVideoById(Guid videoId);
        public void DisplayAllVideos();
        public Video GetVideoById(Guid videoId);
        public List<Video> GetAllVideos();
    }
}
