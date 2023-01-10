using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;

namespace EmployeeLearning.model.employee
{
    public class Employee : IEmployee
    {
        #region PROPERTIES
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public JobRole JobRole { get; set; }
        #endregion

        public Employee()
        {
            JobRole = new JobRole();
        }

        #region PUBLIC METHODS
        public void WatcVideo(int videoId)
        {
            JobRole.FindVideoById(videoId).MarkAsWatched();
        }

        public void MarkAllVideoAsUnWatched()
        {
            JobRole.MarkAllAsUnWatched();
        }

        public List<Video> GetWatchedVideos()
        {
            return JobRole.LearningPath;
        }

        public Video GetVideoById(int videoId)
        {
            return JobRole.FindVideoById(videoId);
        }
        #endregion
    }
}
