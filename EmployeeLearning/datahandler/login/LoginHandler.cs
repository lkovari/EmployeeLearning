using EmployeeLearning.datahandler.employees;
using EmployeeLearning.model.employee;
using EmployeeLearning.testdata.digest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.datahandler.login
{
    public class LoginHandler : ILoginHandler
    {
        #region PUBLIC PROPERTIES
        public IEmployeesDataHandler employeesDataHandler;
        #endregion

        LoginHandler(IEmployeesDataHandler employeesDataHandler)
        {
            this.employeesDataHandler = employeesDataHandler;
        }

        public bool Login(string username, string password)
        {
            string digest = CreateDigest.GenerateDigest(password);
            Employee? foundEmployee = employeesDataHandler.GetEmployeeByUserName(username);
            bool isPasswordMatched = foundEmployee != null && foundEmployee.Password == digest;
            foundEmployee.IsAuthenticated = isPasswordMatched;
            return isPasswordMatched;
        }
    }
}
