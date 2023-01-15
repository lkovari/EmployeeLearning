using EmployeeLearning.controller.video;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;

namespace EmployeeLearning.datahandler.jobrole
{
    public class JobRoleDataHandler : IJobRoleDataHandler
    {
        #region PROPERTIES
        public JobRole JobRole { get; private set; }
        #endregion

        #region CONSTRUCTOR
        public JobRoleDataHandler(JobRole jobRole)
        {
            JobRole = jobRole;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Assign a Video to the JobRole
        /// </summary>
        /// <param name="video">The Video what should be assign</param>
        public void AssignVideo(Video video)
        {
            JobRole.LearningPath.Add(video);
        }

        /// <summary>
        /// Get Assigned Video by Id
        /// </summary>
        /// <param name="videoId">Guid ~ The Id of the Video</param>
        /// <returns>Video</returns>
        public Video GetAssignedVideoById(Guid videoId)
        {
            return (Video)JobRole.LearningPath.Single(v => v.Id == videoId);
        }

        /// <summary>
        /// Get Assigned Videos of JobTole
        /// </summary>
        /// <returns>The List of Videos</returns>
        public List<Video> GetAssignedVideos()
        {
            return JobRole.LearningPath;
        }

        /// <summary>
        /// Remove the Assigned Video from the Videos of JobRole
        /// </summary>
        /// <param name="videoId">Guid ~ The Id of the Video</param>
        public void RemoveAssignedVideoById(Guid videoId)
        {
            JobRole.LearningPath.Remove(GetAssignedVideoById(videoId));
        }
        #endregion
    }
}
