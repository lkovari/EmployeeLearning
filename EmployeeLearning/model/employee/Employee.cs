using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;

namespace EmployeeLearning.model.employee
{
    public class Employee : BaseModel, IEmployee
    {
        #region CONSTANTS
        private readonly bool VIDEO_IS_WATCHED = true;
        #endregion

        #region PROPERTIES
        private JobRole _jobRole;
        public JobRole JobRole { get { return _jobRole; } }
        public bool IsAuthenticated { get; set; }
        #endregion

        public Employee(Nullable<int> id, string? name, JobRole? jobRole) : base(id, name)
        {
            if (jobRole == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", jobRole));
            } else
            {
                _jobRole = jobRole;
            }
        }

        #region PUBLIC METHODS
        public void WatchAVideo(int videoId)
        {
            JobRole.FindVideoByIdOfJobRole(videoId).VideoMarkAsWatched();
        }

        public void ResetVideoWatches()
        {
            JobRole.ResetVideoWatches();
        }

        public List<Video> GetWatchedVideos()
        {
            var watchedVideos = new List<Video>();
            foreach (Video video in _jobRole.LearningPath)
            {
                if (video.IsWatched == VIDEO_IS_WATCHED)
                {
                    watchedVideos.Add(video);
                }
            }
            return watchedVideos;
        }

        public Video GetVideoById(int videoId)
        {
            return JobRole.FindVideoByIdOfJobRole(videoId);
        }

        public List<Video> GetAssignedVideos()
        {
            return JobRole.GetAssignedVideosOfJobRole();
        }
        #endregion
    }
}
