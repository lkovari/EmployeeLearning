using EmployeeLearning.datahandler.employees;
using EmployeeLearning.model.employee;
using EmployeeLearning.testdata.digest;

namespace EmployeeLearning.datahandler.login
{
    public class LoginHandler : ILoginHandler
    {
        #region PUBLIC PROPERTIES
        private IEmployeesDataHandler employeesDataHandler;
        #endregion

        #region CONSTRUCTOR
        public LoginHandler(IEmployeesDataHandler employeesDataHandler)
        {
            this.employeesDataHandler = employeesDataHandler;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Login an Employee
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>true if success false if failed</returns>
        public bool Login(string username, string password)
        {
            string digest = CreateDigest.GenerateDigest(password);
            Employee? foundEmployee = employeesDataHandler.GetEmployeeByUserName(username);
            bool isPasswordMatched = foundEmployee != null && foundEmployee.Password == digest;
            foundEmployee.IsAuthenticated = isPasswordMatched;
            return isPasswordMatched;
        }
        #endregion
    }
}
