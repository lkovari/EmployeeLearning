using EmployeeLearning.model.video;

namespace EmployeeLearning.datahandler.jobrole
{
    public interface IJobRoleDataHandler
    {
        public void AssignVideo(Video video);
        public void RemoveAssignedVideoById(Guid videoId);
        public Video GetAssignedVideoById(Guid videoId);
        public List<Video> GetAssignedVideos();
    }
}
