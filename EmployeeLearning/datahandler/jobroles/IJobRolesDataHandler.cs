using EmployeeLearning.model.jobrole;

namespace EmployeeLearning.datahandler.jobroles
{
    public interface IJobRolesDataHandler
    {
        public void AddJobRole(JobRole jobRole);
        public void RemoveJobRoleById(Guid jobRoleId);
        public JobRole GetJobRoleById(Guid jobRoleId);
        public List<JobRole> GetAllJobRoles();
        public void DisplayJobRoles();
    }
}
