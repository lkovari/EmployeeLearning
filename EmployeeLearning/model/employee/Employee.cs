using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;

namespace EmployeeLearning.model.employee
{
    public class Employee : BaseModel
    {
        #region PROPERTIES
        private JobRole _jobRole;
        public JobRole JobRole { get { return _jobRole; } }
        public bool IsAuthenticated { get; set; }
        #endregion

        public Employee(string? name, JobRole? jobRole) : base(name)
        {
            if (jobRole == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", jobRole));
            } else
            {
                _jobRole = jobRole;
            }
        }
    }
}
