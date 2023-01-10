using EmployeeLearning.model.video;

namespace EmployeeLearning.model.jobrole
{
    public class JobRole : IJobRole
    {
        #region CONSTANTS
        private readonly bool VIDEO_IS_WATCHED = true;
        #endregion

        #region PROPERTIES
        public Nullable<int> Id { get; }
        public string? Name { get; }
        public List<Video> LearningPath { get; }
        #endregion

        public JobRole(Nullable<int> id, string? name, List<Video> videos)
        {
            Id = id;
            Name = name;
            LearningPath = videos;
        }

        #region PUBLIC METHODS

        public void addVideo(Video video)
        {
            if (LearningPath.IndexOf(video) < 0)
            {
                LearningPath.Add(video);
            } else
            {
                // Nothing to do; 
            }
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
            var watchedVideos = new List<Video>();
            foreach (Video video in LearningPath)
            {
                if (video.IsWatched == VIDEO_IS_WATCHED)
                {
                    watchedVideos.Add(video);
                } 
            }
            return watchedVideos;
        }

        public List<Video> GetAllVideos()
        {
            return (List<Video>)LearningPath;
        }

        #endregion
    }
}
