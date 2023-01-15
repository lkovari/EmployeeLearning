using EmployeeLearning.model.jobrole;

namespace EmployeeLearning.model.employee
{
    public class Employee : BaseModel
    {
        #region PROPERTIES
        private JobRole _jobRole;
        public JobRole JobRole { get { return _jobRole; } }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Employee(string? name,
            string userName,
            string password,
            JobRole? jobRole) : base(name)
        {
            if (jobRole == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", jobRole));
            } else
            {
                _jobRole = jobRole;
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
