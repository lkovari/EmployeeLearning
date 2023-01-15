using EmployeeLearning.adapters.displayjobroles;
using EmployeeLearning.adapters.displaymodel;
using EmployeeLearning.model.jobrole;

namespace EmployeeLearning.datahandler.jobroles
{
    public class JobRolesDataHandler : IJobRolesDataHandler
    {
        #region PUBLIC PROPERTIES
        public List<JobRole> JobRoles { get; private set; }
        #endregion

        #region DISPLAY ADAPTERS
        private IDisplayJobRoles displayJobRoles;
        #endregion

        #region CONSTRUCTOR
        public JobRolesDataHandler(List<JobRole> jobRoles, IDisplayJobRoles displayJobRoles)
        {
            JobRoles = jobRoles;
            this.displayJobRoles = displayJobRoles;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Add a JobRole
        /// </summary>
        /// <param name="jobRole">JobRole</param>
        public void AddJobRole(JobRole jobRole)
        {
            JobRoles.Add(jobRole);
        }

        /// <summary>
        /// Display JobRole
        /// </summary>
        public void DisplayJobRoles()
        {
            List<string> jobrRolesToDisplay = new();
            JobRoles.ForEach(jobRole => {
                string textToDisplay = string.Format("ID {0} Name {1} Assigned Videos: {2}",
                    jobRole.Id, jobRole.Name, jobRole.LearningPath.Count);
                jobrRolesToDisplay.Add(textToDisplay);
            });
            AdapterModel adapterModelForAssignedVideos = new();
            adapterModelForAssignedVideos.Tittle = "Available JobRoles";
            adapterModelForAssignedVideos.Data.AddRange(jobrRolesToDisplay);
            displayJobRoles.DisplayJobRole(adapterModelForAssignedVideos);
        }

        /// <summary>
        /// Get all JobRoles
        /// </summary>
        /// <returns>List<JobRole></returns>
        public List<JobRole> GetAllJobRoles()
        {
            return JobRoles;
        }

        /// <summary>
        /// Get JobRole by Id
        /// </summary>
        /// <param name="jobRoleId">Guid</param>
        /// <returns>JobRole</returns>
        public JobRole GetJobRoleById(Guid jobRoleId)
        {
            return JobRoles.Single(jobRole => jobRole.Id == jobRoleId) as JobRole;
        }

        /// <summary>
        /// Remove JobRole by Id
        /// </summary>
        /// <param name="jobRole">Guid</param>
        public void RemoveJobRoleById(Guid jobRoleId)
        {
            JobRoles.Remove(GetJobRoleById(jobRoleId));
        }
        #endregion
    }
}
