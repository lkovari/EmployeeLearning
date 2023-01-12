using EmployeeLearning.model.video;

namespace EmployeeLearning.model.jobrole
{
    public class JobRole : BaseModel, IJobRole
    {

        #region PROPERTIES
        public List<Video> LearningPath { get; }
        #endregion

        public JobRole(Nullable<int> id, string? name, List<Video>? videos) : base(id, name)
        {
            if (videos == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", videos));
            }
            else
            {
                LearningPath = videos;
            }
        }

        #region PUBLIC METHODS

        public void AssignVideoToJobRole(Video video)
        {
            if (LearningPath.IndexOf(video) < 0)
            {
                LearningPath.Add(video);
            } else
            {
                throw new Exception("AddVideo: Video already exists!");
            }
        }

        public void UnassignedVideoFromJobRole(int videoId)
        {
            LearningPath.Remove(FindVideoByIdOfJobRole(videoId));
        }

        public Video FindVideoByIdOfJobRole(int videoId)
        {
            return ((Video)(from video in LearningPath where video.Id == videoId select video));
        }

        public void ResetVideoWatches()
        {
            LearningPath.ForEach(v => v.VideoMarkAsUnWatched());
        }

        public List<Video> GetAssignedVideosOfJobRole()
        {
            return (List<Video>)LearningPath;
        }

        #endregion
    }
}
