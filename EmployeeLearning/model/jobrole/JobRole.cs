using EmployeeLearning.model.video;

namespace EmployeeLearning.model.jobrole
{
    public class JobRole : IJobRole
    {
        #region CONSTANTS
        private readonly bool VIDEO_IS_WATCHED = true;
        #endregion

        #region PROPERTIES
        public Int32? Id { get; set; }
        public string? Name { get; set; }


        public List<Video> LearningPath { get; set; }
        #endregion

        public JobRole()
        {
            LearningPath = new List<Video>();
        }

        #region PUBLIC METHODS

        public void addVideo(Video video)
        {
            LearningPath.Add(video);
        }
        public void removeVideo(int videoId)
        {
            LearningPath.Remove(FindVideoById(videoId));
        }

        public Video FindVideoById(int videoId)
        {
            return ((Video)(from video in LearningPath where video.Id == videoId select video));
        }

        public void MarkAllAsUnWatched()
        {
            LearningPath.ForEach(v => v.MarkAsUnWatched());
        }

        public List<Video> GetWatchedVideos()
        {
            return (List<Video>)LearningPath.Where(v => v.IsWatched == VIDEO_IS_WATCHED);
        }

        public List<Video> GetAllVideos()
        {
            return (List<Video>)LearningPath;
        }

        #endregion
    }
}
