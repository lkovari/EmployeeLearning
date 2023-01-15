using EmployeeLearning.model.video;

namespace EmployeeLearning.datahandler.videos
{
    public interface IVideosDataHandler
    {
        public void addVideo(Video video);
        public void removeVideoById(Guid videoId);
        public void displayAllVideos();
        public Video GetVideoById(Guid videoId);
        public List<Video> getAllVideos();
    }
}
