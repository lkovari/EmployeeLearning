using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;

namespace EmployeeLearning.model.employee
{
    public class Employee : IEmployee
    {
        #region PROPERTIES
        private Nullable<int> _id;
        public Nullable<int> Id { get { return _id; } }
        
        private string? _lastName;
        public string LastName { get { return _lastName; } }

        private string? _firstName;
        public string? FirstName { get { return _firstName; } }

        private JobRole _jobRole;
        public JobRole JobRole { get { return _jobRole; } }
        #endregion

        public Employee(Nullable<int> id, string? lastName, string? firstName, JobRole jobRole)
        {
            _id = id;
            _lastName = lastName;
            _firstName = firstName;
            _jobRole = jobRole;
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
            return JobRole.GetWatchedVideos();
        }

        public Video GetVideoById(int videoId)
        {
            return JobRole.FindVideoById(videoId);
        }
        #endregion
    }
}
