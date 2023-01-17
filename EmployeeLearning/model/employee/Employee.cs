using EmployeeLearning.model.jobrole;

namespace EmployeeLearning.model.employee
{
    public class Employee : BaseModel
    {
        #region PROPERTIES
        public List<JobRole> JobRoles { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Employee(string? name,
            string userName,
            string password,
            List<JobRole> jobRoles) : base(name)
        {
            if (jobRoles == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", jobRoles));
            } else
            {
                if (JobRoles == null) 
                { 
                    JobRoles = new List<JobRole>(); 
                }
                JobRoles.AddRange(jobRoles);
            }
            if (userName == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", userName));
            }
            else
            {
                UserName = userName;
            }
            if (password == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", password));
            }
            else
            {
                Password = password;
            }
        }
        #endregion
    }
}
